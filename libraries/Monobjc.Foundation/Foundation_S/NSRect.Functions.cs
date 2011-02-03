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
using System.Runtime.InteropServices;
using Monobjc.ApplicationServices;

namespace Monobjc.Foundation
{
    public partial struct NSRect
    {
        /// <summary>
        /// A <see cref="NSRect"/> with its origin and size set to zero.
        /// </summary>
        public static readonly NSRect NSZeroRect = new NSRect();

		/// <summary>
		/// Converts a <see cref="CGRect"/> instance to a <see cref="NSRect"/>
		/// </summary>
		/// <param name="cgrect">The <see cref="CGRect"/> to convert.</param>
		/// <returns>A new <see cref="NSRect"/> instance.</returns>
		public static NSRect NSRectFromCGRect(CGRect cgrect)
		{
			return NSMakeRect(cgrect.origin.x, cgrect.origin.y, cgrect.size.width, cgrect.size.height);
		}
		
		/// <summary>
		/// Converts a <see cref="NSRect"/> instance to a <see cref="CGRect"/>
		/// </summary>
		/// <param name="nsrect">The <see cref="NSRect"/> to convert.</param>
		/// <returns>A new <see cref="CGRect"/> instance.</returns>
		public static CGRect NSRectToCGRect(NSRect nsrect)
		{
			return CGRect.CGRectMake(nsrect.origin.x, nsrect.origin.y, nsrect.size.width, nsrect.size.height);
		}
		
        /// <summary>
        /// Returns a Boolean value that indicates whether one rectangle completely encloses another.
        /// </summary>
        /// <remarks>Original declaration is : BOOL NSContainsRect(NSRect aRect, NSRect bRect)</remarks>
        public static bool NSContainsRect(NSRect aRect, NSRect bRect)
        {
            return (!NSIsEmptyRect(bRect) &&
                    (NSMinX(aRect) <= NSMinX((bRect))) &&
                    (NSMinY(aRect) <= NSMinY((bRect))) &&
                    (NSMaxX(aRect) >= NSMaxX((bRect))) &&
                    (NSMaxY(aRect) >= NSMaxY((bRect))));
        }

        /// <summary>
        /// Divides a rectangle into two new rectangles.
        /// </summary>
        /// <remarks>Original declaration is : void NSDivideRect(NSRect inRect, NSRect *slice, NSRect *remainder, float amount, NSRectEdge edge)</remarks>
        public static void NSDivideRect(NSRect inRect,
                                               ref NSRect slice,
                                               ref NSRect remainder,
                                               float amount,
                                               NSRectEdge edge)
        {
            if (NSIsEmptyRect(inRect))
            {
                slice = NSZeroRect;
                remainder = NSZeroRect;
            }

            switch (edge)
            {
                case NSRectEdge.NSMinXEdge:
                    {
                        float delta = amount;
                        if (amount > inRect.size.width)
                        {
                            delta = inRect.size.width;
                        }

                        slice = NSMakeRect(inRect.origin.x,
                                           inRect.origin.y,
                                           delta,
                                           inRect.size.height);
                        remainder = NSMakeRect(inRect.origin.x + delta,
                                               inRect.origin.y,
                                               inRect.size.width - delta,
                                               inRect.size.height);
                    }
                    break;
                case NSRectEdge.NSMinYEdge:
                    {
                        float delta = amount;
                        if (amount > inRect.size.height)
                        {
                            delta = inRect.size.height;
                        }

                        slice = NSMakeRect(inRect.origin.x,
                                           inRect.origin.y,
                                           inRect.size.width,
                                           delta);
                        remainder = NSMakeRect(inRect.origin.x,
                                               inRect.origin.y + delta,
                                               inRect.size.width,
                                               inRect.size.height - delta);
                    }
                    break;
                case NSRectEdge.NSMaxXEdge:
                    {
                        float delta = amount;
                        if (amount > inRect.size.width)
                        {
                            delta = inRect.size.width;
                        }

                        slice = NSMakeRect(inRect.origin.x + inRect.size.width - delta,
                                           inRect.origin.y,
                                           delta,
                                           inRect.size.height);
                        remainder = NSMakeRect(inRect.origin.x,
                                               inRect.origin.y,
                                               inRect.size.width - delta,
                                               inRect.size.height);
                    }
                    break;
                case NSRectEdge.NSMaxYEdge:
                    {
                        float delta = amount;
                        if (amount > inRect.size.height)
                        {
                            delta = inRect.size.height;
                        }

                        slice = NSMakeRect(inRect.origin.x,
                                           inRect.origin.y + inRect.size.height - delta,
                                           inRect.size.width,
                                           delta);
                        remainder = NSMakeRect(inRect.origin.x,
                                               inRect.origin.y,
                                               inRect.size.width,
                                               inRect.size.height - delta);
                    } 
                    break;
                default:
                    throw new ArgumentOutOfRangeException("edge");
            }
        }

        /// <summary>
        /// Returns a Boolean value that indicates whether the two rectangles are equal.
        /// </summary>
        /// <remarks>Original declaration is : BOOL NSEqualRects(NSRect aRect, NSRect bRect)</remarks>
        public static bool NSEqualRects(NSRect aRect,
                                        NSRect bRect)
        {
            return Equals(aRect, bRect);
        }

        /// <summary>
        /// Returns the height of a given rectangle.
        /// </summary>
        /// <remarks>Original declaration is : float NSHeight(NSRect aRect)</remarks>
        public static float NSHeight(NSRect aRect)
        {
            return aRect.size.height;
        }

        /// <summary>
        /// Insets a rectangle by a specified amount.
        /// </summary>
        /// <remarks>Original declaration is : NSRect NSInsetRect(NSRect aRect, float dX, float dY)</remarks>
        public static NSRect NSInsetRect(NSRect aRect,
                                                float dX,
                                                float dY)
        {
            return new NSRect(aRect.origin.x + dX,
                              aRect.origin.y + dY,
                              aRect.size.width - 2 * dX,
                              aRect.size.height - 2 * dY);
        }

        /// <summary>
        /// Adjusts the sides of a rectangle to integer values.
        /// </summary>
        /// <remarks>Original declaration is : NSRect NSIntegralRect(NSRect aRect)</remarks>
        public static NSRect NSIntegralRect(NSRect aRect)
        {
            NSRect result = new NSRect();
            result.origin.x = (float)Math.Floor(aRect.origin.x);
            result.origin.y = (float)Math.Floor(aRect.origin.y);
            result.size.width = (float)Math.Ceiling(aRect.origin.x + aRect.size.width) - result.origin.x;
            result.size.height = (float)Math.Ceiling(aRect.origin.y + aRect.size.height) - result.origin.y;
            return result;
        }

        /// <summary>
        /// Calculates the intersection of two rectangles.
        /// </summary>
        /// <remarks>Original declaration is : NSRect NSIntersectionRect(NSRect aRect, NSRect bRect)</remarks>
        public static NSRect NSIntersectionRect(NSRect aRect, NSRect bRect)
        {
            if (((NSMaxX(aRect) <= NSMinX(bRect)) || (NSMaxX(bRect) <= NSMinX(aRect))) ||
                ((NSMaxY(aRect) <= NSMinY(bRect)) || (NSMaxY(bRect) <= NSMinY(aRect))))
            {
                return NSZeroRect;
            }

            NSRect result = new NSRect();

            result.origin.x = (NSMinX(aRect) <= NSMinX(bRect)) ? NSMinX(bRect) : NSMinX(aRect);
            result.origin.y = (NSMinY(aRect) <= NSMinY(bRect)) ? NSMinY(bRect) : NSMinY(aRect);

            result.size.width = (NSMaxX(aRect) >= NSMaxX(bRect)) ? (NSMaxX(bRect) - result.origin.x) : (NSMaxX(aRect) - result.origin.x);
            result.size.height = (NSMaxY(aRect) >= NSMaxY(bRect)) ? (NSMaxY(bRect) - result.origin.y) : (NSMaxY(aRect) - result.origin.y);

            return result;
        }

        /// <summary>
        /// Returns a Boolean value that indicates whether two rectangles intersect.
        /// </summary>
        /// <remarks>Original declaration is : BOOL NSIntersectsRect(NSRect aRect, NSRect bRect)</remarks>
        public static bool NSIntersectsRect(NSRect aRect, NSRect bRect)
        {
            return (((NSMaxX(aRect) <= NSMinX(bRect)) || (NSMaxX(bRect) <= NSMinX(aRect))) ||
                    ((NSMaxY(aRect) <= NSMinY(bRect)) || (NSMaxY(bRect) <= NSMinY(aRect))))
                       ? false
                       : true;
        }

        /// <summary>
        /// Returns a Boolean value that indicates whether a given rectangle is empty.
        /// </summary>
        /// <remarks>Original declaration is : BOOL NSIsEmptyRect(NSRect aRect)</remarks>
        public static bool NSIsEmptyRect(NSRect aRect)
        {
            return ((aRect.size.width > 0) && (aRect.size.height > 0)) ? false : true;
        }

        /// <summary>
        /// Creates a new NSRect from the specified values.
        /// </summary>
        /// <remarks>Original declaration is : NSRect NSMakeRect(float x, float y, float w, float h)</remarks>
        public static NSRect NSMakeRect(float x, float y, float w, float h)
        {
            return new NSRect(x, y, w, h);
        }

        /// <summary>
        /// Returns the largest x coordinate of a given rectangle.
        /// </summary>
        /// <remarks>Original declaration is : float NSMaxX(NSRect aRect)</remarks>
        public static float NSMaxX(NSRect aRect)
        {
            return (aRect.origin.x + aRect.size.width);
        }

        /// <summary>
        /// Returns the largest y coordinate of a given rectangle.
        /// </summary>
        /// <remarks>Original declaration is : float NSMaxY(NSRect aRect)</remarks>
        public static float NSMaxY(NSRect aRect)
        {
            return (aRect.origin.y + aRect.size.height);
        }

        /// <summary>
        /// Returns the x coordinate of a given rectangle’s midpoint.
        /// </summary>
        /// <remarks>Original declaration is : float NSMidX(NSRect aRect)</remarks>
        public static float NSMidX(NSRect aRect)
        {
            return (aRect.origin.x + aRect.size.width / 2.0f);
        }

        /// <summary>
        /// Returns the y coordinate of a given rectangle’s midpoint.
        /// </summary>
        /// <remarks>Original declaration is : float NSMidY(NSRect aRect)</remarks>
        public static float NSMidY(NSRect aRect)
        {
            return (aRect.origin.y + aRect.size.height / 2.0f);
        }

        /// <summary>
        /// Returns the smallest x coordinate of a given rectangle.
        /// </summary>
        /// <remarks>Original declaration is : float NSMinX(NSRect aRect)</remarks>
        public static float NSMinX(NSRect aRect)
        {
            return (aRect.origin.x);
        }

        /// <summary>
        /// Returns the smallest y coordinate of a given rectangle.
        /// </summary>
        /// <remarks>Original declaration is : float NSMinY(NSRect aRect)</remarks>
        public static float NSMinY(NSRect aRect)
        {
            return (aRect.origin.y);
        }

        /// <summary>
        /// Returns a Boolean value that indicates whether the point is in the specified rectangle.
        /// </summary>
        /// <remarks>Original declaration is : BOOL NSMouseInRect(NSPoint aPoint, NSRect aRect, BOOL isFlipped)</remarks>
        public static bool NSMouseInRect(NSPoint aPoint, NSRect aRect, bool isFlipped)
        {
            return isFlipped
                       ? (aPoint.x >= NSMinX(aRect)) &&
                         (aPoint.x < NSMaxX(aRect)) &&
                         (aPoint.y > NSMinY(aRect)) &&
                         (aPoint.y <= NSMaxY(aRect))
                       : (aPoint.x >= NSMinX(aRect)) &&
                         (aPoint.x < NSMaxX(aRect)) &&
                         (aPoint.y >= NSMinY(aRect)) &&
                         (aPoint.y < NSMaxY(aRect));
        }

        /// <summary>
        /// Offsets the rectangle by the specified amount.
        /// </summary>
        /// <remarks>Original declaration is : NSRect NSOffsetRect(NSRect aRect, float dX, float dY)</remarks>
        public static NSRect NSOffsetRect(NSRect aRect, float dX, float dY)
        {
            NSRect result = aRect;
            result.origin.x += dX;
            result.origin.y += dY;
            return result;
        }

        /// <summary>
        /// Returns a Boolean value that indicates whether a given point is in a given rectangle.
        /// </summary>
        /// <remarks>Original declaration is : BOOL NSPointInRect(NSPoint aPoint, NSRect aRect)</remarks>
        public static bool NSPointInRect(NSPoint aPoint, NSRect aRect)
        {
            return NSMouseInRect(aPoint, aRect, false);
        }

        /// <summary>
        /// Returns a rectangle from a text-based representation.
        /// </summary>
        /// <remarks>Original declaration is : NSRect NSRectFromString(NSString *aString)</remarks>
        [DllImport("/System/Libraries/Frameworks/Foundation.framework/Foundation")]
        public static extern NSRect NSRectFromString([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(IdMarshaler<NSString>))] NSString aString);

        /// <summary>
        /// Returns a string representation of a rectangle.
        /// </summary>
        /// <remarks>Original declaration is : NSString *NSStringFromRect(NSRect aRect)</remarks>
        [DllImport("/System/Libraries/Frameworks/Foundation.framework/Foundation")]
        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(IdMarshaler<NSString>))]
        public static extern NSString NSStringFromRect(NSRect aRect);

        /// <summary>
        /// Calculates the union of two rectangles.
        /// </summary>
        /// <remarks>Original declaration is : NSRect NSUnionRect(NSRect aRect, NSRect bRect)</remarks>
        public static NSRect NSUnionRect(NSRect aRect, NSRect bRect)
        {
            if (NSIsEmptyRect(aRect) && NSIsEmptyRect(bRect))
            {
                return NSZeroRect;
            }
            if (NSIsEmptyRect(aRect))
            {
                return bRect;
            }
            if (NSIsEmptyRect(bRect))
            {
                return aRect;
            }

            NSRect result = NSMakeRect(
                Math.Min(NSMinX(aRect), NSMinX(bRect)),
                Math.Min(NSMinY(aRect), NSMinY(bRect)),
                Math.Max(NSMaxX(aRect), NSMaxX(bRect)),
                Math.Max(NSMaxY(aRect), NSMaxY(bRect))
                );
            return result;
        }

        /// <summary>
        /// Returns the width of the specified rectangle.
        /// </summary>
        /// <remarks>Original declaration is : float NSWidth(NSRect aRect)</remarks>
        public static float NSWidth(NSRect aRect)
        {
            return aRect.size.width;
        }
    }
}