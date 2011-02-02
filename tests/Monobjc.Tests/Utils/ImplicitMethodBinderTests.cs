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
    [Description("Test the implicit operator Binder for methods")]
    public class ImplicitMethodBinderTests
    {
        private const String METHOD = "op_Implicit";
        private const String METHOD_MUST_EXIST = "Method must be found";
        private const String METHOD_MUST_NOT_EXIST = "Method must not be found";

        [Test]
        public void TestBinder()
        {
            Binder binder = new ImplicitMethodBinder(typeof(Class01), typeof(Class02));
            MethodInfo methodInfo = typeof(Class01).GetMethod(METHOD, BindingFlags.Public | BindingFlags.Static, binder, new[] { typeof(Class01) }, null);
            Assert.Null(methodInfo, METHOD_MUST_NOT_EXIST);

            methodInfo = typeof(Class01).GetMethod(METHOD, BindingFlags.Public | BindingFlags.Static, binder, new[] { typeof(Class02) }, null);
            Assert.Null(methodInfo, METHOD_MUST_NOT_EXIST);

            methodInfo = typeof(Class02).GetMethod(METHOD, BindingFlags.Public | BindingFlags.Static, binder, new[] { typeof(Class01) }, null);
            Assert.NotNull(methodInfo, METHOD_MUST_EXIST);

            methodInfo = typeof(Class02).GetMethod(METHOD, BindingFlags.Public | BindingFlags.Static, binder, new[] { typeof(Class02) }, null);
            Assert.NotNull(methodInfo, METHOD_MUST_EXIST);
        }

        public class Class01
        {
        }

        public class Class02
        {
            public static implicit operator Class02(Class01 value)
            {
                return null;
            }

            public static implicit operator Class01(Class02 value)
            {
                return null;
            }
        }

        public class Class03
        {
            public static implicit operator Class01(Class03 value)
            {
                return null;
            }
        }

        public class Class04
        {
            public static implicit operator Class04(Class01 value)
            {
                return null;
            }
        }
    }
}