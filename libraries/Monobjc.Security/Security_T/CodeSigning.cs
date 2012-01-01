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

using Monobjc;
using Monobjc.Foundation;
using System;
using System.CodeDom.Compiler;
using System.Globalization;
using System.Runtime.InteropServices;

namespace Monobjc.Security
{
    public static partial class CodeSigning
    {
#if MACOSX_10_6
        /// <summary>
        /// <para>The guest code object (SecGuestRef) for that guest. This object plus the process ID (kSecGuestAttributePid) uniquely identify the guest.</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        public static readonly NSString kSecGuestAttributeCanonical = ObjectiveCRuntime.GetExtern<NSString>("Security", "kSecGuestAttributeCanonical");
#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>A CFDataRef object containing the SHA-1 hash of the code directory.</para>
        /// <para>This hash can be used as a unique identifier to recognize this specific code in the future. This identifier is tied to the current version of the code, unlike the kSecCodeInfoIdentifier identifier, which remains stable across developer-approved updates. If you are not passing this hash in the attribute dictionary when you call the SecHostCreateGuest function, then you must pass the kSecCSGenerateGuestHash flag to the function as well.</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        public static readonly NSString kSecGuestAttributeHash = ObjectiveCRuntime.GetExtern<NSString>("Security", "kSecGuestAttributeHash");
#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>Not implemented.</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        public static readonly NSString kSecGuestAttributeMachPort = ObjectiveCRuntime.GetExtern<NSString>("Security", "kSecGuestAttributeMachPort");
#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>An integer of type pid_t representing a process ID (PID), usually of the kernel’s guest.</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        public static readonly NSString kSecGuestAttributePid = ObjectiveCRuntime.GetExtern<NSString>("Security", "kSecGuestAttributePid");
#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>A CFNumber representing the CPU type under which the guest code is designed to run. See the ARCH(3) manual page for a list of possible CPU types.</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        public static readonly NSString kSecGuestAttributeArchitecture = ObjectiveCRuntime.GetExtern<NSString>("Security", "kSecGuestAttributeArchitecture");
#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>ACFNumber representing the CPU subtype under which the guest code is designed to run. See the ARCH(3) manual page for a list of possible CPU subtypes.</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        public static readonly NSString kSecGuestAttributeSubarchitecture = ObjectiveCRuntime.GetExtern<NSString>("Security", "kSecGuestAttributeSubarchitecture");
#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>The certificate chain of the signing certificate as seen by the system.</para>
        /// <para>A CFArrayRef array of SecCertificateRef objects that the system uses to process the signature. Absent for ad-hoc signed code. May be partial or absent in the case of error.</para>
        /// <para>Specify the kSecCSSigningInformation flag to get this information.</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        public static readonly NSString kSecCodeInfoCertificates = ObjectiveCRuntime.GetExtern<NSString>("Security", "kSecCodeInfoCertificates");
#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>A list of all files in the code that may have been modified by the process of signing it.</para>
        /// <para>A CFArrayRef array of CFURLRef objects. Files not in this list have not been touched by the signing operation.</para>
        /// <para>Specify the kSecCSContentInformation flag to get this information.</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        public static readonly NSString kSecCodeInfoChangedFiles = ObjectiveCRuntime.GetExtern<NSString>("Security", "kSecCodeInfoChangedFiles");
#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>The CMS cryptographic object that secures the code signature.</para>
        /// <para>A CFDataRef object. Empty for ad-hoc signed code.</para>
        /// <para>Specify the kSecCSSigningInformation flag to get this information.</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        public static readonly NSString kSecCodeInfoCMS = ObjectiveCRuntime.GetExtern<NSString>("Security", "kSecCodeInfoCMS");
#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>The designated requirement of the code.</para>
        /// <para>A SecRequirementRef object. If this object is identical to the one returned by the kSecCodeInfoImplicitDesignatedRequirement key, then there is no explicit designated requirement and the designated requirement in use was generated by the system.</para>
        /// <para>Specify the kSecCSRequirementInformation flag to get this information.</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        public static readonly NSString kSecCodeInfoDesignatedRequirement = ObjectiveCRuntime.GetExtern<NSString>("Security", "kSecCodeInfoDesignatedRequirement");
#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>The embedded entitlement blob of the code, if any.</para>
        /// <para>A CFDataRef object.</para>
        /// <para>Specify the kSecCSRequirementInformation flag to get this information.</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        public static readonly NSString kSecCodeInfoEntitlements = ObjectiveCRuntime.GetExtern<NSString>("Security", "kSecCodeInfoEntitlements");
#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>The type and format of the code in a form suitable for display to a knowledgeable user.</para>
        /// <para>A CFStringRef object.</para>
        /// <para>This is generic information returned regardless of which Signing Information flags are passed.</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        public static readonly NSString kSecCodeInfoFormat = ObjectiveCRuntime.GetExtern<NSString>("Security", "kSecCodeInfoFormat");
#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>The signing identifier sealed into the signature.</para>
        /// <para>A CFStringRef object. Absent for unsigned code.</para>
        /// <para>This is generic information returned regardless of which Signing Information flags are passed.</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        public static readonly NSString kSecCodeInfoIdentifier = ObjectiveCRuntime.GetExtern<NSString>("Security", "kSecCodeInfoIdentifier");
#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>The designated requirement (DR) that the system generated—or would have generated—for the code in the absence of an explicitly-declared DR.</para>
        /// <para>A SecRequirementRef object. The actual designated requirement is returned by the kSecCodeInfoDesignatedRequirement key. If the DR was implicitly generated by the system, the two values are the same; you can use this fact to test for an explicit DR.</para>
        /// <para>Specify the kSecCSRequirementInformation flag to get this information.</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        public static readonly NSString kSecCodeInfoImplicitDesignatedRequirement = ObjectiveCRuntime.GetExtern<NSString>("Security", "kSecCodeInfoImplicitDesignatedRequirement");
#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>A URL locating the main executable file of the code.</para>
        /// <para>A CFURLRef object. For single files, the URL locates the file itself. For bundles, it locates the main executable as identified by the bundle’s Info.plist file.</para>
        /// <para>This is generic information returned regardless of which Signing Information flags are passed.</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        public static readonly NSString kSecCodeInfoMainExecutable = ObjectiveCRuntime.GetExtern<NSString>("Security", "kSecCodeInfoMainExecutable");
#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>An information dictionary containing the contents of the secured Info.plist file as seen by Code Signing Services.</para>
        /// <para>A CFDictionaryRef object. Absent if no information property list (Info.plist) file is known to Code Signing Services. Note that this is not necessarily the same dictionary as the one that would be returned by a CFBundle function such as CFBundleCopyInfoDictionaryForURL, because CFBundle is free to add entries to the information property list).</para>
        /// <para>This is generic information returned regardless of which Signing Information flags are passed.</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        public static readonly NSString kSecCodeInfoPList = ObjectiveCRuntime.GetExtern<NSString>("Security", "kSecCodeInfoPList");
#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>The internal requirements of the code as a text string in canonical syntax.</para>
        /// <para>A CFStringRef object. If there is an explicit designated requirement, then it’s included in this text string.</para>
        /// <para>Specify the kSecCSRequirementInformation flag to get this information.</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        public static readonly NSString kSecCodeInfoRequirements = ObjectiveCRuntime.GetExtern<NSString>("Security", "kSecCodeInfoRequirements");
#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>The internal requirements of the code as a binary blob.</para>
        /// <para>A CFDataRef object. If there is an explicit designated requirement, then it’s included in this data blob.</para>
        /// <para>Specify the kSecCSRequirementInformation flag to get this information.</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        public static readonly NSString kSecCodeInfoRequirementData = ObjectiveCRuntime.GetExtern<NSString>("Security", "kSecCodeInfoRequirementData");
#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>The source of the code signature used for the code object in a format suitable to be shown in informational displays: Signatures can be embedded in the application, they can be detached signatures that have been explicitly attached to the code, or they can come from a system database.</para>
        /// <para>A CFStringRef object. This string is for display purposes only; do not rely on the precise value returned.</para>
        /// <para>This is generic information returned regardless of which Signing Information flags are passed.</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        public static readonly NSString kSecCodeInfoSource = ObjectiveCRuntime.GetExtern<NSString>("Security", "kSecCodeInfoSource");
#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>Code status flags for the running code (see “Code Status Flags”).</para>
        /// <para>A CFNumberRef object. This is a snapshot taken at the time the function is executed and may be out of date by the time you examine it. Note, however, that some flag values cannot be changed and are therefore permanently reliable.</para>
        /// <para>Specify the kSecCSDynamicInformation flag to get this information.</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        public static readonly NSString kSecCodeInfoStatus = ObjectiveCRuntime.GetExtern<NSString>("Security", "kSecCodeInfoStatus");
#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>The signing date embedded in the code signature.</para>
        /// <para>A CFDateRef object. Note that a signer is able to omit this date or pre-date it. Therefore, this is not necessarily the date the code was actually signed; however, you do know that this is the date the signer wanted you to see. Ad-hoc signatures never have secured signing dates.</para>
        /// <para>Specify the kSecCSSigningInformation flag to get this information.</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        public static readonly NSString kSecCodeInfoTime = ObjectiveCRuntime.GetExtern<NSString>("Security", "kSecCodeInfoTime");
#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>The trust object the system uses to evaluate the validity of the code's signature.</para>
        /// <para>A retained SecTrustRef object. You may use SecTrust functions (see Certificate, Key, and Trust Services Reference to extract detailed information, particularly for reasons why certificate validation may have failed. Because this object may continue to be used for further evaluations of the code signature, if you make any changes to it, the behavior of the SecTrust fuctions is undefined.</para>
        /// <para>Specify the kSecCSSigningInformation flag to get this information.</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        public static readonly NSString kSecCodeInfoTrust = ObjectiveCRuntime.GetExtern<NSString>("Security", "kSecCodeInfoTrust");
#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>A binary number that uniquely identifies static code.</para>
        /// <para>A CFDataRef object. This identifier can be used to recognize this specific code in the future. This identifier is tied to the current version of the code, unlike the kSecCodeInfoIdentifier identifier, which remains stable across developer-approved updates. The kSecCodeInfoUnique identifier is currently the SHA-1 hash of the code directory; however, future versions of the system may use a different algorithm for newly signed code. In any case, the identifier for already-signed code will not change.</para>
        /// <para>This is generic information returned regardless of which Signing Information flags are passed.</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        public static readonly NSString kSecCodeInfoUnique = ObjectiveCRuntime.GetExtern<NSString>("Security", "kSecCodeInfoUnique");
#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>invalid resource selection pattern encountered.</para>
        /// <para>A CFStringRef object containing a regular expression that’s part of a resource specification that did not parse correctly. A resource specification is an information property list (Info.plist file) that says which files are resources and which are not. This error is returned if any part of the resource specification can’t be parsed.</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        public static readonly NSString kSecCFErrorPattern = ObjectiveCRuntime.GetExtern<NSString>("Security", "kSecCFErrorPattern");
#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>Invalid component in resource seal (CodeResources file).</para>
        /// <para>A CFTypeRef containing the part of the resource seal that had a problem. The CodeResources file that gets generated as part of the code signing process serves as the bundle’s seal. This file is a CFDictionary that contains a listing of all the files found within your bundle coupled with their respective hash values and a set of rule definitions. The type of object returned depends on which item in the dictionary had a problem. See Mac OS X Code Signing In Depth for more information on the CodeResources file.</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        public static readonly NSString kSecCFErrorResourceSeal = ObjectiveCRuntime.GetExtern<NSString>("Security", "kSecCFErrorResourceSeal");
#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>Unsealed resource found.</para>
        /// <para>A CFURLRef object pointing to the resource on disk that is not included in the signed resources for the code.</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        public static readonly NSString kSecCFErrorResourceAdded = ObjectiveCRuntime.GetExtern<NSString>("Security", "kSecCFErrorResourceAdded");
#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>Modified resource found.</para>
        /// <para>A CFURLRef object pointing to the resource on disk that has been altered.</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        public static readonly NSString kSecCFErrorResourceAltered = ObjectiveCRuntime.GetExtern<NSString>("Security", "kSecCFErrorResourceAltered");
#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>A nonoptional sealed resource is missing</para>
        /// <para>A CFURLRef object indicating the URL of the missing resource as it is specified in the CodeResources file.</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        public static readonly NSString kSecCFErrorResourceMissing = ObjectiveCRuntime.GetExtern<NSString>("Security", "kSecCFErrorResourceMissing");
#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>The Info.plist dictionary or other component has been found to be invalid.</para>
        /// <para>A CFTypeRef object identifying the invalid component or key in the dictionary.</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        public static readonly NSString kSecCFErrorInfoPlist = ObjectiveCRuntime.GetExtern<NSString>("Security", "kSecCFErrorInfoPlist");
#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>Guest attribute not accepted.</para>
        /// <para>A CFTypeRef object containing an attribute passed to the SecHostCreateGuest or SecHostSetGuestStatus function that is unrecognized or that contains a value of the wrong type.</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        public static readonly NSString kSecCFErrorGuestAttributes = ObjectiveCRuntime.GetExtern<NSString>("Security", "kSecCFErrorGuestAttributes");
#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>Compilation error for the code requirement source.</para>
        /// <para>A CFStringRef containing a compilation error generated by the parser when the SecRequirementCreateWithStringAndErrors function is processing a code requirement string.</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        public static readonly NSString kSecCFErrorRequirementSyntax = ObjectiveCRuntime.GetExtern<NSString>("Security", "kSecCFErrorRequirementSyntax");
#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>Performs dynamic validation of signed code.</para>
        /// <para>Original signature is 'OSStatus SecCodeCheckValidity (  SecCodeRef code,  SecCSFlags flags,  SecRequirementRef requirement );'</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        /// <param name="code">MISSING</param>
        /// <param name="flags">MISSING</param>
        /// <param name="requirement">MISSING</param>
        /// <returns>A result code; see “Result Codes.”</returns>
        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecCodeCheckValidity")]
        public static extern int SecCodeCheckValidity(IntPtr code, SecCSFlags flags, IntPtr requirement);

#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>Performs dynamic validation of signed code and returns detailed error information in the case of failure.</para>
        /// <para>Original signature is 'OSStatus SecCodeCheckValidityWithErrors (  SecCodeRef code,  SecCSFlags flags,  SecRequirementRef requirement,  CFErrorRef *errors );'</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        /// <param name="code">MISSING</param>
        /// <param name="flags">MISSING</param>
        /// <param name="requirement">MISSING</param>
        /// <param name="errors">MISSING</param>
        /// <returns>A result code; see “Result Codes.”</returns>
        public static int SecCodeCheckValidityWithErrors(IntPtr code, SecCSFlags flags, IntPtr requirement, out NSError errors)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof (IntPtr)));
            Marshal.WriteIntPtr(__local1, IntPtr.Zero);
            int __result = SecCodeCheckValidityWithErrors_Inner(code, flags, requirement, __local1);
            errors = ObjectiveCRuntime.GetInstance<NSError>(Marshal.ReadIntPtr(__local1));
            Marshal.FreeHGlobal(__local1);
            return __result;
        }

        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecCodeCheckValidityWithErrors")]
        private static extern int SecCodeCheckValidityWithErrors_Inner(IntPtr code, SecCSFlags flags, IntPtr requirement, IntPtr errors);

#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>Retrieves the designated code requirement of signed code.</para>
        /// <para>Original signature is 'OSStatus SecCodeCopyDesignatedRequirement (  SecStaticCodeRef code,  SecCSFlags flags,  SecRequirementRef *requirement );'</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        /// <param name="code">MISSING</param>
        /// <param name="flags">MISSING</param>
        /// <param name="requirement">MISSING</param>
        /// <returns>A result code; see “Result Codes.”</returns>
        public static int SecCodeCopyDesignatedRequirement(IntPtr code, SecCSFlags flags, out IntPtr requirement)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(IntPtr.Size);
            Marshal.WriteIntPtr(__local1, IntPtr.Zero);
            int __result = SecCodeCopyDesignatedRequirement_Inner(code, flags, __local1);
            requirement = Marshal.ReadIntPtr(__local1);
            Marshal.FreeHGlobal(__local1);
            return __result;
        }

        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecCodeCopyDesignatedRequirement")]
        private static extern int SecCodeCopyDesignatedRequirement_Inner(IntPtr code, SecCSFlags flags, IntPtr requirement);

#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>Asks a code host to identify one of its guests given the type and value of specific attributes of the guest code.</para>
        /// <para>Original signature is 'OSStatus SecCodeCopyGuestWithAttributes (  SecCodeRef host,  CFDictionaryRef attributes,  SecCSFlags flags,  SecCodeRef *guest );'</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        /// <param name="host">MISSING</param>
        /// <param name="attributes">MISSING</param>
        /// <param name="flags">MISSING</param>
        /// <param name="guest">MISSING</param>
        /// <returns>A result code; see “Result Codes.” In particular:</returns>
        public static int SecCodeCopyGuestWithAttributes(IntPtr host, NSDictionary attributes, SecCSFlags flags, out IntPtr guest)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(IntPtr.Size);
            Marshal.WriteIntPtr(__local1, IntPtr.Zero);
            int __result = SecCodeCopyGuestWithAttributes_Inner(host, attributes, flags, __local1);
            guest = Marshal.ReadIntPtr(__local1);
            Marshal.FreeHGlobal(__local1);
            return __result;
        }

        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecCodeCopyGuestWithAttributes")]
        private static extern int SecCodeCopyGuestWithAttributes_Inner(IntPtr host, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (IdMarshaler<NSDictionary>))] NSDictionary attributes, SecCSFlags flags, IntPtr guest);

#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>Retrieves the code object for the host of specified guest code.</para>
        /// <para>Original signature is 'OSStatus SecCodeCopyHost (  SecCodeRef guest,  SecCSFlags flags,  SecCodeRef *host );'</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        /// <param name="guest">MISSING</param>
        /// <param name="flags">MISSING</param>
        /// <param name="host">MISSING</param>
        /// <returns>A result code; see “Result Codes.”</returns>
        public static int SecCodeCopyHost(IntPtr guest, SecCSFlags flags, out IntPtr host)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(IntPtr.Size);
            Marshal.WriteIntPtr(__local1, IntPtr.Zero);
            int __result = SecCodeCopyHost_Inner(guest, flags, __local1);
            host = Marshal.ReadIntPtr(__local1);
            Marshal.FreeHGlobal(__local1);
            return __result;
        }

        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecCodeCopyHost")]
        private static extern int SecCodeCopyHost_Inner(IntPtr guest, SecCSFlags flags, IntPtr host);

#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>Retrieves the location on disk of signed code, given a code or static code object.</para>
        /// <para>Original signature is 'OSStatus SecCodeCopyPath (  SecStaticCodeRef staticCode,  SecCSFlags flags,  CFURLRef *path );'</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        /// <param name="staticCode">MISSING</param>
        /// <param name="flags">MISSING</param>
        /// <param name="path">MISSING</param>
        /// <returns>A result code; see “Result Codes.”</returns>
        public static int SecCodeCopyPath(IntPtr staticCode, SecCSFlags flags, out NSURL path)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof (IntPtr)));
            Marshal.WriteIntPtr(__local1, IntPtr.Zero);
            int __result = SecCodeCopyPath_Inner(staticCode, flags, __local1);
            path = ObjectiveCRuntime.GetInstance<NSURL>(Marshal.ReadIntPtr(__local1));
            Marshal.FreeHGlobal(__local1);
            return __result;
        }

        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecCodeCopyPath")]
        private static extern int SecCodeCopyPath_Inner(IntPtr staticCode, SecCSFlags flags, IntPtr path);

#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>Retrieves the code object for the code making the call.</para>
        /// <para>Original signature is 'OSStatus SecCodeCopySelf (  SecCSFlags flags,  SecCodeRef *self );'</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        /// <param name="flags">MISSING</param>
        /// <param name="self">MISSING</param>
        /// <returns>A result code; see “Result Codes.”</returns>
        public static int SecCodeCopySelf(SecCSFlags flags, out IntPtr self)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(IntPtr.Size);
            Marshal.WriteIntPtr(__local1, IntPtr.Zero);
            int __result = SecCodeCopySelf_Inner(flags, __local1);
            self = Marshal.ReadIntPtr(__local1);
            Marshal.FreeHGlobal(__local1);
            return __result;
        }

        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecCodeCopySelf")]
        private static extern int SecCodeCopySelf_Inner(SecCSFlags flags, IntPtr self);

#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>Retrieves various pieces of information from a code signature.</para>
        /// <para>Original signature is 'OSStatus SecCodeCopySigningInformation (  SecStaticCodeRef code,  SecCSFlags flags,  CFDictionaryRef *information );'</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        /// <param name="code">MISSING</param>
        /// <param name="flags">MISSING</param>
        /// <param name="information">MISSING</param>
        /// <returns>A result code; see “Result Codes.”</returns>
        public static int SecCodeCopySigningInformation(IntPtr code, SecCSFlags flags, out NSDictionary information)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof (IntPtr)));
            Marshal.WriteIntPtr(__local1, IntPtr.Zero);
            int __result = SecCodeCopySigningInformation_Inner(code, flags, __local1);
            information = ObjectiveCRuntime.GetInstance<NSDictionary>(Marshal.ReadIntPtr(__local1));
            Marshal.FreeHGlobal(__local1);
            return __result;
        }

        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecCodeCopySigningInformation")]
        private static extern int SecCodeCopySigningInformation_Inner(IntPtr code, SecCSFlags flags, IntPtr information);

#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>Locates the origin of running code and returns a static code object representing the code in the file system.</para>
        /// <para>Original signature is 'OSStatus SecCodeCopyStaticCode (  SecCodeRef code,  SecCSFlags flags,  SecStaticCodeRef *staticCode );'</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        /// <param name="code">MISSING</param>
        /// <param name="flags">MISSING</param>
        /// <param name="staticCode">MISSING</param>
        /// <returns>A result code; see “Result Codes.”</returns>
        public static int SecCodeCopyStaticCode(IntPtr code, SecCSFlags flags, out IntPtr staticCode)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(IntPtr.Size);
            Marshal.WriteIntPtr(__local1, IntPtr.Zero);
            int __result = SecCodeCopyStaticCode_Inner(code, flags, __local1);
            staticCode = Marshal.ReadIntPtr(__local1);
            Marshal.FreeHGlobal(__local1);
            return __result;
        }

        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecCodeCopyStaticCode")]
        private static extern int SecCodeCopyStaticCode_Inner(IntPtr code, SecCSFlags flags, IntPtr staticCode);

#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>Asks the kernel to accept the signing information currently attached to a code object and uses it to validate memory page-ins.</para>
        /// <para>Original signature is 'OSStatus SecCodeMapMemory (  SecStaticCodeRef code,  SecCSFlags flags );'</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        /// <param name="code">MISSING</param>
        /// <param name="flags">MISSING</param>
        /// <returns>A result code; see “Result Codes.”</returns>
        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecCodeMapMemory")]
        public static extern int SecCodeMapMemory(IntPtr code, SecCSFlags flags);

#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>Creates a new guest and describes its initial properties.</para>
        /// <para>Original signature is 'OSStatus SecHostCreateGuest (  SecGuestRef host,  uint32_t status,  CFURLRef path,  CFDictionaryRef attributes,  SecCSFlags flags,  SecGuestRef *newGuest );'</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        /// <param name="host">MISSING</param>
        /// <param name="status">MISSING</param>
        /// <param name="path">MISSING</param>
        /// <param name="attributes">MISSING</param>
        /// <param name="flags">MISSING</param>
        /// <param name="newGuest">MISSING</param>
        /// <returns>A result code; see “Result Codes.”</returns>
        public static int SecHostCreateGuest(IntPtr host, uint status, NSURL path, NSDictionary attributes, SecCSFlags flags, out IntPtr newGuest)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(IntPtr.Size);
            Marshal.WriteIntPtr(__local1, IntPtr.Zero);
            int __result = SecHostCreateGuest_Inner(host, status, path, attributes, flags, __local1);
            newGuest = Marshal.ReadIntPtr(__local1);
            Marshal.FreeHGlobal(__local1);
            return __result;
        }

        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecHostCreateGuest")]
        private static extern int SecHostCreateGuest_Inner(IntPtr host, uint status, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (IdMarshaler<NSURL>))] NSURL path, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (IdMarshaler<NSDictionary>))] NSDictionary attributes, SecCSFlags flags, IntPtr newGuest);

#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>Removes a guest from a host.</para>
        /// <para>Original signature is 'OSStatus SecHostRemoveGuest (  SecGuestRef host,  SecGuestRef guest,  SecCSFlags flags );'</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        /// <param name="host">MISSING</param>
        /// <param name="guest">MISSING</param>
        /// <param name="flags">MISSING</param>
        /// <returns>A result code; see “Result Codes.”</returns>
        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecHostRemoveGuest")]
        public static extern int SecHostRemoveGuest(IntPtr host, IntPtr guest, SecCSFlags flags);

#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>Retrieves the handle for the guest currently selected for the calling thread.</para>
        /// <para>Original signature is 'OSStatus SecHostSelectedGuest (  SecCSFlags flags,  SecGuestRef *guestRef );'</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        /// <param name="flags">MISSING</param>
        /// <param name="guestRef">MISSING</param>
        /// <returns>A result code; see “Result Codes.”</returns>
        public static int SecHostSelectedGuest(SecCSFlags flags, out IntPtr guestRef)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(IntPtr.Size);
            Marshal.WriteIntPtr(__local1, IntPtr.Zero);
            int __result = SecHostSelectedGuest_Inner(flags, __local1);
            guestRef = Marshal.ReadIntPtr(__local1);
            Marshal.FreeHGlobal(__local1);
            return __result;
        }

        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecHostSelectedGuest")]
        private static extern int SecHostSelectedGuest_Inner(SecCSFlags flags, IntPtr guestRef);

#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>Makes the calling thread the proxy for a specified guest.</para>
        /// <para>Original signature is 'OSStatus SecHostSelectGuest (  SecGuestRef guestRef,  SecCSFlags flags );'</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        /// <param name="guestRef">MISSING</param>
        /// <param name="flags">MISSING</param>
        /// <returns>A result code; see “Result Codes.”</returns>
        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecHostSelectGuest")]
        public static extern int SecHostSelectGuest(IntPtr guestRef, SecCSFlags flags);

#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>Updates the status and attributes of a particular guest.</para>
        /// <para>Original signature is 'OSStatus SecHostSetGuestStatus (  SecGuestRef guestRef,  uint32_t status,  CFDictionaryRef attributes,  SecCSFlags flags );'</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        /// <param name="guestRef">MISSING</param>
        /// <param name="status">MISSING</param>
        /// <param name="attributes">MISSING</param>
        /// <param name="flags">MISSING</param>
        /// <returns>A result code; see “Result Codes.”</returns>
        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecHostSetGuestStatus")]
        public static extern int SecHostSetGuestStatus(IntPtr guestRef, uint status, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (IdMarshaler<NSDictionary>))] NSDictionary attributes, SecCSFlags flags);

#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>Tells the Code Signing Services hosting subsystem that the calling code will directly respond to hosting inquiries over the given port.</para>
        /// <para>Original signature is 'OSStatus SecHostSetHostingPort (  mach_port_t hostingPort,  SecCSFlags flags );'</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        /// <param name="hostingPort">MISSING</param>
        /// <param name="flags">MISSING</param>
        /// <returns>A result code; see “Result Codes.”</returns>
        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecHostSetHostingPort")]
        public static extern int SecHostSetHostingPort(uint hostingPort, SecCSFlags flags);

#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>Extracts a binary form of a code requirement from a code requirement object.</para>
        /// <para>Original signature is 'OSStatus SecRequirementCopyData (  SecRequirementRef requirement,  SecCSFlags flags,  CFDataRef *data );'</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        /// <param name="requirement">MISSING</param>
        /// <param name="flags">MISSING</param>
        /// <param name="data">MISSING</param>
        /// <returns>A result code; see “Result Codes.”</returns>
        public static int SecRequirementCopyData(IntPtr requirement, SecCSFlags flags, out NSData data)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof (IntPtr)));
            Marshal.WriteIntPtr(__local1, IntPtr.Zero);
            int __result = SecRequirementCopyData_Inner(requirement, flags, __local1);
            data = ObjectiveCRuntime.GetInstance<NSData>(Marshal.ReadIntPtr(__local1));
            Marshal.FreeHGlobal(__local1);
            return __result;
        }

        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecRequirementCopyData")]
        private static extern int SecRequirementCopyData_Inner(IntPtr requirement, SecCSFlags flags, IntPtr data);

#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>Converts a code requirement object into text form.</para>
        /// <para>Original signature is 'OSStatus SecRequirementCopyString (  SecRequirementRef requirement,  SecCSFlags flags,  CFStringRef *text );'</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        /// <param name="requirement">MISSING</param>
        /// <param name="flags">MISSING</param>
        /// <param name="text">MISSING</param>
        /// <returns>A result code; see “Result Codes.”</returns>
        public static int SecRequirementCopyString(IntPtr requirement, SecCSFlags flags, out NSString text)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof (IntPtr)));
            Marshal.WriteIntPtr(__local1, IntPtr.Zero);
            int __result = SecRequirementCopyString_Inner(requirement, flags, __local1);
            text = ObjectiveCRuntime.GetInstance<NSString>(Marshal.ReadIntPtr(__local1));
            Marshal.FreeHGlobal(__local1);
            return __result;
        }

        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecRequirementCopyString")]
        private static extern int SecRequirementCopyString_Inner(IntPtr requirement, SecCSFlags flags, IntPtr text);

#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>Creates a code requirement object from the binary form of a code requirement.</para>
        /// <para>Original signature is 'OSStatus SecRequirementCreateWithData (  CFDataRef data,  SecCSFlags flags,  SecRequirementRef *requirement );'</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        /// <param name="data">MISSING</param>
        /// <param name="flags">MISSING</param>
        /// <param name="requirement">MISSING</param>
        /// <returns>A result code; see “Result Codes.”</returns>
        public static int SecRequirementCreateWithData(NSData data, SecCSFlags flags, out IntPtr requirement)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(IntPtr.Size);
            Marshal.WriteIntPtr(__local1, IntPtr.Zero);
            int __result = SecRequirementCreateWithData_Inner(data, flags, __local1);
            requirement = Marshal.ReadIntPtr(__local1);
            Marshal.FreeHGlobal(__local1);
            return __result;
        }

        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecRequirementCreateWithData")]
        private static extern int SecRequirementCreateWithData_Inner([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (IdMarshaler<NSData>))] NSData data, SecCSFlags flags, IntPtr requirement);

#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>Creates a code requirement object by compiling a valid text representation of a code requirement.</para>
        /// <para>Original signature is 'OSStatus SecRequirementCreateWithString (  CFStringRef text,  SecCSFlags flags,  SecRequirementRef *requirement );'</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        /// <param name="text">MISSING</param>
        /// <param name="flags">MISSING</param>
        /// <param name="requirement">MISSING</param>
        /// <returns>A result code; see “Result Codes.”</returns>
        public static int SecRequirementCreateWithString(NSString text, SecCSFlags flags, out IntPtr requirement)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(IntPtr.Size);
            Marshal.WriteIntPtr(__local1, IntPtr.Zero);
            int __result = SecRequirementCreateWithString_Inner(text, flags, __local1);
            requirement = Marshal.ReadIntPtr(__local1);
            Marshal.FreeHGlobal(__local1);
            return __result;
        }

        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecRequirementCreateWithString")]
        private static extern int SecRequirementCreateWithString_Inner([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (IdMarshaler<NSString>))] NSString text, SecCSFlags flags, IntPtr requirement);

#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>Creates a code requirement object by compiling a valid text representation of a code requirement and returns detailed error information in the case of failure.</para>
        /// <para>Original signature is 'OSStatus SecRequirementCreateWithStringAndErrors (  CFStringRef text,  SecCSFlags flags,  CFErrorRef *errors,  SecRequirementRef *requirement );'</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        /// <param name="text">MISSING</param>
        /// <param name="flags">MISSING</param>
        /// <param name="errors">MISSING</param>
        /// <param name="requirement">MISSING</param>
        /// <returns>A result code; see “Result Codes.”</returns>
        public static int SecRequirementCreateWithStringAndErrors(NSString text, SecCSFlags flags, out NSError errors, out IntPtr requirement)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof (IntPtr)));
            IntPtr __local2 = Marshal.AllocHGlobal(IntPtr.Size);
            Marshal.WriteIntPtr(__local1, IntPtr.Zero);
            Marshal.WriteIntPtr(__local2, IntPtr.Zero);
            int __result = SecRequirementCreateWithStringAndErrors_Inner(text, flags, __local1, __local2);
            errors = ObjectiveCRuntime.GetInstance<NSError>(Marshal.ReadIntPtr(__local1));
            requirement = Marshal.ReadIntPtr(__local2);
            Marshal.FreeHGlobal(__local1);
            Marshal.FreeHGlobal(__local2);
            return __result;
        }

        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecRequirementCreateWithStringAndErrors")]
        private static extern int SecRequirementCreateWithStringAndErrors_Inner([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (IdMarshaler<NSString>))] NSString text, SecCSFlags flags, IntPtr errors, IntPtr requirement);

#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>Validates a static code object.</para>
        /// <para>Original signature is 'OSStatus SecStaticCodeCheckValidity (  SecStaticCodeRef staticCode,  SecCSFlags flags,  SecRequirementRef requirement );'</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        /// <param name="staticCode">MISSING</param>
        /// <param name="flags">MISSING</param>
        /// <param name="requirement">MISSING</param>
        /// <returns>A result code; see “Result Codes.”</returns>
        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecStaticCodeCheckValidity")]
        public static extern int SecStaticCodeCheckValidity(IntPtr staticCode, SecCSFlags flags, IntPtr requirement);

#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>Performs static validation of static signed code and returns detailed error information in the case of failure.</para>
        /// <para>Original signature is 'OSStatus SecStaticCodeCheckValidityWithErrors (  SecStaticCodeRef staticCode,  SecCSFlags flags,  SecRequirementRef requirement,  CFErrorRef *errors );'</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        /// <param name="staticCode">MISSING</param>
        /// <param name="flags">MISSING</param>
        /// <param name="requirement">MISSING</param>
        /// <param name="errors">MISSING</param>
        /// <returns>A result code; see “Result Codes.”</returns>
        public static int SecStaticCodeCheckValidityWithErrors(IntPtr staticCode, SecCSFlags flags, IntPtr requirement, out NSError errors)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof (IntPtr)));
            Marshal.WriteIntPtr(__local1, IntPtr.Zero);
            int __result = SecStaticCodeCheckValidityWithErrors_Inner(staticCode, flags, requirement, __local1);
            errors = ObjectiveCRuntime.GetInstance<NSError>(Marshal.ReadIntPtr(__local1));
            Marshal.FreeHGlobal(__local1);
            return __result;
        }

        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecStaticCodeCheckValidityWithErrors")]
        private static extern int SecStaticCodeCheckValidityWithErrors_Inner(IntPtr staticCode, SecCSFlags flags, IntPtr requirement, IntPtr errors);

#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>Creates a static code object representing the code at a specified file system path.</para>
        /// <para>Original signature is 'OSStatus SecStaticCodeCreateWithPath (  CFURLRef path,  SecCSFlags flags,  SecStaticCodeRef *staticCode );'</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        /// <param name="path">MISSING</param>
        /// <param name="flags">MISSING</param>
        /// <param name="staticCode">MISSING</param>
        /// <returns>A result code; see “Result Codes.”</returns>
        public static int SecStaticCodeCreateWithPath(NSURL path, SecCSFlags flags, out IntPtr staticCode)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(IntPtr.Size);
            Marshal.WriteIntPtr(__local1, IntPtr.Zero);
            int __result = SecStaticCodeCreateWithPath_Inner(path, flags, __local1);
            staticCode = Marshal.ReadIntPtr(__local1);
            Marshal.FreeHGlobal(__local1);
            return __result;
        }

        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecStaticCodeCreateWithPath")]
        private static extern int SecStaticCodeCreateWithPath_Inner([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (IdMarshaler<NSURL>))] NSURL path, SecCSFlags flags, IntPtr staticCode);

#endif

    }
}
