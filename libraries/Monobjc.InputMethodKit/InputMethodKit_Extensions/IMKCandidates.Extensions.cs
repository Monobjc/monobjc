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
using System.CodeDom.Compiler;
using System.Globalization;
using System.Runtime.InteropServices;

using Monobjc;
using Monobjc.Foundation;
using Monobjc.AppKit;

namespace Monobjc.InputMethodKit
{
#if !MACOSX_10_7
	public partial class IMKCandidates
	{
        #region ----- NSCoding -----

		/// <summary>
		/// <para>Encodes the receiver using a given archiver. (required)</para>
		/// <para>Original signature is '- (void)encodeWithCoder:(NSCoder *)encoder'</para>
		/// <para>Available in OS X v10.0 and later.</para>
		/// </summary>
		/// <param name="encoder">An archiver object.</param>
		public virtual void EncodeWithCoder (NSCoder encoder)
		{
			ObjectiveCRuntime.SendMessage (this, "encodeWithCoder:", encoder);
		}
		
		/// <summary>
		/// <para>Returns an object initialized from data in a given unarchiver. (required)</para>
		/// <para>Original signature is '- (id)initWithCoder:(NSCoder *)decoder'</para>
		/// <para>Available in OS X v10.0 and later.</para>
		/// </summary>
		/// <param name="decoder">An unarchiver object.</param>
		/// <returns>self, initialized using the data in decoder.</returns>
		public virtual Id InitWithCoder (NSCoder decoder)
		{
			return ObjectiveCRuntime.SendMessage<Id> (this, "initWithCoder:", decoder);
		}

        #endregion
	}
#endif
}
