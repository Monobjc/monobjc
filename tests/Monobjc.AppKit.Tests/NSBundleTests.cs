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
using Monobjc.Foundation;
using NUnit.Framework;

namespace Monobjc.AppKit
{
    [TestFixture]
    [Category("NSBundle")]
    [Description("Test with NSBundle wrapper")]
    public class NSBundleTests : WrapperTests
	{
        [Test]
        public void TestResourceCreation()
        {
			NSBundle bundle = NSBundle.MainBundle;
			Check(bundle);
			
			bundle.LoadNibResourceNamedOwner(typeof(NSBundleTests), "Monobjc.AppKit.Tests.MainMenu.nib", null);
        }

        private static void Check(Id @object)
        {
            Assert.IsNotNull(@object, "Instance cannot be null");
            Assert.AreNotEqual(IntPtr.Zero, @object.NativePointer, "Native pointer cannot be null");
        }
	}
}