//
// This file is part of Monobjc, a .NET/Objective-C bridge
// Copyright (C) 2007-2013 - Laurent Etiemble
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
    public partial struct CGRect
    {
        /// <summary>
        /// Returns an int value that indicates whether this rectangle completely encloses another.
        /// </summary>
        public int ContainsRect(CGRect aRect)
        {
            return CGRectContainsRect(this, aRect);
        }

        /// <summary>
        /// Divides this rectangle into two new rectangles.
        /// </summary>
        public void DivideRect(ref CGRect slice,
                               ref CGRect remainder,
                               CGFloat amount,
                               CGRectEdge edge)
        {
            CGRectDivide(this, ref slice, ref remainder, amount, edge);
        }

        /// <summary>
        /// Returns the height of this rectangle.
        /// </summary>
		public CGFloat Height
        {
            get { return CGRectGetHeight(this); }
        }

        /// <summary>
        /// Creates a rectangle that insets this rectangle by a specified amount.
        /// </summary>
		public CGRect InsetRect(CGFloat dX, CGFloat dY)
        {
            return CGRectInset(this, dX, dY);
        }

        /// <summary>
        /// Creates a rectangle with the sides of this rectangle to integer values.
        /// </summary>
        public CGRect IntegralRect()
        {
            return CGRectIntegral(this);
        }

        /// <summary>
        /// Calculates the intersection of this rectangle with the specified rectangle.
        /// </summary>
        public CGRect IntersectionRect(CGRect aRect)
        {
            return CGRectIntersection(this, aRect);
        }

        /// <summary>
        /// Returns an int value that indicates whether this rectangle and the specified rectangle intersect.
        /// </summary>
        public int IntersectsRect(CGRect aRect)
        {
            return CGRectIntersectsRect(this, aRect);
        }

        /// <summary>
        /// Returns an int value that indicates whether this rectangle is empty.
        /// </summary>
        public int IsEmptyRect
        {
            get { return CGRectIsEmpty(this); }
        }

        /// <summary>
        /// Returns the largest x coordinate of the rectangle.
        /// </summary>
		public CGFloat MaxX
        {
            get { return CGRectGetMaxX(this); }
        }

        /// <summary>
        /// Returns the largest y coordinate of the rectangle.
        /// </summary>
		public CGFloat MaxY
        {
            get { return CGRectGetMaxY(this); }
        }

        /// <summary>
        /// Returns the x coordinate of the rectangle's midpoint.
        /// </summary>
		public CGFloat MidX
        {
            get { return CGRectGetMidX(this); }
        }

        /// <summary>
        /// Returns the y coordinate of the rectangle's midpoint.
        /// </summary>
		public CGFloat MidY
        {
            get { return CGRectGetMidY(this); }
        }

        /// <summary>
        /// Returns the smallest x coordinate of the rectangle.
        /// </summary>
		public CGFloat MinX
        {
            get { return CGRectGetMinX(this); }
        }

        /// <summary>
        /// Returns the smallest y coordinate of the rectangle.
        /// </summary>
		public CGFloat MinY
        {
            get { return CGRectGetMinY(this); }
        }

        /// <summary>
        /// Creates a rectangle that offsets this rectangle by the specified amount.
        /// </summary>
		public CGRect OffsetRect(CGFloat dX, CGFloat dY)
        {
            return CGRectOffset(this, dX, dY);
        }

        /// <summary>
        /// Returns an int value that indicates whether a given point is in a specified rectangle.
        /// </summary>
        public int PointInRect(CGPoint aPoint)
        {
            return CGRectContainsPoint(this, aPoint);
        }

        /// <summary>
        /// Creates a rectangle as the union of this rectangle and the specified rectangle.
        /// </summary>
        public CGRect UnionRect(CGRect aRect)
        {
            return CGRectUnion(this, aRect);
        }

        /// <summary>
        /// Returns the width of the rectangle.
        /// </summary>
		public CGFloat Width
        {
            get { return CGRectGetWidth(this); }
        }
    }
}