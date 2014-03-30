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
namespace Monobjc.ApplicationServices
{
    public partial struct CGSize
    {
        /// <summary>
        /// A <see cref="CGSize"/> with its width and height set to zero.
        /// </summary>
        public static readonly CGSize CGSizeZero = new CGSize();

        /// <summary>
        /// Indicates whether two sizes are equal.
        /// </summary>
        /// <param name="size1">The first size to examine.</param>
        /// <param name="size2">The second size to examine.</param>
        /// <returns>Returns 1 if the two specified sizes are equal; otherwise, 0.</returns>
        /// <remarks>Original declaration is : int CGSizeEqualToSize ( CGSize size1, CGSize size2 );</remarks>
        public static int CGSizeEqualToSize(CGSize size1, CGSize size2)
        {
            return Equals(size1, size2) ? 1 : 0;
        }

        /// <summary>
        /// Returns a size structure constructed from dimension values you provide.
        /// </summary>
        /// <param name="width">A width value.</param>
        /// <param name="height">A height value.</param>
        /// <returns>Returns a CGSize structure with the specified width and height.</returns>
        /// <remarks>Original declaration is : CGSize CGSizeMake ( float width, float height );</remarks>
		public static CGSize CGSizeMake(CGFloat width, CGFloat height)
        {
            return new CGSize(width, height);
        }
    }
}