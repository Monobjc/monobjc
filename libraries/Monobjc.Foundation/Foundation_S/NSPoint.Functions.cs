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
using System.Runtime.InteropServices;
using Monobjc.ApplicationServices;

namespace Monobjc.Foundation
{
    public partial struct NSPoint
    {
        /// <summary>
        /// A <see cref="NSPoint"/> instance with its coordinates set to zero.
        /// </summary>
        public static readonly NSPoint NSZeroPoint = new NSPoint();

		/// <summary>
		/// Converts a <see cref="CGPoint"/> instance to a <see cref="NSPoint"/>
		/// </summary>
		/// <param name="cgpoint">The <see cref="CGPoint"/> to convert.</param>
		/// <returns>A new <see cref="NSPoint"/> instance.</returns>
		public static NSPoint NSPointFromCGPoint(CGPoint cgpoint)
		{
			return NSMakePoint(cgpoint.x, cgpoint.y);
		}
		
		/// <summary>
		/// Converts a <see cref="NSPoint"/> instance to a <see cref="CGPoint"/>
		/// </summary>
		/// <param name="nspoint">The <see cref="NSPoint"/> to convert.</param>
		/// <returns>A new <see cref="CGPoint"/> instance.</returns>
		public static CGPoint CGPointFromNSPoint(NSPoint nspoint)
		{
			return CGPoint.CGPointMake(nspoint.x, nspoint.y);
		}		

        /// <summary>
        /// Tests two points for equality.
        /// </summary>
        /// <remarks>Original declaration is : BOOL NSEqualPoints(NSPoint aPoint, NSPoint bPoint)</remarks>
        public static bool NSEqualPoints(NSPoint aPoint,
                                         NSPoint bPoint)
        {
            return Equals(aPoint, bPoint);
        }

        /// <summary>
        /// Creates a new NSPoint from the specified values.
        /// </summary>
        /// <remarks>Original declaration is : NSPoint NSMakePoint(float x, float y)</remarks>
        public static NSPoint NSMakePoint(float x,
                                          float y)
        {
            return new NSPoint(x, y);
        }

        /// <summary>
        /// Returns a point from a text-based representation.
        /// </summary>
        /// <remarks>Original declaration is : NSPoint NSPointFromString(NSString *aString)</remarks>
        [DllImport("/System/Libraries/Frameworks/Foundation.framework/Foundation")]
        [return : MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (IdMarshaler<NSString>))]
        public static extern NSPoint NSPointFromString([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (IdMarshaler<NSString>))] NSString aString);

        /// <summary>
        /// Returns a string representation of a point.
        /// </summary>
        /// <remarks>Original declaration is : NSString *NSStringFromPoint(NSPoint aPoint)</remarks>
        [DllImport("/System/Libraries/Frameworks/Foundation.framework/Foundation")]
        [return : MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (IdMarshaler<NSString>))]
        public static extern NSString NSStringFromPoint(NSPoint aPoint);
    }
}