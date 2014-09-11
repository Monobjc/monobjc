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
	/// <summary>
	/// The UUID structure defines Universally Unique Identifiers (UUIDs). UUIDs provide unique designations of objects such as interfaces, manager entry-point vectors, and client objects.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public partial struct UUID
	{
		/// <summary>
		/// <para>Specifies the first 8 hexadecimal digits of the UUID.</para>
		/// </summary>
		public uint a;
		/// <summary>
		/// <para>Specifies the first group of 4 hexadecimal digits of the UUID.</para>
		/// </summary>
		public ushort b;
		/// <summary>
		/// <para>Specifies the second group of 4 hexadecimal digits of the UUID.</para>
		/// </summary>
		public ushort c;
		/// <summary>
		/// <para>Array of eight elements. The first two elements contain the third group of 4 hexadecimal digits of the UUID. The remaining six elements contain the final 12 hexadecimal digits of the UUID.</para>
		/// </summary>
		public byte d, e, f, g, h, i, j, k;
		
		/// <summary>
		/// Returns the a string representation of this instance.
		/// </summary>
		/// <returns>
		/// A <see cref="T:System.String"></see> containing a representation of this instance.
		/// </returns>
		public override String ToString ()
		{
			return ToGuid(this).ToString();
		}
	}
}
