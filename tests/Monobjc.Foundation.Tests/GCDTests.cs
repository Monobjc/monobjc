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
using NUnit.Framework;
using Monobjc.Kernel;
using System.Threading;
using System.Runtime.InteropServices;

namespace Monobjc.Foundation
{
    [TestFixture]
    [Category("GCD")]
    public class GCDTests : WrapperTests
    {
//        [Test]
//        public void TestDispatchSync()
//        {
//            IntPtr queue = Dispatch.dispatch_get_global_queue(Dispatch.DISPATCH_QUEUE_PRIORITY_DEFAULT, 0);
//
//            int run = 0;
//            dispatch_block_t block = delegate
//            {
//                run++;
//            };
//
//            Dispatch.dispatch_sync(queue, block);
//
//            Assert.AreEqual(1, run, "dispatch_sync should have been executed");
//        }
//
//        [Test]
//        public void TestDispatchAsync()
//        {
//            IntPtr queue = Dispatch.dispatch_get_global_queue(Dispatch.DISPATCH_QUEUE_PRIORITY_DEFAULT, 0);
//
//            using (ManualResetEventSlim mre = new ManualResetEventSlim(false))
//            {
//                int run = 0;
//                dispatch_block_t block = delegate
//                {
//                    run++;
//                    mre.Set();
//                };
//                GCHandle handle = GCHandle.Alloc(block, GCHandleType.Pinned);
//
//                Dispatch.dispatch_async(queue, block);
//                mre.Wait(1000);
//                
//                Assert.AreEqual(1, run, "dispatch_async should have been executed");
//                handle.Free();
//            }
//        }
    }
}
