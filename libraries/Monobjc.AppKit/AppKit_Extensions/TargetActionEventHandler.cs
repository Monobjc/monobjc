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
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Monobjc.Foundation;

namespace Monobjc.AppKit
{
    /// <summary>
    /// Delegate to subscribe to <see cref="IActionProvider.ActionEvent"/> events.
    /// </summary>
    /// <param name="sender">The sender of the event</param>
    public delegate void ActionEventHandler(Id sender);

    /// <summary>
    /// Delegate to subscribe to <see cref="IDoubleActionProvider.DoubleActionEvent"/> events.
    /// </summary>
    /// <param name="sender">The sender of the event</param>
    public delegate void DoubleActionEventHandler(Id sender);

    /// <summary>
    /// Interface implemented by class that provides an Action/Target mecanism.
    /// </summary>
    public interface IActionProvider
    {
        /// <summary>
        /// Returns the target object of the receiver.
        /// </summary>
        Id Target { set; }

        /// <summary>
        /// Returns the default action-message selector associated with the control.
        /// </summary>
        IntPtr Action { set; }

        /// <summary>
        /// Occurs when an action is triggered.
        /// </summary>
        event ActionEventHandler ActionEvent;
    }

    /// <summary>
    /// Interface implemented by class that provides an Action/Target mecanism.
    /// </summary>
    public interface IDoubleActionProvider : IActionProvider
    {
        /// <summary>
        /// Returns the default action-message selector associated with the control.
        /// </summary>
        IntPtr DoubleAction { set; }

        /// <summary>
        /// Occurs when a double-action is triggered.
        /// </summary>
        event DoubleActionEventHandler DoubleActionEvent;
    }

    /// <summary>
    /// Event handler that is exposed to the Objective-C runtime and relays target/action to listeners.
    /// </summary>
    [ObjectiveCClass]
    public class ActionDispatcher : NSObject
    {
        /// <summary>
        /// Static field for a quick access to the ActionDispatcher class.
        /// </summary>
        public static readonly Class ActionDispatcherClass = Class.Get(typeof(ActionDispatcher));

        private static readonly IDictionary<IActionProvider, ActionDispatcher> map = new Dictionary<IActionProvider, ActionDispatcher>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ActionDispatcher"/> class.
        /// </summary>
        public ActionDispatcher() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ActionDispatcher"/> class.
        /// </summary>
        /// <param name="nativePointer">The native pointer.</param>
        public ActionDispatcher(IntPtr nativePointer)
            : base(nativePointer) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ActionDispatcher"/> class.
        /// </summary>
        /// <param name="provider">The provider.</param>
        protected ActionDispatcher(IActionProvider provider)
        {
            provider.Target = this;
            provider.Action = ObjectiveCRuntime.Selector("doAction:");
        }

        /// <summary>
        /// Does the action.
        /// </summary>
        /// <param name="sender">The sender.</param>
        [ObjectiveCMessage("doAction:")]
        public void DoAction(Id sender)
        {
            if (this.ActionEvent != null)
            {
                this.ActionEvent(sender);
            }
        }

        /// <summary>
        /// Occurs when an action is triggered.
        /// </summary>
        public event ActionEventHandler ActionEvent;

        /// <summary>
        /// Adds an action handler to the given <see cref="IActionProvider"/> instance.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <param name="handler">The handler.</param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static void AddHandler(IActionProvider provider, ActionEventHandler handler)
        {
            ActionDispatcher dispatcher;
            if (map.ContainsKey(provider))
            {
                dispatcher = map[provider];
            }
            else
            {
                dispatcher = new ActionDispatcher(provider);
                map.Add(provider, dispatcher);
            }
            dispatcher.ActionEvent += handler;
        }

        /// <summary>
        /// Removes an action handler from the given <see cref="IActionProvider"/> instance.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <param name="handler">The handler.</param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static void RemoveHandler(IActionProvider provider, ActionEventHandler handler)
        {
            if (!map.ContainsKey(provider))
            {
                return;
            }

            ActionDispatcher dispatcher = map[provider];
            dispatcher.ActionEvent -= handler;
            if (dispatcher.ActionEvent.GetInvocationList().Length == 0)
            {
                dispatcher.Release();
                map.Remove(provider);
            }
        }
    }

    /// <summary>
    /// Event handler that is exposed to the Objective-C runtime and relays target/action to listeners.
    /// </summary>
    [ObjectiveCClass]
    public class DoubleActionDispatcher : ActionDispatcher
    {
        /// <summary>
        /// Static field for a quick access to the DoubleActionDispatcher class.
        /// </summary>
        public static readonly Class DoubleActionDispatcherClass = Class.Get(typeof(DoubleActionDispatcher));

        private static readonly IDictionary<IActionProvider, DoubleActionDispatcher> map = new Dictionary<IActionProvider, DoubleActionDispatcher>();

        /// <summary>
        /// Initializes a new instance of the <see cref="DoubleActionDispatcher"/> class.
        /// </summary>
        public DoubleActionDispatcher() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DoubleActionDispatcher"/> class.
        /// </summary>
        /// <param name="nativePointer">The native pointer.</param>
        public DoubleActionDispatcher(IntPtr nativePointer)
            : base(nativePointer) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ActionDispatcher"/> class.
        /// </summary>
        /// <param name="provider">The provider.</param>
        protected DoubleActionDispatcher(IDoubleActionProvider provider)
            : base(provider)
        {
            provider.DoubleAction = ObjectiveCRuntime.Selector("doDoubleAction:");
        }

        /// <summary>
        /// Does the double-action.
        /// </summary>
        /// <param name="sender">The sender.</param>
        [ObjectiveCMessage("doDoubleAction:")]
        public void DoDoubleAction(Id sender)
        {
            if (this.DoubleActionEvent != null)
            {
                this.DoubleActionEvent(sender);
            }
        }

        /// <summary>
        /// Occurs when an action is triggered.
        /// </summary>
        public event DoubleActionEventHandler DoubleActionEvent;

        /// <summary>
        /// Adds an action handler to the given <see cref="IActionProvider"/> instance.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <param name="handler">The handler.</param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static void AddHandler(IDoubleActionProvider provider, DoubleActionEventHandler handler)
        {
            DoubleActionDispatcher dispatcher;
            if (map.ContainsKey(provider))
            {
                dispatcher = map[provider];
            }
            else
            {
                dispatcher = new DoubleActionDispatcher(provider);
                map.Add(provider, dispatcher);
            }
            dispatcher.DoubleActionEvent += handler;
        }

        /// <summary>
        /// Removes an action handler from the given <see cref="IActionProvider"/> instance.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <param name="handler">The handler.</param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static void RemoveHandler(IDoubleActionProvider provider, DoubleActionEventHandler handler)
        {
            if (!map.ContainsKey(provider))
            {
                return;
            }

            DoubleActionDispatcher dispatcher = map[provider];
            dispatcher.DoubleActionEvent -= handler;
            if (dispatcher.DoubleActionEvent.GetInvocationList().Length == 0)
            {
                dispatcher.Release();
                map.Remove(provider);
            }
        }
    }
}