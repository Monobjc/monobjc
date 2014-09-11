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
using Monobjc.ApplicationServices;

namespace Monobjc.QuartzCore
{
	public partial struct CATransform3D
	{
		/// <summary>
		/// 	<para>Concatenate 'b' to 'a' and return the result: t' = a * b.</para>
		/// 	<para>Original signature is : CATransform3D CATransform3DConcat (CATransform3D a, CATransform3D b);</para>
		/// 	<para>Available in Mac OS X version 10.5 and later.</para>
		/// </summary>
		public static CATransform3D Concat (CATransform3D a, CATransform3D b)
		{
			// TODO: Check matrices at http://www.devmaster.net/wiki/Transformation_matrices
			return new CATransform3D (a.m11 * b.m11 + a.m12 * b.m21 + a.m13 * b.m31 + a.m14 * b.m41,
                                     a.m11 * b.m12 + a.m12 * b.m22 + a.m13 * b.m32 + a.m14 * b.m42,
                                     a.m11 * b.m13 + a.m12 * b.m23 + a.m13 * b.m33 + a.m14 * b.m43,
                                     a.m11 * b.m14 + a.m12 * b.m24 + a.m13 * b.m34 + a.m14 * b.m44,

                                     a.m21 * b.m11 + a.m22 * b.m21 + a.m23 * b.m31 + a.m24 * b.m41,
                                     a.m21 * b.m12 + a.m22 * b.m22 + a.m23 * b.m32 + a.m24 * b.m42,
                                     a.m21 * b.m13 + a.m22 * b.m23 + a.m23 * b.m33 + a.m24 * b.m43,
                                     a.m21 * b.m14 + a.m22 * b.m24 + a.m23 * b.m34 + a.m24 * b.m44,

                                     a.m31 * b.m11 + a.m32 * b.m21 + a.m33 * b.m31 + a.m34 * b.m41,
                                     a.m31 * b.m12 + a.m32 * b.m22 + a.m33 * b.m32 + a.m34 * b.m42,
                                     a.m31 * b.m13 + a.m32 * b.m23 + a.m33 * b.m33 + a.m34 * b.m43,
                                     a.m31 * b.m14 + a.m32 * b.m24 + a.m33 * b.m34 + a.m34 * b.m44,

                                     a.m41 * b.m11 + a.m42 * b.m21 + a.m43 * b.m31 + a.m44 * b.m41,
                                     a.m41 * b.m12 + a.m42 * b.m22 + a.m43 * b.m32 + a.m44 * b.m42,
                                     a.m41 * b.m13 + a.m42 * b.m23 + a.m43 * b.m33 + a.m44 * b.m43,
                                     a.m41 * b.m14 + a.m42 * b.m24 + a.m43 * b.m34 + a.m44 * b.m44);
		}

		/// <summary>
		///     <para>Returns a Boolean value that indicates whether the two transforms are exactly equal.</para>
		///     <para>Original signature is : bool CATransform3DEqualToTransform (CATransform3D a, CATransform3D b);</para>
		/// 	<para>Available in Mac OS X version 10.5 and later.</para>
		/// </summary>
		public static bool EqualToTransform (CATransform3D a, CATransform3D b)
		{
			return Equals (a, b);
		}

		/// <summary>
		///     <para>Returns the affine transform represented by 't'. If 't' can not be exactly represented as an affine transform the returned value is undefined.</para>
		///     <para>Original signature is : CGAffineTransform CATransform3DGetAffineTransform (CATransform3D t);</para>
		/// 	<para>Available in Mac OS X version 10.5 and later.</para>
		/// </summary>
		public static CGAffineTransform CATransform3DGetAffineTransform (CATransform3D t)
		{
			// TODO : To implement
			throw new NotImplementedException ();
		}

		/// <summary>
		///     <para>Invert 't' and return the result. Returns the original matrix if 't' has no inverse.</para>
		///     <para>Original signature is : CATransform3D CATransform3DInvert (CATransform3D t);</para>
		/// 	<para>Available in Mac OS X version 10.5 and later.</para>
		/// </summary>
		public static CATransform3D Invert (CATransform3D t)
		{
			// TODO : To implement
			throw new NotImplementedException ();
		}

		/// <summary>
		///     <para>Returns true if 't' can be exactly represented by an affine transform.</para>
		///     <para>Original signature is : bool CATransform3DIsAffine (CATransform3D t);</para>
		/// 	<para>Available in Mac OS X version 10.5 and later.</para>
		/// </summary>
		public static bool IsAffine (CATransform3D t)
		{
			// TODO : To implement
			throw new NotImplementedException ();
		}

		/// <summary>
		///     <para>Returns a Boolean value that indicates whether the transform is the identity transform.</para>
		///     <para>Original signature is : bool CATransform3DIsIdentity (CATransform3D t);</para>
		/// 	<para>Available in Mac OS X version 10.5 and later.</para>
		/// </summary>
		public static bool IsIdentity (CATransform3D t)
		{
			return EqualToTransform (t, Identity);
		}

		/// <summary>
		///     <para>Return a transform with the same effect as affine transform 'm'.</para>
		///     <para>Original signature is : CATransform3D CATransform3DMakeAffineTransform (CGAffineTransform m)</para>
		/// 	<para>Available in Mac OS X version 10.5 and later.</para>
		/// </summary>
		public static CATransform3D Make (CGAffineTransform m)
		{
			// TODO : To implement
			throw new NotImplementedException ();
		}

		/// <summary>
		///     <para>Returns a transform that rotates by 'angle' radians about the vector '(x, y, z)'. If the vector has length zero the identity transform is returned.</para>
		///     <para>Original signature is : CATransform3D CATransform3DMakeRotation (CGFloat angle, CGFloat x, CGFloat y, CGFloat z);</para>
		/// 	<para>Available in Mac OS X version 10.5 and later.</para>
		/// </summary>
		public static CATransform3D MakeRotation (float angle, float x, float y, float z)
		{
			// TODO: Check matrices at http://www.devmaster.net/wiki/Transformation_matrices
			float oneMinusCos = (float)(1.0d - Math.Cos (angle));
			float sin = (float)Math.Sin (angle);
			float x2 = x * x;
			float y2 = y * y;
			float z2 = z * z;

			return new CATransform3D (1.0f + oneMinusCos * (x2 - 1), oneMinusCos * x * y + z * sin, oneMinusCos * x * z - y * sin, 0,
                                     oneMinusCos * x * y - z * sin, 1.0f + oneMinusCos * (y2 - 1.0f), oneMinusCos * y * z - x * sin, 0,
                                     oneMinusCos * x * z + y * sin, oneMinusCos * y * z - x * sin, 1.0f + oneMinusCos * (z2 - 1.0f), 0,
                                     0, 0, 0, 1.0f);
		}

		/// <summary>
		///     <para>Returns a transform that scales by `(sx, sy, sz)': * t' = [sx 0 0 0; 0 sy 0 0; 0 0 sz 0; 0 0 0 1].</para>
		///     <para>Original signature is : CATransform3D CATransform3DMakeScale (CGFloat sx, CGFloat sy, CGFloat sz);</para>
		/// 	<para>Available in Mac OS X version 10.5 and later.</para>
		/// </summary>
		public static CATransform3D MakeScale (float sx, float sy, float sz)
		{
			// TODO: Check matrices at http://www.devmaster.net/wiki/Transformation_matrices
			return new CATransform3D (sx, 0.0f, 0.0f, 0.0f,
                                     0.0f, sy, 0.0f, 0.0f,
                                     0.0f, 0.0f, sz, 0.0f,
                                     0.0f, 0.0f, 0.0f, 1.0f);
		}

		/// <summary>
		///     <para>Returns a transform that translates by '(tx, ty, tz)'. t' = [1 0 0 0; 0 1 0 0; 0 0 1 0; tx ty tz 1].</para>
		///     <para>Original signature is : CATransform3D CATransform3DMakeTranslation (CGFloat tx, CGFloat ty, CGFloat tz)</para>
		/// 	<para>Available in Mac OS X version 10.5 and later.</para>
		/// </summary>
		public static CATransform3D MakeTranslation (float tx, float ty, float tz)
		{
			// TODO: Check matrices at http://www.devmaster.net/wiki/Transformation_matrices
			return new CATransform3D (1.0f, 0.0f, 0.0f, 0.0f,
                                     0.0f, 1.0f, 0.0f, 0.0f,
                                     0.0f, 0.0f, 1.0f, 0.0f,
                                     tx, ty, tz, 1.0f);
		}

		/// <summary>
		///     <para>Rotate 't' by 'angle' radians about the vector '(x, y, z)' and return the result. If the vector has zero length the behavior is undefined: t' = rotation(angle, x, y, z) * t.</para>
		///     <para>Original signature is : CATransform3D CATransform3DRotate (CATransform3D t, CGFloat angle, CGFloat x, CGFloat y, CGFloat z)</para>
		/// 	<para>Available in Mac OS X version 10.5 and later.</para>
		/// </summary>
		public static CATransform3D Rotate (CATransform3D t, float angle, float x, float y, float z)
		{
			CATransform3D rotation = MakeRotation (angle, x, y, z);
			return Concat (t, rotation);
		}

		/// <summary>
		///     <para>Scale 't' by '(sx, sy, sz)' and return the result: * t' = scale(sx, sy, sz) * t.</para>
		///     <para>Original signature is : CATransform3D CATransform3DScale (CATransform3D t, CGFloat sx, CGFloat sy, CGFloat sz)</para>
		/// 	<para>Available in Mac OS X version 10.5 and later.</para>
		/// </summary>
		public static CATransform3D Scale (CATransform3D t, float sx, float sy, float sz)
		{
			// TODO: Check matrices at http://www.devmaster.net/wiki/Transformation_matrices
			return new CATransform3D (t.m11 * sx, t.m12 * sy, t.m13 * sz, t.m14,
                                     t.m21 * sx, t.m22 * sy, t.m23 * sz, t.m24,
                                     t.m31 * sx, t.m32 * sy, t.m33 * sz, t.m34,
                                     t.m41 * sx, t.m42 * sy, t.m43 * sz, t.m44);
		}

		/// <summary>
		/// 	<para>Translate 't' by '(tx, ty, tz)' and return the result: * t' = translate(tx, ty, tz) * t.</para>
		/// 	<para>Original signature is : CATransform3D CATransform3DTranslate (CATransform3D t, CGFloat tx, CGFloat ty, CGFloat tz);</para>
		/// 	<para>Available in Mac OS X version 10.5 and later.</para>
		/// </summary>
		public static CATransform3D Translate (CATransform3D t, float tx, float ty, float tz)
		{
			// TODO: Check matrices at http://www.devmaster.net/wiki/Transformation_matrices
			return new CATransform3D (t.m11 + t.m14 * tx, t.m12 + t.m14 * ty, t.m13 + t.m14 * tz, t.m14,
                                     t.m21 + t.m24 * tx, t.m22 + t.m24 * ty, t.m23 + t.m24 * tz, t.m24,
                                     t.m31 + t.m34 * tx, t.m32 + t.m34 * ty, t.m33 + t.m34 * tz, t.m34,
                                     t.m41 + t.m44 * tx, t.m42 + t.m44 * ty, t.m43 + t.m44 * tz, t.m44);
		}
	}
}