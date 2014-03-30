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
	public partial struct GLKVector3
	{
		/// <summary>
		/// <para>Returns the sum of two vectors.</para>
		/// <para>Original signature is 'GLKVector3 GLKVector3Add ( GLKVector3 vectorLeft, GLKVector3 vectorRight ) {}'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="vectorLeft">MISSING</param>
		/// <param name="vectorRight">MISSING</param>
		/// <returns>A new vector whose components each represent the sum of the two components found in the same positions of the two source vectors.</returns>
		public static GLKVector3 Add (GLKVector3 vectorLeft, GLKVector3 vectorRight)
		{
			GLKVector3 v = new GLKVector3 (vectorLeft.x + vectorRight.x,
				vectorLeft.y + vectorRight.y,
				vectorLeft.z + vectorRight.z);
			return v;
		}

		/// <summary>
		/// <para>Returns a new vector created by adding a scalar value to each component of a vector.</para>
		/// <para>Original signature is 'GLKVector3 GLKVector3AddScalar ( GLKVector3 vector, float value ) {}'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="vector">MISSING</param>
		/// <param name="value">MISSING</param>
		/// <returns>A new vector.</returns>
		public static GLKVector3 AddScalar (GLKVector3 vector, float value)
		{
			GLKVector3 v = new GLKVector3 (vector.x + value,
				vector.y + value,
				vector.z + value);
			return v;
		}

		/// <summary>
		/// <para>Returns a Boolean value that states whether all the components of the source vector are equal to a scalar value.</para>
		/// <para>Original signature is 'bool GLKVector3AllEqualToScalar ( GLKVector3 vector, float value ) {}'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="vector">MISSING</param>
		/// <param name="value">MISSING</param>
		/// <returns>YES if all of the vector’s components are equal to value, NO otherwise.</returns>
		public static bool AllEqualToScalar (GLKVector3 vector, float value)
		{
			bool compare = false;
			if (vector.x == value &&
				vector.y == value &&
				vector.z == value)
				compare = true;
			return compare;
		}

		/// <summary>
		/// <para>Returns a Boolean value that indicates whether each component of the first vector is equal to the corresponding component of a second vector.</para>
		/// <para>Original signature is 'bool GLKVector3AllEqualToVector3 ( GLKVector3 vectorLeft, GLKVector3 vectorRight ) {}'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="vectorLeft">MISSING</param>
		/// <param name="vectorRight">MISSING</param>
		/// <returns>YES if all of the vectors’ components are equal , NO otherwise.</returns>
		public static bool AllEqualToVector3 (GLKVector3 vectorLeft, GLKVector3 vectorRight)
		{
			bool compare = false;
			if (vectorLeft.x == vectorRight.x &&
				vectorLeft.y == vectorRight.y &&
				vectorLeft.z == vectorRight.z)
				compare = true;
			return compare;
		}

		/// <summary>
		/// <para>Returns a Boolean value that states whether all the components of the source vector are greater than or equal to a scalar value.</para>
		/// <para>Original signature is 'bool GLKVector3AllGreaterThanOrEqualToScalar ( GLKVector3 vector, float value ) {}'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="vector">MISSING</param>
		/// <param name="value">MISSING</param>
		/// <returns>YES if all of the vector’s components are greater than or equal to the scalar value, NO otherwise.</returns>
		public static bool AllGreaterThanOrEqualToScalar (GLKVector3 vector, float value)
		{
			bool compare = false;
			if (vector.x >= value &&
				vector.y >= value &&
				vector.z >= value)
				compare = true;
			return compare;
		}

		/// <summary>
		/// <para>Returns a Boolean value that indicates whether each component of the first vector is greater than or equal to the corresponding component of a second vector.</para>
		/// <para>Original signature is 'bool GLKVector3AllGreaterThanOrEqualToVector3 ( GLKVector3 vectorLeft, GLKVector3 vectorRight ) {}'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="vectorLeft">MISSING</param>
		/// <param name="vectorRight">MISSING</param>
		/// <returns>YES if each component in the first vector is greater than or equal to the corresponding component of the second vector, NO otherwise.</returns>
		public static bool AllGreaterThanOrEqualToVector3 (GLKVector3 vectorLeft, GLKVector3 vectorRight)
		{
			bool compare = false;
			if (vectorLeft.x >= vectorRight.x &&
				vectorLeft.y >= vectorRight.y &&
				vectorLeft.z >= vectorRight.z)
				compare = true;
			return compare;
		}

		/// <summary>
		/// <para>Returns a Boolean value that states whether all the components of the source vector are greater than a scalar value.</para>
		/// <para>Original signature is 'bool GLKVector3AllGreaterThanScalar ( GLKVector3 vector, float value ) {}'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="vector">MISSING</param>
		/// <param name="value">MISSING</param>
		/// <returns>YES if all of the vector’s components are greater than the scalar value, NO otherwise.</returns>
		public static bool AllGreaterThanScalar (GLKVector3 vector, float value)
		{
			bool compare = false;
			if (vector.x > value &&
				vector.y > value &&
				vector.z > value)
				compare = true;
			return compare;
		}

		/// <summary>
		/// <para>Returns a Boolean value that indicates whether each component of the first vector is greater than the corresponding component of a second vector.</para>
		/// <para>Original signature is 'bool GLKVector3AllGreaterThanVector3 ( GLKVector3 vectorLeft, GLKVector3 vectorRight ) {}'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="vectorLeft">MISSING</param>
		/// <param name="vectorRight">MISSING</param>
		/// <returns>YES if each component in the first vector is greater than the corresponding component of the second vector, NO otherwise.</returns>
		public static bool AllGreaterThanVector3 (GLKVector3 vectorLeft, GLKVector3 vectorRight)
		{
			bool compare = false;
			if (vectorLeft.x > vectorRight.x &&
				vectorLeft.y > vectorRight.y &&
				vectorLeft.z > vectorRight.z)
				compare = true;
			return compare;
		}

		/// <summary>
		/// <para>Returns the cross product of two vectors.</para>
		/// <para>Original signature is 'GLKVector3 GLKVector3CrossProduct ( GLKVector3 vectorLeft, GLKVector3 vectorRight ) {}'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="vectorLeft">MISSING</param>
		/// <param name="vectorRight">MISSING</param>
		/// <returns>A new vector.</returns>
		public static GLKVector3 CrossProduct (GLKVector3 vectorLeft, GLKVector3 vectorRight)
		{
			GLKVector3 v = new GLKVector3 (vectorLeft.y * vectorRight.z - vectorLeft.z * vectorRight.y,
				vectorLeft.z * vectorRight.x - vectorLeft.x * vectorRight.z,
				vectorLeft.x * vectorRight.y - vectorLeft.y * vectorRight.x);
			return v;
		}

		/// <summary>
		/// <para>Returns the distance between two points.</para>
		/// <para>Original signature is 'float GLKVector3Distance ( GLKVector3 vectorStart, GLKVector3 vectorEnd ) {}'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="vectorStart">MISSING</param>
		/// <param name="vectorEnd">MISSING</param>
		/// <returns>The distance between the two points.</returns>
		public static float Distance (GLKVector3 vectorStart, GLKVector3 vectorEnd)
		{
			return GLKVector3.Length (GLKVector3.Subtract (vectorEnd, vectorStart));
		}

		/// <summary>
		/// <para>Returns a new vector created by dividing one vector by another.</para>
		/// <para>Original signature is 'GLKVector3 GLKVector3Divide ( GLKVector3 vectorLeft, GLKVector3 vectorRight ) {}'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="vectorLeft">MISSING</param>
		/// <param name="vectorRight">MISSING</param>
		/// <returns>A new vector whose components are each calculated by dividing the component found in same position of the first vector by the component found in the same position of the second vector.</returns>
		public static GLKVector3 Divide (GLKVector3 vectorLeft, GLKVector3 vectorRight)
		{
			GLKVector3 v = new GLKVector3 (vectorLeft.x / vectorRight.x,
				vectorLeft.y / vectorRight.y,
				vectorLeft.z / vectorRight.z);
			return v;
		}

		/// <summary>
		/// <para>Returns a new vector created by dividing each component of a vector by a scalar value.</para>
		/// <para>Original signature is 'GLKVector3 GLKVector3DivideScalar ( GLKVector3 vector, float value ) {}'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="vector">MISSING</param>
		/// <param name="value">MISSING</param>
		/// <returns>A new vector.</returns>
		public static GLKVector3 DivideScalar (GLKVector3 vector, float value)
		{
			GLKVector3 v = new GLKVector3 (vector.x / value,
				vector.y / value,
				vector.z / value);
			return v;
		}

		/// <summary>
		/// <para>Returns the dot product of two vectors.</para>
		/// <para>Original signature is 'float GLKVector3DotProduct ( GLKVector3 vectorLeft, GLKVector3 vectorRight ) {}'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="vectorLeft">MISSING</param>
		/// <param name="vectorRight">MISSING</param>
		/// <returns>The dot product of the two vectors.</returns>
		public static float DotProduct (GLKVector3 vectorLeft, GLKVector3 vectorRight)
		{
			return vectorLeft.x * vectorRight.x + vectorLeft.y * vectorRight.y + vectorLeft.z * vectorRight.z;
		}

		/// <summary>
		/// <para>Returns the length of a vector.</para>
		/// <para>Original signature is 'float GLKVector3Length ( GLKVector3 vector ) {}'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="vector">MISSING</param>
		/// <returns>The length of the vector.</returns>
		public static float Length (GLKVector3 vector)
		{
			return (float)Math.Sqrt (vector.x * vector.x + vector.y * vector.y + vector.z * vector.z);
		}

		/// <summary>
		/// <para>Returns a new vector created by linearly interpreting between two vectors.</para>
		/// <para>Original signature is 'GLKVector3 GLKVector3Lerp ( GLKVector3 vectorStart, GLKVector3 vectorEnd, float t ) {}'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="vectorStart">MISSING</param>
		/// <param name="vectorEnd">MISSING</param>
		/// <param name="t">MISSING</param>
		/// <returns>A new vector.</returns>
		public static GLKVector3 Lerp (GLKVector3 vectorStart, GLKVector3 vectorEnd, float t)
		{
			GLKVector3 v = new GLKVector3 (vectorStart.x + ((vectorEnd.x - vectorStart.x) * t),
				vectorStart.y + ((vectorEnd.y - vectorStart.y) * t),
				vectorStart.z + ((vectorEnd.z - vectorStart.z) * t));
			return v;
		}

		/// <summary>
		/// <para>Returns a new three-component vector created from individual component values.</para>
		/// <para>Original signature is 'GLKVector3 GLKVector3Make ( float x, float y, float z ) {}'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="x">MISSING</param>
		/// <param name="y">MISSING</param>
		/// <param name="z">MISSING</param>
		/// <returns>An initialized vector.</returns>
		public static GLKVector3 Make (float x, float y, float z)
		{
			GLKVector3 v = new GLKVector3 (x, y, z);
			return v;
		}

		/// <summary>
		/// <para>Returns a new three-component vector created from an array of components.</para>
		/// <para>Original signature is 'GLKVector3 GLKVector3MakeWithArray ( float values[3] ) {}'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="values">MISSING</param>
		/// <returns>The array.</returns>
		public static GLKVector3 MakeWithArray (IntPtr values)
		{
			throw new NotImplementedException ();
		}

		/// <summary>
		/// <para>Returns a new vector whose component value at each position is the largest component value at the same position in the source vectors.</para>
		/// <para>Original signature is 'GLKVector3 GLKVector3Maximum ( GLKVector3 vectorLeft, GLKVector3 vectorRight ) {}'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="vectorLeft">MISSING</param>
		/// <param name="vectorRight">MISSING</param>
		/// <returns>A new vector.</returns>
		public static GLKVector3 Maximum (GLKVector3 vectorLeft, GLKVector3 vectorRight)
		{
			GLKVector3 max = vectorLeft;
			if (vectorRight.x > vectorLeft.x)
				max.x = vectorRight.x;
			if (vectorRight.y > vectorLeft.y)
				max.y = vectorRight.y;
			if (vectorRight.z > vectorLeft.z)
				max.z = vectorRight.z;
			return max;
		}

		/// <summary>
		/// <para>Returns a new vector whose component value at each position is the smallest component value at the same position in the source vectors.</para>
		/// <para>Original signature is 'GLKVector3 GLKVector3Minimum ( GLKVector3 vectorLeft, GLKVector3 vectorRight ) {}'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="vectorLeft">MISSING</param>
		/// <param name="vectorRight">MISSING</param>
		/// <returns>A new vector.</returns>
		public static GLKVector3 Minimum (GLKVector3 vectorLeft, GLKVector3 vectorRight)
		{
			GLKVector3 min = vectorLeft;
			if (vectorRight.x < vectorLeft.x)
				min.x = vectorRight.x;
			if (vectorRight.y < vectorLeft.y)
				min.y = vectorRight.y;
			if (vectorRight.z < vectorLeft.z)
				min.z = vectorRight.z;
			return min;
		}

		/// <summary>
		/// <para>Returns the product of two vectors.</para>
		/// <para>Original signature is 'GLKVector3 GLKVector3Multiply ( GLKVector3 vectorLeft, GLKVector3 vectorRight ) {}'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="vectorLeft">MISSING</param>
		/// <param name="vectorRight">MISSING</param>
		/// <returns>A new vector whose components each represent the product of the components found in the same positions of the two source vectors.</returns>
		public static GLKVector3 Multiply (GLKVector3 vectorLeft, GLKVector3 vectorRight)
		{
			GLKVector3 v = new GLKVector3 (vectorLeft.x * vectorRight.x,
				vectorLeft.y * vectorRight.y,
				vectorLeft.z * vectorRight.z);
			return v;
		}

		/// <summary>
		/// <para>Returns a new vector created by multiplying each component of a vector by a scalar value.</para>
		/// <para>Original signature is 'GLKVector3 GLKVector3MultiplyScalar ( GLKVector3 vector, float value ) {}'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="vector">MISSING</param>
		/// <param name="value">MISSING</param>
		/// <returns>A new vector.</returns>
		public static GLKVector3 MultiplyScalar (GLKVector3 vector, float value)
		{
			GLKVector3 v = new GLKVector3 (vector.x * value,
				vector.y * value,
				vector.z * value);
			return v;   
		}

		/// <summary>
		/// <para>Returns a new vector created by negating the component values of another vector.</para>
		/// <para>Original signature is 'GLKVector3 GLKVector3Negate ( GLKVector3 vector ) {}'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="vector">MISSING</param>
		/// <returns>A new vector.</returns>
		public static GLKVector3 Negate (GLKVector3 vector)
		{
			GLKVector3 v = new GLKVector3 (-vector.x, -vector.y, -vector.z);
			return v;
		}

		/// <summary>
		/// <para>Returns a new vector created by normalizing the input vector to a length of 1.0.</para>
		/// <para>Original signature is 'GLKVector3 GLKVector3Normalize ( GLKVector3 vector ) {}'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="vector">MISSING</param>
		/// <returns>A new vector.</returns>
		public static GLKVector3 Normalize (GLKVector3 vector)
		{
			float scale = 1.0f / GLKVector3.Length (vector);
			GLKVector3 v = new GLKVector3 (vector.x * scale, vector.y * scale, vector.z * scale);
			return v;
		}

		/// <summary>
		/// <para>Returns a new vector created by projecting a vector onto another vector.</para>
		/// <para>Original signature is 'GLKVector3 GLKVector3Project ( GLKVector3 vectorToProject, GLKVector3 projectionVector ) {}'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="vectorToProject">MISSING</param>
		/// <param name="projectionVector">MISSING</param>
		/// <returns>A new vector.</returns>
		public static GLKVector3 Project (GLKVector3 vectorToProject, GLKVector3 projectionVector)
		{
			float scale = GLKVector3.DotProduct (projectionVector, vectorToProject) / GLKVector3.DotProduct (projectionVector, projectionVector);
			GLKVector3 v = GLKVector3.MultiplyScalar (projectionVector, scale);
			return v;
		}

		/// <summary>
		/// <para>Returns the difference between two vectors.</para>
		/// <para>Original signature is 'GLKVector3 GLKVector3Subtract ( GLKVector3 vectorLeft, GLKVector3 vectorRight ) {}'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="vectorLeft">MISSING</param>
		/// <param name="vectorRight">MISSING</param>
		/// <returns>A new vector whose components each represent the difference between the components found in the same positions of the two source vectors.</returns>
		public static GLKVector3 Subtract (GLKVector3 vectorLeft, GLKVector3 vectorRight)
		{
			GLKVector3 v = new GLKVector3 (vectorLeft.x - vectorRight.x,
				vectorLeft.y - vectorRight.y,
				vectorLeft.z - vectorRight.z);
			return v;
		}

		/// <summary>
		/// <para>Returns a new vector created by subtracting a scalar value from each component of a vector.</para>
		/// <para>Original signature is 'GLKVector3 GLKVector3SubtractScalar ( GLKVector3 vector, float value ) {}'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="vector">MISSING</param>
		/// <param name="value">MISSING</param>
		/// <returns>A new vector.</returns>
		public static GLKVector3 SubtractScalar (GLKVector3 vector, float value)
		{
			GLKVector3 v = new GLKVector3 (vector.x - value,
				vector.y - value,
				vector.z - value);
			return v;    
		}
	}
#endif
}
