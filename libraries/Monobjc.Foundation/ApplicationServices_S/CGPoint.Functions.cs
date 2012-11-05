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
namespace Monobjc.ApplicationServices
{
    public partial struct CGPoint
    {
        /// <summary>
        /// A <see cref="CGRect"/> with its x and y set to zero.
        /// </summary>
        public static readonly CGPoint CGPointZero = new CGPoint();

        /// <summary>
        /// Indicates whether two points are equal.
        /// </summary>
        /// <param name="point1">The first point to examine.</param>
        /// <param name="point2">The second point to examine.</param>
        /// <returns>Returns 1 if the two specified points are the same; otherwise, 0.</returns>
        /// <remarks>Original declaration is : int CGPointEqualToPoint ( CGPoint point1, CGPoint point2 );</remarks>
        public static int CGPointEqualToPoint(CGPoint point1, CGPoint point2)
        {
            return Equals(point1, point2) ? 1 : 0;
        }

        /// <summary>
        /// Returns a point structure constructed from coordinate values you provide.
        /// </summary>
        /// <param name="x">The x-coordinate of the point to construct.</param>
        /// <param name="y">The y-coordinate of the point to construct.</param>
        /// <returns>Returns a CGPoint structure, representing a single (x,y) coordinate pair.</returns>
        /// <remarks>Original declaration is : CGPoint CGPointMake ( float x, float y );</remarks>
		public static CGPoint CGPointMake(CGFloat x, CGFloat y)
        {
            return new CGPoint(x, y);
        }
    }
}