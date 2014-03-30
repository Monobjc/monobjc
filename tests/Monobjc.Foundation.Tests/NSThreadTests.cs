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
using NUnit.Framework;

namespace Monobjc.Foundation
{
    [TestFixture]
    [Category("NSThread")]
    [Description("Test with NSThread wrapper")]
    public class NSThreadTests : WrapperTests
    {
        [Test]
        public void TestMakeMultithread()
        {
            bool value = NSThread.IsMultiThreaded;
            if (value)
            {
                //Assert.Inconclusive("The application is already marked as multi-threaded");
                return;
            }
            NSThread.MakeMultiThreaded();
            Assert.IsTrue(NSThread.IsMultiThreaded, "The application should be marked as multi-threaded");
        }
        
        [Test]
        public void TestInvoke()
        {
            NSThread thread = NSThread.CurrentThread;
            int count;

            count = 1;
            thread.Invoke(delegate() {
                count++;
            });
            Assert.AreEqual(2, count, "Count must be 2");

            count = 2;
            thread.Invoke(delegate(Object state) {
                Assert.IsNull(state);
                count++;
            }, null);
            Assert.AreEqual(3, count, "Count must be 3");

            count = 3;
            thread.Invoke(delegate(Object state) {
                Assert.IsNotNull(state);
                count += (int) state;
            }, 2);
            Assert.AreEqual(5, count, "Count must be 5");

            count = 4;
            thread.Invoke(delegate(Id arg) {
                Assert.IsNotNull(arg);
                count += arg.CastTo<NSNumber>().IntValue;
            }, NSNumber.NumberWithInt(3));
            Assert.AreEqual(7, count, "Count must be 7");
        }

        [Test]
        public void TestStartNewThread()
        {
            ManualResetEventSlim mre = new ManualResetEventSlim();
            int count;
            bool result;

            count = 1;
            mre.Reset();
            NSThread.StartNewThread(delegate() {
                count++;
                mre.Set();
            });
            result = mre.Wait(1000);
            Assert.IsTrue(result, "Wait cannot fail");
            Assert.AreEqual(2, count, "Count must be 2");

            count = 2;
            mre.Reset();
            NSThread.StartNewThread(delegate(Object state) {
                Assert.IsNull(state);
                count++;
                mre.Set();
            }, null);
            result = mre.Wait(1000);
            Assert.IsTrue(result, "Wait cannot fail");
            Assert.AreEqual(3, count, "Count must be 3");

            count = 3;
            mre.Reset();
            NSThread.StartNewThread(delegate(Object state) {
                Assert.IsNotNull(state);
                count += (int) state;
                mre.Set();
            }, 2);
            result = mre.Wait(1000);
            Assert.IsTrue(result, "Wait cannot fail");
            Assert.AreEqual(5, count, "Count must be 5");

            count = 4;
            mre.Reset();
            NSThread.StartNewThread(delegate(Id arg) {
                Assert.IsNotNull(arg);
                count += arg.CastTo<NSNumber>().IntValue;
                mre.Set();
            }, NSNumber.NumberWithInt(3));
            result = mre.Wait(1000);
            Assert.IsTrue(result, "Wait cannot fail");
            Assert.AreEqual(7, count, "Count must be 7");
        }

//        [Test]
//        public void TestContextSend()
//        {
//            int count;
//
//            SynchronizationContext currentContext = SynchronizationContext.Current;
//
//            SynchronizationContext.SetSynchronizationContext(new NSThreadSynchronizationContext());
//            Assert.IsNotNull(SynchronizationContext.Current);
//            
//            count = 1;
//            currentContext.Send(delegate(Object state) {
//                Assert.IsNull(state);
//                count++;
//            }, null);
//            Assert.AreEqual(2, count, "Count must be 2");
//            
//            count = 2;
//            currentContext.Send(delegate(Object state) {
//                Assert.IsNotNull(state);
//                count += (int) state;
//            }, 3);
//            Assert.AreEqual(5, count, "Count must be 5");
//
//            SynchronizationContext.SetSynchronizationContext(currentContext);
//        }
    }
}
