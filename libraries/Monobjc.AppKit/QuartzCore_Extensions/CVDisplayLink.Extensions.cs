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
using Monobjc.AppKit;
using Monobjc.ApplicationServices;
using System;
using System.CodeDom.Compiler;
using System.Globalization;
using System.Runtime.InteropServices;

namespace Monobjc.QuartzCore
{
	/// <summary>
	/// <para>CoreVideo specific error codes.</para>
	/// </summary>
	public enum CVReturn
	{
		/// <summary>
		/// <para>Function executed successfully without errors.</para>
		/// </summary>
	    kCVReturnSuccess                         = 0,
	    /// <summary>
	    /// <para>Placeholder to mark the beginning of the range of CVReturn codes.</para>
	    /// </summary>
	    kCVReturnFirst                           = -6660,
	    /// <summary>
	    /// <para>General error code.</para>
	    /// </summary>
	    kCVReturnError                           = kCVReturnFirst,
		/// <summary>
		/// <para>At least one of the arguments passed in is not valid. Either out of range or the wrong type.</para>
		/// </summary>
	    kCVReturnInvalidArgument                 = -6661,
		/// <summary>
		/// <para>The allocation for a buffer or buffer pool failed. Most likely because of lack of resources.</para>
		/// </summary>
	    kCVReturnAllocationFailed                = -6662,
		/// <summary>
		/// <para>A CVDisplayLink cannot be created for the given DisplayRef.</para>
		/// </summary>
	    kCVReturnInvalidDisplay                  = -6670,
		/// <summary>
		/// <para>The CVDisplayLink is already started and running.</para>
		/// </summary>
	    kCVReturnDisplayLinkAlreadyRunning       = -6671,
		/// <summary>
		/// <para>The CVDisplayLink has not been started.</para>
		/// </summary>
	    kCVReturnDisplayLinkNotRunning           = -6672,
		/// <summary>
		/// <para>The render and display callbacks or the output callback is not set. You have to set either the render/display pair or the single output callback.</para>
		/// </summary>
	    kCVReturnDisplayLinkCallbacksNotSet      = -6673,
		/// <summary>
		/// <para>The requested pixelformat is not supported for the CVBuffer type.</para>
		/// </summary>
	    kCVReturnInvalidPixelFormat              = -6680,
		/// <summary>
		/// <para>The requested size (most likely too big) is not supported for the CVBuffer type.</para>
		/// </summary>
	    kCVReturnInvalidSize                     = -6681,
		/// <summary>
		/// <para>A CVBuffer cannot be created with the given attributes.</para>
		/// </summary>
	    kCVReturnInvalidPixelBufferAttributes    = -6682,
		/// <summary>
		/// <para>The Buffer cannot be used with OpenGL as either its size, pixelformat or attributes are not supported by OpenGL.</para>
		/// </summary>
	    kCVReturnPixelBufferNotOpenGLCompatible  = -6683,
	    /// <summary>
	    /// <para>The allocation request failed because it would have exceeded a specified allocation threshold (see kCVPixelBufferPoolAllocationThresholdKey).</para>
	    /// </summary>
	    kCVReturnWouldExceedAllocationThreshold  = -6689,
		/// <summary>
		/// <para>The allocation for the buffer pool failed. Most likely because of lack of resources. Check if your parameters are in range.</para>
		/// </summary>
	    kCVReturnPoolAllocationFailed            = -6690,
		/// <summary>
		/// <para>A CVBufferPool cannot be created with the given attributes.</para>
		/// </summary>
	    kCVReturnInvalidPoolAttributes           = -6691,
	    /// <summary>
	    /// <para>Placeholder to mark the end of the range of CVReturn codes.</para>
	    /// </summary>
	    kCVReturnLast                            = -6699
	    
	}
	
	/// <summary>
	/// <para>The flags to be used for the display link output callback function.</para>
    /// <para>Available in Mac OS X v10.3 and later.</para>
	/// </summary>
	public enum CVOptionFlags : ulong
	{
		None = 0
	}
	
	/// <summary>
	/// <para>Defines a pointer to a display link output callback function, which is called whenever the display link wants the application to output a frame.</para>
    /// <para>Original signature is 'typedef CVReturn (*CVDisplayLinkOutputCallback)(CVDisplayLinkRef displayLink, const CVTimeStamp *inNow, const CVTimeStamp *inOutputTime, CVOptionFlags flagsIn, CVOptionFlags *flagsOut, void *displayLinkContext);'</para>
    /// <para>Available in Mac OS X v10.3 and later.</para>
	/// </summary>
	/// <param name="displayLink">The display link requesting the frame.</param>
	/// <param name="inNow">A pointer to the current time.</param>
	/// <param name="inOutputTime">A pointer to the time that the frame will be displayed.</param>
	/// <param name="flagsIn">Currently unused. Pass 0.</param>
	/// <param name="flagsOut">Currently unused. Pass 0.</param>
	/// <param name="displayLinkContext">A pointer to application-defined data. This is the pointer you passed into the CVDisplayLinkOutputCallback function when registering your callback.</param>
	public delegate CVReturn CVDisplayLinkOutputCallback(IntPtr displayLink, ref CVTimeStamp inNow, ref CVTimeStamp inOutputTime, CVOptionFlags flagsIn, ref CVOptionFlags flagsOut, IntPtr context);
}
