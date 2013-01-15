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
using System.Runtime.CompilerServices;

namespace Monobjc
{
	public partial class ObjectiveCRuntime
	{
		/// <summary>
		///   Casts an instance to the given type.
		/// </summary>
		/// <typeparam name = "T">The parametric type.</typeparam>
		/// <param name = "instance">The instance.</param>
		/// <returns>A cast instance.</returns>
		public static T CastTo<T> (Id instance) where T : class, IManagedWrapper
		{
			return (instance != null) ? GetInstance<T> (instance.NativePointer, RetrievalMode.Strict) : default(T);
		}

		/// <summary>
		///   Casts an instance to the given type.
		/// </summary>
		/// <typeparam name = "T">The parametric type.</typeparam>
		/// <param name = "instance">The instance.</param>
		/// <returns>A cast instance, or null if the cast is invalid.</returns>
		public static T CastAs<T> (Id instance) where T : class, IManagedWrapper
		{
			return (instance != null) ? GetInstance<T> (instance.NativePointer, RetrievalMode.FailSafe) : default(T);
		}

		/// <summary>
		///   Gets the instance of the given type.
		/// </summary>
		/// <typeparam name = "T">The parametric type.</typeparam>
		/// <param name = "value">The value.</param>
		/// <returns>An instance of the type.</returns>
		public static T GetInstance<T> (IntPtr value) where T : class, IManagedWrapper
		{
			return GetInstance<T> (value, RetrievalMode.Override);
		}

		/// <summary>
		///   Gets the instance of the given type.
		/// </summary>
		/// <typeparam name = "T">The parametric type.</typeparam>
		/// <param name = "value">The value.</param>
		/// <param name = "mode">The retrieval mode.</param>
		/// <returns>An instance of the type, or null if the type is invalid.</returns>
		public static T GetInstance<T> (IntPtr value, RetrievalMode mode) where T : class, IManagedWrapper
		{
			Type type = typeof(T);
			return (T)GetInstanceInternal (type.TypeHandle.Value, value, mode);
		}

		/// <summary>
		///   Generates the wrapper for the given interface.
		/// </summary>
		/// <param name = "type">The type.</param>
		/// <returns></returns>
		internal static IntPtr GenerateWrapper (Type type)
		{
			Logger.Info ("ObjectiveCRuntime", "Creating wrapper for " + type);
			Type wrapperType = WrapperGenerator.DefineWrapperProxy (type);
			Logger.Info ("ObjectiveCRuntime", "Wrapper is " + wrapperType);

			return wrapperType.TypeHandle.Value;
		}

		/// <summary>
		///   Internal call to retrieve a cached or created instance.
		/// </summary>
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IManagedWrapper GetInstanceInternal (IntPtr returnType, IntPtr value, RetrievalMode mode);
		
		/// <summary>
		/// Retrieval mode used for cache access.
		/// </summary>
		public enum RetrievalMode
		{
			/// <summary>
			/// The retrieved instance must be assignable the expected type.
			/// </summary>
			Strict,
			/// <summary>
			/// The retrieved instance should be assignable the expected type. If not, null is returned.
			/// </summary>
			FailSafe,
			/// <summary>
			/// The retrieved instance should be assignable the expected type. If not, a new wrapper is generated.
			/// </summary>
			Override,
		}
	}
}