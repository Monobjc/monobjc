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
using NUnit.Framework;

namespace Monobjc.Utils
{
    [TestFixture]
    [Category("Binder")]
    [Category("General")]
    [Description("Test the Generic/Non-Generic Binder for methods")]
    public class CustomMethodBinderTests
    {
        private const String METHOD = "DoSomething";
        private const String METHOD_NOT_FOUND = "Method must be found";
        private const String METHOD_NOT_GENERIC = "Method must be generic";
        private const String METHOD_AMBIGUOUS = "Candidates must be ambiguous";
        private const String METHOD_WRONG_TYPE = "Parameter type is wrong";

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
			
            methodInfo = typeof (Class07).GetMethod(METHOD, BindingFlags.Public | BindingFlags.Instance, binder, new[] {typeof (IntPtr), typeof (Object[])}, null);
            Assert.NotNull(methodInfo, METHOD_NOT_FOUND);
            Assert.AreEqual(false, methodInfo.IsGenericMethod, METHOD_NOT_GENERIC);
			Assert.AreEqual(typeof(IntPtr), methodInfo.GetParameters()[0].ParameterType, METHOD_WRONG_TYPE);
			
            methodInfo = typeof (Class07).GetMethod(METHOD, BindingFlags.Public | BindingFlags.Instance, binder, new[] {typeof (Id), typeof (Object[])}, null);
            Assert.NotNull(methodInfo, METHOD_NOT_FOUND);
            Assert.AreEqual(false, methodInfo.IsGenericMethod, METHOD_NOT_GENERIC);
			Assert.AreEqual(typeof(Id), methodInfo.GetParameters()[0].ParameterType, METHOD_WRONG_TYPE);
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
			
            methodInfo = typeof (Class07).GetMethod(METHOD, BindingFlags.Public | BindingFlags.Instance, binder, new[] {typeof (IntPtr), typeof (Object[])}, null);
            Assert.NotNull(methodInfo, METHOD_NOT_FOUND);
            Assert.AreEqual(true, methodInfo.IsGenericMethod, METHOD_NOT_GENERIC);
			Assert.AreEqual(typeof(IntPtr), methodInfo.GetParameters()[0].ParameterType, METHOD_WRONG_TYPE);
			
            methodInfo = typeof (Class07).GetMethod(METHOD, BindingFlags.Public | BindingFlags.Instance, binder, new[] {typeof (Id), typeof (Object[])}, null);
            Assert.NotNull(methodInfo, METHOD_NOT_FOUND);
            Assert.AreEqual(true, methodInfo.IsGenericMethod, METHOD_NOT_GENERIC);
			Assert.AreEqual(typeof(Id), methodInfo.GetParameters()[0].ParameterType, METHOD_WRONG_TYPE);
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
		
        public class Class07
        {
            public void DoSomething(IntPtr ptr, params Object[] parameters) {}

            public void DoSomething(Id id, params Object[] parameters) {}

            public T DoSomething<T>(IntPtr ptr, params Object[] parameters)
            {
                return default(T);
            }

            public T DoSomething<T>(Id id, params Object[] parameters)
            {
                return default(T);
            }
        }
    }
}