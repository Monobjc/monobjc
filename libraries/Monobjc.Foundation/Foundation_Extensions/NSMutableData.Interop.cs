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

namespace Monobjc.Foundation
{
    public partial class NSMutableData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NSMutableData"/> class.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        public NSMutableData(byte[] bytes)
            : base(bytes) {}

        /// <summary>
        /// Initializes a new instance of the <see cref="NSMutableData"/> class.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <param name="length">The length.</param>
        public NSMutableData(byte[] bytes, NSUInteger length)
            : base(bytes, length) {}

        /// <summary>
        /// <para>Appends to the receiver a given number of bytes from a given buffer.</para>
        /// <para>Original signature is '- (void)appendBytes:(const void *)bytes length:(NSUInteger )length'</para>
        /// <para>Available in Mac OS X v10.0 and later.</para>
        /// </summary>
        /// <param name="bytes">A buffer containing data to append to the receiver's content.</param>
        /// <param name="length">The number of bytes from bytes to append.</param>
        /// <returns>An initialized NSMutableData object capable of holding capacity bytes.</returns>
        public void AppendBytesLength(byte[] bytes, NSUInteger length)
        {
            IntPtr pointer = Marshal.AllocHGlobal((int) length);
            Marshal.Copy(bytes, 0, pointer, (int) length);
            this.AppendBytesLength(pointer, length);
            Marshal.FreeHGlobal(pointer);
        }

        /// <summary>
        /// Implements the operator +.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="otherData">The other data.</param>
        /// <returns>The result of the operator.</returns>
        public static NSMutableData operator +(NSMutableData data, NSData otherData)
        {
            data.AppendData(otherData);
            return data;
        }

        /// <summary>
        /// Implements the operator +.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="bytes">The bytes.</param>
        /// <returns>The result of the operator.</returns>
        public static NSMutableData operator +(NSMutableData data, byte[] bytes)
        {
            data.AppendBytesLength(bytes, (uint) bytes.Length);
            return data;
        }
    }
}