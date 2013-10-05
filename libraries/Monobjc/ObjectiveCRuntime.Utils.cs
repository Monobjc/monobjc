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
using System.Runtime.CompilerServices;
using Monobjc.Runtime;

namespace Monobjc
{
	public partial class ObjectiveCRuntime
	{
        private static String domainToken;

		/// <summary>
		///   Bootstraps the bridge.
		/// </summary>
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void Bootstrap (String domainToken)
		{
			BootstrapInternal (domainToken);

            // The domain token passed in may have been NULL but
            // the native side may have auto generated a token.
            // We cache it on the managed side.
            ObjectiveCRuntime.domainToken = GetDomainToken();
		}

		/// <summary>
		///   Cleans up the bridge.
		/// </summary>
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void CleanUp ()
		{
			CleanUpInternal ();
		}

		/// <summary>
		///   Gets the bitness of the processor.
		/// </summary>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static bool Is64BitsInternal ()
		{
			return Platform.Is64Bits ();
		}

        /// <summary>
        ///   Enable auto generation of domain tokens.
        /// </summary>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void EnableAutoDomainTokens ()
        {
            EnableAutoDomainTokensInternal ();
        }

		/// <summary>
		///   Internal call to bootstrap the bridge.
		/// </summary>
		[MethodImpl(MethodImplOptions.InternalCall)]
        private static extern void BootstrapInternal (String domainToken);

		/// <summary>
		///   Internal call to cleanup the bridge.
		/// </summary>
		[MethodImplAttribute(MethodImplOptions.InternalCall)]
		private static extern void CleanUpInternal ();

        /// <summary>
        ///   Internal call to get the domain token.
        /// </summary>
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        private static extern String GetDomainToken ();

        /// <summary>
        ///   Internal call to enable auto domain tokens.
        /// </summary>
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        private static extern void EnableAutoDomainTokensInternal ();

        /// <summary>
        /// Returns a mangled name based on the domain token.
        /// </summary>
        internal static string GetDomainManagledName (String name)
        {
            if (String.IsNullOrEmpty(domainToken)) {
                return name;
            }
            return String.Concat(name, "_", domainToken);
        }
	}
}
