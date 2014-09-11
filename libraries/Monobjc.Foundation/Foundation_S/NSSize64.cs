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
using System.Runtime.InteropServices;
using Monobjc.ApplicationServices;

namespace Monobjc.Foundation
{
    /// <summary>
    /// Structure used for marshalling on 64 bits platforms.
    /// Never use this structure directly.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NSSize64
    {
        /// <summary>
        /// The width.
        /// </summary>
        public double width;

        /// <summary>
        /// The height.
        /// </summary>
        public double height;

        /// <summary>
        /// Initializes a new instance of the <see cref="Monobjc.Foundation.NSSize64"/> struct.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
		public NSSize64(CGFloat width, CGFloat height)
        {
            this.width = width;
            this.height = height;
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="Monobjc.Foundation.NSSize64"/> to <see cref="Monobjc.Foundation.NSSize"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator NSSize(NSSize64 value)
        {
            return new NSSize(value.width, value.height);
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="Monobjc.Foundation.NSSize"/> to <see cref="Monobjc.Foundation.NSSize64"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator NSSize64(NSSize value)
        {
            return new NSSize64(value.width, value.height);
        }
    }
}