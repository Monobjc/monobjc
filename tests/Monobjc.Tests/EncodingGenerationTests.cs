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

namespace Monobjc
{
    [TestFixture]
    [Category("Encoding")]
    [Description("Test encoding of type and parameters between .NET and Objective-C")]
    public class EncodingGenerationTests : RuntimeTests
    {
        /// <summary>
        ///   Tests the selector for various method without return values.
        /// </summary>
        [Test]
        public void TestSelectorSignatureForMethods()
        {
            MethodInfo methodInfo;

            methodInfo = typeof (TestClassForMethodWithoutReturnType).GetMethod("DoNoReturn", Type.EmptyTypes);
            Assert.IsNotNull(methodInfo, "Method cannot be null");
            Assert.AreEqual("DoNoReturn", ObjectiveCEncoding.GetSelector(methodInfo), "Selector string don't match");

            methodInfo = typeof (TestClassForMethodWithoutReturnType).GetMethod("DoNoReturn", new[] {typeof (bool)});
            Assert.IsNotNull(methodInfo, "Method cannot be null");
            Assert.AreEqual("DoNoReturnWithValue:", ObjectiveCEncoding.GetSelector(methodInfo), "Selector string don't match");

            methodInfo = typeof (TestClassForMethodWithoutReturnType).GetMethod("DoNoReturn", new[] {typeof (char)});
            Assert.IsNotNull(methodInfo, "Method cannot be null");
            Assert.AreEqual("DoNoReturnWithValue:", ObjectiveCEncoding.GetSelector(methodInfo), "Selector string don't match");

            methodInfo = typeof (TestClassForMethodWithoutReturnType).GetMethod("DoNoReturn", new[] {typeof (short)});
            Assert.IsNotNull(methodInfo, "Method cannot be null");
            Assert.AreEqual("DoNoReturnWithValue:", ObjectiveCEncoding.GetSelector(methodInfo), "Selector string don't match");

            methodInfo = typeof (TestClassForMethodWithoutReturnType).GetMethod("DoNoReturn", new[] {typeof (int)});
            Assert.IsNotNull(methodInfo, "Method cannot be null");
            Assert.AreEqual("DoNoReturnWithValue:", ObjectiveCEncoding.GetSelector(methodInfo), "Selector string don't match");

            methodInfo = typeof (TestClassForMethodWithoutReturnType).GetMethod("DoNoReturn", new[] {typeof (long)});
            Assert.IsNotNull(methodInfo, "Method cannot be null");
            Assert.AreEqual("DoNoReturnWithValue:", ObjectiveCEncoding.GetSelector(methodInfo), "Selector string don't match");

            methodInfo = typeof (TestClassForMethodWithoutReturnType).GetMethod("DoNoReturn", new[] {typeof (float)});
            Assert.IsNotNull(methodInfo, "Method cannot be null");
            Assert.AreEqual("DoNoReturnWithValue:", ObjectiveCEncoding.GetSelector(methodInfo), "Selector string don't match");

            methodInfo = typeof (TestClassForMethodWithoutReturnType).GetMethod("DoNoReturn", new[] {typeof (double)});
            Assert.IsNotNull(methodInfo, "Method cannot be null");
            Assert.AreEqual("DoNoReturnWithValue:", ObjectiveCEncoding.GetSelector(methodInfo), "Selector string don't match");
        }

        /// <summary>
        ///   Tests the selector for various method with return values.
        /// </summary>
        [Test]
        public void TestSelectorSignatureForMethodsWithReturn()
        {
            MethodInfo methodInfo;

            methodInfo = typeof (TestClassForMethodWithReturnType).GetMethod("DoWithReturn", Type.EmptyTypes);
            Assert.IsNotNull(methodInfo, "Method cannot be null");
            Assert.AreEqual("DoWithReturn", ObjectiveCEncoding.GetSelector(methodInfo), "Selector string don't match");

            methodInfo = typeof (TestClassForMethodWithReturnType).GetMethod("DoWithReturn", new[] {typeof (bool)});
            Assert.IsNotNull(methodInfo, "Method cannot be null");
            Assert.AreEqual("DoWithReturnWithValue:", ObjectiveCEncoding.GetSelector(methodInfo), "Selector string don't match");

            methodInfo = typeof (TestClassForMethodWithReturnType).GetMethod("DoWithReturn", new[] {typeof (char)});
            Assert.IsNotNull(methodInfo, "Method cannot be null");
            Assert.AreEqual("DoWithReturnWithValue:", ObjectiveCEncoding.GetSelector(methodInfo), "Selector string don't match");

            methodInfo = typeof (TestClassForMethodWithReturnType).GetMethod("DoWithReturn", new[] {typeof (short)});
            Assert.IsNotNull(methodInfo, "Method cannot be null");
            Assert.AreEqual("DoWithReturnWithValue:", ObjectiveCEncoding.GetSelector(methodInfo), "Selector string don't match");

            methodInfo = typeof (TestClassForMethodWithReturnType).GetMethod("DoWithReturn", new[] {typeof (int)});
            Assert.IsNotNull(methodInfo, "Method cannot be null");
            Assert.AreEqual("DoWithReturnWithValue:", ObjectiveCEncoding.GetSelector(methodInfo), "Selector string don't match");

            methodInfo = typeof (TestClassForMethodWithReturnType).GetMethod("DoWithReturn", new[] {typeof (long)});
            Assert.IsNotNull(methodInfo, "Method cannot be null");
            Assert.AreEqual("DoWithReturnWithValue:", ObjectiveCEncoding.GetSelector(methodInfo), "Selector string don't match");

            methodInfo = typeof (TestClassForMethodWithReturnType).GetMethod("DoWithReturn", new[] {typeof (float)});
            Assert.IsNotNull(methodInfo, "Method cannot be null");
            Assert.AreEqual("DoWithReturnWithValue:", ObjectiveCEncoding.GetSelector(methodInfo), "Selector string don't match");

            methodInfo = typeof (TestClassForMethodWithReturnType).GetMethod("DoWithReturn", new[] {typeof (double)});
            Assert.IsNotNull(methodInfo, "Method cannot be null");
            Assert.AreEqual("DoWithReturnWithValue:", ObjectiveCEncoding.GetSelector(methodInfo), "Selector string don't match");
        }

        /// <summary>
        ///   Tests the selector encoding for methods.
        /// </summary>
        [Test]
        public void TestSelectorEncodingForMethods()
        {
            MethodInfo methodInfo;

            methodInfo = typeof (TestClassForMethodWithoutReturnType).GetMethod("DoNoReturn", Type.EmptyTypes);
            Assert.IsNotNull(methodInfo, "Method cannot be null");
            Assert.AreEqual("v8@0:4", ObjectiveCEncoding.GetSignature(methodInfo), "Selector encoding don't match");

            methodInfo = typeof (TestClassForMethodWithoutReturnType).GetMethod("DoNoReturn", new[] {typeof (bool)});
            Assert.IsNotNull(methodInfo, "Method cannot be null");
            Assert.AreEqual("v12@0:4c8", ObjectiveCEncoding.GetSignature(methodInfo), "Selector encoding don't match");

            methodInfo = typeof (TestClassForMethodWithoutReturnType).GetMethod("DoNoReturn", new[] {typeof (char)});
            Assert.IsNotNull(methodInfo, "Method cannot be null");
            Assert.AreEqual("v12@0:4S8", ObjectiveCEncoding.GetSignature(methodInfo), "Selector encoding don't match");

            methodInfo = typeof (TestClassForMethodWithoutReturnType).GetMethod("DoNoReturn", new[] {typeof (short)});
            Assert.IsNotNull(methodInfo, "Method cannot be null");
            Assert.AreEqual("v12@0:4s8", ObjectiveCEncoding.GetSignature(methodInfo), "Selector encoding don't match");

            methodInfo = typeof (TestClassForMethodWithoutReturnType).GetMethod("DoNoReturn", new[] {typeof (int)});
            Assert.IsNotNull(methodInfo, "Method cannot be null");
            Assert.AreEqual("v12@0:4i8", ObjectiveCEncoding.GetSignature(methodInfo), "Selector encoding don't match");

            methodInfo = typeof (TestClassForMethodWithoutReturnType).GetMethod("DoNoReturn", new[] {typeof (long)});
            Assert.IsNotNull(methodInfo, "Method cannot be null");
            Assert.AreEqual("v16@0:4q8", ObjectiveCEncoding.GetSignature(methodInfo), "Selector encoding don't match");

            methodInfo = typeof (TestClassForMethodWithoutReturnType).GetMethod("DoNoReturn", new[] {typeof (float)});
            Assert.IsNotNull(methodInfo, "Method cannot be null");
            Assert.AreEqual("v12@0:4f8", ObjectiveCEncoding.GetSignature(methodInfo), "Selector encoding don't match");

            methodInfo = typeof (TestClassForMethodWithoutReturnType).GetMethod("DoNoReturn", new[] {typeof (double)});
            Assert.IsNotNull(methodInfo, "Method cannot be null");
            Assert.AreEqual("v16@0:4d8", ObjectiveCEncoding.GetSignature(methodInfo), "Selector encoding don't match");
        }

        /// <summary>
        ///   Tests the selector encoding for methods with return.
        /// </summary>
        [Test]
        public void TestSelectorEncodingForMethodsWithReturn()
        {
            MethodInfo methodInfo;

            methodInfo = typeof (TestClassForMethodWithReturnType).GetMethod("DoWithReturn", Type.EmptyTypes);
            Assert.IsNotNull(methodInfo, "Method cannot be null");
            Assert.AreEqual("i8@0:4", ObjectiveCEncoding.GetSignature(methodInfo), "Selector encoding don't match");

            methodInfo = typeof (TestClassForMethodWithReturnType).GetMethod("DoWithReturn", new[] {typeof (bool)});
            Assert.IsNotNull(methodInfo, "Method cannot be null");
            Assert.AreEqual("d12@0:4c8", ObjectiveCEncoding.GetSignature(methodInfo), "Selector encoding don't match");

            methodInfo = typeof (TestClassForMethodWithReturnType).GetMethod("DoWithReturn", new[] {typeof (char)});
            Assert.IsNotNull(methodInfo, "Method cannot be null");
            Assert.AreEqual("f12@0:4S8", ObjectiveCEncoding.GetSignature(methodInfo), "Selector encoding don't match");

            methodInfo = typeof (TestClassForMethodWithReturnType).GetMethod("DoWithReturn", new[] {typeof (short)});
            Assert.IsNotNull(methodInfo, "Method cannot be null");
            Assert.AreEqual("q12@0:4s8", ObjectiveCEncoding.GetSignature(methodInfo), "Selector encoding don't match");

            methodInfo = typeof (TestClassForMethodWithReturnType).GetMethod("DoWithReturn", new[] {typeof (int)});
            Assert.IsNotNull(methodInfo, "Method cannot be null");
            Assert.AreEqual("i12@0:4i8", ObjectiveCEncoding.GetSignature(methodInfo), "Selector encoding don't match");

            methodInfo = typeof (TestClassForMethodWithReturnType).GetMethod("DoWithReturn", new[] {typeof (long)});
            Assert.IsNotNull(methodInfo, "Method cannot be null");
            Assert.AreEqual("s16@0:4q8", ObjectiveCEncoding.GetSignature(methodInfo), "Selector encoding don't match");

            methodInfo = typeof (TestClassForMethodWithReturnType).GetMethod("DoWithReturn", new[] {typeof (float)});
            Assert.IsNotNull(methodInfo, "Method cannot be null");
            Assert.AreEqual("S12@0:4f8", ObjectiveCEncoding.GetSignature(methodInfo), "Selector encoding don't match");

            methodInfo = typeof (TestClassForMethodWithReturnType).GetMethod("DoWithReturn", new[] {typeof (double)});
            Assert.IsNotNull(methodInfo, "Method cannot be null");
            Assert.AreEqual("c16@0:4d8", ObjectiveCEncoding.GetSignature(methodInfo), "Selector encoding don't match");
        }

        /// <summary>
        ///   Test class for selector string and encoding
        /// </summary>
        internal class TestClassForMethodWithoutReturnType : TSObject
        {
            public TestClassForMethodWithoutReturnType(IntPtr value) : base(value) {}

            public void DoNoReturn() {}

            public void DoNoReturn(bool value) {}

            public void DoNoReturn(char value) {}

            public void DoNoReturn(short value) {}

            public void DoNoReturn(int value) {}

            public void DoNoReturn(long value) {}

            public void DoNoReturn(float value) {}

            public void DoNoReturn(double value) {}
        }

        /// <summary>
        ///   Test class for selector string and encoding
        /// </summary>
        internal class TestClassForMethodWithReturnType : TSObject
        {
            public TestClassForMethodWithReturnType(IntPtr value) : base(value) {}

            public int DoWithReturn()
            {
                return 0;
            }

            public double DoWithReturn(bool value)
            {
                return 0.0d;
            }

            public float DoWithReturn(char value)
            {
                return 0.0f;
            }

            public long DoWithReturn(short value)
            {
                return 0L;
            }

            public int DoWithReturn(int value)
            {
                return 0;
            }

            public short DoWithReturn(long value)
            {
                return 0;
            }

            public char DoWithReturn(float value)
            {
                return ' ';
            }

            public bool DoWithReturn(double value)
            {
                return true;
            }
        }
    }
}