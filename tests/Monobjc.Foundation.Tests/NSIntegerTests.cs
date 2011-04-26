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
            NSInteger value = 5678;

            short s;
            int i;
            long l;
            ushort us;
            uint ui;
            ulong ul;
            float f;
            double d;
            NSInteger nint;
            NSUInteger nuint;
            CGFloat cgfloat;

            s = value;
            Assert.AreEqual((short)value, s, "Value must be equal");
            i = value;
            Assert.AreEqual((int)value, i, "Value must be equal");
            l = value;
            Assert.AreEqual((long)value, l, "Value must be equal");
            us = value;
            Assert.AreEqual((ushort)value, s, "Value must be equal");
            ui = value;
            Assert.AreEqual((uint)value, ui, "Value must be equal");
            ul = value;
            Assert.AreEqual((ulong)value, ul, "Value must be equal");
            f = value;
            Assert.AreEqual((float)value, f, "Value must be equal");
            d = value;
            Assert.AreEqual((double)value, d, "Value must be equal");
            nint = value;
            Assert.AreEqual((NSInteger)value, nint, "Value must be equal");
            nuint = value;
            Assert.AreEqual((NSUInteger)value, nuint, "Value must be equal");
            cgfloat = value;
            Assert.AreEqual((CGFloat)value, cgfloat, "Value must be equal");
        }
    }
}