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
using Monobjc.Types;
using NUnit.Framework;

namespace Monobjc
{
    [TestFixture]
    [Category("Runtime")]
    [Category("Messaging")]
    [Description("Test native messaging")]
    public class MessagingTests : RuntimeTests
    {
        [Test]
        public void TestVoidMessaging()
        {
            IntPtr array = objc_sendMsg_IntPtr(this.cls_NSMutableArray, this.sel_alloc);
            Assert.AreNotEqual(IntPtr.Zero, array, "NSMutableArray allocation failed");
            array = objc_sendMsg_IntPtr(array, this.sel_init);
            Assert.AreNotEqual(IntPtr.Zero, array, "NSMutableArray initialization failed");

            ObjectiveCRuntime.SendMessage(array, "release");
            Assert.IsTrue(true);
        }

        [Test]
        public void TestBoolMessaging()
        {
            bool value1 = true;
            Id number = ObjectiveCRuntime.SendMessage<Id>(this.cls_NSNumber, "numberWithBool:", value1);
            Assert.AreNotEqual(IntPtr.Zero, number, "Number creation cannot failed");
            bool value2 = ObjectiveCRuntime.SendMessage<bool>(number, "boolValue");
            Assert.AreEqual(value1, value2, "Bool values must be equal");
        }

        [Test]
        public void TestShortMessaging()
        {
            short value1 = (short) new Random().Next(-5000, 5000);
            Id number = ObjectiveCRuntime.SendMessage<Id>(this.cls_NSNumber, "numberWithShort:", value1);
            Assert.AreNotEqual(IntPtr.Zero, number, "Number creation cannot failed");
            short value2 = ObjectiveCRuntime.SendMessage<short>(number, "shortValue");
            Assert.AreEqual(value1, value2, "Short values must be equal");
        }

        [Test]
        public void TestIntMessaging()
        {
            int value1 = new Random().Next(-65000, 65000);
            Id number = ObjectiveCRuntime.SendMessage<Id>(this.cls_NSNumber, "numberWithInt:", value1);
            Assert.AreNotEqual(IntPtr.Zero, number, "Number creation cannot failed");
            int value2 = ObjectiveCRuntime.SendMessage<int>(number, "intValue");
            Assert.AreEqual(value1, value2, "Int values must be equal");
        }

        [Test]
        public void TestIntegerMessaging()
        {
            int value1 = new Random().Next(-65000, 65000);
            Id number = ObjectiveCRuntime.SendMessage<Id>(this.cls_NSNumber, "numberWithInteger:", value1);
            Assert.AreNotEqual(IntPtr.Zero, number, "Number creation cannot failed");
            int value2 = ObjectiveCRuntime.SendMessage<int>(number, "integerValue");
            Assert.AreEqual(value1, value2, "Int values must be equal");
        }

        [Test]
        public void TestLongMessaging()
        {
            long value1 = new Random().Next(-65000, 65000);
            Id number = ObjectiveCRuntime.SendMessage<Id>(this.cls_NSNumber, "numberWithLongLong:", value1);
            Assert.AreNotEqual(IntPtr.Zero, number, "Number creation cannot failed");
            long value2 = ObjectiveCRuntime.SendMessage<long>(number, "longLongValue");
            Assert.AreEqual(value1, value2, "Long values must be equal");
        }

        [Test]
        public void TestFloatMessaging()
        {
            float value1 = (new Random().Next(-65000, 65000))*3.1415f;
            Id number = ObjectiveCRuntime.SendMessage<Id>(this.cls_NSNumber, "numberWithFloat:", value1);
            Assert.AreNotEqual(IntPtr.Zero, number, "Number creation cannot failed");
            float value2 = ObjectiveCRuntime.SendMessage<float>(number, "floatValue");
            Assert.AreEqual(value1, value2, 0.01, "Long values must be equal");
        }

        [Test]
        public void TestDoubleMessaging()
        {
            double value1 = (new Random().Next(-65000, 65000))*3.1415d;
            Id number = ObjectiveCRuntime.SendMessage<Id>(this.cls_NSNumber, "numberWithDouble:", value1);
            Assert.AreNotEqual(IntPtr.Zero, number, "Number creation cannot failed");
            double value2 = ObjectiveCRuntime.SendMessage<double>(number, "doubleValue");
            Assert.AreEqual(value1, value2, 0.01, "Double values must be equal");
        }

        [Test]
        public void TestSmallStructMessaging()
        {
            TSPoint value1 = new TSPoint(new Random().Next(-65000, 65000)*1.5f, new Random().Next(-65000, 65000)*1.5f);
            Id value = ObjectiveCRuntime.SendMessage<Id>(this.cls_NSValue, "valueWithPoint:", value1);
            Assert.AreNotEqual(IntPtr.Zero, value, "Value creation cannot failed");
            TSPoint value2 = ObjectiveCRuntime.SendMessage<TSPoint>(value, "pointValue");
            Assert.AreEqual(value1, value2, "Point values must be equal");
        }

        [Test]
        public void TestBigStructMessaging()
        {
            TSRect value1 = new TSRect(42, new Random().Next(-65000, 65000)*1.5f, new Random().Next(-65000, 65000)*1.5f, 42);
            Id value = ObjectiveCRuntime.SendMessage<Id>(this.cls_NSValue, "valueWithRect:", value1);
            Assert.AreNotEqual(IntPtr.Zero, value, "Value creation cannot failed");
            TSRect value2 = ObjectiveCRuntime.SendMessage<TSRect>(value, "rectValue");
            Assert.AreEqual(value1, value2, "Rect values must be equal");
        }

        [Test]
        public void TestStringMessaging()
        {
            Id str = ObjectiveCRuntime.SendMessage<Id>(this.cls_NSString, "stringWithUTF8String:", "AbCdEfGhIjKlMnOpQrStUvWxYz");
            Assert.AreNotEqual(IntPtr.Zero, str, "String creation cannot failed");
        }

        [Test]
        public void TestIdMessaging()
        {
            Id str = ObjectiveCRuntime.SendMessage<Id>(this.cls_NSString, "stringWithUTF8String:", "AbCdEfGhIjKlMnOpQrStUvWxYz");
            Assert.AreNotEqual(IntPtr.Zero, str, "String creation cannot failed");
            Id array = ObjectiveCRuntime.SendMessage<Id>(this.cls_NSArray, "arrayWithObject:", str);
            Assert.AreNotEqual(IntPtr.Zero, array, "Array creation cannot failed");
            uint count = ObjectiveCRuntime.SendMessage<uint>(array, "count");
            Assert.AreEqual(1, count, "Array must have 1 element");
        }

        [Test]
        public void TestClassMessaging()
        {
            Id str = ObjectiveCRuntime.SendMessage<Id>(this.cls_NSString, "stringWithUTF8String:", "AbCdEfGhIjKlMnOpQrStUvWxYz");
            Assert.AreNotEqual(IntPtr.Zero, str, "String creation cannot failed");
            bool test = ObjectiveCRuntime.SendMessage<bool>(str, "isKindOfClass:", Class.Get("NSString"));
            Assert.IsTrue(test, "String should be of the right class.");
        }

#if MACOSX_10_6 && HAVE_BLOCK_SUPPORT
        [Test]
        public void TestBlockMessaging()
        {
            Id str = ObjectiveCRuntime.SendMessage<Id>(this.cls_NSString, "stringWithUTF8String:", "AbCdEfGhIjKlMnOpQrStUvWxYz");
            Assert.AreNotEqual(IntPtr.Zero, str, "String creation cannot failed");
            Id array = ObjectiveCRuntime.SendMessage<Id>(this.cls_NSArray, "arrayWithObject:", str);
            Assert.AreNotEqual(IntPtr.Zero, array, "Array creation cannot failed");
            uint count = ObjectiveCRuntime.SendMessage<uint>(array, "count");
            Assert.AreEqual(1, count, "Array must have 1 element");

            Func<Id, Id, int> comparator = delegate { return 0; };
            using (Block block = ObjectiveCRuntime.CreateBlock(comparator))
            {
                Id sortedArray = ObjectiveCRuntime.SendMessage<Id>(array, "sortedArrayUsingComparator:", block);
                Assert.AreNotEqual(IntPtr.Zero, sortedArray, "Array sort cannot failed");
                count = ObjectiveCRuntime.SendMessage<uint>(sortedArray, "count");
                Assert.AreEqual(1, count, "Array must have 1 element");
            }
        }
#endif

        [Test]
        public void TestMessagingException()
        {
            Assert.Throws<ObjectiveCMessagingException>(() => ObjectiveCRuntime.SendMessage<Id>(this.cls_NSString, "stringWithString:", (Id) null));
            Assert.Throws<ObjectiveCMessagingException>(() => ObjectiveCRuntime.SendMessage<Id>(this.cls_NSString, "stringWithUTF8:", "AbCdEfGhIjKlMnOpQrStUvWxYz"));
        }
    }
}