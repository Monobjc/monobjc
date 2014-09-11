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
    public static class NSAttributedStringExtensions
    {        
        public static NSColor GetBackgroundColor(this NSAttributedString str, ref NSRange range)
        {
            return GetAttribute<NSColor>(str, NSAttributedString_AppKitAdditions.NSBackgroundColorAttributeName, ref range);
        }

        public static NSCursor GetCursor(this NSAttributedString str, ref NSRange range)
        {
            return GetAttribute<NSCursor>(str, NSAttributedString_AppKitAdditions.NSCursorAttributeName, ref range);
        }
        
        public static NSFont GetFont(this NSAttributedString str, ref NSRange range)
        {
            return GetAttribute<NSFont>(str, NSAttributedString_AppKitAdditions.NSFontAttributeName, ref range);
        }

        public static NSColor GetForegroundColor(this NSAttributedString str, ref NSRange range)
        {
            return GetAttribute<NSColor>(str, NSAttributedString_AppKitAdditions.NSForegroundColorAttributeName, ref range);
        }
        
        public static Id GetLink(this NSAttributedString str, ref NSRange range)
        {
            return GetAttribute<Id>(str, NSAttributedString_AppKitAdditions.NSLinkAttributeName, ref range);
        }

        public static NSShadow GetShadow(this NSAttributedString str, ref NSRange range)
        {
            return GetAttribute<NSShadow>(str, NSAttributedString_AppKitAdditions.NSShadowAttributeName, ref range);
        }

        private static T GetAttribute<T>(NSAttributedString str, NSString name, ref NSRange range) where T : Id
        {
            return str.AttributeAtIndexEffectiveRange(name, range.location, ref range).CastAs<T>();
        }
    }
}
