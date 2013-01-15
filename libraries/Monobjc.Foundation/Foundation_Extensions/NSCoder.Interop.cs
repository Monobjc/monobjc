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
using System.Globalization;

namespace Monobjc.Foundation
{
    public partial class NSCoder
    {
        /// <summary>
        /// <para>Decodes an Objective-C object that was previously encoded with any of the encode...Object: methods.</para>
        /// <para>Original signature is '- (id)decodeObject'</para>
        /// <para>Available in Mac OS X v10.0 and later.</para>
        /// </summary>
        /// <returns></returns>
        public virtual T DecodeObject<T>() where T : Id
        {
            return ObjectiveCRuntime.SendMessage<T>(this, "decodeObject");
        }
		
        /// <summary>
        /// <para>Decodes and returns an autoreleased Objective-C object that was previously encoded with encodeObject:forKey: or encodeConditionalObject:forKey: and associated with the string key.</para>
        /// <para>Original signature is '- (id)decodeObjectForKey:(NSString *)key'</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        /// <param name="key">MISSING</param>
        /// <returns></returns>
        public virtual T DecodeObjectForKey<T>(NSString key) where T : Id
        {
            return ObjectiveCRuntime.SendMessage<T>(this, "decodeObjectForKey:", key);
        }
		
        /// <summary>
        /// <para>Decodes a property list that was previously encoded with encodePropertyList:.</para>
        /// <para>Original signature is '- (id)decodePropertyList'</para>
        /// <para>Available in Mac OS X v10.0 and later.</para>
        /// </summary>
        /// <returns></returns>
        public virtual T DecodePropertyList<T>() where T : Id
        {
            return ObjectiveCRuntime.SendMessage<T>(this, "decodePropertyList");
        }
    }
}