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

using Monobjc;
using Monobjc.Foundation;
using Monobjc.CoreData;
using Monobjc.QuartzCore;
using Monobjc.ApplicationServices;
using System;
using System.CodeDom.Compiler;
using System.Globalization;
using System.Runtime.InteropServices;

namespace Monobjc.AppKit
{
    public partial class NSCollectionViewItem
    {
        #region ----- NSCoding -----

        /// <summary>
        /// <para>Encodes the receiver using a given archiver. (required)</para>
        /// <para>Original signature is '- (void)encodeWithCoder:(NSCoder *)encoder'</para>
        /// <para>Available in Mac OS X v10.0 and later.</para>
        /// </summary>
        /// <param name="encoder">An archiver object.</param>
        public virtual void EncodeWithCoder(NSCoder encoder)
        {
            ObjectiveCRuntime.SendMessage(this, "encodeWithCoder:", encoder);
        }

        /// <summary>
        /// <para>Returns an object initialized from data in a given unarchiver. (required)</para>
        /// <para>Original signature is '- (id)initWithCoder:(NSCoder *)decoder'</para>
        /// <para>Available in Mac OS X v10.0 and later.</para>
        /// </summary>
        /// <param name="decoder">An unarchiver object.</param>
        /// <returns>self, initialized using the data in decoder.</returns>
        public virtual Id InitWithCoder(NSCoder decoder)
        {
            return ObjectiveCRuntime.SendMessage<Id>(this, "initWithCoder:", decoder);
        }

        #endregion

        #region ----- NSEditorRegistration -----

        /// <summary>
        /// <para>This message should be sent to the receiver when editor has uncommitted changes that can affect the receiver.</para>
        /// <para>Original signature is '- (void)objectDidBeginEditing:(id)editor'</para>
        /// <para>Available in Mac OS X v10.3 and later.</para>
        /// </summary>
        /// <param name="editor">MISSING</param>
        public virtual void ObjectDidBeginEditing(Id editor)
        {
            ObjectiveCRuntime.SendMessage(this, "objectDidBeginEditing:", editor);
        }

        /// <summary>
        /// <para>This message should be sent to the receiver when editor has finished editing a property belonging to the receiver.</para>
        /// <para>Original signature is '- (void)objectDidEndEditing:(id)editor'</para>
        /// <para>Available in Mac OS X v10.3 and later.</para>
        /// </summary>
        /// <param name="editor">MISSING</param>
        public virtual void ObjectDidEndEditing(Id editor)
        {
            ObjectiveCRuntime.SendMessage(this, "objectDidEndEditing:", editor);
        }

        #endregion

        #region ----- NSEditor -----

        /// <summary>
        /// <para>Attempt to commit any currently edited results of the receiver.</para>
        /// <para>Original signature is '- (void)commitEditingWithDelegate:(id)delegate didCommitSelector:(SEL)didCommitSelector contextInfo:(void *)contextInfo'</para>
        /// <para>Available in Mac OS X v10.4 and later.</para>
        /// </summary>
        /// <param name="delegate">MISSING</param>
        /// <param name="didCommitSelector">MISSING</param>
        /// <param name="contextInfo">MISSING</param>
        public virtual void CommitEditingWithDelegateDidCommitSelectorContextInfo(Id @delegate, IntPtr didCommitSelector, IntPtr contextInfo)
        {
            ObjectiveCRuntime.SendMessage(this, "commitEditingWithDelegate:didCommitSelector:contextInfo:", @delegate, didCommitSelector, contextInfo);
        }

        /// <summary>
        /// <para>Causes the receiver to discard any changes, restoring the previous values.</para>
        /// <para>Original signature is '- (void)discardEditing'</para>
        /// <para>Available in Mac OS X v10.3 and later.</para>
        /// </summary>
        public virtual void DiscardEditing()
        {
            ObjectiveCRuntime.SendMessage(this, "discardEditing");
        }

        /// <summary>
        /// <para>Returns whether the receiver was able to commit any pending edits.</para>
        /// <para>Original signature is '- (BOOL)commitEditing'</para>
        /// <para>Available in Mac OS X v10.3 and later.</para>
        /// </summary>
        public virtual bool CommitEditing
        {
            get { return ObjectiveCRuntime.SendMessage<bool>(this, "commitEditing"); }
        }

        #endregion

    }
}
