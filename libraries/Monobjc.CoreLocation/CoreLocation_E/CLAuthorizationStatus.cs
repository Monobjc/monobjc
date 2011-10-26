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

using Monobjc;
using Monobjc.Foundation;
using System;
using System.CodeDom.Compiler;
using System.Globalization;
using System.Runtime.InteropServices;

namespace Monobjc.CoreLocation
{
#if MACOSX_10_7
    /// <summary>
    /// <para>Represents the current authorization state of the application.</para>
    /// <para>Available in Mac OS X v10.7 and later.</para>
    /// </summary>
    [GeneratedCodeAttribute("MonobjcGenerator", "4.0.0.0")]
    public enum CLAuthorizationStatus : int
    {
#if MACOSX_10_7
        /// <summary>
        /// <para>User has not yet made a choice with regards to this application</para>
        /// <para>Available in Mac OS X v10.7 and later.</para>
        /// </summary>
        kCLAuthorizationStatusNotDetermined = 0,
#endif
#if MACOSX_10_7
        /// <summary>
        /// <para>This application is not authorized to use location services.  Due to active restrictions on location services, the user cannot change this status, and may not have personally denied authorization</para>
        /// <para>Available in Mac OS X v10.7 and later.</para>
        /// </summary>
        kCLAuthorizationStatusRestricted,
#endif
#if MACOSX_10_7
        /// <summary>
        /// <para>User has explicitly denied authorization for this application, or location services are disabled in Settings</para>
        /// <para>Available in Mac OS X v10.7 and later.</para>
        /// </summary>
        kCLAuthorizationStatusDenied,
#endif
#if MACOSX_10_7
        /// <summary>
        /// <para>User has authorized this application to use location services</para>
        /// <para>Available in Mac OS X v10.7 and later.</para>
        /// </summary>
        kCLAuthorizationStatusAuthorized,
#endif
    }
#endif
}