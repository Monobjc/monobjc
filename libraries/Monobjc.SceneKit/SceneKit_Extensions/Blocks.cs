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
using Monobjc;
using Monobjc.ApplicationServices;
using Monobjc.AppKit;
using Monobjc.Foundation;
using Monobjc.QuartzCore;

namespace Monobjc.SceneKit
{
#if MACOSX_10_8
	public delegate void SCNSceneSourceStatusHandler(float totalProgress, SCNSceneSourceStatus status, NSError error, out bool stopLoading);

    public delegate bool Func_SCNNode_out_bool_bool(SCNNode child, out bool stop);
#endif

#if MACOSX_10_8
    public delegate void SCNAnimationEventBlock(CAAnimation animation, Id animatedObject, bool playingBackward);

    public delegate void SCNBindingBlock(uint programID, uint location, SCNNode renderedNode, SCNRenderer renderer);

    public delegate void SCNSceneExportProgressHandler(float totalProgress, NSError error, out bool stop);

    public delegate bool Func_Id_NSString_out_bool_bool(Id id, NSString str, out bool stop);
#endif
}
