//
// This file is part of Monobjc, a .NET/Objective-C bridge
// Copyright (C) 2007-2014 - Laurent Etiemble
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