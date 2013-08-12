//
// This file is part of Monobjc, a .NET/Objective-C bridge
// Copyright (C) 2007-2013 - Laurent Etiemble
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
// 
using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Monobjc.Generators;
using Monobjc.Properties;
using Monobjc.Runtime;

namespace Monobjc
{
	/// <summary>
	///   <para>Entry point of the .NET/Objective-C bridge.</para>
	///   <para>The runtime is responsible for:
	///     <list type = "bullet">
	///       <item>The mapping between managed type and Objective-C classes</item>
	///       <item>The mapping between managed instances and their native counterparts</item>
	///       <item>The sending of message from .NET to Objective-C</item>
	///     </list>
	///   </para>
	///   <para>A lot of magic occurs behind the scene to ensure that managed type and instances are seen as native
	///     in the Objective-C runtime.</para>
	/// </summary>
	public static partial class ObjectiveCRuntime
	{
		private static readonly IList<string> SCANNED_ASSEMBLIES = InitializeAssembliesToSkip ();
		private static bool initialized;
		private static Assembly mscorlibAssembly;
		private static Assembly systemAssembly;

		private static DynamicAssembly DynamicAssembly { get; set; }

		private static BlockGenerator BlockGenerator { get; set; }

		private static CategoryGenerator CategoryGenerator { get; set; }

		private static ClassGenerator ClassGenerator { get; set; }

		private static WrapperGenerator WrapperGenerator { get; set; }

		/// <summary>
		///   Initializes the <see cref = "ObjectiveCRuntime" /> class.
		/// </summary>
		[SuppressMessage("Microsoft.Performance", "CA1810:InitializeReferenceTypeStaticFieldsInline")]
		static ObjectiveCRuntime ()
		{
			// Cache the value to avoid superflous calls to runtime
			NativeMethods.InstallBridge ();
			Is64Bits = Is64BitsInternal();
		}

		///<summary>
		///  <para>Initializes the .NET/Objective-C bridge with no class handler callback.</para>
		///  <para>This method must be called AFTER the loading of the native framework (see <see cref = "LoadFramework" />) and
		///    BEFORE any use of the Objective-C classes.</para>
		///</summary>
		///<example>
		///  <para>The following code shows how to use the <see cref = "Initialize()" /> method:</para>
		///  <code>
		///    using System;
		///    using Monobjc;
		///
		///    namespace MyApplication
		///    {
		///    internal class Program
		///    {
		///    public static int Main(String[] args)
		///    {
		///    ...
		/// 
		///    ObjectiveCRuntime.LoadFramework("Cocoa");
		///    ObjectiveCRuntime.Initialize();
		/// 
		///    ...
		///    }
		///    }
		///    }
		///  </code>
		///</example>
		public static void Initialize ()
		{
			// Allow multiple calls without issue
			if (initialized) {
				return;
			}
			initialized = true;

			Logger.Info ("ObjectiveCRuntime", "Bootstrapping the bridge");

			// Create the domain-data
			Bootstrap ();

			Logger.Info ("ObjectiveCRuntime", "Platform detected:");
			Logger.Info ("ObjectiveCRuntime", "    System      : " + MacOSVersion);
			Logger.Info ("ObjectiveCRuntime", "    Processor   : " + Processor);
			Logger.Info ("ObjectiveCRuntime", "    Is64Bits    : " + Is64Bits);
			Logger.Info ("ObjectiveCRuntime", "    IsBigEndian : " + IsBigEndian);

			// This dynamic assembly will hold all the emitted IL code
			DynamicAssembly = new DynamicAssembly ("Monobjc.Dynamic", "GeneratedTypes");

			// Create the dynamic code generators
			BlockGenerator = new BlockGenerator (DynamicAssembly, Is64Bits);
			CategoryGenerator = new CategoryGenerator (DynamicAssembly, Is64Bits);
			ClassGenerator = new ClassGenerator (DynamicAssembly, Is64Bits);
			WrapperGenerator = new WrapperGenerator (DynamicAssembly, Is64Bits);

			// Save key system assemblies so we can ignore them specifically.
			// Not doing so causes a recursive load loop on some Mono versions.
			mscorlibAssembly = typeof(object).Assembly;
			systemAssembly = typeof(Uri).Assembly;

			// Be sure that every loaded assembly gets scanned
			AppDomain.CurrentDomain.AssemblyLoad += CurrentDomain_AssemblyLoad;

			// Be sure that the domain gets properly unloaded
			AppDomain.CurrentDomain.DomainUnload += CurrentDomain_DomainUnload;

			// Scan all the assemblies to search for class and category to register.
			// If they are not registered within the Objective-C Runtime, then define them.
			foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies()) {
				ScanAssembly (assembly);
			}
		}

		/// <summary>
		///   Adds a specific assembly name to the already scanned assemblies list, preventing the runtime from scanning it for exported types when loaded.
		/// </summary>
		/// <param name = "assemblyName">
		///   The name of the assembly (i.e. 'System.Remoting' is enough, no need for signing details). 
		/// </param>
		public static void DoNotScanAssembly (String assemblyName)
		{
			SCANNED_ASSEMBLIES.Add (assemblyName);
		}

		/// <summary>
		///   Scans the given assembly for new managed proxies.
		/// </summary>
		[SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
		private static void ScanAssembly (Assembly assembly)
		{
			String name = assembly.GetName ().Name;

			// Skip the assembly scan if :
			// - it is in the exclusion list
			// - it has already been scanned
			if (SCANNED_ASSEMBLIES.Contains (name)) {
				return;
			}

			if (Logger.InfoEnabled) {
				Logger.Info ("ObjectiveCRuntime", "Processing assembly '" + name + "'");
			}

			try {
				List<Type> classes = new List<Type> ();
				List<Type> categories = new List<Type> ();

				// 1. Scan all exported types to extract potential candidates for:
				//    - Class definitions
				//    - Category definitions
				foreach (Type type in assembly.GetExportedTypes()) {
					// Test for the ObjectiveCClass attribute
					ObjectiveCClassAttribute classAttribute = Attribute.GetCustomAttribute (type, typeof(ObjectiveCClassAttribute), false) as ObjectiveCClassAttribute;
					if (classAttribute != null) {
						classes.Add (type);
						continue;
					}

					// Test for the ObjectiveCCategory attribute
					ObjectiveCCategoryAttribute categoryAttribute = Attribute.GetCustomAttribute (type, typeof(ObjectiveCCategoryAttribute), false) as ObjectiveCCategoryAttribute;
					if (categoryAttribute != null) {
						categories.Add (type);
						continue;
					}
				}

				// 2. For each class definition found, perform a registration
				foreach (Type type in classes) {
					// Type must be an Id subclass
					if (!typeof(Id).IsAssignableFrom (type)) {
						continue;
					}

					if (Logger.DebugEnabled) {
						Logger.Debug ("ObjectiveCRuntime", "Registering Class '" + type + "'");
					}

					// Test for constructors: a managed wrapper must have a default constructor
					// and a constructor that takes an IntPtr parameter.
					ConstructorInfo constructor = type.GetConstructor (Type.EmptyTypes);
					if (constructor == null) {
						throw new ObjectiveCException (String.Format (CultureInfo.CurrentCulture, Resources.ExposedTypeMustHaveADefaultConstructor, type.FullName));
					}
					constructor = type.GetConstructor (new[] {typeof(IntPtr)});
					if (constructor == null) {
						throw new ObjectiveCException (String.Format (CultureInfo.CurrentCulture, Resources.ExposedTypeMustHaveAConstructorWithIntPtrParameter, type.FullName));
					}

					// Register the type hierarchy
					Stack<Type> hierarchy = new Stack<Type> ();

					// Go bottom-up in the hierarchy until a registered type is found
					Type currentType = type;
					while (!Class.IsMapped(currentType)) {
						hierarchy.Push (currentType);
						currentType = currentType.BaseType;
						if (currentType == typeof(Id)) {
							break;
						}
					}

					if (hierarchy.Count > 0) {
						// Go top-down in the hierarchy and register every type
						while (hierarchy.Count > 0) {
							currentType = hierarchy.Pop ();
							Bridge.DefineClass (ClassGenerator, currentType);
						}
					}
				}

				// 3. For each category definition, perform a registration
				foreach (Type type in categories) {
					if (Logger.DebugEnabled) {
						Logger.Debug ("ObjectiveCRuntime", "Registering Category '" + type + "'");
					}

					Bridge.DefineCategory (CategoryGenerator, type);
				}
			} catch (ObjectiveCException) {
				throw;
			} catch (Exception ex) {
				Logger.Warn ("ObjectiveCRuntime", "Failed to parse assembly '" + name + "'");
				Logger.Debug ("ObjectiveCRuntime", "-> Exception was raised " + ex);
			}

			// Store name to avoid future scan
			SCANNED_ASSEMBLIES.Add (name);
		}

		/// <summary>
		///   Dumps the assembly that holds the runtime generated wrappers.
		/// </summary>
		public static void DumpAssembly ()
		{
			DynamicAssembly.Save ();
		}

		/// <summary>
		///   Handles the AssemblyLoad event of the CurrentDomain control.
		/// </summary>
		private static void CurrentDomain_AssemblyLoad (Object sender, AssemblyLoadEventArgs args)
		{
			// Retrieving the assembly name causes a recursive load loop of system
			// assemblies on some Mono versions, so we specifically abort if these
			// are detected.
			if (args.LoadedAssembly == mscorlibAssembly || args.LoadedAssembly == systemAssembly)
				return;

			Logger.Debug ("ObjectiveCRuntime", "Domain has loaded the '" + args.LoadedAssembly.GetName().FullName + "' assembly");
			ScanAssembly (args.LoadedAssembly);
		}

		/// <summary>
		///   Handles the DomainUnload event of the CurrentDomain control.
		/// </summary>
		/// <param name = "sender">The source of the event.</param>
		/// <param name = "e">The <see cref = "System.EventArgs" /> instance containing the event data.</param>
		private static void CurrentDomain_DomainUnload (object sender, EventArgs e)
		{
			Logger.Info ("ObjectiveCRuntime", "Cleaning up the bridge");
			AppDomain.CurrentDomain.DomainUnload -= CurrentDomain_DomainUnload;

			// If requested, dump the dynamic assembly
			String dump = Environment.GetEnvironmentVariable ("MONOBJC_DUMP_ASSEMBLY");
			if (String.Equals (dump, "YES", StringComparison.OrdinalIgnoreCase) ||
				String.Equals (dump, "TRUE", StringComparison.OrdinalIgnoreCase)) {
				Logger.Debug ("ObjectiveCRuntime", "Dumping dynamic assembly");
				DynamicAssembly.Save ();
			}

			CleanUp ();
		}

		/// <summary>
		///   Gets the Mac OS version.
		/// </summary>
		/// <value>The mac OS version.</value>
		public static MacOSVersion MacOSVersion {
			[MethodImpl(MethodImplOptions.NoInlining)]
            get { return Platform.GetOSVersion (); }
		}

		/// <summary>
		///   Gets the processor description.
		/// </summary>
		/// <value>The processor.</value>
		public static String Processor {
			[MethodImpl(MethodImplOptions.NoInlining)]
            get { return Platform.GetProcessor (); }
		}

		/// <summary>
		///   Gets a value indicating whether the platform is 32 or 64 bits.
		/// </summary>
		/// <value><c>true</c> if the platform is 64 bits; otherwise, <c>false</c>.</value>
		public static bool Is64Bits { get; private set; }

		/// <summary>
		///   Gets a value indicating whether the platform uses big-endianness.
		/// </summary>
		/// <value>
		///   <c>true</c> if the platform uses big-endianness; otherwise, <c>false</c>.
		/// </value>
		public static bool IsBigEndian {
			[MethodImpl(MethodImplOptions.NoInlining)]
            get { return Platform.IsBigEndian (); }
		}

		/// <summary>
		///   Loads a Mac OS framework bundle by searching for the common places.
		/// </summary>
		/// <param name = "name">The name of the framework to load.</param>
		/// <exception cref = "ObjectiveCException">If the framework cannot be found</exception>
		public static void LoadFramework (String name)
		{
			IntPtr handle = NativeMethods.LoadFramework (name);
			if (handle == IntPtr.Zero) {
				throw new ObjectiveCException (String.Format (CultureInfo.CurrentCulture, "Failed to load framework {0}", name));
			}
		}

		/// <summary>
		///   Returns the native selector from the name.
		/// </summary>
		/// <param name = "name">The selector name.</param>
		/// <returns>A pointer to a selector</returns>
		public static IntPtr Selector (String name)
		{
			return NativeMethods.sel_registerName (name);
		}

		/// <summary>
		///   Returns the name of the native selector.
		/// </summary>
		/// <param name = "value">The selector.</param>
		/// <returns>The name of the selector</returns>
		public static String Selector (IntPtr value)
		{
			return Marshal.PtrToStringAnsi (NativeMethods.sel_getName (value));
		}

		/// <summary>
		///   Returns the name of the native protocol.
		/// </summary>
		/// <param name = "value">The bative protocol.</param>
		/// <returns>The name of the protocol</returns>
		public static String GetProtocolName (IntPtr value)
		{
			return Marshal.PtrToStringAnsi (NativeMethods.protocol_getName (value));
		}

		/// <summary>
		///   Gets the symbol.
		/// </summary>
		/// <typeparam name = "T"></typeparam>
		/// <param name = "framework">The framework.</param>
		/// <param name = "symbol">The symbol.</param>
		/// <returns></returns>
		public static T GetExtern<T> (String framework, String symbol)
		{
			IntPtr pointer = NativeMethods.GetFrameworkSymbol (framework, symbol);
			if (pointer == IntPtr.Zero) {
				return default(T);
			}
			Type type = typeof(T);
			if (typeof(Id).IsAssignableFrom (type)) {
				// Read the address of the object
				IntPtr value = Marshal.ReadIntPtr (pointer);
				return (T)GetInstanceInternal (type.TypeHandle.Value, value, RetrievalMode.Override);
			}
			if (type == typeof(int)) {
				// Read the value
				int value = Marshal.ReadInt32 (pointer);
				return (T)(Object)value;
			}
			if (type == typeof(uint)) {
				// Read the value
				uint value = (uint)Marshal.ReadInt32 (pointer);
				return (T)(Object)value;
			}
			if (type == typeof(float)) {
				// Perform a direct marhalling
				return (T)Marshal.PtrToStructure (pointer, typeof(float));
			}
			if (type == typeof(double)) {
				// Perform a direct marhalling
				return (T)Marshal.PtrToStructure (pointer, typeof(double));
			}
			if (type.IsValueType) {
				// Perform an indirect marhalling
				return (T)Marshal.PtrToStructure (pointer, type);
			}
			throw new NotSupportedException (String.Format (CultureInfo.CurrentCulture, "Externals for type {0} are not supported", type));
		}

		/// <summary>
		///   Initializes the assemblies to skip.
		/// </summary>
		/// <returns></returns>
		private static IList<String> InitializeAssembliesToSkip ()
		{
			IList<String> list = new List<String> (128)
                                     {
                                         // Our own assemblies
                                         "Monobjc",
                                         "Monobjc.Dynamic",
                                         // .NET assemblies
                                         "mscorlib",
                                         "System",
                                         "System.ComponentModel.DataAnnotations",
                                         "System.Configuration",
                                         "System.Configuration.Install",
                                         "System.Core",
                                         "System.Data",
                                         "System.Data.DataSetExtensions",
                                         "System.Data.Linq",
                                         "System.Data.OracleClient",
                                         "System.Data.Services",
                                         "System.Design",
                                         "System.DirectoryServices",
                                         "System.Drawing",
                                         "System.Drawing.Design",
                                         "System.EnterpriseServices",
                                         "System.IdentityModel",
                                         "System.IdentityModel.Selectors",
                                         "System.Management",
                                         "System.Messaging",
                                         "System.Runtime.Remoting",
                                         "System.Runtime.Serialization",
                                         "System.Runtime.Serialization.Formatters.Soap",
                                         "System.Security",
                                         "System.ServiceModel",
                                         "System.ServiceModel.Web",
                                         "System.ServiceProcess",
                                         "System.Transactions",
                                         "System.Web",
                                         "System.Web.Abstractions",
                                         "System.Web.DynamicData",
                                         "System.Web.Extensions",
                                         "System.Web.Extensions.Design",
                                         "System.Web.Mvc",
                                         "System.Web.Routing",
                                         "System.Web.Services",
                                         "System.Windows.Forms",
                                         "System.Xml",
                                         "System.Xml.Linq",
                                         // Mono assemblies
                                         "Mono.Addins",
                                         "Mono.Addins.CecilReflector",
                                         "Mono.Addins.Gui",
                                         "Mono.Addins.Setup",
                                         "Mono.C5",
                                         "Mono.CSharp",
                                         "Mono.Cairo",
                                         "Mono.Cecil",
                                         "Mono.Cecil.Mdb",
                                         "Mono.CompilerServices.SymbolWriter",
                                         "Mono.Data",
                                         "Mono.Data.Sqlite",
                                         "Mono.Data.SqliteClient",
                                         "Mono.Data.SybaseClient",
                                         "Mono.Data.Tds",
                                         "Mono.Data.TdsClient",
                                         "Mono.Debugger.Soft",
                                         "Mono.GetOptions",
                                         "Mono.Http",
                                         "Mono.Management",
                                         "Mono.Messaging",
                                         "Mono.Messaging.RabbitMQ",
                                         "Mono.Posix",
                                         "Mono.Security",
                                         "Mono.Security.Win32",
                                         "Mono.Simd",
                                         "Mono.Tasklets",
                                         "Mono.Web",
                                         "Mono.WebBrowser",
                                         "Mono.WebServer",
                                         "Mono.WebServer2",
                                         // Microsoft assemblies
                                         "Microsoft.Build.Engine",
                                         "Microsoft.Build.Framework",
                                         "Microsoft.Build.Tasks",
                                         "Microsoft.Build.Utilities",
                                         "Microsoft.JScript",
                                         "Microsoft.VisualBasic",
                                         "Microsoft.VisualC",
                                         "Microsoft.Vsa",
                                         // SharpZipLib assembly
                                         "ICSharpCode.SharpZipLib",
                                         // log4net assembly
                                         "log4net",
                                         // NAnt assemblies
                                         "NAnt.Core",
                                         "NAnt.DotNetTasks",
                                         "NAnt.NUnit",
                                         "NAnt.NUnit2Tasks",
                                         // NUnit assemblies
                                         "nunit.core",
                                         "nunit.framework",
                                         "nunit.util"
                                     };
			return list;
		}
	}
}