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
using System.Runtime.InteropServices;
using NUnit.Framework;

namespace Monobjc
{
    [TestFixture]
    [Category("Runtime")]
    [Category("Symbols")]
    [Category("Framework")]
    [Description("Test framework related functions")]
    public class SymbolTests
    {
        [Test]
        public void TestFrameworkLoading()
        {
            IntPtr handle;

            handle = NativeMethods.LoadFramework("Garbage");
            Assert.AreEqual(IntPtr.Zero, handle, "Framework must not be found");

            handle = NativeMethods.LoadFramework("Foundation");
            Assert.AreNotEqual(IntPtr.Zero, handle, "Framework must be found");
        }

        [Test]
        public void TestFrameworkSymbols()
        {
            ObjectiveCRuntime.LoadFramework("WebKit");
            ObjectiveCRuntime.Initialize();

            IntPtr symbol;

            symbol = NativeMethods.GetFrameworkSymbol("WebKit", "WebViewDummy");
            Assert.AreEqual(IntPtr.Zero, symbol, "Symbol must not be found");

            symbol = NativeMethods.GetFrameworkSymbol("WebKit", "WebViewDidChangeNotification");
            Assert.AreNotEqual(IntPtr.Zero, symbol, "Symbol must be found");
        }

        [Test]
        public void TestFrameworkExternals()
        {
            ObjectiveCRuntime.LoadFramework("Foundation");
            ObjectiveCRuntime.LoadFramework("AppKit");
            ObjectiveCRuntime.LoadFramework("CoreLocation");
            ObjectiveCRuntime.LoadFramework("DiscRecording");
            ObjectiveCRuntime.LoadFramework("WebKit");
            ObjectiveCRuntime.Initialize();

            Id value = ObjectiveCRuntime.GetExtern<Id>("WebKit", "WebViewDidChangeNotification");
            Assert.AreNotEqual(IntPtr.Zero, value.NativePointer, "Symbol must be found");

            IntPtr str = ObjectiveCRuntime.SendMessage<IntPtr>(value, "UTF8String");
            Assert.AreNotEqual(IntPtr.Zero, str, "Symbol must have a valid value");

            String s = Marshal.PtrToStringAuto(str);
            Assert.AreEqual("WebViewDidChangeNotification", s, "Symbol must have the right value");

            int @int = ObjectiveCRuntime.GetExtern<int>("QuartzCore", "kCIFormatARGB8");
            Assert.AreNotEqual(Int32.MinValue, @int, "Symbol must be found");
            Assert.AreEqual(23, @int, "Symbol must have the right value");

            float @float = ObjectiveCRuntime.GetExtern<float>("DiscRecording", "DRDeviceBurnSpeedMax");
            Assert.AreNotEqual(Single.NaN, @float, "Symbol must be found");
            Assert.AreEqual(65535.0f, @float, "Symbol must have the right value");

            double @double = ObjectiveCRuntime.GetExtern<double>("CoreLocation", "kCLLocationAccuracyNearestTenMeters");
            Assert.AreNotEqual(Double.NaN, @double, "Symbol must be found");
            Assert.AreEqual(10.0d, @double, "Symbol must have the right value");
        }
    }
}