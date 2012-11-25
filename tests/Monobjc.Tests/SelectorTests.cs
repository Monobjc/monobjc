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
    [Category("Selector")]
    [Description("Test selector functions")]
    public class SelectorTests : RuntimeTests
    {
        [Test]
        public void TestSelectorDefinitions()
        {
            ObjectiveCRuntime.Initialize();

            IntPtr[] sels = new[]
                                {
                                    this.sel_addObject,
                                    this.sel_alloc,
                                    this.sel_autorelease,
                                    this.sel_boolValue,
                                    this.sel_compare,
                                    this.sel_count,
                                    this.sel_doubleValue,
                                    this.sel_floatValue,
                                    this.sel_frame,
                                    this.sel_init,
                                    this.sel_intValue,
                                    this.sel_length,
                                    this.sel_mainScreen,
                                    this.sel_numberWithBool,
                                    this.sel_numberWithDouble,
                                    this.sel_numberWithFloat,
                                    this.sel_numberWithInt,
                                    this.sel_numberWithShort,
                                    this.sel_objectAtIndex,
                                    this.sel_retain,
                                    this.sel_release,
                                    this.sel_shortValue,
                                    this.sel_isEqualToValue,
                                    this.sel_pointValue,
                                    this.sel_rangeValue,
                                    this.sel_rectValue,
                                    this.sel_sizeValue,
                                    this.sel_string,
                                    this.sel_stringWithUTF8String,
                                    this.sel_stringWithCharactersLength,
                                    this.sel_stringWithString,
                                    this.sel_valueWithPoint,
                                    this.sel_valueWithRange,
                                    this.sel_valueWithRect,
                                    this.sel_valueWithSize,
                                };

            foreach (IntPtr sel in sels)
            {
                String name = ObjectiveCRuntime.Selector(sel);
                Assert.AreNotEqual("", name, "Select cannot be empty");
                IntPtr selector = ObjectiveCRuntime.Selector(name);
                Assert.AreNotEqual(IntPtr.Zero, selector, "Selector cannot be null");
            }
        }

        [Test]
        public void TestSelectorOperations()
        {
            ObjectiveCRuntime.Initialize();

            String name;
            IntPtr sel;

            name = "alloc";
            sel = ObjectiveCRuntime.Selector(name);
            Assert.AreNotEqual(IntPtr.Zero, sel, "Selector cannot be null");
            name = ObjectiveCRuntime.Selector(sel);
            Assert.AreEqual("alloc", name, "Selector must be equal");

            name = "isEqualToValue:";
            sel = ObjectiveCRuntime.Selector(name);
            Assert.AreNotEqual(IntPtr.Zero, sel, "Selector cannot be null");
            name = ObjectiveCRuntime.Selector(sel);
            Assert.AreEqual("isEqualToValue:", name, "Selector must be equal");

            name = "stringWithCharacters:length:";
            sel = ObjectiveCRuntime.Selector(name);
            Assert.AreNotEqual(IntPtr.Zero, sel, "Selector cannot be null");
            name = ObjectiveCRuntime.Selector(sel);
            Assert.AreEqual("stringWithCharacters:length:", name, "Selector must be equal");
        }

        [Test]
        public void TestSelectorExtensions()
        {
            ObjectiveCRuntime.Initialize();

            String name, name1, name2;
            IntPtr sel1, sel2;

            name = "alloc";
            sel1 = ObjectiveCRuntime.Selector(name);
            Assert.AreNotEqual(IntPtr.Zero, sel1, "Selector cannot be null");
            sel2 = name.ToSelector();
            Assert.AreNotEqual(IntPtr.Zero, sel2, "Selector cannot be null");
            name1 = ObjectiveCRuntime.Selector(sel1);
            Assert.AreEqual(name, name1, "Selector must be equal");
            name2 = ObjectiveCRuntime.Selector(sel2);
            Assert.AreEqual(name, name2, "Selector must be equal");

            name = "isEqualToValue:";
            sel1 = ObjectiveCRuntime.Selector(name);
            Assert.AreNotEqual(IntPtr.Zero, sel1, "Selector cannot be null");
            sel2 = name.ToSelector();
            Assert.AreNotEqual(IntPtr.Zero, sel2, "Selector cannot be null");
            name1 = ObjectiveCRuntime.Selector(sel1);
            Assert.AreEqual(name, name1, "Selector must be equal");
            name2 = ObjectiveCRuntime.Selector(sel2);
            Assert.AreEqual(name, name2, "Selector must be equal");

            name = "stringWithCharacters:length:";
            sel1 = ObjectiveCRuntime.Selector(name);
            Assert.AreNotEqual(IntPtr.Zero, sel1, "Selector cannot be null");
            sel2 = name.ToSelector();
            Assert.AreNotEqual(IntPtr.Zero, sel2, "Selector cannot be null");
            name1 = ObjectiveCRuntime.Selector(sel1);
            Assert.AreEqual(name, name1, "Selector must be equal");
            name2 = ObjectiveCRuntime.Selector(sel2);
            Assert.AreEqual(name, name2, "Selector must be equal");
        }
    }
}