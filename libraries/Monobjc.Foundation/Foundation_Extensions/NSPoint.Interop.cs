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

namespace Monobjc.Foundation
{
    public partial struct NSPoint
    {
        /// <summary>
        /// Translates the point by the specified size.
        /// </summary>
        /// <param name="nsPoint">A point.</param>
        /// <param name="nsSize">A size.</param>
        /// <returns></returns>
        public static NSPoint Add(NSPoint nsPoint, NSSize nsSize)
        {
            return new NSPoint(nsPoint.x + nsSize.width, nsPoint.y + nsSize.height);
        }

        /// <summary>
        /// Translates the point by the specified size.
        /// </summary>
        /// <param name="nsPoint">A point.</param>
        /// <param name="nsSize">A size.</param>
        /// <returns></returns>
        public static NSPoint Substract(NSPoint nsPoint, NSSize nsSize)
        {
            return new NSPoint(nsPoint.x - nsSize.width, nsPoint.y - nsSize.height);
        }

        /// <summary>
        /// Computes the size between the two points. The values are always positives.
        /// </summary>
        /// <param name="nsPoint1">The point 1.</param>
        /// <param name="nsPoint2">The point 2.</param>
        /// <returns>A <see cref="NSSize"/> instance that contains the size between the two points.</returns>
        public static NSSize Substract(NSPoint nsPoint1, NSPoint nsPoint2)
        {
            return new NSSize(Math.Abs(nsPoint2.x - nsPoint1.x), Math.Abs(nsPoint2.y - nsPoint1.y));
        }

        /// <summary>
        /// Implements the operator +.
        /// </summary>
        /// <param name="nsPoint">The ns point.</param>
        /// <param name="nsSize">Size of the ns.</param>
        /// <returns>The result of the operator.</returns>
        public static NSPoint operator +(NSPoint nsPoint, NSSize nsSize)
        {
            return Add(nsPoint, nsSize);
        }

        /// <summary>
        /// Implements the operator -.
        /// </summary>
        /// <param name="nsPoint">The ns point.</param>
        /// <param name="nsSize">Size of the ns.</param>
        /// <returns>The result of the operator.</returns>
        public static NSPoint operator -(NSPoint nsPoint, NSSize nsSize)
        {
            return Substract(nsPoint, nsSize);
        }

        /// <summary>
        /// Implements the operator -.
        /// </summary>
        /// <param name="nsPoint1">The point 1.</param>
        /// <param name="nsPoint2">The point 2.</param>
        /// <returns>The result of the operator.</returns>
        public static NSSize operator -(NSPoint nsPoint1, NSPoint nsPoint2)
        {
            return Substract(nsPoint1, nsPoint2);
        }
    }
}