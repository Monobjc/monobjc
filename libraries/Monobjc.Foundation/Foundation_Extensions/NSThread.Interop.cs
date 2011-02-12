//
// This file is part of Monobjc, a .NET/Objective-C bridge
// Copyright (C) 2007-2011 - Laurent Etiemble
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
using System.Runtime.CompilerServices;
using System.Threading;

namespace Monobjc.Foundation
{
    public partial class NSThread
    {
        /// <summary>
        /// Delegate that will be run.
        /// <para>The associated method MUST create an <see cref="NSAutoreleasePool"/> if needed to avoid leaks.</para>
        /// </summary>
        public delegate void NSThreadRunner(Id argument);

        /// <summary>
        /// Makes the application multi-threaded.
        /// </summary>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static void MakeMultiThreaded()
        {
            if (!IsMultiThreaded)
            {
                Logger.Debug("NSThread", "Making current application multithreaded");

                // Setup a signal to block until secondary thread is running
                ManualResetEvent mre = new ManualResetEvent(false);

                // The code that will be executed in the secondary thread
                NSThreadRunner runner = delegate
                                            {
                                                // Signal event to unblock caller
                                                Logger.Debug("NSThread", "Signalling that multithreading is activated");
                                                mre.Set();
                                            };
                // Create the secondary thread
                DetachNewThreadSelectorToTargetWithObject(runner, null);

                // Block until secondary thread is running
                mre.WaitOne();

                Logger.Debug("NSThread", "Current application is NOW multithreaded");
            }
        }

        /// <summary>
        /// Detaches a new thread.
        /// </summary>
        /// <param name="aRunner">The delegate that will be executed on the new thread.</param>
        /// <param name="anArgument">The single argument passed to the target. May be nil.</param>
        /// <returns>YES if the application is multithreaded, NO otherwise.</returns>
        public static void DetachNewThreadSelectorToTargetWithObject(NSThreadRunner aRunner, Id anArgument)
        {
            NSThreadLauncher launcher = new NSThreadLauncher(aRunner);
            ObjectiveCRuntime.SendMessage(NSThreadClass, "detachNewThreadSelector:toTarget:withObject:", ObjectiveCRuntime.Selector("launch:"), launcher, anArgument);
        }

        /// <summary>
        /// Dispatcher to connect .NET delegate to Objective-C event selector.
        /// </summary>
        [ObjectiveCClass]
        public class NSThreadLauncher : NSObject
        {
            private readonly NSThreadRunner runner;

            /// <summary>
            /// Initializes a new instance of the <see cref="NSThreadLauncher"/> class.
            /// </summary>
            public NSThreadLauncher()
            {
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="NSThreadLauncher"/> class.
            /// </summary>
            /// <param name="nativePointer">The native pointer.</param>
            public NSThreadLauncher(IntPtr nativePointer) : base(nativePointer)
            {
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="NSThreadLauncher"/> class.
            /// </summary>
            /// <param name="runner">The runner.</param>
            public NSThreadLauncher(NSThreadRunner runner)
            {
                this.runner = runner;
            }

            /// <summary>
            /// Callback method to dispatch message.
            /// </summary>
            [ObjectiveCMessage("launch:")]
            public void Launch(Id anArgument)
            {
                if (this.runner != null)
                {
                    this.runner(anArgument);
                }
                this.Autorelease();
            }
        }
    }
}