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
		public static Class InheritanceTest01Class = Class.Get(typeof(InheritanceTest01));
		
		internal bool inCtor1;
				
        public InheritanceTest01()
		{
			Assert.IsTrue(this.inCtor1);
		}
		
        public InheritanceTest01(IntPtr value) : base(value)
		{
		}
		
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
		public static Class InheritanceTest02Class = Class.Get(typeof(InheritanceTest02));
		
		internal bool inCtor2;
		
        public InheritanceTest02()
		{
			Assert.IsTrue(this.inCtor1);
			Assert.IsTrue(this.inCtor2);
		}
		
        public InheritanceTest02(IntPtr value) : base(value)
		{
		}
		
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
		public static Class InheritanceTest03Class = Class.Get(typeof(InheritanceTest03));
		
		internal bool inIntCtor;
		internal bool inFloatCtor;
		
        public InheritanceTest03()
		{
		}
		
        public InheritanceTest03(IntPtr value) : base(value)
		{
		}
		
        public InheritanceTest03(int value) : base("initWithInt:", value)
		{
		}
		
        public InheritanceTest03(float value) : base("initWithFloat:", value)
		{
		}
		
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