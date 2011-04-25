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
using Monobjc.ApplicationServices;
using Monobjc.Foundation;

namespace Monobjc.Foundation
{
    public partial struct NSDecimal
    {
        public static short ShortValue(NSDecimal value)
        {
            return NSDecimalNumber.DecimalNumberWithDecimal(value).ShortValue;
        }

        public static NSDecimal FromShort(short value)
        {
            return NSNumber.NumberWithShort(value).DecimalValue;
        }

        public static int IntValue(NSDecimal value)
        {
            return NSDecimalNumber.DecimalNumberWithDecimal(value).IntValue;
        }

        public static NSDecimal FromInt(int value)
        {
            return NSNumber.NumberWithInt(value).DecimalValue;
        }

        public static long LongLongValue(NSDecimal value)
        {
            return NSDecimalNumber.DecimalNumberWithDecimal(value).LongLongValue;
        }

        public static NSDecimal FromLongLong(long value)
        {
            return NSNumber.NumberWithLongLong(value).DecimalValue;
        }

        public static NSInteger IntegerValue(NSDecimal value)
        {
            return NSDecimalNumber.DecimalNumberWithDecimal(value).IntegerValue;
        }

        public static NSDecimal FromInteger(NSInteger value)
        {
            return NSNumber.NumberWithInteger(value).DecimalValue;
        }

        public static ushort UnsignedShortValue(NSDecimal value)
        {
            return NSDecimalNumber.DecimalNumberWithDecimal(value).UnsignedShortValue;
        }

        public static NSDecimal FromUnsignedShort(ushort value)
        {
            return NSNumber.NumberWithUnsignedShort(value).DecimalValue;
        }

        public static uint UnsignedIntValue(NSDecimal value)
        {
            return NSDecimalNumber.DecimalNumberWithDecimal(value).UnsignedIntValue;
        }

        public static NSDecimal FromUnsignedInt(uint value)
        {
            return NSNumber.NumberWithUnsignedInt(value).DecimalValue;
        }

        public static ulong UnsignedLongLongValue(NSDecimal value)
        {
            return NSDecimalNumber.DecimalNumberWithDecimal(value).UnsignedLongLongValue;
        }

        public static NSDecimal FromUnsignedLongLong(ulong value)
        {
            return NSNumber.NumberWithUnsignedLongLong(value).DecimalValue;
        }

        public static NSUInteger UnsignedIntegerValue(NSDecimal value)
        {
            return NSDecimalNumber.DecimalNumberWithDecimal(value).UnsignedIntegerValue;
        }

        public static NSDecimal FromUnsignedInteger(NSUInteger value)
        {
            return NSNumber.NumberWithUnsignedInteger(value).DecimalValue;
        }

        public static float FloatValue(NSDecimal value)
        {
            return NSDecimalNumber.DecimalNumberWithDecimal(value).FloatValue;
        }

        public static NSDecimal FromFloat(float value)
        {
            return NSNumber.NumberWithFloat(value).DecimalValue;
        }

        public static double DoubleValue(NSDecimal value)
        {
            return NSDecimalNumber.DecimalNumberWithDecimal(value).DoubleValue;
        }

        public static NSDecimal FromDouble(double value)
        {
            return NSNumber.NumberWithDouble(value).DecimalValue;
        }

        public static NSString StringValue(NSDecimal value)
        {
            return NSDecimalNumber.DecimalNumberWithDecimal(value).StringValue;
        }

        public static NSDecimal FromString(NSString value)
        {
            NSDecimalNumber number = new NSDecimalNumber(value);
            NSDecimal @decimal = number.DecimalValue;
            number.Release();
            return @decimal;
        }
    }
}