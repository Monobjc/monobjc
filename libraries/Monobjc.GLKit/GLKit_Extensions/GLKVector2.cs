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
	public partial struct GLKVector2
	{
		/// <summary>
		/// <para>Returns the sum of two vectors.</para>
		/// <para>Original signature is 'GLKVector2 GLKVector2Add ( GLKVector2 vectorLeft, GLKVector2 vectorRight ) {}'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="vectorLeft">MISSING</param>
		/// <param name="vectorRight">MISSING</param>
		/// <returns>A new vector whose components each represent the sum of the two components found in the same positions of the two source vectors.</returns>
		public static GLKVector2 Add (GLKVector2 vectorLeft, GLKVector2 vectorRight)
		{
			GLKVector2 v = new GLKVector2 (vectorLeft.x + vectorRight.x, vectorLeft.y + vectorRight.y);
			return v;
		}

		/// <summary>
		/// <para>Returns a new vector created by adding a scalar value to each component of a vector.</para>
		/// <para>Original signature is 'GLKVector2 GLKVector2AddScalar ( GLKVector2 vector, float value ) {}'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="vector">MISSING</param>
		/// <param name="value">MISSING</param>
		/// <returns>A new vector.</returns>
		public static GLKVector2 AddScalar (GLKVector2 vector, float value)
		{
			GLKVector2 v = new GLKVector2 (vector.x + value, vector.y + value);
			return v;
		}

		/// <summary>
		/// <para>Returns a Boolean value that states whether all the components of the source vector are equal to a scalar value.</para>
		/// <para>Original signature is 'bool GLKVector2AllEqualToScalar ( GLKVector2 vector, float value ) {}'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="vector">MISSING</param>
		/// <param name="value">MISSING</param>
		/// <returns>YES if all of the vector’s components are equal to value, NO otherwise.</returns>
		public static bool AllEqualToScalar (GLKVector2 vector, float value)
		{
			bool compare = false;
			if (vector.x == value &&
				vector.y == value)
				compare = true;
			return compare;
		}

		/// <summary>
		/// <para>Returns a Boolean value that indicates whether each component of the first vector is equal to the corresponding component of a second vector.</para>
		/// <para>Original signature is 'bool GLKVector2AllEqualToVector2 ( GLKVector2 vectorLeft, GLKVector2 vectorRight ) {}'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="vectorLeft">MISSING</param>
		/// <param name="vectorRight">MISSING</param>
		/// <returns>YES if all of the vectors’ components are equal , NO otherwise.</returns>
		public static bool AllEqualToVector2 (GLKVector2 vectorLeft, GLKVector2 vectorRight)
		{
			bool compare = false;
			if (vectorLeft.x == vectorRight.x &&
				vectorLeft.y == vectorRight.y)
				compare = true;
			return compare;
		}

		/// <summary>
		/// <para>Returns a Boolean value that states whether all the components of the source vector are greater than or equal to a scalar value.</para>
		/// <para>Original signature is 'bool GLKVector2AllGreaterThanOrEqualToScalar ( GLKVector2 vector, float value ) {}'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="vector">MISSING</param>
		/// <param name="value">MISSING</param>
		/// <returns>A Boolean value that states whether the vector components are all greater than or equal to the scalar value.</returns>
		public static bool AllGreaterThanOrEqualToScalar (GLKVector2 vector, float value)
		{
			bool compare = false;
			if (vector.x >= value &&
				vector.y >= value)
				compare = true;
			return compare;
		}

		/// <summary>
		/// <para>Returns a Boolean value that indicates whether each component of the first vector is greater than or equal to the corresponding component of a second vector.</para>
		/// <para>Original signature is 'bool GLKVector2AllGreaterThanOrEqualToVector2 ( GLKVector2 vectorLeft, GLKVector2 vectorRight ) {}'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="vectorLeft">MISSING</param>
		/// <param name="vectorRight">MISSING</param>
		/// <returns>YES if each component in the first vector is greater than or equal to the corresponding component of the second vector, NO otherwise.</returns>
		public static bool AllGreaterThanOrEqualToVector2 (GLKVector2 vectorLeft, GLKVector2 vectorRight)
		{
			bool compare = false;
			if (vectorLeft.x >= vectorRight.x &&
				vectorLeft.y >= vectorRight.y)
				compare = true;
			return compare;
		}

		/// <summary>
		/// <para>Returns a Boolean value that states whether all the components of the source vector are greater than a scalar value.</para>
		/// <para>Original signature is 'bool GLKVector2AllGreaterThanScalar ( GLKVector2 vector, float value ) {}'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="vector">MISSING</param>
		/// <param name="value">MISSING</param>
		/// <returns>YES if all of the vector’s components are greater than the scalar value, NO otherwise.</returns>
		public static bool AllGreaterThanScalar (GLKVector2 vector, float value)
		{
			bool compare = false;
			if (vector.x > value &&
				vector.y > value)
				compare = true;
			return compare;
		}

		/// <summary>
		/// <para>Returns a Boolean value that indicates whether each component of the first vector is greater than the corresponding component of a second vector.</para>
		/// <para>Original signature is 'bool GLKVector2AllGreaterThanVector2 ( GLKVector2 vectorLeft, GLKVector2 vectorRight ) {}'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="vectorLeft">MISSING</param>
		/// <param name="vectorRight">MISSING</param>
		/// <returns>YES if each component in the first vector is greater than the corresponding component of the second vector, NO otherwise.</returns>
		public static bool AllGreaterThanVector2 (GLKVector2 vectorLeft, GLKVector2 vectorRight)
		{
			bool compare = false;
			if (vectorLeft.x > vectorRight.x &&
				vectorLeft.y > vectorRight.y)
				compare = true;
			return compare;
		}

		/// <summary>
		/// <para>Returns the distance between two points.</para>
		/// <para>Original signature is 'float GLKVector2Distance ( GLKVector2 vectorStart, GLKVector2 vectorEnd ) {}'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="vectorStart">MISSING</param>
		/// <param name="vectorEnd">MISSING</param>
		/// <returns>The distance between the two points.</returns>
		public static float Distance (GLKVector2 vectorStart, GLKVector2 vectorEnd)
		{
			return GLKVector2.Length (GLKVector2.Subtract (vectorEnd, vectorStart));
		}

		/// <summary>
		/// <para>Returns a new vector created by dividing one vector by another.</para>
		/// <para>Original signature is 'GLKVector2 GLKVector2Divide ( GLKVector2 vectorLeft, GLKVector2 vectorRight ) {}'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="vectorLeft">MISSING</param>
		/// <param name="vectorRight">MISSING</param>
		/// <returns>A new vector whose components are each calculated by dividing the component found in same position of the first vector by the component found in the same position of the second vector.</returns>
		public static GLKVector2 Divide (GLKVector2 vectorLeft, GLKVector2 vectorRight)
		{
			GLKVector2 v = new GLKVector2 (vectorLeft.x / vectorRight.x, vectorLeft.y / vectorRight.y);
			return v;
		}

		/// <summary>
		/// <para>Returns a new vector created by dividing each component of a vector by a scalar value.</para>
		/// <para>Original signature is 'GLKVector2 GLKVector2DivideScalar ( GLKVector2 vector, float value ) {}'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="vector">MISSING</param>
		/// <param name="value">MISSING</param>
		/// <returns>A new vector.</returns>
		public static GLKVector2 DivideScalar (GLKVector2 vector, float value)
		{
			GLKVector2 v = new GLKVector2 (vector.x / value, vector.y / value);
			return v;
		}

		/// <summary>
		/// <para>Returns the dot product of two vectors.</para>
		/// <para>Original signature is 'float GLKVector2.DotProduct ( GLKVector2 vectorLeft, GLKVector2 vectorRight ) {}'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="vectorLeft">MISSING</param>
		/// <param name="vectorRight">MISSING</param>
		/// <returns>The dot product of the two vectors.</returns>
		public static float DotProduct (GLKVector2 vectorLeft, GLKVector2 vectorRight)
		{
			return vectorLeft.x * vectorRight.x + vectorLeft.y * vectorRight.y;
		}

		/// <summary>
		/// <para>Returns the length of a vector.</para>
		/// <para>Original signature is 'float GLKVector2Length ( GLKVector2 vector ) {}'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="vector">MISSING</param>
		/// <returns>The length of the vector.</returns>
		public static float Length (GLKVector2 vector)
		{
			return (float)Math.Sqrt (vector.x * vector.x + vector.y * vector.y);
		}

		/// <summary>
		/// <para>Returns a new vector created by linearly interpreting between two vectors.</para>
		/// <para>Original signature is 'GLKVector2 GLKVector2Lerp ( GLKVector2 vectorStart, GLKVector2 vectorEnd, float t ) {}'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="vectorStart">MISSING</param>
		/// <param name="vectorEnd">MISSING</param>
		/// <param name="t">MISSING</param>
		/// <returns>A new vector.</returns>
		public static GLKVector2 Lerp (GLKVector2 vectorStart, GLKVector2 vectorEnd, float t)
		{
			GLKVector2 v = new GLKVector2 (vectorStart.x + ((vectorEnd.x - vectorStart.x) * t), vectorStart.y + ((vectorEnd.y - vectorStart.y) * t));
			return v;
		}

		/// <summary>
		/// <para>Returns a new two-component vector created from individual component values.</para>
		/// <para>Original signature is 'GLKVector2 GLKVector2Make ( float x, float y ) {}'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="x">MISSING</param>
		/// <param name="y">MISSING</param>
		/// <returns>An initialized vector.</returns>
		public static GLKVector2 Make (float x, float y)
		{
			GLKVector2 v = new GLKVector2 (x, y);
			return v;
		}

		/// <summary>
		/// <para>Returns a new two-component vector created from an array of components.</para>
		/// <para>Original signature is 'GLKVector2 GLKVector2MakeWithArray ( float values[2] ) {}'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="values">MISSING</param>
		/// <returns>The array</returns>
		public static GLKVector2 MakeWithArray (IntPtr values)
		{
			throw new NotImplementedException ();
		}

		/// <summary>
		/// <para>Returns a new vector whose component value at each position is the largest component value at the same position of the two source vectors.</para>
		/// <para>Original signature is 'GLKVector2 GLKVector2Maximum ( GLKVector2 vectorLeft, GLKVector2 vectorRight ) {}'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="vectorLeft">MISSING</param>
		/// <param name="vectorRight">MISSING</param>
		/// <returns>A new vector.</returns>
		public static GLKVector2 Maximum (GLKVector2 vectorLeft, GLKVector2 vectorRight)
		{
			GLKVector2 max = vectorLeft;
			if (vectorRight.x > vectorLeft.x)
				max.x = vectorRight.x;
			if (vectorRight.y > vectorLeft.y)
				max.y = vectorRight.y;
			return max;
		}

		/// <summary>
		/// <para>Returns a new vector whose component value at each position is the smallest component value at the same position of the two source vectors.</para>
		/// <para>Original signature is 'GLKVector2 GLKVector2Minimum ( GLKVector2 vectorLeft, GLKVector2 vectorRight ) {}'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="vectorLeft">MISSING</param>
		/// <param name="vectorRight">MISSING</param>
		/// <returns>A new vector.</returns>
		public static GLKVector2 Minimum (GLKVector2 vectorLeft, GLKVector2 vectorRight)
		{
			GLKVector2 min = vectorLeft;
			if (vectorRight.x < vectorLeft.x)
				min.x = vectorRight.x;
			if (vectorRight.y < vectorLeft.y)
				min.y = vectorRight.y;
			return min;
		}

		/// <summary>
		/// <para>Returns a new vector created by multiplying one vector by another.</para>
		/// <para>Original signature is 'GLKVector2 GLKVector2Multiply ( GLKVector2 vectorLeft, GLKVector2 vectorRight ) {}'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="vectorLeft">MISSING</param>
		/// <param name="vectorRight">MISSING</param>
		/// <returns>A new vector whose components each represent the product of the components found in the same positions of the two source vectors.</returns>
		public static GLKVector2 Multiply (GLKVector2 vectorLeft, GLKVector2 vectorRight)
		{
			GLKVector2 v = new GLKVector2 (vectorLeft.x * vectorRight.x, vectorLeft.y * vectorRight.y);
			return v;
		}

		/// <summary>
		/// <para>Returns a new vector created by multiplying each component of a vector by a scalar value.</para>
		/// <para>Original signature is 'GLKVector2 GLKVector2.MultiplyScalar ( GLKVector2 vector, float value ) {}'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="vector">MISSING</param>
		/// <param name="value">MISSING</param>
		/// <returns>A new vector.</returns>
		public static GLKVector2 MultiplyScalar (GLKVector2 vector, float value)
		{
			GLKVector2 v = new GLKVector2 (vector.x * value, vector.y * value);
			return v;
		}

		/// <summary>
		/// <para>Returns a new vector created by negating the component values of another vector.</para>
		/// <para>Original signature is 'GLKVector2 GLKVector2Negate ( GLKVector2 vector ) {}'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="vector">MISSING</param>
		/// <returns>A new vector.</returns>
		public static GLKVector2 Negate (GLKVector2 vector)
		{
			GLKVector2 v = new GLKVector2 (-vector.x, -vector.y);
			return v;
		}

		/// <summary>
		/// <para>Returns a new vector created by normalizing an input vector to a length of 1.0.</para>
		/// <para>Original signature is 'GLKVector2 GLKVector2Normalize ( GLKVector2 vector ) {}'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="vector">MISSING</param>
		/// <returns>A new vector.</returns>
		public static GLKVector2 Normalize (GLKVector2 vector)
		{
			float scale = 1.0f / GLKVector2.Length (vector);
			GLKVector2 v = GLKVector2.MultiplyScalar (vector, scale);
			return v;
		}

		/// <summary>
		/// <para>Returns a new vector created by projecting a vector onto another vector</para>
		/// <para>Original signature is 'GLKVector2 GLKVector2Project ( GLKVector2 vectorToProject, GLKVector2 projectionVector ) {}'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="vectorToProject">MISSING</param>
		/// <param name="projectionVector">MISSING</param>
		/// <returns>A new vector.</returns>
		public static GLKVector2 Project (GLKVector2 vectorToProject, GLKVector2 projectionVector)
		{
			float scale = GLKVector2.DotProduct (projectionVector, vectorToProject) / GLKVector2.DotProduct (projectionVector, projectionVector);
			GLKVector2 v = GLKVector2.MultiplyScalar (projectionVector, scale);
			return v;
		}

		/// <summary>
		/// <para>Returns the difference between two vectors.</para>
		/// <para>Original signature is 'GLKVector2 GLKVector2Subtract ( GLKVector2 vectorLeft, GLKVector2 vectorRight ) {}'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="vectorLeft">MISSING</param>
		/// <param name="vectorRight">MISSING</param>
		/// <returns>A new vector whose components each represent the difference between the components found in the same positions of the two source vectors.</returns>
		public static GLKVector2 Subtract (GLKVector2 vectorLeft, GLKVector2 vectorRight)
		{
			GLKVector2 v = new GLKVector2 (vectorLeft.x - vectorRight.x, vectorLeft.y - vectorRight.y);
			return v;
		}

		/// <summary>
		/// <para>Returns a new vector created by subtracting a scalar value from each component of a vector.</para>
		/// <para>Original signature is 'GLKVector2 GLKVector2SubtractScalar ( GLKVector2 vector, float value ) {}'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="vector">MISSING</param>
		/// <param name="value">MISSING</param>
		/// <returns>A new vector.</returns>
		public static GLKVector2 SubtractScalar (GLKVector2 vector, float value)
		{
			GLKVector2 v = new GLKVector2 (vector.x - value, vector.y - value);
			return v;
		}
	}
#endif
}
