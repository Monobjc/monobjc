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
using Monobjc.Foundation;

namespace Monobjc.AppKit
{
    public partial class NSAlert
    {
        /// <summary>
        /// <para>Runs the receiver modally as an alert sheet attached to a specified window.</para>
        /// <para>Original signature is '- (void)beginSheetModalForWindow:(NSWindow *)window modalDelegate:(id)modalDelegate didEndSelector:(SEL)alertDidEndSelector contextInfo:(void *)contextInfo'</para>
        /// <para>Available in Mac OS X v10.3 and later.</para>
        /// </summary>
        /// <param name="window">The parent window for the sheet.</param>
        /// <param name="modalDelegate">The delegate for the modal-dialog session.</param>
        /// <param name="contextInfo">Contextual data passed to modalDelegate in didEndSelector message.</param>
        public void BeginSheetModalForWindowModalDelegateDidEndSelectorContextInfo(NSWindow window, SheetDidEndReturnCodeContextInfoEventHandler<NSAlert> modalDelegate, IntPtr contextInfo)
        {
            NSAlertSheetDispatcher sheetDispatcher = new NSAlertSheetDispatcher(modalDelegate);
            ObjectiveCRuntime.SendMessage(this, "beginSheetModalForWindow:modalDelegate:didEndSelector:contextInfo:", window, sheetDispatcher, ObjectiveCRuntime.Selector("alertDidEnd:returnCode:contextInfo:"), contextInfo);
        }

        /// <summary>
        /// Dispatcher to connect .NET delegate to Objective-C event selector.
        /// </summary>
        [ObjectiveCClass]
        public class NSAlertSheetDispatcher : NSObject
        {
            private readonly SheetDidEndReturnCodeContextInfoEventHandler<NSAlert> modalDelegate;

            /// <summary>
            ///   Initializes a new instance of the <see cref = "NSAlertSheetDispatcher" /> class.
            /// </summary>
            public NSAlertSheetDispatcher() {}

            /// <summary>
            ///   Initializes a new instance of the <see cref = "NSAlertSheetDispatcher" /> class.
            /// </summary>
            /// <param name = "nativePointer">The native pointer.</param>
            public NSAlertSheetDispatcher(IntPtr nativePointer) : base(nativePointer) {}

            /// <summary>
            /// Initializes a new instance of the <see cref="NSAlertSheetDispatcher"/> class.
            /// </summary>
            /// <param name="modalDelegate">The modal delegate.</param>
            public NSAlertSheetDispatcher(SheetDidEndReturnCodeContextInfoEventHandler<NSAlert> modalDelegate)
            {
                this.modalDelegate = modalDelegate;
            }

            /// <summary>
            ///   Callback method to dispatch message.
            /// </summary>
            [ObjectiveCMessage("alertDidEnd:returnCode:contextInfo:")]
            public void SheetDidEndReturnCodeContextInfo(NSAlert alert, NSInteger returnCode, IntPtr contextInfo)
            {
                this.modalDelegate(alert, returnCode, contextInfo);
                this.Autorelease();
            }
        }
    }
}