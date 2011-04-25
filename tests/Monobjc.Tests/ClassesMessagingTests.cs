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