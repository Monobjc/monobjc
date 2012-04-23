//
// This file is part of Monobjc, a .NET/Objective-C bridge
// Copyright (C) 2007-2012 - Laurent Etiemble
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
using Monobjc.ApplicationServices;
using NUnit.Framework;

namespace Monobjc.Foundation
{
    [TestFixture]
    [Category("NSInteger")]
    public class NSIntegerTests : WrapperTests
    {
        [Test]
        public void TestCasting()
        {
            NSInteger value;

            short s = -123;
            int i = -123456;
            long l = -1234567890;
            ushort us = 123;
            uint ui = 123456;
            ulong ul = 1234567890;
            float f = 12345.6789f;
            double d = 12345.6789d;
            //NSInteger nint = -123456;
            NSUInteger nuint = 123456;
            CGFloat cgfloat = new CGFloat(12345.6789f);

            value = s;
            Assert.AreEqual(value, new NSInteger(s), "Value must be equal");
            value = i;
            Assert.AreEqual(value, new NSInteger(i), "Value must be equal");
            value = l;
            Assert.AreEqual(value, new NSInteger((int)l), "Value must be equal");
            value = us;
            Assert.AreEqual(value, new NSInteger(us), "Value must be equal");
            value = ui;
            Assert.AreEqual(value, new NSInteger((int)ui), "Value must be equal");
            value = ul;
            Assert.AreEqual(value, new NSInteger((int)ul), "Value must be equal");
            value = (NSInteger) f;
            Assert.AreEqual(value, new NSInteger((int)f), "Value must be equal");
            value = (NSInteger) d;
            Assert.AreEqual(value, new NSInteger((int)d), "Value must be equal");
            //value = nint;
            //Assert.AreEqual(value, new NSInteger(nint.value), "Value must be equal");
            value = nuint;
            Assert.AreEqual(value, new NSInteger((int)nuint.value), "Value must be equal");
            value = (NSInteger) cgfloat;
            Assert.AreEqual(value, new NSInteger((int)cgfloat.value), "Value must be equal");
        }
    }
}