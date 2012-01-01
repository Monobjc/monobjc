//
// This file is part of Monobjc, a .NET/Objective-C bridge
// Copyright (C) 2007-2012 - Laurent Etiemble
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
    public partial class NSOpenPanel
    {
        public void BeginSheetForDirectoryFileModalForWindowModalDelegateDidEndSelectorContextInfo(NSString path, NSString name, NSWindow docWindow, SheetDidEndReturnCodeContextInfoEventHandler<NSOpenPanel> modelessDelegate, IntPtr contextInfo)
        {
            NSOpenPanelSheetDispatcher dispatcher = new NSOpenPanelSheetDispatcher(modelessDelegate);
            ObjectiveCRuntime.SendMessage(this, "beginSheetForDirectory:file:modalForWindow:modalDelegate:didEndSelector:contextInfo:", path, name, docWindow, dispatcher, ObjectiveCRuntime.Selector("panelDidEnd:returnCode:contextInfo:"), contextInfo);
        }

        /// <summary>
        /// <para>Presents a modeless Open panel. (Deprecated in Mac OS X v10.6. Use beginWithCompletionHandler: instead. You can set absoluteDirectoryPath using setDirectoryURL:, and you can set fileTypes using setAllowedFileTypes:.)</para>
        /// <para>Original signature is '- (void)beginForDirectory:(NSString *)absoluteDirectoryPath file:(NSString *)filename types:(NSArray *)fileTypes modelessDelegate:(id)modelessDelegate didEndSelector:(SEL)didEndSelector contextInfo:(void *)contextInfo'</para>
        /// <para>Available in Mac OS X v10.3 and later.</para>
        /// </summary>
        /// <param name="absoluteDirectoryPath">The directory whose files the panel displays. When nil, the directory is the same directory used in the previous invocation of the panel; this is probably the best choice for most situations.</param>
        /// <param name="filename">Specifies a particular file in absoluteDirectoryPath that is selected when the Open panel is presented to the user. When nil, no file is initially selected.</param>
        /// <param name="fileTypes">An array of file extensions and/or HFS file types. Specifies the files the panel allows the user to select. nil makes all files in absoluteDirectoryPath selectable by the user. An array of types passed in here will override one set using setAllowedFileTypes:.</param>
        /// <param name="modelessDelegate">This is not the same as a delegate assigned to the panel. This delegate is temporary and the relationship only lasts until the panel is dismissed.</param>
        /// <param name="contextInfo">Any context information passed to modelessDelegate in the didEndSelector message.</param>
        [Obsolete("Deprecated in Mac OS X v10.6. Use beginWithCompletionHandler: instead. You can set absoluteDirectoryPath using setDirectoryURL:, and you can set fileTypes using setAllowedFileTypes:.")]
        public void BeginForDirectoryFileTypesModelessDelegateDidEndSelectorContextInfo(NSString absoluteDirectoryPath, NSString filename, NSArray fileTypes, SheetDidEndReturnCodeContextInfoEventHandler<NSOpenPanel> modelessDelegate, IntPtr contextInfo)
        {
            NSOpenPanelSheetDispatcher dispatcher = new NSOpenPanelSheetDispatcher(modelessDelegate);
            ObjectiveCRuntime.SendMessage(this, "beginForDirectory:file:types:modelessDelegate:didEndSelector:contextInfo:", absoluteDirectoryPath, filename, fileTypes, dispatcher, ObjectiveCRuntime.Selector("panelDidEnd:returnCode:contextInfo:"), contextInfo);
        }

        /// <summary>
        /// <para>Presents an Open panel as a sheet with the directory specified by absoluteDirectoryPath and optionally the file specified by filename selected. (Deprecated in Mac OS X v10.6. Use beginSheetModalForWindow:completionHandler: instead. You can set absoluteDirectoryPath using setDirectoryURL:, and you can set fileTypes using setAllowedFileTypes:.)</para>
        /// <para>Original signature is '- (void)beginSheetForDirectory:(NSString *)absoluteDirectoryPath file:(NSString *)filename types:(NSArray *)fileTypes modalForWindow:(NSWindow *)docWindow modalDelegate:(id)modalDelegate didEndSelector:(SEL)didEndSelector contextInfo:(void *)contextInfo'</para>
        /// <para>Available in Mac OS X v10.0 and later.</para>
        /// </summary>
        /// <param name="absoluteDirectoryPath">The directory whose files the panel displays. When nil, the directory is the same directory used in the previous invocation of the panel; this is probably the best choice for most situations.</param>
        /// <param name="filename">Specifies a particular file in absoluteDirectoryPath that is selected when the Open panel is presented to the user. When nil, no file is initially selected.</param>
        /// <param name="fileTypes">An array of file extensions and/or HFS file types. Specifies the files the panel allows the user to select. nil makes all files in absoluteDirectoryPath selectable by the user. An array of types passed in here will override one set using setAllowedFileTypes:.</param>
        /// <param name="docWindow">The window to open the sheet on.</param>
        /// <param name="modalDelegate">This is not the same as a delegate assigned to the panel. This delegate is temporary and the relationship only lasts until the panel is dismissed..</param>
        /// <param name="contextInfo">Any context information passed to modalDelegate in the didEndSelector message.</param>
        [Obsolete("Deprecated in Mac OS X v10.6. Use beginSheetModalForWindow:completionHandler: instead. You can set absoluteDirectoryPath using setDirectoryURL:, and you can set fileTypes using setAllowedFileTypes:.")]
        public void BeginSheetForDirectoryFileTypesModalForWindowModalDelegateDidEndSelectorContextInfo(NSString absoluteDirectoryPath, NSString filename, NSArray fileTypes, NSWindow docWindow, SheetDidEndReturnCodeContextInfoEventHandler<NSOpenPanel> modalDelegate, IntPtr contextInfo)
        {
            NSOpenPanelSheetDispatcher dispatcher = new NSOpenPanelSheetDispatcher(modalDelegate);
            ObjectiveCRuntime.SendMessage(this, "beginSheetForDirectory:file:types:modalForWindow:modalDelegate:didEndSelector:contextInfo:", absoluteDirectoryPath, filename, fileTypes, docWindow, dispatcher, ObjectiveCRuntime.Selector("panelDidEnd:returnCode:contextInfo:"), contextInfo);
        }

        /// <summary>
        /// Dispatcher to connect .NET delegate to Objective-C event selector.
        /// </summary>
        [ObjectiveCClass]
        public class NSOpenPanelSheetDispatcher : NSObject
        {
            private readonly SheetDidEndReturnCodeContextInfoEventHandler<NSOpenPanel> modalDelegate;

            /// <summary>
            /// Initializes a new instance of the <see cref="NSOpenPanelSheetDispatcher"/> class.
            /// </summary>
            public NSOpenPanelSheetDispatcher()
            {
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="NSOpenPanelSheetDispatcher"/> class.
            /// </summary>
            /// <param name="nativePointer">The native pointer.</param>
            public NSOpenPanelSheetDispatcher(IntPtr nativePointer) : base(nativePointer)
            {
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="NSOpenPanelSheetDispatcher"/> class.
            /// </summary>
            /// <param name="modalDelegate">The modal delegate.</param>
            public NSOpenPanelSheetDispatcher(SheetDidEndReturnCodeContextInfoEventHandler<NSOpenPanel> modalDelegate)
            {
                this.modalDelegate = modalDelegate;
            }

            /// <summary>
            ///   Callback method to dispatch message.
            /// </summary>
            [ObjectiveCMessage("panelDidEnd:returnCode:contextInfo:")]
            public void SheetDidEndReturnCodeContextInfo(NSOpenPanel panel, NSInteger returnCode, IntPtr contextInfo)
            {
                this.modalDelegate(panel, returnCode, contextInfo);
                this.Autorelease();
            }
        }
    }
}