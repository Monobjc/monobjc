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
using Monobjc;
using Monobjc.ApplicationServices;
using System;
using System.CodeDom.Compiler;
using System.Globalization;
using System.Runtime.InteropServices;

namespace Monobjc.Foundation
{
    public static partial class FoundationFramework
    {
        /// <summary>
        /// <para>Returns a localized version of a string.</para>
        /// <para>Original signature is 'NSString *NSLocalizedString(NSString *key, NSString *comment)'</para>
        /// <para>Available in Mac OS X v10.0 and later.</para>
        /// </summary>
        public static NSString NSLocalizedString(NSString key,
                                                 NSString comment)
        {
            return NSBundle.MainBundle.LocalizedStringForKeyValueTable(key, NSString.Empty, null);
        }

        /// <summary>
        /// <para>Returns a localized version of a string.</para>
        /// <para>Original signature is 'NSString *NSLocalizedStringFromTable(NSString *key, NSString *tableName, NSString *comment)'</para>
        /// <para>Available in Mac OS X v10.0 and later.</para>
        /// </summary>
        public static NSString NSLocalizedStringFromTable(NSString key,
                                                          NSString tableName,
                                                          NSString comment)
        {
            return NSBundle.MainBundle.LocalizedStringForKeyValueTable(key, NSString.Empty, tableName);
        }

        /// <summary>
        /// <para>Returns a localized version of a string.</para>
        /// <para>Original signature is 'NSString *NSLocalizedStringFromTableInBundle(NSString *key, NSString *tableName, NSBundle *bundle, NSString *comment)'</para>
        /// <para>Available in Mac OS X v10.0 and later.</para>
        /// </summary>
        public static NSString NSLocalizedStringFromTableInBundle(NSString key,
                                                                  NSString tableName,
                                                                  NSBundle bundle,
                                                                  NSString comment)
        {
            return bundle.LocalizedStringForKeyValueTable(key, NSString.Empty, tableName);
        }

        /// <summary>
        /// <para>Returns a localized version of a string.</para>
        /// <para>Original signature is 'NSString *NSLocalizedStringWithDefaultValue(NSString *key, NSString *tableName, NSBundle *bundle, NSString *value, NSString *comment)'</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        public static NSString NSLocalizedStringWithDefaultValue(NSString key,
                                                                 NSString tableName,
                                                                 NSBundle bundle,
                                                                 NSString value,
                                                                 NSString comment)
        {
            return bundle.LocalizedStringForKeyValueTable(key, value, tableName);
        }
    }
}
