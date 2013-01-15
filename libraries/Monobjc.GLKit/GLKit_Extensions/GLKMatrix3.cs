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
	public partial struct GLKMatrix3
	{
		/// <summary>
		/// A 3x3 identity matrix.
		/// </summary>
		public static readonly GLKMatrix3 Identity = new GLKMatrix3 (1, 0, 0, 0, 1, 0, 0, 0, 1);

		/// <summary>
		/// <para>Returns a new 3x3 matrix created by performing a component-wise addition of two matrices.</para>
		/// <para>Original signature is 'GLKMatrix3 GLKMatrix3Add ( GLKMatrix3 matrixLeft, GLKMatrix3 matrixRight );'</para>
		/// <para>Available in OS X x0.8 and later.</para>
		/// </summary>
		/// <param name="matrixLeft">MISSING</param>
		/// <param name="matrixRight">MISSING</param>
		/// <returns>A new matrix whose components each represent the sum of the components found in the same positions of the two source matrices.</returns>
		public static GLKMatrix3 Add (GLKMatrix3 matrixLeft, GLKMatrix3 matrixRight)
		{
			GLKMatrix3 m = new GLKMatrix3 ();
			
			m [0] = matrixLeft [0] + matrixRight [0];
			m [1] = matrixLeft [1] + matrixRight [1];
			m [2] = matrixLeft [2] + matrixRight [2];
			
			m [3] = matrixLeft [3] + matrixRight [3];
			m [4] = matrixLeft [4] + matrixRight [4];
			m [5] = matrixLeft [5] + matrixRight [5];
			
			m [6] = matrixLeft [6] + matrixRight [6];
			m [7] = matrixLeft [7] + matrixRight [7];
			m [8] = matrixLeft [8] + matrixRight [8];
			
			return m;
		}

		/// <summary>
		/// <para>Retrieves a column from a 3x3 matrix.</para>
		/// <para>Original signature is 'GLKVector3 GLKMatrix3GetColumn ( GLKMatrix3 matrix, int column );'</para>
		/// <para>Available in OS X x0.8 and later.</para>
		/// </summary>
		/// <param name="matrix">MISSING</param>
		/// <param name="column">MISSING</param>
		/// <returns>A vector representing the column retrieved from the matrix.</returns>
		public static GLKVector3 GetColumn (GLKMatrix3 matrix, int column)
		{
			GLKVector3 v = new GLKVector3 (
				 matrix [column * 3 + 0],
				 matrix [column * 3 + 1],
				 matrix [column * 3 + 2]
			);
			return v;
		}


		/// <summary>
		/// <para>Returns the upper-left 2x2 section of a 3x3 matrix.</para>
		/// <para>Original signature is 'GLKMatrix2 GLKMatrix3GetMatrix2 ( GLKMatrix3 matrix );'</para>
		/// <para>Available in OS X x0.8 and later.</para>
		/// </summary>
		/// <param name="matrix">MISSING</param>
		/// <returns>A new 2x2 matrix.</returns>
		public static GLKMatrix2 GetMatrix2 (GLKMatrix3 matrix)
		{
			GLKMatrix2 m = new GLKMatrix2 (matrix [0], matrix [1], matrix [3], matrix [4]);
			return m;
		}

		/// <summary>
		/// <para>Retrieves a row from a 3x3 matrix.</para>
		/// <para>Original signature is 'GLKVector3 GLKMatrix3GetRow ( GLKMatrix3 matrix, int row );'</para>
		/// <para>Available in OS X x0.8 and later.</para>
		/// </summary>
		/// <param name="matrix">MISSING</param>
		/// <param name="row">MISSING</param>
		/// <returns>A vector representing the row retrieved from the matrix.</returns>
		public static GLKVector3 GetRow (GLKMatrix3 matrix, int row)
		{
			GLKVector3 v = new GLKVector3 (matrix [row], matrix [3 + row], matrix [6 + row]);
			return v;
		}

		/// <summary>
		/// <para>Returns a 3x3 matrix created from individual component values.</para>
		/// <para>Original signature is 'GLKMatrix3 GLKMatrix3Make ( float m00, float m01, float m02, float m10, float m11, float m12, float m20, float m21, float m22 );'</para>
		/// <para>Available in OS X x0.8 and later.</para>
		/// </summary>
		/// <param name="m00">MISSING</param>
		/// <param name="m01">MISSING</param>
		/// <param name="m02">MISSING</param>
		/// <param name="m10">MISSING</param>
		/// <param name="m11">MISSING</param>
		/// <param name="m12">MISSING</param>
		/// <param name="m20">MISSING</param>
		/// <param name="m21">MISSING</param>
		/// <param name="m22">MISSING</param>
		/// <returns>A new matrix.</returns>
		public static GLKMatrix3 Make (float m00, float m01, float m02, float m10, float m11, float m12, float m20, float m21, float m22)
		{
			GLKMatrix3 m = new GLKMatrix3 (m00, m01, m02, m10, m11, m12, m20, m21, m22);
			return m;
		}

		/// <summary>
		/// <para>Returns a 3x3 transposed matrix created from individual component values.</para>
		/// <para>Original signature is 'GLKMatrix3 GLKMatrix3MakeAndTranspose ( float m00, float m01, float m02, float m10, float m11, float m12, float m20, float m21, float m22 );'</para>
		/// <para>Available in OS X x0.8 and later.</para>
		/// </summary>
		/// <param name="m00">MISSING</param>
		/// <param name="m01">MISSING</param>
		/// <param name="m02">MISSING</param>
		/// <param name="m10">MISSING</param>
		/// <param name="m11">MISSING</param>
		/// <param name="m12">MISSING</param>
		/// <param name="m20">MISSING</param>
		/// <param name="m21">MISSING</param>
		/// <param name="m22">MISSING</param>
		/// <returns>A new matrix.</returns>
		public static GLKMatrix3 MakeAndTranspose (float m00, float m01, float m02, float m10, float m11, float m12, float m20, float m21, float m22)
		{
			GLKMatrix3 m = new GLKMatrix3 (m00, m10, m20, m01, m11, m21, m02, m12, m22);
			return m;

		}

		/// <summary>
		/// <para>Returns a 3x3 matrix that performs a rotation around an arbitrary vector.</para>
		/// <para>Original signature is 'GLKMatrix3 GLKMatrix3MakeRotation ( float radians, float x, float y, float z );'</para>
		/// <para>Available in OS X x0.8 and later.</para>
		/// </summary>
		/// <param name="radians">MISSING</param>
		/// <param name="x">MISSING</param>
		/// <param name="y">MISSING</param>
		/// <param name="z">MISSING</param>
		/// <returns>A new rotation matrix.</returns>
		public static GLKMatrix3 MakeRotation (float radians, float x, float y, float z)
		{
			GLKVector3 v = GLKVector3.Normalize (GLKVector3.Make (x, y, z));
			float cos = (float)Math.Cos (radians);
			float cosp = 1.0f - cos;
			float sin = (float)Math.Sin (radians);
    
			GLKMatrix3 m = new GLKMatrix3 (cos + cosp * v.x * v.x,
                     cosp * v.x * v.y + v.z * sin,
                     cosp * v.x * v.z - v.y * sin,

                     cosp * v.x * v.y - v.z * sin,
                     cos + cosp * v.y * v.y,
                     cosp * v.y * v.z + v.x * sin,

                     cosp * v.x * v.z + v.y * sin,
                     cosp * v.y * v.z - v.x * sin,
                     cos + cosp * v.z * v.z);
    
			return m;
		}

		/// <summary>
		/// <para>Returns a 3x3 matrix that performs a scaling transformation.</para>
		/// <para>Original signature is 'GLKMatrix3 GLKMatrix3MakeScale ( float sx, float sy, float sz );'</para>
		/// <para>Available in OS X x0.8 and later.</para>
		/// </summary>
		/// <param name="sx">MISSING</param>
		/// <param name="sy">MISSING</param>
		/// <param name="sz">MISSING</param>
		/// <returns>A new scaling matrix.</returns>
		public static GLKMatrix3 MakeScale (float sx, float sy, float sz)
		{
			GLKMatrix3 m = Identity;
			m [0] = sx;
			m [4] = sy;
			m [8] = sz;
			return m;
		}

		/// <summary>
		/// <para>Returns a 3x3 matrix created from an array of component values.</para>
		/// <para>Original signature is 'GLKMatrix3 GLKMatrix3MakeWithArray ( float values[9] );'</para>
		/// <para>Available in OS X x0.8 and later.</para>
		/// </summary>
		/// <param name="values">MISSING</param>
		/// <returns>A new matrix.</returns>
		public static GLKMatrix3 MakeWithArray (IntPtr values)
		{
			throw new NotImplementedException ();
		}

		/// <summary>
		/// <para>Returns a 3x3 transposed matrix created from an array of component values.</para>
		/// <para>Original signature is 'GLKMatrix3 GLKMatrix3MakeWithArrayAndTranspose ( float values[9] );'</para>
		/// <para>Available in OS X x0.8 and later.</para>
		/// </summary>
		/// <param name="values">MISSING</param>
		/// <returns>A new matrix.</returns>
		public static GLKMatrix3 MakeWithArrayAndTranspose (IntPtr values)
		{
			throw new NotImplementedException ();
		}

		/// <summary>
		/// <para>Returns a 3x3 matrix created from three column vectors.</para>
		/// <para>Original signature is 'GLKMatrix3 GLKMatrix3MakeWithColumns ( GLKVector3 column0, GLKVector3 column1, GLKVector3 column2 );'</para>
		/// <para>Available in OS X x0.8 and later.</para>
		/// </summary>
		/// <param name="column0">MISSING</param>
		/// <param name="column1">MISSING</param>
		/// <param name="column2">MISSING</param>
		/// <returns>A new matrix.</returns>
		public static GLKMatrix3 MakeWithColumns (GLKVector3 column0, GLKVector3 column1, GLKVector3 column2)
		{
			GLKMatrix3 m = new GLKMatrix3 (column0.x, column0.y, column0.z,
                     column1.x, column1.y, column1.z,
                     column2.x, column2.y, column2.z);
			return m;

		}

		/// <summary>
		/// <para>Returns a 3x3 matrix that performs a rotation based on a quaternion.</para>
		/// <para>Original signature is 'GLKMatrix3 GLKMatrix3MakeWithQuaternion ( GLKQuaternion quaternion );'</para>
		/// <para>Available in OS X x0.8 and later.</para>
		/// </summary>
		/// <param name="quaternion">MISSING</param>
		/// <returns>A new matrix that provides an equivalent rotation to that stored in the quaternion.</returns>
		public static GLKMatrix3 MakeWithQuaternion (GLKQuaternion quaternion)
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
    
			GLKMatrix3 m = new GLKMatrix3 (1.0f - _2y * y - _2z * z,
                    _2x * y + _2w * z,
                    _2x * z - _2w * y,

                    _2x * y - _2w * z,
                    1.0f - _2x * x - _2z * z,
                    _2y * z + _2w * x,

                    _2x * z + _2w * y,
                    _2y * z - _2w * x,
                    1.0f - _2x * x - _2y * y);
    
			return m;
		}

		/// <summary>
		/// <para>Returns a 3x3 matrix created from three row vectors.</para>
		/// <para>Original signature is 'GLKMatrix3 GLKMatrix3MakeWithRows ( GLKVector3 row0, GLKVector3 row1, GLKVector3 row2 );'</para>
		/// <para>Available in OS X x0.8 and later.</para>
		/// </summary>
		/// <param name="row0">MISSING</param>
		/// <param name="row1">MISSING</param>
		/// <param name="row2">MISSING</param>
		/// <returns>A new matrix.</returns>
		public static GLKMatrix3 MakeWithRows (GLKVector3 row0, GLKVector3 row1, GLKVector3 row2)
		{
			GLKMatrix3 m = new GLKMatrix3 (row0.x, row1.x, row2.x,
                     row0.y, row1.y, row2.y,
                     row0.z, row1.z, row2.z);
			return m;

		}

		/// <summary>
		/// <para>Returns a 3x3 matrix that performs a rotation around the positive x-axis.</para>
		/// <para>Original signature is 'GLKMatrix3 GLKMatrix3MakeXRotation ( float radians );'</para>
		/// <para>Available in OS X x0.8 and later.</para>
		/// </summary>
		/// <param name="radians">MISSING</param>
		/// <returns>A new rotation matrix.</returns>
		public static GLKMatrix3 MakeXRotation (float radians)
		{
			float cos = (float)Math.Cos (radians);
			float sin = (float)Math.Sin (radians);
    
			GLKMatrix3 m = new GLKMatrix3 (1.0f, 0.0f, 0.0f, 0.0f, cos, sin, 0.0f, -sin, cos);
			return m;

		}

		/// <summary>
		/// <para>Returns a 3x3 matrix that performs a rotation around the positive y-axis.</para>
		/// <para>Original signature is 'GLKMatrix3 GLKMatrix3MakeYRotation ( float radians );'</para>
		/// <para>Available in OS X x0.8 and later.</para>
		/// </summary>
		/// <param name="radians">MISSING</param>
		/// <returns>A new rotation matrix.</returns>
		public static GLKMatrix3 MakeYRotation (float radians)
		{
			float cos = (float)Math.Cos (radians);
			float sin = (float)Math.Sin (radians);
    
			GLKMatrix3 m = new GLKMatrix3 (cos, 0.0f, -sin, 0.0f, 1.0f, 0.0f, sin, 0.0f, cos);
			return m;
		}

		/// <summary>
		/// <para>Returns a 3x3 matrix that performs a rotation around the positive z-axis.</para>
		/// <para>Original signature is 'GLKMatrix3 GLKMatrix3MakeZRotation ( float radians );'</para>
		/// <para>Available in OS X x0.8 and later.</para>
		/// </summary>
		/// <param name="radians">MISSING</param>
		/// <returns>A new rotation matrix.</returns>
		public static GLKMatrix3 MakeZRotation (float radians)
		{
			float cos = (float)Math.Cos (radians);
			float sin = (float)Math.Sin (radians);
    
			GLKMatrix3 m = new GLKMatrix3 (cos, sin, 0.0f, -sin, cos, 0.0f, 0.0f, 0.0f, 1.0f);
			return m;
		}

		/// <summary>
		/// <para>Returns the product of two matrices.</para>
		/// <para>Original signature is 'GLKMatrix3 GLKMatrix3Multiply ( GLKMatrix3 matrixLeft, GLKMatrix3 matrixRight );'</para>
		/// <para>Available in OS X x0.8 and later.</para>
		/// </summary>
		/// <param name="matrixLeft">MISSING</param>
		/// <param name="matrixRight">MISSING</param>
		/// <returns>A new matrix.</returns>
		public static GLKMatrix3 Multiply (GLKMatrix3 matrixLeft, GLKMatrix3 matrixRight)
		{
			GLKMatrix3 m = new GLKMatrix3 ();
    
			m [0] = matrixLeft [0] * matrixRight [0] + matrixLeft [3] * matrixRight [1] + matrixLeft [6] * matrixRight [2];
			m [3] = matrixLeft [0] * matrixRight [3] + matrixLeft [3] * matrixRight [4] + matrixLeft [6] * matrixRight [5];
			m [6] = matrixLeft [0] * matrixRight [6] + matrixLeft [3] * matrixRight [7] + matrixLeft [6] * matrixRight [8];
    
			m [1] = matrixLeft [1] * matrixRight [0] + matrixLeft [4] * matrixRight [1] + matrixLeft [7] * matrixRight [2];
			m [4] = matrixLeft [1] * matrixRight [3] + matrixLeft [4] * matrixRight [4] + matrixLeft [7] * matrixRight [5];
			m [7] = matrixLeft [1] * matrixRight [6] + matrixLeft [4] * matrixRight [7] + matrixLeft [7] * matrixRight [8];
    
			m [2] = matrixLeft [2] * matrixRight [0] + matrixLeft [5] * matrixRight [1] + matrixLeft [8] * matrixRight [2];
			m [5] = matrixLeft [2] * matrixRight [3] + matrixLeft [5] * matrixRight [4] + matrixLeft [8] * matrixRight [5];
			m [8] = matrixLeft [2] * matrixRight [6] + matrixLeft [5] * matrixRight [7] + matrixLeft [8] * matrixRight [8];
    
			return m;		
		}

		/// <summary>
		/// <para>Multiplies a 3x3 matrix by a vector.</para>
		/// <para>Original signature is 'GLKVector3 GLKMatrix3MultiplyVector3 ( GLKMatrix3 matrixLeft, GLKVector3 vectorRight );'</para>
		/// <para>Available in OS X x0.8 and later.</para>
		/// </summary>
		/// <param name="matrixLeft">MISSING</param>
		/// <param name="vectorRight">MISSING</param>
		/// <returns>A new vector created by multiplying the matrix by the vector.</returns>
		public static GLKVector3 MultiplyVector3 (GLKMatrix3 matrixLeft, GLKVector3 vectorRight)
		{
			GLKVector3 v = new GLKVector3 (matrixLeft [0] * vectorRight.x + matrixLeft [3] * vectorRight.y + matrixLeft [6] * vectorRight.z,
                     matrixLeft [1] * vectorRight.x + matrixLeft [4] * vectorRight.y + matrixLeft [7] * vectorRight.z,
                     matrixLeft [2] * vectorRight.x + matrixLeft [5] * vectorRight.y + matrixLeft [8] * vectorRight.z);
			return v;
		}

		/// <summary>
		/// <para>Multiplies a 3x3 matrix by an array of vectors.</para>
		/// <para>Original signature is 'void GLKMatrix3MultiplyVector3Array ( GLKMatrix3 matrix, GLKVector3 *vectors, size_t vectorCount );'</para>
		/// <para>Available in OS X x0.8 and later.</para>
		/// </summary>
		/// <param name="matrix">MISSING</param>
		/// <param name="vectors">MISSING</param>
		/// <param name="vectorCount">MISSING</param>
		public static void MultiplyVector3Array (GLKMatrix3 matrix, IntPtr vectors, NSUInteger vectorCount)
		{
			throw new NotImplementedException ();
		}

		/// <summary>
		/// <para>Returns a new 3x3 matrix created by concatenating a matrix with a rotation around a vector.</para>
		/// <para>Original signature is 'GLKMatrix3 GLKMatrix3Rotate ( GLKMatrix3 matrix, float radians, float x, float y, float z );'</para>
		/// <para>Available in OS X x0.8 and later.</para>
		/// </summary>
		/// <param name="matrix">MISSING</param>
		/// <param name="radians">MISSING</param>
		/// <param name="x">MISSING</param>
		/// <param name="y">MISSING</param>
		/// <param name="z">MISSING</param>
		/// <returns>A new matrix.</returns>
		public static GLKMatrix3 Rotate (GLKMatrix3 matrix, float radians, float x, float y, float z)
		{
			GLKMatrix3 rm = MakeRotation (radians, x, y, z);
			return Multiply (matrix, rm);
		}

		/// <summary>
		/// <para>Returns a new 3x3 matrix created by concatenating a matrix with a rotation around a vector.</para>
		/// <para>Original signature is 'GLKMatrix3 GLKMatrix3RotateWithVector3 ( GLKMatrix3 matrix, float radians, GLKVector3 axisVector );'</para>
		/// <para>Available in OS X x0.8 and later.</para>
		/// </summary>
		/// <param name="matrix">MISSING</param>
		/// <param name="radians">MISSING</param>
		/// <param name="axisVector">MISSING</param>
		/// <returns>A new matrix.</returns>
		public static GLKMatrix3 RotateWithVector3 (GLKMatrix3 matrix, float radians, GLKVector3 axisVector)
		{
			GLKMatrix3 rm = MakeRotation (radians, axisVector.x, axisVector.y, axisVector.z);
			return Multiply (matrix, rm);
		}

		/// <summary>
		/// <para>Returns a new 3x3 matrix created by concatenating a matrix with a rotation around a vector.</para>
		/// <para>Original signature is 'GLKMatrix3 GLKMatrix3RotateWithVector4 ( GLKMatrix3 matrix, float radians, GLKVector4 axisVector );'</para>
		/// <para>Available in OS X x0.8 and later.</para>
		/// </summary>
		/// <param name="matrix">MISSING</param>
		/// <param name="radians">MISSING</param>
		/// <param name="axisVector">MISSING</param>
		/// <returns>A new matrix.</returns>
		public static GLKMatrix3 RotateWithVector4 (GLKMatrix3 matrix, float radians, GLKVector4 axisVector)
		{
			GLKMatrix3 rm = MakeRotation (radians, axisVector.x, axisVector.y, axisVector.z);
			return Multiply (matrix, rm);
		}

		/// <summary>
		/// <para>Returns a new 3x3 matrix created by concatenating a matrix with a rotation around the x-axis.</para>
		/// <para>Original signature is 'GLKMatrix3 GLKMatrix3RotateX ( GLKMatrix3 matrix, float radians );'</para>
		/// <para>Available in OS X x0.8 and later.</para>
		/// </summary>
		/// <param name="matrix">MISSING</param>
		/// <param name="radians">MISSING</param>
		/// <returns>A new matrix.</returns>
		public static GLKMatrix3 RotateX (GLKMatrix3 matrix, float radians)
		{
			GLKMatrix3 rm = MakeXRotation (radians);
			return Multiply (matrix, rm);
		}

		/// <summary>
		/// <para>Returns a new 3x3 matrix created by concatenating a matrix with a rotation around the y-axis.</para>
		/// <para>Original signature is 'GLKMatrix3 GLKMatrix3RotateY ( GLKMatrix3 matrix, float radians );'</para>
		/// <para>Available in OS X x0.8 and later.</para>
		/// </summary>
		/// <param name="matrix">MISSING</param>
		/// <param name="radians">MISSING</param>
		/// <returns>A new matrix.</returns>
		public static GLKMatrix3 RotateY (GLKMatrix3 matrix, float radians)
		{
			GLKMatrix3 rm = MakeYRotation (radians);
			return Multiply (matrix, rm);
		}

		/// <summary>
		/// <para>Returns a new 3x3 matrix created by concatenating a matrix with a rotation around the z-axis.</para>
		/// <para>Original signature is 'GLKMatrix3 GLKMatrix3RotateZ ( GLKMatrix3 matrix, float radians );'</para>
		/// <para>Available in OS X x0.8 and later.</para>
		/// </summary>
		/// <param name="matrix">MISSING</param>
		/// <param name="radians">MISSING</param>
		/// <returns>A new matrix.</returns>
		public static GLKMatrix3 RotateZ (GLKMatrix3 matrix, float radians)
		{
			GLKMatrix3 rm = MakeZRotation (radians);
			return Multiply (matrix, rm);
		}

		/// <summary>
		/// <para>Returns a new 3x3 matrix created by concatenating a matrix with a scaling transform.</para>
		/// <para>Original signature is 'GLKMatrix3 GLKMatrix3Scale ( GLKMatrix3 matrix, float sx, float sy, float sz );'</para>
		/// <para>Available in OS X x0.8 and later.</para>
		/// </summary>
		/// <param name="matrix">MISSING</param>
		/// <param name="sx">MISSING</param>
		/// <param name="sy">MISSING</param>
		/// <param name="sz">MISSING</param>
		/// <returns>A new matrix.</returns>
		public static GLKMatrix3 Scale (GLKMatrix3 matrix, float sx, float sy, float sz)
		{
			GLKMatrix3 m = Identity;
			m [0] = sx;
			m [4] = sy;
			m [8] = sz;
			return m;

		}

		/// <summary>
		/// <para>Returns a new 3x3 matrix created by concatenating a matrix with a scaling transform defined by a vector.</para>
		/// <para>Original signature is 'GLKMatrix3 GLKMatrix3ScaleWithVector3 ( GLKMatrix3 matrix, GLKVector3 scaleVector );'</para>
		/// <para>Available in OS X x0.8 and later.</para>
		/// </summary>
		/// <param name="matrix">MISSING</param>
		/// <param name="scaleVector">MISSING</param>
		/// <returns>A new matrix.</returns>
		public static GLKMatrix3 ScaleWithVector3 (GLKMatrix3 matrix, GLKVector3 scaleVector)
		{
			GLKMatrix3 m = new GLKMatrix3 (matrix [0] * scaleVector.x, matrix [1] * scaleVector.x, matrix [2] * scaleVector.x,
                     matrix [3] * scaleVector.y, matrix [4] * scaleVector.y, matrix [5] * scaleVector.y,
                     matrix [6] * scaleVector.z, matrix [7] * scaleVector.z, matrix [8] * scaleVector.z);
			return m;
		}

		/// <summary>
		/// <para>Returns a new 3x3 matrix created by concatenating a matrix with a scaling transform defined by a vector.</para>
		/// <para>Original signature is 'GLKMatrix3 GLKMatrix3ScaleWithVector4 ( GLKMatrix3 matrix, GLKVector4 scaleVector );'</para>
		/// <para>Available in OS X x0.8 and later.</para>
		/// </summary>
		/// <param name="matrix">MISSING</param>
		/// <param name="scaleVector">MISSING</param>
		/// <returns>A new matrix.</returns>
		public static GLKMatrix3 ScaleWithVector4 (GLKMatrix3 matrix, GLKVector4 scaleVector)
		{
			GLKMatrix3 m = new GLKMatrix3 (matrix [0] * scaleVector.x, matrix [1] * scaleVector.x, matrix [2] * scaleVector.x,
                     matrix [3] * scaleVector.y, matrix [4] * scaleVector.y, matrix [5] * scaleVector.y,
                     matrix [6] * scaleVector.z, matrix [7] * scaleVector.z, matrix [8] * scaleVector.z);
			return m;
		}

		/// <summary>
		/// <para>Returns a new 3x3 matrix with one column replaced by a new vector.</para>
		/// <para>Original signature is 'GLKMatrix3 GLKMatrix3SetColumn ( GLKMatrix3 matrix, int column, GLKVector3 vector );'</para>
		/// <para>Available in OS X x0.8 and later.</para>
		/// </summary>
		/// <param name="matrix">MISSING</param>
		/// <param name="column">MISSING</param>
		/// <param name="vector">MISSING</param>
		/// <returns>A new matrix.</returns>
		public static GLKMatrix3 SetColumn (GLKMatrix3 matrix, int column, GLKVector3 vector)
		{
			matrix [column * 3 + 0] = vector.x;
			matrix [column * 3 + 1] = vector.y;
			matrix [column * 3 + 2] = vector.z;
    
			return matrix;
		}

		/// <summary>
		/// <para>Returns a new 3x3 matrix with one row replaced by a new vector.</para>
		/// <para>Original signature is 'GLKMatrix3 GLKMatrix3SetRow ( GLKMatrix3 matrix, int row, GLKVector3 vector );'</para>
		/// <para>Available in OS X x0.8 and later.</para>
		/// </summary>
		/// <param name="matrix">MISSING</param>
		/// <param name="row">MISSING</param>
		/// <param name="vector">MISSING</param>
		/// <returns>A new matrix.</returns>
		public static GLKMatrix3 SetRow (GLKMatrix3 matrix, int row, GLKVector3 vector)
		{
			matrix [row] = vector.x;
			matrix [row + 3] = vector.y;
			matrix [row + 6] = vector.z;
    
			return matrix;
		}

		/// <summary>
		/// <para>Returns a new 3x3 matrix created by performing a component-wise subtraction of two matrices.</para>
		/// <para>Original signature is 'GLKMatrix3 GLKMatrix3Subtract ( GLKMatrix3 matrixLeft, GLKMatrix3 matrixRight );'</para>
		/// <para>Available in OS X x0.8 and later.</para>
		/// </summary>
		/// <param name="matrixLeft">MISSING</param>
		/// <param name="matrixRight">MISSING</param>
		/// <returns>A new matrix whose components each represent the difference between the components found in the same positions of the two source matrices.</returns>
		public static GLKMatrix3 Subtract (GLKMatrix3 matrixLeft, GLKMatrix3 matrixRight)
		{
			GLKMatrix3 m = new GLKMatrix3 ();
    
			m [0] = matrixLeft [0] - matrixRight [0];
			m [1] = matrixLeft [1] - matrixRight [1];
			m [2] = matrixLeft [2] - matrixRight [2];
    
			m [3] = matrixLeft [3] - matrixRight [3];
			m [4] = matrixLeft [4] - matrixRight [4];
			m [5] = matrixLeft [5] - matrixRight [5];
    
			m [6] = matrixLeft [6] - matrixRight [6];
			m [7] = matrixLeft [7] - matrixRight [7];
			m [8] = matrixLeft [8] - matrixRight [8];
    
			return m;
		}

		/// <summary>
		/// <para>Returns the transpose of a matrix.</para>
		/// <para>Original signature is 'GLKMatrix3 GLKMatrix3Transpose ( GLKMatrix3 matrix );'</para>
		/// <para>Available in OS X x0.8 and later.</para>
		/// </summary>
		/// <param name="matrix">MISSING</param>
		/// <returns>The transpose of the matrix.</returns>
		public static GLKMatrix3 Transpose (GLKMatrix3 matrix)
		{
			GLKMatrix3 m = new GLKMatrix3 (matrix [0], matrix [3], matrix [6],
				matrix [1], matrix [4], matrix [7],
				matrix [2], matrix [5], matrix [8]);
			return m;
		}
	}
#endif
}
