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
using Monobjc.AppKit;
using Monobjc.Foundation;

namespace Monobjc.AppKit
{
    public static class NSMutableAttributedStringExtensions
    {
        public static void SetBackgroundColor(this NSMutableAttributedString str, NSColor value, NSRange range)
        {
            SetAttribute(str, NSAttributedString_AppKitAdditions.NSBackgroundColorAttributeName, value, range);
        }

        public static void SetCursor(this NSMutableAttributedString str, NSCursor value, NSRange range)
        {
            SetAttribute(str, NSAttributedString_AppKitAdditions.NSCursorAttributeName, value, range);
        }

        public static void SetFont(this NSMutableAttributedString str, NSFont value, NSRange range)
        {
            SetAttribute(str, NSAttributedString_AppKitAdditions.NSFontAttributeName, value, range);
        }

        public static void SetForegroundColor(this NSMutableAttributedString str, NSColor value, NSRange range)
        {
            SetAttribute(str, NSAttributedString_AppKitAdditions.NSForegroundColorAttributeName, value, range);
        }

        public static void SetLink(this NSMutableAttributedString str, Id value, NSRange range)
        {
            SetAttribute(str, NSAttributedString_AppKitAdditions.NSLinkAttributeName, value, range);
        }

        public static void SetShadow(this NSMutableAttributedString str, NSShadow value, NSRange range)
        {
            SetAttribute(str, NSAttributedString_AppKitAdditions.NSShadowAttributeName, value, range);
        }

        private static void SetAttribute<T>(NSMutableAttributedString str, NSString name, T value, NSRange range) where T : Id
        {
            str.AddAttributeValueRange(name, value, range); 
        }
    }
}
