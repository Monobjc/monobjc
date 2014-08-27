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

namespace Monobjc.CoreMedia
{
#if MACOSX_10_7

    /// <summary>
    /// <para>Defines a structure that represents a rational time value int64/int32.</para>
    /// <para>Available in Mac OS X v10.7 and later.</para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public partial struct CMTime
    {
        /// <summary>
        /// <para>The value of the CMTime.</para>
        /// <para>Available in Mac OS X v10.7 and later.</para>
        /// </summary>
        public long value;

        /// <summary>
        /// <para>The timescale of the CMTime.</para>
        /// <para>Available in Mac OS X v10.7 and later.</para>
        /// </summary>
        public int timescale;

        /// <summary>
        /// <para>A bitfield representing the flags set for the CMTime.</para>
        /// <para>Available in Mac OS X v10.7 and later.</para>
        /// </summary>
        public CMTimeFlags flags;

        /// <summary>
        /// <para>The epoch of the CMTime.</para>
        /// <para>Available in Mac OS X v10.7 and later.</para>
        /// </summary>
        public long epoch;
    }
#endif
}