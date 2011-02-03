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
using Monobjc.ApplicationServices;

namespace Monobjc.Foundation
{
    public partial struct NSRect
    {
        /// <summary>
        /// Converts this instance to a <see cref="CGRect"/>
        /// </summary>
        /// <value>A new <see cref="CGRect"/> instance.</value>
        public CGRect CGRect
        {
            get { return NSRectToCGRect(this); }
        }

        /// <summary>
        /// Returns a Boolean value that indicates whether this rectangle completely encloses another.
        /// </summary>
        public bool ContainsRect(NSRect aRect)
        {
            return NSContainsRect(this, aRect);
        }

        /// <summary>
        /// Divides this rectangle into two new rectangles.
        /// </summary>
        public void DivideRect(ref NSRect slice,
                               ref NSRect remainder,
                               float amount,
                               NSRectEdge edge)
        {
            NSDivideRect(this, ref slice, ref remainder, amount, edge);
        }

        /// <summary>
        /// Returns the height of this rectangle.
        /// </summary>
        public float Height
        {
            get { return NSHeight(this); }
        }

        /// <summary>
        /// Creates a rectangle that insets this rectangle by a specified amount.
        /// </summary>
        public NSRect InsetRect(float dX, float dY)
        {
            return NSInsetRect(this, dX, dY);
        }

        /// <summary>
        /// Creates a rectangle with the sides of this rectangle to integer values.
        /// </summary>
        public NSRect IntegralRect()
        {
            return NSIntegralRect(this);
        }

        /// <summary>
        /// Calculates the intersection of this rectangle with the specified rectangle.
        /// </summary>
        public NSRect IntersectionRect(NSRect aRect)
        {
            return NSIntersectionRect(this, aRect);
        }

        /// <summary>
        /// Returns a Boolean value that indicates whether this rectangle and the specified rectangle intersect.
        /// </summary>
        public bool IntersectsRect(NSRect aRect)
        {
            return NSIntersectsRect(this, aRect);
        }

        /// <summary>
        /// Returns a Boolean value that indicates whether this rectangle is empty.
        /// </summary>
        public bool IsEmptyRect
        {
            get { return NSIsEmptyRect(this); }
        }

        /// <summary>
        /// Returns the largest x coordinate of the rectangle.
        /// </summary>
        public float MaxX
        {
            get { return NSMaxX(this); }
        }

        /// <summary>
        /// Returns the largest y coordinate of the rectangle.
        /// </summary>
        public float MaxY
        {
            get { return NSMaxY(this); }
        }

        /// <summary>
        /// Returns the x coordinate of the rectangle’s midpoint.
        /// </summary>
        public float MidX
        {
            get { return NSMidX(this); }
        }

        /// <summary>
        /// Returns the y coordinate of the rectangle’s midpoint.
        /// </summary>
        public float MidY
        {
            get { return NSMidY(this); }
        }

        /// <summary>
        /// Returns the smallest x coordinate of the rectangle.
        /// </summary>
        public float MinX
        {
            get { return NSMinX(this); }
        }

        /// <summary>
        /// Returns the smallest y coordinate of the rectangle.
        /// </summary>
        public float MinY
        {
            get { return NSMinY(this); }
        }

        /// <summary>
        /// Returns a Boolean value that indicates whether the point is in the rectangle.
        /// </summary>
        public bool MouseInRect(NSPoint aPoint, bool isFlipped)
        {
            return NSMouseInRect(aPoint, this, isFlipped);
        }

        /// <summary>
        /// Creates a rectangle that offsets this rectangle by the specified amount.
        /// </summary>
        public NSRect OffsetRect(float dX, float dY)
        {
            return NSOffsetRect(this, dX, dY);
        }

        /// <summary>
        /// Returns a Boolean value that indicates whether a given point is in a specified rectangle.
        /// </summary>
        public bool PointInRect(NSPoint aPoint)
        {
            return this.MouseInRect(aPoint, false);
        }

        /// <summary>
        /// Creates a rectangle as the union of this rectangle and the specified rectangle.
        /// </summary>
        public NSRect UnionRect(NSRect aRect)
        {
            return NSUnionRect(this, aRect);
        }

        /// <summary>
        /// Returns the width of the rectangle.
        /// </summary>
        public float Width
        {
            get { return NSWidth(this); }
        }
    }
}