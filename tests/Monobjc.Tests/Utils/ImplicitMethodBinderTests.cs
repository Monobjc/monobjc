//
// This file is part of Monobjc, a .NET/Objective-C bridge
// Copyright (C) 2007-2014 - Laurent Etiemble
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
            Binder binder = new ImplicitMethodBinder(typeof (Class01), typeof (Class02));
            MethodInfo methodInfo = typeof (Class01).GetMethod(METHOD, BindingFlags.Public | BindingFlags.Static, binder, new[] {typeof (Class01)}, null);
            Assert.Null(methodInfo, METHOD_MUST_NOT_EXIST);

            methodInfo = typeof (Class01).GetMethod(METHOD, BindingFlags.Public | BindingFlags.Static, binder, new[] {typeof (Class02)}, null);
            Assert.Null(methodInfo, METHOD_MUST_NOT_EXIST);

            methodInfo = typeof (Class02).GetMethod(METHOD, BindingFlags.Public | BindingFlags.Static, binder, new[] {typeof (Class01)}, null);
            Assert.NotNull(methodInfo, METHOD_MUST_EXIST);

            methodInfo = typeof (Class02).GetMethod(METHOD, BindingFlags.Public | BindingFlags.Static, binder, new[] {typeof (Class02)}, null);
            Assert.NotNull(methodInfo, METHOD_MUST_EXIST);
        }

        public class Class01 {}

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