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
using System.Runtime.InteropServices;



namespace Monobjc.Security

{
    /// <summary>
    /// Contains information about keychain settings.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SecKeychainSettings
    {
        /// <summary>
        /// An unsigned 32-bit integer representing the keychain version.
        /// </summary>
        public uint version;

        /// <summary>
        /// A Boolean value indicating whether the keychain locks when the system sleeps.
        /// </summary>
        public bool lockOnSleep;

        /// <summary>
        /// A Boolean value indicating whether the keychain automatically locks after a certain period of time.
        /// </summary>
        public bool useLockInterval;

        /// <summary>
        /// An unsigned 32-bit integer representing the number of seconds before the keychain locks. If you set useLockInterval to FALSE, set lockInterval to INT_MAX to indicate that the keychain never locks.
        /// </summary>
        public uint lockInterval;
    }
}