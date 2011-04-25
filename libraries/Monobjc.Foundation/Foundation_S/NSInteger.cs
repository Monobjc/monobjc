//
// This file is part of Monobjc, a .NET/Objective-C bridge
// Copyright (C) 2007-2011 - Laurent Etiemble
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
    /// Structure that wraps an signed integer value and is mapped to the NSInteger native type.
    /// </summary>
    [ObjectiveCUnderlyingType(typeof(int), Is64Bits = false)]
    [ObjectiveCUnderlyingType(typeof(long), Is64Bits = true)]
    public partial struct NSInteger
    {
        /// <summary>
        /// The wrapped value.
        /// </summary>
        public int value;

        public NSInteger(int value)
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