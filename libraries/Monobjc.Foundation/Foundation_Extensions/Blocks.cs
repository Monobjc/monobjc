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

namespace Monobjc.Foundation
{
    /// <summary>
    /// Defines the signature for a block object used for comparison operations.
    /// </summary>
    public delegate NSComparisonResult NSComparator(Id obj1,Id obj2);

#if MACOSX_10_8
    /// <summary>
    /// Implement this block to retrieve the error of the script executed by <code>executeWithCompletionHandler:</code>.
    /// </summary>
    public delegate void NSUserScriptTaskCompletionHandler(NSError error);

    /// <summary>
    /// Implement this block to retrieve the result of the AppleScript executed by <code>executeWithAppleEvent:completionHandler:</code>.
    /// </summary>
    public delegate void NSUserAppleScriptTaskCompletionHandler(NSAppleEventDescriptor result,NSError error);

    /// <summary>
    /// Implement this block to retrieve the output of the Automator workflow executed by <code>executeWithInput:completionHandler:</code>.
    /// </summary>
    public delegate void NSUserAutomatorTaskCompletionHandler(Id result,NSError error);

    /// <summary>
    /// Implement this block to retrieve an error from the Unix scripted executed by <code>executeWithArguments:completionHandler:</code>.
    /// </summary>
    public delegate void NSUserUnixTaskCompletionHandler(NSError error);
#endif

    public delegate bool Func_Id_Id_out_bool_bool(Id key, Id obj, out bool stop);
    public delegate bool Func_Id_NSUInteger_out_bool_bool(Id obj, NSUInteger idx, out bool stop);
    public delegate bool Func_Id_out_bool_bool(Id obj, out bool stop);
    public delegate bool Func_NSUInteger_out_bool_bool(NSUInteger idx, out bool stop);
    public delegate Id Func_Id_NSArray_NSMutableDictionary_Id(Id evaluatedObject, NSArray expressions, NSMutableDictionary context);
    public delegate void Action_Id_Id_out_bool(Id key, Id obj, out bool stop);
    public delegate void Action_Id_NSRange_out_bool(Id obj, NSRange range, out bool stop);
    public delegate void Action_Id_NSUInteger_out_bool(Id obj, NSUInteger idx, out bool stop);
    public delegate void Action_Id_out_bool(Id obj, out bool stop);
#if MACOSX_10_9
    public delegate void Action_IntPtr_NSRange_out_bool(IntPtr bytes, NSRange byteRange, out bool stop);
#endif
    public delegate void Action_NSDictionary_NSRange_out_bool(NSDictionary attr, NSRange range, out bool stop);
    public delegate void Action_NSRange_out_bool(NSRange range, out bool stop);
    public delegate void Action_NSString_NSRange_NSRange_out_bool(NSString tag, NSRange tokenRange, NSRange sentenceRange, out bool stop);
    public delegate void Action_NSString_out_bool(NSString line, out bool stop);
#if MACOSX_10_7
    public delegate void Action_NSTextCheckingResult_NSMatchingFlags_out_bool(NSTextCheckingResult result, NSMatchingFlags flags, out bool stop);
#endif
    public delegate void Action_NSUInteger_out_bool(NSUInteger idx, out bool stop);
}
