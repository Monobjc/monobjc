//
// This file is part of Monobjc, a .NET/Objective-C bridge
// Copyright (C) 2007-2013 - Laurent Etiemble
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
using Monobjc.Foundation;
using NUnit.Framework;

namespace Monobjc.AppKit
{
	[TestFixture]
	[Category("NSNib")]
	[Description("Test with NSNib wrapper")]
	public class NSNibTests : WrapperTests
	{
		[Test]
		public void TestNibNotFound ()
		{
			bool result = NSNib.InstantiateNibWithOwnerTopLevelObjects (typeof(NSNibTests), "dummy", null);
			Assert.IsFalse (result);
		}

		[Test]
		public void TestNibInvariantCulture ()
		{
			bool result = NSNib.InstantiateNibWithOwnerTopLevelObjects (typeof(NSNibTests), "Monobjc.AppKit.Tests.MainMenu.nib", null);
			Assert.IsTrue (result);
		}
			
		[Test]
		public void TestNibSpecificCulture ()
		{
			bool result = NSNib.InstantiateNibWithOwnerTopLevelObjects (typeof(NSNibTests), "Monobjc.AppKit.Tests.MainMenu2.nib", null);
			Assert.IsTrue (result);
		}
	}
}