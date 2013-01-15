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
	/// <para>A 4x4 matrix.</para>
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public partial struct GLKMatrix4
	{
		public float m00, m01, m02, m03;
		public float m10, m11, m12, m13;
		public float m20, m21, m22, m23;
		public float m30, m31, m32, m33;

		/// <summary>
		/// Initializes a new instance of the <see cref="Monobjc.GLKit.GLKMatrix4"/> struct.
		/// </summary>
		public GLKMatrix4(float m00, float m01, float m02, float m03, float m10, float m11, float m12, float m13, float m20, float m21, float m22, float m23, float m30, float m31, float m32, float m33){
			this.m00 = m00;
			this.m01 = m01;
			this.m02 = m02;
			this.m03 = m03;
			this.m10 = m10;
			this.m11 = m11;
			this.m12 = m12;
			this.m13 = m13;
			this.m20 = m20;
			this.m21 = m21;
			this.m22 = m22;
			this.m23 = m23;
			this.m30 = m30;
			this.m31 = m31;
			this.m32 = m32;
			this.m33 = m33;
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
					return this.m02;
				case 3:
					return this.m03;
				case 4:
					return this.m10;
				case 5:
					return this.m11;
				case 6:
					return this.m12;
				case 7:
					return this.m13;
				case 8:
					return this.m20;
				case 9:
					return this.m21;
				case 10:
					return this.m22;
				case 11:
					return this.m23;
				case 12:
					return this.m30;
				case 13:
					return this.m31;
				case 14:
					return this.m32;
				case 15:
					return this.m33;
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
					this.m02 = value;
					break;
				case 3:
					this.m03 = value;
					break;
				case 4:
					this.m10 = value;
					break;
				case 5:
					this.m11 = value;
					break;
				case 6:
					this.m12 = value;
					break;
				case 7:
					this.m13 = value;
					break;
				case 8:
					this.m20 = value;
					break;
				case 9:
					this.m21 = value;
					break;
				case 10:
					this.m22 = value;
					break;
				case 11:
					this.m23 = value;
					break;
				case 12:
					this.m30 = value;
					break;
				case 13:
					this.m31 = value;
					break;
				case 14:
					this.m32 = value;
					break;
				case 15:
					this.m33 = value;
					break;
				default:
					throw new System.IndexOutOfRangeException ();
				}
			}
		}
	}
#endif
}
