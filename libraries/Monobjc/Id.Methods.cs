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
namespace Monobjc
{
    public partial class Id
    {
        /// <summary>
        ///   <para>Gets the class of the underlying instance.</para>
        /// </summary>
        /// <value>The class.</value>
        /// <remarks>
        ///   Original signature is '- (Class)class'
        /// </remarks>
        public Class Class
        {
            get { return ObjectiveCRuntime.SendMessage<Class>(this, "class"); }
        }

        /// <summary>
        ///   Allocates a new native instance.
        /// </summary>
        public virtual Id Alloc()
        {
            return ObjectiveCRuntime.SendMessage<Id>(this, "alloc");
        }

        /// <summary>
        ///   <para>Adds the receiver to the current autorelease pool.</para>
        ///   <para>Original signature is '- (id)autorelease'</para>
        ///   <para>Available in Mac OS X v10.0 and later.</para>
        /// </summary>
        /// <returns></returns>
        public virtual Id Autorelease()
        {
            this.owner = false;
            return ObjectiveCRuntime.SendMessage<Id>(this, "autorelease");
        }

        /// <summary>
        ///   <para>Adds the receiver to the current autorelease pool.</para>
        ///   <para>Original signature is '- (id)autorelease'</para>
        ///   <para>Available in Mac OS X v10.0 and later.</para>
        /// </summary>
        /// <returns></returns>
        public virtual T Autorelease<T>() where T : Id
        {
            this.owner = false;
            return ObjectiveCRuntime.SendMessage<T>(this, "autorelease");
        }

        /// <summary>
        ///   <para>Decrements the receiver’s reference count.</para>
        ///   <para>Original signature is '- (oneway void)release'</para>
        ///   <para>Available in Mac OS X v10.0 and later.</para>
        /// </summary>
        public virtual void Release()
        {
            this.owner = false;
            ObjectiveCRuntime.SendMessage(this, "release");
        }

        /// <summary>
        ///   <para>Increments the receiver’s reference count.</para>
        ///   <para>Original signature is '- (id)retain'</para>
        ///   <para>Available in Mac OS X v10.0 and later.</para>
        /// </summary>
        /// <returns></returns>
        public virtual Id Retain()
        {
            this.owner = true;
            return ObjectiveCRuntime.SendMessage<Id>(this, "retain");
        }

        /// <summary>
        ///   <para>Increments the receiver’s reference count.</para>
        ///   <para>Original signature is '- (id)retain'</para>
        ///   <para>Available in Mac OS X v10.0 and later.</para>
        /// </summary>
        /// <returns></returns>
        public virtual T Retain<T>() where T : Id
        {
            this.owner = true;
            return ObjectiveCRuntime.SendMessage<T>(this, "retain");
        }
    }
}