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
namespace Monobjc.AppKit
{
    public partial class NSColor
    {
        /// <summary>
        /// <para>Returns an NSColor object that represents a blend between the receiver and the highlight color returned by highlightColor.</para>
        /// <para>Original signature is '- (NSColor *)highlightWithLevel:( CGFloat)highlightLevel'</para>
        /// <para>Available in Mac OS X v10.0 and later.</para>
        /// </summary>
        /// <param name="color">The color.</param>
        /// <param name="highlightLevel">The amount of the highlight color that is blended with the receiver's color. This should be a number from 0.0 through 1.0. A highlightLevel below 0.0 is interpreted as 0.0; a highlightLevel above 1.0 is interpreted as 1.0.</param>
        /// <returns>
        /// The new NSColor object. Returns nil if the colors can’t be converted.
        /// </returns>
        public static NSColor operator *(NSColor color, float highlightLevel)
        {
            return color.HighlightWithLevel(highlightLevel);
        }

        /// <summary>
        /// <para>Returns an NSColor object that represents a blend between the receiver and the shadow color returned by shadowColor.</para>
        /// <para>Original signature is '- (NSColor *)shadowWithLevel:( CGFloat)shadowLevel'</para>
        /// <para>Available in Mac OS X v10.0 and later.</para>
        /// </summary>
        /// <param name="color">The color.</param>
        /// <param name="shadowLevel">The amount of the shadow color used for the blend. This should be a number from 0.0 through 1.0. A shadowLevel below 0.0 is interpreted as 0.0; a shadowLevel above 1.0 is interpreted as 1.0.</param>
        /// <returns>
        /// The new NSColor object. Returns nil if the colors can’t be converted.
        /// </returns>
        public static NSColor operator /(NSColor color, float shadowLevel)
        {
            return color.ShadowWithLevel(shadowLevel);
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return null;
        }
    }
}