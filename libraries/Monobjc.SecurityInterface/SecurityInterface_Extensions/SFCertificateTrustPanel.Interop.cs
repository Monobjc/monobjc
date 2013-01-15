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
using Monobjc.AppKit;
using Monobjc.Foundation;

namespace Monobjc.SecurityInterface
{
    public partial class SFCertificateTrustPanel
    {
        /// <summary>
        /// <para>Displays one or more certificates in a modal sheet.</para>
        /// <para>Original signature is '- (void)beginSheetForWindow:(NSWindow *)docWindow modalDelegate:(id)delegate didEndSelector:(SEL)didEndSelector contextInfo:(void *)contextInfo certificates:(NSArray *)certificates showGroup:(BOOL)showGroup'</para>
        /// <para>Available in Mac OS X v10.3 and later.</para>
        /// </summary>
        /// <param name="docWindow">The parent window to which the sheet is attached.</param>

        /// <param name="modalDelegate">The delegate object in which the method specified in the didEndSelector parameter is implemented.</param>
        /// <param name="contextInfo">A pointer to data that is passed to the delegate method. You can use this data pointer for any purpose you wish.</param>
        /// <param name="certificates">The certificates to display. Pass an NSArray containing one or more objects of type SecCertificateRef in this parameter. The first certificate in the array must be the leaf certificate. The other certificates (if any) can be included in any order.</param>
        /// <param name="showGroup">Specifies whether additional certificates (other than the leaf certificate) are displayed.</param>
        public void BeginSheetForWindowModalDelegateDidEndSelectorContextInfoCertificatesShowGroup(NSWindow docWindow, SheetDidEndReturnCodeContextInfoEventHandler<SFCertificateTrustPanel> modalDelegate, IntPtr contextInfo, NSArray certificates,
                                                                                                   bool showGroup)
        {

            SFCertificateTrustPanelSheetDispatcher sheetDispatcher = new SFCertificateTrustPanelSheetDispatcher(modalDelegate);
            ObjectiveCRuntime.SendMessage(this, "beginSheetForWindow:modalDelegate:didEndSelector:contextInfo:certificates:showGroup:", docWindow, sheetDispatcher, ObjectiveCRuntime.Selector("panelDidEnd:returnCode:contextInfo:"), contextInfo, certificates,
                                          showGroup);
        }

        /// <summary>
        /// <para>Displays a modal sheet that shows the results of a certificate trust evaluation and that allows the user to edit trust settings.</para>
        /// <para>Original signature is '- (void)beginSheetForWindow:(NSWindow *)docWindow modalDelegate:(id)delegate didEndSelector:(SEL)didEndSelector contextInfo:(void *)contextInfo trust:(SecTrustRef)trust message:(NSString *)message'</para>
        /// <para>Available in Mac OS X v10.3 and later.</para>
        /// </summary>
        /// <param name="docWindow">The parent window to which the sheet is attached.</param>

        /// <param name="modalDelegate">The delegate object in which the method specified in the didEndSelector parameter is implemented.</param>
        /// <param name="contextInfo">A pointer to data that is passed to the delegate method. You can use this data pointer for any purpose you wish.</param>
        /// <param name="trust">A trust management object. Use the SecTrustCreateWithCertificates function (in Security/SecTrust.h) to create the trust management object.</param>
        /// <param name="message">A message string to display in the sheet.</param>

        public void BeginSheetForWindowModalDelegateDidEndSelectorContextInfoTrustMessage(NSWindow docWindow, SheetDidEndReturnCodeContextInfoEventHandler<SFCertificateTrustPanel> modalDelegate, IntPtr contextInfo, IntPtr trust, NSString message)
        {

            SFCertificateTrustPanelSheetDispatcher sheetDispatcher = new SFCertificateTrustPanelSheetDispatcher(modalDelegate);
            ObjectiveCRuntime.SendMessage(this, "beginSheetForWindow:modalDelegate:didEndSelector:contextInfo:trust:message:", docWindow, sheetDispatcher, ObjectiveCRuntime.Selector("panelDidEnd:returnCode:contextInfo:"), contextInfo, trust, message);
        }

        /// <summary>
        ///   Dispatcher to connect .NET delegate to Objective-C event selector.
        /// </summary>
        [ObjectiveCClass]
        public class SFCertificateTrustPanelSheetDispatcher : NSObject
        {
            private readonly SheetDidEndReturnCodeContextInfoEventHandler<SFCertificateTrustPanel> modalDelegate;

            /// <summary>
            ///   Initializes a new instance of the <see cref = "SFCertificateTrustPanelSheetDispatcher" /> class.
            /// </summary>
            public SFCertificateTrustPanelSheetDispatcher() {}

            /// <summary>
            ///   Initializes a new instance of the <see cref = "SFCertificateTrustPanelSheetDispatcher" /> class.
            /// </summary>
            /// <param name = "nativePointer">The native pointer.</param>
            public SFCertificateTrustPanelSheetDispatcher(IntPtr nativePointer)
                : base(nativePointer) {}

            /// <summary>
            ///   Initializes a new instance of the <see cref = "SFCertificateTrustPanelSheetDispatcher" /> class.
            /// </summary>
            /// <param name = "modalDelegate">The modal delegate.</param>
            public SFCertificateTrustPanelSheetDispatcher(SheetDidEndReturnCodeContextInfoEventHandler<SFCertificateTrustPanel> modalDelegate)
            {
                this.modalDelegate = modalDelegate;
            }

            /// <summary>
            ///   Callback method to dispatch message.
            /// </summary>
            [ObjectiveCMessage("panelDidEnd:returnCode:contextInfo:")]
            public void PanelDidEndReturnCodeContextInfo(SFCertificateTrustPanel sheet, NSInteger returnCode, IntPtr contextInfo)
            {
                this.modalDelegate(sheet, returnCode, contextInfo);
                this.Release();
            }
        }
    }
}