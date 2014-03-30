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
using Monobjc.ApplicationServices;

namespace Monobjc.QuartzCore
{
	/// <summary>
	/// Structure used for marshalling on 64 bits platforms.
	/// Never use this structure directly.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public partial struct CATransform3D64
	{
		/// <summary>
		/// Matrix coefficient at position 1, 1
		/// </summary>
		public double m11;

		/// <summary>
		/// Matrix coefficient at position 1, 2
		/// </summary>
		public double m12;

		/// <summary>
		/// Matrix coefficient at position 1, 3
		/// </summary>
		public double m13;

		/// <summary>
		/// Matrix coefficient at position 1, 4
		/// </summary>
		public double m14;

		/// <summary>
		/// Matrix coefficient at position 2, 1
		/// </summary>
		public double m21;

		/// <summary>
		/// Matrix coefficient at position 2, 2
		/// </summary>
		public double m22;

		/// <summary>
		/// Matrix coefficient at position 2, 3
		/// </summary>
		public double m23;

		/// <summary>
		/// Matrix coefficient at position 2, 4
		/// </summary>
		public double m24;

		/// <summary>
		/// Matrix coefficient at position 3, 1
		/// </summary>
		public double m31;

		/// <summary>
		/// Matrix coefficient at position 3, 2
		/// </summary>
		public double m32;

		/// <summary>
		/// Matrix coefficient at position 3, 3
		/// </summary>
		public double m33;

		/// <summary>
		/// Matrix coefficient at position 3, 4
		/// </summary>
		public double m34;

		/// <summary>
		/// Matrix coefficient at position 4, 1
		/// </summary>
		public double m41;

		/// <summary>
		/// Matrix coefficient at position 4, 2
		/// </summary>
		public double m42;

		/// <summary>
		/// Matrix coefficient at position 4, 3
		/// </summary>
		public double m43;

		/// <summary>
		/// Matrix coefficient at position 4, 4
		/// </summary>
		public double m44;

		/// <summary>
		/// Initializes a new instance of the <see cref="CATransform3D64"/> struct.
		/// </summary>
		public CATransform3D64 (CGFloat m11, CGFloat m12, CGFloat m13, CGFloat m14, 
		                        CGFloat m21, CGFloat m22, CGFloat m23, CGFloat m24, 
		                        CGFloat m31, CGFloat m32, CGFloat m33, CGFloat m34, 
		                        CGFloat m41, CGFloat m42, CGFloat m43, CGFloat m44)
		{
			this.m11 = m11;
			this.m12 = m12;
			this.m13 = m13;
			this.m14 = m14;
			this.m21 = m21;
			this.m22 = m22;
			this.m23 = m23;
			this.m24 = m24;
			this.m31 = m31;
			this.m32 = m32;
			this.m33 = m33;
			this.m34 = m34;
			this.m41 = m41;
			this.m42 = m42;
			this.m43 = m43;
			this.m44 = m44;
		}

		/// <summary>
		/// Performs an implicit conversion from <see cref="Monobjc.QuartzCore.CATransform3D64"/> to <see cref="Monobjc.QuartzCore.CATransform3D"/>.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator CATransform3D (CATransform3D64 value)
		{
			return new CATransform3D (
				value.m11, value.m12, value.m13, value.m14,
				value.m21, value.m22, value.m23, value.m24,
				value.m31, value.m32, value.m33, value.m34,
				value.m41, value.m42, value.m43, value.m44
			);
		}
		
		/// <summary>
		/// Performs an implicit conversion from <see cref="Monobjc.QuartzCore.CATransform3D"/> to <see cref="Monobjc.QuartzCore.CATransform3D64"/>.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator CATransform3D64 (CATransform3D value)
		{
			return new CATransform3D64 (
				value.m11, value.m12, value.m13, value.m14,
				value.m21, value.m22, value.m23, value.m24,
				value.m31, value.m32, value.m33, value.m34,
				value.m41, value.m42, value.m43, value.m44
			);
		}
	}
}
