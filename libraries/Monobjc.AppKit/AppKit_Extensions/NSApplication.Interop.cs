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
    public partial class NSApplication
    {
        /// <summary>
        ///   <para>Returns the NSApplication instance (the global variable NSApp), creating it if it doesn�t exist yet.</para>
        ///   <para>Original signature is '+ (NSApplication *)sharedApplication'</para>
        ///   <para>Available in Mac OS X v10.0 and later.</para>
        /// </summary>
        public static NSApplication NSApp
        {
            get { return SharedApplication; }
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return "NSApplication";
        }

        /// <summary>
        ///   <para>Starts a document modal session.</para>
        ///   <para>Original signature is '- (void)beginSheet:(NSWindow *)sheet modalForWindow:(NSWindow *)docWindow modalDelegate:(id)modalDelegate didEndSelector:(SEL)didEndSelector contextInfo:(void *)contextInfo'</para>
        ///   <para>Available in Mac OS X v10.0 and later.</para>
        /// </summary>
        /// <param name = "sheet">The window object representing the sheet you want to display.</param>
        /// <param name = "docWindow">The window object to which you want to attach the sheet.</param>
        /// <param name = "modalDelegate">The delegate object that defines your didEndSelector method. If nil, the method in didEndSelector is not called.</param>
        /// <param name = "contextInfo">A pointer to the context info you want passed to the didEndSelector method when the sheet�s modal session ends.</param>
        public void BeginSheetModalForWindowModalDelegateDidEndSelectorContextInfo(NSWindow sheet, NSWindow docWindow, SheetDidEndReturnCodeContextInfoEventHandler<NSWindow> modalDelegate, IntPtr contextInfo)
        {
            NSApplicationSheetDispatcher sheetDispatcher = new NSApplicationSheetDispatcher(modalDelegate);
            ObjectiveCRuntime.SendMessage(this, "beginSheet:modalForWindow:modalDelegate:didEndSelector:contextInfo:", sheet, docWindow, sheetDispatcher, ObjectiveCRuntime.Selector("sheetDidEnd:returnCode:contextInfo:"), contextInfo);
        }

        /// <summary>
        ///   Dispatcher to connect .NET delegate to Objective-C event selector.
        /// </summary>
        [ObjectiveCClass]
        public class NSApplicationSheetDispatcher : NSObject
        {
            private readonly SheetDidEndReturnCodeContextInfoEventHandler<NSWindow> modalDelegate;

            /// <summary>
            ///   Initializes a new instance of the <see cref = "NSApplicationSheetDispatcher" /> class.
            /// </summary>
            public NSApplicationSheetDispatcher() {}

            /// <summary>
            ///   Initializes a new instance of the <see cref = "NSApplicationSheetDispatcher" /> class.
            /// </summary>
            /// <param name = "nativePointer">The native pointer.</param>
            public NSApplicationSheetDispatcher(IntPtr nativePointer) : base(nativePointer) {}

            /// <summary>
            /// Initializes a new instance of the <see cref="NSApplicationSheetDispatcher"/> class.
            /// </summary>
            /// <param name="modalDelegate">The modal delegate.</param>
            public NSApplicationSheetDispatcher(SheetDidEndReturnCodeContextInfoEventHandler<NSWindow> modalDelegate)
            {
                this.modalDelegate = modalDelegate;
            }

            /// <summary>
            ///   Callback method to dispatch message.
            /// </summary>
            [ObjectiveCMessage("sheetDidEnd:returnCode:contextInfo:")]
            public void SheetDidEndReturnCodeContextInfo(NSWindow sheet, NSInteger returnCode, IntPtr contextInfo)
            {
                this.modalDelegate(sheet, returnCode, contextInfo);
                this.Autorelease();
            }
        }
    }
}