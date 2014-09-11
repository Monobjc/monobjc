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
using System.Runtime.InteropServices;
using Monobjc.ApplicationServices;

namespace Monobjc.Foundation
{
    public partial struct NSSize
    {
        /// <summary>
        /// An <see cref="NSSize"/> with its width and height set to 0.
        /// </summary>
        public static readonly NSSize NSZeroSize;

		/// <summary>
		/// Converts a <see cref="CGSize"/> instance to a <see cref="NSSize"/>
		/// </summary>
		/// <param name="cgsize">The <see cref="CGSize"/> to convert.</param>
		/// <returns>A new <see cref="NSSize"/> instance.</returns>
		public static NSSize NSSizeFromCGSize(CGSize cgsize)
		{
			return NSMakeSize(cgsize.width, cgsize.height);
		}
		
		/// <summary>
		/// Converts a <see cref="NSSize"/> instance to a <see cref="CGSize"/>
		/// </summary>
		/// <param name="nssize">The <see cref="NSSize"/> to convert.</param>
		/// <returns>A new <see cref="CGSize"/> instance.</returns>
		public static CGSize CGSizeFromNSSize(NSSize nssize)
		{
			return CGSize.CGSizeMake(nssize.width, nssize.height);
		}		

        /// <summary>
        /// Tests two size values for equality.
        /// </summary>
        /// <remarks>Original declaration is : BOOL NSEqualSizes(NSSize aSize, NSSize bSize)</remarks>
        public static bool NSEqualSizes(NSSize aSize,
                                        NSSize bSize)
        {
            return Equals(aSize, bSize);
        }

        /// <summary>
        /// Creates a new NSSize from the specified values.
        /// </summary>
        /// <remarks>Original declaration is : NSSize NSMakeSize(float width, float height)</remarks>
		public static NSSize NSMakeSize(CGFloat width,
		                                CGFloat height)
        {
            return new NSSize(width, height);
        }

        /// <summary>
        /// Returns an NSSize from a text-based representation.
        /// </summary>
        /// <remarks>Original declaration is : NSSize NSSizeFromString(NSString *aString)</remarks>
        [DllImport("/System/Library/Frameworks/Foundation.framework/Foundation")]
        public static extern NSSize NSSizeFromString([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (IdMarshaler<NSString>))] NSString aString);

        /// <summary>
        /// Returns a string representation of a size.
        /// </summary>
        /// <remarks>Original declaration is : NSString *NSStringFromSize(NSSize aSize)</remarks>
        [DllImport("/System/Library/Frameworks/Foundation.framework/Foundation")]
        [return : MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (IdMarshaler<NSString>))]
        public static extern NSString NSStringFromSize(NSSize aSize);
    }
}