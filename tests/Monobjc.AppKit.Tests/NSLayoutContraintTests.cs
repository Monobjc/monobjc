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
using Monobjc.Foundation;
using NUnit.Framework;

namespace Monobjc.AppKit
{
#if MACOSX_10_7
    [TestFixture]
    [Category("NSLayoutConstraint")]
    [Description("Test with NSLayoutConstraint wrapper")]
    public class NSLayoutConstraintTests : WrapperTests
	{
        [Test]
        public void TestStaticCreation()
        {
			NSLayoutConstraint constraint;
			NSArray constraints;
			NSDictionary views;
			
			NSView view = new NSView(new NSRect(0, 0, 512, 512));
			NSButton button1 = new NSButton(new NSRect(0, 0, 128, 48));
			view.AddSubview(button1);
			button1.Release();
			NSButton button2 = new NSButton(new NSRect(0, 0, 128, 48));
			view.AddSubview(button2);
			button2.Release();
			
			views = NSDictionary.DictionaryWithObjectsAndKeys(button1, (NSString)"button1", button2, (NSString)"button2", null);
            constraints = NSLayoutConstraint.ConstraintsWithVisualFormatOptionsMetricsViews("[button1]-[button2]", 0, null, views);
            Check(constraints);
			
			view.Release();
        }

        [Test]
        public void TestPriority()
        {
			NSLayoutConstraint constraint;
			NSArray constraints;
			NSDictionary views;
			NSLayoutPriority priority;
			
			NSView view = new NSView(new NSRect(0, 0, 512, 512));
			NSButton button1 = new NSButton(new NSRect(0, 0, 128, 48));
			view.AddSubview(button1);
			button1.Release();
			NSButton button2 = new NSButton(new NSRect(0, 0, 128, 48));
			view.AddSubview(button2);
			button2.Release();
			
			views = NSDictionary.DictionaryWithObjectsAndKeys(button1, (NSString)"button1", button2, (NSString)"button2", null);
            constraints = NSLayoutConstraint.ConstraintsWithVisualFormatOptionsMetricsViews("[button1]-[button2]", 0, null, views);
            Check(constraints);

			constraint = constraints.LastObject.CastTo<NSLayoutConstraint>();
            Check(constraint);
			
			constraint.Priority = NSLayoutPriority.NSLayoutPriorityRequired;
			priority = constraint.Priority;
			Assert.AreEqual(NSLayoutPriority.NSLayoutPriorityRequired, priority, "Priorities should be equal");
			
			constraint.Priority = (NSLayoutPriority) ((double)NSLayoutPriority.NSLayoutPriorityDefaultLow + 1.5);
			priority = constraint.Priority;
			Assert.AreEqual(NSLayoutPriority.NSLayoutPriorityDefaultLow + 1, priority, "Priorities should be equal");
			
			constraint.Priority = (NSLayoutPriority) ((double)NSLayoutPriority.NSLayoutPriorityDefaultLow + 45.23);
			priority = constraint.Priority;
			Assert.AreEqual(NSLayoutPriority.NSLayoutPriorityDefaultLow + 45, priority, "Priorities should be equal");
			
			constraint.Priority = (NSLayoutPriority) ((double)NSLayoutPriority.NSLayoutPriorityDefaultLow + 45.75);
			priority = constraint.Priority;
			Assert.AreEqual(NSLayoutPriority.NSLayoutPriorityDefaultLow + 45, priority, "Priorities should be equal");
			
			view.Release();
        }

        [Test]
        public void TestExceptions()
        {
			NSLayoutConstraint constraint;
			NSArray constraints;
			NSDictionary views;
			
			NSView view = new NSView(new NSRect(0, 0, 512, 512));
			NSButton button1 = new NSButton(new NSRect(0, 0, 128, 48));
			view.AddSubview(button1);
			button1.Release();
			NSButton button2 = new NSButton(new NSRect(0, 0, 128, 48));
			view.AddSubview(button2);
			button2.Release();
			
            Assert.Throws<ObjectiveCMessagingException>(() =>
			{
				constraints = NSLayoutConstraint.ConstraintsWithVisualFormatOptionsMetricsViews("[button1]-[button2]", 0, null, null);
			});
            Assert.Throws<ObjectiveCMessagingException>(() =>
			{
				views = NSDictionary.DictionaryWithObjectsAndKeys(button1, (NSString)"button1", null);
				constraints = NSLayoutConstraint.ConstraintsWithVisualFormatOptionsMetricsViews("[button1]-[button2]", 0, null, views);
			});
            Assert.Throws<ObjectiveCMessagingException>(() =>
			{
				views = NSDictionary.DictionaryWithObjectsAndKeys(button1, (NSString)"button1", button2, (NSString)"dummy", null);
				constraints = NSLayoutConstraint.ConstraintsWithVisualFormatOptionsMetricsViews("V|[button1]-[button2]|", 0, null, views);
			});
            Assert.Throws<ObjectiveCMessagingException>(() =>
			{
				views = NSDictionary.DictionaryWithObjectsAndKeys(button1, (NSString)"button1", button2, (NSString)"dummy", null);
				constraints = NSLayoutConstraint.ConstraintsWithVisualFormatOptionsMetricsViews("V:|[button1(>30)]|", 0, null, views);
			});
			
			view.Release();
        }

        private static void Check(Id @object)
        {
            Assert.IsNotNull(@object, "Instance cannot be null");
            Assert.AreNotEqual(IntPtr.Zero, @object.NativePointer, "Native pointer cannot be null");
        }
	}
#endif
}
