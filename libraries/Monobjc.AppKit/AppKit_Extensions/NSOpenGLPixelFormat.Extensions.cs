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

using Monobjc;
using Monobjc.Foundation;
using Monobjc.CoreData;
using Monobjc.QuartzCore;
using Monobjc.ApplicationServices;
using System;
using System.CodeDom.Compiler;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;

namespace Monobjc.AppKit
{
	public partial class NSOpenGLPixelFormat
	{
        /// <summary>
        /// <para>Returns an NSOpenGLPixelFormat object initialized with specified pixel format attributes.</para>
        /// <para>Original signature is '- (id)initWithAttributes:(const NSOpenGLPixelFormatAttribute *)attribs'</para>
        /// <para>Available in Mac OS X v10.0 and later.</para>
        /// </summary>

        public NSOpenGLPixelFormat(NSOpenGLPixelFormatAttribute[] attribs) : this(attribs.Select(attribute => Convert.ToUInt32(attribute)).ToArray())
        {
        }
		
        /// <summary>
        /// <para>Returns an NSOpenGLPixelFormat object initialized with specified pixel format attributes.</para>
        /// <para>Original signature is '- (id)initWithAttributes:(const NSOpenGLPixelFormatAttribute *)attribs'</para>
        /// <para>Available in Mac OS X v10.0 and later.</para>
        /// </summary>

        public NSOpenGLPixelFormat(Object[] attribs) : this(attribs.Select(Convert.ToUInt32).ToArray())
        {
        }
		
        /// <summary>
        /// <para>Returns an NSOpenGLPixelFormat object initialized with specified pixel format attributes.</para>
        /// <para>Original signature is '- (id)initWithAttributes:(const NSOpenGLPixelFormatAttribute *)attribs'</para>
        /// <para>Available in Mac OS X v10.0 and later.</para>
        /// </summary>
        public NSOpenGLPixelFormat(uint[] attribs) : this(ObjectiveCRuntime.SendMessage<IntPtr>(NSOpenGLPixelFormatClass, "alloc"))
        {
			// TODO: Remove when array are supported in bridge
			int size = Marshal.SizeOf(typeof(uint));
			IntPtr native = Marshal.AllocHGlobal(attribs.Length * size);
			for(int i = 0; i < attribs.Length; i++)
			{
				IntPtr insert = new IntPtr(native.ToInt64() + i * size);
				Marshal.WriteInt32(insert, (int) attribs[i]);
			}
            this.NativePointer = ObjectiveCRuntime.SendMessage<IntPtr>(this, "initWithAttributes:", native);
			Marshal.FreeHGlobal(native);
        }
	}
}
