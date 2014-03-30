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
	public partial struct GLKVector4
	{
		/// <summary>
		/// <para>Returns the sum of two vectors.</para>
		/// <para>Original signature is 'GLKVector4 GLKVector4Add ( GLKVector4 vectorLeft, GLKVector4 vectorRight ) {}'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="vectorLeft">MISSING</param>
		/// <param name="vectorRight">MISSING</param>
		/// <returns>A new vector whose components each represent the sum of the two components found in the same positions of the two source vectors.</returns>
		public static GLKVector4 Add (GLKVector4 vectorLeft, GLKVector4 vectorRight)
		{
			GLKVector4 v = new GLKVector4 (vectorLeft.x + vectorRight.x,
				vectorLeft.y + vectorRight.y,
				vectorLeft.z + vectorRight.z,
				vectorLeft.w + vectorRight.w);
			return v;
		}

		/// <summary>
		/// <para>Returns a new vector created by adding a scalar value to each component of a vector.</para>
		/// <para>Original signature is 'GLKVector4 GLKVector4AddScalar ( GLKVector4 vector, float value ) {}'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="vector">MISSING</param>
		/// <param name="value">MISSING</param>
		/// <returns>A new vector.</returns>
		public static GLKVector4 AddScalar (GLKVector4 vector, float value)
		{
			GLKVector4 v = new GLKVector4 (vector.x + value,
				vector.y + value,
				vector.z + value,
				vector.w + value);
			return v;
		}

		/// <summary>
		/// <para>Returns a Boolean value that states whether all the components of the source vector are equal to a scalar value.</para>
		/// <para>Original signature is 'bool GLKVector4AllEqualToScalar ( GLKVector4 vector, float value ) {}'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="vector">MISSING</param>
		/// <param name="value">MISSING</param>
		/// <returns>YES if all of the vector’s components are equal to value, NO otherwise.</returns>
		public static bool AllEqualToScalar (GLKVector4 vector, float value)
		{
			bool compare = false;
			if (vector.x == value &&
				vector.y == value &&
				vector.z == value &&
				vector.w == value)
				compare = true;
			return compare;
		}

		/// <summary>
		/// <para>Returns a Boolean value that indicates whether each component of the first vector is equal to the corresponding component of a second vector.</para>
		/// <para>Original signature is 'bool GLKVector4AllEqualToVector4 ( GLKVector4 vectorLeft, GLKVector4 vectorRight ) {}'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="vectorLeft">MISSING</param>
		/// <param name="vectorRight">MISSING</param>
		/// <returns>YES if all of the vectors’ components are equal , NO otherwise.</returns>
		public static bool AllEqualToVector4 (GLKVector4 vectorLeft, GLKVector4 vectorRight)
		{
			bool compare = false;
			if (vectorLeft.x == vectorRight.x &&
				vectorLeft.y == vectorRight.y &&
				vectorLeft.z == vectorRight.z &&
				vectorLeft.w == vectorRight.w)
				compare = true;
			return compare;
		}

		/// <summary>
		/// <para>Returns a Boolean value that states whether all the components of the source vector are greater than or equal to a scalar value.</para>
		/// <para>Original signature is 'bool GLKVector4AllGreaterThanOrEqualToScalar ( GLKVector4 vector, float value ) {}'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="vector">MISSING</param>
		/// <param name="value">MISSING</param>
		/// <returns>YES if all of the vector’s components are greater than or equal to the scalar value, NO otherwise.</returns>
		public static bool AllGreaterThanOrEqualToScalar (GLKVector4 vector, float value)
		{
			bool compare = false;
			if (vector.x >= value &&
				vector.y >= value &&
				vector.z >= value &&
				vector.w >= value)
				compare = true;
			return compare;
		}

		/// <summary>
		/// <para>Returns a Boolean value that indicates whether each component of the first vector is greater than or equal to the corresponding component of a second vector.</para>
		/// <para>Original signature is 'bool GLKVector4AllGreaterThanOrEqualToVector4 ( GLKVector4 vectorLeft, GLKVector4 vectorRight ) {}'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="vectorLeft">MISSING</param>
		/// <param name="vectorRight">MISSING</param>
		/// <returns>YES if each component in the first vector is greater than or equal to the corresponding component of the second vector, NO otherwise.</returns>
		public static bool AllGreaterThanOrEqualToVector4 (GLKVector4 vectorLeft, GLKVector4 vectorRight)
		{
			bool compare = false;
			if (vectorLeft.x >= vectorRight.x &&
				vectorLeft.y >= vectorRight.y &&
				vectorLeft.z >= vectorRight.z &&
				vectorLeft.w >= vectorRight.w)
				compare = true;
			return compare;
		}

		/// <summary>
		/// <para>Returns a Boolean value that states whether all the components of the source vector are greater than a scalar value.</para>
		/// <para>Original signature is 'bool GLKVector4AllGreaterThanScalar ( GLKVector4 vector, float value ) {}'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="vector">MISSING</param>
		/// <param name="value">MISSING</param>
		/// <returns>YES if all of the vector’s components are greater than the scalar value, NO otherwise.</returns>
		public static bool AllGreaterThanScalar (GLKVector4 vector, float value)
		{
			bool compare = false;
			if (vector.x > value &&
				vector.y > value &&
				vector.z > value &&
				vector.w > value)
				compare = true;
			return compare;
		}

		/// <summary>
		/// <para>Returns a Boolean value that indicates whether each component of the first vector is greater than the corresponding component of a second vector.</para>
		/// <para>Original signature is 'bool GLKVector4AllGreaterThanVector4 ( GLKVector4 vectorLeft, GLKVector4 vectorRight ) {}'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="vectorLeft">MISSING</param>
		/// <param name="vectorRight">MISSING</param>
		/// <returns>YES if each component in the first vector is greater than the corresponding component of the second vector, NO otherwise.</returns>
		public static bool AllGreaterThanVector4 (GLKVector4 vectorLeft, GLKVector4 vectorRight)
		{
			bool compare = false;
			if (vectorLeft.x > vectorRight.x &&
				vectorLeft.y > vectorRight.y &&
				vectorLeft.z > vectorRight.z &&
				vectorLeft.w > vectorRight.w)
				compare = true;
			return compare;
		}

		/// <summary>
		/// <para>Returns the cross product of two vectors.</para>
		/// <para>Original signature is 'GLKVector4 GLKVector4CrossProduct ( GLKVector4 vectorLeft, GLKVector4 vectorRight ) {}'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="vectorLeft">MISSING</param>
		/// <param name="vectorRight">MISSING</param>
		/// <returns>A new vector.</returns>
		public static GLKVector4 CrossProduct (GLKVector4 vectorLeft, GLKVector4 vectorRight)
		{
			GLKVector4 v = new GLKVector4 (vectorLeft.y * vectorRight.z - vectorLeft.z * vectorRight.y,
				vectorLeft.z * vectorRight.x - vectorLeft.x * vectorRight.z,
				vectorLeft.x * vectorRight.y - vectorLeft.y * vectorRight.x,
				0.0f);
			return v;
		}

		/// <summary>
		/// <para>Returns the distance between two points.</para>
		/// <para>Original signature is 'float GLKVector4Distance ( GLKVector4 vectorStart, GLKVector4 vectorEnd ) {}'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="vectorStart">MISSING</param>
		/// <param name="vectorEnd">MISSING</param>
		/// <returns>The distance between the two points.</returns>
		public static float Distance (GLKVector4 vectorStart, GLKVector4 vectorEnd)
		{
			return GLKVector4.Length (GLKVector4.Subtract (vectorEnd, vectorStart));
		}

		/// <summary>
		/// <para>Returns a new vector created by dividing one vector by another.</para>
		/// <para>Original signature is 'GLKVector4 GLKVector4Divide ( GLKVector4 vectorLeft, GLKVector4 vectorRight ) {}'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="vectorLeft">MISSING</param>
		/// <param name="vectorRight">MISSING</param>
		/// <returns>A new vector whose components are each calculated by dividing the component found in same position of the first vector by the component found in the same position of the second vector.</returns>
		public static GLKVector4 Divide (GLKVector4 vectorLeft, GLKVector4 vectorRight)
		{
			GLKVector4 v = new GLKVector4 (vectorLeft.x / vectorRight.x,
				vectorLeft.y / vectorRight.y,
				vectorLeft.z / vectorRight.z,
				vectorLeft.w / vectorRight.w);
			return v;
		}

		/// <summary>
		/// <para>Returns a new vector created by dividing each component of a vector by a scalar value.</para>
		/// <para>Original signature is 'GLKVector4 GLKVector4DivideScalar ( GLKVector4 vector, float value ) {}'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="vector">MISSING</param>
		/// <param name="value">MISSING</param>
		/// <returns>A new vector.</returns>
		public static GLKVector4 DivideScalar (GLKVector4 vector, float value)
		{
			GLKVector4 v = new GLKVector4 (vector.x / value,
				vector.y / value,
				vector.z / value,
				vector.w / value);
			return v;
		}

		/// <summary>
		/// <para>Returns the dot product of two vectors.</para>
		/// <para>Original signature is 'float GLKVector4DotProduct ( GLKVector4 vectorLeft, GLKVector4 vectorRight ) {}'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="vectorLeft">MISSING</param>
		/// <param name="vectorRight">MISSING</param>
		/// <returns>The dot product of the two vectors.</returns>
		public static float DotProduct (GLKVector4 vectorLeft, GLKVector4 vectorRight)
		{
			return vectorLeft.x * vectorRight.x +
				vectorLeft.y * vectorRight.y +
				vectorLeft.z * vectorRight.z +
				vectorLeft.w * vectorRight.w;
		}

		/// <summary>
		/// <para>Returns the length of a vector.</para>
		/// <para>Original signature is 'float GLKVector4Length ( GLKVector4 vector ) {}'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="vector">MISSING</param>
		/// <returns>The length of the vector.</returns>
		public static float Length (GLKVector4 vector)
		{
			return (float)Math.Sqrt (vector.x * vector.x +
				vector.y * vector.y +
				vector.z * vector.z +
				vector.w * vector.w);
		}

		/// <summary>
		/// <para>Returns a new vector created by linearly interpreting between two vectors.</para>
		/// <para>Original signature is 'GLKVector4 GLKVector4Lerp ( GLKVector4 vectorStart, GLKVector4 vectorEnd, float t ) {}'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="vectorStart">MISSING</param>
		/// <param name="vectorEnd">MISSING</param>
		/// <param name="t">MISSING</param>
		/// <returns>A new vector.</returns>
		public static GLKVector4 Lerp (GLKVector4 vectorStart, GLKVector4 vectorEnd, float t)
		{
			GLKVector4 v = new GLKVector4 (vectorStart.x + ((vectorEnd.x - vectorStart.x) * t),
				vectorStart.y + ((vectorEnd.y - vectorStart.y) * t),
				vectorStart.z + ((vectorEnd.z - vectorStart.z) * t),
				vectorStart.w + ((vectorEnd.w - vectorStart.w) * t));
			return v;
		}

		/// <summary>
		/// <para>Returns a new four-component vector created from individual component values.</para>
		/// <para>Original signature is 'GLKVector4 GLKVector4Make ( float x, float y, float z, float w ) {}'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="x">MISSING</param>
		/// <param name="y">MISSING</param>
		/// <param name="z">MISSING</param>
		/// <param name="w">MISSING</param>
		/// <returns>An initialized vector.</returns>
		public static GLKVector4 Make (float x, float y, float z, float w)
		{
			GLKVector4 v = new GLKVector4 (x, y, z, w);
			return v;
		}

		/// <summary>
		/// <para>Returns a new four-component vector created from an array of components.</para>
		/// <para>Original signature is 'GLKVector4 GLKVector4MakeWithArray ( float values[4] ) {}'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="values">MISSING</param>
		/// <returns>The array</returns>
		public static GLKVector4 MakeWithArray (IntPtr values)
		{
			throw new NotImplementedException ();
		}

		/// <summary>
		/// <para>Returns a new four-component vector created by combining a three-component vector with a scalar value.</para>
		/// <para>Original signature is 'GLKVector4 GLKVector4MakeWithVector3 ( GLKVector3 vector, float w ) {}'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="vector">MISSING</param>
		/// <param name="w">MISSING</param>
		/// <returns>A new vector.</returns>
		public static GLKVector4 MakeWithVector3 (GLKVector3 vector, float w)
		{
			GLKVector4 v = new GLKVector4 (vector.x, vector.y, vector.z, w);
			return v;
		}

		/// <summary>
		/// <para>Returns a new vector whose component value at each position is the largest component value at the same position in the source vectors.</para>
		/// <para>Original signature is 'GLKVector4 GLKVector4Maximum ( GLKVector4 vectorLeft, GLKVector4 vectorRight ) {}'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="vectorLeft">MISSING</param>
		/// <param name="vectorRight">MISSING</param>
		/// <returns>A new vector.</returns>
		public static GLKVector4 Maximum (GLKVector4 vectorLeft, GLKVector4 vectorRight)
		{
			GLKVector4 max = vectorLeft;
			if (vectorRight.x > vectorLeft.x)
				max.x = vectorRight.x;
			if (vectorRight.y > vectorLeft.y)
				max.y = vectorRight.y;
			if (vectorRight.z > vectorLeft.z)
				max.z = vectorRight.z;
			if (vectorRight.w > vectorLeft.w)
				max.w = vectorRight.w;
			return max;
		}

		/// <summary>
		/// <para>Returns a new vector whose component value at each position is the smallest component value at the same position in the source vectors.</para>
		/// <para>Original signature is 'GLKVector4 GLKVector4Minimum ( GLKVector4 vectorLeft, GLKVector4 vectorRight ) {}'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="vectorLeft">MISSING</param>
		/// <param name="vectorRight">MISSING</param>
		/// <returns>A new vector.</returns>
		public static GLKVector4 Minimum (GLKVector4 vectorLeft, GLKVector4 vectorRight)
		{
			GLKVector4 min = vectorLeft;
			if (vectorRight.x < vectorLeft.x)
				min.x = vectorRight.x;
			if (vectorRight.y < vectorLeft.y)
				min.y = vectorRight.y;
			if (vectorRight.z < vectorLeft.z)
				min.z = vectorRight.z;
			if (vectorRight.w < vectorLeft.w)
				min.w = vectorRight.w;
			return min;
		}

		/// <summary>
		/// <para>Returns the product of two vectors.</para>
		/// <para>Original signature is 'GLKVector4 GLKVector4Multiply ( GLKVector4 vectorLeft, GLKVector4 vectorRight ) {}'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="vectorLeft">MISSING</param>
		/// <param name="vectorRight">MISSING</param>
		/// <returns>A new vector whose components each represent the product of the components found in the same positions of the two source vectors.</returns>
		public static GLKVector4 Multiply (GLKVector4 vectorLeft, GLKVector4 vectorRight)
		{
			GLKVector4 v = new GLKVector4 (vectorLeft.x * vectorRight.x,
				vectorLeft.y * vectorRight.y,
				vectorLeft.z * vectorRight.z,
				vectorLeft.w * vectorRight.w);
			return v;
		}

		/// <summary>
		/// <para>Returns a new vector created by multiplying each component of a vector by a scalar value.</para>
		/// <para>Original signature is 'GLKVector4 GLKVector4MultiplyScalar ( GLKVector4 vector, float value ) {}'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="vector">MISSING</param>
		/// <param name="value">MISSING</param>
		/// <returns>A new vector.</returns>
		public static GLKVector4 MultiplyScalar (GLKVector4 vector, float value)
		{
			GLKVector4 v = new GLKVector4 (vector.x * value,
				vector.y * value,
				vector.z * value,
				vector.w * value);
			return v;   
		}

		/// <summary>
		/// <para>Returns a new vector created by negating the component values of another vector.</para>
		/// <para>Original signature is 'GLKVector4 GLKVector4Negate ( GLKVector4 vector ) {}'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="vector">MISSING</param>
		/// <returns>A new vector.</returns>
		public static GLKVector4 Negate (GLKVector4 vector)
		{
			GLKVector4 v = new GLKVector4 (-vector.x, -vector.y, -vector.z, -vector.w);
			return v;
		}

		/// <summary>
		/// <para>Returns a new vector created by normalizing an input vector to a length of 1.0.</para>
		/// <para>Original signature is 'GLKVector4 GLKVector4Normalize ( GLKVector4 vector ) {}'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="vector">MISSING</param>
		/// <returns>A new vector.</returns>
		public static GLKVector4 Normalize (GLKVector4 vector)
		{
			float scale = 1.0f / GLKVector4.Length (vector);
			GLKVector4 v = GLKVector4.MultiplyScalar (vector, scale);
			return v;
		}

		/// <summary>
		/// <para>Returns a new vector created by projecting a vector onto another vector.</para>
		/// <para>Original signature is 'GLKVector4 GLKVector4Project ( GLKVector4 vectorToProject, GLKVector4 projectionVector ) {}'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="vectorToProject">MISSING</param>
		/// <param name="projectionVector">MISSING</param>
		/// <returns>A new vector.</returns>
		public static GLKVector4 Project (GLKVector4 vectorToProject, GLKVector4 projectionVector)
		{
			float scale = GLKVector4.DotProduct (projectionVector, vectorToProject) / GLKVector4.DotProduct (projectionVector, projectionVector);
			GLKVector4 v = GLKVector4.MultiplyScalar (projectionVector, scale);
			return v;
		}

		/// <summary>
		/// <para>Returns the difference between two vectors.</para>
		/// <para>Original signature is 'GLKVector4 GLKVector4Subtract ( GLKVector4 vectorLeft, GLKVector4 vectorRight ) {}'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="vectorLeft">MISSING</param>
		/// <param name="vectorRight">MISSING</param>
		/// <returns>A new vector whose components each represent the difference between the components found in the same positions of the two source vectors.</returns>
		public static GLKVector4 Subtract (GLKVector4 vectorLeft, GLKVector4 vectorRight)
		{
			GLKVector4 v = new GLKVector4 (vectorLeft.x - vectorRight.x,
				vectorLeft.y - vectorRight.y,
				vectorLeft.z - vectorRight.z,
				vectorLeft.w - vectorRight.w);
			return v;
		}

		/// <summary>
		/// <para>Returns a new vector created by subtracting a scalar value from each component of a vector.</para>
		/// <para>Original signature is 'GLKVector4 GLKVector4SubtractScalar ( GLKVector4 vector, float value ) {}'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="vector">MISSING</param>
		/// <param name="value">MISSING</param>
		/// <returns>A new vector.</returns>
		public static GLKVector4 SubtractScalar (GLKVector4 vector, float value)
		{
			GLKVector4 v = new GLKVector4 (vector.x - value,
				vector.y - value,
				vector.z - value,
				vector.w - value);
			return v;
		}
	}
#endif
}
