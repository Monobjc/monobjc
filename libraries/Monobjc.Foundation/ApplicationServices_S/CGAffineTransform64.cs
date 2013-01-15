//
// This file is part of Monobjc, a .NET/Objective-C bridge
// Copyright (C) 2007-2013 - Laurent Etiemble
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
    ///<summary>
    /// Structure used for marshalling on 64 bits platforms.
    /// Never use this structure directly.
    ///</summary>
    [StructLayout(LayoutKind.Sequential)]
    public partial struct CGAffineTransform64
    {
        /// <summary>
        /// The entry at position [1,1] in the matrix.
        /// </summary>
        public double a;

        /// <summary>
        /// The entry at position [1,2] in the matrix.
        /// </summary>
        public double b;

        /// <summary>
        /// The entry at position [2,1] in the matrix.
        /// </summary>
        public double c;

        /// <summary>
        /// The entry at position [2,2] in the matrix.
        /// </summary>
        public double d;

        /// <summary>
        /// The entry at position [3,1] in the matrix.
        /// </summary>
        public double tx;

        /// <summary>
        /// The entry at position [3,2] in the matrix.
        /// </summary>
        public double ty;

        /// <summary>
        /// Initializes a new instance of the <see cref="CGAffineTransform64"/> struct.
        /// </summary>
        /// <param name="a">A.</param>
        /// <param name="b">The b.</param>
        /// <param name="c">The c.</param>
        /// <param name="d">The d.</param>
        /// <param name="tx">The tx.</param>
        /// <param name="ty">The ty.</param>
		public CGAffineTransform64(CGFloat a, CGFloat b, CGFloat c, CGFloat d, CGFloat tx, CGFloat ty)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;
            this.tx = tx;
            this.ty = ty;
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="Monobjc.ApplicationServices.CGAffineTransform64"/> to <see cref="Monobjc.ApplicationServices.CGAffineTransform"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator CGAffineTransform(CGAffineTransform64 value)
        {
            return new CGAffineTransform(value.a, value.b, value.c, value.d, value.tx, value.ty);
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="Monobjc.ApplicationServices.CGAffineTransform"/> to <see cref="Monobjc.ApplicationServices.CGAffineTransform64"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator CGAffineTransform64(CGAffineTransform value)
        {
            return new CGAffineTransform64(value.a, value.b, value.c, value.d, value.tx, value.ty);
        }
    }
}