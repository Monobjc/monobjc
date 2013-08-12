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
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

namespace Monobjc.Foundation
{
    public partial class NSThread
    {
        /// <summary>
        /// Makes the application multi-threaded.
        /// </summary>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static void MakeMultiThreaded()
        {
            // Note: This code dates back to the old days of OS X where Cocoa applications were single-threaded at startup.
            // Now, all the applications are multi-threaded when launched.
            if (!IsMultiThreaded)
            {
                Logger.Debug("NSThread", "Making current application multithreaded");

                // Setup a signal to block until secondary thread is running
                ManualResetEvent mre = new ManualResetEvent(false);

                // The code that will be executed in the secondary thread
                Action runner = delegate
                {
                    // Signal event to unblock caller
                    Logger.Debug("NSThread", "Signalling that multithreading is activated");
                    mre.Set();
                };

                // Create the secondary thread
                StartNewThread(runner);

                // Block until secondary thread is running
                mre.WaitOne();

                Logger.Debug("NSThread", "Current application is NOW multithreaded");
            }
        }

        /// <summary>
        /// Asynchronously invokes the action on a new thread and returns immediately.
        /// </summary>
        /// <param name="action">Action to invoke.</param>
        public static void StartNewThread(Action action)
        {
            NSThreadLauncher launcher = new NSThreadLauncher(action);
            launcher.PerformSelectorInBackgroundWithObject(NSThreadLauncher.LaunchSelector, null);
        }

        /// <summary>
        /// Asynchronously invokes the action on a new thread and returns immediately.
        /// </summary>
        /// <param name="actionWithId">The delegate that will be executed on the new thread.</param>
        /// <param name="arg">The single argument passed to the target. May be nil.</param>
        public static void StartNewThread(Action<Id> actionWithId, Id arg)
        {
            NSThreadLauncher launcher = new NSThreadLauncher(actionWithId);
            launcher.PerformSelectorInBackgroundWithObject(NSThreadLauncher.LaunchSelector, arg);
        }

        /// <summary>
        /// Asynchronously invokes the action on a new thread and returns immediately.
        /// </summary>
        /// <param name="actionWithState">The delegate that will be executed on a new thread.</param>
        /// <param name="arg">The single argument passed to the target. May be nil.</param>
        public static void StartNewThread(Action<Object> actionWithState, Object state)
        {
            NSValue arg = WrapState(state);
            NSThreadLauncher launcher = new NSThreadLauncher(actionWithState);
            launcher.PerformSelectorInBackgroundWithObject(NSThreadLauncher.LaunchSelector, arg);
        }

        /// <summary>
        /// Queues the action to the thread and returns immediately.
        /// </summary>
        /// <param name="action">Action to invoke.</param>
        public void BeginInvoke(Action action)
        {
            NSThreadLauncher launcher = new NSThreadLauncher(action);
            launcher.PerformSelectorOnThreadWithObjectWaitUntilDone(NSThreadLauncher.LaunchSelector, this, null, false);
        }

        /// <summary>
        /// Invokes the action on the thread and blocks until it completes.
        /// </summary>
        /// <param name="action">Action to invoke.</param>
        public void Invoke(Action action)
        {
            NSThreadLauncher launcher = new NSThreadLauncher(action);
            launcher.PerformSelectorOnThreadWithObjectWaitUntilDone(NSThreadLauncher.LaunchSelector, this, null, true);
        }

        /// <summary>
        /// Queues the action to the thread and returns immediately.
        /// </summary>
        /// <param name="actionWithId">The delegate that will be executed on the thread.</param>
        /// <param name="arg">The single argument passed to the target. May be nil.</param>
        public void BeginInvoke(Action<Id> actionWithId, Id arg)
        {
            NSThreadLauncher launcher = new NSThreadLauncher(actionWithId);
            launcher.PerformSelectorOnThreadWithObjectWaitUntilDone(NSThreadLauncher.LaunchSelector, this, arg, false);
        }

        /// <summary>
        /// Invokes the action on the thread and blocks until it completes.
        /// </summary>
        /// <param name="actionWithId">The delegate that will be executed on the thread.</param>
        /// <param name="arg">The single argument passed to the target. May be nil.</param>
        public void Invoke(Action<Id> actionWithId, Id arg)
        {
            NSThreadLauncher launcher = new NSThreadLauncher(actionWithId);
            launcher.PerformSelectorOnThreadWithObjectWaitUntilDone(NSThreadLauncher.LaunchSelector, this, arg, true);
        }

        /// <summary>
        /// Queues the action to the thread and returns immediately.
        /// </summary>
        /// <param name="actionWithState">The delegate that will be executed on the thread.</param>
        /// <param name="state">The single argument passed to the target. May be nil.</param>
        public void BeginInvoke(Action<Object> actionWithState, Object state)
        {
            NSValue arg = WrapState(state);
            NSThreadLauncher launcher = new NSThreadLauncher(actionWithState);
            launcher.PerformSelectorOnThreadWithObjectWaitUntilDone(NSThreadLauncher.LaunchSelector, this, arg, false);
        }

        /// <summary>
        /// Invokes the action on the thread and blocks until it completes.
        /// </summary>
        /// <param name="actionWithState">The delegate that will be executed on the thread.</param>
        /// <param name="state">The single argument passed to the target. May be nil.</param>
        public void Invoke(Action<Object> actionWithState, Object state)
        {
            NSValue arg = WrapState(state);
            NSThreadLauncher launcher = new NSThreadLauncher(actionWithState);
            launcher.PerformSelectorOnThreadWithObjectWaitUntilDone(NSThreadLauncher.LaunchSelector, this, arg, true);
        }

        /// <summary>
        /// Wraps a <see cref="System.GCHandle"/> for an object into a <see cref="Monobjc.Foundation.NSValue"/> instance.
        /// </summary>
        private static NSValue WrapState(Object obj)
        {
            NSValue arg = null;
            if (obj != null)
            {
                GCHandle handle = GCHandle.Alloc(obj);
                IntPtr handleValue = GCHandle.ToIntPtr(handle);
                arg = NSValue.ValueWithPointer(handleValue);
            }
            return arg;
        }

        /// <summary>
        /// Dispatcher to connect .NET delegate to Objective-C event selector.
        /// </summary>
        [ObjectiveCClass]
        public class NSThreadLauncher : NSObject
        {
            public const String SelectorName = "launch:";
            public static IntPtr LaunchSelector = ObjectiveCRuntime.Selector(SelectorName);
            private readonly Action<Object> actionWithState;
            private readonly Action<Id> actionWithId;
            private readonly Action action;

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
            /// <param name="action">The action.</param>
            public NSThreadLauncher(Action action)
            {
                this.action = action;
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="NSThreadLauncher"/> class.
            /// </summary>
            /// <param name="actionWithState">The action to execute which accepts an object parameter.</param>
            public NSThreadLauncher(Action<Object> actionWithState)
            {
                this.actionWithState = actionWithState;
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="NSThreadLauncher"/> class.
            /// </summary>
            /// <param name="actionWithId">The action to execute which accepts an object parameter.</param>
            public NSThreadLauncher(Action<Id> actionWithId)
            {
                this.actionWithId = actionWithId;
            }

            /// <summary>
            /// Callback method to dispatch message.
            /// </summary>
            [ObjectiveCMessage(NSThreadLauncher.SelectorName)]
            public void Launch(Id anArgument)
            {
                if (this.actionWithState != null)
                {
                    var val = anArgument.SafeCastTo<NSValue>();
                    if (val != null)
                    {
                        GCHandle stateHandle = GCHandle.FromIntPtr(val.PointerValue);
                        Object state = stateHandle.Target;

                        try
                        {
                            this.actionWithState(state);
                        }
                        finally
                        {
                            stateHandle.Free();
                        }
                    }
                    else
                    {
                        this.actionWithState(null);
                    }
                }
                else if (this.actionWithId != null)
                {
                    this.actionWithId(anArgument);
                }
                else if (this.action != null)
                {
                    this.action();
                }
                this.Autorelease();
            }
        }
    }

    /// <summary>
    /// SynchronizationContext for posting operations to an 
    /// </summary>
    public class NSThreadSynchronizationContext : SynchronizationContext
    {
        private readonly NSThread thread;

        /// <summary>
        /// Initializes a new instance of the <see cref="Monobjc.Foundation.NSThreadSynchronizationContext"/> class.
        /// </summary>
        public NSThreadSynchronizationContext() : this(NSThread.CurrentThread)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Monobjc.Foundation.NSThread+NSThreadSynchronizationContext"/> class.
        /// </summary>
        /// <param name="thread">The underlying thread.</param>
        public NSThreadSynchronizationContext(NSThread thread)
        {
            // Note: The thread is not retained
            this.thread = thread;
        }

        /// <summary>
        /// Creates the copy.
        /// </summary>
        /// <returns>The copy.</returns>
        public override SynchronizationContext CreateCopy()
        {
            return new NSThreadSynchronizationContext(this.thread);
        }

        /// <summary>
        /// Post an operation to the thread asynchronously.
        /// </summary>
        /// <param name="d">Delegate to invoke</param>
        /// <param name="state">State object</param>
        public override void Post(SendOrPostCallback d, Object state)
        {
            this.thread.BeginInvoke((s) => d(s), state);
        }

        /// <summary>
        /// Send an operation to the thread and block until complete.
        /// </summary>
        /// <param name="d">Delegate to invoke</param>
        /// <param name="state">State object</param>
        public override void Send(SendOrPostCallback d, Object state)
        {
            this.thread.Invoke((s) => d(s), state);
        }
    }
}