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
using System.CodeDom.Compiler;
using System.Globalization;
using System.Runtime.InteropServices;

using Monobjc;

namespace Monobjc.Foundation
{
    /// <summary>
	/// <para>Identifiers used by NSDivideRect to specify the edge of the input rectangle from which the division is measured.</para>
    /// <para>Available in Mac OS X v10.0 and later.</para>
    /// </summary>
    [ObjectiveCUnderlyingTypeAttribute(typeof(uint), Is64Bits = false)]
    [ObjectiveCUnderlyingTypeAttribute(typeof(ulong), Is64Bits = true)]
    public enum NSRectEdge : uint
    {
        /// <summary>
		/// <para>Specifies the left edge of the input rectangle. The input rectangle is divided vertically, and the leftmost rectangle with the width of amount is placed in slice.</para>
        /// <para>Available in Mac OS X v10.0 and later.</para>
        /// </summary>
		NSMinXEdge = 0,
        /// <summary>
		/// <para>Specifies the bottom edge of the input rectangle. The input rectangle is divided horizontally, and the bottom rectangle with the height of amount is placed in slice.</para>
        /// <para>Available in Mac OS X v10.0 and later.</para>
        /// </summary>
		NSMinYEdge = 1,
        /// <summary>
		/// <para>Specifies the right edge of the input rectangle. The input rectangle is divided vertically, and the rightmost rectangle with the width of amount is placed in slice.</para>
        /// <para>Available in Mac OS X v10.0 and later.</para>
        /// </summary>
		NSMaxXEdge = 2,
        /// <summary>
		/// <para>Specifies the top edge of the input rectangle. The input rectangle is divided horizontally, and the top rectangle with the height of amount is placed in slice.</para>
        /// <para>Available in Mac OS X v10.0 and later.</para>
        /// </summary>
		NSMaxYEdge = 3,
    }
}
