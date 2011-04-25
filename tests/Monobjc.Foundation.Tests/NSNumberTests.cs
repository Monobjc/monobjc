//
// This file is part of Monobjc, a .NET/Objective-C bridge
// Copyright (C) 2007-2011 - Laurent Etiemble
//
// Monobjc is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// any later version.
//
// Monobjc is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with Monobjc.  If not, see <http://www.gnu.org/licenses/>.
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

        //[Test]
        //public void TestInstanceCreation()
        //{
        //    NSNumber number;

        //    number = new NSNumber(true);
        //    Check(number);
        //    Assert.AreEqual(1, number.IntValue, "Number has wrong value");
        //    number.Autorelease();

        //    number = new NSNumber(false);
        //    Check(number);
        //    Assert.AreEqual(0, number.IntValue, "Number has wrong value");
        //    number.Autorelease();

        //    number = new NSNumber(123.456d);
        //    Check(number);
        //    Assert.AreEqual(123.456d, number.DoubleValue, "Number has wrong value");
        //    number.Autorelease();

        //    number = new NSNumber(-12345678901234567890d);
        //    Check(number);
        //    Assert.AreEqual(-12345678901234567890d, number.DoubleValue, "Number has wrong value");
        //    number.Autorelease();

        //    number = new NSNumber(123.456f);
        //    Check(number);
        //    Assert.AreEqual(123.456f, number.FloatValue, "Number has wrong value");
        //    number.Autorelease();

        //    number = new NSNumber(-12345678901234567890f);
        //    Check(number);
        //    Assert.AreEqual(-12345678901234567890f, number.FloatValue, "Number has wrong value");
        //    number.Autorelease();

        //    number = new NSNumber(123);
        //    Check(number);
        //    Assert.AreEqual(123, number.IntValue, "Number has wrong value");
        //    number.Autorelease();

        //    number = new NSNumber(-123456);
        //    Check(number);
        //    Assert.AreEqual(-123456, number.IntValue, "Number has wrong value");
        //    number.Autorelease();
        //}

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