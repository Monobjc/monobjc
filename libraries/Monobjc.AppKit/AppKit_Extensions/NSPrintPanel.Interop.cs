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

namespace Monobjc.AppKit
{
    public partial class NSPrintPanel
    {
        /// <summary>
        /// <para>Displays a Print panel sheet and runs it modally for the specified window.</para>
        /// <para>Original signature is '- (void)beginSheetWithPrintInfo:(NSPrintInfo *)printInfo modalForWindow:(NSWindow *)docWindow delegate:(id)modalDelegate didEndSelector:(SEL)didEndSelector contextInfo:(void *)contextInfo'</para>
        /// <para>Available in Mac OS X v10.0 and later.</para>
        /// </summary>
        /// <param name="printInfo">The printing information for the current job.</param>
        /// <param name="docWindow">The window on which to display the sheet.</param>
        /// <param name="modalDelegate">A modal delegate object assigned to handle the closing of the Print panel sheet.</param>
        /// <param name="contextInfo">A pointer to context data the didEndSelector method needs to process the sheet. This data is user-defined and may be NULL.</param>
        public void BeginSheetWithPrintInfoModalForWindowDelegateDidEndSelectorContextInfo(NSPrintInfo printInfo, NSWindow docWindow, SheetDidEndReturnCodeContextInfoEventHandler<NSPrintPanel> modalDelegate, IntPtr contextInfo)
        {
            NSPrintPanelSheetDispatcher dispatcher = new NSPrintPanelSheetDispatcher(modalDelegate);
            ObjectiveCRuntime.SendMessage(this, "beginSheetWithPrintInfo:modalForWindow:delegate:didEndSelector:contextInfo:", printInfo, docWindow, dispatcher, ObjectiveCRuntime.Selector("printPanelDidEnd:returnCode:contextInfo:"), contextInfo);
        }

        /// <summary>
        /// Dispatcher to connect .NET delegate to Objective-C event selector.
        /// </summary>
        [ObjectiveCClass]
        public class NSPrintPanelSheetDispatcher : NSObject
        {
            private readonly SheetDidEndReturnCodeContextInfoEventHandler<NSPrintPanel> modalDelegate;

            /// <summary>
            /// Initializes a new instance of the <see cref="NSPrintPanelSheetDispatcher"/> class.
            /// </summary>
            public NSPrintPanelSheetDispatcher()
            {
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="NSPrintPanelSheetDispatcher"/> class.
            /// </summary>
            /// <param name="nativePointer">The native pointer.</param>
            public NSPrintPanelSheetDispatcher(IntPtr nativePointer) : base(nativePointer)
            {
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="NSPrintPanelSheetDispatcher"/> class.
            /// </summary>
            /// <param name="modalDelegate">The modal delegate.</param>
            public NSPrintPanelSheetDispatcher(SheetDidEndReturnCodeContextInfoEventHandler<NSPrintPanel> modalDelegate)
            {
                this.modalDelegate = modalDelegate;
            }

            /// <summary>
            /// Callback method to dispatch message.
            /// </summary>
            [ObjectiveCMessage("printPanelDidEnd:returnCode:contextInfo:")]
            public void PrintPanelDidEndReturnCodeContextInfo(NSPrintPanel printPanel, NSInteger returnCode, IntPtr contextInfo)
            {
                this.modalDelegate(printPanel, returnCode, contextInfo);
                this.Autorelease();
            }
        }
    }
}