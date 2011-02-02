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
using System.Reflection;
using NUnit.Framework;

namespace Monobjc.Utils
{
    [TestFixture]
    [Category("General")]
    [Description("Test the Generic/Non-Generic Binder for methods")]
    public class CustomMethodBinderTests
    {
        private const String METHOD = "DoSomething";
        private const String METHOD_NOT_FOUND = "Method must be found";
        private const String METHOD_NOT_GENERIC = "Method must be generic";
        private const String METHOD_AMBIGUOUS = "Candidates must be ambiguous";

        [Test]
        public void TestBinder()
        {
            MethodInfo methodInfo;

            methodInfo = typeof (Class01).GetMethod(METHOD, BindingFlags.Public | BindingFlags.Instance, null, new[] {typeof (object)}, null);
            Assert.NotNull(methodInfo, METHOD_NOT_FOUND);
            Assert.AreEqual(false, methodInfo.IsGenericMethod, METHOD_NOT_GENERIC);

            methodInfo = typeof (Class02).GetMethod(METHOD, BindingFlags.Public | BindingFlags.Instance, null, new[] {typeof (object)}, null);
            Assert.NotNull(methodInfo, METHOD_NOT_FOUND);
            Assert.AreEqual(true, methodInfo.IsGenericMethod, METHOD_NOT_GENERIC);

            // This assertion passes on .NET 3.5
            // This assertion fails on Mono 2.6.1
            //
            //Assert.Throws<AmbiguousMatchException>(() => { 
            //    methodInfo = typeof (Class03).GetMethod(METHOD, BindingFlags.Public | BindingFlags.Instance, null, new[] {typeof (object)}, null); 
            //    Console.WriteLine("Found " + methodInfo);
            //}, METHOD_AMBIGUOUS);

            methodInfo = typeof (Class04).GetMethod(METHOD, BindingFlags.Public | BindingFlags.Instance, null, new[] {typeof (object)}, null);
            Assert.NotNull(methodInfo, METHOD_NOT_FOUND);
            Assert.AreEqual(false, methodInfo.IsGenericMethod, METHOD_NOT_GENERIC);

            methodInfo = typeof (Class04).GetMethod(METHOD, BindingFlags.Public | BindingFlags.Instance, null, new[] {typeof (object), typeof (Object[])}, null);
            Assert.NotNull(methodInfo, METHOD_NOT_FOUND);
            Assert.AreEqual(false, methodInfo.IsGenericMethod, METHOD_NOT_GENERIC);

            methodInfo = typeof (Class05).GetMethod(METHOD, BindingFlags.Public | BindingFlags.Instance, null, new[] {typeof (object)}, null);
            Assert.NotNull(methodInfo, METHOD_NOT_FOUND);
            Assert.AreEqual(true, methodInfo.IsGenericMethod, METHOD_NOT_GENERIC);

            methodInfo = typeof (Class05).GetMethod(METHOD, BindingFlags.Public | BindingFlags.Instance, null, new[] {typeof (object), typeof (Object[])}, null);
            Assert.NotNull(methodInfo, METHOD_NOT_FOUND);
            Assert.AreEqual(true, methodInfo.IsGenericMethod, METHOD_NOT_GENERIC);

            // This assertion passes on .NET 3.5
            // This assertion fails on Mono 2.6.1
            //
            //Assert.Throws<AmbiguousMatchException>(() =>
            //{ 
            //    methodInfo = typeof (Class06).GetMethod(METHOD, BindingFlags.Public | BindingFlags.Instance, null, new[] {typeof (object)}, null); 
            //    Console.WriteLine("Found " + methodInfo);
            //}, METHOD_AMBIGUOUS);

            // This assertion passes on .NET 3.5
            // This assertion fails on Mono 2.6.1
            //
            //Assert.Throws<AmbiguousMatchException>(() =>
            //{ 
            //    methodInfo = typeof (Class06).GetMethod(METHOD, BindingFlags.Public | BindingFlags.Instance, null, new[] {typeof (object), typeof (Object[])}, null); 
            //    Console.WriteLine("Found " + methodInfo);
            //}, METHOD_AMBIGUOUS);
        }

        [Test]
        public void TestCustomBinderNonGeneric()
        {
            MethodInfo methodInfo;
            GenericMethodBinder binder = new GenericMethodBinder(false);

            methodInfo = typeof (Class01).GetMethod(METHOD, BindingFlags.Public | BindingFlags.Instance, binder, new[] {typeof (object)}, null);
            Assert.NotNull(methodInfo, METHOD_NOT_FOUND);
            Assert.AreEqual(false, methodInfo.IsGenericMethod, METHOD_NOT_GENERIC);

            methodInfo = typeof (Class02).GetMethod(METHOD, BindingFlags.Public | BindingFlags.Instance, binder, new[] {typeof (object)}, null);
            Assert.IsNull(methodInfo, METHOD_NOT_FOUND);

            methodInfo = typeof (Class03).GetMethod(METHOD, BindingFlags.Public | BindingFlags.Instance, binder, new[] {typeof (object)}, null);
            Assert.NotNull(methodInfo, METHOD_NOT_FOUND);
            Assert.AreEqual(false, methodInfo.IsGenericMethod, METHOD_NOT_GENERIC);

            methodInfo = typeof (Class04).GetMethod(METHOD, BindingFlags.Public | BindingFlags.Instance, binder, new[] {typeof (object)}, null);
            Assert.NotNull(methodInfo, METHOD_NOT_FOUND);
            Assert.AreEqual(false, methodInfo.IsGenericMethod, METHOD_NOT_GENERIC);

            methodInfo = typeof (Class04).GetMethod(METHOD, BindingFlags.Public | BindingFlags.Instance, binder, new[] {typeof (object), typeof (Object[])}, null);
            Assert.NotNull(methodInfo, METHOD_NOT_FOUND);
            Assert.AreEqual(false, methodInfo.IsGenericMethod, METHOD_NOT_GENERIC);

            methodInfo = typeof (Class05).GetMethod(METHOD, BindingFlags.Public | BindingFlags.Instance, binder, new[] {typeof (object)}, null);
            Assert.IsNull(methodInfo, METHOD_NOT_FOUND);

            methodInfo = typeof (Class05).GetMethod(METHOD, BindingFlags.Public | BindingFlags.Instance, binder, new[] {typeof (object), typeof (Object[])}, null);
            Assert.IsNull(methodInfo, METHOD_NOT_FOUND);

            methodInfo = typeof (Class06).GetMethod(METHOD, BindingFlags.Public | BindingFlags.Instance, binder, new[] {typeof (object)}, null);
            Assert.NotNull(methodInfo, METHOD_NOT_FOUND);
            Assert.AreEqual(false, methodInfo.IsGenericMethod, METHOD_NOT_GENERIC);

            methodInfo = typeof (Class06).GetMethod(METHOD, BindingFlags.Public | BindingFlags.Instance, binder, new[] {typeof (object), typeof (Object[])}, null);
            Assert.NotNull(methodInfo, METHOD_NOT_FOUND);
            Assert.AreEqual(false, methodInfo.IsGenericMethod, METHOD_NOT_GENERIC);
        }

        [Test]
        public void TestCustomBinderGeneric()
        {
            MethodInfo methodInfo;
            GenericMethodBinder binder = new GenericMethodBinder(true);

            methodInfo = typeof (Class01).GetMethod(METHOD, BindingFlags.Public | BindingFlags.Instance, binder, new[] {typeof (object)}, null);
            Assert.IsNull(methodInfo, METHOD_NOT_FOUND);

            methodInfo = typeof (Class02).GetMethod(METHOD, BindingFlags.Public | BindingFlags.Instance, binder, new[] {typeof (object)}, null);
            Assert.NotNull(methodInfo, METHOD_NOT_FOUND);
            Assert.AreEqual(true, methodInfo.IsGenericMethod, METHOD_NOT_GENERIC);

            methodInfo = typeof (Class03).GetMethod(METHOD, BindingFlags.Public | BindingFlags.Instance, binder, new[] {typeof (object)}, null);
            Assert.NotNull(methodInfo, METHOD_NOT_FOUND);
            Assert.AreEqual(true, methodInfo.IsGenericMethod, METHOD_NOT_GENERIC);

            methodInfo = typeof (Class04).GetMethod(METHOD, BindingFlags.Public | BindingFlags.Instance, binder, new[] {typeof (object)}, null);
            Assert.IsNull(methodInfo, METHOD_NOT_FOUND);

            methodInfo = typeof (Class04).GetMethod(METHOD, BindingFlags.Public | BindingFlags.Instance, binder, new[] {typeof (object), typeof (Object[])}, null);
            Assert.IsNull(methodInfo, METHOD_NOT_FOUND);

            methodInfo = typeof (Class05).GetMethod(METHOD, BindingFlags.Public | BindingFlags.Instance, binder, new[] {typeof (object)}, null);
            Assert.NotNull(methodInfo, METHOD_NOT_FOUND);
            Assert.AreEqual(true, methodInfo.IsGenericMethod, METHOD_NOT_GENERIC);

            methodInfo = typeof (Class05).GetMethod(METHOD, BindingFlags.Public | BindingFlags.Instance, binder, new[] {typeof (object), typeof (Object[])}, null);
            Assert.NotNull(methodInfo, METHOD_NOT_FOUND);
            Assert.AreEqual(true, methodInfo.IsGenericMethod, METHOD_NOT_GENERIC);

            methodInfo = typeof (Class06).GetMethod(METHOD, BindingFlags.Public | BindingFlags.Instance, binder, new[] {typeof (object)}, null);
            Assert.NotNull(methodInfo, METHOD_NOT_FOUND);
            Assert.AreEqual(true, methodInfo.IsGenericMethod, METHOD_NOT_GENERIC);

            methodInfo = typeof (Class06).GetMethod(METHOD, BindingFlags.Public | BindingFlags.Instance, binder, new[] {typeof (object), typeof (Object[])}, null);
            Assert.NotNull(methodInfo, METHOD_NOT_FOUND);
            Assert.AreEqual(true, methodInfo.IsGenericMethod, METHOD_NOT_GENERIC);
        }

        public class Class01
        {
            public void DoSomething(Object obj) {}
        }

        public class Class02
        {
            public T DoSomething<T>(Object obj)
            {
                return default(T);
            }
        }

        public class Class03
        {
            public void DoSomething(Object obj) {}

            public T DoSomething<T>(Object obj)
            {
                return default(T);
            }
        }

        public class Class04
        {
            public void DoSomething(Object obj) {}

            public void DoSomething(Object obj, params Object[] parameters) {}
        }

        public class Class05
        {
            public T DoSomething<T>(Object obj)
            {
                return default(T);
            }

            public T DoSomething<T>(Object obj, params Object[] parameters)
            {
                return default(T);
            }
        }

        public class Class06
        {
            public void DoSomething(Object obj) {}

            public void DoSomething(Object obj, params Object[] parameters) {}

            public T DoSomething<T>(Object obj)
            {
                return default(T);
            }

            public T DoSomething<T>(Object obj, params Object[] parameters)
            {
                return default(T);
            }
        }
    }
}