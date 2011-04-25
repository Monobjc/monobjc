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
using System.Reflection;
using Monobjc.Types;
using NUnit.Framework;

namespace Monobjc.Generators
{
#if MACOSX_10_6 && HAVE_BLOCK_SUPPORT
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
                Type type = assembly.GetType(proxyType.FullName);
                DynamicAssemblyHelper.Compare(referenceType, type);
            }
            catch (Exception ex)
            {
                Assert.Fail("Type retrieval failed with " + ex);
            }
        }
    }
#endif
}