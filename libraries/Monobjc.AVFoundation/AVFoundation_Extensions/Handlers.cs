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
using Monobjc.CoreMedia;
using Monobjc.Foundation;

namespace Monobjc.AVFoundation
{
#if MACOSX_10_7
	/// <summary>
	/// This type specifies the signature for the block invoked when generateCGImagesAsynchronouslyForTimes:completionHandler: has completed.
	/// </summary>
	public delegate void AVAssetImageGeneratorCompletionHandler (CMTime requestedTime, IntPtr image, CMTime actualTime, AVAssetImageGeneratorResult result, NSError error);

	/// <summary>
	/// <para>Constants to indicate the outcome of image generation.</para>
	/// <para>Available in OS X v10.7 and later.</para>
	/// </summary>
	[ObjectiveCUnderlyingTypeAttribute(typeof(int), Is64Bits = false)]
	[ObjectiveCUnderlyingTypeAttribute(typeof(long), Is64Bits = true)]
	public enum AVAssetImageGeneratorResult : int
	{
		/// <summary>
		/// <para>Indicates that generation succeeded.</para>
		/// <para>Available in OS X v10.7 and later.</para>
		/// </summary>
		AVAssetImageGeneratorSucceeded,
		/// <summary>
		/// <para>Indicates that generation failed.</para>
		/// <para>Available in OS X v10.7 and later.</para>
		/// </summary>
		AVAssetImageGeneratorFailed,
		/// <summary>
		/// <para>Indicates that generation was cancelled.</para>
		/// <para>Available in OS X v10.7 and later.</para>
		/// </summary>
		AVAssetImageGeneratorCancelled,
	}
#endif
}
