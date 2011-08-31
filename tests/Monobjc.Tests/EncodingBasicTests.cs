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
using Monobjc.Types;
using NUnit.Framework;

namespace Monobjc
{
    [TestFixture]
    [Category("Encoding")]
    [Description("Test encoding of type and parameters between .NET and Objective-C")]
    public class EncodingBasicTests : RuntimeTests
    {
        /// <summary>
        ///   Tests the encoding string.
        /// </summary>
        [Test]
        public void TestGetStringEncoding()
        {
            Assert.AreEqual("c", ObjectiveCEncoding.GetTypeEncoding(typeof (bool)), "Encoding is wrong for bool");
            Assert.AreEqual("S", ObjectiveCEncoding.GetTypeEncoding(typeof (char)), "Encoding is wrong for char");

            Assert.AreEqual("s", ObjectiveCEncoding.GetTypeEncoding(typeof (short)), "Encoding is wrong for short");
            Assert.AreEqual("s", ObjectiveCEncoding.GetTypeEncoding(typeof (Int16)), "Encoding is wrong for Int16");
            Assert.AreEqual("i", ObjectiveCEncoding.GetTypeEncoding(typeof (int)), "Encoding is wrong for int");
            Assert.AreEqual("i", ObjectiveCEncoding.GetTypeEncoding(typeof (Int32)), "Encoding is wrong for Int32");
            Assert.AreEqual("q", ObjectiveCEncoding.GetTypeEncoding(typeof (long)), "Encoding is wrong for long");
            Assert.AreEqual("q", ObjectiveCEncoding.GetTypeEncoding(typeof (Int64)), "Encoding is wrong for Int64");

            Assert.AreEqual("S", ObjectiveCEncoding.GetTypeEncoding(typeof (ushort)), "Encoding is wrong for ushort");
            Assert.AreEqual("S", ObjectiveCEncoding.GetTypeEncoding(typeof (UInt16)), "Encoding is wrong for UInt16");
            Assert.AreEqual("I", ObjectiveCEncoding.GetTypeEncoding(typeof (uint)), "Encoding is wrong for uint");
            Assert.AreEqual("I", ObjectiveCEncoding.GetTypeEncoding(typeof (UInt32)), "Encoding is wrong for UInt32");
            Assert.AreEqual("Q", ObjectiveCEncoding.GetTypeEncoding(typeof (ulong)), "Encoding is wrong for ulong");
            Assert.AreEqual("Q", ObjectiveCEncoding.GetTypeEncoding(typeof (UInt64)), "Encoding is wrong for UInt64");

            Assert.AreEqual("f", ObjectiveCEncoding.GetTypeEncoding(typeof (float)), "Encoding is wrong for float");
            Assert.AreEqual("d", ObjectiveCEncoding.GetTypeEncoding(typeof (double)), "Encoding is wrong for double");

            Assert.AreEqual("v", ObjectiveCEncoding.GetTypeEncoding(typeof (void)), "Encoding is wrong for void");

            Assert.AreEqual("*", ObjectiveCEncoding.GetTypeEncoding(typeof (String)), "Encoding is wrong for String");
            Assert.AreEqual("@", ObjectiveCEncoding.GetTypeEncoding(typeof (Id)), "Encoding is wrong for id");
            Assert.AreEqual("#", ObjectiveCEncoding.GetTypeEncoding(typeof (Class)), "Encoding is wrong for ObjCClass");

            Assert.AreEqual("{TSDecimal=iSSSSSSSS}", ObjectiveCEncoding.GetTypeEncoding(typeof (TSDecimal)), "Encoding is wrong for TSDecimal");

            // Variable types
            if (ObjectiveCRuntime.Is64Bits)
            {
                Assert.AreEqual("d", ObjectiveCEncoding.GetTypeEncoding(typeof (TSFloat)), "Encoding is wrong for CGFloat");
                Assert.AreEqual("q", ObjectiveCEncoding.GetTypeEncoding(typeof (TSInteger)), "Encoding is wrong for NSInteger");
                Assert.AreEqual("Q", ObjectiveCEncoding.GetTypeEncoding(typeof (TSUInteger)), "Encoding is wrong for NSUInteger");

                Assert.AreEqual("{TSRange64=QQ}", ObjectiveCEncoding.GetTypeEncoding(typeof (TSRange)), "Encoding is wrong for TSRange");
                Assert.AreEqual("{TSPoint64=dd}", ObjectiveCEncoding.GetTypeEncoding(typeof (TSPoint)), "Encoding is wrong for TSPoint");
                Assert.AreEqual("{TSSize64=dd}", ObjectiveCEncoding.GetTypeEncoding(typeof (TSSize)), "Encoding is wrong for TSSize");
                Assert.AreEqual("{TSRect64={TSPoint64=dd}{TSSize64=dd}}", ObjectiveCEncoding.GetTypeEncoding(typeof (TSRect)), "Encoding is wrong for TSRect");

                Assert.AreEqual("q", ObjectiveCEncoding.GetTypeEncoding(typeof (TSIntegerEnumeration)), "Encoding is wrong for TSIntegerEnumeration");
                Assert.AreEqual("Q", ObjectiveCEncoding.GetTypeEncoding(typeof (TSUIntegerEnumeration)), "Encoding is wrong for TSUIntegerEnumeration");
            }
            else
            {
                Assert.AreEqual("f", ObjectiveCEncoding.GetTypeEncoding(typeof (TSFloat)), "Encoding is wrong for CGFloat");
                Assert.AreEqual("i", ObjectiveCEncoding.GetTypeEncoding(typeof (TSInteger)), "Encoding is wrong for NSInteger");
                Assert.AreEqual("I", ObjectiveCEncoding.GetTypeEncoding(typeof (TSUInteger)), "Encoding is wrong for NSUInteger");

                Assert.AreEqual("{TSRange=II}", ObjectiveCEncoding.GetTypeEncoding(typeof (TSRange)), "Encoding is wrong for TSRange");
                Assert.AreEqual("{TSPoint=ff}", ObjectiveCEncoding.GetTypeEncoding(typeof (TSPoint)), "Encoding is wrong for TSPoint");
                Assert.AreEqual("{TSSize=ff}", ObjectiveCEncoding.GetTypeEncoding(typeof (TSSize)), "Encoding is wrong for TSSize");
                Assert.AreEqual("{TSRect={TSPoint=ff}{TSSize=ff}}", ObjectiveCEncoding.GetTypeEncoding(typeof (TSRect)), "Encoding is wrong for TSRect");

                Assert.AreEqual("i", ObjectiveCEncoding.GetTypeEncoding(typeof (TSIntegerEnumeration)), "Encoding is wrong for TSIntegerEnumeration");
                Assert.AreEqual("I", ObjectiveCEncoding.GetTypeEncoding(typeof (TSUIntegerEnumeration)), "Encoding is wrong for TSUIntegerEnumeration");
            }

            // Arrays (Not Supported Yet)

            // Union (Not Supported Yet)

            // BitField (Not Supported Yet)

            // Enum
            Assert.AreEqual("i", ObjectiveCEncoding.GetTypeEncoding(typeof (TSWindingRule)), "Encoding is wrong for TSWindingRule");

            Assert.AreEqual(@"^", ObjectiveCEncoding.GetTypeEncoding(typeof (IntPtr)), "Encoding is wrong for IntPtr");

            Assert.AreEqual("@", ObjectiveCEncoding.GetTypeEncoding(typeof (ITSObject)), "Encoding is wrong for ITSObject");
            Assert.AreEqual("@", ObjectiveCEncoding.GetTypeEncoding(typeof (TSObject)), "Encoding is wrong for TSObject");
            Assert.AreEqual("@", ObjectiveCEncoding.GetTypeEncoding(typeof (TSString)), "Encoding is wrong for TSString");
            Assert.AreEqual("@", ObjectiveCEncoding.GetTypeEncoding(typeof (TSControl)), "Encoding is wrong for TSControl");
        }

        /// <summary>
        ///   Tests the encoding size.
        /// </summary>
        [Test]
        public void TestGetSize()
        {
            Assert.AreEqual(1, ObjectiveCEncoding.GetTypeSize(typeof (bool)), "Size is wrong for bool");
            Assert.AreEqual(2, ObjectiveCEncoding.GetTypeSize(typeof (char)), "Size is wrong for char");

            Assert.AreEqual(2, ObjectiveCEncoding.GetTypeSize(typeof (short)), "Size is wrong for short");
            Assert.AreEqual(2, ObjectiveCEncoding.GetTypeSize(typeof (Int16)), "Size is wrong for Int16");
            Assert.AreEqual(4, ObjectiveCEncoding.GetTypeSize(typeof (int)), "Size is wrong for int");
            Assert.AreEqual(4, ObjectiveCEncoding.GetTypeSize(typeof (Int32)), "Size is wrong for Int32");
            Assert.AreEqual(8, ObjectiveCEncoding.GetTypeSize(typeof (long)), "Size is wrong for long");
            Assert.AreEqual(8, ObjectiveCEncoding.GetTypeSize(typeof (Int64)), "Size is wrong for Int64");

            Assert.AreEqual(2, ObjectiveCEncoding.GetTypeSize(typeof (ushort)), "Size is wrong for ushort");
            Assert.AreEqual(2, ObjectiveCEncoding.GetTypeSize(typeof (UInt16)), "Size is wrong for UInt16");
            Assert.AreEqual(4, ObjectiveCEncoding.GetTypeSize(typeof (uint)), "Size is wrong for uint");
            Assert.AreEqual(4, ObjectiveCEncoding.GetTypeSize(typeof (UInt32)), "Size is wrong for UInt32");
            Assert.AreEqual(8, ObjectiveCEncoding.GetTypeSize(typeof (ulong)), "Size is wrong for ulong");
            Assert.AreEqual(8, ObjectiveCEncoding.GetTypeSize(typeof (UInt64)), "Size is wrong for UInt64");

            Assert.AreEqual(4, ObjectiveCEncoding.GetTypeSize(typeof (float)), "Size is wrong for float");
            Assert.AreEqual(8, ObjectiveCEncoding.GetTypeSize(typeof (double)), "Size is wrong for double");

            Assert.AreEqual(4, ObjectiveCEncoding.GetTypeSize(typeof (void)), "Size is wrong for void");

            Assert.AreEqual(IntPtr.Size, ObjectiveCEncoding.GetTypeSize(typeof (String)), "Size is wrong for String");
            Assert.AreEqual(IntPtr.Size, ObjectiveCEncoding.GetTypeSize(typeof (Id)), "Size is wrong for id");
            Assert.AreEqual(IntPtr.Size, ObjectiveCEncoding.GetTypeSize(typeof (Class)), "Size is wrong for ObjCClass");

            Assert.AreEqual(20, ObjectiveCEncoding.GetTypeSize(typeof (TSDecimal)), "Size is wrong for TSDecimal");

            // Variable types
            if (ObjectiveCRuntime.Is64Bits)
            {
                Assert.AreEqual(8, ObjectiveCEncoding.GetTypeSize(typeof (TSFloat)), "Size is wrong for CGFloat");
                Assert.AreEqual(8, ObjectiveCEncoding.GetTypeSize(typeof (TSInteger)), "Size is wrong for NSInteger");
                Assert.AreEqual(8, ObjectiveCEncoding.GetTypeSize(typeof (TSUInteger)), "Size is wrong for NSUInteger");

                Assert.AreEqual(16, ObjectiveCEncoding.GetTypeSize(typeof (TSRange)), "Size is wrong for TSRange");
                Assert.AreEqual(32, ObjectiveCEncoding.GetTypeSize(typeof (TSRect)), "Size is wrong for TSRect");
                Assert.AreEqual(16, ObjectiveCEncoding.GetTypeSize(typeof (TSSize)), "Size is wrong for TSSize");
                Assert.AreEqual(16, ObjectiveCEncoding.GetTypeSize(typeof (TSPoint)), "Size is wrong for TSPoint");

                Assert.AreEqual(8, ObjectiveCEncoding.GetTypeSize(typeof (TSIntegerEnumeration)), "Size is wrong for TSIntegerEnumeration");
            }
            else
            {
                Assert.AreEqual(4, ObjectiveCEncoding.GetTypeSize(typeof (TSFloat)), "Size is wrong for CGFloat");
                Assert.AreEqual(4, ObjectiveCEncoding.GetTypeSize(typeof (TSInteger)), "Size is wrong for NSInteger");
                Assert.AreEqual(4, ObjectiveCEncoding.GetTypeSize(typeof (TSUInteger)), "Size is wrong for NSUInteger");

                Assert.AreEqual(8, ObjectiveCEncoding.GetTypeSize(typeof (TSRange)), "Size is wrong for TSRange");
                Assert.AreEqual(16, ObjectiveCEncoding.GetTypeSize(typeof (TSRect)), "Size is wrong for TSRect");
                Assert.AreEqual(8, ObjectiveCEncoding.GetTypeSize(typeof (TSSize)), "Size is wrong for TSSize");
                Assert.AreEqual(8, ObjectiveCEncoding.GetTypeSize(typeof (TSPoint)), "Size is wrong for TSPoint");

                Assert.AreEqual(4, ObjectiveCEncoding.GetTypeSize(typeof (TSIntegerEnumeration)), "Size is wrong for TSIntegerEnumeration");
            }

            // Arrays (Not Supported Yet)

            // Union (Not Supported Yet)

            // BitField (Not Supported Yet)

            // Enum
            Assert.AreEqual(4, ObjectiveCEncoding.GetTypeSize(typeof (TSWindingRule)), "Size is wrong for TSWindingRule");

            Assert.AreEqual(IntPtr.Size, ObjectiveCEncoding.GetTypeSize(typeof (IntPtr)), "Size is wrong for IntPtr");

            Assert.AreEqual(IntPtr.Size, ObjectiveCEncoding.GetTypeSize(typeof (ITSObject)), "Size is wrong for ITSObject");
            Assert.AreEqual(IntPtr.Size, ObjectiveCEncoding.GetTypeSize(typeof (TSObject)), "Size is wrong for TSObject");
            Assert.AreEqual(IntPtr.Size, ObjectiveCEncoding.GetTypeSize(typeof (TSString)), "Size is wrong for TSString");
            Assert.AreEqual(IntPtr.Size, ObjectiveCEncoding.GetTypeSize(typeof (TSWindow)), "Size is wrong for TSWindow");
        }
    }
}