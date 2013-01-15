//
// This file is part of Monobjc, a .NET/Objective-C bridge
// Copyright (C) 2007-2012 - Laurent Etiemble
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
	/// <para>A 2x2 matrix.</para>
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public partial struct GLKMatrix2
	{
		public float m00, m01;
		public float m10, m11;

		/// <summary>
		/// Initializes a new instance of the <see cref="Monobjc.GLKit.GLKMatrix2"/> struct.
		/// </summary>
		public GLKMatrix2(float m00, float m01, float m10, float m11){
			this.m00 = m00;
			this.m01 = m01;
			this.m10 = m10;
			this.m11 = m11;
		}

		/// <summary>
		/// Gets or sets the value at the specified index.
		/// </summary>
		public float this [int index] {
			get {
				switch (index) {
				case 0:
					return this.m00;
				case 1:
					return this.m01;
				case 2:
					return this.m10;
				case 3:
					return this.m11;
				default:
					throw new System.IndexOutOfRangeException ();
				}
			}
			set {
				switch (index) {
				case 0:
					this.m00 = value;
					break;
				case 1:
					this.m01 = value;
					break;
				case 2:
					this.m10 = value;
					break;
				case 3:
					this.m11 = value;
					break;
				default:
					throw new System.IndexOutOfRangeException ();
				}
			}
		}
	}
#endif
}
