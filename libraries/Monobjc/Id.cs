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
using System.Runtime.CompilerServices;

namespace Monobjc
{
    /// <summary>
    ///   <para>This type represents a native object in the Objective-C runtime and is referenced through a memory pointer.</para>
    ///   <para>For each managed instance is associated a native pointer that allows a two-way messaging between the .NET and the Objective-C runtime.</para>
    /// </summary>
    public partial class Id : IManagedWrapper, IDisposable, IEquatable<Id>
    {
        private bool owner;
        internal IntPtr pointer;

        /// <summary>
        ///   Initializes a new instance of the <see cref = "Id" /> class.
        /// </summary>
        public Id()
        {
            this.owner = true;
            Class cls = Class.Get(this.GetType());
            this.NativePointer = ObjectiveCRuntime.SendMessage<IntPtr>(cls, "alloc");
            this.NativePointer = ObjectiveCRuntime.SendMessage<IntPtr>(this, "init");
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref = "Id" /> class.
        /// </summary>
        /// <param name = "value">The pointer.</param>
        public Id(IntPtr value)
        {
            this.NativePointer = value;
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref = "Id" /> class.
        /// </summary>
        /// <param name = "selector">The selector.</param>
        /// <param name = "firstParameter">The first param.</param>
        /// <param name = "otherParameters">The parameters.</param>
        protected Id(String selector, Object firstParameter, params Object[] otherParameters)
        {
            this.owner = true;
            Class cls = Class.Get(this.GetType());
            this.NativePointer = ObjectiveCRuntime.SendMessage<IntPtr>(cls, "alloc");
            this.NativePointer = ObjectiveCRuntime.SendMessageVarArgs<IntPtr>(this, selector, firstParameter, otherParameters);
        }

        /// <summary>
        ///   Gets or sets the native pointer.
        /// </summary>
        /// <value>The native pointer.</value>
        public IntPtr NativePointer
        {
            get { return this.pointer; }
            set
            {
                this.pointer = value;
                MapInstance(this.pointer, this);
            }
        }

        /// <summary>
        ///   Try to cast the current instance to the given type. The cast is dynamically tested for safety.
        /// </summary>
        /// <typeparam name = "T">The type of the instance.</typeparam>
        /// <returns>
        ///   The cast instance or null if the cast is not valid
        /// </returns>
        public T CastAs<T>() where T : class, IManagedWrapper
        {
            return ObjectiveCRuntime.CastAs<T>(this);
        }

        /// <summary>
        ///   Cast the current instance to the given type. The cast is dynamically tested for safety.
        /// </summary>
        /// <typeparam name = "T">The type of the instance.</typeparam>
        /// <returns>The cast instance</returns>
        /// <exception cref = "ObjectiveCClassCastException">If an error occured during the cast</exception>
        public T CastTo<T>() where T : class, IManagedWrapper
        {
            return ObjectiveCRuntime.CastTo<T>(this);
        }

        /// <summary>
        ///   Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        ///   Releases unmanaged resources and performs other cleanup operations before the
        ///   <see cref = "Id" /> is reclaimed by garbage collection.
        /// </summary>
        ~Id()
        {
            this.Dispose(false);
        }

        /// <summary>
        ///   Releases unmanaged and - optionally - managed resources
        /// </summary>
        /// <param name = "disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing && this.owner)
            {
                this.Release();
            }
        }

        /// <summary>
        ///   Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <returns>
        ///   true if the current object is equal to the <paramref name = "other" /> parameter; otherwise, false.
        /// </returns>
        /// <param name = "other">An object to compare with this object.
        /// </param>
        public bool Equals(Id other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return other.pointer.Equals(this.pointer);
        }

        /// <summary>
        ///   Determines whether the specified <see cref = "T:System.Object" /> is equal to the current <see cref = "T:System.Object" />.
        /// </summary>
        /// <returns>
        ///   true if the specified <see cref = "T:System.Object" /> is equal to the current <see cref = "T:System.Object" />; otherwise, false.
        /// </returns>
        /// <param name = "obj">The <see cref = "T:System.Object" /> to compare with the current <see cref = "T:System.Object" />. 
        /// </param>
        /// <exception cref = "T:System.NullReferenceException">The <paramref name = "obj" /> parameter is null.
        /// </exception>
        /// <filterpriority>2</filterpriority>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            if (obj.GetType() != typeof (Id))
            {
                return false;
            }
            return this.Equals((Id) obj);
        }

        /// <summary>
        ///   Serves as a hash function for a particular type.
        /// </summary>
        /// <returns>
        ///   A hash code for the current <see cref = "T:System.Object" />.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public override int GetHashCode()
        {
            return this.pointer.GetHashCode();
        }

        /// <summary>
        ///   Implements the operator ==.
        /// </summary>
        /// <param name = "left">The left.</param>
        /// <param name = "right">The right.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(Id left, Id right)
        {
            return Equals(left, right);
        }

        /// <summary>
        ///   Implements the operator !=.
        /// </summary>
        /// <param name = "left">The left.</param>
        /// <param name = "right">The right.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(Id left, Id right)
        {
            return !Equals(left, right);
        }

        /// <summary>
        ///   Gets the instance variable of the specified name.
        /// </summary>
        /// <typeparam name = "T">The type of the instance variable.</typeparam>
        /// <param name = "name">The name of the instance variable.</param>
        /// <returns>The value of the instance variable.</returns>
        protected T GetInstanceVariable<T>(String name)
        {
            return (T) GetInstanceVariableInternal(typeof (T).TypeHandle.Value, this.pointer, name);
        }

        /// <summary>
        ///   Sets the instance variable of the specified name.
        /// </summary>
        /// <typeparam name = "T">The type of the instance variable.</typeparam>
        /// <param name = "name">The name of the instance variable.</param>
        /// <param name = "value">The value of the instance variable.</param>
        protected void SetInstanceVariable<T>(String name, T value)
        {
            SetInstanceVariableInternal(typeof (T).TypeHandle.Value, this.pointer, name, value);
        }

        /// <summary>
        ///   Add this instance to the cache for fast mapping.
        /// </summary>
        /// <param name = "pointer">The native pointer.</param>
        /// <param name = "instance">The instance.</param>
        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern void MapInstance(IntPtr pointer, Id instance);

        /// <summary>
        ///   Internal call to get the value of the instance variable.
        /// </summary>
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        private static extern Object GetInstanceVariableInternal(IntPtr type, IntPtr pointer, String name);

        /// <summary>
        ///   Internal call to set the value of the instance variable.
        /// </summary>
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        private static extern void SetInstanceVariableInternal(IntPtr type, IntPtr pointer, String name, Object value);
    }
}