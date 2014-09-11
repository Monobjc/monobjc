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

namespace Monobjc
{
	/// <summary>
	///   Interface to identity classes or interfaces that can act as a managed wrapper.
	/// </summary>
	public partial interface IManagedWrapper
	{
		/// <summary>
		///   Cast the current instance to the given type. The cast is dynamically tested for safety.
		/// </summary>
		/// <typeparam name = "T">The type of the instance.</typeparam>
		/// <returns>The cast instance</returns>
		/// <exception cref = "ObjectiveCClassCastException">If an error occured during the cast</exception>
		T CastTo<T> () where T : class, IManagedWrapper;

		/// <summary>
		///   Try to cast the current instance to the given type. The cast is dynamically tested for safety.
		/// </summary>
		/// <typeparam name = "T">The type of the instance.</typeparam>
		/// <returns>The cast instance or null if the cast is not valid</returns>
		T CastAs<T> () where T : class, IManagedWrapper;

		/// <summary>
		///   <para>Gets the underlying native pointer.</para>
		/// </summary>
		/// <value>The native pointer.</value>
		IntPtr NativePointer { get; }
	}
}