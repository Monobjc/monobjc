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
using Monobjc.Foundation;

namespace Monobjc.AppKit
{
    public partial class NSSavePanel
    {
        /// <summary>
        /// <para>Presents a Save panel as a sheet with a specified path and, optionally, a specified file in that path. (Deprecated in Mac OS X v10.6. Use beginSheetModalForWindow:completionHandler: instead.)</para>
        /// <para>Original signature is '- (void)beginSheetForDirectory:(NSString *)path file:(NSString *)name modalForWindow:(NSWindow *)docWindow modalDelegate:(id)modalDelegate didEndSelector:(SEL)didEndSelector contextInfo:(void *)contextInfo'</para>
        /// <para>Available in Mac OS X v10.0 and later.</para>
        /// </summary>
        /// <param name="path">Directory whose files the panel displays. When nil, the directory is the same directory used in the previous invocation of the panel; this is probably the best choice for most situations.</param>
        /// <param name="name">Specifies a particular file in path that is selected when the Save panel is presented to a user. When nil, no file is initially selected.</param>
        /// <param name="docWindow">If not nil, the Save panel slides down as a sheet running as a document modal window in docWindow. If nil, the behavior defaults to a standalone modal window.</param>
        /// <param name="modalDelegate">This is not the same as a delegate assigned to the panel. This delegate is temporary and the relationship only lasts until the panel is dismissed. The NSSavePanel object does not retain the modal delegate.</param>
        /// <param name="contextInfo">Context information passed to modalDelegate in the didEndSelector message.</param>
        [Obsolete("Deprecated in Mac OS X v10.6. Use beginSheetModalForWindow:completionHandler: instead.")]
        public void BeginSheetForDirectoryFileModalForWindowModalDelegateDidEndSelectorContextInfo(NSString path, NSString name, NSWindow docWindow, SheetDidEndReturnCodeContextInfoEventHandler<NSSavePanel> modalDelegate, IntPtr contextInfo)
        {
            NSSavePanelSheetDispatcher dispatcher = new NSSavePanelSheetDispatcher(modalDelegate);
            ObjectiveCRuntime.SendMessage(this, "beginSheetForDirectory:file:modalForWindow:modalDelegate:didEndSelector:contextInfo:", path, name, docWindow, dispatcher, ObjectiveCRuntime.Selector("panelDidEnd:returnCode:contextInfo:"), contextInfo);
        }

        /// <summary>
        /// Dispatcher to connect .NET delegate to Objective-C event selector.
        /// </summary>
        [ObjectiveCClass]
        public class NSSavePanelSheetDispatcher : NSObject
        {
            private readonly SheetDidEndReturnCodeContextInfoEventHandler<NSSavePanel> modalDelegate;

            /// <summary>
            /// Initializes a new instance of the <see cref="NSSavePanelSheetDispatcher"/> class.
            /// </summary>
            public NSSavePanelSheetDispatcher()
            {
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="NSSavePanelSheetDispatcher"/> class.
            /// </summary>
            /// <param name="nativePointer">The native pointer.</param>
            public NSSavePanelSheetDispatcher(IntPtr nativePointer) : base(nativePointer)
            {
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="NSSavePanelSheetDispatcher"/> class.
            /// </summary>
            /// <param name="modalDelegate">The modal delegate.</param>
            public NSSavePanelSheetDispatcher(SheetDidEndReturnCodeContextInfoEventHandler<NSSavePanel> modalDelegate)
            {
                this.modalDelegate = modalDelegate;
            }

            /// <summary>
            /// Callback method to dispatch message.
            /// </summary>
            [ObjectiveCMessage("panelDidEnd:returnCode:contextInfo:")]
            public void PanelDidEndReturnCodeContextInfo(NSSavePanel sheet, NSInteger returnCode, IntPtr contextInfo)
            {
                this.modalDelegate(sheet, returnCode, contextInfo);
                this.Autorelease();
            }
        }
    }
}