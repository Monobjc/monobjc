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
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Monobjc.Properties;

namespace Monobjc
{
    /// <summary>
	///   Custom marshaller for <see cref = "Block" /> instances. This makes interop a breeze as it cuts a lot of code.
	/// </summary>
	public class BlockMarshaler : ICustomMarshaler
	{
		private static readonly BlockMarshaler INSTANCE = new BlockMarshaler ();

		/// <summary>
		///   Returns a shared instance of the custom marshaller.
		/// </summary>
		/// <param name = "cookie">A cookie string from the interop layer</param>
		/// <returns>The shared instance</returns>
		[SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
		[SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "cookie")]
		[MethodImpl(MethodImplOptions.Synchronized)]
		public static ICustomMarshaler GetInstance (String cookie)
		{
			return INSTANCE;
		}

		/// <summary>
		///   Converts the unmanaged data to managed data.
		/// </summary>
		/// <param name = "pNativeData">A pointer to the unmanaged data to be wrapped.</param>
		/// <returns>
		///   Returns the managed view of the COM data.
		/// </returns>
		public Object MarshalNativeToManaged (IntPtr pNativeData)
		{
			throw new NotSupportedException (Resources.BlockCannotBeUnmarshalled);
		}

		/// <summary>
		///   Converts the managed data to unmanaged data.
		/// </summary>
		/// <param name = "ManagedObj">The managed object to be converted.</param>
		/// <returns>
		///   Returns the COM view of the managed object.
		/// </returns>
		public IntPtr MarshalManagedToNative (Object ManagedObj)
		{
			Block block = ManagedObj as Block;
			return (block != null) ? block.NativePointer : IntPtr.Zero;
		}

		/// <summary>
		///   Performs necessary cleanup of the unmanaged data when it is no longer needed.
		/// </summary>
		/// <param name = "pNativeData">A pointer to the unmanaged data to be destroyed.</param>
		public void CleanUpNativeData (IntPtr pNativeData)
		{
		}

		/// <summary>
		///   Performs necessary cleanup of the managed data when it is no longer needed.
		/// </summary>
		/// <param name = "ManagedObj">The managed object to be destroyed.</param>
		public void CleanUpManagedData (Object ManagedObj)
		{
		}

		/// <summary>
		///   Returns the size of the native data to be marshaled.
		/// </summary>
		/// <returns>The size in bytes of the native data.</returns>
		public int GetNativeDataSize ()
		{
			return IntPtr.Size;
		}
	}
}