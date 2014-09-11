//
// This file is part of Monobjc, a .NET/Objective-C bridge
// Copyright (C) 2007-2014 - Laurent Etiemble
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
using System.Runtime.InteropServices;

namespace Monobjc
{
	/// <summary>
	///   <para>Exports native methods exposed in <c>libobjc.dylib</c> shared library.</para>
	///   <para>Thanks to .NET P/Invoke system, most of the marshalling work is automatic.</para>
	///   <para>The following methods are safe for use on both Mac OS X 10.4 and later.</para>
	/// </summary>
	internal static class NativeMethods
	{
		/// <summary>
		///   Installs the internal calls for the bridge.
		/// </summary>
		[DllImport("__Internal", EntryPoint = "monobjc_install_bridge")]
		public static extern void InstallBridge ();

		/// <summary>
		///   Installs the internal calls for the bridge.
		/// </summary>
		[DllImport("__Internal", EntryPoint = "monobjc_load_framework")]
		public static extern IntPtr LoadFramework (String framework);

		/// <summary>
		///   Gets the symbol located in the framework.
		/// </summary>
		/// <param name = "framework">Name of the framework.</param>
		/// <param name = "symbol">The symbol.</param>
		/// <returns>A pointer to the symbol or <c>null</c> if the symbol is not found.</returns>
		[DllImport("__Internal", EntryPoint = "monobjc_get_symbol")]
		public static extern IntPtr GetFrameworkSymbol (String framework, String symbol);

		/// <summary>
		///   <para>Returns the name of the method specified by the selector.</para>
		///   <para>This function is one of two ways to retrieve the name of a selector. You can also cast a selector pointer directly to a C string pointer (const char *), but you cannot use an arbitrary C string as a selector because selectors are C strings that are indexed by pointer. See SEL for more information.</para>
		///   <para>The original declaration is :
		///     <code>
		///       const char* sel_getName(SEL aSelector)
		///     </code>
		///   </para>
		/// </summary>
		/// <param name = "aSelector">A pointer of type SEL. Pass the selector whose name you wish to determine.</param>
		/// <returns>A C string indicating the name of the selector.</returns>
		/// <remarks>
		///   For more details, see the Objective-C Runtime Reference (http://developer.apple.com/DOCUMENTATION/Cocoa/Reference/ObjectiveCRuntimeRef/index.html).
		/// </remarks>
		[DllImport("libobjc", CharSet = CharSet.Ansi)]
		public static extern IntPtr sel_getName (IntPtr aSelector);

		/// <summary>
		///   <para>Registers a method with the Objective-C runtime system, maps the method name to a selector, and returns the selector value.</para>
		///   <para>You must register a method name with the Objective-C runtime system to obtain the methodís selector before you can add the method to a class definition. If the method name has already been registered, this function simply returns the selector.</para>
		///   <para>The original declaration is :
		///     <code>
		///       SEL sel_registerName(const char *str);
		///     </code>
		///   </para>
		/// </summary>
		/// <param name = "str">A pointer to a C string. Pass the name of the method you wish to register.</param>
		/// <returns>A pointer of type SEL specifying the selector for the named method.</returns>
		/// <remarks>
		///   For more details, see the Objective-C Runtime Reference (http://developer.apple.com/DOCUMENTATION/Cocoa/Reference/ObjectiveCRuntimeRef/index.html).
		/// </remarks>
		[DllImport("libobjc", CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true)]
		public static extern IntPtr sel_registerName ([MarshalAs(UnmanagedType.LPStr)] String str);

        /// <summary>
        ///   <para>Returns a the name of a protocol.</para>
        ///   <para>The original declaration is :
        ///     <code>
        ///       const char *protocol_getName(Protocol *p);
        ///     </code>
        ///   </para>
        /// </summary>
        /// <returns>
        ///   The name.
        /// </returns>
        /// <param name = 'protocol'>A protocol.</param>
        /// <returns>The name of the protocol p as a C string.</returns>
        /// <remarks>
        ///   For more details, see the Objective-C Runtime Reference (http://developer.apple.com/DOCUMENTATION/Cocoa/Reference/ObjectiveCRuntimeRef/index.html).
        /// </remarks>
        [DllImport("libobjc", CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern IntPtr protocol_getName(IntPtr protocol);
	}
}