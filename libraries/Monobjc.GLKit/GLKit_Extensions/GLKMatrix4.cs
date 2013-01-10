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
using System;
using Monobjc.Foundation;

namespace Monobjc.GLKit
{
#if MACOSX_10_8
	public partial struct GLKMatrix4
	{
		/// <summary>
		/// A 3x3 identity matrix.
		/// </summary>
		public static readonly GLKMatrix4 Identity = new GLKMatrix4 (1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1);

		/// <summary>
		/// <para>Retrieves a column from a 4x4 matrix.</para>
		/// <para>Original signature is 'GLKVector4 GLKMatrix4GetColumn ( GLKMatrix4 matrix, int column );'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="matrix">MISSING</param>
		/// <param name="column">MISSING</param>
		/// <returns>A vector representing the column retrieved from the matrix.</returns>
		public static GLKVector4 GetColumn (GLKMatrix4 matrix, int column)
		{
			GLKVector4 v = new GLKVector4 (matrix [column * 4 + 0], matrix [column * 4 + 1], matrix [column * 4 + 2], matrix [column * 4 + 3]);
			return v;
		}

		/// <summary>
		/// <para>Returns the upper-left 2x2 section of a 4x4 matrix.</para>
		/// <para>Original signature is 'GLKMatrix2 GLKMatrix4GetMatrix2 ( GLKMatrix4 matrix );'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="matrix">MISSING</param>
		/// <returns>A new 2x2 matrix.</returns>
		public static GLKMatrix2 GetMatrix2 (GLKMatrix4 matrix)
		{
			GLKMatrix2 m = new GLKMatrix2 (matrix [0], matrix [1],
				matrix [4], matrix [5]);
			return m;
		}

		/// <summary>
		/// <para>Returns the upper-left 3x3 section of a 4x4 matrix.</para>
		/// <para>Original signature is 'GLKMatrix3 GLKMatrix4GetMatrix3 ( GLKMatrix4 matrix );'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="matrix">MISSING</param>
		/// <returns>A new 3x3 matrix.</returns>
		public static GLKMatrix3 GetMatrix3 (GLKMatrix4 matrix)
		{
			GLKMatrix3 m = new GLKMatrix3 (matrix [0], matrix [1], matrix [2],
				matrix [4], matrix [5], matrix [6],
				matrix [8], matrix [9], matrix [10]);
			return m;
		}

		/// <summary>
		/// <para>Retrieves a row from a 4x4 matrix.</para>
		/// <para>Original signature is 'GLKVector4 GLKMatrix4GetRow ( GLKMatrix4 matrix, int row );'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="matrix">MISSING</param>
		/// <param name="row">MISSING</param>
		/// <returns>A vector representing the row retrieved from the matrix.</returns>
		public static GLKVector4 GetRow (GLKMatrix4 matrix, int row)
		{
			GLKVector4 v = new GLKVector4 (matrix [row], matrix [4 + row], matrix [8 + row], matrix [12 + row]);
			return v;
		}

		/// <summary>
		/// <para>Returns a 4x4 matrix created from individual component values.</para>
		/// <para>Original signature is 'GLKMatrix4 GLKMatrix4Make ( float m00, float m01, float m02, float m03, float m10, float m11, float m12, float m13, float m20, float m21, float m22, float m23, float m30, float m31, float m32, float m33 );'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="m00">MISSING</param>
		/// <param name="m01">MISSING</param>
		/// <param name="m02">MISSING</param>
		/// <param name="m03">MISSING</param>
		/// <param name="m10">MISSING</param>
		/// <param name="m11">MISSING</param>
		/// <param name="m12">MISSING</param>
		/// <param name="m13">MISSING</param>
		/// <param name="m20">MISSING</param>
		/// <param name="m21">MISSING</param>
		/// <param name="m22">MISSING</param>
		/// <param name="m23">MISSING</param>
		/// <param name="m30">MISSING</param>
		/// <param name="m31">MISSING</param>
		/// <param name="m32">MISSING</param>
		/// <param name="m33">MISSING</param>
		/// <returns>A new matrix.</returns>
		public static GLKMatrix4 Make (float m00, float m01, float m02, float m03, float m10, float m11, float m12, float m13, float m20, float m21, float m22, float m23, float m30, float m31, float m32, float m33)
		{
			GLKMatrix4 m = new GLKMatrix4 (m00, m01, m02, m03,
				m10, m11, m12, m13,
				m20, m21, m22, m23,
				m30, m31, m32, m33);
			return m;
		}

		/// <summary>
		/// <para>Returns a 4x4 transposed matrix created from individual component values.</para>
		/// <para>Original signature is 'GLKMatrix4 GLKMatrix4MakeAndTranspose ( float m00, float m01, float m02, float m03, float m10, float m11, float m12, float m13, float m20, float m21, float m22, float m23, float m30, float m31, float m32, float m33 );'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="m00">MISSING</param>
		/// <param name="m01">MISSING</param>
		/// <param name="m02">MISSING</param>
		/// <param name="m03">MISSING</param>
		/// <param name="m10">MISSING</param>
		/// <param name="m11">MISSING</param>
		/// <param name="m12">MISSING</param>
		/// <param name="m13">MISSING</param>
		/// <param name="m20">MISSING</param>
		/// <param name="m21">MISSING</param>
		/// <param name="m22">MISSING</param>
		/// <param name="m23">MISSING</param>
		/// <param name="m30">MISSING</param>
		/// <param name="m31">MISSING</param>
		/// <param name="m32">MISSING</param>
		/// <param name="m33">MISSING</param>
		/// <returns>A new matrix.</returns>
		public static GLKMatrix4 MakeAndTranspose (float m00, float m01, float m02, float m03, float m10, float m11, float m12, float m13, float m20, float m21, float m22, float m23, float m30, float m31, float m32, float m33)
		{
			GLKMatrix4 m = new GLKMatrix4 (m00, m10, m20, m30,
				m01, m11, m21, m31,
				m02, m12, m22, m32,
				m03, m13, m23, m33);
			return m;
		}

		/// <summary>
		/// <para>Returns a 4x4 perspective projection matrix.</para>
		/// <para>Original signature is 'GLKMatrix4 GLKMatrix4MakeFrustum ( float left, float right, float bottom, float top, float nearZ, float farZ );'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="left">MISSING</param>
		/// <param name="right">MISSING</param>
		/// <param name="bottom">MISSING</param>
		/// <param name="top">MISSING</param>
		/// <param name="nearZ">MISSING</param>
		/// <param name="farZ">MISSING</param>
		/// <returns>A projection matrix.</returns>
		public static GLKMatrix4 MakeFrustum (float left, float right, float bottom, float top, float nearZ, float farZ)
		{
			float ral = right + left;
			float rsl = right - left;
			float tsb = top - bottom;
			float tab = top + bottom;
			float fan = farZ + nearZ;
			float fsn = farZ - nearZ;
			
			GLKMatrix4 m = new GLKMatrix4 (2.0f * nearZ / rsl, 0.0f, 0.0f, 0.0f,
				0.0f, 2.0f * nearZ / tsb, 0.0f, 0.0f,
				ral / rsl, tab / tsb, -fan / fsn, -1.0f,
				0.0f, 0.0f, (-2.0f * farZ * nearZ) / fsn, 0.0f);
			
			return m;
		}

		/// <summary>
		/// <para>Returns a 4x4 matrix that transforms world coordinates to eye coordinates.</para>
		/// <para>Original signature is 'GLKMatrix4 GLKMatrix4MakeLookAt ( float eyeX, float eyeY, float eyeZ, float centerX, float centerY, float centerZ, float upX, float upY, float upZ );'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="eyeX">MISSING</param>
		/// <param name="eyeY">MISSING</param>
		/// <param name="eyeZ">MISSING</param>
		/// <param name="centerX">MISSING</param>
		/// <param name="centerY">MISSING</param>
		/// <param name="centerZ">MISSING</param>
		/// <param name="upX">MISSING</param>
		/// <param name="upY">MISSING</param>
		/// <param name="upZ">MISSING</param>
		/// <returns>A newly initialized view matrix.</returns>
		public static GLKMatrix4 MakeLookAt (float eyeX, float eyeY, float eyeZ, float centerX, float centerY, float centerZ, float upX, float upY, float upZ)
		{
			GLKVector3 ev = new GLKVector3 (eyeX, eyeY, eyeZ);
			GLKVector3 cv = new GLKVector3 (centerX, centerY, centerZ);
			GLKVector3 uv = new GLKVector3 (upX, upY, upZ);
			GLKVector3 n = GLKVector3.Normalize (GLKVector3.Add (ev, GLKVector3.Negate (cv)));
			GLKVector3 u = GLKVector3.Normalize (GLKVector3.CrossProduct (uv, n));
			GLKVector3 v = GLKVector3.CrossProduct (n, u);
			
			GLKMatrix4 m = new GLKMatrix4 (u.x, v.x, n.x, 0.0f,
				u.y, v.y, n.y, 0.0f,
				u.z, v.z, n.z, 0.0f,
				GLKVector3.DotProduct (GLKVector3.Negate (u), ev),
				GLKVector3.DotProduct (GLKVector3.Negate (v), ev),
				GLKVector3.DotProduct (GLKVector3.Negate (n), ev),
				1.0f);
			
			return m;
		}

		/// <summary>
		/// <para>Returns a 4x4 orthographic projection matrix.</para>
		/// <para>Original signature is 'GLKMatrix4 GLKMatrix4MakeOrtho ( float left, float right, float bottom, float top, float nearZ, float farZ );'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="left">MISSING</param>
		/// <param name="right">MISSING</param>
		/// <param name="bottom">MISSING</param>
		/// <param name="top">MISSING</param>
		/// <param name="nearZ">MISSING</param>
		/// <param name="farZ">MISSING</param>
		/// <returns>A new projection matrix.</returns>
		public static GLKMatrix4 MakeOrtho (float left, float right, float bottom, float top, float nearZ, float farZ)
		{
			float ral = right + left;
			float rsl = right - left;
			float tab = top + bottom;
			float tsb = top - bottom;
			float fan = farZ + nearZ;
			float fsn = farZ - nearZ;
			
			GLKMatrix4 m = new GLKMatrix4 (2.0f / rsl, 0.0f, 0.0f, 0.0f,
				0.0f, 2.0f / tsb, 0.0f, 0.0f,
				0.0f, 0.0f, -2.0f / fsn, 0.0f,
				-ral / rsl, -tab / tsb, -fan / fsn, 1.0f);
			
			return m;
		}

		/// <summary>
		/// <para>Returns a 4x4 perspective projection matrix.</para>
		/// <para>Original signature is 'GLKMatrix4 GLKMatrix4MakePerspective ( float fovyRadians, float aspect, float nearZ, float farZ );'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="fovyRadians">MISSING</param>
		/// <param name="aspect">MISSING</param>
		/// <param name="nearZ">MISSING</param>
		/// <param name="farZ">MISSING</param>
		/// <returns>A new projection matrix.</returns>
		public static GLKMatrix4 MakePerspective (float fovyRadians, float aspect, float nearZ, float farZ)
		{
			float cotan = 1.0f / (float)Math.Tan (fovyRadians / 2.0f);
			
			GLKMatrix4 m = new GLKMatrix4 (cotan / aspect, 0.0f, 0.0f, 0.0f,
				0.0f, cotan, 0.0f, 0.0f,
				0.0f, 0.0f, (farZ + nearZ) / (nearZ - farZ), -1.0f,
				0.0f, 0.0f, (2.0f * farZ * nearZ) / (nearZ - farZ), 0.0f);
			
			return m;
		}

		/// <summary>
		/// <para>Returns a 4x4 matrix that performs a rotation around an arbitrary vector.</para>
		/// <para>Original signature is 'GLKMatrix4 GLKMatrix4.MakeRotation ( float radians, float x, float y, float z );'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="radians">MISSING</param>
		/// <param name="x">MISSING</param>
		/// <param name="y">MISSING</param>
		/// <param name="z">MISSING</param>
		/// <returns>A new rotation matrix.</returns>
		public static GLKMatrix4 MakeRotation (float radians, float x, float y, float z)
		{
			GLKVector3 v = GLKVector3.Normalize (GLKVector3.Make (x, y, z));
			float cos = (float)Math.Cos (radians);
			float cosp = 1.0f - cos;
			float sin = (float)Math.Sin (radians);
			
			GLKMatrix4 m = new GLKMatrix4 (cos + cosp * v.x * v.x,
				cosp * v.x * v.y + v.z * sin,
				cosp * v.x * v.z - v.y * sin,
				0.0f,
				cosp * v.x * v.y - v.z * sin,
				cos + cosp * v.y * v.y,
				cosp * v.y * v.z + v.x * sin,
				0.0f,
				cosp * v.x * v.z + v.y * sin,
				cosp * v.y * v.z - v.x * sin,
				cos + cosp * v.z * v.z,
				0.0f,
				0.0f,
				0.0f,
				0.0f,
				1.0f);
			
			return m;
		}

		/// <summary>
		/// <para>Returns a 4x4 matrix that performs a scaling transformation.</para>
		/// <para>Original signature is 'GLKMatrix4 GLKMatrix4MakeScale ( float sx, float sy, float sz );'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="sx">MISSING</param>
		/// <param name="sy">MISSING</param>
		/// <param name="sz">MISSING</param>
		/// <returns>A new scaling matrix.</returns>
		public static GLKMatrix4 MakeScale (float sx, float sy, float sz)
		{
			GLKMatrix4 m = GLKMatrix4.Identity;
			m [0] = sx;
			m [5] = sy;
			m [10] = sz;
			return m;
		}

		/// <summary>
		/// <para>Returns a 4x4 matrix that performs a translation.</para>
		/// <para>Original signature is 'GLKMatrix4 GLKMatrix4MakeTranslation ( float tx, float ty, float tz );'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="tx">MISSING</param>
		/// <param name="ty">MISSING</param>
		/// <param name="tz">MISSING</param>
		/// <returns>A new translation matrix.</returns>
		public static GLKMatrix4 MakeTranslation (float tx, float ty, float tz)
		{
			GLKMatrix4 m = GLKMatrix4.Identity;
			m [12] = tx;
			m [13] = ty;
			m [14] = tz;
			return m;
		}

		/// <summary>
		/// <para>Returns a 4x4 matrix created from an array of component values.</para>
		/// <para>Original signature is 'GLKMatrix4 GLKMatrix4MakeWithArray ( float values[16] );'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="values">MISSING</param>
		/// <returns>A new matrix.</returns>
		public static GLKMatrix4 MakeWithArray (IntPtr values)
		{
			throw new NotImplementedException ();
		}

		/// <summary>
		/// <para>Returns a 4x4 transposed matrix created from an array of component values.</para>
		/// <para>Original signature is 'GLKMatrix4 GLKMatrix4MakeWithArrayAndTranspose ( float values[16] );'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="values">MISSING</param>
		/// <returns>A new matrix.</returns>
		public static GLKMatrix4 MakeWithArrayAndTranspose (IntPtr values)
		{
			throw new NotImplementedException ();
		}

		/// <summary>
		/// <para>Returns a 4x4 matrix created from four column vectors.</para>
		/// <para>Original signature is 'GLKMatrix4 GLKMatrix4MakeWithColumns ( GLKVector4 column0, GLKVector4 column1, GLKVector4 column2, GLKVector4 column3 );'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="column0">MISSING</param>
		/// <param name="column1">MISSING</param>
		/// <param name="column2">MISSING</param>
		/// <param name="column3">MISSING</param>
		/// <returns>A new matrix.</returns>
		public static GLKMatrix4 MakeWithColumns (GLKVector4 column0, GLKVector4 column1, GLKVector4 column2, GLKVector4 column3)
		{
			GLKMatrix4 m = new GLKMatrix4 (column0.x, column0.y, column0.z, column0.w,
				column1.x, column1.y, column1.z, column1.w,
				column2.x, column2.y, column2.z, column2.w,
				column3.x, column3.y, column3.z, column3.w);
			return m;
		}

		/// <summary>
		/// <para>Returns a 4x4 matrix that performs a rotation based on a quaternion.</para>
		/// <para>Original signature is 'GLKMatrix4 GLKMatrix4MakeWithQuaternion ( GLKQuaternion quaternion );'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="quaternion">MISSING</param>
		/// <returns>A new matrix that provides an equivalent rotation to that stored in the quaternion.</returns>
		public static GLKMatrix4 MakeWithQuaternion (GLKQuaternion quaternion)
		{
			quaternion = GLKQuaternion.Normalize (quaternion);
			
			float x = quaternion.x;
			float y = quaternion.y;
			float z = quaternion.z;
			float w = quaternion.w;
			
			float _2x = x + x;
			float _2y = y + y;
			float _2z = z + z;
			float _2w = w + w;
			
			GLKMatrix4 m = new GLKMatrix4 (1.0f - _2y * y - _2z * z,
				_2x * y + _2w * z,
				_2x * z - _2w * y,
				0.0f,
				_2x * y - _2w * z,
				1.0f - _2x * x - _2z * z,
				_2y * z + _2w * x,
				0.0f,
				_2x * z + _2w * y,
				_2y * z - _2w * x,
				1.0f - _2x * x - _2y * y,
				0.0f,
				0.0f,
				0.0f,
				0.0f,
				1.0f);
			
			return m;
		}

		/// <summary>
		/// <para>Returns a 4x4 matrix created from four row vectors.</para>
		/// <para>Original signature is 'GLKMatrix4 GLKMatrix4MakeWithRows ( GLKVector4 row0, GLKVector4 row1, GLKVector4 row2, GLKVector4 row3 );'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="row0">MISSING</param>
		/// <param name="row1">MISSING</param>
		/// <param name="row2">MISSING</param>
		/// <param name="row3">MISSING</param>
		/// <returns>A new matrix.</returns>
		public static GLKMatrix4 MakeWithRows (GLKVector4 row0, GLKVector4 row1, GLKVector4 row2, GLKVector4 row3)
		{
			GLKMatrix4 m = new GLKMatrix4 (row0.x, row1.x, row2.x, row3.x,
				row0.y, row1.y, row2.y, row3.y,
				row0.z, row1.z, row2.z, row3.z,
				row0.w, row1.w, row2.w, row3.w);
			return m;
		}

		/// <summary>
		/// <para>Returns a 4x4 matrix that performs a rotation around the positive x-axis.</para>
		/// <para>Original signature is 'GLKMatrix4 GLKMatrix4MakeXRotation ( float radians );'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="radians">MISSING</param>
		/// <returns>A new rotation matrix.</returns>
		public static GLKMatrix4 MakeXRotation (float radians)
		{
			float cos = (float)Math.Cos (radians);
			float sin = (float)Math.Sin (radians);
			
			GLKMatrix4 m = new GLKMatrix4 (1.0f, 0.0f, 0.0f, 0.0f,
				0.0f, cos, sin, 0.0f,
				0.0f, -sin, cos, 0.0f,
				0.0f, 0.0f, 0.0f, 1.0f);
			
			return m;
		}

		/// <summary>
		/// <para>Returns a 4x4 matrix that performs a rotation around the positive y-axis.</para>
		/// <para>Original signature is 'GLKMatrix4 GLKMatrix4MakeYRotation ( float radians );'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="radians">MISSING</param>
		/// <returns>A new rotation matrix.</returns>
		public static GLKMatrix4 MakeYRotation (float radians)
		{
			float cos = (float)Math.Cos (radians);
			float sin = (float)Math.Sin (radians);
			
			GLKMatrix4 m = new GLKMatrix4 (cos, 0.0f, -sin, 0.0f,
				0.0f, 1.0f, 0.0f, 0.0f,
				sin, 0.0f, cos, 0.0f,
				0.0f, 0.0f, 0.0f, 1.0f);
			
			return m;
		}

		/// <summary>
		/// <para>Returns a 4x4 matrix that performs a rotation around the positive z-axis.</para>
		/// <para>Original signature is 'GLKMatrix4 GLKMatrix4MakeZRotation ( float radians );'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="radians">MISSING</param>
		/// <returns>A new rotation matrix.</returns>
		public static GLKMatrix4 MakeZRotation (float radians)
		{
			float cos = (float)Math.Cos (radians);
			float sin = (float)Math.Sin (radians);
			
			GLKMatrix4 m = new GLKMatrix4 (cos, sin, 0.0f, 0.0f,
				-sin, cos, 0.0f, 0.0f,
				0.0f, 0.0f, 1.0f, 0.0f,
				0.0f, 0.0f, 0.0f, 1.0f);
			
			return m;
		}

		/// <summary>
		/// <para>Returns the product of two matrices.</para>
		/// <para>Original signature is 'GLKMatrix4 GLKMatrix4.Multiply ( GLKMatrix4 matrixLeft, GLKMatrix4 matrixRight );'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="matrixLeft">MISSING</param>
		/// <param name="matrixRight">MISSING</param>
		/// <returns>A new matrix created by multiplying the two matrices together.</returns>
		public static GLKMatrix4 Multiply (GLKMatrix4 matrixLeft, GLKMatrix4 matrixRight)
		{
			GLKMatrix4 m = new GLKMatrix4 ();
			
			m [0] = matrixLeft [0] * matrixRight [0] + matrixLeft [4] * matrixRight [1] + matrixLeft [8] * matrixRight [2] + matrixLeft [12] * matrixRight [3];
			m [4] = matrixLeft [0] * matrixRight [4] + matrixLeft [4] * matrixRight [5] + matrixLeft [8] * matrixRight [6] + matrixLeft [12] * matrixRight [7];
			m [8] = matrixLeft [0] * matrixRight [8] + matrixLeft [4] * matrixRight [9] + matrixLeft [8] * matrixRight [10] + matrixLeft [12] * matrixRight [11];
			m [12] = matrixLeft [0] * matrixRight [12] + matrixLeft [4] * matrixRight [13] + matrixLeft [8] * matrixRight [14] + matrixLeft [12] * matrixRight [15];
			
			m [1] = matrixLeft [1] * matrixRight [0] + matrixLeft [5] * matrixRight [1] + matrixLeft [9] * matrixRight [2] + matrixLeft [13] * matrixRight [3];
			m [5] = matrixLeft [1] * matrixRight [4] + matrixLeft [5] * matrixRight [5] + matrixLeft [9] * matrixRight [6] + matrixLeft [13] * matrixRight [7];
			m [9] = matrixLeft [1] * matrixRight [8] + matrixLeft [5] * matrixRight [9] + matrixLeft [9] * matrixRight [10] + matrixLeft [13] * matrixRight [11];
			m [13] = matrixLeft [1] * matrixRight [12] + matrixLeft [5] * matrixRight [13] + matrixLeft [9] * matrixRight [14] + matrixLeft [13] * matrixRight [15];
			
			m [2] = matrixLeft [2] * matrixRight [0] + matrixLeft [6] * matrixRight [1] + matrixLeft [10] * matrixRight [2] + matrixLeft [14] * matrixRight [3];
			m [6] = matrixLeft [2] * matrixRight [4] + matrixLeft [6] * matrixRight [5] + matrixLeft [10] * matrixRight [6] + matrixLeft [14] * matrixRight [7];
			m [10] = matrixLeft [2] * matrixRight [8] + matrixLeft [6] * matrixRight [9] + matrixLeft [10] * matrixRight [10] + matrixLeft [14] * matrixRight [11];
			m [14] = matrixLeft [2] * matrixRight [12] + matrixLeft [6] * matrixRight [13] + matrixLeft [10] * matrixRight [14] + matrixLeft [14] * matrixRight [15];
			
			m [3] = matrixLeft [3] * matrixRight [0] + matrixLeft [7] * matrixRight [1] + matrixLeft [11] * matrixRight [2] + matrixLeft [15] * matrixRight [3];
			m [7] = matrixLeft [3] * matrixRight [4] + matrixLeft [7] * matrixRight [5] + matrixLeft [11] * matrixRight [6] + matrixLeft [15] * matrixRight [7];
			m [11] = matrixLeft [3] * matrixRight [8] + matrixLeft [7] * matrixRight [9] + matrixLeft [11] * matrixRight [10] + matrixLeft [15] * matrixRight [11];
			m [15] = matrixLeft [3] * matrixRight [12] + matrixLeft [7] * matrixRight [13] + matrixLeft [11] * matrixRight [14] + matrixLeft [15] * matrixRight [15];
			
			return m;
		}

		/// <summary>
		/// <para>Multiplies a 4x4 matrix by a position vector to create a vector in homogenous coordinates, then projects the result to a 3-component vector.</para>
		/// <para>Original signature is 'GLKVector3 GLKMatrix4.MultiplyAndProjectVector3 ( GLKMatrix4 matrixLeft, GLKVector3 vectorRight );'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="matrixLeft">MISSING</param>
		/// <param name="vectorRight">MISSING</param>
		/// <returns>A new vector created by first multiplying the matrix by the vector and then performing perspective division on the result vector.</returns>
		public static GLKVector3 MultiplyAndProjectVector3 (GLKMatrix4 matrixLeft, GLKVector3 vectorRight)
		{
			GLKVector4 v4 = GLKMatrix4.MultiplyVector4 (matrixLeft, GLKVector4.Make (vectorRight.x, vectorRight.y, vectorRight.z, 1.0f));
			return GLKVector3.MultiplyScalar (GLKVector3.Make (v4.x, v4.y, v4.z), 1.0f / v4.w);
		}

		/// <summary>
		/// <para>Multiplies a 4x4 matrix by an array of 3-component vectors. Each result is projected back to 3-component vector.</para>
		/// <para>Original signature is 'void GLKMatrix4.MultiplyAndProjectVector3Array ( GLKMatrix4 matrix, GLKVector3 *vectors, size_t vectorCount );'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="matrix">MISSING</param>
		/// <param name="vectors">MISSING</param>
		/// <param name="vectorCount">MISSING</param>
		public static void MultiplyAndProjectVector3Array (GLKMatrix4 matrix, IntPtr vectors, NSUInteger vectorCount)
		{
			throw new NotImplementedException ();
		}

		/// <summary>
		/// <para>Multiplies a 4x4 matrix by a 3-component vector.</para>
		/// <para>Original signature is 'GLKVector3 GLKMatrix4.MultiplyVector3 ( GLKMatrix4 matrixLeft, GLKVector3 vectorRight );'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="matrixLeft">MISSING</param>
		/// <param name="vectorRight">MISSING</param>
		/// <returns>A new vector created by multiplying the matrix by the vector.</returns>
		public static GLKVector3 MultiplyVector3 (GLKMatrix4 matrixLeft, GLKVector3 vectorRight)
		{
			GLKVector4 v4 = GLKMatrix4.MultiplyVector4 (matrixLeft, GLKVector4.Make (vectorRight.x, vectorRight.y, vectorRight.z, 0.0f));
			return GLKVector3.Make (v4.x, v4.y, v4.z);
		}

		/// <summary>
		/// <para>Multiplies a 4x4 matrix by an array of 3-component vectors.</para>
		/// <para>Original signature is 'void GLKMatrix4.MultiplyVector3Array ( GLKMatrix4 matrix, GLKVector3 *vectors, size_t vectorCount );'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="matrix">MISSING</param>
		/// <param name="vectors">MISSING</param>
		/// <param name="vectorCount">MISSING</param>
		public static void MultiplyVector3Array (GLKMatrix4 matrix, IntPtr vectors, NSUInteger vectorCount)
		{
			throw new NotImplementedException ();
		}

		/// <summary>
		/// <para>Multiplies a 4x4 matrix by an array of 3-component vectors, applying translation.</para>
		/// <para>Original signature is 'void GLKMatrix4.MultiplyVector3ArrayWithTranslation ( GLKMatrix4 matrix, GLKVector3 *vectors, size_t vectorCount );'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="matrix">MISSING</param>
		/// <param name="vectors">MISSING</param>
		/// <param name="vectorCount">MISSING</param>
		public static void MultiplyVector3ArrayWithTranslation (GLKMatrix4 matrix, IntPtr vectors, NSUInteger vectorCount)
		{
			throw new NotImplementedException ();
		}

		/// <summary>
		/// <para>Multiplies a 4x4 matrix by a 3-component vector, applying translation.</para>
		/// <para>Original signature is 'GLKVector3 GLKMatrix4.MultiplyVector3WithTranslation ( GLKMatrix4 matrixLeft, GLKVector3 vectorRight );'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="matrixLeft">MISSING</param>
		/// <param name="vectorRight">MISSING</param>
		/// <returns>A new vector created by multiplying the matrix by the vector.</returns>
		public static GLKVector3 MultiplyVector3WithTranslation (GLKMatrix4 matrixLeft, GLKVector3 vectorRight)
		{
			GLKVector4 v4 = GLKMatrix4.MultiplyVector4 (matrixLeft, GLKVector4.Make (vectorRight.x, vectorRight.y, vectorRight.z, 1.0f));
			return GLKVector3.Make (v4.x, v4.y, v4.z);
		}

		/// <summary>
		/// <para>Multiplies a 4x4 matrix by a 4-component vector.</para>
		/// <para>Original signature is 'GLKVector4 GLKMatrix4.MultiplyVector4 ( GLKMatrix4 matrixLeft, GLKVector4 vectorRight );'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="matrixLeft">MISSING</param>
		/// <param name="vectorRight">MISSING</param>
		/// <returns>A new vector created by multiplying the matrix by the vector.</returns>
		public static GLKVector4 MultiplyVector4 (GLKMatrix4 matrixLeft, GLKVector4 vectorRight)
		{
			GLKVector4 v = new GLKVector4 (matrixLeft [0] * vectorRight.x + matrixLeft [4] * vectorRight.y + matrixLeft [8] * vectorRight.z + matrixLeft [12] * vectorRight.w,
				matrixLeft [1] * vectorRight.x + matrixLeft [5] * vectorRight.y + matrixLeft [9] * vectorRight.z + matrixLeft [13] * vectorRight.w,
				matrixLeft [2] * vectorRight.x + matrixLeft [6] * vectorRight.y + matrixLeft [10] * vectorRight.z + matrixLeft [14] * vectorRight.w,
				matrixLeft [3] * vectorRight.x + matrixLeft [7] * vectorRight.y + matrixLeft [11] * vectorRight.z + matrixLeft [15] * vectorRight.w);
			return v;
		}

		/// <summary>
		/// <para>Multiplies a 4x4 matrix by an array of 4-component vectors.</para>
		/// <para>Original signature is 'void GLKMatrix4.MultiplyVector4Array ( GLKMatrix4 matrix, GLKVector4 *vectors, size_t vectorCount );'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="matrix">MISSING</param>
		/// <param name="vectors">MISSING</param>
		/// <param name="vectorCount">MISSING</param>
		public static void MultiplyVector4Array (GLKMatrix4 matrix, IntPtr vectors, NSUInteger vectorCount)
		{
			throw new NotImplementedException ();
		}

		/// <summary>
		/// <para>Returns a new 4x4 matrix created by concatenating a matrix with a rotation around a vector.</para>
		/// <para>Original signature is 'GLKMatrix4 GLKMatrix4Rotate ( GLKMatrix4 matrix, float radians, float x, float y, float z );'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="matrix">MISSING</param>
		/// <param name="radians">MISSING</param>
		/// <param name="x">MISSING</param>
		/// <param name="y">MISSING</param>
		/// <param name="z">MISSING</param>
		/// <returns>A new matrix.</returns>
		public static GLKMatrix4 Rotate (GLKMatrix4 matrix, float radians, float x, float y, float z)
		{
			GLKMatrix4 rm = GLKMatrix4.MakeRotation (radians, x, y, z);
			return GLKMatrix4.Multiply (matrix, rm);
		}

		/// <summary>
		/// <para>Returns a new 4x4 matrix created by concatenating a matrix with a rotation around a vector.</para>
		/// <para>Original signature is 'GLKMatrix4 GLKMatrix4RotateWithVector3 ( GLKMatrix4 matrix, float radians, GLKVector3 axisVector );'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="matrix">MISSING</param>
		/// <param name="radians">MISSING</param>
		/// <param name="axisVector">MISSING</param>
		/// <returns>A new matrix.</returns>
		public static GLKMatrix4 RotateWithVector3 (GLKMatrix4 matrix, float radians, GLKVector3 axisVector)
		{
			GLKMatrix4 rm = GLKMatrix4.MakeRotation (radians, axisVector.x, axisVector.y, axisVector.z);
			return GLKMatrix4.Multiply (matrix, rm);
		}

		/// <summary>
		/// <para>Returns a new 4x4 matrix created by concatenating a matrix with a rotation around a vector.</para>
		/// <para>Original signature is 'GLKMatrix4 GLKMatrix4RotateWithVector4 ( GLKMatrix4 matrix, float radians, GLKVector4 axisVector );'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="matrix">MISSING</param>
		/// <param name="radians">MISSING</param>
		/// <param name="axisVector">MISSING</param>
		/// <returns>A new matrix.</returns>
		public static GLKMatrix4 RotateWithVector4 (GLKMatrix4 matrix, float radians, GLKVector4 axisVector)
		{
			GLKMatrix4 rm = GLKMatrix4.MakeRotation (radians, axisVector.x, axisVector.y, axisVector.z);
			return GLKMatrix4.Multiply (matrix, rm);    
		}

		/// <summary>
		/// <para>Returns a new 4x4 matrix created by concatenating a matrix with a rotation around the x-axis.</para>
		/// <para>Original signature is 'GLKMatrix4 GLKMatrix4RotateX ( GLKMatrix4 matrix, float radians );'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="matrix">MISSING</param>
		/// <param name="radians">MISSING</param>
		/// <returns>A new matrix.</returns>
		public static GLKMatrix4 RotateX (GLKMatrix4 matrix, float radians)
		{
			GLKMatrix4 rm = GLKMatrix4.MakeXRotation (radians);
			return GLKMatrix4.Multiply (matrix, rm);
		}

		/// <summary>
		/// <para>Returns a new 4x4 matrix created by concatenating a matrix with a rotation around the y-axis.</para>
		/// <para>Original signature is 'GLKMatrix4 GLKMatrix4RotateY ( GLKMatrix4 matrix, float radians );'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="matrix">MISSING</param>
		/// <param name="radians">MISSING</param>
		/// <returns>A new matrix.</returns>
		public static GLKMatrix4 RotateY (GLKMatrix4 matrix, float radians)
		{
			GLKMatrix4 rm = GLKMatrix4.MakeYRotation (radians);
			return GLKMatrix4.Multiply (matrix, rm);
		}

		/// <summary>
		/// <para>Returns a new 4x4 matrix created by concatenating a matrix with a rotation around the z-axis.</para>
		/// <para>Original signature is 'GLKMatrix4 GLKMatrix4RotateZ ( GLKMatrix4 matrix, float radians );'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="matrix">MISSING</param>
		/// <param name="radians">MISSING</param>
		/// <returns>A new matrix.</returns>
		public static GLKMatrix4 RotateZ (GLKMatrix4 matrix, float radians)
		{
			GLKMatrix4 rm = GLKMatrix4.MakeZRotation (radians);
			return GLKMatrix4.Multiply (matrix, rm);
		}

		/// <summary>
		/// <para>Returns a new 4x4 matrix created by concatenating a matrix with a scaling transform.</para>
		/// <para>Original signature is 'GLKMatrix4 GLKMatrix4Scale ( GLKMatrix4 matrix, float sx, float sy, float sz );'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="matrix">MISSING</param>
		/// <param name="sx">MISSING</param>
		/// <param name="sy">MISSING</param>
		/// <param name="sz">MISSING</param>
		/// <returns>A new matrix.</returns>
		public static GLKMatrix4 Scale (GLKMatrix4 matrix, float sx, float sy, float sz)
		{
			GLKMatrix4 m = new GLKMatrix4 (matrix [0] * sx, matrix [1] * sx, matrix [2] * sx, matrix [3] * sx,
				matrix [4] * sy, matrix [5] * sy, matrix [6] * sy, matrix [7] * sy,
				matrix [8] * sz, matrix [9] * sz, matrix [10] * sz, matrix [11] * sz,
				matrix [12], matrix [13], matrix [14], matrix [15]);
			return m;
		}

		/// <summary>
		/// <para>Returns a new 4x4 matrix created by concatenating a matrix with a scaling transform defined by a vector.</para>
		/// <para>Original signature is 'GLKMatrix4 GLKMatrix4ScaleWithVector3 ( GLKMatrix4 matrix, GLKVector3 scaleVector );'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="matrix">MISSING</param>
		/// <param name="scaleVector">MISSING</param>
		/// <returns>A new matrix.</returns>
		public static GLKMatrix4 ScaleWithVector3 (GLKMatrix4 matrix, GLKVector3 scaleVector)
		{
			GLKMatrix4 m = new GLKMatrix4 (matrix [0] * scaleVector.x, matrix [1] * scaleVector.x, matrix [2] * scaleVector.x, matrix [3] * scaleVector.x,
				matrix [4] * scaleVector.y, matrix [5] * scaleVector.y, matrix [6] * scaleVector.y, matrix [7] * scaleVector.y,
				matrix [8] * scaleVector.z, matrix [9] * scaleVector.z, matrix [10] * scaleVector.z, matrix [11] * scaleVector.z,
				matrix [12], matrix [13], matrix [14], matrix [15]);
			return m;
		}

		/// <summary>
		/// <para>Returns a new 4x4 matrix created by concatenating a matrix with a scaling transform defined by a vector.</para>
		/// <para>Original signature is 'GLKMatrix4 GLKMatrix4ScaleWithVector4 ( GLKMatrix4 matrix, GLKVector4 scaleVector );'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="matrix">MISSING</param>
		/// <param name="scaleVector">MISSING</param>
		/// <returns>A new matrix.</returns>
		public static GLKMatrix4 ScaleWithVector4 (GLKMatrix4 matrix, GLKVector4 scaleVector)
		{
			GLKMatrix4 m = new GLKMatrix4 (matrix [0] * scaleVector.x, matrix [1] * scaleVector.x, matrix [2] * scaleVector.x, matrix [3] * scaleVector.x,
				matrix [4] * scaleVector.y, matrix [5] * scaleVector.y, matrix [6] * scaleVector.y, matrix [7] * scaleVector.y,
				matrix [8] * scaleVector.z, matrix [9] * scaleVector.z, matrix [10] * scaleVector.z, matrix [11] * scaleVector.z,
				matrix [12], matrix [13], matrix [14], matrix [15]);
			return m;
		}

		/// <summary>
		/// <para>Returns a new 4x4 matrix with one column replaced by a new vector.</para>
		/// <para>Original signature is 'GLKMatrix4 GLKMatrix4SetColumn ( GLKMatrix4 matrix, int column, GLKVector4 vector );'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="matrix">MISSING</param>
		/// <param name="column">MISSING</param>
		/// <param name="vector">MISSING</param>
		/// <returns>A new matrix.</returns>
		public static GLKMatrix4 SetColumn (GLKMatrix4 matrix, int column, GLKVector4 vector)
		{
			matrix [column * 4 + 0] = vector.x;
			matrix [column * 4 + 1] = vector.y;
			matrix [column * 4 + 2] = vector.z;
			matrix [column * 4 + 3] = vector.w;
			
			return matrix;
		}

		/// <summary>
		/// <para>Returns a new 4x4 matrix with one row replaced by a new vector.</para>
		/// <para>Original signature is 'GLKMatrix4 GLKMatrix4SetRow ( GLKMatrix4 matrix, int row, GLKVector4 vector );'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="matrix">MISSING</param>
		/// <param name="row">MISSING</param>
		/// <param name="vector">MISSING</param>
		/// <returns>A new matrix.</returns>
		public static GLKMatrix4 SetRow (GLKMatrix4 matrix, int row, GLKVector4 vector)
		{
			matrix [row] = vector.x;
			matrix [row + 4] = vector.y;
			matrix [row + 8] = vector.z;
			matrix [row + 12] = vector.w;
			
			return matrix;
		}

		/// <summary>
		/// <para>Returns a new 4x4 matrix created by concatenating a matrix with a translation transform.</para>
		/// <para>Original signature is 'GLKMatrix4 GLKMatrix4Translate ( GLKMatrix4 matrix, float tx, float ty, float tz );'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="matrix">MISSING</param>
		/// <param name="tx">MISSING</param>
		/// <param name="ty">MISSING</param>
		/// <param name="tz">MISSING</param>
		/// <returns>A new matrix.</returns>
		public static GLKMatrix4 Translate (GLKMatrix4 matrix, float tx, float ty, float tz)
		{
			GLKMatrix4 m = new GLKMatrix4 (matrix [0], matrix [1], matrix [2], matrix [3],
				matrix [4], matrix [5], matrix [6], matrix [7],
				matrix [8], matrix [9], matrix [10], matrix [11],
				matrix [0] * tx + matrix [4] * ty + matrix [8] * tz + matrix [12],
				matrix [1] * tx + matrix [5] * ty + matrix [9] * tz + matrix [13],
				matrix [2] * tx + matrix [6] * ty + matrix [10] * tz + matrix [14],
				matrix [15]);
			return m;
		}

		/// <summary>
		/// <para>Returns a new 4x4 matrix created by concatenating a matrix with a translation transform defined by a vector.</para>
		/// <para>Original signature is 'GLKMatrix4 GLKMatrix4TranslateWithVector3 ( GLKMatrix4 matrix, GLKVector3 translationVector );'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="matrix">MISSING</param>
		/// <param name="translationVector">MISSING</param>
		/// <returns>A new matrix.</returns>
		public static GLKMatrix4 TranslateWithVector3 (GLKMatrix4 matrix, GLKVector3 translationVector)
		{
			GLKMatrix4 m = new GLKMatrix4 (matrix [0], matrix [1], matrix [2], matrix [3],
				matrix [4], matrix [5], matrix [6], matrix [7],
				matrix [8], matrix [9], matrix [10], matrix [11],
				matrix [0] * translationVector.x + matrix [4] * translationVector.y + matrix [8] * translationVector.z + matrix [12],
				matrix [1] * translationVector.x + matrix [5] * translationVector.y + matrix [9] * translationVector.z + matrix [13],
				matrix [2] * translationVector.x + matrix [6] * translationVector.y + matrix [10] * translationVector.z + matrix [14],
				matrix [15]);
			return m;
		}

		/// <summary>
		/// <para>Returns a new 4x4 matrix created by concatenating a matrix with a translation transform defined by a vector.</para>
		/// <para>Original signature is 'GLKMatrix4 GLKMatrix4TranslateWithVector4 ( GLKMatrix4 matrix, GLKVector4 translationVector );'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="matrix">MISSING</param>
		/// <param name="translationVector">MISSING</param>
		/// <returns>A new matrix.</returns>
		public static GLKMatrix4 TranslateWithVector4 (GLKMatrix4 matrix, GLKVector4 translationVector)
		{
			GLKMatrix4 m = new GLKMatrix4 (matrix [0], matrix [1], matrix [2], matrix [3],
				matrix [4], matrix [5], matrix [6], matrix [7],
				matrix [8], matrix [9], matrix [10], matrix [11],
				matrix [0] * translationVector.x + matrix [4] * translationVector.y + matrix [8] * translationVector.z + matrix [12],
				matrix [1] * translationVector.x + matrix [5] * translationVector.y + matrix [9] * translationVector.z + matrix [13],
				matrix [2] * translationVector.x + matrix [6] * translationVector.y + matrix [10] * translationVector.z + matrix [14],
				matrix [15]);
			return m;
		}

		/// <summary>
		/// <para>Returns the transpose of a matrix.</para>
		/// <para>Original signature is 'GLKMatrix4 GLKMatrix4Transpose ( GLKMatrix4 matrix );'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="matrix">MISSING</param>
		/// <returns>A new matrix that is the transpose of the original matrix.</returns>
		public static GLKMatrix4 Transpose (GLKMatrix4 matrix)
		{
			GLKMatrix4 m = new GLKMatrix4 (matrix [0], matrix [4], matrix [8], matrix [12],
				matrix [1], matrix [5], matrix [9], matrix [13],
				matrix [2], matrix [6], matrix [10], matrix [14],
				matrix [3], matrix [7], matrix [11], matrix [15]);
			return m;
		}
	}
#endif
}
