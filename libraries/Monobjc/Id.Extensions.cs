//
// This file is part of Monobjc, a .NET/Objective-C bridge
// Copyright (C) 2007-2012 - Laurent Etiemble
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
	/// <summary>
	///   Extensions methods for Id class, that are null friendly (i.e. a call on a null reference returns.
	/// </summary>
	public static class IdExtensions
	{
		/// <summary>
		///   <para>Performs a safe autorelease operation on the given instance.</para>
		///   <para>The equivalent code is:</para>
		///   <code>
		///     if (instance != null) instance.Release(); return instance;
		///   </code>
		/// </summary>
		/// <typeparam name = "T">The type of the instance</typeparam>
		/// <param name = "instance">The instance.</param>
		/// <returns>The instance autoreleased or null if instance was null</returns>
		public static T SafeAutorelease<T> (this T instance) where T : Id
		{
			if (instance != null) {
				instance.Autorelease ();
			}
			return instance;
		}

		/// <summary>
		///   <para>Performs a safe release operation on the given instance.</para>
		///   <para>The equivalent code is:</para>
		///   <code>
		///     if (instance != null) instance.Release();
		///   </code>
		/// </summary>
		/// <param name = "instance">The instance.</param>
		public static void SafeRelease (this Id instance)
		{
			if (instance != null) {
				instance.Release ();
			}
		}

		/// <summary>
		///   <para>Performs a safe retain operation on the given instance.</para>
		///   <para>The equivalent code is:</para>
		///   <code>
		///     if (instance != null) instance.Retain(); return instance;
		///   </code>
		/// </summary>
		/// <typeparam name = "T">The type of the instance</typeparam>
		/// <param name = "instance">The instance.</param>
		/// <returns>The instance retained or null if instance was null</returns>
		public static T SafeRetain<T> (this T instance) where T : Id
		{
			if (instance != null) {
				instance.Retain ();
			}
			return instance;
		}

		/// <summary>
		///   Cast the current instance to the given type. the cast is dynamically tested for safety
		/// </summary>
		/// <typeparam name = "TInstance">The type of the instance.</typeparam>
		/// <returns>The cast instance or null if the reference is null</returns>
		/// <exception cref = "ObjectiveCClassCastException">If an error occured during the cast</exception>
		public static TInstance SafeCastTo<TInstance> (this Id id) where TInstance : class, IManagedWrapper
		{
			return (id != null) ? ObjectiveCRuntime.CastTo<TInstance> (id) : null;
		}

		/// <summary>
		///   Try to cast the current instance to the given type. The cast is dynamically tested for safety.
		/// </summary>
		/// <typeparam name = "TInstance">The type of the instance.</typeparam>
		/// <returns>The cast instance or null if the cast is not valid or if the reference is null</returns>
		public static TInstance SafeCastAs<TInstance> (this Id id) where TInstance : class, IManagedWrapper
		{
			return (id != null) ? ObjectiveCRuntime.CastAs<TInstance> (id) : null;
		}

		/// <summary>
		///   <para>Returns the object returned by copyWithZone:, where the zone is nil.</para>
		///   <para>Original signature is '- (id)copy'</para>
		///   <para>Available in Mac OS X v10.0 and later.</para>
		/// </summary>
		public static TInstance Copy<TInstance> (this TInstance instance) where TInstance : class, IManagedWrapper
		{
			return (instance != null) ? ObjectiveCRuntime.SendMessage<TInstance> (instance, "copy") : null;
		}

		/// <summary>
		///   <para>Returns the object returned by mutableCopyWithZone: where the zone is nil.</para>
		///   <para>Original signature is '- (id)mutableCopy'</para>
		///   <para>Available in Mac OS X v10.0 and later.</para>
		/// </summary>
		public static TInstance MutableCopy<TInstance> (this TInstance instance) where TInstance : class, IManagedWrapper
		{
			return (instance != null) ? ObjectiveCRuntime.SendMessage<TInstance> (instance, "mutableCopy") : null;
		}
	}
}