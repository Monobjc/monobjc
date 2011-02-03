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
using System;

namespace Monobjc.ApplicationServices
{
    public partial struct CGRect
    {
        /// <summary>
        /// A <see cref="CGRect"/> with its origin and size set to zero.
        /// </summary>
        public static readonly CGRect CGRectZero = new CGRect();

        /// <summary>
        /// Indicates whether a rectangle contains a specified point.
        /// </summary>
        /// <param name="rect">The rectangle to examine.</param>
        /// <param name="point">The point to examine.</param>
        /// <returns>Returns 1 if the specified point is located within the specified rectangle; otherwise, 0.</returns>
        /// <remarks>Original declaration is : int CGRectContainsPoint ( CGRect rect, CGPoint point );</remarks>
        public static int CGRectContainsPoint(CGRect rect, CGPoint point)
        {
            return ((point.x >= CGRectGetMinX(rect)) &&
                    (point.x < CGRectGetMaxX(rect)) &&
                    (point.y >= CGRectGetMinY(rect)) &&
                    (point.y < CGRectGetMaxY(rect))) ? 1 : 0;
        }

        /// <summary>
        /// Indicates whether the first rectangle contains the second rectangle.
        /// </summary>
        /// <param name="rect1">The rectangle to examine for containment of the rectangle passed in rect2.</param>
        /// <param name="rect2">The rectangle to examine for being contained in the rectangle passed in rect1.</param>
        /// <returns>Returns 1 if the rectangle specified by rect2 is contained in the rectangle passed in rect1; otherwise, 0. The first rectangle contains the second if the union of the two rectangles is equal to the first rectangle.</returns>
        /// <remarks>Original declaration is : int CGRectContainsRect ( CGRect rect1, CGRect rect2 );</remarks>
        public static int CGRectContainsRect(CGRect rect1, CGRect rect2)
        {
            return ((CGRectIsEmpty(rect2) == 0) &&
                    (CGRectGetMinX(rect1) <= CGRectGetMinX((rect2))) &&
                    (CGRectGetMinY(rect1) <= CGRectGetMinY((rect2))) &&
                    (CGRectGetMaxX(rect1) >= CGRectGetMaxX((rect2))) &&
                    (CGRectGetMaxY(rect1) >= CGRectGetMaxY((rect2)))) ? 1 : 0;
        }

        /// <summary>
        /// Divides a source rectangle into two component rectangles.
        /// </summary>
        /// <param name="rect">The source rectangle.</param>
        /// <param name="slice">On input, a pointer to an uninitialized rectangle. On return, a rectangle that contains the specified edge and extends the distance beyond it specified by the amount parameter.</param>
        /// <param name="remainder">On input, a pointer to an uninitialized rectangle. On return, the rectangle contains the portion of the source rectangle that remains after CGRectEdge produces the “slice” rectangle.</param>
        /// <param name="amount">A distance from the rectangle’s side that is specified in the edge parameter. This distance defines the line, parallel to the specified side, that Quartz uses to divide the source rectangle.</param>
        /// <param name="edge">A CGRectEdge value (CGRectMinXEdge, CGRectMinYEdge, CGRectMaxXEdge, or CGRectMaxYEdge) that specifies the side of the rectangle from which the distance passed in the amount parameter is measured. CGRectDivide produces a “slice” rectangle that contains the specified edge and extends amount distance beyond it.</param>
        /// <returns>Returns 1 if the two specified rectangles have equal size and origin values, or are both null. Otherwise, returns 0.</returns>
        /// <remarks>Original declaration is : void CGRectDivide ( CGRect rect, CGRect *slice, CGRect *remainder, float amount, CGRectEdge edge );</remarks>
        public static void CGRectDivide(CGRect rect, ref CGRect slice, ref CGRect remainder, float amount, CGRectEdge edge)
        {
            if (CGRectIsEmpty(rect) == 1)
            {
                slice = CGRectZero;
                remainder = CGRectZero;
            }

            switch (edge)
            {
                case CGRectEdge.CGRectMinXEdge:
                    {
                        float delta = amount;
                        if (amount > rect.size.width)
                        {
                            delta = rect.size.width;
                        }

                        slice = CGRectMake(rect.origin.x,
                                           rect.origin.y,
                                           delta,
                                           rect.size.height);
                        remainder = CGRectMake(rect.origin.x + delta,
                                               rect.origin.y,
                                               rect.size.width - delta,
                                               rect.size.height);
                    }
                    break;
                case CGRectEdge.CGRectMinYEdge:
                    {
                        float delta = amount;
                        if (amount > rect.size.height)
                        {
                            delta = rect.size.height;
                        }

                        slice = CGRectMake(rect.origin.x,
                                           rect.origin.y,
                                           rect.size.width,
                                           delta);
                        remainder = CGRectMake(rect.origin.x,
                                               rect.origin.y + delta,
                                               rect.size.width,
                                               rect.size.height - delta);
                    }
                    break;
                case CGRectEdge.CGRectMaxXEdge:
                    {
                        float delta = amount;
                        if (amount > rect.size.width)
                        {
                            delta = rect.size.width;
                        }

                        slice = CGRectMake(rect.origin.x + rect.size.width - delta,
                                           rect.origin.y,
                                           delta,
                                           rect.size.height);
                        remainder = CGRectMake(rect.origin.x,
                                               rect.origin.y,
                                               rect.size.width - delta,
                                               rect.size.height);
                    }
                    break;
                case CGRectEdge.CGRectMaxYEdge:
                    {
                        float delta = amount;
                        if (amount > rect.size.height)
                        {
                            delta = rect.size.height;
                        }

                        slice = CGRectMake(rect.origin.x,
                                           rect.origin.y + rect.size.height - delta,
                                           rect.size.width,
                                           delta);
                        remainder = CGRectMake(rect.origin.x,
                                               rect.origin.y,
                                               rect.size.width,
                                               rect.size.height - delta);
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException("edge");
            }
        }

        /// <summary>
        /// Indicates whether two rectangles are equal in size and position.
        /// </summary>
        /// <param name="rect1">The first rectangle to examine.</param>
        /// <param name="rect2">The second rectangle to examine.</param>
        /// <returns>Returns 1 if the two specified rectangles have equal size and origin values, or are both null. Otherwise, returns 0.</returns>
        /// <remarks>Original declaration is : int CGRectEqualToRect ( CGRect rect1, CGRect rect2 );</remarks>
        public static int CGRectEqualToRect(CGRect rect1, CGRect rect2)
        {
            return Equals(rect1, rect2) ? 1 : 0;
        }

        /// <summary>
        /// Returns the height of a rectangle.
        /// </summary>
        /// <param name="rect">The rectangle to examine.</param>
        /// <returns>The height of the specified rectangle.</returns>
        /// <remarks>Original declaration is : float CGRectGetHeight ( CGRect rect );</remarks>
        public static float CGRectGetHeight(CGRect rect)
        {
            return rect.size.height;
        }

        /// <summary>
        /// Returns the x-axis coordinate that establishes the right edge of a rectangle.
        /// </summary>
        /// <param name="rect">The rectangle to examine.</param>
        /// <returns>The x-coordinate of the top-right corner of the specified rectangle.</returns>
        /// <remarks>Original declaration is : float CGRectGetMaxX ( CGRect rect );</remarks>
        public static float CGRectGetMaxX(CGRect rect)
        {
            return rect.origin.x + rect.size.width;
        }

        /// <summary>
        /// Returns the y-axis coordinate that establishes the top edge of a rectangle.
        /// </summary>
        /// <param name="rect">The rectangle to examine.</param>
        /// <returns>The y-coordinate of the top-right corner of the specified rectangle.</returns>
        /// <remarks>Original declaration is : float CGRectGetMaxY ( CGRect rect );</remarks>
        public static float CGRectGetMaxY(CGRect rect)
        {
            return rect.origin.y + rect.size.height;
        }

        /// <summary>
        /// Returns the x-axis coordinate that establishes the center of a rectangle.
        /// </summary>
        /// <param name="rect">The rectangle to examine.</param>
        /// <returns>The x-coordinate of the center of the specified rectangle.</returns>
        /// <remarks>Original declaration is : float CGRectGetMidX ( CGRect rect );</remarks>
        public static float CGRectGetMidX(CGRect rect)
        {
            return rect.origin.x + (rect.size.width/2.0f);
        }

        /// <summary>
        /// Returns the y-axis coordinate that establishes the center of a rectangle.
        /// </summary>
        /// <param name="rect">The rectangle to examine.</param>
        /// <returns>The y-coordinate of the center of the specified rectangle.</returns>
        /// <remarks>Original declaration is : float CGRectGetMidY ( CGRect rect );</remarks>
        public static float CGRectGetMidY(CGRect rect)
        {
            return rect.origin.y + (rect.size.height/2.0f);
        }

        /// <summary>
        /// Returns the x-axis coordinate that establishes the left edge of a rectangle.
        /// </summary>
        /// <param name="rect">The rectangle to examine.</param>
        /// <returns>The x-coordinate of the bottom-left corner of the specified rectangle.</returns>
        /// <remarks>Original declaration is : float CGRectGetMinX ( CGRect rect );</remarks>
        public static float CGRectGetMinX(CGRect rect)
        {
            return rect.origin.x;
        }

        /// <summary>
        /// Returns the y-axis coordinate that establishes the bottom edge of a rectangle.
        /// </summary>
        /// <param name="rect">The rectangle to examine.</param>
        /// <returns>The y-coordinate of the bottom-left corner of the specified rectangle.</returns>
        /// <remarks>Original declaration is : float CGRectGetMinY ( CGRect rect );</remarks>
        public static float CGRectGetMinY(CGRect rect)
        {
            return rect.origin.y;
        }

        /// <summary>
        /// Returns the width of a rectangle.
        /// </summary>
        /// <param name="rect">The rectangle to examine.</param>
        /// <returns>The width of the specified rectangle.</returns>
        /// <remarks>Original declaration is : float CGRectGetWidth ( CGRect rect );</remarks>
        public static float CGRectGetWidth(CGRect rect)
        {
            return rect.size.width;
        }

        /// <summary>
        /// Returns a rectangle that is smaller or larger than the source rectangle, with the same center point.
        /// </summary>
        /// <param name="rect">The source rectangle.</param>
        /// <param name="dx">The value by which to adjust the x-coordinates of the source rectangle. To create an inset rectangle, specify a positive value. To create a larger, encompassing rectangle, specify a negative value.</param>
        /// <param name="dy">The value by which to adjust the y-coordinates of the source rectangle. To create an inset rectangle, specify a positive value. To create a larger, encompassing rectangle, specify a negative value.</param>
        /// <returns>A rectangle with its origin offset in the x-axis by the distance specified by the dx parameter and in the y-axis by the distance specified by the dy parameter, and its size adjusted by (2*dx,2*dy), relative to the source rectangle. If dx and dy are positive values, then the rectangle’s size is decreased. If dx and dy are negative values, the rectangle’s size is increased.</returns>
        /// <remarks>Original declaration is : CGRect CGRectInset ( CGRect rect, float dx, float dy );</remarks>
        public static CGRect CGRectInset(CGRect rect, float dx, float dy)
        {
            return CGRectMake(rect.origin.x + dx,
                              rect.origin.y + dy,
                              rect.size.width - 2*dx,
                              rect.size.height - 2*dy);
        }

        /// <summary>
        /// Returns a rectangle with integer values for its origin and size.
        /// </summary>
        /// <param name="rect">The source rectangle.</param>
        /// <returns>The rectangle with smallest integer values for its origin and size that contains the source rectangle. That is, given a rectangle with fractional origin or size values, CGRectIntegral rounds the rectangle’s origin downward and its size upward to the nearest whole integers, such that the result contains the original rectangle.</returns>
        /// <remarks>Original declaration is : CGRect CGRectIntegral ( CGRect rect );</remarks>
        public static CGRect CGRectIntegral(CGRect rect)
        {
            CGRect result = new CGRect();
            result.origin.x = (float)Math.Floor(rect.origin.x);
            result.origin.y = (float)Math.Floor(rect.origin.y);
            result.size.width = (float)Math.Ceiling(rect.origin.x + rect.size.width) - result.origin.x;
            result.size.height = (float)Math.Ceiling(rect.origin.y + rect.size.height) - result.origin.y;
            return result;
        }

        /// <summary>
        /// Returns the intersection of two rectangles.
        /// </summary>
        /// <param name="rect1">The first source rectangle.</param>
        /// <param name="rect2">The second source rectangle.</param>
        /// <returns>A rectangle that is the intersection of the two specified rectangles. If the two rectangles do not intersect, returns the null rectangle. To check for this condition, use CGRectIsNull.</returns>
        /// <remarks>Original declaration is : CGRect CGRectIntersection ( CGRect rect1, CGRect rect2 );</remarks>
        public static CGRect CGRectIntersection(CGRect rect1, CGRect rect2)
        {
            if (((CGRectGetMaxX(rect1) <= CGRectGetMinX(rect2)) || (CGRectGetMaxX(rect2) <= CGRectGetMinX(rect1))) ||
                ((CGRectGetMaxY(rect1) <= CGRectGetMinY(rect2)) || (CGRectGetMaxY(rect2) <= CGRectGetMinY(rect1))))
            {
                return CGRectZero;
            }

            CGRect result = new CGRect();

            result.origin.x = (CGRectGetMinX(rect1) <= CGRectGetMinX(rect2)) ? CGRectGetMinX(rect2) : CGRectGetMinX(rect1);
            result.origin.y = (CGRectGetMinY(rect1) <= CGRectGetMinY(rect2)) ? CGRectGetMinY(rect2) : CGRectGetMinY(rect1);

            result.size.width = (CGRectGetMaxX(rect1) >= CGRectGetMaxX(rect2)) ? (CGRectGetMaxX(rect2) - result.origin.x) : (CGRectGetMaxX(rect1) - result.origin.x);
            result.size.height = (CGRectGetMaxY(rect1) >= CGRectGetMaxY(rect2)) ? (CGRectGetMaxY(rect2) - result.origin.y) : (CGRectGetMaxY(rect1) - result.origin.y);

            return result;
        }

        /// <summary>
        /// Indicates whether two rectangles intersect.
        /// </summary>
        /// <param name="rect1">The first rectangle to examine.</param>
        /// <param name="rect2">The second rectangle to examine.</param>
        /// <returns>Returns 1 if the two specified rectangles intersect; otherwise, 0. The first rectangle intersects the second if the intersection of the rectangles is not equal to the null rectangle.</returns>
        /// <remarks>Original declaration is : int CGRectIntersectsRect ( CGRect rect1, CGRect rect2 );</remarks>
        public static int CGRectIntersectsRect(CGRect rect1, CGRect rect2)
        {
            return (((CGRectGetMaxX(rect1) <= CGRectGetMinX(rect2)) || (CGRectGetMaxX(rect2) <= CGRectGetMinX(rect1))) ||
                    ((CGRectGetMaxY(rect1) <= CGRectGetMinY(rect2)) || (CGRectGetMaxY(rect2) <= CGRectGetMinY(rect1))))
                       ? 0
                       : 1;
        }

        /// <summary>
        /// Indicates whether a rectangle has zero width or height or is a null rectangle.
        /// </summary>
        /// <param name="rect">The rectangle to examine.</param>
        /// <returns>Returns 1 if the specified rectangle is empty; otherwise, 0.</returns>
        /// <remarks>Original declaration is : int CGRectIsEmpty ( CGRect rect );</remarks>
        public static int CGRectIsEmpty(CGRect rect)
        {
            return ((rect.size.width > 0) && (rect.size.height > 0)) ? 0 : 1;
        }

        /// <summary>
        /// Checks whether a rectangle is infinite.
        /// </summary>
        /// <param name="rect">The rectangle to examine.</param>
        /// <returns>Returns true if the specified rectangle is infinite, false otherwise.</returns>
        /// <remarks>Original declaration is : bool CGRectIsInfinite ( CGRect rect );</remarks>
        public static bool CGRectIsInfinite(CGRect rect)
        {
            return false;
        }

        /// <summary>
        /// Indicates whether a rectangle is invalid.
        /// </summary>
        /// <param name="rect">The rectangle to examine.</param>
        /// <returns>Returns 1 if the specified rectangle is null; otherwise, 0.</returns>
        /// <remarks>Original declaration is : int CGRectIsNull ( CGRect rect );</remarks>
        public static int CGRectIsNull(CGRect rect)
        {
            return 0;
        }

        /// <summary>
        /// Returns a rectangle structure constructed from coordinate and dimension values you provide.
        /// </summary>
        /// <param name="x">The x-coordinate of the rectangle’s origin point.</param>
        /// <param name="y">The y-coordinate of the rectangle’s origin point.</param>
        /// <param name="width">The width of the rectangle.</param>
        /// <param name="height">The height of the rectangle.</param>
        /// <returns>Returns a rectangle with the specified location and dimensions.</returns>
        /// <remarks>Original declaration is : CGRect CGRectMake ( float x, float y, float width, float height );</remarks>
        public static CGRect CGRectMake(float x, float y, float width, float height)
        {
            return new CGRect(x, y, width, height);
        }

        /// <summary>
        /// Returns a rectangle with an origin offset from that of the source rectangle.
        /// </summary>
        /// <param name="rect">The source rectangle.</param>
        /// <param name="dx">The value by which to move the x-coordinate of the source rectangle’s origin.</param>
        /// <param name="dy">The value by which to move the y-coordinate of the source rectangle’s origin.</param>
        /// <returns>A rectangle with the same size as the source, but with its origin offset by dx units along the x-axis and dy units along the y-axis with respect to the source.</returns>
        /// <remarks>Original declaration is : CGRect CGRectOffset ( CGRect rect, float dx, float dy );</remarks>
        public static CGRect CGRectOffset(CGRect rect, float dx, float dy)
        {
            return CGRectMake(rect.origin.x + dx,
                              rect.origin.y + dy,
                              rect.size.width,
                              rect.size.height);
        }

        /// <summary>
        /// Returns a rectangle with a positive width and height.
        /// </summary>
        /// <param name="rect">The source rectangle.</param>
        /// <returns>Returns a rectangle, equivalent to the source rectangle, with a positive width and height.</returns>
        /// <remarks>Original declaration is : CGRect CGRectStandardize ( CGRect rect );</remarks>
        public static CGRect CGRectStandardize(CGRect rect)
        {
            bool horiz = (rect.size.width > 0);
            bool vert = (rect.size.height > 0);
            float w = horiz ? rect.size.width : -rect.size.width;
            float h = horiz ? rect.size.height : -rect.size.height;
            float x = horiz ? rect.origin.x : rect.origin.x - w;
            float y = vert ? rect.origin.y : rect.origin.y - h;
            return CGRectMake(x, y, w, h);
        }

        /// <summary>
        /// Returns the smallest rectangle that contains two other specified rectangles.
        /// </summary>
        /// <param name="r1">The first source rectangle.</param>
        /// <param name="r2">The second source rectangle.</param>
        /// <returns>The smallest rectangle that completely contains both of the source rectangles.</returns>
        /// <remarks>Original declaration is : CGRect CGRectUnion ( CGRect r1, CGRect r2 );</remarks>
        public static CGRect CGRectUnion(CGRect r1, CGRect r2)
        {
            if ((CGRectIsEmpty(r1) == 1) && (CGRectIsEmpty(r2) == 2))
            {
                return CGRectZero;
            }
            else if (CGRectIsEmpty(r1) == 1)
            {
                return r2;
            }
            else if (CGRectIsEmpty(r2) == 1)
            {
                return r1;
            }

            CGRect result = CGRectMake(Math.Min(CGRectGetMinX(r1), CGRectGetMinX(r2)),
                                       Math.Min(CGRectGetMinY(r1), CGRectGetMinY(r2)),
                                       Math.Max(CGRectGetMaxX(r1), CGRectGetMaxX(r2)),
                                       Math.Max(CGRectGetMaxY(r1), CGRectGetMaxY(r2)));
            return result;
        }
    }
}