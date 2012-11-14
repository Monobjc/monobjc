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
			Block block = null;
			Action<NSNotification> action = delegate(NSNotification notification) { 
				notified = true;
			};
			block = Block.Create(action);
			
			Id listener = NSNotificationCenter.DefaultCenter.AddObserverForNameObjectQueueUsingBlock(MyListener.SELECTOR_NOTIFICATION, null, null, block);
			
			mre = new ManualResetEvent(false);
			new Thread(this.Notify).Start();
			mre.WaitOne(5000);
			
			Assert.IsTrue(notified, "Listener must be notified");
			
			NSNotificationCenter.DefaultCenter.RemoveObserver(listener);
			block.Dispose();
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
		
		public static readonly NSString SELECTOR_NOTIFICATION = NSString.NSPinnedString("SELECTOR_NOTIFICATION");
		
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