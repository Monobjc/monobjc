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
namespace Monobjc.ScriptingBridge
{
#if MACOSX_10_5
	/// <summary>
	/// <para>Specify how to launch an application.</para>
	/// <para>Available in Mac OS X v10.5 and later.</para>
	/// </summary>
	public enum LSLaunchFlags : uint
	{
		/// <summary>
		/// Defaults = open, async, use Info.plist, start Classic
		/// </summary>
		kLSLaunchDefaults = 0x00000001,
		/// <summary>
		///  Print items instead of open them
		/// </summary>
		kLSLaunchAndPrint = 0x00000002,
		kLSLaunchReserved2 = 0x00000004,
		kLSLaunchReserved3 = 0x00000008,
		kLSLaunchReserved4 = 0x00000010,
		kLSLaunchReserved5 = 0x00000020,
		/// <summary>
		/// Report launch/open failures in the UI
		/// </summary>
		kLSLaunchAndDisplayErrors = 0x00000040,
		/// <summary>
		/// /Causes launch to fail if target is background-only.
		/// </summary>
		kLSLaunchInhibitBGOnly = 0x00000080,
		/// <summary>
		/// Do not add app or documents to recents menus.
		/// </summary>
		kLSLaunchDontAddToRecents = 0x00000100,
		/// <summary>
		/// Do not bring new app to the foreground.
		/// </summary>
		kLSLaunchDontSwitch = 0x00000200,
		/// <summary>
		/// Use Info.plist to determine launch parameters
		/// </summary>
		kLSLaunchNoParams = 0x00000800,
		/// <summary>
		/// Asynchronous launch; return as soon as the app starts launching.
		/// </summary>
		kLSLaunchAsync = 0x00010000,
		/// <summary>
		/// Start up Classic environment if required for app.
		/// </summary>
		kLSLaunchStartClassic = 0x00020000,
		/// <summary>
		/// Force app to launch in Classic environment.
		/// </summary>
		kLSLaunchInClassic = 0x00040000,
		/// <summary>
		/// Instantiate app even if it is already running.
		/// </summary>
		kLSLaunchNewInstance = 0x00080000,
		/// <summary>
		/// Send child a "hide" request as soon as it checks in.
		/// </summary>
		kLSLaunchAndHide = 0x00100000,
		/// <summary>
		/// Hide all other apps when the app checks in.
		/// </summary>
		kLSLaunchAndHideOthers = 0x00200000,
		/// <summary>
		/// Mark items to be opened as untrusted
		/// </summary>
		kLSLaunchHasUntrustedContents = 0x00400000
	}
#endif
}
