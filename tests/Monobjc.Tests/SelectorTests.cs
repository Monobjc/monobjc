//
// This file is part of Monobjc, a .NET/Objective-C bridge
// Copyright (C) 2007-2012 - Laurent Etiemble
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