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
    /// Used to describe a decimal number.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NSDecimal
    {
        /// <summary>
        /// The exponent.
        /// </summary>
        public int _exponent;

        /// <summary>
        /// The length
        /// </summary>
        public uint _length;

        /// <summary>
        /// Whether this instance is negative
        /// </summary>
        public uint _isNegative;

        /// <summary>
        /// Whether this instance is compact
        /// </summary>
        public uint _isCompact;

        /// <summary>
        /// Reserved for future use.
        /// </summary>
        public uint _reserved;

        /// <summary>
        /// The mantissa
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public ushort[] _mantissa;
    }
}