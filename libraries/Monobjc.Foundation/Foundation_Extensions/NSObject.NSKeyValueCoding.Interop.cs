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
using System;

namespace Monobjc.Foundation
{
    public partial class NSObject
    {
        /// <summary>
        /// <para>Returns the value for the property identified by a given key.</para>
        /// <para>Original signature is '- (id)valueForKey:(NSString *)key'</para>
        /// <para>Available in Mac OS X v10.0 and later.</para>
        /// </summary>
        /// <param name="key">The name of one of the receiver's properties.</param>
        /// <returns>The value for the property identified by key.</returns>
        public virtual T ValueForKey<T>(NSString key) where T : Id
        {
            return ObjectiveCRuntime.SendMessage<T>(this, "valueForKey:", key);
        }

        /// <summary>
        /// <para>Returns the value for the derived property identified by a given key path.</para>
        /// <para>Original signature is '- (id)valueForKeyPath:(NSString *)keyPath'</para>
        /// <para>Available in Mac OS X v10.0 and later.</para>
        /// </summary>
        /// <param name="keyPath">A key path of the form relationship.property (with one or more relationships); for example “department.name” or “department.manager.lastName”.</param>
        /// <returns>The value for the derived property identified by keyPath.</returns>
        public virtual T ValueForKeyPath<T>(NSString keyPath) where T : Id
        {
            return ObjectiveCRuntime.SendMessage<T>(this, "valueForKeyPath:", keyPath);
        }

        /// <summary>
        /// <para>Sets the property of the receiver specified by a given key to a given value.</para>
        /// <para>Original signature is '- (void)setValue:(id)value forKey:(NSString *)key'</para>
        /// <para>Available in Mac OS X v10.3 and later.</para>
        /// </summary>
        /// <param name="value">The value for the property identified by key.</param>
        /// <param name="key">The name of one of the receiver's properties.</param>
        public void SetValueForKey(String value, String key)
        {
            this.SetValueForKey((NSString) value, (NSString) key);
        }

        /// <summary>
        /// <para>Sets the property of the receiver specified by a given key to a given value.</para>
        /// <para>Original signature is '- (void)setValue:(id)value forKey:(NSString *)key'</para>
        /// <para>Available in Mac OS X v10.3 and later.</para>
        /// </summary>
        /// <param name="value">The value for the property identified by key.</param>
        /// <param name="key">The name of one of the receiver's properties.</param>
        public void SetValueForKey(short value, String key)
        {
            this.SetValueForKey((NSNumber) value, key);
        }

        /// <summary>
        /// <para>Sets the property of the receiver specified by a given key to a given value.</para>
        /// <para>Original signature is '- (void)setValue:(id)value forKey:(NSString *)key'</para>
        /// <para>Available in Mac OS X v10.3 and later.</para>
        /// </summary>
        /// <param name="value">The value for the property identified by key.</param>
        /// <param name="key">The name of one of the receiver's properties.</param>
        public void SetValueForKey(long value, String key)
        {
            this.SetValueForKey((NSNumber) value, key);
        }

        /// <summary>
        /// <para>Sets the property of the receiver specified by a given key to a given value.</para>
        /// <para>Original signature is '- (void)setValue:(id)value forKey:(NSString *)key'</para>
        /// <para>Available in Mac OS X v10.3 and later.</para>
        /// </summary>
        /// <param name="value">The value for the property identified by key.</param>
        /// <param name="key">The name of one of the receiver's properties.</param>
        public void SetValueForKey(int value, String key)
        {
            this.SetValueForKey((NSNumber) value, key);
        }

        /// <summary>
        /// <para>Sets the property of the receiver specified by a given key to a given value.</para>
        /// <para>Original signature is '- (void)setValue:(id)value forKey:(NSString *)key'</para>
        /// <para>Available in Mac OS X v10.3 and later.</para>
        /// </summary>
        /// <param name="value">The value for the property identified by key.</param>
        /// <param name="key">The name of one of the receiver's properties.</param>
        public void SetValueForKey(float value, String key)
        {
            this.SetValueForKey((NSNumber) value, key);
        }

        /// <summary>
        /// <para>Sets the property of the receiver specified by a given key to a given value.</para>
        /// <para>Original signature is '- (void)setValue:(id)value forKey:(NSString *)key'</para>
        /// <para>Available in Mac OS X v10.3 and later.</para>
        /// </summary>
        /// <param name="value">The value for the property identified by key.</param>
        /// <param name="key">The name of one of the receiver's properties.</param>
        public void SetValueForKey(double value, String key)
        {
            this.SetValueForKey((NSNumber) value, key);
        }

        /// <summary>
        /// <para>Sets the property of the receiver specified by a given key to a given value.</para>
        /// <para>Original signature is '- (void)setValue:(id)value forKey:(NSString *)key'</para>
        /// <para>Available in Mac OS X v10.3 and later.</para>
        /// </summary>
        /// <param name="value">The value for the property identified by key.</param>
        /// <param name="key">The name of one of the receiver's properties.</param>
        public void SetValueForKey(char value, String key)
        {
            this.SetValueForKey((NSNumber) value, key);
        }

        /// <summary>
        /// <para>Sets the property of the receiver specified by a given key to a given value.</para>
        /// <para>Original signature is '- (void)setValue:(id)value forKey:(NSString *)key'</para>
        /// <para>Available in Mac OS X v10.3 and later.</para>
        /// </summary>
        /// <param name="value">The value for the property identified by key.</param>
        /// <param name="key">The name of one of the receiver's properties.</param>
        public void SetValueForKey(bool value, String key)
        {
            this.SetValueForKey((NSNumber) value, key);
        }
    }
}