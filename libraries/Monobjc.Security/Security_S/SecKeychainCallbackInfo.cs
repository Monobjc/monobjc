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
using System.Runtime.InteropServices;

namespace Monobjc.Security
{
    /// <summary>
    /// <para>Defines a pointer to a customized callback function that Keychain Services calls when a keychain event has occurred.</para>
    /// </summary>
    /// <param name="keychainEvent">The keychain event of which your application wishes to be notified. The type of event that can trigger your callback depends on the bit mask you passed in the eventMask parameter of the function SecKeychainAddCallback.</param>
    /// <param name="info">A pointer to a structure of type SecKeychainCallbackInfo. On return, the structure contains information about the keychain event that occurred. The Keychain Manager passes this information to your callback function through this parameter.</param>
    /// <param name="context">A pointer to application-defined storage that your application previously passed to the function SecKeychainAddCallback. You can use this value to perform operations such as tracking which instance of a function is operating.</param>
    /// <returns>A result code. See “Keychain Services Result Codes.”</returns>
    public delegate int SecKeychainCallback(SecKeychainEvent keychainEvent, ref SecKeychainCallbackInfo info, IntPtr context);

    /// <summary>
    ///   Contains information about a keychain event.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SecKeychainCallbackInfo
    {
        /// <summary>
        ///   The version of this structure.
        /// </summary>
        public UInt32 version;

        /// <summary>
        ///   A reference to the keychain item associated with this event, if any. Note that some events do not involve a particular keychain item.
        /// </summary>
        public IntPtr item;

        /// <summary>
        ///   A reference to the keychain in which the event occurred.
        /// </summary>
        public IntPtr keychain;

        /// <summary>
        ///   The id of the process that generated this event.
        /// </summary>
        public int pid;
    }
}