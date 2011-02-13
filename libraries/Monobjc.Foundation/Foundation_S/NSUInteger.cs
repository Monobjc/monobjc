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
    /// Structure that wraps a floating-point value and is mapped to the NSUInteger native type.
    /// </summary>
    [ObjectiveCUnderlyingType(typeof(uint), Is64Bits = false)]
    [ObjectiveCUnderlyingType(typeof(ulong), Is64Bits = true)]
    public struct NSUInteger
    {
        /// <summary>
        /// <para>Defines a value that indicates that an item requested couldn’t be found or doesn’t exist.</para>
        /// <para>Available in Mac OS X v10.0 and later.</para>
        /// </summary>
        public static readonly NSUInteger NSNotFound = Int32.MaxValue;

        /// <summary>
        /// The wrapped value.
        /// </summary>
        public uint value;

        public NSUInteger(uint value)
        {
            this.value = value;
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="NSUInteger"/> to <see cref="System.UInt32"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator uint(NSUInteger value)
        {
            return value.value;
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="System.UInt32"/> to <see cref="NSUInteger"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator NSUInteger(uint value)
        {
            return new NSUInteger(value);
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="NSUInteger"/> to <see cref="System.UInt64"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator ulong(NSUInteger value)
        {
            return value.value;
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="System.UInt64"/> to <see cref="NSUInteger"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator NSUInteger(ulong value)
        {
            return new NSUInteger(Convert.ToUInt32(value));
        }
		
        /// <summary>
        /// Performs an implicit conversion from <see cref="Monobjc.Foundation.NSInteger"/> to <see cref="Monobjc.Foundation.NSUInteger"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
		public static implicit operator NSUInteger(NSInteger value)
		{
			return new NSUInteger((uint) value.value);
		}
		
        /// <summary>
        /// Performs an explicit conversion from <see cref="Monobjc.Foundation.NSUInteger"/> to <see cref="System.Int32"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator int(NSUInteger value)
        {
            return (int)value.value;
        }

        /// <summary>
        /// Performs an explicit conversion from <see cref="System.Int32"/> to <see cref="Monobjc.Foundation.NSUInteger"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator NSUInteger(int value)
        {
            return new NSUInteger((uint)value);
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