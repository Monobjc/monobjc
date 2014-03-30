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

namespace Monobjc.Foundation
{
    /// <summary>
    /// Structure that wraps a unsigned integer value and is mapped to the NSUInteger native type.
    /// </summary>
    [ObjectiveCUnderlyingType(typeof(uint), Is64Bits = false)]
    [ObjectiveCUnderlyingType(typeof(ulong), Is64Bits = true)]
    public partial struct NSUInteger
    {
		/// <summary>
		/// <para>The maximum value for an NSUInteger.</para>
		/// <para>Available in Mac OS X v10.5 and later.</para>
		/// </summary>
		public static readonly NSUInteger NSUIntegerMax = UInt32.MaxValue;
		
		/// <summary>
        /// <para>Defines a value that indicates that an item requested couldn't be found or doesn't exist.</para>
        /// <para>Available in Mac OS X v10.0 and later.</para>
        /// </summary>
        public static readonly NSUInteger NSNotFound = ObjectiveCRuntime.Is64Bits ? UInt32.MaxValue : Int32.MaxValue;

        /// <summary>
        /// The wrapped value.
        /// </summary>
        public uint value;

        public NSUInteger(uint value)
        {
            this.value = value;
        }
		
        /// <summary>
        /// Returns the a string representation of this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"></see> containing a representation of this instance.
        /// </returns>
		public override string ToString()
		{
			return this.value.ToString();
		}
    }
}