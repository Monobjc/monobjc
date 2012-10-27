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
using System.Globalization;
using System.Runtime.InteropServices;
using Monobjc.ApplicationServices;

namespace Monobjc.Foundation
{
    /// <summary>
    /// <para>Represents a two-dimensional size.</para>
    /// <para>Normally, the values of width and height are non-negative. The functions that create an <see cref="NSSize"/> structure do not prevent you from setting a negative value for these attributes. If the value of width or height is negative, however, the behavior of some methods may be undefined.</para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    [ObjectiveCUnderlyingType(typeof(NSSize), Is64Bits = false)]
    [ObjectiveCUnderlyingType(typeof(NSSize64), Is64Bits = true)]
    public partial struct NSSize : IEquatable<NSSize>
    {
        /// <summary>
        /// The width.
        /// </summary>
        public float width;

        /// <summary>
        /// The height.
        /// </summary>
        public float height;

        /// <summary>
        /// Initializes a new instance of the <see cref="NSSize"/> class.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
		public NSSize(CGFloat width, CGFloat height)
        {
            this.width = width;
            this.height = height;
        }

        /// <summary>
        /// Returns the a string representation of this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"></see> containing a representation of this instance.
        /// </returns>
        public override String ToString()
        {
            return String.Format(CultureInfo.CurrentCulture, "NSSize({0}, {1})", this.width, this.height);
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="nsSize1">The ns size1.</param>
        /// <param name="nsSize2">The ns size2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(NSSize nsSize1, NSSize nsSize2)
        {
            return !nsSize1.Equals(nsSize2);
        }

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="nsSize1">The ns size1.</param>
        /// <param name="nsSize2">The ns size2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(NSSize nsSize1, NSSize nsSize2)
        {
            return nsSize1.Equals(nsSize2);
        }

        /// <summary>
        /// Equalses the specified ns size.
        /// </summary>
        /// <param name="nsSize">Size of the ns.</param>
        /// <returns></returns>
        public bool Equals(NSSize nsSize)
        {
            return (this.width == nsSize.width) && (this.height == nsSize.height);
        }

        /// <summary>
        /// Indicates whether this instance and a specified object are equal.
        /// </summary>
        /// <param name="obj">Another object to compare to.</param>
        /// <returns>
        /// true if obj and this instance are the same type and represent the same value; otherwise, false.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (!(obj is NSSize))
            {
                return false;
            }
            return Equals((NSSize) obj);
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>
        /// A 32-bit signed integer that is the hash code for this instance.
        /// </returns>
        public override int GetHashCode()
        {
            return this.width.GetHashCode() + 29*this.height.GetHashCode();
        }
    }
}