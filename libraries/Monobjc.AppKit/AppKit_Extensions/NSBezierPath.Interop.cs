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
using Monobjc.Foundation;

namespace Monobjc.AppKit
{
    partial class NSBezierPath
    {
        /// <summary>
        /// Implements the operator +.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="otherPath">The other path.</param>
        /// <returns>The result of the operator.</returns>
        public static NSBezierPath operator +(NSBezierPath path, NSBezierPath otherPath)
        {
            path.AppendBezierPath(otherPath);
            return path;
        }

        /// <summary>
        /// Implements the operator +.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="aRect">A rect.</param>
        /// <returns>The result of the operator.</returns>
        public static NSBezierPath operator +(NSBezierPath path, NSRect aRect)
        {
            path.AppendBezierPathWithRect(aRect);
            return path;
        }
    }
}