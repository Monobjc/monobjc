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
using System;
using Monobjc.Types;
using NUnit.Framework;

namespace Monobjc
{
    [TestFixture]
    [Category("Runtime")]
    [Category("Exposal")]
    [Category("Messaging")]
    [Description("Test messaging to the exposed classes")]
    public class ClassesMessagingTests : RuntimeTests
    {
        [Test]
        public void TestVoidMessaging()
        {
            IntPtr instance = objc_sendMsg_IntPtr(Class.Get(typeof (MessageTest01)).NativePointer, this.sel_alloc);
            Assert.AreNotEqual(IntPtr.Zero, instance, "Instance allocation failed");
            instance = objc_sendMsg_IntPtr(instance, this.sel_init);
            Assert.AreNotEqual(IntPtr.Zero, instance, "Instance initialization failed");

            objc_sendMsg_void(instance, this.sel_release);
            Assert.IsTrue(true);
        }

        [Test]
        public void TestBoolMessaging()
        {
            IntPtr instance = objc_sendMsg_IntPtr(Class.Get(typeof (MessageTest01)).NativePointer, this.sel_alloc);
            Assert.AreNotEqual(IntPtr.Zero, instance, "Instance allocation failed");
            instance = objc_sendMsg_IntPtr(instance, this.sel_init);
            Assert.AreNotEqual(IntPtr.Zero, instance, "Instance initialization failed");

            IntPtr sel = sel_registerName("doWithBool:");

            bool value1 = true;
            bool value2 = objc_sendMsg_bool_bool(instance, sel, value1);
            Assert.AreEqual(value1, value2, "Bool values must be equal");

            value1 = false;
            value2 = objc_sendMsg_bool_bool(instance, sel, value1);
            Assert.AreEqual(value1, value2, "Bool values must be equal");

            objc_sendMsg_void(instance, this.sel_release);
            Assert.IsTrue(true);
        }

        [Test]
        public void TestShortMessaging()
        {
            MessageTest01 instance = new MessageTest01();

            short value1 = (short) new Random().Next(-5000, 5000);
            short value2 = ObjectiveCRuntime.SendMessage<short>(instance, "doWithShort:", value1);
            Assert.AreEqual(value1, value2, "Short values must be equal");

            instance.Release();
            Assert.IsTrue(true);
        }

        [Test]
        public void TestIntMessaging()
        {
            MessageTest01 instance = new MessageTest01();

            int value1 = new Random().Next(-65000, 65000);
            int value2 = ObjectiveCRuntime.SendMessage<int>(instance, "doWithInt:", value1);
            Assert.AreEqual(value1, value2, "Int values must be equal");

            instance.Release();
            Assert.IsTrue(true);
        }

        [Test]
        public void TestLongMessaging()
        {
            MessageTest01 instance = new MessageTest01();

            long value1 = new Random().Next(-65000, 65000);
            long value2 = ObjectiveCRuntime.SendMessage<long>(instance, "doWithLong:", value1);
            Assert.AreEqual(value1, value2, "Long values must be equal");

            instance.Release();
            Assert.IsTrue(true);
        }

        /*
		[Test]
		public void TestMessagingException()
		{
            IntPtr instance = objc_sendMsg_IntPtr(Class.Get(typeof(MessageTest02)).NativePointer, this.sel_alloc);
            Assert.AreNotEqual(IntPtr.Zero, instance, "Instance allocation failed");
            instance = objc_sendMsg_IntPtr(instance, this.sel_init);
            Assert.AreNotEqual(IntPtr.Zero, instance, "Instance initialization failed");

			//IntPtr sel = sel_registerName("generateNotImplementedException");
			//objc_sendMsg_void(instance, sel);
			ObjectiveCRuntime.SendMessage(instance, "generateNotImplementedException");
			
			//Assert.Throws<NotImplementedException>( () => ObjectiveCRuntime.SendMessage(instance, "generateNotImplementedException") );
			//Assert.Throws<NotImplementedException>( () => ObjectiveCRuntime.SendMessage(instance, "generateNotImplementedExceptionWithValue:", 123) );
			
			objc_sendMsg_void(instance, sel_release);
			Assert.IsTrue(true);
		}
        */
    }

    [ObjectiveCClass]
    public class MessageTest01 : TSObject
    {
        public MessageTest01() {}

        public MessageTest01(IntPtr value) : base(value) {}

        [ObjectiveCMessage("doWithBool:")]
        public bool DoWithBool(bool value)
        {
            return value;
        }

        [ObjectiveCMessage("doWithShort:")]
        public short DoWithShort(short value)
        {
            return value;
        }

        [ObjectiveCMessage("doWithInt:")]
        public int DoWithShort(int value)
        {
            return value;
        }

        [ObjectiveCMessage("doWithLong:")]
        public long DoWithShort(long value)
        {
            return value;
        }
    }

    [ObjectiveCClass]
    public class MessageTest02 : TSObject
    {
        public MessageTest02() {}

        public MessageTest02(IntPtr value) : base(value) {}

        [ObjectiveCMessage("generateNotImplementedException")]
        public void GenerateNotImplementedException()
        {
            //throw new NotImplementedException("TEST");
        }

        [ObjectiveCMessage("generateNotImplementedExceptionWithValue:")]
        public void GenerateNotImplementedException(int value)
        {
            //throw new NotImplementedException("value=" + value);
        }
    }
}