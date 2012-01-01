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

namespace Monobjc.AppKit
{
    /// <summary>

    /// <para>Edge insets describe the distance between the edges of one rectangle to a related rectangle that can be described by measuring a constant but edge-specific distance from each edge.</para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    [ObjectiveCUnderlyingType(typeof(NSEdgeInsets), Is64Bits = false)]
    [ObjectiveCUnderlyingType(typeof(NSEdgeInsets64), Is64Bits = true)]
    public partial struct NSEdgeInsets : IEquatable<NSEdgeInsets>

    {

        /// <summary>

        /// <para>The distance from the top of the source rectangle to the top of the result rectangle.</para>

        /// </summary>

        public float top;

        /// <summary>

        /// <para>The distance from the left side of the source rectangle to the left side of the result rectangle.</para>

        /// </summary>

        public float left;

        /// <summary>

        /// <para>The distance from the bottom of the source rectangle to the bottom of the result rectangle.</para>

        /// </summary>

        public float bottom;

        /// <summary>

        /// <para>The distance from the right side of the source rectangle to the right side of the result rectangle.</para>

        /// </summary>

        public float right;



        /// <summary>

        /// Initializes a new instance of the <see cref="NSEdgeInsets"/> struct.

        /// </summary>

        /// <param name="top">The top.</param>

        /// <param name="left">The left.</param>

        /// <param name="bottom">The bottom.</param>

        /// <param name="right">The right.</param>

        public NSEdgeInsets(float top, float left, float bottom, float right)

        {

            this.top = top;

            this.left = left;

            this.bottom = bottom;

            this.right = right;

        }



        /// <summary>

        /// Returns the a string representation of this instance.

        /// </summary>

        /// <returns>

        /// A <see cref="T:System.String"></see> containing a representation of this instance.

        /// </returns>

        public override String ToString()

        {

            return String.Format(CultureInfo.CurrentCulture, "NSEdgeInsets(top={0} left{1} bottom{2} right{3})", this.top, this.left, this.bottom, this.right);

        }



        /// <summary>

        /// Indicates whether the current object is equal to another object of the same type.

        /// </summary>

        /// <returns>

        /// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.

        /// </returns>

        /// <param name="other">An object to compare with this object.

        ///                 </param>

        public bool Equals(NSEdgeInsets other)

        {

            return other.top.Equals(this.top) && other.left.Equals(this.left) && other.bottom.Equals(this.bottom) && other.right.Equals(this.right);

        }



        /// <summary>

        /// Indicates whether this instance and a specified object are equal.

        /// </summary>

        /// <returns>

        /// true if <paramref name="obj"/> and this instance are the same type and represent the same value; otherwise, false.

        /// </returns>

        /// <param name="obj">Another object to compare to. 

        ///                 </param><filterpriority>2</filterpriority>

        public override bool Equals(object obj)

        {

            if (ReferenceEquals(null, obj))

            {

                return false;

            }

            if (obj.GetType() != typeof (NSEdgeInsets))

            {

                return false;

            }

            return Equals((NSEdgeInsets) obj);

        }



        /// <summary>

        /// Returns the hash code for this instance.

        /// </summary>

        /// <returns>

        /// A 32-bit signed integer that is the hash code for this instance.

        /// </returns>

        /// <filterpriority>2</filterpriority>

        public override int GetHashCode()

        {

            unchecked

            {

                int result = this.top.GetHashCode();

                result = (result*397) ^ this.left.GetHashCode();

                result = (result*397) ^ this.bottom.GetHashCode();

                result = (result*397) ^ this.right.GetHashCode();

                return result;

            }

        }



        public static bool operator ==(NSEdgeInsets left, NSEdgeInsets right)

        {

            return left.Equals(right);

        }



        public static bool operator !=(NSEdgeInsets left, NSEdgeInsets right)

        {

            return !left.Equals(right);

        }

    }
}