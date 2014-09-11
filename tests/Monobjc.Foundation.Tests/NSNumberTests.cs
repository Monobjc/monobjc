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
using NUnit.Framework;

namespace Monobjc.Foundation
{
    [TestFixture]
    [Category("NSNumber")]
    [Description("Test with NSNumber wrapper")]
    public class NSNumberTests : WrapperTests
    {
        [Test]
        public void TestStaticCreation()
        {
            NSNumber number;
            
            number = NSNumber.NumberWithBool(true);
            Check(number);
            Assert.AreEqual(1, number.IntValue, "Number has wrong value");

            number = NSNumber.NumberWithBool(false);
            Check(number);
            Assert.AreEqual(0, number.IntValue, "Number has wrong value");

            number = NSNumber.NumberWithDouble(123.456d);
            Check(number);
            Assert.AreEqual(123.456d, number.DoubleValue, "Number has wrong value");

            number = NSNumber.NumberWithDouble(-12345678901234567890d);
            Check(number);
            Assert.AreEqual(-12345678901234567890d, number.DoubleValue, "Number has wrong value");

            number = NSNumber.NumberWithFloat(123.456f);
            Check(number);
            Assert.AreEqual(123.456f, number.FloatValue, "Number has wrong value");

            number = NSNumber.NumberWithFloat(-12345678901234567890f);
            Check(number);
            Assert.AreEqual(-12345678901234567890f, number.FloatValue, "Number has wrong value");

            number = NSNumber.NumberWithInt(123);
            Check(number);
            Assert.AreEqual(123, number.IntValue, "Number has wrong value");

            number = NSNumber.NumberWithInt(-123456);
            Check(number);
            Assert.AreEqual(-123456, number.IntValue, "Number has wrong value");
        }

        [Test]
        public void TestInstanceCreation()
        {
            NSNumber number;

            number = new NSNumber(true);
            Check(number);
            Assert.AreEqual(1, number.IntValue, "Number has wrong value");
            number.Autorelease();

            number = new NSNumber(false);
            Check(number);
            Assert.AreEqual(0, number.IntValue, "Number has wrong value");
            number.Autorelease();

            number = new NSNumber(123.456d);
            Check(number);
            Assert.AreEqual(123.456d, number.DoubleValue, "Number has wrong value");
            number.Autorelease();

            number = new NSNumber(-12345678901234567890d);
            Check(number);
            Assert.AreEqual(-12345678901234567890d, number.DoubleValue, "Number has wrong value");
            number.Autorelease();

            number = new NSNumber(123.456f);
            Check(number);
            Assert.AreEqual(123.456f, number.FloatValue, "Number has wrong value");
            number.Autorelease();

            number = new NSNumber(-12345678901234567890f);
            Check(number);
            Assert.AreEqual(-12345678901234567890f, number.FloatValue, "Number has wrong value");
            number.Autorelease();

            number = new NSNumber(123);
            Check(number);
            Assert.AreEqual(123, number.IntValue, "Number has wrong value");
            number.Autorelease();

            number = new NSNumber(-123456);
            Check(number);
            Assert.AreEqual(-123456, number.IntValue, "Number has wrong value");
            number.Autorelease();
        }

        [Test]
        public void TestOperations()
        {
            NSNumber number;
            
            number = NSNumber.NumberWithInt(234);
            Check(number);
            bool b = number.BoolValue;
            Assert.AreEqual(true, b, "Numbers must be equals");

            number = NSNumber.NumberWithInt(345);
            Check(number);
            short s = number.ShortValue;
            Assert.AreEqual(345, s, "Numbers must be equals");

            number = NSNumber.NumberWithInt(456);
            Check(number);
            long ll = number.LongLongValue;
            Assert.AreEqual(456, ll, "Numbers must be equals");
        }

        private static void Check(NSNumber number)
        {
            Assert.IsNotNull(number, "Number cannot be null");
            Assert.AreNotEqual(IntPtr.Zero, number.NativePointer, "Native pointer cannot be null");
        }
    }
}