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
    [Category("NSCell")]
    [Description("Test with NSCell wrapper")]
    public class NSCellTests : WrapperTests
	{
        [Test]
        public void TestConversion()
        {
            NSCellStateValue value;
            bool result;
            
            value = NSCellStateValue.NSOffState;
            result = value.ToBool();
            Assert.AreEqual(false, result);
            
            value = NSCellStateValue.NSMixedState;
            result = value.ToBool();
            Assert.AreEqual(true, result);
            
            value = NSCellStateValue.NSOnState;
            result = value.ToBool();
            Assert.AreEqual(true, result);
            
            result = false;
            value = result.ToNSCellStateValue();
            Assert.AreEqual(NSCellStateValue.NSOffState, value);
            
            result = true;
            value = result.ToNSCellStateValue();
            Assert.AreEqual(NSCellStateValue.NSOnState, value);
        }
	}
}