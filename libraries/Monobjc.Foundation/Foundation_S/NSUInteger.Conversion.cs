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
using Monobjc.Foundation;

namespace Monobjc.Foundation
{
	public partial struct NSUInteger
	{
		public static explicit operator sbyte (NSUInteger value)
		{
			return (sbyte)value.value;
		}

		public static implicit operator NSUInteger (sbyte value)
		{
			return new NSUInteger ((uint)value);
		}

		public static explicit operator short (NSUInteger value)
		{
			return (short)value.value;
		}

		public static implicit operator NSUInteger (short value)
		{
			return new NSUInteger ((uint)value);
		}

		public static explicit operator int (NSUInteger value)
		{
			return (int)value.value;
		}

		public static implicit operator NSUInteger (int value)
		{
			return new NSUInteger ((uint)value);
		}

		public static explicit operator long (NSUInteger value)
		{
			return value.value;
		}

		public static implicit operator NSUInteger (long value)
		{
			return new NSUInteger ((uint)value);
		}

		public static explicit operator byte (NSUInteger value)
		{
			return (byte)value.value;
		}

		public static implicit operator NSUInteger (byte value)
		{
			return new NSUInteger (value);
		}

		public static explicit operator ushort (NSUInteger value)
		{
			return (ushort)value.value;
		}

		public static implicit operator NSUInteger (ushort value)
		{
			return new NSUInteger (value);
		}

		public static implicit operator uint (NSUInteger value)
		{
			return value.value;
		}

		public static implicit operator NSUInteger (uint value)
		{
			return new NSUInteger (value);
		}

		public static explicit operator ulong (NSUInteger value)
		{
			return value.value;
		}

		public static implicit operator NSUInteger (ulong value)
		{
			return new NSUInteger ((uint)value);
		}

		public static explicit operator float (NSUInteger value)
		{
			return value.value;
		}

		public static explicit operator NSUInteger (float value)
		{
			return new NSUInteger ((uint)value);
		}

		public static explicit operator double (NSUInteger value)
		{
			return value.value;
		}

		public static explicit operator NSUInteger (double value)
		{
			return new NSUInteger ((uint)value);
		}

		public static explicit operator NSUInteger (CGFloat value)
		{
			return new NSUInteger ((uint)value.value);
		}

		public static implicit operator CGFloat (NSUInteger value)
		{
			return new CGFloat (value.value);
		}

		public static implicit operator NSInteger (NSUInteger value)
		{
			return new NSInteger ((int)value.value);
		}
	}
}
