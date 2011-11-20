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
using System.Globalization;

namespace Monobjc.Foundation
{
    public partial class NSObject
    {
        /// <summary>
        /// <para>Invoked to inform the receiver that the value of a given property has changed.</para>
        /// <para>Original signature is '- (void)didChangeValueForKey:(NSString *)key'</para>
        /// <para>Available in Mac OS X v10.3 and later.</para>
        /// </summary>
        /// <param name="firstKey">The name of the property that changed.</param>
        /// <param name="others">Others keys.</param>
        public virtual void DidChangeValueForKey(NSString firstKey, params NSString[] others)
        {
            ObjectiveCRuntime.SendMessage(this, "didChangeValueForKey:", firstKey);
			foreach(NSString key in others) {
	            ObjectiveCRuntime.SendMessage(this, "didChangeValueForKey:", key);
			}
        }

        /// <summary>
        /// <para>Invoked to inform the receiver that the value of a given property is about to change.</para>
        /// <para>Original signature is '- (void)willChangeValueForKey:(NSString *)key'</para>
        /// <para>Available in Mac OS X v10.3 and later.</para>
        /// </summary>
        /// <param name="firstKey">The name of the property that will change.</param>
        /// <param name="others">Others keys.</param>
        public virtual void WillChangeValueForKey(NSString firstKey, params NSString[] others)
        {
            ObjectiveCRuntime.SendMessage(this, "willChangeValueForKey:", firstKey);
			foreach(NSString key in others) {
	            ObjectiveCRuntime.SendMessage(this, "willChangeValueForKey:", key);
			}
        }
		
        /// <summary>
        /// <para>Returns the object returned by copyWithZone:, where the zone is nil.</para>
        /// <para>Original signature is '- (id)copy'</para>
        /// <para>Available in Mac OS X v10.0 and later.</para>
        /// </summary>
        public virtual T Copy<T>() where T : Id
        {
            return ObjectiveCRuntime.SendMessage<T>(this, "copy");
        }

        /// <summary>
        /// <para>Returns the object returned by mutableCopyWithZone: where the zone is nil.</para>
        /// <para>Original signature is '- (id)mutableCopy'</para>
        /// <para>Available in Mac OS X v10.0 and later.</para>
        /// </summary>
        public virtual T MutableCopy<T>() where T : Id
        {
            return ObjectiveCRuntime.SendMessage<T>(this, "mutableCopy");
        }

        /// <summary>
        /// <para>Returns a Boolean value that indicates whether the receiver implements or inherits a method that can respond to a specified message.</para>
        /// <para>Original signature is '- (BOOL)respondsToSelector:(SEL)aSelector'</para>
        /// <para>Available in Mac OS X v10.0 and later.</para>
        /// </summary>
        /// <param name="aSelector">A selector that identifies a message.</param>
        /// <returns>
        /// YES if the receiver implements or inherits a method that can respond to aSelector, otherwise NO.
        /// </returns>
        public virtual bool RespondsToSelector(String aSelector)
        {
            return this.RespondsToSelector(ObjectiveCRuntime.Selector(aSelector));
        }

        /// <summary>
        ///   Returns a <see cref = "System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        ///   A <see cref = "System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return String.Format(CultureInfo.CurrentCulture, "Description = {0}", this.Description);
        }
    }
}