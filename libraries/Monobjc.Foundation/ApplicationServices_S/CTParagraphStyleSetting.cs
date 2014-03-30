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

namespace Monobjc.ApplicationServices
{
	/// <summary>
	/// <para>This structure is used to alter the paragraph style.</para>
	/// <para>Available in Mac OS X v10.5 and later.</para>
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public partial struct CTParagraphStyleSetting
	{
		/// <summary>
		/// <para>The specifier of the setting. See 'CTParagraphStyleSpecifier' for possible values.</para>
		/// </summary>
		public CTParagraphStyleSpecifier spec;

		/// <summary>
		/// <para>The size of the value pointed to by the value field. This value must match the size of the value required by the CTParagraphStyleSpecifier set in the spec field.</para>
		/// </summary>
		public IntPtr valueSize;

		/// <summary>
		/// <para>A reference to the value of the setting specified by the spec field. The value must be in the proper range for the spec value and at least as large as the size specified in valueSize.</para>
		/// </summary>
		public IntPtr value;
	}
}
