//
// This file is part of Monobjc, a .NET/Objective-C bridge
// Copyright (C) 2007-2011 - Laurent Etiemble
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
namespace Monobjc.ApplicationServices
{
    /// <summary>
    /// Structure that wraps a floating-point value and is mapped to the CGFloat native type.
    /// </summary>
    [ObjectiveCUnderlyingType(typeof(float), Is64Bits = false)]
    [ObjectiveCUnderlyingType(typeof(double), Is64Bits = true)]
    public struct CGFloat
    {
        /// <summary>
        /// The wrapped value.
        /// </summary>
        public float value;

        /// <summary>
        /// Initializes a new instance of the <see cref="CGFloat"/> struct.
        /// </summary>
        /// <param name="value">The value.</param>
        public CGFloat(float value)
        {
            this.value = value;
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="CGFloat"/> to <see cref="System.Single"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator float(CGFloat value)
        {
            return value.value;
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="System.Single"/> to <see cref="CGFloat"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator CGFloat(float value)
        {
            return new CGFloat(value);
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="CGFloat"/> to <see cref="System.Double"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator double(CGFloat value)
        {
            return value.value;
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="System.Double"/> to <see cref="CGFloat"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator CGFloat(double value)
        {
            return new CGFloat((float)value);
        }
		
        /// <summary>
        /// Returns the a string representation of this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"></see> containing a representation of this instance.
        /// </returns>
		public override string ToString()
		{
			return this.value.ToString();
		}
    }
}