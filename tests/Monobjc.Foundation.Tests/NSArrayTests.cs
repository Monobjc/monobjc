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
using NUnit.Framework;

namespace Monobjc.Foundation
{
    [TestFixture]
    [Category("NSArray")]
    public class NSArrayTests : WrapperTests
    {
        [Test]
        public void TestStaticCreation()
        {
            NSArray array = NSArray.Array;
            Assert.IsNotNull(array, "Creation cannot fail");
            Assert.AreNotEqual(IntPtr.Zero, array.NativePointer, "Pointer cannot be null");

            Class cls = array.Class;
            Assert.IsNotNull(cls, "Class retrieval cannot fail");
            Assert.AreNotEqual(IntPtr.Zero, cls.NativePointer, "Pointer cannot be null");

            uint count = array.Count;
            Assert.AreEqual(0, count, "Length must be 0");

            array = NSArray.ArrayWithObject(NSString.String);
            Assert.IsNotNull(array, "Creation cannot fail");
            Assert.AreNotEqual(IntPtr.Zero, array.NativePointer, "Pointer cannot be null");
        }

        [Test]
        public void TestVarArgsCreation()
        {
            NSArray array;

            array = NSArray.ArrayWithObjects(NSNumber.NumberWithInt(123), NSString.StringWithUTF8String("TEST"), null);
            Assert.IsNotNull(array, "Creation cannot fail");
            Assert.AreNotEqual(IntPtr.Zero, array.NativePointer, "Pointer cannot be null");

            array = NSArray.ArrayWithObjects(NSNumber.NumberWithInt(123), NSNumber.NumberWithInt(456), NSNumber.NumberWithInt(789), null);
            Assert.IsNotNull(array, "Creation cannot fail");
            Assert.AreNotEqual(IntPtr.Zero, array.NativePointer, "Pointer cannot be null");

            array = NSArray.ArrayWithObjects(NSNumber.NumberWithInt(123), NSString.String, NSNumber.NumberWithInt(789), null);
            Assert.IsNotNull(array, "Creation cannot fail");
            Assert.AreNotEqual(IntPtr.Zero, array.NativePointer, "Pointer cannot be null");
        }
    }
}