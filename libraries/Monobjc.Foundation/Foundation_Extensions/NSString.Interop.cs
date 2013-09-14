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
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Monobjc.Foundation
{
    public partial class NSString
    {
        /// <summary>
        /// Returns an retained instance of NSString.
        /// </summary>
        public static NSString NSPinnedString(String value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            NSString str = new NSString(value);
            return str;
        }

        /// <summary>
        /// Empty string
        /// </summary>
        public static NSString Empty
        {
            get { return System.String.Empty; }
        }

        /// <summary>
        /// Gets the <see cref="System.Char"/> at the specified index.
        /// </summary>
        /// <value></value>
        public Char this[uint index]
        {
            get { return this.CharacterAtIndex(index); }
        }

        ///<summary>
        ///Returns a <see cref="T:System.String"></see> that represents the current <see cref="T:System.Object"></see>.
        ///</summary>
        ///<returns>
        ///A <see cref="T:System.String"></see> that represents the current <see cref="T:System.Object"></see>.
        ///</returns>
        public override String ToString()
        {
            return ToStringInternal(this.NativePointer);
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="System.String"/> to <see cref="Monobjc.Foundation.NSString"/>.
        /// <para>The returned NSString is auto-released.</para>
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator NSString(String value)
        {
            if (value != null)
            {
                NSString str = new NSString(value);
                str.Autorelease();
                return str;
            }
            return null;
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="System.String"/> to <see cref="Monobjc.Foundation.NSString"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator String(NSString value)
        {
            return value != null ? ToStringInternal(value.NativePointer) : null;
        }

        /// <summary>
        /// Implements the operator +.
        /// </summary>
        /// <param name="string">The @string.</param>
        /// <param name="otherString">The other string.</param>
        /// <returns>The result of the operator.</returns>
        public static NSString operator +(NSString @string, NSString otherString)
        {
            return @string.StringByAppendingString(otherString);
        }

        /// <summary>
        /// Determines whether this string is null or empty.
        /// </summary>
        /// <param name="string">The string.</param>
        /// <returns>
        /// 	<c>true</c> if it is null or empty; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNullOrEmpty(NSString @string)
        {
            return (@string == null || @string.IsEqualToString(NSString.String));
        }

        /// <summary>
        /// Internal call to convert a <see cref="Monobjc.Foundation.NSString"/> object to a <see cref="System.String"/> object.
        /// </summary>
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        public extern static String ToStringInternal (IntPtr ptr);
    }
}