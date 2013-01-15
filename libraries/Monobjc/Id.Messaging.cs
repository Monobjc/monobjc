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

namespace Monobjc
{
	partial class Id
	{
		/// <summary>
		///   Sends a message to this receiver (either a Class or an object instance).
		/// </summary>
		/// <param name = "selector">The selector.</param>
		/// <param name = "parameters">The parameters.</param>
		public void SendMessage (String selector, params Object[] parameters)
		{
			ObjectiveCRuntime.SendMessage (this, selector, parameters);
		}

		/// <summary>
		///   Sends a message to this receiver (either a Class or an object instance).
		/// </summary>
		/// <typeparam name = "TReturnType">The type of the return type.</typeparam>
		/// <param name = "selector">The selector.</param>
		/// <param name = "parameters">The parameters.</param>
		/// <returns></returns>
		public TReturnType SendMessage<TReturnType> (String selector, params Object[] parameters)
		{
			return ObjectiveCRuntime.SendMessage<TReturnType> (this, selector, parameters);
		}

		/// <summary>
		///   <para>Sends a message to the super instance of this receiver.</para>
		/// </summary>
		/// <param name = "cls">The class of the receiver.</param>
		/// <param name = "selector">The selector.</param>
		/// <param name = "parameters">The parameters.</param>
		public void SendMessageSuper (Class cls, string selector, params object[] parameters)
		{
			ObjectiveCRuntime.SendMessageSuper (this, cls, selector, parameters);
		}

		/// <summary>
		///   <para>Sends a message to the super instance of this receiver.</para>
		/// </summary>
		/// <typeparam name = "TReturnType">The type of the return type.</typeparam>
		/// <param name = "cls">The class of the receiver.</param>
		/// <param name = "selector">The selector.</param>
		/// <param name = "parameters">The parameters.</param>
		/// <returns></returns>
		public TReturnType SendMessageSuper<TReturnType> (Class cls, string selector, params object[] parameters)
		{
			return ObjectiveCRuntime.SendMessageSuper<TReturnType> (this, cls, selector, parameters);
		}

		/// <summary>
		///   <para>Sends a message to this receiver (either a Class or an object instance).</para>
		///   <para>The last parameter passed must be an object array that contains the variable list of arguments</para>
		/// </summary>
		/// <param name = "selector">The selector.</param>
		/// <param name = "parameters">The parameters.</param>
		/// <returns></returns>
		public void SendMessageVarArgs (String selector, params Object[] parameters)
		{
			ObjectiveCRuntime.SendMessageVarArgs (this, selector, parameters);
		}

		/// <summary>
		///   <para>Sends a message to this receiver (either a Class or an object instance).</para>
		///   <para>The last parameter passed must be an object array that contains the variable list of arguments</para>
		/// </summary>
		/// <typeparam name = "TReturnType">The type of the return type.</typeparam>
		/// <param name = "selector">The selector.</param>
		/// <param name = "parameters">The parameters.</param>
		/// <returns></returns>
		public TReturnType SendMessageVarArgs<TReturnType> (String selector, params Object[] parameters)
		{
			return ObjectiveCRuntime.SendMessageVarArgs<TReturnType> (this, selector, parameters);
		}

		/// <summary>
		///   <para>Sends a message to the super instance of this receiver.</para>
		///   <para>The last parameter passed must be an object array that contains the variable list of arguments</para>
		/// </summary>
		/// <param name = "cls">The class of the receiver.</param>
		/// <param name = "selector">The selector.</param>
		/// <param name = "parameters">The parameters.</param>
		public void SendMessageSuperVarArgs (Class cls, string selector, params object[] parameters)
		{
			ObjectiveCRuntime.SendMessageSuperVarArgs (this, cls, selector, parameters);
		}

		/// <summary>
		///   <para>Sends a message to the super instance of this receiver.</para>
		///   <para>The last parameter passed must be an object array that contains the variable list of arguments</para>
		/// </summary>
		/// <typeparam name = "TReturnType">The type of the return type.</typeparam>
		/// <param name = "cls">The class of the receiver.</param>
		/// <param name = "selector">The selector.</param>
		/// <param name = "parameters">The parameters.</param>
		/// <returns></returns>
		public TReturnType SendMessageSuperVarArgs<TReturnType> (Class cls, string selector, params object[] parameters)
		{
			return ObjectiveCRuntime.SendMessageSuperVarArgs<TReturnType> (this, cls, selector, parameters);
		}
	}
}