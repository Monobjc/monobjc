//
// This file is part of Monobjc, a .NET/Objective-C bridge
// Copyright (C) 2007-2013 - Laurent Etiemble
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

namespace Monobjc.GLKit
{
#if MACOSX_10_8
	/// <summary>
	/// <para>A representation of a 4-component vector.</para>
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public partial struct GLKVector4
	{
		/// <summary>
		/// <para>The first element.</para>
		/// </summary>
		public float x;
		/// <summary>
		/// <para>The second element.</para>
		/// </summary>
		public float y;
		/// <summary>
		/// <para>The third element.</para>
		/// </summary>
		public float z;
		/// <summary>
		/// <para>The fourth element.</para>
		/// </summary>
		public float w;

		/// <summary>
		/// Initializes a new instance of the <see cref="Monobjc.GLKit.GLKVector4"/> struct.
		/// </summary>
		public GLKVector4(float x, float y, float z, float w) {
			this.x = x;
			this.y = y;
			this.z = z;
			this.w = w;
		}
	}
#endif
}
