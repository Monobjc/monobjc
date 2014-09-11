//
// This file is part of Monobjc, a .NET/Objective-C bridge
// Copyright (C) 2007-2014 - Laurent Etiemble
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
        private Id CopyWithZone(IntPtr zone)
        {
            return this;
        }
    }
}