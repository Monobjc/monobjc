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
using Monobjc.Runtime;
using NUnit.Framework;

namespace Monobjc.Generators
{
    [TestFixture]
    [Category("Categories")]
    [Category("Generators")]
    [Description("Test category proxies creation")]
    public class CategoryGeneratorTests
    {
        private static int counter;

        [Test]
        public void TestCategoryGeneration()
        {
            counter = 10;

            this.TestClass(typeof (DummyCategoryVariousParameters), typeof (DummyCategoryVariousParameters_Proxy), false);
            this.TestClass(typeof (DummyCategoryVariousReturns), typeof (DummyCategoryVariousReturns_Proxy), false);
        }

        [Test]
        public void TestCategoryGenerationVariableTypes32bits()
        {
            counter = 20;

            this.TestClass(typeof (DummyCategoryVariousParametersVariableTypes), typeof (DummyCategoryVariousParametersVariableTypes32Bits_Proxy), false);
            this.TestClass(typeof (DummyCategoryVariousReturnsVariableTypes), typeof (DummyCategoryVariousReturnsVariableTypes32Bits_Proxy), false);
        }

        [Test]
        public void TestCategoryGenerationVariableTypes64bits()
        {
            counter = 30;

            this.TestClass(typeof (DummyCategoryVariousParametersVariableTypes), typeof (DummyCategoryVariousParametersVariableTypes64Bits_Proxy), true);
            this.TestClass(typeof (DummyCategoryVariousReturnsVariableTypes), typeof (DummyCategoryVariousReturnsVariableTypes64Bits_Proxy), true);
        }

        private void TestClass(Type classType, Type referenceType, bool is64Bits)
        {
            counter++;

            DynamicAssembly assembly = new DynamicAssembly(DynamicAssemblyHelper.GetAssemblyName(this, counter), "MyModule");

            MethodTuple[] extensionMethods = Bridge.CollectStaticMethods(classType);
            Assert.IsTrue(Array.TrueForAll(extensionMethods, m => m.MethodInfo.IsStatic));

            CategoryGenerator generator = new CategoryGenerator(assembly, is64Bits);
            Type proxyType = generator.DefineCategoryProxy(classType, extensionMethods);

            try
            {
                assembly.Save();
                Type type = assembly.GetType(proxyType.FullName);
                DynamicAssemblyHelper.Compare(referenceType, type);
            }
            catch (Exception ex)
            {
                Assert.Fail("Type retrieval failed with " + ex);
            }
        }
    }
}