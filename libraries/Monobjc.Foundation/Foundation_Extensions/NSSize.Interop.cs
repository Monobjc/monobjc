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
using Monobjc.ApplicationServices;

namespace Monobjc.Foundation
{
    public partial struct NSSize
    {
        /// <summary>
        /// Returns the sum of the two sizes instances.
        /// </summary>
        /// <param name="size1">A size.</param>
        /// <param name="size2">A size.</param>
        /// <returns></returns>
        public static NSSize Add(NSSize size1, NSSize size2)
        {
            return new NSSize(size1.width + size2.width, size1.height + size2.height);
        }

        /// <summary>
        /// Returns the difference of the two sizes instances.
        /// </summary>
        /// <param name="size1">A size.</param>
        /// <param name="size2">A size.</param>
        /// <returns></returns>
        public static NSSize Substract(NSSize size1, NSSize size2)
        {
            return new NSSize(size1.width - size2.width, size1.height - size2.height);
        }

        /// <summary>
        /// Returns the product of the size instance by the given factor.
        /// </summary>
        /// <param name="size">The size.</param>
        /// <param name="factor">The factor.</param>
        /// <returns></returns>
        public static NSSize Multiply(NSSize size, CGFloat factor)
        {
            return new NSSize(size.width*factor, size.height*factor);
        }

        /// <summary>
        /// Returns the result of the division of the size instance by the given factor.
        /// </summary>
        /// <param name="size">The size.</param>
        /// <param name="factor">The factor.</param>
        /// <returns></returns>
		public static NSSize Divide(NSSize size, CGFloat factor)
        {
            return new NSSize(size.width/factor, size.height/factor);
        }

        /// <summary>
        /// Implements the operator +.
        /// </summary>
        /// <param name="size1">The ns size1.</param>
        /// <param name="size2">The ns size2.</param>
        /// <returns>The result of the operator.</returns>
        public static NSSize operator +(NSSize size1, NSSize size2)
        {
            return Add(size1, size2);
        }

        /// <summary>
        /// Implements the operator -.
        /// </summary>
        /// <param name="size1">The ns size1.</param>
        /// <param name="size2">The ns size2.</param>
        /// <returns>The result of the operator.</returns>
        public static NSSize operator -(NSSize size1, NSSize size2)
        {
            return Substract(size1, size2);
        }

        /// <summary>
        /// Implements the operator *.
        /// </summary>
        /// <param name="size">The size.</param>
        /// <param name="factor">The factor.</param>
        /// <returns>The result of the operator.</returns>
		public static NSSize operator *(NSSize size, CGFloat factor)
        {
            return Multiply(size, factor);
        }

        /// <summary>
        /// Implements the operator /.
        /// </summary>
        /// <param name="size">The size.</param>
        /// <param name="factor">The factor.</param>
        /// <returns>The result of the operator.</returns>
		public static NSSize operator /(NSSize size, CGFloat factor)
        {
            return Divide(size, factor);
        }
    }
}