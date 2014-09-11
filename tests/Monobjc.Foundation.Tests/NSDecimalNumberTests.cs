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
using Monobjc.ApplicationServices;
using NUnit.Framework;

namespace Monobjc.Foundation
{
    [TestFixture]
    [Category("NSDecimalNumber")]
    public class NSDecimalNumberTests : WrapperTests
    {
        //[Test]
        //public void TestStaticCreation()
        //{
        //    NSDecimalNumber number;

        //    number = NSDecimalNumber.NumberWithBool(true);
        //    Check(number);
        //    Assert.AreEqual(1, number.IntValue, "Number has wrong value");

        //    number = NSDecimalNumber.NumberWithBool(false);
        //    Check(number);
        //    Assert.AreEqual(0, number.IntValue, "Number has wrong value");

        //    number = NSDecimalNumber.NumberWithDouble(123.456d);
        //    Check(number);
        //    Assert.AreEqual(123.456d, number.DoubleValue, "Number has wrong value");

        //    number = NSDecimalNumber.NumberWithDouble(-12345678901234567890d);
        //    Check(number);
        //    Assert.AreEqual(-12345678901234567890d, number.DoubleValue, "Number has wrong value");

        //    number = NSDecimalNumber.NumberWithFloat(123.456f);
        //    Check(number);
        //    Assert.AreEqual(123.456f, number.FloatValue, "Number has wrong value");

        //    number = NSDecimalNumber.NumberWithFloat(-12345678901234567890f);
        //    Check(number);
        //    Assert.AreEqual(-12345678901234567890f, number.FloatValue, "Number has wrong value");

        //    number = NSDecimalNumber.NumberWithInt(123);
        //    Check(number);
        //    Assert.AreEqual(123, number.IntValue, "Number has wrong value");

        //    number = NSDecimalNumber.NumberWithInt(-123456);
        //    Check(number);
        //    Assert.AreEqual(-123456, number.IntValue, "Number has wrong value");
        //}

        //[Test]
        //public void TestInstanceCreation()
        //{
        //    NSDecimalNumber number;

        //    number = new NSDecimalNumber(true);
        //    Check(number);
        //    Assert.AreEqual(1, number.IntValue, "Number has wrong value");
        //    number.Autorelease();

        //    number = new NSDecimalNumber(false);
        //    Check(number);
        //    Assert.AreEqual(0, number.IntValue, "Number has wrong value");
        //    number.Autorelease();

        //    number = new NSDecimalNumber(123.456d);
        //    Check(number);
        //    Assert.AreEqual(123.456d, number.DoubleValue, "Number has wrong value");
        //    number.Autorelease();

        //    number = new NSDecimalNumber(-12345678901234567890d);
        //    Check(number);
        //    Assert.AreEqual(-12345678901234567890d, number.DoubleValue, "Number has wrong value");
        //    number.Autorelease();

        //    number = new NSDecimalNumber(123.456f);
        //    Check(number);
        //    Assert.AreEqual(123.456f, number.FloatValue, "Number has wrong value");
        //    number.Autorelease();

        //    number = new NSDecimalNumber(-12345678901234567890f);
        //    Check(number);
        //    Assert.AreEqual(-12345678901234567890f, number.FloatValue, "Number has wrong value");
        //    number.Autorelease();

        //    number = new NSDecimalNumber(123);
        //    Check(number);
        //    Assert.AreEqual(123, number.IntValue, "Number has wrong value");
        //    number.Autorelease();

        //    number = new NSDecimalNumber(-123456);
        //    Check(number);
        //    Assert.AreEqual(-123456, number.IntValue, "Number has wrong value");
        //    number.Autorelease();
        //}

        //[Test]
        //public void TestOperations()
        //{
        //    NSDecimalNumber number;

        //    number = NSDecimalNumber.NumberWithInt(234);
        //    Check(number);
        //    bool b = number.BoolValue;
        //    Assert.AreEqual(true, b, "Numbers must be equals");

        //    number = NSDecimalNumber.NumberWithInt(345);
        //    Check(number);
        //    short s = number.ShortValue;
        //    Assert.AreEqual(345, s, "Numbers must be equals");

        //    number = NSDecimalNumber.NumberWithInt(456);
        //    Check(number);
        //    long ll = number.LongLongValue;
        //    Assert.AreEqual(456, ll, "Numbers must be equals");
        //}

        #pragma warning disable 219
        [Test]
        public void TestConversions()
        {
            NSDecimal number;

            //char c = 'a';
            short s = 1234;
            int i = 123456;
            long l = 1234567890123456789;
            //ushort us = 50000;
            //uint ui = 2000000000;
            //ulong ul = 12345678901234567890;
            float f = 1234.5678f;
            double d = 123456789.123456789;

            number = NSDecimal.FromShort(s);
            number = NSDecimal.FromInt(i);
            number = NSDecimal.FromLongLong(l);
            number = NSDecimal.FromFloat(f);
            number = NSDecimal.FromDouble(d);
        }
        #pragma warning restore 219

        private static void Check(NSDecimalNumber number)
        {
            Assert.IsNotNull(number, "Number cannot be null");
            Assert.AreNotEqual(IntPtr.Zero, number.NativePointer, "Native pointer cannot be null");
        }
    }
}