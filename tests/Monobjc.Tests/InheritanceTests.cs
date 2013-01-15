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
using Monobjc.Types;
using NUnit.Framework;

namespace Monobjc
{
    [TestFixture]
    [Category("Runtime")]
    [Category("Exposal")]
    [Category("Inheritance")]
    [Description("Test messaging to the exposed classes")]
    public class InheritanceTests : RuntimeTests
    {
        [Test]
        public void TestOneLevelInheritance()
        {
            InheritanceTest01 instance = new InheritanceTest01();
            Assert.IsTrue(instance.inCtor1);
            instance.Release();
        }

        [Test]
        public void TestTowLevelsInheritance()
        {
            InheritanceTest02 instance = new InheritanceTest02();
            Assert.IsTrue(instance.inCtor1);
            Assert.IsTrue(instance.inCtor2);
            instance.Release();
        }

        [Test]
        public void TestDesignatedInitializers()
        {
            InheritanceTest03 instance = new InheritanceTest03(0);
            Assert.IsTrue(instance.inIntCtor);
            Assert.IsFalse(instance.inFloatCtor);
            instance.Release();

            instance = new InheritanceTest03(1.5f);
            Assert.IsTrue(instance.inIntCtor);
            Assert.IsTrue(instance.inFloatCtor);
            instance.Release();
        }
    }

    [ObjectiveCClass("InheritanceTest01")]
    public class InheritanceTest01 : TSObject
    {
        public static Class InheritanceTest01Class = Class.Get(typeof (InheritanceTest01));

        internal bool inCtor1;

        public InheritanceTest01()
        {
            Assert.IsTrue(this.inCtor1);
        }

        public InheritanceTest01(IntPtr value) : base(value) {}

        [ObjectiveCMessage("init")]
        public override Id Init()
        {
            this.NativePointer = this.SendMessageSuper<IntPtr>(InheritanceTest01Class, "init");
            this.inCtor1 = true;
            return this;
        }
    }

    [ObjectiveCClass("InheritanceTest02")]
    public class InheritanceTest02 : InheritanceTest01
    {
        public static Class InheritanceTest02Class = Class.Get(typeof (InheritanceTest02));

        internal bool inCtor2;

        public InheritanceTest02()
        {
            Assert.IsTrue(this.inCtor1);
            Assert.IsTrue(this.inCtor2);
        }

        public InheritanceTest02(IntPtr value) : base(value) {}

        [ObjectiveCMessage("init")]
        public override Id Init()
        {
            this.NativePointer = this.SendMessageSuper<IntPtr>(InheritanceTest02Class, "init");
            this.inCtor2 = true;
            return this;
        }
    }

    [ObjectiveCClass("InheritanceTest03")]
    public class InheritanceTest03 : TSObject
    {
        public static Class InheritanceTest03Class = Class.Get(typeof (InheritanceTest03));

        internal bool inIntCtor;
        internal bool inFloatCtor;

        public InheritanceTest03() {}

        public InheritanceTest03(IntPtr value) : base(value) {}

        public InheritanceTest03(int value) : base("initWithInt:", value) {}

        public InheritanceTest03(float value) : base("initWithFloat:", value) {}

        [ObjectiveCMessage("init")]
        public override Id Init()
        {
            this.NativePointer = this.SendMessageSuper<IntPtr>(InheritanceTest03Class, "init");
            return this;
        }

        [ObjectiveCMessage("initWithInt:")]
        public Id Init(int value)
        {
            this.NativePointer = this.SendMessageSuper<IntPtr>(InheritanceTest03Class, "init");
            this.inIntCtor = true;
            return this;
        }

        [ObjectiveCMessage("initWithFloat:")]
        public Id Init(float value)
        {
            this.NativePointer = this.SendMessage<IntPtr>("initWithInt:", Convert.ToInt32(value));
            this.inFloatCtor = true;
            return this;
        }
    }
}