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
    [Description("Test messaging to the exposed wrappers")]
    public class WrapperMessagingTests : RuntimeTests
    {
        [Test]
        public void TestWrapperMessaging()
        {
            IntPtr instance = objc_sendMsg_IntPtr(Class.Get(typeof (WrapperTest01)).NativePointer, this.sel_alloc);
            Assert.AreNotEqual(IntPtr.Zero, instance, "Instance allocation failed");
            instance = objc_sendMsg_IntPtr(instance, this.sel_init);
            Assert.AreNotEqual(IntPtr.Zero, instance, "Instance initialization failed");

			ITSObject wrapper = ObjectiveCRuntime.GetInstance<ITSObject>(instance);
            Assert.IsNotNull(wrapper, "Wrapper cannot be null");
            Assert.AreNotEqual(IntPtr.Zero, wrapper.NativePointer, "Instance retrieval has failed");
			
			bool isProxy = wrapper.IsProxy;
			Assert.IsFalse(isProxy, "Class is not a proxy");
        }
    }

    [ObjectiveCClass]
    public class WrapperTest01 : TSObject
    {
        public WrapperTest01() {}

        public WrapperTest01(IntPtr value) : base(value) {}

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
		
        [ObjectiveCMessage("copyWithZone:")]
        Id CopyWithZone(IntPtr zone)
		{
			return this;
		}
    }
}