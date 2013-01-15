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

namespace Monobjc.Foundation
{
    partial class NSNumber
    {
        /// <summary>
        /// Performs an implicit conversion from <see cref="System.Boolean"/> to <see cref="Monobjc.Foundation.NSNumber"/>.
        /// </summary>
        /// <param name="value">if set to <c>true</c> [value].</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator NSNumber(bool value)
        {
            return NumberWithBool(value);
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="System.Char"/> to <see cref="Monobjc.Foundation.NSNumber"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator NSNumber(char value)
        {
            return NumberWithChar(value);
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="System.Double"/> to <see cref="Monobjc.Foundation.NSNumber"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator NSNumber(double value)
        {
            return NumberWithDouble(value);
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="System.Single"/> to <see cref="Monobjc.Foundation.NSNumber"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator NSNumber(float value)
        {
            return NumberWithFloat(value);
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="System.Int32"/> to <see cref="Monobjc.Foundation.NSNumber"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator NSNumber(int value)
        {
            return NumberWithInt(value);
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="System.Int64"/> to <see cref="Monobjc.Foundation.NSNumber"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator NSNumber(long value)
        {
            return NumberWithLongLong(value);
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="System.Int16"/> to <see cref="Monobjc.Foundation.NSNumber"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator NSNumber(short value)
        {
            return NumberWithShort(value);
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="System.UInt32"/> to <see cref="Monobjc.Foundation.NSNumber"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator NSNumber(uint value)
        {
            return NumberWithUnsignedInt(value);
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="System.UInt64"/> to <see cref="Monobjc.Foundation.NSNumber"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator NSNumber(ulong value)
        {
            return NumberWithUnsignedLongLong(value);
        }

        /// <summary>

        /// Performs an implicit conversion from <see cref="System.UInt16"/> to <see cref="Monobjc.Foundation.NSNumber"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator NSNumber(ushort value)
        {
            return NumberWithUnsignedShort(value);
        }

        /// <summary>
        /// Create a <see cref="NSNumber"/> instance the with enumeration value.
        /// </summary>
        /// <typeparam name="T">The enumeration type</typeparam>
        /// <param name="value">The value.</param>
        /// <returns>A <see cref="NSNumber"/> instance or null if the type is not an enumeration.</returns>
        public static NSNumber NumberWithEnum<T>(T value) 
        {
            Type type = Enum.GetUnderlyingType(typeof (T));
            if (type == typeof(int))
            {
                return NumberWithInt(Convert.ToInt32(value));
            }
            if (type == typeof(uint))
            {
                return NumberWithUnsignedInt(Convert.ToUInt32(value));
            }
            if (type == typeof(long))
            {
                return NumberWithLongLong(Convert.ToInt64(value));
            }
            if (type == typeof(ulong))
            {
                return NumberWithUnsignedLongLong(Convert.ToUInt64(value));
            }
            if (type == typeof(short))
            {
                return NumberWithShort(Convert.ToInt16(value));
            }
            if (type == typeof(ushort))
            {
                return NumberWithUnsignedShort(Convert.ToUInt16(value));
            }
            return null;
        }
    }
}