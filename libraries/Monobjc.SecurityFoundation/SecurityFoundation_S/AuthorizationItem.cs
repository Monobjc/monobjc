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

namespace Monobjc.SecurityFoundation
{
    /// <summary>
    /// Contains information about an authorization right or the authorization environment.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct AuthorizationItem
    {
        /// <summary>
        /// The required name of the authorization right or environment data. The name of a right is something that you create. You should name rights in a style similar to Java package names. For example, "com.myOrganization.myProduct.myRight". Set this field to kAuthorizationRightExecute when requesting a right for use in the function AuthorizationExecuteWithPrivileges.
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public String name;

        /// <summary>
        /// An unsigned 32-bit integer that represents the number of bytes in the value field. Set the valueLength field to 0 if you set the value field to NULL.
        /// </summary>
        public uint valueLength;

        /// <summary>
        /// A pointer to information pertaining to the name field. For example, if the name field is set to the value represented by the constant kAuthorizationRightExecute, then set the value field to the full POSIX pathname of the tool you want to execute. In most other cases, set this field to NULL.
        /// </summary>
        public IntPtr value;

        /// <summary>
        /// Reserved option bits. Set to 0.
        /// </summary>
        public uint flags;
    }
}