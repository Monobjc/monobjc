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

            this.TestClass(typeof(DummyCategoryVariousParameters), typeof(DummyCategoryVariousParameters_Proxy), false);
            this.TestClass(typeof(DummyCategoryVariousReturns), typeof(DummyCategoryVariousReturns_Proxy), false);
        }

        [Test]
        public void TestCategoryGenerationVariableTypes32bits()
        {
            counter = 20;

            this.TestClass(typeof(DummyCategoryVariousParametersVariableTypes), typeof(DummyCategoryVariousParametersVariableTypes32Bits_Proxy), false);
            this.TestClass(typeof(DummyCategoryVariousReturnsVariableTypes), typeof(DummyCategoryVariousReturnsVariableTypes32Bits_Proxy), false);
        }

        [Test]
        public void TestCategoryGenerationVariableTypes64bits()
        {
            counter = 30;

            this.TestClass(typeof(DummyCategoryVariousParametersVariableTypes), typeof(DummyCategoryVariousParametersVariableTypes64Bits_Proxy), true);
            this.TestClass(typeof(DummyCategoryVariousReturnsVariableTypes), typeof(DummyCategoryVariousReturnsVariableTypes64Bits_Proxy), true);
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