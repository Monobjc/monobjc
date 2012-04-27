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
	public partial struct NSInteger
	{
		public static explicit operator sbyte (NSInteger value)
		{
			return (sbyte)value.value;
		}

		public static implicit operator NSInteger (sbyte value)
		{
			return new NSInteger (value);
		}

		public static explicit operator short (NSInteger value)
		{
			return (short)value.value;
		}

		public static implicit operator NSInteger (short value)
		{
			return new NSInteger (value);
		}

		public static implicit operator int (NSInteger value)
		{
			return value.value;
		}

		public static implicit operator NSInteger (int value)
		{
			return new NSInteger (value);
		}

		public static implicit operator long (NSInteger value)
		{
			return value.value;
		}

		public static implicit operator NSInteger (long value)
		{
			return new NSInteger ((int)value);
		}

		public static explicit operator byte (NSInteger value)
		{
			return (byte)value.value;
		}

		public static implicit operator NSInteger (byte value)
		{
			return new NSInteger (value);
		}

		public static explicit operator ushort (NSInteger value)
		{
			return (ushort)value.value;
		}

		public static implicit operator NSInteger (ushort value)
		{
			return new NSInteger (value);
		}

		public static explicit operator uint (NSInteger value)
		{
			return (uint)value.value;
		}

		public static implicit operator NSInteger (uint value)
		{
			return new NSInteger ((int)value);
		}

		public static explicit operator ulong (NSInteger value)
		{
			return (ulong)value.value;
		}

		public static implicit operator NSInteger (ulong value)
		{
			return new NSInteger ((int)value);
		}

		public static explicit operator float (NSInteger value)
		{
			return value.value;
		}

		public static explicit operator NSInteger (float value)
		{
			return new NSInteger ((int)value);
		}

		public static explicit operator double (NSInteger value)
		{
			return value.value;
		}

		public static explicit operator NSInteger (double value)
		{
			return new NSInteger ((int)value);
		}

		public static explicit operator NSInteger (CGFloat value)
		{
			return new NSInteger ((int)value.value);
		}

		public static implicit operator CGFloat (NSInteger value)
		{
			return new CGFloat (value.value);
		}

		public static implicit operator NSUInteger (NSInteger value)
		{
			return new NSUInteger ((uint)value.value);
		}
	}
}
