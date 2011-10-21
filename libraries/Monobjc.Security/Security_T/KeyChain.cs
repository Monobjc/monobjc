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
    public static partial class KeyChain
    {
#if MACOSX_10_5
        /// <summary>
        /// <para>Returns a string explaining the meaning of a security result code.</para>
        /// <para>Original signature is 'CFStringRef SecCopyErrorMessageString(  OSStatus status,  void *reserved );'</para>
        /// <para>Available in Mac OS X v10.5 and later.</para>
        /// </summary>
        /// <param name="status">MISSING</param>
        /// <param name="reserved">MISSING</param>
        /// <returns>A human-readable string describing the result, or NULL if no string is available for the specified result code. You must call the CFRelease function to release this object when you are finished using it.</returns>
        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecCopyErrorMessageString")]
        [return : MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (IdMarshaler<NSString>))]
        public static extern NSString SecCopyErrorMessageString(int status, IntPtr reserved);

#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>Adds one or more items to a keychain.</para>
        /// <para>Original signature is 'OSStatus SecItemAdd (  CFDictionaryRef attributes,  CFTypeRef *result );'</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        /// <param name="attributes">MISSING</param>
        /// <param name="result">MISSING</param>
        /// <returns>A result code. See “Keychain Services Result Codes.” Call SecCopyErrorMessageString (Mac OS X only) to get a human-readable string explaining the result.</returns>
        public static int SecItemAdd(NSDictionary attributes, out IntPtr result)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(IntPtr.Size);
            Marshal.WriteIntPtr(__local1, IntPtr.Zero);
            int __result = SecItemAdd_Inner(attributes, __local1);
            result = Marshal.ReadIntPtr(__local1);
            Marshal.FreeHGlobal(__local1);
            return __result;
        }

        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecItemAdd")]
        private static extern int SecItemAdd_Inner([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (IdMarshaler<NSDictionary>))] NSDictionary attributes, IntPtr result);

#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>Returns one or more keychain items that match a search query.</para>
        /// <para>Original signature is 'OSStatus SecItemCopyMatching (  CFDictionaryRef query,  CFTypeRef *result );'</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        /// <param name="query">MISSING</param>
        /// <param name="result">MISSING</param>
        /// <returns>A result code. See “Keychain Services Result Codes.” Call SecCopyErrorMessageString (Mac OS X only) to get a human-readable string explaining the result.</returns>
        public static int SecItemCopyMatching(NSDictionary query, out IntPtr result)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(IntPtr.Size);
            Marshal.WriteIntPtr(__local1, IntPtr.Zero);
            int __result = SecItemCopyMatching_Inner(query, __local1);
            result = Marshal.ReadIntPtr(__local1);
            Marshal.FreeHGlobal(__local1);
            return __result;
        }

        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecItemCopyMatching")]
        private static extern int SecItemCopyMatching_Inner([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (IdMarshaler<NSDictionary>))] NSDictionary query, IntPtr result);

#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>Deletes items that match a search query.</para>
        /// <para>Original signature is 'OSStatus SecItemDelete (  CFDictionaryRef query );'</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        /// <param name="query">MISSING</param>
        /// <returns>A result code. See “Keychain Services Result Codes.” Call SecCopyErrorMessageString (Mac OS X only) to get a human-readable string explaining the result.</returns>
        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecItemDelete")]
        public static extern int SecItemDelete([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (IdMarshaler<NSDictionary>))] NSDictionary query);

#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>Modifies items that match a search query.</para>
        /// <para>Original signature is 'OSStatus SecItemUpdate (  CFDictionaryRef query,  CFDictionaryRef attributesToUpdate );'</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        /// <param name="query">MISSING</param>
        /// <param name="attributesToUpdate">MISSING</param>
        /// <returns>A result code. See “Keychain Services Result Codes.” Call SecCopyErrorMessageString (Mac OS X only) to get a human-readable string explaining the result.</returns>
        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecItemUpdate")]
        public static extern int SecItemUpdate([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (IdMarshaler<NSDictionary>))] NSDictionary query, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (IdMarshaler<NSDictionary>))] NSDictionary attributesToUpdate);

#endif

        /// <summary>
        /// <para>Registers your keychain event callback function</para>
        /// <para>Original signature is 'OSStatus SecKeychainAddCallback (  SecKeychainCallback callbackFunction,  SecKeychainEventMask eventMask,  void *userContext );'</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        /// <param name="callbackFunction">MISSING</param>
        /// <param name="eventMask">MISSING</param>
        /// <param name="userContext">MISSING</param>
        /// <returns>A result code. See “Keychain Services Result Codes.” Call SecCopyErrorMessageString (Mac OS X only) to get a human-readable string explaining the result.</returns>
        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecKeychainAddCallback")]
        public static extern int SecKeychainAddCallback(SecKeychainCallback callbackFunction, SecKeychainEventMask eventMask, IntPtr userContext);


        /// <summary>
        /// <para>Adds a new generic password to a keychain.</para>
        /// <para>Original signature is 'OSStatus SecKeychainAddGenericPassword (  SecKeychainRef keychain,  UInt32 serviceNameLength,  const char *serviceName,  UInt32 accountNameLength,  const char *accountName,  UInt32 passwordLength,  const void *passwordData,  SecKeychainItemRef *itemRef );'</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        /// <param name="keychain">MISSING</param>
        /// <param name="serviceNameLength">MISSING</param>
        /// <param name="serviceName">MISSING</param>
        /// <param name="accountNameLength">MISSING</param>
        /// <param name="accountName">MISSING</param>
        /// <param name="passwordLength">MISSING</param>
        /// <param name="passwordData">MISSING</param>
        /// <param name="itemRef">MISSING</param>
        /// <returns>A result code. See “Keychain Services Result Codes.” The result code errSecNoDefaultKeychain indicates that no default keychain could be found. The result code errSecDuplicateItem indicates that you tried to add a password that already exists in the keychain. The result code errSecDataTooLarge indicates that you tried to add more data than is allowed for a structure of this type. Call SecCopyErrorMessageString (Mac OS X only) to get a human-readable string explaining the result.</returns>
        public static int SecKeychainAddGenericPassword(IntPtr keychain, uint serviceNameLength, String serviceName, uint accountNameLength, String accountName, uint passwordLength, IntPtr passwordData, out IntPtr itemRef)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(IntPtr.Size);
            Marshal.WriteIntPtr(__local1, IntPtr.Zero);
            int __result = SecKeychainAddGenericPassword_Inner(keychain, serviceNameLength, serviceName, accountNameLength, accountName, passwordLength, passwordData, __local1);
            itemRef = Marshal.ReadIntPtr(__local1);
            Marshal.FreeHGlobal(__local1);
            return __result;
        }

        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecKeychainAddGenericPassword")]
        private static extern int SecKeychainAddGenericPassword_Inner(IntPtr keychain, uint serviceNameLength, String serviceName, uint accountNameLength, String accountName, uint passwordLength, IntPtr passwordData, IntPtr itemRef);


        /// <summary>
        /// <para>Adds a new Internet password to a keychain.</para>
        /// <para>Original signature is 'OSStatus SecKeychainAddInternetPassword (  SecKeychainRef keychain,  UInt32 serverNameLength,  const char *serverName,  UInt32 securityDomainLength,  const char *securityDomain,  UInt32 accountNameLength,  const char *accountName,  UInt32 pathLength,  const char *path,  UInt16 port,  SecProtocolType protocol,  SecAuthenticationType authenticationType,  UInt32 passwordLength,  const void *passwordData,  SecKeychainItemRef *itemRef );'</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        /// <param name="keychain">MISSING</param>
        /// <param name="serverNameLength">MISSING</param>
        /// <param name="serverName">MISSING</param>
        /// <param name="securityDomainLength">MISSING</param>
        /// <param name="securityDomain">MISSING</param>
        /// <param name="accountNameLength">MISSING</param>
        /// <param name="accountName">MISSING</param>
        /// <param name="pathLength">MISSING</param>
        /// <param name="path">MISSING</param>
        /// <param name="port">MISSING</param>
        /// <param name="protocol">MISSING</param>
        /// <param name="authenticationType">MISSING</param>
        /// <param name="passwordLength">MISSING</param>
        /// <param name="passwordData">MISSING</param>
        /// <param name="itemRef">MISSING</param>
        /// <returns>A result code. See “Keychain Services Result Codes.” The result code errSecNoDefaultKeychain indicates that no default keychain could be found. The result code errSecDuplicateItem indicates that you tried to add a password that already exists in the keychain. The result code errSecDataTooLarge indicates that you tried to add more data than is allowed for a structure of this type. Call SecCopyErrorMessageString (Mac OS X only) to get a human-readable string explaining the result.</returns>
        public static int SecKeychainAddInternetPassword(IntPtr keychain, uint serverNameLength, String serverName, uint securityDomainLength, String securityDomain, uint accountNameLength, String accountName, uint pathLength, String path, UInt16 port, SecProtocolType protocol, SecAuthenticationType authenticationType, uint passwordLength, IntPtr passwordData, out IntPtr itemRef)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(IntPtr.Size);
            Marshal.WriteIntPtr(__local1, IntPtr.Zero);
            int __result = SecKeychainAddInternetPassword_Inner(keychain, serverNameLength, serverName, securityDomainLength, securityDomain, accountNameLength, accountName, pathLength, path, port, protocol, authenticationType, passwordLength, passwordData, __local1);
            itemRef = Marshal.ReadIntPtr(__local1);
            Marshal.FreeHGlobal(__local1);
            return __result;
        }

        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecKeychainAddInternetPassword")]
        private static extern int SecKeychainAddInternetPassword_Inner(IntPtr keychain, uint serverNameLength, String serverName, uint securityDomainLength, String securityDomain, uint accountNameLength, String accountName, uint pathLength, String path, UInt16 port, SecProtocolType protocol, SecAuthenticationType authenticationType, uint passwordLength, IntPtr passwordData, IntPtr itemRef);


        /// <summary>
        /// <para>Obtains tags for all possible attributes of a given item class.</para>
        /// <para>Original signature is 'OSStatus SecKeychainAttributeInfoForItemID (  SecKeychainRef keychain,  UInt32 itemID,  SecKeychainAttributeInfo **info );'</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        /// <param name="keychain">MISSING</param>
        /// <param name="itemID">MISSING</param>
        /// <param name="info">MISSING</param>
        /// <returns>A result code. See “Keychain Services Result Codes.” Call SecCopyErrorMessageString (Mac OS X only) to get a human-readable string explaining the result.</returns>
        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecKeychainAttributeInfoForItemID")]
        public static extern int SecKeychainAttributeInfoForItemID(IntPtr keychain, uint itemID, IntPtr info);


        /// <summary>
        /// <para>Retrieves the application access of a keychain.</para>
        /// <para>Original signature is 'OSStatus SecKeychainCopyAccess (  SecKeychainRef keychain,  SecAccessRef *access );'</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        /// <param name="keychain">MISSING</param>
        /// <param name="access">MISSING</param>
        /// <returns>A result code. See “Keychain Services Result Codes.” Call SecCopyErrorMessageString (Mac OS X only) to get a human-readable string explaining the result.</returns>
        public static int SecKeychainCopyAccess(IntPtr keychain, out IntPtr access)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(IntPtr.Size);
            Marshal.WriteIntPtr(__local1, IntPtr.Zero);
            int __result = SecKeychainCopyAccess_Inner(keychain, __local1);
            access = Marshal.ReadIntPtr(__local1);
            Marshal.FreeHGlobal(__local1);
            return __result;
        }

        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecKeychainCopyAccess")]
        private static extern int SecKeychainCopyAccess_Inner(IntPtr keychain, IntPtr access);


        /// <summary>
        /// <para>Retrieves a pointer to the default keychain.</para>
        /// <para>Original signature is 'OSStatus SecKeychainCopyDefault (  SecKeychainRef *keychain );'</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        /// <param name="keychain">MISSING</param>
        /// <returns>A result code. See “Keychain Services Result Codes.” The result code errSecNoDefaultKeychain indicates that there is no default keychain. Call SecCopyErrorMessageString (Mac OS X only) to get a human-readable string explaining the result.</returns>
        public static int SecKeychainCopyDefault(out IntPtr keychain)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(IntPtr.Size);
            Marshal.WriteIntPtr(__local1, IntPtr.Zero);
            int __result = SecKeychainCopyDefault_Inner(__local1);
            keychain = Marshal.ReadIntPtr(__local1);
            Marshal.FreeHGlobal(__local1);
            return __result;
        }

        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecKeychainCopyDefault")]
        private static extern int SecKeychainCopyDefault_Inner(IntPtr keychain);


        /// <summary>
        /// <para>Retrieves the default keychain from a specified preference domain.</para>
        /// <para>Original signature is 'OSStatus SecKeychainCopyDomainDefault (  SecPreferencesDomain domain,  SecKeychainRef *keychain );'</para>
        /// <para>Available in Mac OS X v10.3 and later.</para>
        /// </summary>
        /// <param name="domain">MISSING</param>
        /// <param name="keychain">MISSING</param>
        /// <returns>A result code. See “Keychain Services Result Codes.” Call SecCopyErrorMessageString (Mac OS X only) to get a human-readable string explaining the result.</returns>
        public static int SecKeychainCopyDomainDefault(SecPreferencesDomain domain, out IntPtr keychain)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(IntPtr.Size);
            Marshal.WriteIntPtr(__local1, IntPtr.Zero);
            int __result = SecKeychainCopyDomainDefault_Inner(domain, __local1);
            keychain = Marshal.ReadIntPtr(__local1);
            Marshal.FreeHGlobal(__local1);
            return __result;
        }

        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecKeychainCopyDomainDefault")]
        private static extern int SecKeychainCopyDomainDefault_Inner(SecPreferencesDomain domain, IntPtr keychain);


        /// <summary>
        /// <para>Retrieves the keychain search list for a specified preference domain.</para>
        /// <para>Original signature is 'OSStatus SecKeychainCopyDomainSearchList (  SecPreferencesDomain domain,  CFArrayRef *searchList );'</para>
        /// <para>Available in Mac OS X v10.3 and later.</para>
        /// </summary>
        /// <param name="domain">MISSING</param>
        /// <param name="searchList">MISSING</param>
        /// <returns>A result code. See “Keychain Services Result Codes.” Call SecCopyErrorMessageString (Mac OS X only) to get a human-readable string explaining the result.</returns>
        public static int SecKeychainCopyDomainSearchList(SecPreferencesDomain domain, out NSArray searchList)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof (IntPtr)));
            Marshal.WriteIntPtr(__local1, IntPtr.Zero);
            int __result = SecKeychainCopyDomainSearchList_Inner(domain, __local1);
            searchList = ObjectiveCRuntime.GetInstance<NSArray>(Marshal.ReadIntPtr(__local1));
            Marshal.FreeHGlobal(__local1);
            return __result;
        }

        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecKeychainCopyDomainSearchList")]
        private static extern int SecKeychainCopyDomainSearchList_Inner(SecPreferencesDomain domain, IntPtr searchList);


        /// <summary>
        /// <para>Retrieves a keychain search list.</para>
        /// <para>Original signature is 'OSStatus SecKeychainCopySearchList (  CFArrayRef *searchList );'</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        /// <param name="searchList">MISSING</param>
        /// <returns>A result code. See “Keychain Services Result Codes.” Call SecCopyErrorMessageString (Mac OS X only) to get a human-readable string explaining the result.</returns>
        public static int SecKeychainCopySearchList(out NSArray searchList)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof (IntPtr)));
            Marshal.WriteIntPtr(__local1, IntPtr.Zero);
            int __result = SecKeychainCopySearchList_Inner(__local1);
            searchList = ObjectiveCRuntime.GetInstance<NSArray>(Marshal.ReadIntPtr(__local1));
            Marshal.FreeHGlobal(__local1);
            return __result;
        }

        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecKeychainCopySearchList")]
        private static extern int SecKeychainCopySearchList_Inner(IntPtr searchList);


        /// <summary>
        /// <para>Obtains a keychain’s settings.</para>
        /// <para>Original signature is 'OSStatus SecKeychainCopySettings (  SecKeychainRef keychain,  SecKeychainSettings *outSettings );'</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        /// <param name="keychain">MISSING</param>
        /// <param name="outSettings">MISSING</param>
        /// <returns>A result code. See “Keychain Services Result Codes.” Call SecCopyErrorMessageString (Mac OS X only) to get a human-readable string explaining the result.</returns>
        public static int SecKeychainCopySettings(IntPtr keychain, out SecKeychainSettings outSettings)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof (IntPtr)));
            Marshal.WriteIntPtr(__local1, IntPtr.Zero);
            int __result = SecKeychainCopySettings_Inner(keychain, __local1);
            outSettings = (SecKeychainSettings) Marshal.PtrToStructure(__local1, typeof(SecKeychainSettings));
            Marshal.FreeHGlobal(__local1);
            return __result;
        }

        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecKeychainCopySettings")]
        private static extern int SecKeychainCopySettings_Inner(IntPtr keychain, IntPtr outSettings);


        /// <summary>
        /// <para>Creates an empty keychain.</para>
        /// <para>Original signature is 'OSStatus SecKeychainCreate (  const char *pathName,  UInt32 passwordLength,  const void *password,  Boolean promptUser,  SecAccessRef initialAccess,  SecKeychainRef *keychain );'</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        /// <param name="pathName">MISSING</param>
        /// <param name="passwordLength">MISSING</param>
        /// <param name="password">MISSING</param>
        /// <param name="promptUser">MISSING</param>
        /// <param name="initialAccess">MISSING</param>
        /// <param name="keychain">MISSING</param>
        /// <returns>A result code. See “Keychain Services Result Codes.” Call SecCopyErrorMessageString (Mac OS X only) to get a human-readable string explaining the result.</returns>
        public static int SecKeychainCreate(String pathName, uint passwordLength, IntPtr password, bool promptUser, IntPtr initialAccess, out IntPtr keychain)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(IntPtr.Size);
            Marshal.WriteIntPtr(__local1, IntPtr.Zero);
            int __result = SecKeychainCreate_Inner(pathName, passwordLength, password, promptUser, initialAccess, __local1);
            keychain = Marshal.ReadIntPtr(__local1);
            Marshal.FreeHGlobal(__local1);
            return __result;
        }

        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecKeychainCreate")]
        private static extern int SecKeychainCreate_Inner(String pathName, uint passwordLength, IntPtr password, bool promptUser, IntPtr initialAccess, IntPtr keychain);


        /// <summary>
        /// <para>Deletes one or more keychains from the default keychain search list, and removes the keychain itself if it is a file.</para>
        /// <para>Original signature is 'OSStatus SecKeychainDelete (  SecKeychainRef keychainOrArray );'</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        /// <param name="keychainOrArray">MISSING</param>
        /// <returns>A result code. See “Keychain Services Result Codes.” The result code errSecInvalidKeychain is returned if the specified keychain is invalid or if the value of the keychainOrArray parameter is invalid (NULL). Call SecCopyErrorMessageString (Mac OS X only) to get a human-readable string explaining the result.</returns>
        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecKeychainDelete")]
        public static extern int SecKeychainDelete(IntPtr keychainOrArray);


        /// <summary>
        /// <para>Finds the first generic password based on the attributes passed.</para>
        /// <para>Original signature is 'OSStatus SecKeychainFindGenericPassword (  CFTypeRef keychainOrArray,  UInt32 serviceNameLength,  const char *serviceName,  UInt32 accountNameLength,  const char *accountName,  UInt32 *passwordLength,  void **passwordData,  SecKeychainItemRef *itemRef );'</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        /// <param name="keychainOrArray">MISSING</param>
        /// <param name="serviceNameLength">MISSING</param>
        /// <param name="serviceName">MISSING</param>
        /// <param name="accountNameLength">MISSING</param>
        /// <param name="accountName">MISSING</param>
        /// <param name="passwordLength">MISSING</param>
        /// <param name="passwordData">MISSING</param>
        /// <param name="itemRef">MISSING</param>
        /// <returns>A result code. See “Keychain Services Result Codes.” Call SecCopyErrorMessageString (Mac OS X only) to get a human-readable string explaining the result.</returns>
        public static int SecKeychainFindGenericPassword(IntPtr keychainOrArray, uint serviceNameLength, String serviceName, uint accountNameLength, String accountName, out uint passwordLength, out IntPtr passwordData, out IntPtr itemRef)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof (uint)));
            IntPtr __local2 = Marshal.AllocHGlobal(IntPtr.Size);
            IntPtr __local3 = Marshal.AllocHGlobal(IntPtr.Size);
            Marshal.WriteIntPtr(__local2, IntPtr.Zero);
            Marshal.WriteIntPtr(__local3, IntPtr.Zero);
            int __result = SecKeychainFindGenericPassword_Inner(keychainOrArray, serviceNameLength, serviceName, accountNameLength, accountName, __local1, __local2, __local3);
            passwordLength = (uint) Marshal.ReadInt32(__local1);
            passwordData = Marshal.ReadIntPtr(__local2);
            itemRef = Marshal.ReadIntPtr(__local3);
            Marshal.FreeHGlobal(__local1);
            Marshal.FreeHGlobal(__local2);
            Marshal.FreeHGlobal(__local3);
            return __result;
        }

        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecKeychainFindGenericPassword")]
        private static extern int SecKeychainFindGenericPassword_Inner(IntPtr keychainOrArray, uint serviceNameLength, String serviceName, uint accountNameLength, String accountName, IntPtr passwordLength, IntPtr passwordData, IntPtr itemRef);


        /// <summary>
        /// <para>Finds the first Internet password based on the attributes passed.</para>
        /// <para>Original signature is 'OSStatus SecKeychainFindInternetPassword (  CFTypeRef keychainOrArray,  UInt32 serverNameLength,  const char *serverName,  UInt32 securityDomainLength,  const char *securityDomain,  UInt32 accountNameLength,  const char *accountName,  UInt32 pathLength,  const char *path,  UInt16 port,  SecProtocolType protocol,  SecAuthenticationType authenticationType,  UInt32 *passwordLength,  void **passwordData,  SecKeychainItemRef *itemRef );'</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        /// <param name="keychainOrArray">MISSING</param>
        /// <param name="serverNameLength">MISSING</param>
        /// <param name="serverName">MISSING</param>
        /// <param name="securityDomainLength">MISSING</param>
        /// <param name="securityDomain">MISSING</param>
        /// <param name="accountNameLength">MISSING</param>
        /// <param name="accountName">MISSING</param>
        /// <param name="pathLength">MISSING</param>
        /// <param name="path">MISSING</param>
        /// <param name="port">MISSING</param>
        /// <param name="protocol">MISSING</param>
        /// <param name="authenticationType">MISSING</param>
        /// <param name="passwordLength">MISSING</param>
        /// <param name="passwordData">MISSING</param>
        /// <param name="itemRef">MISSING</param>
        /// <returns>A result code. See “Keychain Services Result Codes.” Call SecCopyErrorMessageString (Mac OS X only) to get a human-readable string explaining the result.</returns>
        public static int SecKeychainFindInternetPassword(IntPtr keychainOrArray, uint serverNameLength, String serverName, uint securityDomainLength, String securityDomain, uint accountNameLength, String accountName, uint pathLength, String path, UInt16 port, SecProtocolType protocol, SecAuthenticationType authenticationType, out uint passwordLength, out IntPtr passwordData, out IntPtr itemRef)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof (uint)));
            IntPtr __local2 = Marshal.AllocHGlobal(IntPtr.Size);
            IntPtr __local3 = Marshal.AllocHGlobal(IntPtr.Size);
            Marshal.WriteIntPtr(__local2, IntPtr.Zero);
            Marshal.WriteIntPtr(__local3, IntPtr.Zero);
            int __result = SecKeychainFindInternetPassword_Inner(keychainOrArray, serverNameLength, serverName, securityDomainLength, securityDomain, accountNameLength, accountName, pathLength, path, port, protocol, authenticationType, __local1, __local2, __local3);
            passwordLength = (uint) Marshal.ReadInt32(__local1);
            passwordData = Marshal.ReadIntPtr(__local2);
            itemRef = Marshal.ReadIntPtr(__local3);
            Marshal.FreeHGlobal(__local1);
            Marshal.FreeHGlobal(__local2);
            Marshal.FreeHGlobal(__local3);
            return __result;
        }

        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecKeychainFindInternetPassword")]
        private static extern int SecKeychainFindInternetPassword_Inner(IntPtr keychainOrArray, uint serverNameLength, String serverName, uint securityDomainLength, String securityDomain, uint accountNameLength, String accountName, uint pathLength, String path, UInt16 port, SecProtocolType protocol, SecAuthenticationType authenticationType, IntPtr passwordLength, IntPtr passwordData, IntPtr itemRef);


        /// <summary>
        /// <para>Releases the memory acquired by calling the SecKeychainAttributeInfoForItemID function.</para>
        /// <para>Original signature is 'OSStatus SecKeychainFreeAttributeInfo (  SecKeychainAttributeInfo *info );'</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        /// <param name="info">MISSING</param>
        /// <returns>A result code. See “Keychain Services Result Codes.” Call SecCopyErrorMessageString (Mac OS X only) to get a human-readable string explaining the result.</returns>
        public static int SecKeychainFreeAttributeInfo(ref SecKeychainAttributeInfo info)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof (IntPtr)));
            Marshal.StructureToPtr(info, __local1, false);
            int __result = SecKeychainFreeAttributeInfo_Inner(__local1);
            info = (SecKeychainAttributeInfo) Marshal.PtrToStructure(__local1, typeof(SecKeychainAttributeInfo));
            Marshal.FreeHGlobal(__local1);
            return __result;
        }

        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecKeychainFreeAttributeInfo")]
        private static extern int SecKeychainFreeAttributeInfo_Inner(IntPtr info);


        /// <summary>
        /// <para>Determines the path of a keychain.</para>
        /// <para>Original signature is 'OSStatus SecKeychainGetPath (  SecKeychainRef keychain,  UInt32 *ioPathLength,  char *pathName );'</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        /// <param name="keychain">MISSING</param>
        /// <param name="ioPathLength">MISSING</param>
        /// <param name="pathName">MISSING</param>
        /// <returns>A result code. See “Keychain Services Result Codes.” Call SecCopyErrorMessageString (Mac OS X only) to get a human-readable string explaining the result.</returns>
        public static int SecKeychainGetPath(IntPtr keychain, out uint ioPathLength, out IntPtr pathName)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof (uint)));
            IntPtr __local2 = Marshal.AllocHGlobal(IntPtr.Size);
            Marshal.WriteIntPtr(__local2, IntPtr.Zero);
            int __result = SecKeychainGetPath_Inner(keychain, __local1, __local2);
            ioPathLength = (uint) Marshal.ReadInt32(__local1);
            pathName = Marshal.ReadIntPtr(__local2);
            Marshal.FreeHGlobal(__local1);
            Marshal.FreeHGlobal(__local2);
            return __result;
        }

        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecKeychainGetPath")]
        private static extern int SecKeychainGetPath_Inner(IntPtr keychain, IntPtr ioPathLength, IntPtr pathName);


        /// <summary>
        /// <para>Gets the current keychain preference domain.</para>
        /// <para>Original signature is 'OSStatus SecKeychainGetPreferenceDomain (  SecPreferencesDomain *domain );'</para>
        /// <para>Available in Mac OS X v10.3 and later.</para>
        /// </summary>
        /// <param name="domain">MISSING</param>
        /// <returns>A result code. See “Keychain Services Result Codes.” Call SecCopyErrorMessageString (Mac OS X only) to get a human-readable string explaining the result.</returns>
        public static int SecKeychainGetPreferenceDomain(out SecPreferencesDomain domain)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof (IntPtr)));
            Marshal.WriteIntPtr(__local1, IntPtr.Zero);
            int __result = SecKeychainGetPreferenceDomain_Inner(__local1);
            domain = (SecPreferencesDomain) Marshal.ReadInt32(__local1);
            Marshal.FreeHGlobal(__local1);
            return __result;
        }

        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecKeychainGetPreferenceDomain")]
        private static extern int SecKeychainGetPreferenceDomain_Inner(IntPtr domain);


        /// <summary>
        /// <para>Retrieves status information of a keychain.</para>
        /// <para>Original signature is 'OSStatus SecKeychainGetStatus (  SecKeychainRef keychain,  SecKeychainStatus *keychainStatus );'</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        /// <param name="keychain">MISSING</param>
        /// <param name="keychainStatus">MISSING</param>
        /// <returns>A result code. See “Keychain Services Result Codes.” The result code errSecNoSuchKeychain indicates that the specified keychain could not be found. The result code errSecInvalidKeychain indicates that the specified keychain is invalid. Call SecCopyErrorMessageString (Mac OS X only) to get a human-readable string explaining the result.</returns>
        public static int SecKeychainGetStatus(IntPtr keychain, out SecKeychainStatus keychainStatus)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof (IntPtr)));
            Marshal.WriteIntPtr(__local1, IntPtr.Zero);
            int __result = SecKeychainGetStatus_Inner(keychain, __local1);
            keychainStatus = (SecKeychainStatus) Marshal.ReadInt32(__local1);
            Marshal.FreeHGlobal(__local1);
            return __result;
        }

        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecKeychainGetStatus")]
        private static extern int SecKeychainGetStatus_Inner(IntPtr keychain, IntPtr keychainStatus);


        /// <summary>
        /// <para>Indicates whether Keychain Services functions that normally display a user interaction are allowed to do so.</para>
        /// <para>Original signature is 'OSStatus SecKeychainGetUserInteractionAllowed (  Boolean *state );'</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        /// <param name="state">MISSING</param>
        /// <returns>A result code. See “Keychain Services Result Codes.” Call SecCopyErrorMessageString (Mac OS X only) to get a human-readable string explaining the result.</returns>
        public static int SecKeychainGetUserInteractionAllowed(out bool state)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof (bool)));
            int __result = SecKeychainGetUserInteractionAllowed_Inner(__local1);
            state = (Marshal.ReadByte(__local1) != 0);
            Marshal.FreeHGlobal(__local1);
            return __result;
        }

        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecKeychainGetUserInteractionAllowed")]
        private static extern int SecKeychainGetUserInteractionAllowed_Inner(IntPtr state);


        /// <summary>
        /// <para>Determines the version of Keychain Services installed on the user’s system.</para>
        /// <para>Original signature is 'OSStatus SecKeychainGetVersion (  UInt32 *returnVers );'</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        /// <param name="returnVers">MISSING</param>
        /// <returns>A result code. See “Keychain Services Result Codes.” Call SecCopyErrorMessageString (Mac OS X only) to get a human-readable string explaining the result.</returns>
        public static int SecKeychainGetVersion(out uint returnVers)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof (uint)));
            int __result = SecKeychainGetVersion_Inner(__local1);
            returnVers = (uint) Marshal.ReadInt32(__local1);
            Marshal.FreeHGlobal(__local1);
            return __result;
        }

        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecKeychainGetVersion")]
        private static extern int SecKeychainGetVersion_Inner(IntPtr returnVers);


        /// <summary>
        /// <para>Retrieves the data and/or attributes stored in the given keychain item.</para>
        /// <para>Original signature is 'OSStatus SecKeychainItemCopyAttributesAndData (  SecKeychainItemRef itemRef,  SecKeychainAttributeInfo *info,  SecItemClass *itemClass,  SecKeychainAttributeList **attrList,  UInt32 *length,  void **outData );'</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        /// <param name="itemRef">MISSING</param>
        /// <param name="info">MISSING</param>
        /// <param name="itemClass">MISSING</param>
        /// <param name="attrList">MISSING</param>
        /// <param name="length">MISSING</param>
        /// <param name="outData">MISSING</param>
        /// <returns>A result code. See “Keychain Services Result Codes.” Call SecCopyErrorMessageString (Mac OS X only) to get a human-readable string explaining the result.</returns>
        public static int SecKeychainItemCopyAttributesAndData(IntPtr itemRef, out SecKeychainAttributeInfo info, out SecItemClass itemClass, out IntPtr attrList, out uint length, out IntPtr outData)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof (IntPtr)));
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof (IntPtr)));
            IntPtr __local3 = Marshal.AllocHGlobal(IntPtr.Size);
            IntPtr __local4 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof (uint)));
            IntPtr __local5 = Marshal.AllocHGlobal(IntPtr.Size);
            Marshal.WriteIntPtr(__local1, IntPtr.Zero);
            Marshal.WriteIntPtr(__local2, IntPtr.Zero);
            Marshal.WriteIntPtr(__local3, IntPtr.Zero);
            Marshal.WriteIntPtr(__local5, IntPtr.Zero);
            int __result = SecKeychainItemCopyAttributesAndData_Inner(itemRef, __local1, __local2, __local3, __local4, __local5);
            info = (SecKeychainAttributeInfo) Marshal.PtrToStructure(__local1, typeof(SecKeychainAttributeInfo));
            itemClass = (SecItemClass) Marshal.ReadInt32(__local2);
            attrList = Marshal.ReadIntPtr(__local3);
            length = (uint) Marshal.ReadInt32(__local4);
            outData = Marshal.ReadIntPtr(__local5);
            Marshal.FreeHGlobal(__local1);
            Marshal.FreeHGlobal(__local2);
            Marshal.FreeHGlobal(__local3);
            Marshal.FreeHGlobal(__local4);
            Marshal.FreeHGlobal(__local5);
            return __result;
        }

        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecKeychainItemCopyAttributesAndData")]
        private static extern int SecKeychainItemCopyAttributesAndData_Inner(IntPtr itemRef, IntPtr info, IntPtr itemClass, IntPtr attrList, IntPtr length, IntPtr outData);


        /// <summary>
        /// <para>Copies the data and attributes stored in the given keychain item.</para>
        /// <para>Original signature is 'OSStatus SecKeychainItemCopyContent (  SecKeychainItemRef itemRef,  SecItemClass *itemClass,  SecKeychainAttributeList *attrList,  UInt32 *length,  void **outData );'</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        /// <param name="itemRef">MISSING</param>
        /// <param name="itemClass">MISSING</param>
        /// <param name="attrList">MISSING</param>
        /// <param name="length">MISSING</param>
        /// <param name="outData">MISSING</param>
        /// <returns>A result code. See “Keychain Services Result Codes.” Call SecCopyErrorMessageString (Mac OS X only) to get a human-readable string explaining the result.</returns>
        public static int SecKeychainItemCopyContent(IntPtr itemRef, out SecItemClass itemClass, out IntPtr attrList, out uint length, out IntPtr outData)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof (IntPtr)));
            IntPtr __local2 = Marshal.AllocHGlobal(IntPtr.Size);
            IntPtr __local3 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof (uint)));
            IntPtr __local4 = Marshal.AllocHGlobal(IntPtr.Size);
            Marshal.WriteIntPtr(__local1, IntPtr.Zero);
            Marshal.WriteIntPtr(__local2, IntPtr.Zero);
            Marshal.WriteIntPtr(__local4, IntPtr.Zero);
            int __result = SecKeychainItemCopyContent_Inner(itemRef, __local1, __local2, __local3, __local4);
            itemClass = (SecItemClass) Marshal.ReadInt32(__local1);
            attrList = Marshal.ReadIntPtr(__local2);
            length = (uint) Marshal.ReadInt32(__local3);
            outData = Marshal.ReadIntPtr(__local4);
            Marshal.FreeHGlobal(__local1);
            Marshal.FreeHGlobal(__local2);
            Marshal.FreeHGlobal(__local3);
            Marshal.FreeHGlobal(__local4);
            return __result;
        }

        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecKeychainItemCopyContent")]
        private static extern int SecKeychainItemCopyContent_Inner(IntPtr itemRef, IntPtr itemClass, IntPtr attrList, IntPtr length, IntPtr outData);


#if MACOSX_10_6
        /// <summary>
        /// <para>Provides a keychain item reference, given a persistent reference.</para>
        /// <para>Original signature is 'OSStatus SecKeychainItemCopyFromPersistentReference(  CFDataRef persistentItemRef,  SecKeychainItemRef *itemRef);'</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        /// <param name="persistentItemRef">MISSING</param>
        /// <param name="itemRef">MISSING</param>
        /// <returns>A result code. See “Keychain Services Result Codes.” Call SecCopyErrorMessageString (Mac OS X only) to get a human-readable string explaining the result.</returns>
        public static int SecKeychainItemCopyFromPersistentReference(NSData persistentItemRef, out IntPtr itemRef)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(IntPtr.Size);
            Marshal.WriteIntPtr(__local1, IntPtr.Zero);
            int __result = SecKeychainItemCopyFromPersistentReference_Inner(persistentItemRef, __local1);
            itemRef = Marshal.ReadIntPtr(__local1);
            Marshal.FreeHGlobal(__local1);
            return __result;
        }

        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecKeychainItemCopyFromPersistentReference")]
        private static extern int SecKeychainItemCopyFromPersistentReference_Inner([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (IdMarshaler<NSData>))] NSData persistentItemRef, IntPtr itemRef);

#endif

        /// <summary>
        /// <para>Returns the keychain object of a given keychain item.</para>
        /// <para>Original signature is 'OSStatus SecKeychainItemCopyKeychain (  SecKeychainItemRef itemRef,  SecKeychainRef *keychainRef );'</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        /// <param name="itemRef">MISSING</param>
        /// <param name="keychainRef">MISSING</param>
        /// <returns>A result code. See “Keychain Services Result Codes.” Call SecCopyErrorMessageString (Mac OS X only) to get a human-readable string explaining the result.</returns>
        public static int SecKeychainItemCopyKeychain(IntPtr itemRef, out IntPtr keychainRef)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(IntPtr.Size);
            Marshal.WriteIntPtr(__local1, IntPtr.Zero);
            int __result = SecKeychainItemCopyKeychain_Inner(itemRef, __local1);
            keychainRef = Marshal.ReadIntPtr(__local1);
            Marshal.FreeHGlobal(__local1);
            return __result;
        }

        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecKeychainItemCopyKeychain")]
        private static extern int SecKeychainItemCopyKeychain_Inner(IntPtr itemRef, IntPtr keychainRef);


        /// <summary>
        /// <para>Copies a keychain item from one keychain to another.</para>
        /// <para>Original signature is 'OSStatus SecKeychainItemCreateCopy (  SecKeychainItemRef itemRef,  SecKeychainRef destKeychainRef,  SecAccessRef initialAccess,  SecKeychainItemRef *itemCopy );'</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        /// <param name="itemRef">MISSING</param>
        /// <param name="destKeychainRef">MISSING</param>
        /// <param name="initialAccess">MISSING</param>
        /// <param name="itemCopy">MISSING</param>
        /// <returns>A result code. See “Keychain Services Result Codes.” Call SecCopyErrorMessageString (Mac OS X only) to get a human-readable string explaining the result.</returns>
        public static int SecKeychainItemCreateCopy(IntPtr itemRef, IntPtr destKeychainRef, IntPtr initialAccess, out IntPtr itemCopy)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(IntPtr.Size);
            Marshal.WriteIntPtr(__local1, IntPtr.Zero);
            int __result = SecKeychainItemCreateCopy_Inner(itemRef, destKeychainRef, initialAccess, __local1);
            itemCopy = Marshal.ReadIntPtr(__local1);
            Marshal.FreeHGlobal(__local1);
            return __result;
        }

        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecKeychainItemCreateCopy")]
        private static extern int SecKeychainItemCreateCopy_Inner(IntPtr itemRef, IntPtr destKeychainRef, IntPtr initialAccess, IntPtr itemCopy);


        /// <summary>
        /// <para>Creates a new keychain item from the supplied parameters.</para>
        /// <para>Original signature is 'OSStatus SecKeychainItemCreateFromContent (  SecItemClass itemClass,  SecKeychainAttributeList *attrList,  UInt32 length,  const void *data,  SecKeychainRef keychainRef,  SecAccessRef initialAccess,  SecKeychainItemRef *itemRef );'</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        /// <param name="itemClass">MISSING</param>
        /// <param name="attrList">MISSING</param>
        /// <param name="length">MISSING</param>
        /// <param name="data">MISSING</param>
        /// <param name="keychainRef">MISSING</param>
        /// <param name="initialAccess">MISSING</param>
        /// <param name="itemRef">MISSING</param>
        /// <returns>A result code. See “Keychain Services Result Codes.” Call SecCopyErrorMessageString (Mac OS X only) to get a human-readable string explaining the result.</returns>
        public static int SecKeychainItemCreateFromContent(SecItemClass itemClass, out IntPtr attrList, uint length, IntPtr data, IntPtr keychainRef, IntPtr initialAccess, out IntPtr itemRef)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(IntPtr.Size);
            IntPtr __local2 = Marshal.AllocHGlobal(IntPtr.Size);
            Marshal.WriteIntPtr(__local1, IntPtr.Zero);
            Marshal.WriteIntPtr(__local2, IntPtr.Zero);
            int __result = SecKeychainItemCreateFromContent_Inner(itemClass, __local1, length, data, keychainRef, initialAccess, __local2);
            attrList = Marshal.ReadIntPtr(__local1);
            itemRef = Marshal.ReadIntPtr(__local2);
            Marshal.FreeHGlobal(__local1);
            Marshal.FreeHGlobal(__local2);
            return __result;
        }

        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecKeychainItemCreateFromContent")]
        private static extern int SecKeychainItemCreateFromContent_Inner(SecItemClass itemClass, IntPtr attrList, uint length, IntPtr data, IntPtr keychainRef, IntPtr initialAccess, IntPtr itemRef);


#if MACOSX_10_6
        /// <summary>
        /// <para>Creates a persistent reference for a keychain item.</para>
        /// <para>Original signature is 'OSStatus SecKeychainItemCreatePersistentReference(  SecKeychainItemRef itemRef,  CFDataRef *persistentItemRef);'</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        /// <param name="itemRef">MISSING</param>
        /// <param name="persistentItemRef">MISSING</param>
        /// <returns>A result code. See “Keychain Services Result Codes.” Call SecCopyErrorMessageString (Mac OS X only) to get a human-readable string explaining the result.</returns>
        public static int SecKeychainItemCreatePersistentReference(IntPtr itemRef, out NSData persistentItemRef)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof (IntPtr)));
            Marshal.WriteIntPtr(__local1, IntPtr.Zero);
            int __result = SecKeychainItemCreatePersistentReference_Inner(itemRef, __local1);
            persistentItemRef = ObjectiveCRuntime.GetInstance<NSData>(Marshal.ReadIntPtr(__local1));
            Marshal.FreeHGlobal(__local1);
            return __result;
        }

        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecKeychainItemCreatePersistentReference")]
        private static extern int SecKeychainItemCreatePersistentReference_Inner(IntPtr itemRef, IntPtr persistentItemRef);

#endif

        /// <summary>
        /// <para>Deletes a keychain item from the default keychain’s permanent data store.</para>
        /// <para>Original signature is 'OSStatus SecKeychainItemDelete (  SecKeychainItemRef itemRef );'</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        /// <param name="itemRef">MISSING</param>
        /// <returns>A result code. See “Keychain Services Result Codes.” Call SecCopyErrorMessageString (Mac OS X only) to get a human-readable string explaining the result.</returns>
        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecKeychainItemDelete")]
        public static extern int SecKeychainItemDelete(IntPtr itemRef);


        /// <summary>
        /// <para>Releases the memory used by the keychain attribute list and/or the keychain data retrieved in a call to SecKeychainItemCopyAttributesAndData.</para>
        /// <para>Original signature is 'OSStatus SecKeychainItemFreeAttributesAndData (  SecKeychainAttributeList *attrList,  void *data );'</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        /// <param name="attrList">MISSING</param>
        /// <param name="data">MISSING</param>
        /// <returns>A result code. See “Keychain Services Result Codes.” Call SecCopyErrorMessageString (Mac OS X only) to get a human-readable string explaining the result.</returns>
        public static int SecKeychainItemFreeAttributesAndData(ref SecKeychainAttributeList attrList, IntPtr data)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof (IntPtr)));
            Marshal.StructureToPtr(attrList, __local1, false);
            int __result = SecKeychainItemFreeAttributesAndData_Inner(__local1, data);
            attrList = (SecKeychainAttributeList) Marshal.PtrToStructure(__local1, typeof(SecKeychainAttributeList));
            Marshal.FreeHGlobal(__local1);
            return __result;
        }

        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecKeychainItemFreeAttributesAndData")]
        private static extern int SecKeychainItemFreeAttributesAndData_Inner(IntPtr attrList, IntPtr data);


        /// <summary>
        /// <para>Releases the memory used by the keychain attribute list and the keychain data retrieved in a call to the SecKeychainItemCopyContent function.</para>
        /// <para>Original signature is 'OSStatus SecKeychainItemFreeContent (  SecKeychainAttributeList *attrList,  void *data );'</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        /// <param name="attrList">MISSING</param>
        /// <param name="data">MISSING</param>
        /// <returns>A result code. See “Keychain Services Result Codes.” Call SecCopyErrorMessageString (Mac OS X only) to get a human-readable string explaining the result.</returns>
        public static int SecKeychainItemFreeContent(ref SecKeychainAttributeList attrList, IntPtr data)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof (IntPtr)));
            Marshal.StructureToPtr(attrList, __local1, false);
            int __result = SecKeychainItemFreeContent_Inner(__local1, data);
            attrList = (SecKeychainAttributeList) Marshal.PtrToStructure(__local1, typeof(SecKeychainAttributeList));
            Marshal.FreeHGlobal(__local1);
            return __result;
        }

        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecKeychainItemFreeContent")]
        private static extern int SecKeychainItemFreeContent_Inner(IntPtr attrList, IntPtr data);


        /// <summary>
        /// <para>Locks a keychain.</para>
        /// <para>Original signature is 'OSStatus SecKeychainLock (  SecKeychainRef keychain );'</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        /// <param name="keychain">MISSING</param>
        /// <returns>A result code. See “Keychain Services Result Codes.”The result code errSecNoSuchKeychain indicates that specified keychain could not be found. The result code errSecInvalidKeychain indicates that the specified keychain is invalid. Call SecCopyErrorMessageString (Mac OS X only) to get a human-readable string explaining the result.</returns>
        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecKeychainLock")]
        public static extern int SecKeychainLock(IntPtr keychain);


        /// <summary>
        /// <para>Locks all keychains belonging to the current user.</para>
        /// <para>Original signature is 'OSStatus SecKeychainLockAll (  void );'</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        /// <returns>A result code. See “Keychain Services Result Codes.” Call SecCopyErrorMessageString (Mac OS X only) to get a human-readable string explaining the result.</returns>
        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecKeychainLockAll")]
        public static extern int SecKeychainLockAll();


        /// <summary>
        /// <para>Opens a keychain.</para>
        /// <para>Original signature is 'OSStatus SecKeychainOpen (  const char *pathName,  SecKeychainRef *keychain );'</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        /// <param name="pathName">MISSING</param>
        /// <param name="keychain">MISSING</param>
        /// <returns>A result code. See “Keychain Services Result Codes.” Call SecCopyErrorMessageString (Mac OS X only) to get a human-readable string explaining the result.</returns>
        public static int SecKeychainOpen(String pathName, out IntPtr keychain)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(IntPtr.Size);
            Marshal.WriteIntPtr(__local1, IntPtr.Zero);
            int __result = SecKeychainOpen_Inner(pathName, __local1);
            keychain = Marshal.ReadIntPtr(__local1);
            Marshal.FreeHGlobal(__local1);
            return __result;
        }

        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecKeychainOpen")]
        private static extern int SecKeychainOpen_Inner(String pathName, IntPtr keychain);


        /// <summary>
        /// <para>Unregisters your keychain event callback function.</para>
        /// <para>Original signature is 'OSStatus SecKeychainRemoveCallback (  SecKeychainCallback callbackFunction );'</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        /// <param name="callbackFunction">MISSING</param>
        /// <returns>A result code. See “Keychain Services Result Codes.” Call SecCopyErrorMessageString (Mac OS X only) to get a human-readable string explaining the result.</returns>
        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecKeychainRemoveCallback")]
        public static extern int SecKeychainRemoveCallback(SecKeychainCallback callbackFunction);


        /// <summary>
        /// <para>Finds the next keychain item matching the given search criteria.</para>
        /// <para>Original signature is 'OSStatus SecKeychainSearchCopyNext (  SecKeychainSearchRef searchRef,  SecKeychainItemRef *itemRef );'</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        /// <param name="searchRef">MISSING</param>
        /// <param name="itemRef">MISSING</param>
        /// <returns>A result code. When there are no more items that match, errSecItemNotFound is returned. See “Keychain Services Result Codes.” Call SecCopyErrorMessageString (Mac OS X only) to get a human-readable string explaining the result.</returns>
        public static int SecKeychainSearchCopyNext(IntPtr searchRef, out IntPtr itemRef)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(IntPtr.Size);
            Marshal.WriteIntPtr(__local1, IntPtr.Zero);
            int __result = SecKeychainSearchCopyNext_Inner(searchRef, __local1);
            itemRef = Marshal.ReadIntPtr(__local1);
            Marshal.FreeHGlobal(__local1);
            return __result;
        }

        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecKeychainSearchCopyNext")]
        private static extern int SecKeychainSearchCopyNext_Inner(IntPtr searchRef, IntPtr itemRef);


        /// <summary>
        /// <para>Creates a search object matching a list of zero or more attributes.</para>
        /// <para>Original signature is 'OSStatus SecKeychainSearchCreateFromAttributes (  CFTypeRef keychainOrArray,  SecItemClass itemClass,  const SecKeychainAttributeList *attrList,  SecKeychainSearchRef *searchRef );'</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        /// <param name="keychainOrArray">MISSING</param>
        /// <param name="itemClass">MISSING</param>
        /// <param name="attrList">MISSING</param>
        /// <param name="searchRef">MISSING</param>
        /// <returns>A result code. See “Keychain Services Result Codes.” Call SecCopyErrorMessageString (Mac OS X only) to get a human-readable string explaining the result.</returns>
        public static int SecKeychainSearchCreateFromAttributes(IntPtr keychainOrArray, SecItemClass itemClass, ref SecKeychainAttributeList attrList, out IntPtr searchRef)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof (IntPtr)));
            IntPtr __local2 = Marshal.AllocHGlobal(IntPtr.Size);
            Marshal.StructureToPtr(attrList, __local1, false);
            Marshal.WriteIntPtr(__local2, IntPtr.Zero);
            int __result = SecKeychainSearchCreateFromAttributes_Inner(keychainOrArray, itemClass, __local1, __local2);
            attrList = (SecKeychainAttributeList) Marshal.PtrToStructure(__local1, typeof(SecKeychainAttributeList));
            searchRef = Marshal.ReadIntPtr(__local2);
            Marshal.FreeHGlobal(__local1);
            Marshal.FreeHGlobal(__local2);
            return __result;
        }

        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecKeychainSearchCreateFromAttributes")]
        private static extern int SecKeychainSearchCreateFromAttributes_Inner(IntPtr keychainOrArray, SecItemClass itemClass, IntPtr attrList, IntPtr searchRef);


        /// <summary>
        /// <para>Sets the application access for a keychain.</para>
        /// <para>Original signature is 'OSStatus SecKeychainSetAccess (  SecKeychainRef keychain,  SecAccessRef access );'</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        /// <param name="keychain">MISSING</param>
        /// <param name="access">MISSING</param>
        /// <returns>A result code. See “Keychain Services Result Codes.” Call SecCopyErrorMessageString (Mac OS X only) to get a human-readable string explaining the result.</returns>
        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecKeychainSetAccess")]
        public static extern int SecKeychainSetAccess(IntPtr keychain, IntPtr access);


        /// <summary>
        /// <para>Sets the default keychain.</para>
        /// <para>Original signature is 'OSStatus SecKeychainSetDefault (  SecKeychainRef keychain );'</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        /// <param name="keychain">MISSING</param>
        /// <returns>A result code. See “Keychain Services Result Codes.” The result code errSecNoSuchKeychain indicates that the specified keychain could not be found. The result code errSecInvalidKeychain indicates that the specified keychain is invalid. Call SecCopyErrorMessageString (Mac OS X only) to get a human-readable string explaining the result.</returns>
        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecKeychainSetDefault")]
        public static extern int SecKeychainSetDefault(IntPtr keychain);


        /// <summary>
        /// <para>Sets the default keychain for a specified preference domain.</para>
        /// <para>Original signature is 'OSStatus SecKeychainSetDomainDefault (  SecPreferencesDomain domain,  SecKeychainRef keychain );'</para>
        /// <para>Available in Mac OS X v10.3 and later.</para>
        /// </summary>
        /// <param name="domain">MISSING</param>
        /// <param name="keychain">MISSING</param>
        /// <returns>A result code. See “Keychain Services Result Codes.” Call SecCopyErrorMessageString (Mac OS X only) to get a human-readable string explaining the result.</returns>
        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecKeychainSetDomainDefault")]
        public static extern int SecKeychainSetDomainDefault(SecPreferencesDomain domain, IntPtr keychain);


        /// <summary>
        /// <para>Sets the keychain search list for a specified preference domain.</para>
        /// <para>Original signature is 'OSStatus SecKeychainSetDomainSearchList (  SecPreferencesDomain domain,  CFArrayRef searchList );'</para>
        /// <para>Available in Mac OS X v10.3 and later.</para>
        /// </summary>
        /// <param name="domain">MISSING</param>
        /// <param name="searchList">MISSING</param>
        /// <returns>A result code. See “Keychain Services Result Codes.” Call SecCopyErrorMessageString (Mac OS X only) to get a human-readable string explaining the result.</returns>
        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecKeychainSetDomainSearchList")]
        public static extern int SecKeychainSetDomainSearchList(SecPreferencesDomain domain, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (IdMarshaler<NSArray>))] NSArray searchList);


        /// <summary>
        /// <para>Sets the keychain preference domain.</para>
        /// <para>Original signature is 'OSStatus SecKeychainSetPreferenceDomain (  SecPreferencesDomain domain );'</para>
        /// <para>Available in Mac OS X v10.3 and later.</para>
        /// </summary>
        /// <param name="domain">MISSING</param>
        /// <returns>A result code. See “Keychain Services Result Codes.” Call SecCopyErrorMessageString (Mac OS X only) to get a human-readable string explaining the result.</returns>
        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecKeychainSetPreferenceDomain")]
        public static extern int SecKeychainSetPreferenceDomain(SecPreferencesDomain domain);


        /// <summary>
        /// <para>Specifies the list of keychains to use in the default keychain search list.</para>
        /// <para>Original signature is 'OSStatus SecKeychainSetSearchList (  CFArrayRef searchList );'</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        /// <param name="searchList">MISSING</param>
        /// <returns>A result code. See “Keychain Services Result Codes.” Call SecCopyErrorMessageString (Mac OS X only) to get a human-readable string explaining the result.</returns>
        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecKeychainSetSearchList")]
        public static extern int SecKeychainSetSearchList([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (IdMarshaler<NSArray>))] NSArray searchList);


        /// <summary>
        /// <para>Changes the settings of a keychain.</para>
        /// <para>Original signature is 'OSStatus SecKeychainSetSettings (  SecKeychainRef keychain,  const SecKeychainSettings *newSettings );'</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        /// <param name="keychain">MISSING</param>
        /// <param name="newSettings">MISSING</param>
        /// <returns>A result code. See “Keychain Services Result Codes.” Call SecCopyErrorMessageString (Mac OS X only) to get a human-readable string explaining the result.</returns>
        public static int SecKeychainSetSettings(IntPtr keychain, ref SecKeychainSettings newSettings)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof (IntPtr)));
            Marshal.StructureToPtr(newSettings, __local1, false);
            int __result = SecKeychainSetSettings_Inner(keychain, __local1);
            newSettings = (SecKeychainSettings) Marshal.PtrToStructure(__local1, typeof(SecKeychainSettings));
            Marshal.FreeHGlobal(__local1);
            return __result;
        }

        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecKeychainSetSettings")]
        private static extern int SecKeychainSetSettings_Inner(IntPtr keychain, IntPtr newSettings);


        /// <summary>
        /// <para>Enables or disables the user interface for Keychain Services functions that automatically display a user interface.</para>
        /// <para>Original signature is 'OSStatus SecKeychainSetUserInteractionAllowed (  Boolean state );'</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        /// <param name="state">MISSING</param>
        /// <returns>A result code. See “Keychain Services Result Codes.” Call SecCopyErrorMessageString (Mac OS X only) to get a human-readable string explaining the result.</returns>
        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecKeychainSetUserInteractionAllowed")]
        public static extern int SecKeychainSetUserInteractionAllowed(bool state);


        /// <summary>
        /// <para>Unlocks a keychain.</para>
        /// <para>Original signature is 'OSStatus SecKeychainUnlock (  SecKeychainRef keychain,  UInt32 passwordLength,  const void *password,  Boolean usePassword );'</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        /// <param name="keychain">MISSING</param>
        /// <param name="passwordLength">MISSING</param>
        /// <param name="password">MISSING</param>
        /// <param name="usePassword">MISSING</param>
        /// <returns>A result code. See “Keychain Services Result Codes.” The result code userCanceledErr indicates that the user pressed the Cancel button in the Unlock Keychain dialog box. The result code errSecAuthFailed indicates that authentication failed because of too many unsuccessful retries. The result code errSecInteractionRequired indicates that user interaction is required to unlock the keychain. Call SecCopyErrorMessageString (Mac OS X only) to get a human-readable string explaining the result.</returns>
        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecKeychainUnlock")]
        public static extern int SecKeychainUnlock(IntPtr keychain, uint passwordLength, IntPtr password, bool usePassword);


    }

    /// <summary>
    /// <para>Defines constants you can use to identify the type of authentication to use for an Internet password.</para>
    /// <para>Available in Mac OS X v10.2 and later.</para>
    /// </summary>
    [GeneratedCodeAttribute("MonobjcGenerator", "4.0.0.0")]
    public enum SecAuthenticationType : uint
    {
        /// <summary>
        /// <para>Specifies Windows NT LAN Manager authentication.</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        kSecAuthenticationTypeNTLM = 0x6E746C6D,
        /// <summary>
        /// <para>Specifies Microsoft Network default authentication.</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        kSecAuthenticationTypeMSN = 0x6D736E61,
        /// <summary>
        /// <para>Specifies Distributed Password authentication.</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        kSecAuthenticationTypeDPA = 0x64706161,
        /// <summary>
        /// <para>Specifies Remote Password authentication.</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        kSecAuthenticationTypeRPA = 0x72706161,
        /// <summary>
        /// <para>Specifies HTTP Basic authentication.</para>
        /// <para>Available in Mac OS X v10.3 and later.</para>
        /// </summary>
        kSecAuthenticationTypeHTTPBasic = 0x68747470,
        /// <summary>
        /// <para>Specifies HTTP Digest Access authentication.</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        kSecAuthenticationTypeHTTPDigest = 0x68747464,
        /// <summary>
        /// <para>Specifies HTML form based authentication.</para>
        /// <para>Available in Mac OS X v10.3 and later.</para>
        /// </summary>
        kSecAuthenticationTypeHTMLForm = 0x666F726D,
        /// <summary>
        /// <para>Specifies the default authentication type.</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        kSecAuthenticationTypeDefault = 0x64666C74,
#if MACOSX_10_5
        /// <summary>
        /// <para>Specifies that any authentication type is acceptable.</para>
        /// <para>When performing a search, use this value to avoid constraining your search results to a particular authentication type.</para>
        /// <para>Available in Mac OS X v10.5 and later.</para>
        /// </summary>
        kSecAuthenticationTypeAny = 0,
#endif
    }

    /// <summary>
    /// <para>Defines the keychain-related event.</para>
    /// <para>Available in Mac OS X v10.2 and later.</para>
    /// </summary>
    [GeneratedCodeAttribute("MonobjcGenerator", "4.0.0.0")]
    public enum SecKeychainEvent : uint
    {
        /// <summary>
        /// <para>Indicates a keychain was locked.</para>
        /// <para>It is impossible to distinguish between a lock event caused by an explicit request and one caused by a keychain that locked itself because of a timeout. Therefore, the pid parameter in the SecKeychainCallbackInfo structure does not contain useful information for this event. Note that when the login session terminates, all keychains become effectively locked; however, no kSecLockEvent events are generated in this case.</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        kSecLockEvent = 1,
        /// <summary>
        /// <para>Indicates a keychain was successfully unlocked.</para>
        /// <para>It is impossible to distinguish between an unlock event caused by an explicit request and one that occurred automatically because the keychain was needed to perform an operation. In either case, however, the pid parameter in the SecKeychainCallbackInfo structure does return the ID of the process whose actions caused the unlock event.</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        kSecUnlockEvent = 2,
        /// <summary>
        /// <para>Indicates an item was added to a keychain.</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        kSecAddEvent = 3,
        /// <summary>
        /// <para>Indicates an item was deleted from a keychain.</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        kSecDeleteEvent = 4,
        /// <summary>
        /// <para>Indicates a keychain item was updated.</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        kSecUpdateEvent = 5,
        /// <summary>
        /// <para>Indicates the keychain password was changed.</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        kSecPasswordChangedEvent = 6,
        /// <summary>
        /// <para>Indicates that a different keychain was specified as the default.</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        kSecDefaultChangedEvent = 9,
        /// <summary>
        /// <para>Indicates a process has accessed a keychain item’s data.</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        kSecDataAccessEvent = 10,
        /// <summary>
        /// <para>Indicates the list of keychains has changed.</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        kSecKeychainListChangedEvent = 11,
#if MACOSX_10_5
        /// <summary>
        /// <para>Indicates trust settings have changed.</para>
        /// <para>Available in Mac OS X v10.5 and later.</para>
        /// </summary>
        kSecTrustSettingsChangedEvent = 12,
#endif
    }

    /// <summary>
    /// <para>Defines bit masks for keychain event constants</para>
    /// <para>Available in Mac OS X v10.2 and later.</para>
    /// </summary>
    [GeneratedCodeAttribute("MonobjcGenerator", "4.0.0.0")]
    public enum SecKeychainEventMask : uint
    {
        /// <summary>
        /// <para>If the bit specified by this mask is set, your callback function is invoked when a keychain is locked.</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        kSecLockEventMask = 1U << (int) SecKeychainEvent.kSecLockEvent,
        /// <summary>
        /// <para>If the bit specified by this mask is set, your callback function is invoked when a keychain is unlocked.</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        kSecUnlockEventMask = 1U << (int) SecKeychainEvent.kSecUnlockEvent,
        /// <summary>
        /// <para>If the bit specified by this mask is set, your callback function is invoked when an item is added to a keychain.</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        kSecAddEventMask = 1U << (int) SecKeychainEvent.kSecAddEvent,
        /// <summary>
        /// <para>If the bit specified by this mask is set, your callback function is invoked when an item is deleted from a keychain.</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        kSecDeleteEventMask = 1U << (int) SecKeychainEvent.kSecDeleteEvent,
        /// <summary>
        /// <para>If the bit specified by this mask is set, your callback function is invoked when a keychain item is updated.</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        kSecUpdateEventMask = 1U << (int) SecKeychainEvent.kSecUpdateEvent,
        /// <summary>
        /// <para>If the bit specified by this mask is set, your callback function is invoked when the keychain password is changed.</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        kSecPasswordChangedEventMask = 1U << (int) SecKeychainEvent.kSecPasswordChangedEvent,
        /// <summary>
        /// <para>If the bit specified by this mask is set, your callback function is invoked when a different keychain is specified as the default.</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        kSecDefaultChangedEventMask = 1U << (int) SecKeychainEvent.kSecDefaultChangedEvent,
        /// <summary>
        /// <para>If the bit specified by this mask is set, your callback function is invoked when a process accesses a keychain item’s data.</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        kSecDataAccessEventMask = 1U << (int) SecKeychainEvent.kSecDataAccessEvent,
        /// <summary>
        /// <para>If the bit specified by this mask is set, your callback function is invoked when a keychain list is changed.</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        kSecKeychainListChangedMask = 1U << (int) SecKeychainEvent.kSecKeychainListChangedEvent,
#if MACOSX_10_5
        /// <summary>
        /// <para>If the bit specified by this mask is set, your callback function is invoked when there is a change in certificate trust settings.</para>
        /// <para>Available in Mac OS X v10.5 and later.</para>
        /// </summary>
        kSecTrustSettingsChangedEventMask = 1U << (int) SecKeychainEvent.kSecTrustSettingsChangedEvent,
#endif
        /// <summary>
        /// <para>If all the bits are set, your callback function is invoked whenever any event occurs.</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        kSecEveryEventMask = 0xffffffff,
    }

    /// <summary>
    /// <para>Specifies a keychain item’s attributes.</para>
    /// <para>Available in Mac OS X v10.2 and later.</para>
    /// </summary>
    [GeneratedCodeAttribute("MonobjcGenerator", "4.0.0.0")]
    public enum SecItemAttr : uint
    {
        /// <summary>
        /// <para>Identifies the creation date attribute.</para>
        /// <para>You use this tag to get a string value that represents the date the item was created, expressed in Zulu Time format ("YYYYMMDDhhmmssZ"). This is the native format for stored time values in the CDSA specification (defined as CSSM_DB_ATTRIBUTE_FORMAT_TIME_DATE in the CSSM_DB_ATTRIBUTE_FORMAT enumeration, Section 17.2.6.). When specifying the creation date as input to a function (for example, SecKeychainSearchCreateFromAttributes), you may alternatively provide a numeric value of type UInt32 or SInt64, expressed as seconds since 01 January 1904.</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        kSecCreationDateItemAttr = 0x63646174,
        /// <summary>
        /// <para>Identifies the modification date attribute.</para>
        /// <para>You use this tag to get a string value that represents the date the item was created, expressed in Zulu Time format ("YYYYMMDDhhmmssZ"). This is the native format for stored time values in the CDSA specification (defined as CSSM_DB_ATTRIBUTE_FORMAT_TIME_DATE in the CSSM_DB_ATTRIBUTE_FORMAT enumeration, Section 17.2.6.). When specifying the creation date as input to a function (for example, SecKeychainSearchCreateFromAttributes), you may alternatively provide a numeric value of type UInt32 or SInt64, expressed as seconds since 01 January 1904.</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        kSecModDateItemAttr = 0x6D646174,
        /// <summary>
        /// <para>Identifies the description attribute.</para>
        /// <para>You use this tag to set or get a string value that represents a user-visible string describing this particular kind of item, for example “disk image password”. Keychain strings should use UTF-8 encoding.</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        kSecDescriptionItemAttr = 0x64657363,
        /// <summary>
        /// <para>Identifies the comment attribute.</para>
        /// <para>You use this tag to set or get a string value that represents a user-editable string containing comments for this item. Keychain strings should use UTF-8 encoding.</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        kSecCommentItemAttr = 0x69636D74,
        /// <summary>
        /// <para>Identifies the creator attribute.</para>
        /// <para>You use this tag to set or get a value of type FourCharCode that represents the item's creator.</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        kSecCreatorItemAttr = 0x63727472,
        /// <summary>
        /// <para>Identifies the type attribute.</para>
        /// <para>You use this tag to set or get a value of type FourCharCode that represents the item’s type.</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        kSecTypeItemAttr = 0x74797065,
        /// <summary>
        /// <para>Identifies the script code attribute.</para>
        /// <para>You use this tag to set or get a value of type ScriptCode that represents the script code for all strings. Use of this attribute is deprecated; string attributes should always be stored in UTF-8 encoding.</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        kSecScriptCodeItemAttr = 0x73637270,
        /// <summary>
        /// <para>Identifies the label attribute.</para>
        /// <para>You use this tag to set or get a string value that represents a user-editable string containing the label for this item. Keychain strings should use UTF-8 encoding.</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        kSecLabelItemAttr = 0x6C61626C,
        /// <summary>
        /// <para>Identifies the invisible attribute.</para>
        /// <para>You use this tag to set or get a value of type Boolean that indicates whether the item is invisible (that is, should not be displayed).</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        kSecInvisibleItemAttr = 0x696E7669,
        /// <summary>
        /// <para>Identifies the negative attribute.</para>
        /// <para>You use this tag to set or get a value of type Boolean that indicates whether there is a valid password associated with this keychain item. This is useful if your application doesn’t want a password for some particular service to be stored in the keychain, but prefers that it always be entered by the user. The item, which is typically invisible and with zero-length data, acts as a placeholder.</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        kSecNegativeItemAttr = 0x6E656761,
        /// <summary>
        /// <para>Identifies the custom icon attribute.</para>
        /// <para>Use of this attribute is deprecated. Custom icons for keychains are not supported in Mac OS X.</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        kSecCustomIconItemAttr = 0x63757369,
        /// <summary>
        /// <para>Identifies the account attribute.</para>
        /// <para>You use this tag to set or get a string that represents the user account. It also applies to generic, Internet, and AppleShare password items. Keychain strings should use UTF-8 encoding.</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        kSecAccountItemAttr = 0x61636374,
        /// <summary>
        /// <para>Identifies the service attribute.</para>
        /// <para>You use this tag to set or get a string that represents the service associated with this item, for example, “iTools”. This is unique to generic password attributes. Keychain strings should use UTF-8 encoding.</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        kSecServiceItemAttr = 0x73766365,
        /// <summary>
        /// <para>Identifies the generic attribute.</para>
        /// <para>You use this tag to set or get a value of untyped bytes that represents a user-defined attribute. This is unique to generic password attributes.</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        kSecGenericItemAttr = 0x67656E61,
        /// <summary>
        /// <para>Identifies the security domain attribute.</para>
        /// <para>You use this tag to set or get a value that represents the Internet security domain. This is unique to Internet password attributes.</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        kSecSecurityDomainItemAttr = 0x73646D6E,
        /// <summary>
        /// <para>Identifies the server attribute.</para>
        /// <para>You use this tag to set or get a string that represents the Internet server’s domain name or IP address. This is unique to Internet password attributes. Keychain strings should use UTF-8 encoding.</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        kSecServerItemAttr = 0x73727672,
        /// <summary>
        /// <para>Identifies the authentication type attribute.</para>
        /// <para>You use this tag to set or get a value of type SecAuthenticationType that represents the Internet authentication scheme. For possible authentication values, see “Keychain Authentication Type Constants.” This is unique to Internet password attributes.</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        kSecAuthenticationTypeItemAttr = 0x61747970,
        /// <summary>
        /// <para>Identifies the port attribute.</para>
        /// <para>You use this tag to set or get a value of type UInt32 that represents the Internet port number. This is unique to Internet password attributes.</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        kSecPortItemAttr = 0x706F7274,
        /// <summary>
        /// <para>Identifies the path attribute.</para>
        /// <para>You use this tag to set or get a string value that represents the path. This is unique to Internet password attributes. Keychain strings should use UTF-8 encoding.</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        kSecPathItemAttr = 0x70617468,
        /// <summary>
        /// <para>Identifies the volume attribute.</para>
        /// <para>You use this tag to set or get a string value that represents the AppleShare volume. This is unique to AppleShare password attributes. Keychain strings should use UTF-8 encoding.</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        kSecVolumeItemAttr = 0x766C6D65,
        /// <summary>
        /// <para>Identifies the address attribute.</para>
        /// <para>You use this tag to set or get a value of type string that represents the AppleTalk zone name, or the IP or domain name that represents the server address. This is unique to AppleShare password attributes. Keychain strings should use UTF-8 encoding.</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        kSecAddressItemAttr = 0x61646472,
        /// <summary>
        /// <para>Identifies the server signature attribute.</para>
        /// <para>You use this tag to set or get a value of type SecAFPServerSignature that represents the server signature block. This is unique to AppleShare password attributes.</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        kSecSignatureItemAttr = 0x73736967,
        /// <summary>
        /// <para>Identifies the protocol attribute.</para>
        /// <para>You use this tag to set or get a value of type SecProtocolType that represents the Internet protocol. For possible protocol type values, see “Keychain Protocol Type Constants.” This is unique to AppleShare and Internet password attributes.</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        kSecProtocolItemAttr = 0x7074636C,
        /// <summary>
        /// <para>Indicates a CSSM_CERT_TYPE type.</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        kSecCertificateType = 0x63747970,
        /// <summary>
        /// <para>Indicates a CSSM_CERT_ENCODING type.</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        kSecCertificateEncoding = 0x63656E63,
        /// <summary>
        /// <para>Indicates a CSSM_CRL_TYPE type.</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        kSecCrlType = 0x63727470,
        /// <summary>
        /// <para>Indicates a CSSM_CRL_ENCODING type.</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        kSecCrlEncoding = 0x63726E63,
        /// <summary>
        /// <para>Indicates an alias.</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        kSecAlias = 0x616C6973,
    }

    /// <summary>
    /// <para>Specifies the attributes for a key item in a keychain.</para>
    /// <para>Available in Mac OS X v10.4 and later.</para>
    /// </summary>
    [GeneratedCodeAttribute("MonobjcGenerator", "4.0.0.0")]
    public enum SecKeyItemAttr : uint
    {
        /// <summary>
        /// <para>Type uint32 (CSSM_KEYCLASS); value is one of CSSM_KEYCLASS_PUBLIC_KEY, CSSM_KEYCLASS_PRIVATE_KEY or CSSM_KEYCLASS_SESSION_KEY.</para>
        /// <para>Available in Mac OS X v10.4 and later.</para>
        /// </summary>
        kSecKeyKeyClass = 0,
        /// <summary>
        /// <para>Type blob; human readable name of the key. Same as kSecLabelItemAttr for normal keychain items.</para>
        /// <para>Available in Mac OS X v10.4 and later.</para>
        /// </summary>
        kSecKeyPrintName = 1,
        /// <summary>
        /// <para>Type blob; currently unused.</para>
        /// <para>Available in Mac OS X v10.4 and later.</para>
        /// </summary>
        kSecKeyAlias = 2,
        /// <summary>
        /// <para>Type uint32; value is nonzero. This key is permanent (stored in some keychain) and is always 1.</para>
        /// <para>Available in Mac OS X v10.4 and later.</para>
        /// </summary>
        kSecKeyPermanent = 3,
        /// <summary>
        /// <para>Type uint32; value is nonzero. This key is protected by a user login, a password, or both.</para>
        /// <para>Available in Mac OS X v10.4 and later.</para>
        /// </summary>
        kSecKeyPrivate = 4,
        /// <summary>
        /// <para>Type uint32; value is nonzero. Attributes of this key can be modified.</para>
        /// <para>Available in Mac OS X v10.4 and later.</para>
        /// </summary>
        kSecKeyModifiable = 5,
        /// <summary>
        /// <para>Type blob; for private and public keys this contains the hash of the public key. This is used to associate certificates and keys. Its value matches the value of the kSecPublicKeyHashItemAttr attribute of a certificate and it's used to construct an identity from a certificate and a key. For symmetric keys this is whatever the creator of the key passed in when they generated the key.</para>
        /// <para>Available in Mac OS X v10.4 and later.</para>
        /// </summary>
        kSecKeyLabel = 6,
        /// <summary>
        /// <para>Type blob; currently unused.</para>
        /// <para>Available in Mac OS X v10.4 and later.</para>
        /// </summary>
        kSecKeyApplicationTag = 7,
        /// <summary>
        /// <para>Type data. The data points to a CSSM_GUID structure representing the module ID of the CSP owning this key.</para>
        /// <para>Available in Mac OS X v10.4 and later.</para>
        /// </summary>
        kSecKeyKeyCreator = 8,
        /// <summary>
        /// <para>Type uint32; value is a CSSM algorithm (CSSM_ALGORITHMS) representing the algorithm associated with this key.</para>
        /// <para>Available in Mac OS X v10.4 and later.</para>
        /// </summary>
        kSecKeyKeyType = 9,
        /// <summary>
        /// <para>Type uint32; value is the number of bits in this key.</para>
        /// <para>Available in Mac OS X v10.4 and later.</para>
        /// </summary>
        kSecKeyKeySizeInBits = 10,
        /// <summary>
        /// <para>Type uint32; value is the effective number of bits in this key. For example, a DES key has a key size in bits (kSecKeyKeySizeInBits) of 64 but a value for kSecKeyEffectiveKeySize of 56.</para>
        /// <para>Available in Mac OS X v10.4 and later.</para>
        /// </summary>
        kSecKeyEffectiveKeySize = 11,
        /// <summary>
        /// <para>Type CSSM_DATE. Earliest date at which this key may be used. If the value is all zeros or not present, no restriction applies.</para>
        /// <para>Available in Mac OS X v10.4 and later.</para>
        /// </summary>
        kSecKeyStartDate = 12,
        /// <summary>
        /// <para>Type CSSM_DATE. Latest date at which this key may be used. If the value is all zeros or not present, no restriction applies.</para>
        /// <para>Available in Mac OS X v10.4 and later.</para>
        /// </summary>
        kSecKeyEndDate = 13,
        /// <summary>
        /// <para>Type uint32; value is nonzero. This key cannot be wrapped with CSSM_ALGID_NONE.</para>
        /// <para>Available in Mac OS X v10.4 and later.</para>
        /// </summary>
        kSecKeySensitive = 14,
        /// <summary>
        /// <para>Type uint32; value is nonzero. This key has always been marked sensitive.</para>
        /// <para>Available in Mac OS X v10.4 and later.</para>
        /// </summary>
        kSecKeyAlwaysSensitive = 15,
        /// <summary>
        /// <para>Type uint32; value is nonzero. This key can be wrapped.</para>
        /// <para>Available in Mac OS X v10.4 and later.</para>
        /// </summary>
        kSecKeyExtractable = 16,
        /// <summary>
        /// <para>Type uint32; value is nonzero. This key was never marked extractable.</para>
        /// <para>Available in Mac OS X v10.4 and later.</para>
        /// </summary>
        kSecKeyNeverExtractable = 17,
        /// <summary>
        /// <para>Type uint32; value is nonzero. This key can be used in an encrypt operation.</para>
        /// <para>Available in Mac OS X v10.4 and later.</para>
        /// </summary>
        kSecKeyEncrypt = 18,
        /// <summary>
        /// <para>Type uint32; value is nonzero. This key can be used in a decrypt operation.</para>
        /// <para>Available in Mac OS X v10.4 and later.</para>
        /// </summary>
        kSecKeyDecrypt = 19,
        /// <summary>
        /// <para>Type uint32; value is nonzero. This key can be used in a key derivation operation.</para>
        /// <para>Available in Mac OS X v10.4 and later.</para>
        /// </summary>
        kSecKeyDerive = 20,
        /// <summary>
        /// <para>Type uint32, value is nonzero. This key can be used in a sign operation.</para>
        /// <para>Available in Mac OS X v10.4 and later.</para>
        /// </summary>
        kSecKeySign = 21,
        /// <summary>
        /// <para>Type uint32, value is nonzero. This key can be used in a verify operation.</para>
        /// <para>Available in Mac OS X v10.4 and later.</para>
        /// </summary>
        kSecKeyVerify = 22,
        /// <summary>
        /// <para>Type uint32.</para>
        /// <para>Available in Mac OS X v10.4 and later.</para>
        /// </summary>
        kSecKeySignRecover = 23,
        /// <summary>
        /// <para>Type uint32. This key can unwrap other keys.</para>
        /// <para>Available in Mac OS X v10.4 and later.</para>
        /// </summary>
        kSecKeyVerifyRecover = 24,
        /// <summary>
        /// <para>Type uint32; value is nonzero. This key can wrap other keys.</para>
        /// <para>Available in Mac OS X v10.4 and later.</para>
        /// </summary>
        kSecKeyWrap = 25,
        /// <summary>
        /// <para>Type uint32; value is nonzero. This key can unwrap other keys.</para>
        /// <para>Available in Mac OS X v10.4 and later.</para>
        /// </summary>
        kSecKeyUnwrap = 26,
    }

    /// <summary>
    /// <para>Specifies a keychain item’s class code.</para>
    /// </summary>
    [GeneratedCodeAttribute("MonobjcGenerator", "4.0.0.0")]
    public enum SecItemClass : uint
    {
        /// <summary>
        /// </summary>
        /* SecKeychainItem.h */  kSecInternetPasswordItemClass = 0x696E6574,
        /// <summary>
        /// <para>Indicates that the item is a generic password.</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        kSecGenericPasswordItemClass = 0x67656E70,
        /// <summary>
        /// <para>Indicates that the item is an AppleShare password.</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        kSecAppleSharePasswordItemClass = 0x61736870,
        /// <summary>
        /// <para>Indicates that the item is an X509 certificate.</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        kSecCertificateItemClass = 0x80000000 + 0x1000,
#if MACOSX_10_5
        /// <summary>
        /// <para>Indicates that the item is a public key of a public-private pair.</para>
        /// <para>Available in Mac OS X v10.5 and later.</para>
        /// </summary>
        kSecPublicKeyItemClass = 0x80000000 + 0x0005,
#endif
#if MACOSX_10_5
        /// <summary>
        /// <para>Indicates that the item is a private key of a public-private pair.</para>
        /// <para>Available in Mac OS X v10.5 and later.</para>
        /// </summary>
        kSecPrivateKeyItemClass = 0x80000000 + 0x0006,
#endif
#if MACOSX_10_5
        /// <summary>
        /// <para>Indicates that the item is a private key used for symmetric-key encryption.</para>
        /// <para>Available in Mac OS X v10.5 and later.</para>
        /// </summary>
        kSecSymmetricKeyItemClass = 0x80000000 + 0x0007,
#endif
    }

    /// <summary>
    /// <para>Defines values for import and export flags.</para>
    /// <para>Available in Mac OS X v10.4 and later.</para>
    /// </summary>
    [GeneratedCodeAttribute("MonobjcGenerator", "4.0.0.0")]
    public enum SecItemImportExportFlags : uint
    {
        /// <summary>
        /// <para>The exported data should have PEM armour.</para>
        /// <para>Available in Mac OS X v10.4 and later.</para>
        /// </summary>
        kSecItemPemArmour = 0x00000001,
    }

    /// <summary>
    /// <para>Defines values for the flags field of the import/export parameters.</para>
    /// <para>Available in Mac OS X v10.4 and later.</para>
    /// </summary>
    [GeneratedCodeAttribute("MonobjcGenerator", "4.0.0.0")]
    public enum SecKeyImportExportFlags : uint
    {
        /// <summary>
        /// <para>Prevents the importing of more than one private key by the SecKeychainItemImport function. If the importKeychain parameter is NULL, this bit is ignored. Otherwise, if this bit is set and there is more than one key in the incoming external representation, no items are imported to the specified keychain and the error errSecMultipleKeys is returned.</para>
        /// <para>Available in Mac OS X v10.4 and later.</para>
        /// </summary>
        kSecKeyImportOnlyOne = 0x00000001,
        /// <summary>
        /// <para>When set, the password for import or export is obtained by user prompt. (A password is sometimes referred to as a passphrase to emphasize the fact that a longer string that includes non-letter characters, such as numbers, punctuation, and spaces, is more secure than a simple word.) Otherwise, you must provide the password in the passphrase field of the SecKeyImportExportParameters structure. A user-supplied password is preferred, because it avoids having the cleartext password appear in the application’s address space at any time.</para>
        /// <para>Available in Mac OS X v10.4 and later.</para>
        /// </summary>
        kSecKeySecurePassphrase = 0x00000002,
        /// <summary>
        /// <para>When set, imported private keys have no access object attached to them. In the absence of both this bit and the accessRef field in SecKeyImportExportParameters, imported private keys are given default access controls.</para>
        /// <para>Available in Mac OS X v10.4 and later.</para>
        /// </summary>
        kSecKeyNoAccessControl = 0x00000004,
    }

    /// <summary>
    /// <para>Specifies the format of an item after export from or before import to the keychain.</para>
    /// </summary>
    [GeneratedCodeAttribute("MonobjcGenerator", "4.0.0.0")]
    public enum SecExternalFormat : uint
    {
        /// <summary>
        /// <para>When importing, indicates the format is unknown. When exporting, use the default format for the item. For asymmetric keys, the default is kSecFormatOpenSSL. For symmetric keys, the default is kSecFormatRawKey. For certificates, the default is kSecFormatX509Cert. For multiple items, the default is kSecFormatPEMSequence.</para>
        /// <para>Available in Mac OS X v10.4 and later.</para>
        /// </summary>
        kSecFormatUnknown = 0,
        /// <summary>
        /// </summary>
        /* AsymmetricKeyFormats */  kSecFormatOpenSSL,
        /// <summary>
        /// <para>OpenSSH 1 format for asymmetric (public/private) keys. OpenSSH is an OpenBSD implementation of the Secure Shell (SSH) protocol.</para>
        /// <para>Available in Mac OS X v10.4 and later.</para>
        /// </summary>
        kSecFormatSSH,
        /// <summary>
        /// <para>Format for asymmetric keys. BSAFE is a standard from RSA Security for encryption, digital signatures, and privacy.</para>
        /// <para>Available in Mac OS X v10.4 and later.</para>
        /// </summary>
        kSecFormatBSAFE,
#if MACOSX_10_5
        /// <summary>
        /// <para>OpenSSH 2 format for public keys. OpenSSH version 2 private keys are in format kSecFormatOpenSSL or kSecFormatWrappedOpenSSL. OpenSSH is an OpenBSD implementation of the Secure Shell (SSH) protocol.</para>
        /// <para>Available in Mac OS X v10.5 and later.</para>
        /// </summary>
        kSecFormatSSHv2,
#endif
        /// <summary>
        /// </summary>
        /* SymmetricKeyFormats */  kSecFormatRawKey,
        /// <summary>
        /// </summary>
        /* Formatsforwrappedsymmetricandprivatekeys */  kSecFormatWrappedPKCS8,
        /// <summary>
        /// <para>Format for wrapped symmetric and private keys. OpenSSL is an open-source toolkit for Secure Sockets Layer (SSL) and Transport Layer Security (TLS).</para>
        /// <para>Available in Mac OS X v10.4 and later.</para>
        /// </summary>
        kSecFormatWrappedOpenSSL,
        /// <summary>
        /// <para>OpenSSH 1 format for wrapped symmetric and private keys. OpenSSH is an OpenBSD implementation of the Secure Shell (SSH) protocol.</para>
        /// <para>Available in Mac OS X v10.4 and later.</para>
        /// </summary>
        kSecFormatWrappedSSH,
        /// <summary>
        /// <para>Not supported.</para>
        /// <para>Available in Mac OS X v10.4 and later.</para>
        /// </summary>
        kSecFormatWrappedLSH,
        /// <summary>
        /// </summary>
        /* Formatsforcertificates */  kSecFormatX509Cert,
        /// <summary>
        /// </summary>
        /* AggregateTypes */  kSecFormatPEMSequence,
        /// <summary>
        /// <para>Sequence of certificates, no PEM armour. PKCS7 is the Cryptographic Message Syntax Standard from RSA Security, Inc.</para>
        /// <para>Available in Mac OS X v10.4 and later.</para>
        /// </summary>
        kSecFormatPKCS7,
        /// <summary>
        /// <para>Set of certificates and private keys. PKCS12 is the Personal Information Exchange Syntax from RSA Security, Inc.</para>
        /// <para>Available in Mac OS X v10.4 and later.</para>
        /// </summary>
        kSecFormatPKCS12,
        /// <summary>
        /// <para>Set of certificates in the Netscape Certificate Sequence format.</para>
        /// <para>Available in Mac OS X v10.4 and later.</para>
        /// </summary>
        kSecFormatNetscapeCertSequence,
    }

    /// <summary>
    /// <para>Specifies the type of keychain item being imported.</para>
    /// </summary>
    [GeneratedCodeAttribute("MonobjcGenerator", "4.0.0.0")]
    public enum SecExternalItemType : uint
    {
        /// <summary>
        /// </summary>
        kSecItemTypeUnknown,
        /// <summary>
        /// </summary>
        /* caller doesn'tknowwhatthisis */  kSecItemTypePrivateKey,
        /// <summary>
        /// <para>Indicates a public key.</para>
        /// <para>Available in Mac OS X v10.4 and later.</para>
        /// </summary>
        kSecItemTypePublicKey,
        /// <summary>
        /// <para>Indicates a session key.</para>
        /// <para>Available in Mac OS X v10.4 and later.</para>
        /// </summary>
        kSecItemTypeSessionKey,
        /// <summary>
        /// <para>Indicates a certificate.</para>
        /// <para>Available in Mac OS X v10.4 and later.</para>
        /// </summary>
        kSecItemTypeCertificate,
        /// <summary>
        /// <para>Indicates a set of certificates or certificates and private keys, such as PKCS7, PKCS12, or kSecFormatPEMSequence formats (see “Keychain Item Import/Export Formats”).</para>
        /// <para>Available in Mac OS X v10.4 and later.</para>
        /// </summary>
        kSecItemTypeAggregate,
    }

    /// <summary>
    /// <para>Defines constants for the keychain preference domains.</para>
    /// <para>Available in Mac OS X v10.3 and later.</para>
    /// </summary>
    [GeneratedCodeAttribute("MonobjcGenerator", "4.0.0.0")]
    public enum SecPreferencesDomain : int
    {
        /// <summary>
        /// <para>Indicates the user preference domain preferences.</para>
        /// <para>Available in Mac OS X v10.3 and later.</para>
        /// </summary>
        kSecPreferencesDomainUser,
        /// <summary>
        /// <para>Indicates the system or daemon preference domain preferences.</para>
        /// <para>Available in Mac OS X v10.3 and later.</para>
        /// </summary>
        kSecPreferencesDomainSystem,
        /// <summary>
        /// <para>Indicates the preferences are common to everyone.</para>
        /// <para>Available in Mac OS X v10.3 and later.</para>
        /// </summary>
        kSecPreferencesDomainCommon,
        /// <summary>
        /// <para>Indicates an alternate preference domain preferences.</para>
        /// <para>Available in Mac OS X v10.3 through Mac OS X v10.3 and later.</para>
        /// </summary>
        kSecPreferencesDomainAlternate,
    }

    /// <summary>
    /// <para>Defines the protocol type associated with an AppleShare or Internet password.</para>
    /// </summary>
    [GeneratedCodeAttribute("MonobjcGenerator", "4.0.0.0")]
    public enum SecProtocolType : uint
    {
        /// <summary>
        /// <para>Indicates FTP.</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        kSecProtocolTypeFTP = 0x66747020,
        /// <summary>
        /// <para>Indicates a client side FTP account. The usage of this constant is deprecated as of Mac OS X v10.3.</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        kSecProtocolTypeFTPAccount = 0x66747061,
        /// <summary>
        /// <para>Indicates HTTP.</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        kSecProtocolTypeHTTP = 0x68747470,
        /// <summary>
        /// <para>Indicates IRC.</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        kSecProtocolTypeIRC = 0x69726320,
        /// <summary>
        /// <para>Indicates NNTP.</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        kSecProtocolTypeNNTP = 0x6E6E7470,
        /// <summary>
        /// <para>Indicates POP3.</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        kSecProtocolTypePOP3 = 0x706F7033,
        /// <summary>
        /// <para>Indicates SMTP.</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        kSecProtocolTypeSMTP = 0x736D7470,
        /// <summary>
        /// <para>Indicates SOCKS.</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        kSecProtocolTypeSOCKS = 0x736F7820,
        /// <summary>
        /// <para>Indicates IMAP.</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        kSecProtocolTypeIMAP = 0x696D6170,
        /// <summary>
        /// <para>Indicates LDAP.</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        kSecProtocolTypeLDAP = 0x6C646170,
        /// <summary>
        /// <para>Indicates AFP over AppleTalk.</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        kSecProtocolTypeAppleTalk = 0x61746C6B,
        /// <summary>
        /// <para>Indicates AFP over TCP.</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        kSecProtocolTypeAFP = 0x61667020,
        /// <summary>
        /// <para>Indicates Telnet.</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        kSecProtocolTypeTelnet = 0x74656C6E,
        /// <summary>
        /// <para>Indicates SSH.</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        kSecProtocolTypeSSH = 0x73736820,
        /// <summary>
        /// <para>Indicates FTP over TLS/SSL.</para>
        /// <para>Available in Mac OS X v10.3 and later.</para>
        /// </summary>
        kSecProtocolTypeFTPS = 0x66747073,
        /// <summary>
        /// <para>Indicates HTTP over TLS/SSL.</para>
        /// <para>Available in Mac OS X v10.3 and later.</para>
        /// </summary>
        kSecProtocolTypeHTTPS = 0x68747073,
        /// <summary>
        /// <para>Indicates HTTP proxy.</para>
        /// <para>Available in Mac OS X v10.3 and later.</para>
        /// </summary>
        kSecProtocolTypeHTTPProxy = 0x68747078,
        /// <summary>
        /// </summary>
        kSecProtocolTypeHTTPSProx = 0x68747378,
        /// <summary>
        /// <para>Indicates FTP proxy.</para>
        /// <para>Available in Mac OS X v10.3 and later.</para>
        /// </summary>
        kSecProtocolTypeFTPProxy = 0x66747078,
#if MACOSX_10_5
        /// <summary>
        /// <para>Indicates CIFS.</para>
        /// <para>Available in Mac OS X v10.5 and later.</para>
        /// </summary>
        kSecProtocolTypeCIFS = 0x63696673,
#endif
        /// <summary>
        /// <para>Indicates SMB.</para>
        /// <para>Available in Mac OS X v10.3 and later.</para>
        /// </summary>
        kSecProtocolTypeSMB = 0x736D6220,
        /// <summary>
        /// <para>Indicates RTSP.</para>
        /// <para>Available in Mac OS X v10.3 and later.</para>
        /// </summary>
        kSecProtocolTypeRTSP = 0x72747370,
        /// <summary>
        /// <para>Indicates RTSP proxy.</para>
        /// <para>Available in Mac OS X v10.3 and later.</para>
        /// </summary>
        kSecProtocolTypeRTSPProxy = 0x72747378,
        /// <summary>
        /// <para>Indicates DAAP.</para>
        /// <para>Available in Mac OS X v10.3 and later.</para>
        /// </summary>
        kSecProtocolTypeDAAP = 0x64616170,
        /// <summary>
        /// <para>Indicates Remote Apple Events.</para>
        /// <para>Available in Mac OS X v10.3 and later.</para>
        /// </summary>
        kSecProtocolTypeEPPC = 0x65707063,
        /// <summary>
        /// <para>Indicates IPP.</para>
        /// <para>Available in Mac OS X v10.3 and later.</para>
        /// </summary>
        kSecProtocolTypeIPP = 0x69707020,
        /// <summary>
        /// <para>Indicates NNTP over TLS/SSL.</para>
        /// <para>Available in Mac OS X v10.3 and later.</para>
        /// </summary>
        kSecProtocolTypeNNTPS = 0x6E747073,
        /// <summary>
        /// <para>Indicates LDAP over TLS/SSL.</para>
        /// <para>Available in Mac OS X v10.3 and later.</para>
        /// </summary>
        kSecProtocolTypeLDAPS = 0x6C647073,
        /// <summary>
        /// <para>Indicates Telnet over TLS/SSL.</para>
        /// <para>Available in Mac OS X v10.3 and later.</para>
        /// </summary>
        kSecProtocolTypeTelnetS = 0x74656C73,
        /// <summary>
        /// <para>Indicates IMAP4 over TLS/SSL.</para>
        /// <para>Available in Mac OS X v10.3 and later.</para>
        /// </summary>
        kSecProtocolTypeIMAPS = 0x696D7073,
        /// <summary>
        /// <para>Indicates IRC over TLS/SSL.</para>
        /// <para>Available in Mac OS X v10.3 and later.</para>
        /// </summary>
        kSecProtocolTypeIRCS = 0x69726373,
        /// <summary>
        /// <para>Indicates POP3 over TLS/SSL.</para>
        /// <para>Available in Mac OS X v10.3 and later.</para>
        /// </summary>
        kSecProtocolTypePOP3S = 0x706F7073,
#if MACOSX_10_5
        /// <summary>
        /// <para>Indicates CVS pserver.</para>
        /// <para>Available in Mac OS X v10.5 and later.</para>
        /// </summary>
        kSecProtocolTypeCVSpserver = 0x63767370,
#endif
#if MACOSX_10_5
        /// <summary>
        /// <para>Indicates Subversion.</para>
        /// <para>Available in Mac OS X v10.5 and later.</para>
        /// </summary>
        kSecProtocolTypeSVN = 0x73766E20,
#endif
#if MACOSX_10_5
        /// <summary>
        /// <para>Indicates that any protocol is acceptable.</para>
        /// <para>When performing a search, use this constant to avoid constraining your search results to a particular protocol.</para>
        /// <para>Available in Mac OS X v10.5 and later.</para>
        /// </summary>
        kSecProtocolTypeAny = 0,
#endif
    }

    /// <summary>
    /// <para>Defines the current status of a keychain.</para>
    /// <para>Available in Mac OS X v10.2 and later.</para>
    /// </summary>
    [GeneratedCodeAttribute("MonobjcGenerator", "4.0.0.0")]
    public enum SecKeychainStatus : uint
    {
        /// <summary>
        /// <para>Indicates the keychain is unlocked.</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        kSecUnlockStateStatus = 1,
        /// <summary>
        /// <para>Indicates the keychain is readable.</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        kSecReadPermStatus = 2,
        /// <summary>
        /// <para>Indicates the keychain is writable.</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        kSecWritePermStatus = 4,
    }
}
