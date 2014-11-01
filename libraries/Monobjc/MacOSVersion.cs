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
		MacOSUnrecognized = 0,
		/// <summary>
		///   Value for MacOS 10.0 (Cheetah)
		/// </summary>
		MacOS100 = 10 * 256 + 0,
		/// <summary>
		///   Value for MacOS 10.1 (Puma)
		/// </summary>
        MacOS101 = 10 * 256 + 1,
		/// <summary>
		///   Value for MacOS 10.2 (Jaguar)
		/// </summary>
        MacOS102 = 10 * 256 + 2,
		/// <summary>
		///   Value for MacOS 10.3 (Panther)
		/// </summary>
        MacOS103 = 10 * 256 + 3,
		/// <summary>
		///   Value for MacOS 10.4 (Tiger)
		/// </summary>
        MacOS104 = 10 * 256 + 4,
		/// <summary>
		///   Value for MacOS 10.5 (Leopard)
		/// </summary>
        MacOS105 = 10 * 256 + 5,
		/// <summary>
		///   Value for MacOS 10.6 (Snow Leopard)
		/// </summary>
        MacOS106 = 10 * 256 + 6,
		/// <summary>
		///   Value for MacOS 10.7 (Lion)
		/// </summary>
        MacOS107 = 10 * 256 + 7,
        /// <summary>
        ///   Value for MacOS 10.8 (Mountain Lion)
        /// </summary>
        MacOS108 = 10 * 256 + 8,
        /// <summary>
        ///   Value for MacOS 10.9 (Mavericks)
        /// </summary>
        MacOS109 = 10 * 256 + 9,
        /// <summary>
        ///   Value for MacOS 10.9 (Yosemite)
        /// </summary>
        MacOS1010 = 10 * 256 + 10,
	}
}
