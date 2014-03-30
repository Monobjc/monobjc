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
    [Category("NSUInteger")]
    public class NSUIntegerTests : WrapperTests
    {
        [Test]
        public void TestCasting()
        {
            NSUInteger value;

            short s = -123;
            int i = -123456;
            long l = -1234567890;
            ushort us = 123;
            uint ui = 123456;
            ulong ul = 1234567890;
            float f = 12345.6789f;
            double d = 12345.6789d;
            NSInteger nint = -123456;
            //NSUInteger nuint = 123456;
            CGFloat cgfloat = new CGFloat(12345.6789f);

            value = s;
            Assert.AreEqual(value, new NSUInteger((uint)s), "Value must be equal");
            value = i;
            Assert.AreEqual(value, new NSUInteger((uint)i), "Value must be equal");
            value = l;
            Assert.AreEqual(value, new NSUInteger((uint)l), "Value must be equal");
            value = us;
            Assert.AreEqual(value, new NSUInteger(us), "Value must be equal");
            value = ui;
            Assert.AreEqual(value, new NSUInteger(ui), "Value must be equal");
            value = ul;
            Assert.AreEqual(value, new NSUInteger((uint)ul), "Value must be equal");
            value = (NSInteger) f;
            Assert.AreEqual(value, new NSUInteger((uint)f), "Value must be equal");
            value = (NSInteger) d;
            Assert.AreEqual(value, new NSUInteger((uint)d), "Value must be equal");
            value = nint;
            Assert.AreEqual(value, new NSUInteger((uint)nint.value), "Value must be equal");
            //value = nuint;
            //Assert.AreEqual(value, new NSUInteger(nuint.value), "Value must be equal");
            value = (NSInteger) cgfloat;
            Assert.AreEqual(value, new NSUInteger((uint)cgfloat.value), "Value must be equal");
        }
		
        [Test]
        public void TestConstant()
        {
			uint value = NSUInteger.NSNotFound;
			
			if (ObjectiveCRuntime.Is64Bits) {
	            Assert.AreEqual(value, UInt32.MaxValue, "Value must be equal");
			} else {
	            Assert.AreEqual(value, Int32.MaxValue, "Value must be equal");
			}
		}
    }
}