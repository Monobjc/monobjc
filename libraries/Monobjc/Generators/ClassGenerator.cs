//
// This file is part of Monobjc, a .NET/Objective-C bridge
// Copyright (C) 2007-2012 - Laurent Etiemble
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
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;

namespace Monobjc.Generators
{
	/// <summary>
	///   Code generator that produces class proxies.
	/// </summary>
	internal partial class ClassGenerator : CodeGenerator
	{
		private const String NAME_PATTERN = "Monobjc.Dynamic.Classes.{0}";

		/// <summary>
		///   Initializes a new instance of the <see cref = "ClassGenerator" /> class.
		/// </summary>
		/// <param name = "assembly">The assembly.</param>
		/// <param name = "is64Bits"></param>
		public ClassGenerator (DynamicAssembly assembly, bool is64Bits) : base(assembly, is64Bits)
		{
		}

		/// <summary>
		///   TODO: Doc
		/// </summary>
		public Type DefineClassProxy (Type type, IEnumerable<MethodTuple> instanceMethods, IEnumerable<MethodTuple> classMethods)
		{
			if (type == null) {
				throw new ArgumentNullException ("type");
			}

			// Compute the name of the class proxy
			String typeName = String.Format (CultureInfo.CurrentCulture, NAME_PATTERN, type.FullName);
			TypeBuilder typeBuilder = this.Assembly.AddType (typeName, true);

			if (Logger.DebugEnabled) {
				Logger.Debug ("ClassGenerator", "Generating Class Proxy: " + typeName);
			}

			// Create call proxy for instance methods
			foreach (MethodTuple methodTuple in instanceMethods) {
				methodTuple.ProxyDelegate = this.DefineDelegate (typeBuilder, methodTuple.MethodInfo, out methodTuple.ProxyDelegateConstructor);
				methodTuple.ProxyMethodInfo = this.DefineProxyMethod (typeBuilder, methodTuple);
				methodTuple.ProxyDelegateFieldInfo = DefineProxyDelegateFieldInfo (typeBuilder, methodTuple);
			}

			// Create call proxy for class methods
			foreach (MethodTuple methodTuple in classMethods) {
				methodTuple.ProxyDelegate = this.DefineDelegate (typeBuilder, methodTuple.MethodInfo, out methodTuple.ProxyDelegateConstructor);
				methodTuple.ProxyMethodInfo = this.DefineProxyMethod (typeBuilder, methodTuple);
				methodTuple.ProxyDelegateFieldInfo = DefineProxyDelegateFieldInfo (typeBuilder, methodTuple);
			}

			// Create static constructor
			DefineStaticConstructor (typeBuilder, instanceMethods.Concat (classMethods));

			// Finish the creation
			Type proxy = typeBuilder.CreateType ();

			return proxy;
		}
	}
}