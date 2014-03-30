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
using System;

namespace Monobjc.Foundation
{
    partial class NSMutableString
    {
        /// <summary>
        /// Implements the operator +.
        /// </summary>
        /// <param name="string">The string.</param>
        /// <param name="otherString">The other string.</param>
        /// <returns>The result of the operator.</returns>
        public static NSMutableString operator +(NSMutableString @string, NSString otherString)
        {
            @string.AppendString(otherString);
            return @string;
        }
		
        /// <summary>
        /// Performs an implicit conversion from <see cref="System.String"/> to <see cref="Monobjc.Foundation.NSMutableString"/>.
        /// <para>The returned NSString is auto-released.</para>
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator NSMutableString(String value)
        {
            if (value != null)
            {
                NSMutableString str = new NSMutableString(value);
                str.Autorelease();
                return str;
            }
            return null;
        }
    }
}