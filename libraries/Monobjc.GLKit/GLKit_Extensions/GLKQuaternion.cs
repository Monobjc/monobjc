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

namespace Monobjc.GLKit
{
#if MACOSX_10_8
	public partial struct GLKQuaternion
	{
		/// <summary>
		/// An identity quaternion.
		/// </summary>
		public static readonly GLKQuaternion Identity = new GLKQuaternion (1, 1, 1, 1);

		/// <summary>
		/// <para>Returns the sum of two quaternions.</para>
		/// <para>Original signature is 'GLKQuaternion GLKQuaternionAdd ( GLKQuaternion quaternionLeft, GLKQuaternion quaternionRight );'</para>
		/// <para>Available in OS X x0.8 and later.</para>
		/// </summary>
		/// <param name="quaternionLeft">MISSING</param>
		/// <param name="quaternionRight">MISSING</param>
		/// <returns>A new quaternion.</returns>
		public static GLKQuaternion Add (GLKQuaternion quaternionLeft, GLKQuaternion quaternionRight)
		{
			GLKQuaternion q = new GLKQuaternion (quaternionLeft.x + quaternionRight.x,
				quaternionLeft.y + quaternionRight.y,
				quaternionLeft.z + quaternionRight.z,
				quaternionLeft.w + quaternionRight.w);
			return q;
		}

		/// <summary>
		/// <para>Returns the conjugate of a quaternion.</para>
		/// <para>Original signature is 'GLKQuaternion GLKQuaternionConjugate ( GLKQuaternion quaternion );'</para>
		/// <para>Available in OS X x0.8 and later.</para>
		/// </summary>
		/// <param name="quaternion">MISSING</param>
		/// <returns>A new quaternion that is the conjugate of the source quaternion.</returns>
		public static GLKQuaternion Conjugate (GLKQuaternion quaternion)
		{
			GLKQuaternion q = new GLKQuaternion (-quaternion.x, -quaternion.y, -quaternion.z, quaternion.w);
			return q;
		}

		/// <summary>
		/// <para>Returns an inverse of a quaternion.</para>
		/// <para>Original signature is 'GLKQuaternion GLKQuaternionInvert ( GLKQuaternion quaternion );'</para>
		/// <para>Available in OS X x0.8 and later.</para>
		/// </summary>
		/// <param name="quaternion">MISSING</param>
		/// <returns>A new quaternion that is the inverse of the source quaternion.</returns>
		public static GLKQuaternion Invert (GLKQuaternion quaternion)
		{
			float scale = 1.0f / (quaternion.x * quaternion.x + 
				quaternion.y * quaternion.y +
				quaternion.z * quaternion.z +
				quaternion.w * quaternion.w);
			GLKQuaternion q = new GLKQuaternion (-quaternion.x * scale, -quaternion.y * scale, -quaternion.z * scale, quaternion.w * scale);
			return q;
		}

		/// <summary>
		/// <para>Returns the length of a quaternion.</para>
		/// <para>Original signature is 'float GLKQuaternionLength ( GLKQuaternion quaternion );'</para>
		/// <para>Available in OS X x0.8 and later.</para>
		/// </summary>
		/// <param name="quaternion">MISSING</param>
		/// <returns>The length of the quaternion.</returns>
		public static float Length (GLKQuaternion quaternion)
		{
			return (float)Math.Sqrt (quaternion.x * quaternion.x +
				quaternion.y * quaternion.y +
				quaternion.z * quaternion.z +
				quaternion.w * quaternion.w);
		}

		/// <summary>
		/// <para>Returns a quaternion created from its separate components.</para>
		/// <para>Original signature is 'GLKQuaternion GLKQuaternionMake ( float x, float y, float z, float w );'</para>
		/// <para>Available in OS X x0.8 and later.</para>
		/// </summary>
		/// <param name="x">MISSING</param>
		/// <param name="y">MISSING</param>
		/// <param name="z">MISSING</param>
		/// <param name="w">MISSING</param>
		/// <returns>A new quaternion.</returns>
		public static GLKQuaternion Make (float x, float y, float z, float w)
		{
			GLKQuaternion q = new GLKQuaternion (x, y, z, w);
			return q;
		}

		/// <summary>
		/// <para>Creates a quaternion that represents a rotation around an axis.</para>
		/// <para>Original signature is 'GLKQuaternion GLKQuaternionMakeWithAngleAndAxis ( float radians, float x, float y, float z );'</para>
		/// <para>Available in OS X x0.8 and later.</para>
		/// </summary>
		/// <param name="radians">MISSING</param>
		/// <param name="x">MISSING</param>
		/// <param name="y">MISSING</param>
		/// <param name="z">MISSING</param>
		/// <returns>A new quaternion.</returns>
		public static GLKQuaternion MakeWithAngleAndAxis (float radians, float x, float y, float z)
		{
			float halfAngle = radians * 0.5f;
			float scale = (float)Math.Sin (halfAngle);
			GLKQuaternion q = new GLKQuaternion (scale * x, scale * y, scale * z, (float)Math.Cos (halfAngle));
			return q;
		}

		/// <summary>
		/// <para>Creates a quaternion that represents a rotation around an axis.</para>
		/// <para>Original signature is 'GLKQuaternion GLKQuaternionMakeWithAngleAndVector3Axis ( float radians, GLKVector3 axisVector );'</para>
		/// <para>Available in OS X x0.8 and later.</para>
		/// </summary>
		/// <param name="radians">MISSING</param>
		/// <param name="axisVector">MISSING</param>
		/// <returns>A new quaternion.</returns>
		public static GLKQuaternion MakeWithAngleAndVector3Axis (float radians, GLKVector3 axisVector)
		{
			return MakeWithAngleAndAxis (radians, axisVector.x, axisVector.y, axisVector.z);
		}

		/// <summary>
		/// <para>Returns a quaternion created from an array of components.</para>
		/// <para>Original signature is 'GLKQuaternion GLKQuaternionMakeWithArray ( float values[4] );'</para>
		/// <para>Available in OS X x0.8 and later.</para>
		/// </summary>
		/// <param name="values">MISSING</param>
		/// <returns>A new quaternion.</returns>
		public static GLKQuaternion MakeWithArray (IntPtr values)
		{
			throw new NotImplementedException ();
		}

		/// <summary>
		/// <para>Returns a quaternion created from a vector and a scalar.</para>
		/// <para>Original signature is 'GLKQuaternion GLKQuaternionMakeWithVector3 ( GLKVector3 vector, float scalar );'</para>
		/// <para>Available in OS X x0.8 and later.</para>
		/// </summary>
		/// <param name="vector">MISSING</param>
		/// <param name="scalar">MISSING</param>
		/// <returns>A new quaternion.</returns>
		public static GLKQuaternion MakeWithVector3 (GLKVector3 vector, float scalar)
		{
			GLKQuaternion q = new GLKQuaternion (vector.x, vector.y, vector.z, scalar);
			return q;
		}

		/// <summary>
		/// <para>Returns the product of two quaternions.</para>
		/// <para>Original signature is 'GLKQuaternion GLKQuaternionMultiply ( GLKQuaternion quaternionLeft, GLKQuaternion quaternionRight );'</para>
		/// <para>Available in OS X x0.8 and later.</para>
		/// </summary>
		/// <param name="quaternionLeft">MISSING</param>
		/// <param name="quaternionRight">MISSING</param>
		/// <returns>A new quaternion.</returns>
		public static GLKQuaternion Multiply (GLKQuaternion quaternionLeft, GLKQuaternion quaternionRight)
		{
			GLKQuaternion q = new GLKQuaternion (quaternionLeft.w * quaternionRight.x +
				quaternionLeft.x * quaternionRight.w +
				quaternionLeft.y * quaternionRight.z -
				quaternionLeft.z * quaternionRight.y,
        
				quaternionLeft.w * quaternionRight.y +
				quaternionLeft.y * quaternionRight.w +
				quaternionLeft.z * quaternionRight.x -
				quaternionLeft.x * quaternionRight.z,
        
				quaternionLeft.w * quaternionRight.z +
				quaternionLeft.z * quaternionRight.w +
				quaternionLeft.x * quaternionRight.y -
				quaternionLeft.y * quaternionRight.x,
        
				quaternionLeft.w * quaternionRight.w -
				quaternionLeft.x * quaternionRight.x -
				quaternionLeft.y * quaternionRight.y -
				quaternionLeft.z * quaternionRight.z);
			return q;
		}

		/// <summary>
		/// <para>Returns a normalized version of a quaternion.</para>
		/// <para>Original signature is 'GLKQuaternion GLKQuaternionNormalize ( GLKQuaternion quaternion );'</para>
		/// <para>Available in OS X x0.8 and later.</para>
		/// </summary>
		/// <param name="quaternion">MISSING</param>
		/// <returns>A new quaternion, normalized to have a length of 1.0.</returns>
		public static GLKQuaternion Normalize (GLKQuaternion quaternion)
		{
			float scale = 1.0f / Length (quaternion);
			GLKQuaternion q = new GLKQuaternion (quaternion.x * scale, quaternion.y * scale, quaternion.z * scale, quaternion.w * scale);
			return q;
		}

		/// <summary>
		/// <para>Returns a new vector that is calculated by applying a quaternion rotation to a vector.</para>
		/// <para>Original signature is 'GLKVector3 GLKQuaternionRotateVector3 ( GLKQuaternion quaternion, GLKVector3 vector );'</para>
		/// <para>Available in OS X x0.8 and later.</para>
		/// </summary>
		/// <param name="quaternion">MISSING</param>
		/// <param name="vector">MISSING</param>
		/// <returns>A new vector.</returns>
		public static GLKVector3 RotateVector3 (GLKQuaternion quaternion, GLKVector3 vector)
		{
			GLKQuaternion rotatedQuaternion = Make (vector.x, vector.y, vector.z, 0.0f);
			rotatedQuaternion = Multiply (Multiply (quaternion, rotatedQuaternion), Invert (quaternion));
			return GLKVector3.Make (rotatedQuaternion.x, rotatedQuaternion.y, rotatedQuaternion.z);
		}

		/// <summary>
		/// <para>Returns a new vector calculated by applying a quaternion rotation to a vector.</para>
		/// <para>Original signature is 'GLKVector4 GLKQuaternionRotateVector4 ( GLKQuaternion quaternion, GLKVector4 vector );'</para>
		/// <para>Available in OS X x0.8 and later.</para>
		/// </summary>
		/// <param name="quaternion">MISSING</param>
		/// <param name="vector">MISSING</param>
		/// <returns>A new vector.</returns>
		public static GLKVector4 RotateVector4 (GLKQuaternion quaternion, GLKVector4 vector)
		{
			GLKQuaternion rotatedQuaternion = Make (vector.x, vector.y, vector.z, 0.0f);
			rotatedQuaternion = Multiply (Multiply (quaternion, rotatedQuaternion), Invert (quaternion));
			return GLKVector4.Make (rotatedQuaternion.x, rotatedQuaternion.y, rotatedQuaternion.z, vector.w);
		}

		/// <summary>
		/// <para>Returns the difference between two quaternions.</para>
		/// <para>Original signature is 'GLKQuaternion GLKQuaternionSubtract ( GLKQuaternion quaternionLeft, GLKQuaternion quaternionRight );'</para>
		/// <para>Available in OS X x0.8 and later.</para>
		/// </summary>
		/// <param name="quaternionLeft">MISSING</param>
		/// <param name="quaternionRight">MISSING</param>
		/// <returns>A new quaternion.</returns>
		public static GLKQuaternion Subtract (GLKQuaternion quaternionLeft, GLKQuaternion quaternionRight)
		{
			GLKQuaternion q = new GLKQuaternion (quaternionLeft.x - quaternionRight.x,
                        quaternionLeft.y - quaternionRight.y,
                        quaternionLeft.z - quaternionRight.z,
                        quaternionLeft.w - quaternionRight.w);
			return q;
		}
	}
#endif
}
