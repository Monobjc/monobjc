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
using Monobjc.Foundation;
using NUnit.Framework;

namespace Monobjc.AppKit
{
    [TestFixture]
    [Category("NSColor")]
    [Description("Test with NSColor wrapper")]
    public class NSColorTests : WrapperTests
	{
        [Test]
        public void TestStaticCreation()
        {
			NSColor color;
		
            color = NSColor.BlackColor;
            Check(color);
			
            color = NSColor.ColorForControlTint(NSControlTint.NSDefaultControlTint);
            Check(color);
			
            color = NSColor.ColorWithCalibratedHueSaturationBrightnessAlpha(0.5, 0.5, 0.5, 0.5);
            Check(color);
			
            color = NSColor.ColorWithCalibratedRedGreenBlueAlpha(0.5, 0.5, 0.5, 0.5);
            Check(color);
			
            color = NSColor.ColorWithCalibratedWhiteAlpha(0.5, 0.5);
            Check(color);
			
            color = NSColor.ColorWithDeviceCyanMagentaYellowBlackAlpha(0.5, 0.5, 0.5, 0.5, 0.5);
            Check(color);
			
            color = NSColor.ColorWithDeviceHueSaturationBrightnessAlpha(0.5, 0.5, 0.5, 0.5);
            Check(color);
			
            color = NSColor.ColorWithDeviceRedGreenBlueAlpha(0.5, 0.5, 0.5, 0.5);
            Check(color);
			
            color = NSColor.ColorWithDeviceWhiteAlpha(0.5, 0.5);
            Check(color);
        }

        private static void Check(Id @object)
        {
            Assert.IsNotNull(@object, "Instance cannot be null");
            Assert.AreNotEqual(IntPtr.Zero, @object.NativePointer, "Native pointer cannot be null");
        }
	}
}