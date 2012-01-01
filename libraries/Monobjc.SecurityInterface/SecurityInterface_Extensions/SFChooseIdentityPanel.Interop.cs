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
using Monobjc.AppKit;
using Monobjc.Foundation;

namespace Monobjc.SecurityInterface
{
    public partial class SFChooseIdentityPanel
    {
        /// <summary>
        /// <para>Displays a list of identities in a modal sheet from which the user can select an identity.</para>
        /// <para>Original signature is '- (void)beginSheetForWindow:(NSWindow *)docWindow modalDelegate:(id)delegate didEndSelector:(SEL)didEndSelector contextInfo:(void *)contextInfo identities:(NSArray *)identities message:(NSString *)message'</para>
        /// <para>Available in Mac OS X v10.3 and later.</para>
        /// </summary>
        /// <param name="docWindow">The parent window to which the sheet is attached.</param>
        /// <param name="modalDelegate">The delegate object in which the method specified in the didEndSelector parameter is implemented.</param>
        /// <param name="contextInfo">A pointer to data that is passed to the delegate method. You can use this data pointer for any purpose you wish.</param>
        /// <param name="identities">An array of identity objects (objects of type SecIdentityRef). Use the SecIdentitySearchCopyNext function (in Security/SecIdentitySearch.h) to find identity objects.</param>
        /// <param name="message">A message string to display in the sheet.</param>
        public void BeginSheetForWindowModalDelegateDidEndSelectorContextInfoIdentitiesMessage(NSWindow docWindow, SheetDidEndReturnCodeContextInfoEventHandler<SFChooseIdentityPanel> modalDelegate, IntPtr contextInfo, NSArray identities, NSString message)
        {
            SFChooseIdentityPanelSheetDispatcher sheetDispatcher = new SFChooseIdentityPanelSheetDispatcher(modalDelegate);
            ObjectiveCRuntime.SendMessage(this, "beginSheetForWindow:modalDelegate:didEndSelector:contextInfo:identities:message:", docWindow, sheetDispatcher, ObjectiveCRuntime.Selector("panelDidEnd:returnCode:contextInfo:"), contextInfo, identities,
                                          message);
        }

        /// <summary>
        /// Dispatcher to connect .NET delegate to Objective-C event selector.
        /// </summary>
        [ObjectiveCClass]
        public class SFChooseIdentityPanelSheetDispatcher : NSObject
        {
            private readonly SheetDidEndReturnCodeContextInfoEventHandler<SFChooseIdentityPanel> modalDelegate;

            /// <summary>
            /// Initializes a new instance of the <see cref="SFChooseIdentityPanelSheetDispatcher"/> class.
            /// </summary>
            public SFChooseIdentityPanelSheetDispatcher() {}

            /// <summary>
            /// Initializes a new instance of the <see cref="SFChooseIdentityPanelSheetDispatcher"/> class.
            /// </summary>
            /// <param name="nativePointer">The native pointer.</param>
            public SFChooseIdentityPanelSheetDispatcher(IntPtr nativePointer)
                : base(nativePointer) {}

            /// <summary>
            /// Initializes a new instance of the <see cref="SFChooseIdentityPanelSheetDispatcher"/> class.
            /// </summary>
            /// <param name="modalDelegate">The modal delegate.</param>
            public SFChooseIdentityPanelSheetDispatcher(SheetDidEndReturnCodeContextInfoEventHandler<SFChooseIdentityPanel> modalDelegate)
            {
                this.modalDelegate = modalDelegate;
            }

            /// <summary>
            /// Callback method to dispatch message.
            /// </summary>
            [ObjectiveCMessage("panelDidEnd:returnCode:contextInfo:")]
            public void PanelDidEndReturnCodeContextInfo(SFChooseIdentityPanel sheet, NSInteger returnCode, IntPtr contextInfo)
            {
                this.modalDelegate(sheet, returnCode, contextInfo);
                this.Release();
            }
        }
    }
}