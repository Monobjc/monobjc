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
using System.Runtime.InteropServices;

namespace Monobjc.ApplicationServices
{
    ///<summary>
    /// Structure used for marshalling on 64 bits platforms.
    /// Never use this structure directly.
    ///</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct CGPoint64
    {
        /// <summary>
        /// The x coordinate.
        /// </summary>
        public double x;

        /// <summary>
        /// The y coordinate.
        /// </summary>
        public double y;

        /// <summary>
        /// Initializes a new instance of the <see cref="Monobjc.ApplicationServices.CGPoint64"/> struct.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
		public CGPoint64(CGFloat x, CGFloat y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="Monobjc.ApplicationServices.CGPoint64"/> to <see cref="Monobjc.ApplicationServices.CGPoint"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator CGPoint(CGPoint64 value)
        {
            return new CGPoint(value.x, value.y);
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="Monobjc.ApplicationServices.CGPoint"/> to <see cref="Monobjc.ApplicationServices.CGPoint64"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator CGPoint64(CGPoint value)
        {
            return new CGPoint64(value.x, value.y);
        }
    }
}