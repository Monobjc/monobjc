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

namespace Monobjc.Security
{
    public static partial class Authorization
    {
        /// <summary>
        /// <para>Retrieves side-band data such as the user name and other information gathered during evaluation of authorization.</para>
        /// <para>Original signature is 'OSStatus AuthorizationCopyInfo (  AuthorizationRef authorization,  AuthorizationString tag,  AuthorizationItemSet **info );'</para>
        /// <para>Available in Mac OS X v10.0 and later.</para>
        /// </summary>
        /// <param name="authorization">MISSING</param>
        /// <param name="tag">MISSING</param>
        /// <param name="info">MISSING</param>
        /// <returns>A result code. See “Authorization Services Result Codes.”</returns>
        public static int CopyInfo(IntPtr authorization, String tag, out IntPtr info)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(IntPtr.Size);
            Marshal.WriteIntPtr(__local1, IntPtr.Zero);
            int __result = CopyInfo_Inner(authorization, tag, __local1);
            info = Marshal.ReadIntPtr(__local1);
            Marshal.FreeHGlobal(__local1);
            return __result;
        }

        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="AuthorizationCopyInfo")]
        private static extern int CopyInfo_Inner(IntPtr authorization, String tag, IntPtr info);


        /// <summary>
        /// <para>Authorizes and preauthorizes rights.</para>
        /// <para>Original signature is 'OSStatus AuthorizationCopyRights (  AuthorizationRef authorization,  const AuthorizationRights *rights,  const AuthorizationEnvironment *environment,  AuthorizationFlags flags,  AuthorizationRights **authorizedRights );'</para>
        /// <para>Available in Mac OS X v10.0 and later.</para>
        /// </summary>
        /// <param name="authorization">MISSING</param>
        /// <param name="rights">MISSING</param>
        /// <param name="environment">MISSING</param>
        /// <param name="flags">MISSING</param>
        /// <param name="authorizedRights">MISSING</param>
        /// <returns>A result code. See “Authorization Services Result Codes.”</returns>
        public static int CopyRights(IntPtr authorization, IntPtr rights, IntPtr environment, AuthorizationFlags flags, out IntPtr authorizedRights)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(IntPtr.Size);
            Marshal.WriteIntPtr(__local1, IntPtr.Zero);
            int __result = CopyRights_Inner(authorization, rights, environment, flags, __local1);
            authorizedRights = Marshal.ReadIntPtr(__local1);
            Marshal.FreeHGlobal(__local1);
            return __result;
        }

        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="AuthorizationCopyRights")]
        private static extern int CopyRights_Inner(IntPtr authorization, IntPtr rights, IntPtr environment, AuthorizationFlags flags, IntPtr authorizedRights);


        /// <summary>
        /// <para>Creates a new authorization reference and provides an option to authorize or preauthorize rights.</para>
        /// <para>Original signature is 'OSStatus AuthorizationCreate (  const AuthorizationRights *rights,  const AuthorizationEnvironment *environment,  AuthorizationFlags flags,  AuthorizationRef *authorization );'</para>
        /// <para>Available in Mac OS X v10.0 and later.</para>
        /// </summary>
        /// <param name="rights">MISSING</param>
        /// <param name="environment">MISSING</param>
        /// <param name="flags">MISSING</param>
        /// <param name="authorization">MISSING</param>
        /// <returns>A result code. See “Authorization Services Result Codes.”</returns>
        public static int Create(IntPtr rights, IntPtr environment, AuthorizationFlags flags, out IntPtr authorization)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(IntPtr.Size);
            Marshal.WriteIntPtr(__local1, IntPtr.Zero);
            int __result = Create_Inner(rights, environment, flags, __local1);
            authorization = Marshal.ReadIntPtr(__local1);
            Marshal.FreeHGlobal(__local1);
            return __result;
        }

        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="AuthorizationCreate")]
        private static extern int Create_Inner(IntPtr rights, IntPtr environment, AuthorizationFlags flags, IntPtr authorization);


        /// <summary>
        /// <para>Internalizes the external representation of an authorization reference.</para>
        /// <para>Original signature is 'OSStatus AuthorizationCreateFromExternalForm (  const AuthorizationExternalForm *extForm,  AuthorizationRef *authorization );'</para>
        /// <para>Available in Mac OS X v10.0 and later.</para>
        /// </summary>
        /// <param name="extForm">MISSING</param>
        /// <param name="authorization">MISSING</param>
        /// <returns>A result code. See “Authorization Services Result Codes.”</returns>
        public static int CreateFromExternalForm(IntPtr extForm, out IntPtr authorization)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(IntPtr.Size);
            Marshal.WriteIntPtr(__local1, IntPtr.Zero);
            int __result = CreateFromExternalForm_Inner(extForm, __local1);
            authorization = Marshal.ReadIntPtr(__local1);
            Marshal.FreeHGlobal(__local1);
            return __result;
        }

        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="AuthorizationCreateFromExternalForm")]
        private static extern int CreateFromExternalForm_Inner(IntPtr extForm, IntPtr authorization);


        /// <summary>
        /// <para>Frees the memory associated with an authorization reference.</para>
        /// <para>Original signature is 'OSStatus AuthorizationFree (  AuthorizationRef authorization,  AuthorizationFlags flags );'</para>
        /// <para>Available in Mac OS X v10.0 and later.</para>
        /// </summary>
        /// <param name="authorization">MISSING</param>
        /// <param name="flags">MISSING</param>
        /// <returns>A result code. See “Authorization Services Result Codes.”</returns>
        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="AuthorizationFree")]
        public static extern int Free(IntPtr authorization, AuthorizationFlags flags);


        /// <summary>
        /// <para>Frees the memory associated with an authorization set.</para>
        /// <para>Original signature is 'OSStatus AuthorizationFreeItemSet (  AuthorizationItemSet *set );'</para>
        /// <para>Available in Mac OS X v10.0 and later.</para>
        /// </summary>
        /// <param name="set">MISSING</param>
        /// <returns>A result code. See “Authorization Services Result Codes.”</returns>
        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="AuthorizationFreeItemSet")]
        public static extern int FreeItemSet(IntPtr set);


        /// <summary>
        /// <para>Creates an external representation of an authorization reference.</para>
        /// <para>Original signature is 'OSStatus AuthorizationMakeExternalForm (  AuthorizationRef authorization,  AuthorizationExternalForm *extForm );'</para>
        /// <para>Available in Mac OS X v10.0 and later.</para>
        /// </summary>
        /// <param name="authorization">MISSING</param>
        /// <param name="extForm">MISSING</param>
        /// <returns>A result code. See “Authorization Services Result Codes.”</returns>
        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="AuthorizationMakeExternalForm")]
        public static extern int MakeExternalForm(IntPtr authorization, IntPtr extForm);


        /// <summary>
        /// <para>Retrieves a right definition as a dictionary.</para>
        /// <para>Original signature is 'OSStatus AuthorizationRightGet (  const char *rightName,  CFDictionaryRef *rightDefinition );'</para>
        /// <para>Available in Mac OS X v10.3 and later.</para>
        /// </summary>
        /// <param name="rightName">MISSING</param>
        /// <param name="rightDefinition">MISSING</param>
        /// <returns>A result code. See “Authorization Services Result Codes.”</returns>
        public static int RightGet(String rightName, out NSDictionary rightDefinition)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof (IntPtr)));
            Marshal.WriteIntPtr(__local1, IntPtr.Zero);
            int __result = RightGet_Inner(rightName, __local1);
            rightDefinition = ObjectiveCRuntime.GetInstance<NSDictionary>(Marshal.ReadIntPtr(__local1));
            Marshal.FreeHGlobal(__local1);
            return __result;
        }

        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="AuthorizationRightGet")]
        private static extern int RightGet_Inner(String rightName, IntPtr rightDefinition);


        /// <summary>
        /// <para>Removes a right from the policy database.</para>
        /// <para>Original signature is 'OSStatus AuthorizationRightRemove (  AuthorizationRef authRef,  const char *rightName );'</para>
        /// <para>Available in Mac OS X v10.3 and later.</para>
        /// </summary>
        /// <param name="authRef">MISSING</param>
        /// <param name="rightName">MISSING</param>
        /// <returns>A result code. See “Authorization Services Result Codes.”</returns>
        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="AuthorizationRightRemove")]
        public static extern int RightRemove(IntPtr authRef, String rightName);


        /// <summary>
        /// <para>Creates or updates a right entry in the policy database.</para>
        /// <para>Original signature is 'OSStatus AuthorizationRightSet (  AuthorizationRef authRef,  const char *rightName,  CFTypeRef rightDefinition,  CFStringRef descriptionKey,  CFBundleRef bundle,  CFStringRef localeTableName );'</para>
        /// <para>Available in Mac OS X v10.3 and later.</para>
        /// </summary>
        /// <param name="authRef">MISSING</param>
        /// <param name="rightName">MISSING</param>
        /// <param name="rightDefinition">MISSING</param>
        /// <param name="descriptionKey">MISSING</param>
        /// <param name="bundle">MISSING</param>
        /// <param name="localeTableName">MISSING</param>
        /// <returns>A result code. See “Authorization Services Result Codes.”</returns>
        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="AuthorizationRightSet")]
        public static extern int RightSet(IntPtr authRef, String rightName, IntPtr rightDefinition, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (IdMarshaler<NSString>))] NSString descriptionKey, IntPtr bundle, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (IdMarshaler<NSString>))] NSString localeTableName);


    }

    /// <summary>
    /// <para>Define valid authorization options.</para>
    /// <para>Available in Mac OS X v10.0 and later.</para>
    /// </summary>
    [GeneratedCodeAttribute("MonobjcGenerator", "4.0.0.0")]
    public enum AuthorizationFlags : uint
    {
        /// <summary>
        /// <para>If no bits are set, none of the following features are available.</para>
        /// <para>Available in Mac OS X v10.0 and later.</para>
        /// </summary>
        kAuthorizationFlagDefaults = 0,
        /// <summary>
        /// <para>If the bit specified by this mask is set, you permit the Security Server to interact with the user when necessary.</para>
        /// <para>Available in Mac OS X v10.0 and later.</para>
        /// </summary>
        kAuthorizationFlagInteractionAllowed = (1 << 0),
        /// <summary>
        /// <para>If the bit specified by this mask is set, the Security Server attempts to grant the rights requested. Once the Security Server denies one right, it ignores the remaining requested rights.</para>
        /// <para>Available in Mac OS X v10.0 and later.</para>
        /// </summary>
        kAuthorizationFlagExtendRights = (1 << 1),
        /// <summary>
        /// <para>If the bit specified by this mask and the kAuthorizationFlagExtendRights mask are set, the Security Server grants or denies rights on an individual basis and all rights are checked.</para>
        /// <para>Available in Mac OS X v10.0 and later.</para>
        /// </summary>
        kAuthorizationFlagPartialRights = (1 << 2),
        /// <summary>
        /// <para>If the bit specified by this mask is set, the Security Server revokes authorization from the process as well as from any other process that is sharing the authorization. If the bit specified by this mask is not set, the Security Server revokes authorization from the process but not from other processes that share the authorization.</para>
        /// <para>Available in Mac OS X v10.0 and later.</para>
        /// </summary>
        kAuthorizationFlagDestroyRights = (1 << 3),
        /// <summary>
        /// <para>If the bit specified by this mask is set, the Security Server preauthorizes the rights requested.</para>
        /// <para>Available in Mac OS X v10.0 and later.</para>
        /// </summary>
        kAuthorizationFlagPreAuthorize = (1 << 4),
        /// <summary>
        /// <para>Private bits. Do not use.</para>
        /// <para>Available in Mac OS X v10.0 and later.</para>
        /// </summary>
        kAuthorizationFlagNoData = (1 << 20),
    }

    /// <summary>
    /// <para>Defines values the Security Server sets in an authorization item’s flag field.</para>
    /// <para>Available in Mac OS X v10.0 and later.</para>
    /// </summary>
    [GeneratedCodeAttribute("MonobjcGenerator", "4.0.0.0")]
    [Flags]
    public enum AuthorizationRightsMask : uint
    {
        /// <summary>
        /// <para>Indicates the Security Server could not preauthorize the right.</para>
        /// <para>Available in Mac OS X v10.0 and later.</para>
        /// </summary>
        kAuthorizationFlagCanNotPreAuthorize = (1 << 0),
    }
}
