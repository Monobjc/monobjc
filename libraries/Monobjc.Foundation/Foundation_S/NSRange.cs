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
    /// A structure used to describe a portion of a series�such as characters in a string or objects in an NSArray object.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    [ObjectiveCUnderlyingType(typeof(NSRange), Is64Bits = false)]
    [ObjectiveCUnderlyingType(typeof(NSRange64), Is64Bits = true)]
    public partial struct NSRange : IEquatable<NSRange>
    {
        /// <summary>
        /// The start index (0 is the first, as in C arrays).
        /// </summary>
        public uint location;

        /// <summary>
        /// The number of items in the range (can be 0).
        /// </summary>
        public uint length;

        /// <summary>
        /// Initializes a new instance of the <see cref="NSRange"/> class.
        /// </summary>
        /// <param name="location">The location.</param>
        /// <param name="length">The length.</param>
		public NSRange(NSUInteger location, NSUInteger length)
        {
            this.location = location;
            this.length = length;
        }

        /// <summary>
        /// Returns the a string representation of this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"></see> containing a representation of this instance.
        /// </returns>
        public override String ToString()
        {
            return String.Format(CultureInfo.CurrentCulture, "NSRange({0}, {1})", this.location, this.length);
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="nsRange1">The ns range1.</param>
        /// <param name="nsRange2">The ns range2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(NSRange nsRange1, NSRange nsRange2)
        {
            return !nsRange1.Equals(nsRange2);
        }

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="nsRange1">The ns range1.</param>
        /// <param name="nsRange2">The ns range2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(NSRange nsRange1, NSRange nsRange2)
        {
            return nsRange1.Equals(nsRange2);
        }

        /// <summary>
        /// Equalses the specified ns range.
        /// </summary>
        /// <param name="nsRange">The ns range.</param>
        /// <returns></returns>
        public bool Equals(NSRange nsRange)
        {
            return (this.location == nsRange.location) && (this.length == nsRange.length);
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
            if (!(obj is NSRange))
            {
                return false;
            }
            return Equals((NSRange) obj);
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>
        /// A 32-bit signed integer that is the hash code for this instance.
        /// </returns>
        public override int GetHashCode()
        {
            return (int) this.location + 29*(int) this.length;
        }
    }
}