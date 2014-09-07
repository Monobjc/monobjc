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
    /// A structure that contains a two-dimensional vector.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    [ObjectiveCUnderlyingType(typeof(CGVector), Is64Bits = false)]
    [ObjectiveCUnderlyingType(typeof(CGVector64), Is64Bits = true)]
    public partial struct CGVector : IEquatable<CGVector>
    {
        /// <summary>
        /// The x coordinate.
        /// </summary>
        public float x;

        /// <summary>
        /// The y coordinate.
        /// </summary>
        public float y;

        /// <summary>
        /// Initializes a new instance of the <see cref="CGVector"/> class.
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
		public CGVector(CGFloat x, CGFloat y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Returns the a string representation of this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"></see> containing a representation of this instance.
        /// </returns>
        public override String ToString()
        {
            return String.Format(CultureInfo.CurrentCulture, "CGVector({0}, {1})", this.x, this.y);
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="CGVector1">The ns point1.</param>
        /// <param name="CGVector2">The ns point2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(CGVector CGVector1, CGVector CGVector2)
        {
            return !CGVector1.Equals(CGVector2);
        }

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="CGVector1">The ns point1.</param>
        /// <param name="CGVector2">The ns point2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(CGVector CGVector1, CGVector CGVector2)
        {
            return CGVector1.Equals(CGVector2);
        }

        /// <summary>
        /// Equalses the specified ns point.
        /// </summary>
        /// <param name="CGVector">The ns point.</param>
        /// <returns></returns>
        public bool Equals(CGVector CGVector)
        {
            return (this.x == CGVector.x) && (this.y == CGVector.y);
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
            if (!(obj is CGVector))
            {
                return false;
            }
            return Equals((CGVector) obj);
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>
        /// A 32-bit signed integer that is the hash code for this instance.
        /// </returns>
        public override int GetHashCode()
        {
            return this.x.GetHashCode() + 29*this.y.GetHashCode();
        }

        public static readonly Converter<CGVector, CGVector64> CGPOINT_2_CGVector64 = (value => (CGVector64)value);

        public static readonly Converter<CGVector64, CGVector> CGPOINT64_2_CGVector = (value => (CGVector)value);

    }
}