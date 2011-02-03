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
using System.Globalization;
using System.Runtime.InteropServices;

namespace Monobjc.Foundation
{
    /// <summary>
    /// Represents a point in a Cartesian coordinate system.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    [ObjectiveCUnderlyingType(typeof(NSPoint), Is64Bits = false)]
    [ObjectiveCUnderlyingType(typeof(NSPoint64), Is64Bits = true)]
    public partial struct NSPoint : IEquatable<NSPoint>
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
        /// Initializes a new instance of the <see cref="NSPoint"/> class.
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        public NSPoint(float x, float y)
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
            return String.Format(CultureInfo.CurrentCulture, "NSPoint({0}, {1})", this.x, this.y);
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="nsPoint1">The ns point1.</param>
        /// <param name="nsPoint2">The ns point2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(NSPoint nsPoint1, NSPoint nsPoint2)
        {
            return !nsPoint1.Equals(nsPoint2);
        }

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="nsPoint1">The ns point1.</param>
        /// <param name="nsPoint2">The ns point2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(NSPoint nsPoint1, NSPoint nsPoint2)
        {
            return nsPoint1.Equals(nsPoint2);
        }

        /// <summary>
        /// Equalses the specified ns point.
        /// </summary>
        /// <param name="nsPoint">The ns point.</param>
        /// <returns></returns>
        public bool Equals(NSPoint nsPoint)
        {
            return (this.x == nsPoint.x) && (this.y == nsPoint.y);
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
            if (!(obj is NSPoint))
            {
                return false;
            }
            return Equals((NSPoint) obj);
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
    }
}