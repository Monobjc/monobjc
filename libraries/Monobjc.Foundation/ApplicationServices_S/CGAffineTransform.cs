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
using System.Runtime.InteropServices;

namespace Monobjc.ApplicationServices
{
    /// <summary>
    /// <para>A structure for holding an affine transformation matrix.</para>
    /// <para>Available in Mac OS X v10.0 and later.</para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public partial struct CGAffineTransform : IEquatable<CGAffineTransform>
    {
        /// <summary>
        /// The entry at position [1,1] in the matrix.
        /// </summary>
        public float a;

        /// <summary>
        /// The entry at position [1,2] in the matrix.
        /// </summary>
        public float b;

        /// <summary>
        /// The entry at position [2,1] in the matrix.
        /// </summary>
        public float c;

        /// <summary>
        /// The entry at position [2,2] in the matrix.
        /// </summary>
        public float d;

        /// <summary>
        /// The entry at position [3,1] in the matrix.
        /// </summary>
        public float tx;

        /// <summary>
        /// The entry at position [3,2] in the matrix.
        /// </summary>
        public float ty;

        /// <summary>
        /// Initializes a new instance of the <see cref="CGAffineTransform"/> struct.
        /// </summary>
        /// <param name="a">A.</param>
        /// <param name="b">The b.</param>
        /// <param name="c">The c.</param>
        /// <param name="d">The d.</param>
        /// <param name="tx">The tx.</param>
        /// <param name="ty">The ty.</param>
		public CGAffineTransform(CGFloat a, CGFloat b, CGFloat c, CGFloat d, CGFloat tx, CGFloat ty)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;
            this.tx = tx;
            this.ty = ty;
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="cgAffineTransform1">The cg affine transform1.</param>
        /// <param name="cgAffineTransform2">The cg affine transform2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(CGAffineTransform cgAffineTransform1, CGAffineTransform cgAffineTransform2)
        {
            return !cgAffineTransform1.Equals(cgAffineTransform2);
        }

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="cgAffineTransform1">The cg affine transform1.</param>
        /// <param name="cgAffineTransform2">The cg affine transform2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(CGAffineTransform cgAffineTransform1, CGAffineTransform cgAffineTransform2)
        {
            return cgAffineTransform1.Equals(cgAffineTransform2);
        }

        /// <summary>
        /// Equalses the specified cg affine transform.
        /// </summary>
        /// <param name="cgAffineTransform">The cg affine transform.</param>
        /// <returns></returns>
        public bool Equals(CGAffineTransform cgAffineTransform)
        {
            if (this.a != cgAffineTransform.a)
            {
                return false;
            }
            if (this.b != cgAffineTransform.b)
            {
                return false;
            }
            if (this.c != cgAffineTransform.c)
            {
                return false;
            }
            if (this.d != cgAffineTransform.d)
            {
                return false;
            }
            if (this.tx != cgAffineTransform.tx)
            {
                return false;
            }
            if (this.ty != cgAffineTransform.ty)
            {
                return false;
            }
            return true;
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
            if (!(obj is CGAffineTransform))
            {
                return false;
            }
            return Equals((CGAffineTransform) obj);
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>
        /// A 32-bit signed integer that is the hash code for this instance.
        /// </returns>
        public override int GetHashCode()
        {
            int result = this.a.GetHashCode();
            result = 29*result + this.b.GetHashCode();
            result = 29*result + this.c.GetHashCode();
            result = 29*result + this.d.GetHashCode();
            result = 29*result + this.tx.GetHashCode();
            result = 29*result + this.ty.GetHashCode();
            return result;
        }
    }
}