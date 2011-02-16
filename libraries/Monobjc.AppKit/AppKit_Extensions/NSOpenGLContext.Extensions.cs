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
    public partial class NSOpenGLContext
    {
        /// <summary>
        /// <para>Sets the value of the specified parameter.</para>
        /// <para>Original signature is '- (void)setValues:(const GLint *)vals forParameter:(NSOpenGLContextParameter)param'</para>
        /// <para>Available in Mac OS X v10.0 and later.</para>
        /// </summary>
        /// <param name="vals">The new value (or values) for the parameter.</param>
        /// <param name="param">The parameter you want to modify. For a list of parameters, see NSOpenGLContextParameter.</param>
        public virtual void SetValuesForParameter(int[] vals, NSOpenGLContextParameter param)
        {
			// TODO: Remove when array are supported in bridge
			int size = Marshal.SizeOf(typeof(uint));
			IntPtr native = Marshal.AllocHGlobal(vals.Length * size);
			for(int i = 0; i < vals.Length; i++)
			{
				IntPtr insert = new IntPtr(native.ToInt64() + i * size);
				Marshal.WriteInt32(insert, (int) vals[i]);
			}
            ObjectiveCRuntime.SendMessage(this, "setValues:forParameter:", native, param);
			Marshal.FreeHGlobal(native);
        }
    }
}
