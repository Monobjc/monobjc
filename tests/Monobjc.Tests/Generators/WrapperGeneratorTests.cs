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
using Monobjc.Dynamic.Wrappers;
using NUnit.Framework;

namespace Monobjc.Generators
{
    [TestFixture]
    [Category("Wrappers")]
    [Category("Generators")]
    [Description("Test protocol proxies creation")]
    public class WrapperGeneratorTests
    {
        [Test]
        public void TestWrapperGenerationErrors()
        {
            Assert.Throws<ArgumentException>(() => this.TestWrapper(11, typeof (Object), typeof (Object)), "Type must be an interafce");
            Assert.Throws<ArgumentException>(() => this.TestWrapper(12, typeof (IManagedWrapper12), typeof (Object)), "Type must be a IManagedWrapper sub-interafce");
            Assert.Throws<ObjectiveCCodeGenerationException>(() => this.TestWrapper(13, typeof (IManagedWrapper13), typeof (Object)), "ObjectiveCProtocol must be present");
            Assert.Throws<ObjectiveCCodeGenerationException>(() => this.TestWrapper(14, typeof (IManagedWrapper14), typeof (Object)), "ObjectiveCMessage is missing");
            Assert.Throws<ObjectiveCCodeGenerationException>(() => this.TestWrapper(15, typeof (IManagedWrapper15), typeof (Object)), "ObjectiveCMessage is invalid");
        }

        [Test]
        public void TestWrapperGeneration()
        {
            this.TestWrapper(21, typeof(IManagedWrapper21), typeof(ManagedWrapper21Impl));
            this.TestWrapper(22, typeof(IManagedWrapper22), typeof(ManagedWrapper22Impl));
            this.TestWrapper(23, typeof(IManagedWrapper23), typeof(ManagedWrapper23Impl));
            this.TestWrapper(24, typeof(IManagedWrapper24), typeof(ManagedWrapper24Impl));
        }

        private void TestWrapper(int number, Type protocolType, Type referenceType)
        {
            DynamicAssembly assembly = new DynamicAssembly(DynamicAssemblyHelper.GetAssemblyName(this, number), "MyModule");

            WrapperGenerator wrapperGenerator = new WrapperGenerator(assembly, false);
            Type proxyType = wrapperGenerator.DefineWrapperProxy(protocolType);

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