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
using System.Runtime.InteropServices;

namespace Monobjc.Foundation
{
    public partial struct NSRange
    {
        /// <summary>
        /// A <see cref="NSRange"/> instance with its coordinates set to zero.
        /// </summary>
        public static readonly NSRange NSZeroRange;

        /// <summary>
        /// A <see cref="NSRange"/> instance with its coordinates set to max.
        /// </summary>
        public static readonly NSRange NSNotFoundRange = new NSRange(NSUInteger.NSNotFound, 0);

        /// <summary>
        /// Returns a Boolean value that indicates whether two given ranges are equal.
        /// </summary>
        /// <remarks>Original declaration is : BOOL NSEqualRanges(NSRange range1, NSRange range2)</remarks>
        public static bool NSEqualRanges(NSRange range1,
                                         NSRange range2)
        {
            return Equals(range1, range2);
        }

        /// <summary>
        /// Returns the intersection of the specified ranges.
        /// </summary>
        /// <remarks>Original declaration is : NSRange NSIntersectionRange(NSRange range1, NSRange range2)</remarks>
        public static NSRange NSIntersectionRange(NSRange range1, NSRange range2)
        {
            uint max1 = NSMaxRange(range1);
            uint max2 = NSMaxRange(range1);

            uint max = (max1 < max2) ? max1 : max2;
            uint location = (range1.location > range2.location) ? range1.location : range2.location;

            return max < location ? NSZeroRange : new NSRange(location, max-location);
        }

        /// <summary>
        /// Returns a Boolean value that indicates whether a specified position is in a given range.
        /// </summary>
        /// <remarks>Original declaration is : BOOL NSLocationInRange(unsigned int index, NSRange aRange)</remarks>
        public static bool NSLocationInRange(uint index, NSRange aRange)
        {
            return ((index >= aRange.location) && (index < (aRange.location + aRange.length)));
        }

        /// <summary>
        /// Creates a new NSRange from the specified values.
        /// </summary>
        /// <remarks>Original declaration is : NSRange NSMakeRange(unsigned int location, unsigned int length)</remarks>
        public static NSRange NSMakeRange(uint location,
                                          uint length)
        {
            return new NSRange(location, length);
        }

        /// <summary>
        /// Returns the number 1 greater than the maximum value within the range.
        /// </summary>
        /// <remarks>Original declaration is : unsigned int NSMaxRange(NSRange range)</remarks>
        public static uint NSMaxRange(NSRange range)
        {
            return (range.location + range.length);
        }

        /// <summary>
        /// Returns a range from a text-based representation.
        /// </summary>
        /// <remarks>Original declaration is : NSRange NSRangeFromString(NSString *aString)</remarks>
        [DllImport("/System/Libraries/Frameworks/Foundation.framework/Foundation")]
        public static extern NSRange NSRangeFromString([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (IdMarshaler<NSString>))] NSString aString);

        /// <summary>
        /// Returns a string representation of a range.
        /// </summary>
        /// <remarks>Original declaration is : NSString *NSStringFromRange(NSRange aRange)</remarks>
        [DllImport("/System/Libraries/Frameworks/Foundation.framework/Foundation")]
        [return : MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (IdMarshaler<NSString>))]
        public static extern NSString NSStringFromRange(NSRange aRange);

        /// <summary>
        /// Returns the intersection of the specified ranges.
        /// </summary>
        /// <remarks>Original declaration is : NSRange NSUnionRange(NSRange range1, NSRange range2)</remarks>
        public static NSRange NSUnionRange(NSRange range1, NSRange range2)
        {
            uint max1 = NSMaxRange(range1);
            uint max2 = NSMaxRange(range1);

            uint max = (max1 > max2) ? max1 : max2;
            uint location = (range1.location < range2.location) ? range1.location : range2.location;

            return new NSRange(location, max - location);
        }
    }
}