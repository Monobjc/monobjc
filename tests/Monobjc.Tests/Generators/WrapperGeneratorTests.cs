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