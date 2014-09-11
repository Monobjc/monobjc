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
using System.Globalization;
using System.Runtime.InteropServices;

namespace Monobjc.ApplicationServices
{
    /// <summary>
    /// <para>Represents a two-dimensional size.</para>
    /// <para>Normally, the values of width and height are non-negative. The functions that create an <see cref="CGSize"/> structure do not prevent you from setting a negative value for these attributes. If the value of width or height is negative, however, the behavior of some methods may be undefined.</para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    [ObjectiveCUnderlyingType(typeof(CGSize), Is64Bits = false)]
    [ObjectiveCUnderlyingType(typeof(CGSize64), Is64Bits = true)]
    public partial struct CGSize : IEquatable<CGSize>
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
        /// Initializes a new instance of the <see cref="CGSize"/> class.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
		public CGSize(CGFloat width, CGFloat height)
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
            return String.Format(CultureInfo.CurrentCulture, "CGSize({0}, {1})", this.width, this.height);
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="CGSize1">The ns size1.</param>
        /// <param name="CGSize2">The ns size2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(CGSize CGSize1, CGSize CGSize2)
        {
            return !CGSize1.Equals(CGSize2);
        }

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="CGSize1">The ns size1.</param>
        /// <param name="CGSize2">The ns size2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(CGSize CGSize1, CGSize CGSize2)
        {
            return CGSize1.Equals(CGSize2);
        }

        /// <summary>
        /// Equalses the specified ns size.
        /// </summary>
        /// <param name="CGSize">Size of the ns.</param>
        /// <returns></returns>
        public bool Equals(CGSize CGSize)
        {
            return (this.width == CGSize.width) && (this.height == CGSize.height);
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
            if (!(obj is CGSize))
            {
                return false;
            }
            return Equals((CGSize) obj);
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