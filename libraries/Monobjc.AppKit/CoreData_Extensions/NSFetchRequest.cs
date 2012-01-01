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
using Monobjc.AppKit;
using Monobjc.QuartzCore;
using System;
using System.CodeDom.Compiler;
using System.Globalization;
using System.Runtime.InteropServices;

namespace Monobjc.CoreData
{
#if !MACOSX_10_7
    public partial class NSFetchRequest : INSCopying
    {
        #region ----- NSCopying -----

        /// <summary>
        /// <para>Returns a new instance that’s a copy of the receiver. (required)</para>
        /// <para>Original signature is '- (id)copyWithZone:(NSZone *)zone'</para>
        /// <para>Available in Mac OS X v10.0 and later.</para>
        /// </summary>
        /// <param name="zone">The zone identifies an area of memory from which to allocate for the new instance. If zone is NULL, the new instance is allocated from the default zone, which is returned from the function NSDefaultMallocZone.</param>
        /// <returns></returns>
        public virtual Id CopyWithZone(IntPtr zone)
        {
            return ObjectiveCRuntime.SendMessage<Id>(this, "copyWithZone:", zone);
        }

        #endregion
    }
#endif
}
