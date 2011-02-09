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
using System.Runtime.InteropServices;

namespace Monobjc.Foundation
{
    /// <summary>
    /// Structure used for marshalling on 64 bits platforms.
    /// Never use this structure directly.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NSRange64
    {
        /// <summary>
        /// The start index (0 is the first, as in C arrays).
        /// </summary>
        public ulong location;

        /// <summary>
        /// The number of items in the range (can be 0).
        /// </summary>
        public ulong length;

        /// <summary>
        /// Initializes a new instance of the <see cref="Monobjc.Foundation.NSRange64"/> struct.
        /// </summary>
        /// <param name="location">The location.</param>
        /// <param name="length">The length.</param>
        public NSRange64(ulong location, ulong length)
        {
            this.location = location;
            this.length = length;
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="Monobjc.Foundation.NSRange64"/> to <see cref="Monobjc.Foundation.NSRange"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator NSRange(NSRange64 value)
        {
            return new NSRange((uint)value.location, (uint)value.length);
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="Monobjc.Foundation.NSRange"/> to <see cref="Monobjc.Foundation.NSRange64"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator NSRange64(NSRange value)
        {
            return new NSRange64(value.location, value.length);
        }
    }
}