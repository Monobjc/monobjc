//
// This file is part of Monobjc, a .NET/Objective-C bridge
// Copyright (C) 2007-2012 - Laurent Etiemble
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
    [Category("Classes")]
    [Category("Generators")]
    [Description("Test class proxies creation")]
    public class ClassGeneratorTests
    {
        private static int counter;

        [Test]
        public void TestEmptyClassGeneration()
        {
            counter = 10;

            this.TestClass(typeof (DummyClassEmpty), typeof (DummyClassEmpty_Proxy), false);
        }

        [Test]
        public void TestClassGenerationWithInstanceFields()
        {
            counter = 20;

            this.TestClass(typeof (DummyClassOneField), typeof (DummyClassOneField_Proxy), false);
            this.TestClass(typeof (DummyClassMoreField), typeof (DummyClassMoreField_Proxy), false);
        }

        [Test]
        public void TestClassGenerationMethods()
        {
            counter = 30;

            this.TestClass(typeof (DummyClassStaticInstance), typeof (DummyClassStaticInstance_Proxy), false);
            this.TestClass(typeof (DummyClassVariousParameters), typeof (DummyClassVariousParameters_Proxy), false);
            this.TestClass(typeof (DummyClassVariousReturns), typeof (DummyClassVariousReturns_Proxy), false);
        }

        [Test]
        public void TestClassGenerationMethodsByRef()
        {
            counter = 40;

            this.TestClass(typeof (DummyClassParametersByRef), typeof (DummyClassParametersByRef_Proxy), false);
            this.TestClass(typeof (DummyClassParametersOut), typeof (DummyClassParametersOut_Proxy), false);
        }

        [Test]
        public void TestClassGenerationVariableTypes32Bits()
        {
            counter = 50;

            this.TestClass(typeof (DummyClassVariousParametersVariableTypes), typeof (DummyClassVariousParametersVariableTypes32Bits_Proxy), false);
            this.TestClass(typeof (DummyClassVariousReturnsVariableTypes), typeof (DummyClassVariousReturnsVariableTypes32Bits_Proxy), false);
            this.TestClass(typeof (DummyClassParametersByRefVariableTypes), typeof (DummyClassParametersByRefVariableTypes32Bits_Proxy), false);
            this.TestClass(typeof (DummyClassParametersOutVariableTypes), typeof (DummyClassParametersOutVariableTypes32Bits_Proxy), false);
        }

        [Test]
        public void TestClassGenerationVariableTypes64Bits()
        {
            counter = 60;

            this.TestClass(typeof (DummyClassVariousParametersVariableTypes), typeof (DummyClassVariousParametersVariableTypes64Bits_Proxy), true);
            this.TestClass(typeof (DummyClassVariousReturnsVariableTypes), typeof (DummyClassVariousReturnsVariableTypes64Bits_Proxy), true);
            this.TestClass(typeof (DummyClassParametersByRefVariableTypes), typeof (DummyClassParametersByRefVariableTypes64Bits_Proxy), true);
            this.TestClass(typeof (DummyClassParametersOutVariableTypes), typeof (DummyClassParametersOutVariableTypes64Bits_Proxy), true);
        }

        private void TestClass(Type classType, Type referenceType, bool is64Bits)
        {
            counter++;

            DynamicAssembly assembly = new DynamicAssembly(DynamicAssemblyHelper.GetAssemblyName(this, counter), "MyModule");

            MethodTuple[] instanceMethods = Bridge.CollectInstanceMethods(classType);
            Assert.IsTrue(Array.TrueForAll(instanceMethods, m => !m.MethodInfo.IsStatic));
            MethodTuple[] staticMethods = Bridge.CollectStaticMethods(classType);
            Assert.IsTrue(Array.TrueForAll(staticMethods, m => m.MethodInfo.IsStatic));

            ClassGenerator generator = new ClassGenerator(assembly, is64Bits);
            Type proxyType = generator.DefineClassProxy(classType, instanceMethods, staticMethods);

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