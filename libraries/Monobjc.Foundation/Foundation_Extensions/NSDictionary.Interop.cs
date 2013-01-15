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
namespace Monobjc.Foundation
{
    public partial class NSDictionary
    {
        /// <summary>
        /// <para>Returns the value associated with a given key.</para>
        /// <para>Original signature is '- (id)objectForKey:(id)aKey'</para>
        /// <para>Available in Mac OS X v10.0 and later.</para>
        /// </summary>
        /// <typeparam name="T">The parametric type</typeparam>
        /// <param name="aKey">The key for which to return the corresponding value.</param>
        /// <returns>
        /// The value associated with aKey, or nil if no value is associated with aKey.
        /// </returns>
        public virtual T ObjectForKey<T>(Id aKey) where T : IManagedWrapper
        {
            return ObjectiveCRuntime.SendMessage<T>(this, "objectForKey:", aKey);
        }
    }
}