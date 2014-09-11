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
using System.Runtime.InteropServices;

namespace Monobjc.Foundation
{
	/// <summary>
	/// The Process Manager provides the cooperative multitasking environment for versions of Mac OS that preceded Mac OS X. The Process Manager controls access to shared resources and manages the scheduling and execution of applications.
	/// </summary>
	public partial class ProcessManager
	{
        /// <summary>
        /// Gets information about the current process, if any.
        /// <para>Applications can use this function to find their own process serial number. Drivers can use this function to find the process serial number of the current process. You can use the returned process serial number in other Process Manager functions.</para>
        /// <para>This function is named MacGetCurrentProcess on non Macintosh platforms and GetCurrentProcess on Macintosh computers. However, even Macintosh code can use the MacGetCurrentProcess name because a macro exists that automatically maps that call to GetCurrentProcess.</para>
        /// </summary>
        /// <param name="psn">On output, a pointer to the process serial number of the current process, that is, the one currently accessing the CPU. This application can be running in either the foreground or the background.</param>
        /// <returns>A result code.</returns>
        [DllImport("/System/Library/Frameworks/AppKit.framework/AppKit")]
        public static extern int GetCurrentProcess(out ProcessSerialNumber psn);

        /// <summary>
        /// Changes the type of the specified process.
        /// <para>You can use this call to transform a background-only application into a foreground application. A foreground application appears in the Dock (and in the Force Quit dialog) and contains a menu bar. This function does not cause the application to be brought to the front; you must call SetFrontProcess to do so.</para>
        /// </summary>
        /// <param name="psn">The serial number of the process you want to transform. You can also use the constant kCurrentProcess to refer to the current process. See ProcessSerialNumber for more information.</param>
        /// <param name="type">A constant indicating the type of transformation you want. Currently you can pass only kProcessTransformToForegroundApplication.</param>
        /// <returns>A result code.</returns>
        [DllImport("/System/Library/Frameworks/AppKit.framework/AppKit")]
        public static extern int TransformProcessType(ref ProcessSerialNumber psn, ProcessApplicationTransformState type);

        /// <summary>
        /// Moves a process to the foreground.
        /// <para>The SetFrontProcess function moves the specified process to the foreground immediately.</para>
        /// <para>If the specified process serial number is invalid or if the specified process is a background-only application, SetFrontProcess returns a nonzero result code and does not change the current foreground process.</para>
        /// </summary>
        /// <param name="psn">A pointer to a valid process serial number. You can also pass a process serial number structure containing the constant kCurrentProcess to refer to the current process. See ProcessSerialNumber for more information.</param>
        /// <returns>A result code.</returns>
        [DllImport("/System/Library/Frameworks/AppKit.framework/AppKit")]
        public static extern int SetFrontProcess(ref ProcessSerialNumber psn);
	}
	
	/// <summary>
	/// Defines the unique identifier for an open process.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public	struct ProcessSerialNumber
	{
		/// <summary>
		/// The high-order long integer of the process serial number.
		/// </summary>
		public UIntPtr highLongOfPSN;
		/// <summary>
		/// The low-order long integer of the process serial number.
		/// </summary>
		public UIntPtr lowLongOfPSN;
	}
	
	/// <summary>
	/// Specify tranformation types to be applied when calling <see cref="AppKitFramework.TransformProcessType"/>.
	/// </summary>
	public enum ProcessApplicationTransformState : uint
	{
		/// <summary>
		/// Use to convert a background-only application to a foreground application.
		/// </summary>
		kProcessTransformToForegroundApplication = 0x01
	}
}