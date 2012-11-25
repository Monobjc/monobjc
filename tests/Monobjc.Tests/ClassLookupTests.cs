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