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
using System;

namespace Monobjc.ApplicationServices
{
    public partial struct CGPoint
    {
        /// <summary>
        /// Translates the point by the specified size.
        /// </summary>
        /// <param name="cgPoint">A point.</param>
        /// <param name="cgSize">A size.</param>
        /// <returns></returns>
        public static CGPoint Add(CGPoint cgPoint, CGSize cgSize)
        {
            return new CGPoint(cgPoint.x + cgSize.width, cgPoint.y + cgSize.height);
        }

        /// <summary>
        /// Translates the point by the specified size.
        /// </summary>
        /// <param name="cgPoint">A point.</param>
        /// <param name="cgSize">A size.</param>
        /// <returns></returns>
        public static CGPoint Substract(CGPoint cgPoint, CGSize cgSize)
        {
            return new CGPoint(cgPoint.x - cgSize.width, cgPoint.y - cgSize.height);
        }

        /// <summary>
        /// Computes the size between the two points. The values are always positives.
        /// </summary>
        /// <param name="cgPoint1">The point 1.</param>
        /// <param name="cgPoint2">The point 2.</param>
        /// <returns>A <see cref="NSSize"/> instance that contains the size between the two points.</returns>
        public static CGSize Substract(CGPoint cgPoint1, CGPoint cgPoint2)
        {
            return new CGSize(Math.Abs(cgPoint2.x - cgPoint1.x), Math.Abs(cgPoint2.y - cgPoint1.y));
        }

        /// <summary>
        /// Implements the operator +.
        /// </summary>
        /// <param name="cgPoint">The ns point.</param>
        /// <param name="cgSize">Size of the ns.</param>
        /// <returns>The result of the operator.</returns>
        public static CGPoint operator +(CGPoint cgPoint, CGSize cgSize)
        {
            return Add(cgPoint, cgSize);
        }

        /// <summary>
        /// Implements the operator -.
        /// </summary>
        /// <param name="cgPoint">The ns point.</param>
        /// <param name="cgSize">Size of the ns.</param>
        /// <returns>The result of the operator.</returns>
        public static CGPoint operator -(CGPoint cgPoint, CGSize cgSize)
        {
            return Substract(cgPoint, cgSize);
        }

        /// <summary>
        /// Implements the operator -.
        /// </summary>
        /// <param name="cgPoint1">The point 1.</param>
        /// <param name="cgPoint2">The point 2.</param>
        /// <returns>The result of the operator.</returns>
        public static CGSize operator -(CGPoint cgPoint1, CGPoint cgPoint2)
        {
            return Substract(cgPoint1, cgPoint2);
        }
    }
}