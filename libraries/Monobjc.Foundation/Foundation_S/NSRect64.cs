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
using System.Runtime.InteropServices;
using Monobjc.ApplicationServices;

namespace Monobjc.Foundation
{
    /// <summary>
    /// Structure used for marshalling on 64 bits platforms.
    /// Never use this structure directly.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NSRect64
    {
        /// <summary>
        /// The origin of the rectangle (its starting x coordinate and y coordinate).
        /// </summary>
        public NSPoint64 origin;

        /// <summary>
        /// The width and height of the rectangle, as measured from the origin.
        /// </summary>
        public NSSize64 size;

        /// <summary>
        /// Initializes a new instance of the <see cref="Monobjc.Foundation.NSRect64"/> struct.
        /// </summary>
        /// <param name="origin">The origin.</param>
        /// <param name="size">The size.</param>
        public NSRect64(NSPoint64 origin, NSSize64 size)
        {
            this.origin = origin;
            this.size = size;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Monobjc.Foundation.NSRect64"/> struct.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
		public NSRect64(CGFloat x, CGFloat y, CGFloat width, CGFloat height)
        {
            this.origin.x = x;
            this.origin.y = y;
            this.size.width = width;
            this.size.height = height;
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="Monobjc.Foundation.NSRect64"/> to <see cref="Monobjc.Foundation.NSRect"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator NSRect(NSRect64 value)
        {
            return new NSRect(value.origin, value.size);
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="Monobjc.Foundation.NSRect"/> to <see cref="Monobjc.Foundation.NSRect64"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator NSRect64(NSRect value)
        {
            return new NSRect64(value.origin, value.size);
        }
    }
}