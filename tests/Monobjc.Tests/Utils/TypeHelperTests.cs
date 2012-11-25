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

namespace Monobjc.Utils
{
    [TestFixture]
    [Category("General")]
    [Description("Test the TypeHelper class")]
    public class TypeHelperTests
    {
        private const String METHOD_MUST_EXIST = "Method must be found {0} => {1}";
        private const String METHOD_MUST_NOT_EXIST = "Method must not be found {0} => {1}";
        private const String VALUE_MUST_BE_EQUAL = "Value must be equal {0} => {1}";

        [Test]
        public void TestTypeConverterForBasicTypes()
        {
            MethodInfo converter;

            converter = TypeHelper.GetConverter(typeof (int), typeof (int));
            Assert.Null(converter, String.Format(METHOD_MUST_NOT_EXIST, typeof (int), typeof (int)));

            converter = TypeHelper.GetConverter(typeof (uint), typeof (uint));
            Assert.Null(converter, String.Format(METHOD_MUST_NOT_EXIST, typeof (uint), typeof (uint)));

            converter = TypeHelper.GetConverter(typeof (long), typeof (long));
            Assert.Null(converter, String.Format(METHOD_MUST_NOT_EXIST, typeof (long), typeof (long)));

            converter = TypeHelper.GetConverter(typeof (ulong), typeof (ulong));
            Assert.Null(converter, String.Format(METHOD_MUST_NOT_EXIST, typeof (ulong), typeof (ulong)));

            converter = TypeHelper.GetConverter(typeof (float), typeof (float));
            Assert.Null(converter, String.Format(METHOD_MUST_NOT_EXIST, typeof (float), typeof (float)));

            converter = TypeHelper.GetConverter(typeof (double), typeof (double));
            Assert.Null(converter, String.Format(METHOD_MUST_NOT_EXIST, typeof (double), typeof (double)));
        }

        [Test]
        public void TestTypeConverterForMixedTypes()
        {
            MethodInfo converter;
            TSIntegerEnumeration tsIntegerEnumeration = TSIntegerEnumeration.NSEvenOddWindingRule;
            TSUIntegerEnumeration tsuIntegerEnumeration = TSUIntegerEnumeration.NSEvenOddWindingRule;
            int i;
            long l;

            converter = TypeHelper.GetConverter(typeof (TSIntegerEnumeration), typeof (int));
            Assert.Null(converter, String.Format(METHOD_MUST_NOT_EXIST, typeof (TSIntegerEnumeration), typeof (int)));

            converter = TypeHelper.GetConverter(typeof (int), typeof (TSIntegerEnumeration));
            Assert.Null(converter, String.Format(METHOD_MUST_NOT_EXIST, typeof (int), typeof (TSIntegerEnumeration)));

            converter = TypeHelper.GetConverter(typeof (TSIntegerEnumeration), typeof (long));
            Assert.NotNull(converter, String.Format(METHOD_MUST_EXIST, typeof (TSIntegerEnumeration), typeof (long)));

            converter = TypeHelper.GetConverter(typeof (long), typeof (TSIntegerEnumeration));
            Assert.NotNull(converter, String.Format(METHOD_MUST_EXIST, typeof (long), typeof (TSIntegerEnumeration)));

            converter = TypeHelper.GetConverter(typeof (TSUIntegerEnumeration), typeof (uint));
            Assert.Null(converter, String.Format(METHOD_MUST_NOT_EXIST, typeof (TSUIntegerEnumeration), typeof (uint)));

            converter = TypeHelper.GetConverter(typeof (uint), typeof (TSUIntegerEnumeration));
            Assert.Null(converter, String.Format(METHOD_MUST_NOT_EXIST, typeof (uint), typeof (TSUIntegerEnumeration)));

            converter = TypeHelper.GetConverter(typeof (TSUIntegerEnumeration), typeof (ulong));
            Assert.NotNull(converter, String.Format(METHOD_MUST_EXIST, typeof (TSUIntegerEnumeration), typeof (ulong)));

            converter = TypeHelper.GetConverter(typeof (ulong), typeof (TSUIntegerEnumeration));
            Assert.NotNull(converter, String.Format(METHOD_MUST_EXIST, typeof (ulong), typeof (TSUIntegerEnumeration)));

            converter = TypeHelper.GetConverter(typeof (TSInteger), typeof (int));
            Assert.NotNull(converter, String.Format(METHOD_MUST_EXIST, typeof (TSInteger), typeof (int)));

            converter = TypeHelper.GetConverter(typeof (int), typeof (TSInteger));
            Assert.NotNull(converter, String.Format(METHOD_MUST_EXIST, typeof (int), typeof (TSInteger)));

            converter = TypeHelper.GetConverter(typeof (TSInteger), typeof (long));
            Assert.NotNull(converter, String.Format(METHOD_MUST_EXIST, typeof (TSInteger), typeof (long)));

            converter = TypeHelper.GetConverter(typeof (long), typeof (TSInteger));
            Assert.NotNull(converter, String.Format(METHOD_MUST_EXIST, typeof (long), typeof (TSInteger)));

            converter = TypeHelper.GetConverter(typeof (TSFloat), typeof (float));
            Assert.NotNull(converter, String.Format(METHOD_MUST_EXIST, typeof (TSFloat), typeof (float)));

            converter = TypeHelper.GetConverter(typeof (float), typeof (TSFloat));
            Assert.NotNull(converter, String.Format(METHOD_MUST_EXIST, typeof (float), typeof (TSFloat)));

            converter = TypeHelper.GetConverter(typeof (TSFloat), typeof (double));
            Assert.NotNull(converter, String.Format(METHOD_MUST_EXIST, typeof (TSFloat), typeof (double)));

            converter = TypeHelper.GetConverter(typeof (double), typeof (TSFloat));
            Assert.NotNull(converter, String.Format(METHOD_MUST_EXIST, typeof (double), typeof (TSFloat)));
        }

        [Test]
        public void TestTypeConverterForMixedStructures()
        {
            MethodInfo converter;

            converter = TypeHelper.GetConverter(typeof (TSPoint), typeof (TSPoint));
            Assert.Null(converter, String.Format(METHOD_MUST_NOT_EXIST, typeof (TSPoint), typeof (TSPoint)));

            converter = TypeHelper.GetConverter(typeof (TSPoint), typeof (TSPoint64));
            Assert.NotNull(converter, String.Format(METHOD_MUST_EXIST, typeof (TSPoint), typeof (TSPoint64)));

            converter = TypeHelper.GetConverter(typeof (TSPoint64), typeof (TSPoint));
            Assert.NotNull(converter, String.Format(METHOD_MUST_EXIST, typeof (TSPoint64), typeof (TSPoint)));

            converter = TypeHelper.GetConverter(typeof (TSRect), typeof (TSRect));
            Assert.Null(converter, String.Format(METHOD_MUST_NOT_EXIST, typeof (TSRect), typeof (TSRect)));

            converter = TypeHelper.GetConverter(typeof (TSRect), typeof (TSRect64));
            Assert.NotNull(converter, String.Format(METHOD_MUST_EXIST, typeof (TSRect64), typeof (TSRect)));

            converter = TypeHelper.GetConverter(typeof (TSRect64), typeof (TSRect));
            Assert.NotNull(converter, String.Format(METHOD_MUST_EXIST, typeof (TSRect), typeof (TSRect64)));
        }
    }
}