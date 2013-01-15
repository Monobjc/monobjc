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
#if MACOSX_10_7
    [TestFixture]
    [Category("NSLayoutConstraint")]
    [Description("Test with NSLayoutConstraint wrapper")]
    public class NSLayoutConstraintTests : WrapperTests
	{
        [Test]
        public void TestStaticCreation()
        {
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
				NSLayoutConstraint.ConstraintsWithVisualFormatOptionsMetricsViews("[button1]-[button2]", 0, null, null);
			});
            Assert.Throws<ObjectiveCMessagingException>(() =>
			{
				views = NSDictionary.DictionaryWithObjectsAndKeys(button1, (NSString)"button1", null);
				NSLayoutConstraint.ConstraintsWithVisualFormatOptionsMetricsViews("[button1]-[button2]", 0, null, views);
			});
            Assert.Throws<ObjectiveCMessagingException>(() =>
			{
				views = NSDictionary.DictionaryWithObjectsAndKeys(button1, (NSString)"button1", button2, (NSString)"dummy", null);
				NSLayoutConstraint.ConstraintsWithVisualFormatOptionsMetricsViews("V|[button1]-[button2]|", 0, null, views);
			});
            Assert.Throws<ObjectiveCMessagingException>(() =>
			{
				views = NSDictionary.DictionaryWithObjectsAndKeys(button1, (NSString)"button1", button2, (NSString)"dummy", null);
				NSLayoutConstraint.ConstraintsWithVisualFormatOptionsMetricsViews("V:|[button1(>30)]|", 0, null, views);
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
