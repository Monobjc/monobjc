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
using System;
using NUnit.Framework;

namespace Monobjc.Foundation
{
    [TestFixture]
    [Category("NSValue")]
    [Description("Test with NSValue wrapper")]
    public class NSValueTests : WrapperTests
    {
        [Test]
        public void TestStaticCreation()
        {
            NSPoint refPoint = new NSPoint(1, 2);
            NSValue val = NSValue.ValueWithPoint(refPoint);
            Check(val);
            NSPoint point = val.PointValue;
            Assert.AreEqual(refPoint, point, "Points must be equal");

            NSRange refRange = new NSRange(3, 4);
            val = NSValue.ValueWithRange(refRange);
            Check(val);
            NSRange range = val.RangeValue;
            Assert.AreEqual(refRange, range, "Ranges must be equal");

            NSRect refRect = new NSRect(5, 6, 789, 789);
            val = NSValue.ValueWithRect(refRect);
            Check(val);
            NSRect rect = val.RectValue;
            Assert.AreEqual(refRect, rect, "Rectangles must be equal");

            NSSize refSize = new NSSize(456, 789);
            val = NSValue.ValueWithSize(refSize);
            Check(val);
            NSSize size = val.SizeValue;
            Assert.AreEqual(refSize, size, "Sizes must be equal");
        }

        private static void Check(NSValue val)
        {
            Assert.IsNotNull(val, "Value cannot be null");
            Assert.AreNotEqual(IntPtr.Zero, val.NativePointer, "Native pointer cannot be null");
        }
    }
}