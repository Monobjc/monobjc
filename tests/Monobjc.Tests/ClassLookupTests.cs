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

namespace Monobjc
{
    [TestFixture]
    [Category("Runtime")]
    [Category("Class")]
    [Description("Test the class lookup and cache")]
    public class ClassLookupTests : RuntimeTests
    {
        [Test]
        public void TestClassLookup()
        {
            String[] names = new[]
                                 {
                                     "NSObject", "NSProxy", "NSString", "NSNumber", "NSValue",
                                     "NSArray", "NSDictionary", "NSSet", "NSIndexSet",
                                     "NSMutableArray", "NSMutableDictionary", "NSMutableSet", "NSMutableIndexSet",
                                     "NSObject", "NSProxy", "NSString", "NSNumber", "NSValue",
                                     "NSArray", "NSDictionary", "NSSet", "NSIndexSet",
                                     "NSMutableArray", "NSMutableDictionary", "NSMutableSet", "NSMutableIndexSet",
                                     "NSObject", "NSProxy", "NSString", "NSNumber", "NSValue",
                                     "NSArray", "NSDictionary", "NSSet", "NSIndexSet",
                                     "NSMutableArray", "NSMutableDictionary", "NSMutableSet", "NSMutableIndexSet",
                                 };

            foreach (String name in names)
            {
                Class cls1 = Class.Get(name);
                Assert.IsNotNull(cls1, "Class cannot be null");
                Assert.AreNotEqual(IntPtr.Zero, cls1.NativePointer, "Pointer cannot be null");
                Assert.AreEqual(name, cls1.Name, "Class names must be equal");

                Class cls2 = Class.Get(cls1.NativePointer);
                Assert.IsNotNull(cls2, "Class cannot be null");
                Assert.AreNotEqual(IntPtr.Zero, cls2.NativePointer, "Pointer cannot be null");
                Assert.AreEqual(cls1.NativePointer, cls2.NativePointer, "Pointers must be equal");
                Assert.AreEqual(cls1, cls2);

                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }
    }
}