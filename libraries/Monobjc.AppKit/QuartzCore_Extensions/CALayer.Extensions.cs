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
using Monobjc.ApplicationServices;
using System;
using System.CodeDom.Compiler;
using System.Globalization;
using System.Runtime.InteropServices;

namespace Monobjc.QuartzCore
{
#if MACOSX_10_5
    public partial class CALayer
    {
#if MACOSX_10_5
        /// <summary>
        /// <para>The identity transform: [1 0 0 0; 0 1 0 0; 0 0 1 0; 0 0 0 1].</para>
        /// <para>Available in Mac OS X v10.5 and later.</para>
        /// </summary>
        public static readonly CATransform3D CATransform3DIdentity = CATransform3D.Identity;
#endif

#if MACOSX_10_5
        /// <summary>
        /// <para>An object that provides the contents of the layer. Animatable.</para>
        /// <para>Original signature is '@property(retain) id contents'</para>
        /// <para>Available in Mac OS X v10.5 and later.</para>
        /// </summary>
        public virtual IntPtr ContentsPointer
        {
            get { return ObjectiveCRuntime.SendMessage<IntPtr>(this, "contents"); }
            set { ObjectiveCRuntime.SendMessage(this, "setContents:", value); }
        }
#endif
    }
#endif
}
