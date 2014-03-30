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
	/// <para>Defines the standard transform matrix used throughout Core Animation.</para>
	/// <para>The transform matrix is used to rotate, scale, translate, skew, and project the layer content. Functions are provided for creating, concatenating, and modifying CATransform3D data.</para>
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	[ObjectiveCUnderlyingType(typeof(CATransform3D), Is64Bits = false)]
	[ObjectiveCUnderlyingType(typeof(CATransform3D64), Is64Bits = true)]
	public partial struct CATransform3D : IEquatable<CATransform3D>
	{
		/// <summary>
		/// Defines the identity transform matrix used by Core Animation.
		/// </summary>
		public static readonly CATransform3D Identity = new CATransform3D (1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1);

		/// <summary>
		/// Matrix coefficient at position 1, 1
		/// </summary>
		public float m11;

		/// <summary>
		/// Matrix coefficient at position 1, 2
		/// </summary>
		public float m12;

		/// <summary>
		/// Matrix coefficient at position 1, 3
		/// </summary>
		public float m13;

		/// <summary>
		/// Matrix coefficient at position 1, 4
		/// </summary>
		public float m14;

		/// <summary>
		/// Matrix coefficient at position 2, 1
		/// </summary>
		public float m21;

		/// <summary>
		/// Matrix coefficient at position 2, 2
		/// </summary>
		public float m22;

		/// <summary>
		/// Matrix coefficient at position 2, 3
		/// </summary>
		public float m23;

		/// <summary>
		/// Matrix coefficient at position 2, 4
		/// </summary>
		public float m24;

		/// <summary>
		/// Matrix coefficient at position 3, 1
		/// </summary>
		public float m31;

		/// <summary>
		/// Matrix coefficient at position 3, 2
		/// </summary>
		public float m32;

		/// <summary>
		/// Matrix coefficient at position 3, 3
		/// </summary>
		public float m33;

		/// <summary>
		/// Matrix coefficient at position 3, 4
		/// </summary>
		public float m34;

		/// <summary>
		/// Matrix coefficient at position 4, 1
		/// </summary>
		public float m41;

		/// <summary>
		/// Matrix coefficient at position 4, 2
		/// </summary>
		public float m42;

		/// <summary>
		/// Matrix coefficient at position 4, 3
		/// </summary>
		public float m43;

		/// <summary>
		/// Matrix coefficient at position 4, 4
		/// </summary>
		public float m44;

		/// <summary>
		/// Initializes a new instance of the <see cref="CATransform3D"/> struct.
		/// </summary>
		public CATransform3D (CGFloat m11, CGFloat m12, CGFloat m13, CGFloat m14, 
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
		/// Implements the operator !=.
		/// </summary>
		/// <param name="caTransform3D1">The ca transform3 d1.</param>
		/// <param name="caTransform3D2">The ca transform3 d2.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator != (CATransform3D caTransform3D1, CATransform3D caTransform3D2)
		{
			return !caTransform3D1.Equals (caTransform3D2);
		}

		/// <summary>
		/// Implements the operator ==.
		/// </summary>
		/// <param name="caTransform3D1">The ca transform3 d1.</param>
		/// <param name="caTransform3D2">The ca transform3 d2.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator == (CATransform3D caTransform3D1, CATransform3D caTransform3D2)
		{
			return caTransform3D1.Equals (caTransform3D2);
		}

		/// <summary>
		/// Equalses the specified ca transform3 D.
		/// </summary>
		/// <param name="caTransform3D">The ca transform3 D.</param>
		/// <returns></returns>
		public bool Equals (CATransform3D caTransform3D)
		{
			if (m11 != caTransform3D.m11) {
				return false;
			}
			if (m12 != caTransform3D.m12) {
				return false;
			}
			if (m13 != caTransform3D.m13) {
				return false;
			}
			if (m14 != caTransform3D.m14) {
				return false;
			}
			if (m21 != caTransform3D.m21) {
				return false;
			}
			if (m22 != caTransform3D.m22) {
				return false;
			}
			if (m23 != caTransform3D.m23) {
				return false;
			}
			if (m24 != caTransform3D.m24) {
				return false;
			}
			if (m31 != caTransform3D.m31) {
				return false;
			}
			if (m32 != caTransform3D.m32) {
				return false;
			}
			if (m33 != caTransform3D.m33) {
				return false;
			}
			if (m34 != caTransform3D.m34) {
				return false;
			}
			if (m41 != caTransform3D.m41) {
				return false;
			}
			if (m42 != caTransform3D.m42) {
				return false;
			}
			if (m43 != caTransform3D.m43) {
				return false;
			}
			if (m44 != caTransform3D.m44) {
				return false;
			}
			return true;
		}

		/// <summary>
		/// Indicates whether this instance and a specified object are equal.
		/// </summary>
		/// <param name="obj">Another object to compare to.</param>
		/// <returns>
		/// true if obj and this instance are the same type and represent the same value; otherwise, false.
		/// </returns>
		public override bool Equals (object obj)
		{
			if (!(obj is CATransform3D)) {
				return false;
			}
			return Equals ((CATransform3D)obj);
		}

		/// <summary>
		/// Returns the hash code for this instance.
		/// </summary>
		/// <returns>
		/// A 32-bit signed integer that is the hash code for this instance.
		/// </returns>
		public override int GetHashCode ()
		{
			int result = m11.GetHashCode ();
			result = 29 * result + m12.GetHashCode ();
			result = 29 * result + m13.GetHashCode ();
			result = 29 * result + m14.GetHashCode ();
			result = 29 * result + m21.GetHashCode ();
			result = 29 * result + m22.GetHashCode ();
			result = 29 * result + m23.GetHashCode ();
			result = 29 * result + m24.GetHashCode ();
			result = 29 * result + m31.GetHashCode ();
			result = 29 * result + m32.GetHashCode ();
			result = 29 * result + m33.GetHashCode ();
			result = 29 * result + m34.GetHashCode ();
			result = 29 * result + m41.GetHashCode ();
			result = 29 * result + m42.GetHashCode ();
			result = 29 * result + m43.GetHashCode ();
			result = 29 * result + m44.GetHashCode ();
			return result;
		}
	}
}
