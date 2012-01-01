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

namespace Monobjc.Foundation
{
    /// <summary>
    /// Represents a rectangle.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    [ObjectiveCUnderlyingType(typeof(NSRect), Is64Bits = false)]
    [ObjectiveCUnderlyingType(typeof(NSRect64), Is64Bits = true)]
    public partial struct NSRect : IEquatable<NSRect>
    {
        /// <summary>
        /// The origin of the rectangle (its starting x coordinate and y coordinate).
        /// </summary>
        public NSPoint origin;

        /// <summary>
        /// The width and height of the rectangle, as measured from the origin.
        /// </summary>
        public NSSize size;

        /// <summary>
        /// Initializes a new instance of the <see cref="NSRect"/> class.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        public NSRect(float x, float y, float width, float height)
        {
            this.origin.x = x;
            this.origin.y = y;
            this.size.width = width;
            this.size.height = height;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NSRect"/> class.
        /// </summary>
        /// <param name="origin">The origin.</param>
        /// <param name="size">The size.</param>
        public NSRect(NSPoint origin, NSSize size)
        {
            this.origin = origin;
            this.size = size;
        }

        /// <summary>
        /// Returns the a string representation of this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"></see> containing a representation of this instance.
        /// </returns>
        public override String ToString()
        {
            return String.Format(CultureInfo.CurrentCulture, "NSRect({0} - {1})", this.origin, this.size);
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="nsRect1">The ns rect1.</param>
        /// <param name="nsRect2">The ns rect2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(NSRect nsRect1, NSRect nsRect2)
        {
            return !nsRect1.Equals(nsRect2);
        }

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="nsRect1">The ns rect1.</param>
        /// <param name="nsRect2">The ns rect2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(NSRect nsRect1, NSRect nsRect2)
        {
            return nsRect1.Equals(nsRect2);
        }

        /// <summary>
        /// Equalses the specified ns rect.
        /// </summary>
        /// <param name="nsRect">The ns rect.</param>
        /// <returns></returns>
        public bool Equals(NSRect nsRect)
        {
            return Equals(this.origin, nsRect.origin) && Equals(this.size, nsRect.size);
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
            if (!(obj is NSRect))
            {
                return false;
            }
            return Equals((NSRect) obj);
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>
        /// A 32-bit signed integer that is the hash code for this instance.
        /// </returns>
        public override int GetHashCode()
        {
            return this.origin.GetHashCode() + 29*this.size.GetHashCode();
        }
    }
}