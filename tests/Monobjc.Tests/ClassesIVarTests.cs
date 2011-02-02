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
    [Category("IVars")]
    [Description("Test ivar access to the exposed classes")]
    public class ClassesIVarTests : RuntimeTests
    {
        [Test]
        public void TestPrimitiveIVar()
        {
            IVarTest01 varTest01 = new IVarTest01();

            int intValue = new Random().Next(-42, 42);
            varTest01.IntProperty = intValue;
            Assert.AreEqual(intValue, varTest01.IntProperty, "Int property must be equals");

            varTest01.Release();
        }

        [Test]
        public void TestPointerIVar()
        {
            IVarTest02 varTest02 = new IVarTest02();

            TSObject instanceValue = new TSObject();
            varTest02.InstanceProperty = instanceValue;
            Assert.AreEqual(instanceValue, varTest02.InstanceProperty, "Instance property must be equals");
            Assert.AreEqual(instanceValue.NativePointer, varTest02.InstanceProperty.NativePointer, "Instance property must be equals");

            varTest02.Release();
        }

        [Test]
        public void TestStructIVar()
        {
            IVarTest03 varTest03 = new IVarTest03();

            TSRange rangeValue = new TSRange();
            rangeValue.location = (uint) new Random().Next(0, 1000);
            rangeValue.length = (uint) new Random().Next(3000, 6000);
            varTest03.RangeProperty = rangeValue;
            Assert.AreEqual(rangeValue, varTest03.RangeProperty, "Range property must be equals");
            Assert.AreEqual(rangeValue.location, varTest03.RangeProperty.location, "Range property location must be equals");
            Assert.AreEqual(rangeValue.length, varTest03.RangeProperty.length, "Range property length must be equals");

            varTest03.Release();
        }

        [Test]
        public void TestMultipleIVar()
        {
            IVarTest04 varTest04 = new IVarTest04();

            varTest04.BoolProperty = true;
            Assert.AreEqual(true, varTest04.BoolProperty, "Bool property must be equals");

            varTest04.BoolProperty = false;
            Assert.AreEqual(false, varTest04.BoolProperty, "Bool property must be equals");

            short shortValue = (short) new Random().Next(-42, 42);
            varTest04.ShortProperty = shortValue;
            Assert.AreEqual(shortValue, varTest04.ShortProperty, "Short property must be equals");

            int intValue = new Random().Next(-42, 42);
            varTest04.IntProperty = intValue;
            Assert.AreEqual(intValue, varTest04.IntProperty, "Int property must be equals");

            long longValue = new Random().Next(-42, 42);
            varTest04.LongProperty = longValue;
            Assert.AreEqual(longValue, varTest04.LongProperty, "Long property must be equals");

            TSObject instanceValue = new TSObject();
            varTest04.InstanceProperty = instanceValue;
            Assert.AreEqual(instanceValue, varTest04.InstanceProperty, "Instance property must be equals");
            Assert.AreEqual(instanceValue.NativePointer, varTest04.InstanceProperty.NativePointer, "Instance property must be equals");

            TSRect rectValue = new TSRect();
            rectValue.origin.x = (uint) new Random().Next(0, 1000);
            rectValue.origin.y = (uint) new Random().Next(2000, 3000);
            rectValue.size.width = (uint) new Random().Next(500, 1000);
            rectValue.size.height = (uint) new Random().Next(4000, 5000);
            varTest04.RectProperty = rectValue;
            Assert.AreEqual(rectValue, varTest04.RectProperty, "Rect property must be equals");
            Assert.AreEqual(rectValue.origin, varTest04.RectProperty.origin, "Rect property origin must be equals");
            Assert.AreEqual(rectValue.size, varTest04.RectProperty.size, "Rect property size must be equals");

            varTest04.Release();
        }
    }

    [ObjectiveCClass]
    public class IVarTest01 : TSObject
    {
        public IVarTest01() {}

        public IVarTest01(IntPtr value) : base(value) {}

        [ObjectiveCIVar("intProperty")]
        public int IntProperty
        {
            get { return this.GetInstanceVariable<int>("intProperty"); }
            set { this.SetInstanceVariable("intProperty", value); }
        }
    }

    [ObjectiveCClass]
    public class IVarTest02 : TSObject
    {
        public IVarTest02() {}

        public IVarTest02(IntPtr value) : base(value) {}

        [ObjectiveCIVar("instanceProperty")]
        public TSObject InstanceProperty
        {
            get { return this.GetInstanceVariable<TSObject>("instanceProperty"); }
            set { this.SetInstanceVariable("instanceProperty", value); }
        }
    }

    [ObjectiveCClass]
    public class IVarTest03 : TSObject
    {
        public IVarTest03() {}

        public IVarTest03(IntPtr value) : base(value) {}

        [ObjectiveCIVar("rangeProperty")]
        public TSRange RangeProperty
        {
            get { return this.GetInstanceVariable<TSRange>("rangeProperty"); }
            set { this.SetInstanceVariable("rangeProperty", value); }
        }
    }

    [ObjectiveCClass]
    public class IVarTest04 : TSObject
    {
        public IVarTest04() {}

        public IVarTest04(IntPtr value) : base(value) {}

        [ObjectiveCIVar("boolProperty")]
        public bool BoolProperty
        {
            get { return this.GetInstanceVariable<bool>("boolProperty"); }
            set { this.SetInstanceVariable("boolProperty", value); }
        }

        [ObjectiveCIVar("shortProperty")]
        public short ShortProperty
        {
            get { return this.GetInstanceVariable<short>("shortProperty"); }
            set { this.SetInstanceVariable("shortProperty", value); }
        }

        [ObjectiveCIVar("intProperty")]
        public int IntProperty
        {
            get { return this.GetInstanceVariable<int>("intProperty"); }
            set { this.SetInstanceVariable("intProperty", value); }
        }

        [ObjectiveCIVar("longProperty")]
        public long LongProperty
        {
            get { return this.GetInstanceVariable<long>("longProperty"); }
            set { this.SetInstanceVariable("longProperty", value); }
        }

        [ObjectiveCIVar("instanceProperty")]
        public TSObject InstanceProperty
        {
            get { return this.GetInstanceVariable<TSObject>("instanceProperty"); }
            set { this.SetInstanceVariable("instanceProperty", value); }
        }

        [ObjectiveCIVar("rectProperty")]
        public TSRect RectProperty
        {
            get { return this.GetInstanceVariable<TSRect>("rectProperty"); }
            set { this.SetInstanceVariable("rectProperty", value); }
        }
    }
}