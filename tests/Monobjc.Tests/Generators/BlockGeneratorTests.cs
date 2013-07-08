//
// This file is part of Monobjc, a .NET/Objective-C bridge
// Copyright (C) 2007-2013 - Laurent Etiemble
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
using System.Reflection;
using Monobjc.Types;
using NUnit.Framework;
using System.Linq;

namespace Monobjc.Generators
{
    public delegate void ArbitraryDelegate1(TSObject obj, TSInteger index, bool stop); 

    public delegate void ArbitraryDelegate2(TSObject obj, TSInteger index, ref bool stop); 

    public delegate void ArbitraryDelegate3(TSObject obj, TSInteger index, out TSObject outObj); 
		
	[TestFixture]
    [Category("Blocks")]
    [Category("Generators")]
    [Description("Test block proxies creation")]
    public class BlockGeneratorTests
    {
        private static int counter;

        [SetUp]
        public void SetUp()
        {
            ObjectiveCRuntime.LoadFramework("Cocoa");
            ObjectiveCRuntime.Initialize();
        }

        [Test]
        public void TestBlockGenerationErrors()
        {
            counter = 10;

            Assert.Throws<ArgumentNullException>(() => this.TestBlock(null, null, false));
            Assert.Throws<ObjectiveCCodeGenerationException>(() => this.TestBlock(typeof (Object), null, false));
        }

        [Test]
        public void TestBlockGenerationForActionNumberOfParameter()
        {
            counter = 20;

            // Test number of parameters
            this.TestBlock(typeof (Action), typeof (Block_Void), false);
            this.TestBlock(typeof (Action<int>), typeof (Block_Void_Int32), false);
            this.TestBlock(typeof (Action<int, int>), typeof (Block_Void_Int32_Int32), false);
            this.TestBlock(typeof (Action<int, int, int>), typeof (Block_Void_Int32_Int32_Int32), false);
            this.TestBlock(typeof (Action<int, int, int, int>), typeof (Block_Void_Int32_Int32_Int32_Int32), false);
        }

        [Test]
        public void TestBlockGenerationForActionTypeOfParameter()
        {
            counter = 30;

            // Test different type of parameter
            this.TestBlock(typeof (Action<bool>), typeof (Block_Void_Boolean), false);
            this.TestBlock(typeof (Action<byte, ushort, uint, ulong>), typeof (Block_Void_Byte_UInt16_UInt32_UInt64), false);
            this.TestBlock(typeof (Action<TSWindingRule>), typeof (Block_Void_TSWindingRule), false);
            this.TestBlock(typeof (Action<IntPtr, Id, Class, String>), typeof (Block_Void_IntPtr_Id_Class_String), false);
        }

        [Test]
        public void TestBlockGenerationForActionVariableTypes32bits()
        {
            counter = 40;

            // Test variable types (32bits)
            this.TestBlock(typeof (Action<TSIntegerEnumeration, TSUIntegerEnumeration>), typeof (Block_Void_TSIntegerEnumeration_TSUnsignedEnumeration32), false);
            this.TestBlock(typeof (Action<TSInteger, TSUInteger, TSFloat>), typeof (Block_Void_TSInteger_TSUInteger_TSFloat32), false);
            this.TestBlock(typeof (Action<TSRange>), typeof (Block_Void_TSRange32), false);
            this.TestBlock(typeof (Action<TSPoint, TSSize, TSRect>), typeof (Block_Void_TSPoint_TSSize_TSRect32), false);
        }

        [Test]
        public void TestBlockGenerationForActionVariableTypes64bits()
        {
            counter = 50;

            // Test variable types (64bits)
            this.TestBlock(typeof (Action<TSIntegerEnumeration, TSUIntegerEnumeration>), typeof (Block_Void_TSIntegerEnumeration_TSUnsignedEnumeration64), true);
            this.TestBlock(typeof (Action<TSInteger, TSUInteger, TSFloat>), typeof (Block_Void_TSInteger_TSUInteger_TSFloat64), true);
            this.TestBlock(typeof (Action<TSRange>), typeof (Block_Void_TSRange64), true);
            this.TestBlock(typeof (Action<TSPoint, TSSize, TSRect>), typeof (Block_Void_TSPoint_TSSize_TSRect64), true);
        }

        [Test]
        public void TestBlockGenerationForFuncNumberOfParameter()
        {
            counter = 60;

            // Test number of parameters
            this.TestBlock(typeof (Func<int>), typeof (Func_Int32), false);
            this.TestBlock(typeof (Func<int, int>), typeof (Func_Int32_Int32), false);
            this.TestBlock(typeof (Func<int, int, int>), typeof (Func_Int32_Int32_Int32), false);
            this.TestBlock(typeof (Func<int, int, int, int>), typeof (Func_Int32_Int32_Int32_Int32), false);
            this.TestBlock(typeof (Func<int, int, int, int, int>), typeof (Func_Int32_Int32_Int32_Int32_Int32), false);
        }

        [Test]
        public void TestBlockGenerationForFuncTypeOfParameter()
        {
            counter = 70;

            // Test different type of parameter
            this.TestBlock(typeof (Func<IntPtr, IntPtr, int>), typeof (Func_IntPtr_IntPtr_Int32), false);
		}

        [Test]
        public void TestBlockGenerationForFuncVariableTypes32bits()
        {
            counter = 80;

            // Test variable types (32bits)
            this.TestBlock(typeof (Func<TSIntegerEnumeration>), typeof (Block_TSIntegerEnumeration32), false);
            this.TestBlock(typeof (Func<TSUIntegerEnumeration>), typeof (Block_TSUnsignedEnumeration32), false);
            this.TestBlock(typeof (Func<TSInteger>), typeof (Block_TSInteger32), false);
            this.TestBlock(typeof (Func<TSUInteger>), typeof (Block_TSUInteger32), false);
            this.TestBlock(typeof (Func<TSFloat>), typeof (Block_TSFloat32), false);
            this.TestBlock(typeof (Func<TSRange>), typeof (Block_TSRange32), false);
            this.TestBlock(typeof (Func<TSPoint>), typeof (Block_TSPoint32), false);
            this.TestBlock(typeof (Func<TSRect>), typeof (Block_TSRect32), false);
        }

        [Test]
        public void TestBlockGenerationForFuncVariableTypes64bits()
        {
            counter = 90;

            // Test variable types (64bits)
            this.TestBlock(typeof (Func<TSIntegerEnumeration>), typeof (Block_TSIntegerEnumeration64), true);
            this.TestBlock(typeof (Func<TSUIntegerEnumeration>), typeof (Block_TSUnsignedEnumeration64), true);
            this.TestBlock(typeof (Func<TSInteger>), typeof (Block_TSInteger64), true);
            this.TestBlock(typeof (Func<TSUInteger>), typeof (Block_TSUInteger64), true);
            this.TestBlock(typeof (Func<TSFloat>), typeof (Block_TSFloat64), true);
            this.TestBlock(typeof (Func<TSRange>), typeof (Block_TSRange64), true);
            this.TestBlock(typeof (Func<TSPoint>), typeof (Block_TSPoint64), true);
            this.TestBlock(typeof (Func<TSRect>), typeof (Block_TSRect64), true);
        }

        [Test]
        public void TestBlockGenerationForArbitratyDelegate()
        {
            counter = 100;

            this.TestBlock(typeof (ArbitraryDelegate1), typeof (Block_ArbitraryDelegate1), false);
            this.TestBlock(typeof (ArbitraryDelegate2), typeof (Block_ArbitraryDelegate2), false);
            this.TestBlock(typeof (ArbitraryDelegate3), typeof (Block_ArbitraryDelegate3), false);
        }

        private void TestBlock(Type delegateType, Type referenceType, bool is64Bits)
        {
            counter++;

            DynamicAssembly dynamicAssembly = new DynamicAssembly(DynamicAssemblyHelper.GetAssemblyName(this, counter), "MyModule");

            BlockGenerator generator = new BlockGenerator(dynamicAssembly, is64Bits);
            Type proxyType = generator.DefineBlockProxy(delegateType);

            try
            {
                String file = dynamicAssembly.Save();

                Assembly assembly = Assembly.LoadFile(file);
                Type type = assembly.GetTypes().Single(t => t.FullName == proxyType.FullName);
                DynamicAssemblyHelper.Compare(referenceType, type);
            }
            catch (Exception ex)
            {
                Assert.Fail("Type retrieval failed with " + ex);
            }
        }
    }
}