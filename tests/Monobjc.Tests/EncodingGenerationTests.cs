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
            if (ObjectiveCRuntime.Is64Bits)
            {
                Assert.AreEqual("v16@0:8", ObjectiveCEncoding.GetSignature(methodInfo), "Selector encoding don't match");
            }
            else
            {
                Assert.AreEqual("v8@0:4", ObjectiveCEncoding.GetSignature(methodInfo), "Selector encoding don't match");
            }

            methodInfo = typeof (TestClassForMethodWithoutReturnType).GetMethod("DoNoReturn", new[] {typeof (bool)});
            Assert.IsNotNull(methodInfo, "Method cannot be null");
            if (ObjectiveCRuntime.Is64Bits)
            {
                Assert.AreEqual("v20@0:8c16", ObjectiveCEncoding.GetSignature(methodInfo), "Selector encoding don't match");
            }
            else
            {
                Assert.AreEqual("v12@0:4c8", ObjectiveCEncoding.GetSignature(methodInfo), "Selector encoding don't match");
            }

            methodInfo = typeof (TestClassForMethodWithoutReturnType).GetMethod("DoNoReturn", new[] {typeof (char)});
            Assert.IsNotNull(methodInfo, "Method cannot be null");
            if (ObjectiveCRuntime.Is64Bits)
            {
                Assert.AreEqual("v20@0:8S16", ObjectiveCEncoding.GetSignature(methodInfo), "Selector encoding don't match");
            }
            else
            {
                Assert.AreEqual("v12@0:4S8", ObjectiveCEncoding.GetSignature(methodInfo), "Selector encoding don't match");
            }

            methodInfo = typeof (TestClassForMethodWithoutReturnType).GetMethod("DoNoReturn", new[] {typeof (short)});
            Assert.IsNotNull(methodInfo, "Method cannot be null");
            if (ObjectiveCRuntime.Is64Bits)
            {
                Assert.AreEqual("v20@0:8s16", ObjectiveCEncoding.GetSignature(methodInfo), "Selector encoding don't match");
            }
            else
            {
                Assert.AreEqual("v12@0:4s8", ObjectiveCEncoding.GetSignature(methodInfo), "Selector encoding don't match");
            }

            methodInfo = typeof (TestClassForMethodWithoutReturnType).GetMethod("DoNoReturn", new[] {typeof (int)});
            Assert.IsNotNull(methodInfo, "Method cannot be null");
            if (ObjectiveCRuntime.Is64Bits)
            {
                Assert.AreEqual("v20@0:8i16", ObjectiveCEncoding.GetSignature(methodInfo), "Selector encoding don't match");
            }
            else
            {
                Assert.AreEqual("v12@0:4i8", ObjectiveCEncoding.GetSignature(methodInfo), "Selector encoding don't match");
            }

            methodInfo = typeof (TestClassForMethodWithoutReturnType).GetMethod("DoNoReturn", new[] {typeof (long)});
            Assert.IsNotNull(methodInfo, "Method cannot be null");
            if (ObjectiveCRuntime.Is64Bits)
            {
                Assert.AreEqual("v24@0:8q16", ObjectiveCEncoding.GetSignature(methodInfo), "Selector encoding don't match");
            }
            else
            {
                Assert.AreEqual("v16@0:4q8", ObjectiveCEncoding.GetSignature(methodInfo), "Selector encoding don't match");
            }

            methodInfo = typeof (TestClassForMethodWithoutReturnType).GetMethod("DoNoReturn", new[] {typeof (float)});
            Assert.IsNotNull(methodInfo, "Method cannot be null");
            if (ObjectiveCRuntime.Is64Bits)
            {
                Assert.AreEqual("v20@0:8f16", ObjectiveCEncoding.GetSignature(methodInfo), "Selector encoding don't match");
            }
            else
            {
                Assert.AreEqual("v12@0:4f8", ObjectiveCEncoding.GetSignature(methodInfo), "Selector encoding don't match");
            }

            methodInfo = typeof (TestClassForMethodWithoutReturnType).GetMethod("DoNoReturn", new[] {typeof (double)});
            Assert.IsNotNull(methodInfo, "Method cannot be null");
            if (ObjectiveCRuntime.Is64Bits)
            {
                Assert.AreEqual("v24@0:8d16", ObjectiveCEncoding.GetSignature(methodInfo), "Selector encoding don't match");
            }
            else
            {
                Assert.AreEqual("v16@0:4d8", ObjectiveCEncoding.GetSignature(methodInfo), "Selector encoding don't match");
            }
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
            if (ObjectiveCRuntime.Is64Bits)
            {
                Assert.AreEqual("i16@0:8", ObjectiveCEncoding.GetSignature(methodInfo), "Selector encoding don't match");
            }
            else
            {
                Assert.AreEqual("i8@0:4", ObjectiveCEncoding.GetSignature(methodInfo), "Selector encoding don't match");
            }

            methodInfo = typeof (TestClassForMethodWithReturnType).GetMethod("DoWithReturn", new[] {typeof (bool)});
            Assert.IsNotNull(methodInfo, "Method cannot be null");
            if (ObjectiveCRuntime.Is64Bits)
            {
                Assert.AreEqual("d24@0:8c16", ObjectiveCEncoding.GetSignature(methodInfo), "Selector encoding don't match");
            }
            else
            {
                Assert.AreEqual("d12@0:4c8", ObjectiveCEncoding.GetSignature(methodInfo), "Selector encoding don't match");
            }

            methodInfo = typeof (TestClassForMethodWithReturnType).GetMethod("DoWithReturn", new[] {typeof (char)});
            Assert.IsNotNull(methodInfo, "Method cannot be null");
            if (ObjectiveCRuntime.Is64Bits)
            {
                Assert.AreEqual("f20@0:8S16", ObjectiveCEncoding.GetSignature(methodInfo), "Selector encoding don't match");
            }
            else
            {
                Assert.AreEqual("f12@0:4S8", ObjectiveCEncoding.GetSignature(methodInfo), "Selector encoding don't match");
            }

            methodInfo = typeof (TestClassForMethodWithReturnType).GetMethod("DoWithReturn", new[] {typeof (short)});
            Assert.IsNotNull(methodInfo, "Method cannot be null");
            if (ObjectiveCRuntime.Is64Bits)
            {
                Assert.AreEqual("q24@0:8s16", ObjectiveCEncoding.GetSignature(methodInfo), "Selector encoding don't match");
            }
            else
            {
                Assert.AreEqual("q12@0:4s8", ObjectiveCEncoding.GetSignature(methodInfo), "Selector encoding don't match");
            }

            methodInfo = typeof (TestClassForMethodWithReturnType).GetMethod("DoWithReturn", new[] {typeof (int)});
            Assert.IsNotNull(methodInfo, "Method cannot be null");
            if (ObjectiveCRuntime.Is64Bits)
            {
                Assert.AreEqual("i20@0:8i16", ObjectiveCEncoding.GetSignature(methodInfo), "Selector encoding don't match");
            }
            else
            {
                Assert.AreEqual("i12@0:4i8", ObjectiveCEncoding.GetSignature(methodInfo), "Selector encoding don't match");
            }

            methodInfo = typeof (TestClassForMethodWithReturnType).GetMethod("DoWithReturn", new[] {typeof (long)});
            Assert.IsNotNull(methodInfo, "Method cannot be null");
            if (ObjectiveCRuntime.Is64Bits)
            {
                Assert.AreEqual("s24@0:8q16", ObjectiveCEncoding.GetSignature(methodInfo), "Selector encoding don't match");
            }
            else
            {
                Assert.AreEqual("s16@0:4q8", ObjectiveCEncoding.GetSignature(methodInfo), "Selector encoding don't match");
            }

            methodInfo = typeof (TestClassForMethodWithReturnType).GetMethod("DoWithReturn", new[] {typeof (float)});
            Assert.IsNotNull(methodInfo, "Method cannot be null");
            if (ObjectiveCRuntime.Is64Bits)
            {
                Assert.AreEqual("S20@0:8f16", ObjectiveCEncoding.GetSignature(methodInfo), "Selector encoding don't match");
            }
            else
            {
                Assert.AreEqual("S12@0:4f8", ObjectiveCEncoding.GetSignature(methodInfo), "Selector encoding don't match");
            }

            methodInfo = typeof (TestClassForMethodWithReturnType).GetMethod("DoWithReturn", new[] {typeof (double)});
            Assert.IsNotNull(methodInfo, "Method cannot be null");
            if (ObjectiveCRuntime.Is64Bits)
            {
                Assert.AreEqual("c24@0:8d16", ObjectiveCEncoding.GetSignature(methodInfo), "Selector encoding don't match");
            }
            else
            {
                Assert.AreEqual("c16@0:4d8", ObjectiveCEncoding.GetSignature(methodInfo), "Selector encoding don't match");
            }
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