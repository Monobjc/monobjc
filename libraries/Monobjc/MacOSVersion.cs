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
namespace Monobjc
{
    /// <summary>
    ///   Enumeration that holds hexadecimal values for MacOS system version.
    /// </summary>
    public enum MacOSVersion
    {
        /// <summary>
        ///   Default value
        /// </summary>
        MacOSUnrecognized = 0x0000,
        /// <summary>
        ///   Value for MacOS 10.0 (Cheetah)
        /// </summary>
        /// <remarks>
        ///   Here for compatibility reasons.
        /// </remarks>
        MacOS100 = 0x1000,
        /// <summary>
        ///   Value for MacOS 10.1 (Puma)
        /// </summary>
        /// <remarks>
        ///   Here for compatibility reasons.
        /// </remarks>
        MacOS101 = 0x1010,
        /// <summary>
        ///   Value for MacOS 10.2 (Jaguar)
        /// </summary>
        /// <remarks>
        ///   Here for compatibility reasons.
        /// </remarks>
        MacOS102 = 0x1020,
        /// <summary>
        ///   Value for MacOS 10.3 (Panther)
        /// </summary>
        /// <remarks>
        ///   Here for compatibility reasons.
        /// </remarks>
        MacOS103 = 0x1030,
        /// <summary>
        ///   Value for MacOS 10.4 (Tiger)
        /// </summary>
        MacOS104 = 0x1040,
        /// <summary>
        ///   Value for MacOS 10.5 (Leopard)
        /// </summary>
        MacOS105 = 0x1050,
        /// <summary>
        ///   Value for MacOS 10.6 (Snow Leopard)
        /// </summary>
        MacOS106 = 0x1060,
    }
}