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
using System.Threading;
using Monobjc;
using Monobjc.Foundation;
using NUnit.Framework;

namespace Monobjc.Foundation
{
    [TestFixture]
    [Category("NSNotification")]
    [Description("Test with NSNotification wrapper")]
    public class NSNotificationTests : WrapperTests
	{
		private ManualResetEvent mre;
		
        [Test]
        public void TestNotificationBySelector()
        {
			MyListener listener = new MyListener();
			
			mre = new ManualResetEvent(false);
			new Thread(this.Notify).Start();
			mre.WaitOne(5000);
			
			Assert.IsTrue(listener.Notified, "Listener must be notified");
			
			listener.Release();
		}
		
        [Test]
        public void TestNotificationByBlock()
        {
			bool notified = false;
			Action<NSNotification> action = delegate(NSNotification notification) { 
				notified = true;
			};
			Id listener = NSNotificationCenter.DefaultCenter.AddObserverForNameObjectQueueUsingBlock(MyListener.SELECTOR_NOTIFICATION, null, null, action);
			
			mre = new ManualResetEvent(false);
			new Thread(this.Notify).Start();
			mre.WaitOne(5000);
			
			Assert.IsTrue(notified, "Listener must be notified");
			
			NSNotificationCenter.DefaultCenter.RemoveObserver(listener);
		}

		private void Notify()
		{
			using(NSAutoreleasePool pool = new NSAutoreleasePool())
			{
				GC.WaitForPendingFinalizers();
				GC.Collect();
				GC.WaitForPendingFinalizers();
				NSNotificationCenter.DefaultCenter.PostNotificationNameObject(MyListener.SELECTOR_NOTIFICATION, null);
				mre.Set();
			}
		}
	}
	
    [ObjectiveCClass("MyListener")]
    public class MyListener : NSObject
    {
        public static Class MyListenerClass = Class.Get(typeof (MyListener));
		
        public const String SELECTOR_NOTIFICATION = "SELECTOR_NOTIFICATION";
		
        public MyListener()
        {
        }

        public MyListener(IntPtr value) : base(value) {}

		public bool Notified { get; private set; }
		
        [ObjectiveCMessage("init")]
        public override Id Init()
        {
            this.NativePointer = this.SendMessageSuper<IntPtr>(MyListenerClass, "init");
			NSNotificationCenter.DefaultCenter.AddObserverSelectorNameObject(this, "handleNotification:".ToSelector(), SELECTOR_NOTIFICATION, null);
            return this;
        }
		
        [ObjectiveCMessage("dealloc")]
		public override void Dealloc ()
		{
			NSNotificationCenter.DefaultCenter.RemoveObserver(this);
			this.SendMessageSuper(MyListenerClass, "dealloc");
		}
		
        [ObjectiveCMessage("handleNotification:")]
		public void NotifySelector(NSNotification notification)
		{
			this.Notified = true;
		}
    }
}