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