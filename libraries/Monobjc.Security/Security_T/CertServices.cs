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
    public static partial class CertServices
    {
#if MACOSX_10_6
        /// <summary>
        /// <para>Item label.</para>
        /// <para>The corresponding value is of type CFStringRef. The format of the string is implementation specific.</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        public static readonly NSString kSecImportItemLabel = ObjectiveCRuntime.GetExtern<NSString>("Security", "kSecImportItemLabel");
#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>Key ID.</para>
        /// <para>The corresponding value is of type CFDataRef. This unique ID is often the SHA-1 digest of the public encryption key.</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        public static readonly NSString kSecImportItemKeyID = ObjectiveCRuntime.GetExtern<NSString>("Security", "kSecImportItemKeyID");
#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>Trust management object.</para>
        /// <para>The corresponding value is of type SecTrustRef. The trust reference returned by the SecPKCS12Import function has been evaluated against the basic X.509 policy and includes as complete a certificate chain as could be constructed from the certificates in the PKCS #12 blob, certificates on the keychain, and any other certificates available to the system. You can use the SecTrustEvaluate function if you want to know whether the certificate chain is complete and valid (according to the basic X.509 policy). There is no guarantee that the evaluation will succeed.</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        public static readonly NSString kSecImportItemTrust = ObjectiveCRuntime.GetExtern<NSString>("Security", "kSecImportItemTrust");
#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>Certificate list.</para>
        /// <para>The corresponding value is of type CFArrayRef. The array consists of SecCertificateRef objects for all the certificates in the PKCS #12 blob. This list might differ from that in the trust management object if there is more than one identity in the blob or if the blob contains extra certificates (for example, an intermediate certificate that is not yet valid but might be needed to establish validity in the near future).</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        public static readonly NSString kSecImportItemCertChain = ObjectiveCRuntime.GetExtern<NSString>("Security", "kSecImportItemCertChain");
#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>Identity object.</para>
        /// <para>The corresponding value is of type SecIdentityRef and represents one identity contained in the PKCS #12 blob.</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        public static readonly NSString kSecImportItemIdentity = ObjectiveCRuntime.GetExtern<NSString>("Security", "kSecImportItemIdentity");
#endif

#if MACOSX_10_5
        /// <summary>
        /// <para>The system-wide default identity.</para>
        /// <para>Available in Mac OS X v10.5 and later.</para>
        /// </summary>
        public static readonly NSString kSecIdentityDomainDefault = ObjectiveCRuntime.GetExtern<NSString>("Security", "kSecIdentityDomainDefault");
#endif

#if MACOSX_10_5
        /// <summary>
        /// <para>Kerberos Key Distribution Center (KDC) identity.</para>
        /// <para>Available in Mac OS X v10.5 and later.</para>
        /// </summary>
        public static readonly NSString kSecIdentityDomainKerberosKDC = ObjectiveCRuntime.GetExtern<NSString>("Security", "kSecIdentityDomainKerberosKDC");
#endif

        /// <summary>
        /// <para>Adds a certificate to a keychain.</para>
        /// <para>Original signature is 'OSStatus SecCertificateAddToKeychain (  SecCertificateRef certificate,  SecKeychainRef keychain );'</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        /// <param name="certificate">MISSING</param>
        /// <param name="keychain">MISSING</param>
        /// <returns>A result code. See “Certificate, Key, and Trust Services Result Codes.”</returns>
        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecCertificateAddToKeychain")]
        public static extern int SecCertificateAddToKeychain(IntPtr certificate, IntPtr keychain);


#if MACOSX_10_5
        /// <summary>
        /// <para>Retrieves the common name of the subject of a certificate.</para>
        /// <para>Original signature is 'OSStatus SecCertificateCopyCommonName(  SecCertificateRef certificate,  CFStringRef *commonName );'</para>
        /// <para>Available in Mac OS X v10.5 and later.</para>
        /// </summary>
        /// <param name="certificate">MISSING</param>
        /// <param name="commonName">MISSING</param>
        /// <returns>A result code. See “Certificate, Key, and Trust Services Result Codes.”</returns>
        public static int SecCertificateCopyCommonName(IntPtr certificate, out NSString commonName)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof (IntPtr)));
            Marshal.WriteIntPtr(__local1, IntPtr.Zero);
            int __result = SecCertificateCopyCommonName_Inner(certificate, __local1);
            commonName = ObjectiveCRuntime.GetInstance<NSString>(Marshal.ReadIntPtr(__local1));
            Marshal.FreeHGlobal(__local1);
            return __result;
        }

        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecCertificateCopyCommonName")]
        private static extern int SecCertificateCopyCommonName_Inner(IntPtr certificate, IntPtr commonName);

#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>Returns a DER representation of a certificate given a certificate object.</para>
        /// <para>Original signature is 'CFDataRef SecCertificateCopyData (  SecCertificateRef certificate );'</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        /// <param name="certificate">MISSING</param>
        /// <returns>The DER representation of the certificate. Call the CFRelease function to release this object when you are finished with it. Returns NULL if the data passed in the certificate parameter is not a valid certificate object.</returns>
        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecCertificateCopyData")]
        [return : MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (IdMarshaler<NSData>))]
        public static extern NSData SecCertificateCopyData(IntPtr certificate);

#endif

#if MACOSX_10_5
        /// <summary>
        /// <para>Retrieves the email addresses for the subject of a certificate.</para>
        /// <para>Original signature is 'OSStatus SecCertificateCopyEmailAddresses(  SecCertificateRef certificate,  CFArrayRef *emailAddresses );'</para>
        /// <para>Available in Mac OS X v10.5 and later.</para>
        /// </summary>
        /// <param name="certificate">MISSING</param>
        /// <param name="emailAddresses">MISSING</param>
        /// <returns>A result code. See “Certificate, Key, and Trust Services Result Codes.”</returns>
        public static int SecCertificateCopyEmailAddresses(IntPtr certificate, out NSArray emailAddresses)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof (IntPtr)));
            Marshal.WriteIntPtr(__local1, IntPtr.Zero);
            int __result = SecCertificateCopyEmailAddresses_Inner(certificate, __local1);
            emailAddresses = ObjectiveCRuntime.GetInstance<NSArray>(Marshal.ReadIntPtr(__local1));
            Marshal.FreeHGlobal(__local1);
            return __result;
        }

        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecCertificateCopyEmailAddresses")]
        private static extern int SecCertificateCopyEmailAddresses_Inner(IntPtr certificate, IntPtr emailAddresses);

#endif

#if MACOSX_10_5
        /// <summary>
        /// <para>Retrieves the preferred certificate for the specified name and key use.</para>
        /// <para>Original signature is 'OSStatus SecCertificateCopyPreference(  CFStringRef name,  CSSM_KEYUSE keyUsage,  SecCertificateRef *certificate );'</para>
        /// <para>Available in Mac OS X v10.5 and later.</para>
        /// </summary>
        /// <param name="name">MISSING</param>
        /// <param name="keyUsage">MISSING</param>
        /// <param name="certificate">MISSING</param>
        /// <returns>A result code. See “Certificate, Key, and Trust Services Result Codes.”</returns>
        public static int SecCertificateCopyPreference(NSString name, CSSM_KEYUSE keyUsage, out IntPtr certificate)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(IntPtr.Size);
            Marshal.WriteIntPtr(__local1, IntPtr.Zero);
            int __result = SecCertificateCopyPreference_Inner(name, keyUsage, __local1);
            certificate = Marshal.ReadIntPtr(__local1);
            Marshal.FreeHGlobal(__local1);
            return __result;
        }

        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecCertificateCopyPreference")]
        private static extern int SecCertificateCopyPreference_Inner([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (IdMarshaler<NSString>))] NSString name, CSSM_KEYUSE keyUsage, IntPtr certificate);

#endif

#if MACOSX_10_5
        /// <summary>
        /// <para>Retrieves the public key from a certificate.</para>
        /// <para>Original signature is 'OSStatus SecCertificateCopyPublicKey(  SecCertificateRef certificate,  SecKeyRef *key );'</para>
        /// <para>Available in Mac OS X v10.5 and later.</para>
        /// </summary>
        /// <param name="certificate">MISSING</param>
        /// <param name="key">MISSING</param>
        /// <returns>A result code. See “Certificate, Key, and Trust Services Result Codes.”</returns>
        public static int SecCertificateCopyPublicKey(IntPtr certificate, out IntPtr key)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(IntPtr.Size);
            Marshal.WriteIntPtr(__local1, IntPtr.Zero);
            int __result = SecCertificateCopyPublicKey_Inner(certificate, __local1);
            key = Marshal.ReadIntPtr(__local1);
            Marshal.FreeHGlobal(__local1);
            return __result;
        }

        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecCertificateCopyPublicKey")]
        private static extern int SecCertificateCopyPublicKey_Inner(IntPtr certificate, IntPtr key);

#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>Returns a human-readable summary of a certificate.</para>
        /// <para>Original signature is 'CFStringRef SecCertificateCopySubjectSummary (  SecCertificateRef certificate );'</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        /// <param name="certificate">MISSING</param>
        /// <returns>A string that contains a human-readable summary of the contents of the certificate. Call the CFRelease function to release this object when you are finished with it. Returns NULL if the data passed in the certificate parameter is not a valid certificate object.</returns>
        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecCertificateCopySubjectSummary")]
        [return : MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (IdMarshaler<NSString>))]
        public static extern NSString SecCertificateCopySubjectSummary(IntPtr certificate);

#endif

        /// <summary>
        /// <para>Creates a certificate object based on the specified data, type, and encoding.</para>
        /// <para>Original signature is 'OSStatus SecCertificateCreateFromData (  const CSSM_DATA *data,  CSSM_CERT_TYPE type,  CSSM_CERT_ENCODING encoding,  SecCertificateRef *certificate );'</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        /// <param name="data">MISSING</param>
        /// <param name="type">MISSING</param>
        /// <param name="encoding">MISSING</param>
        /// <param name="certificate">MISSING</param>
        /// <returns>A result code. See “Certificate, Key, and Trust Services Result Codes.”</returns>
        public static int SecCertificateCreateFromData(ref CSSM_DATA data, CSSM_CERT_TYPE type, CSSM_CERT_ENCODING encoding, out IntPtr certificate)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof (IntPtr)));
            IntPtr __local2 = Marshal.AllocHGlobal(IntPtr.Size);
            Marshal.StructureToPtr(data, __local1, false);
            Marshal.WriteIntPtr(__local2, IntPtr.Zero);
            int __result = SecCertificateCreateFromData_Inner(__local1, type, encoding, __local2);
            data = (CSSM_DATA) Marshal.PtrToStructure(__local1, typeof(CSSM_DATA));
            certificate = Marshal.ReadIntPtr(__local2);
            Marshal.FreeHGlobal(__local1);
            Marshal.FreeHGlobal(__local2);
            return __result;
        }

        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecCertificateCreateFromData")]
        private static extern int SecCertificateCreateFromData_Inner(IntPtr data, CSSM_CERT_TYPE type, CSSM_CERT_ENCODING encoding, IntPtr certificate);


#if MACOSX_10_6
        /// <summary>
        /// <para>Creates a certificate object from a DER representation of a certificate.</para>
        /// <para>Original signature is 'SecCertificateRef SecCertificateCreateWithData (  CFAllocatorRef allocator,  CFDataRef data );'</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        /// <param name="allocator">MISSING</param>
        /// <param name="data">MISSING</param>
        /// <returns>The newly created certificate object. Call the CFRelease function to release this object when you are finished with it. Returns NULL if the data passed in the data parameter is not a valid DER-encoded X.509 certificate.</returns>
        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecCertificateCreateWithData")]
        public static extern IntPtr SecCertificateCreateWithData(IntPtr allocator, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (IdMarshaler<NSData>))] NSData data);

#endif

#if MACOSX_10_5
        /// <summary>
        /// <para>Retrieves the algorithm identifier for a certificate.</para>
        /// <para>Original signature is 'OSStatus SecCertificateGetAlgorithmID(  SecCertificateRef certificate,  const CSSM_X509_ALGORITHM_IDENTIFIER **algid );'</para>
        /// <para>Available in Mac OS X v10.5 and later.</para>
        /// </summary>
        /// <param name="certificate">MISSING</param>
        /// <param name="algid">MISSING</param>
        /// <returns>A result code. See “Certificate, Key, and Trust Services Result Codes.”</returns>
        public static int SecCertificateGetAlgorithmID(IntPtr certificate, out IntPtr algid)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(IntPtr.Size);
            Marshal.WriteIntPtr(__local1, IntPtr.Zero);
            int __result = SecCertificateGetAlgorithmID_Inner(certificate, __local1);
            algid = Marshal.ReadIntPtr(__local1);
            Marshal.FreeHGlobal(__local1);
            return __result;
        }

        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecCertificateGetAlgorithmID")]
        private static extern int SecCertificateGetAlgorithmID_Inner(IntPtr certificate, IntPtr algid);

#endif

        /// <summary>
        /// <para>Retrieves the certificate library handle from a certificate object.</para>
        /// <para>Original signature is 'OSStatus SecCertificateGetCLHandle (  SecCertificateRef certificate,  CSSM_CL_HANDLE *clHandle );'</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        /// <param name="certificate">MISSING</param>
        /// <param name="clHandle">MISSING</param>
        /// <returns>A result code. See “Certificate, Key, and Trust Services Result Codes.”</returns>
        public static int SecCertificateGetCLHandle(IntPtr certificate, out IntPtr clHandle)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(IntPtr.Size);
            Marshal.WriteIntPtr(__local1, IntPtr.Zero);
            int __result = SecCertificateGetCLHandle_Inner(certificate, __local1);
            clHandle = Marshal.ReadIntPtr(__local1);
            Marshal.FreeHGlobal(__local1);
            return __result;
        }

        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecCertificateGetCLHandle")]
        private static extern int SecCertificateGetCLHandle_Inner(IntPtr certificate, IntPtr clHandle);


        /// <summary>
        /// <para>Retrieves the data for a certificate.</para>
        /// <para>Original signature is 'OSStatus SecCertificateGetData (  SecCertificateRef certificate,  CSSM_DATA_PTR data );'</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        /// <param name="certificate">MISSING</param>
        /// <param name="data">MISSING</param>
        /// <returns>A result code. See “Certificate, Key, and Trust Services Result Codes.”</returns>
        public static int SecCertificateGetData(IntPtr certificate, out CSSM_DATA data)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof (IntPtr)));
            Marshal.WriteIntPtr(__local1, IntPtr.Zero);
            int __result = SecCertificateGetData_Inner(certificate, __local1);
            data = (CSSM_DATA) Marshal.PtrToStructure(__local1, typeof(CSSM_DATA));
            Marshal.FreeHGlobal(__local1);
            return __result;
        }

        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecCertificateGetData")]
        private static extern int SecCertificateGetData_Inner(IntPtr certificate, IntPtr data);


        /// <summary>
        /// <para>Unsupported.</para>
        /// <para>Original signature is 'OSStatus SecCertificateGetIssuer (  SecCertificateRef certificate,  CSSM_X509_NAME *issuer );'</para>
        /// <para>Available in VERSION and later.</para>
        /// </summary>
        /// <param name="certificate">MISSING</param>
        /// <param name="issuer">MISSING</param>
        /// <returns>A result code. See “Certificate, Key, and Trust Services Result Codes.”</returns>
        public static int SecCertificateGetIssuer(IntPtr certificate, out CSSM_X509_NAME issuer)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof (IntPtr)));
            Marshal.WriteIntPtr(__local1, IntPtr.Zero);
            int __result = SecCertificateGetIssuer_Inner(certificate, __local1);
            issuer = (CSSM_X509_NAME) Marshal.PtrToStructure(__local1, typeof(CSSM_X509_NAME));
            Marshal.FreeHGlobal(__local1);
            return __result;
        }

        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecCertificateGetIssuer")]
        private static extern int SecCertificateGetIssuer_Inner(IntPtr certificate, IntPtr issuer);


        /// <summary>
        /// <para>Unsupported.</para>
        /// <para>Original signature is 'OSStatus SecCertificateGetItem (  SecCertificateRef certificate,  SecKeychainItemRef *item );'</para>
        /// <para>Available in VERSION and later.</para>
        /// </summary>
        /// <param name="certificate">MISSING</param>
        /// <param name="item">MISSING</param>
        /// <returns>A result code. See “Certificate, Key, and Trust Services Result Codes.”</returns>
        public static int SecCertificateGetItem(IntPtr certificate, out IntPtr item)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(IntPtr.Size);
            Marshal.WriteIntPtr(__local1, IntPtr.Zero);
            int __result = SecCertificateGetItem_Inner(certificate, __local1);
            item = Marshal.ReadIntPtr(__local1);
            Marshal.FreeHGlobal(__local1);
            return __result;
        }

        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecCertificateGetItem")]
        private static extern int SecCertificateGetItem_Inner(IntPtr certificate, IntPtr item);


        /// <summary>
        /// <para>Unsupported.</para>
        /// <para>Original signature is 'OSStatus SecCertificateGetSubject (  SecCertificateRef certificate,  CSSM_X509_NAME *subject );'</para>
        /// <para>Available in VERSION and later.</para>
        /// </summary>
        /// <param name="certificate">MISSING</param>
        /// <param name="subject">MISSING</param>
        /// <returns>A result code. See “Certificate, Key, and Trust Services Result Codes.”</returns>
        public static int SecCertificateGetSubject(IntPtr certificate, out CSSM_X509_NAME subject)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof (IntPtr)));
            Marshal.WriteIntPtr(__local1, IntPtr.Zero);
            int __result = SecCertificateGetSubject_Inner(certificate, __local1);
            subject = (CSSM_X509_NAME) Marshal.PtrToStructure(__local1, typeof(CSSM_X509_NAME));
            Marshal.FreeHGlobal(__local1);
            return __result;
        }

        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecCertificateGetSubject")]
        private static extern int SecCertificateGetSubject_Inner(IntPtr certificate, IntPtr subject);


        /// <summary>
        /// <para>Retrieves the type of a specified certificate.</para>
        /// <para>Original signature is 'OSStatus SecCertificateGetType (  SecCertificateRef certificate,  CSSM_CERT_TYPE *certificateType );'</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        /// <param name="certificate">MISSING</param>
        /// <param name="certificateType">MISSING</param>
        /// <returns>A result code. See “Certificate, Key, and Trust Services Result Codes.”</returns>
        public static int SecCertificateGetType(IntPtr certificate, out CSSM_CERT_TYPE certificateType)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof (IntPtr)));
            Marshal.WriteIntPtr(__local1, IntPtr.Zero);
            int __result = SecCertificateGetType_Inner(certificate, __local1);
            certificateType = (CSSM_CERT_TYPE) Marshal.ReadInt32(__local1);
            Marshal.FreeHGlobal(__local1);
            return __result;
        }

        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecCertificateGetType")]
        private static extern int SecCertificateGetType_Inner(IntPtr certificate, IntPtr certificateType);


#if MACOSX_10_5
        /// <summary>
        /// <para>Sets the preferred certificate for a specified name, key use, and date.</para>
        /// <para>Original signature is 'OSStatus SecCertificateSetPreference(  SecCertificateRef certificate,  CFStringRef name,  CSSM_KEYUSE keyUsage,  CFDateRef date );'</para>
        /// <para>Available in Mac OS X v10.5 and later.</para>
        /// </summary>
        /// <param name="certificate">MISSING</param>
        /// <param name="name">MISSING</param>
        /// <param name="keyUsage">MISSING</param>
        /// <param name="date">MISSING</param>
        /// <returns>A result code. See “Certificate, Key, and Trust Services Result Codes.”</returns>
        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecCertificateSetPreference")]
        public static extern int SecCertificateSetPreference(IntPtr certificate, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (IdMarshaler<NSString>))] NSString name, CSSM_KEYUSE keyUsage, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (IdMarshaler<NSDate>))] NSDate date);

#endif

#if MACOSX_10_5
        /// <summary>
        /// <para>Returns a string describing an error.</para>
        /// <para>Original signature is 'CFStringRef SecCopyErrorMessageString(  OSStatus status,  void *reserved );'</para>
        /// <para>Available in Mac OS X v10.5 and later.</para>
        /// </summary>
        /// <param name="status">MISSING</param>
        /// <param name="reserved">MISSING</param>
        /// <returns>A reference to a localized error string, or NULL if no error string is available for the specified result code. You must release this reference when you are finished with it by calling the CFRelease function.</returns>
        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecCopyErrorMessageString")]
        [return : MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (IdMarshaler<NSString>))]
        public static extern NSString SecCopyErrorMessageString(int status, IntPtr reserved);

#endif

        /// <summary>
        /// <para>Retrieves a certificate associated with an identity.</para>
        /// <para>Original signature is 'OSStatus SecIdentityCopyCertificate (  SecIdentityRef identityRef,  SecCertificateRef *certificateRef );'</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        /// <param name="identityRef">MISSING</param>
        /// <param name="certificateRef">MISSING</param>
        /// <returns>A result code. See “Certificate, Key, and Trust Services Result Codes.”</returns>
        public static int SecIdentityCopyCertificate(IntPtr identityRef, out IntPtr certificateRef)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(IntPtr.Size);
            Marshal.WriteIntPtr(__local1, IntPtr.Zero);
            int __result = SecIdentityCopyCertificate_Inner(identityRef, __local1);
            certificateRef = Marshal.ReadIntPtr(__local1);
            Marshal.FreeHGlobal(__local1);
            return __result;
        }

        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecIdentityCopyCertificate")]
        private static extern int SecIdentityCopyCertificate_Inner(IntPtr identityRef, IntPtr certificateRef);


#if MACOSX_10_5
        /// <summary>
        /// <para>Returns the preferred identity for the specified name and key use.</para>
        /// <para>Original signature is 'OSStatus SecIdentityCopyPreference(  CFStringRef name,  CSSM_KEYUSE keyUsage,  CFArrayRef validIssuers,  SecIdentityRef *identity );'</para>
        /// <para>Available in Mac OS X v10.5 and later.</para>
        /// </summary>
        /// <param name="name">MISSING</param>
        /// <param name="keyUsage">MISSING</param>
        /// <param name="validIssuers">MISSING</param>
        /// <param name="identity">MISSING</param>
        /// <returns>A result code. See “Certificate, Key, and Trust Services Result Codes.”</returns>
        public static int SecIdentityCopyPreference(NSString name, CSSM_KEYUSE keyUsage, NSArray validIssuers, out IntPtr identity)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(IntPtr.Size);
            Marshal.WriteIntPtr(__local1, IntPtr.Zero);
            int __result = SecIdentityCopyPreference_Inner(name, keyUsage, validIssuers, __local1);
            identity = Marshal.ReadIntPtr(__local1);
            Marshal.FreeHGlobal(__local1);
            return __result;
        }

        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecIdentityCopyPreference")]
        private static extern int SecIdentityCopyPreference_Inner([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (IdMarshaler<NSString>))] NSString name, CSSM_KEYUSE keyUsage, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (IdMarshaler<NSArray>))] NSArray validIssuers, IntPtr identity);

#endif

        /// <summary>
        /// <para>Retrieves the private key associated with an identity.</para>
        /// <para>Original signature is 'OSStatus SecIdentityCopyPrivateKey (  SecIdentityRef identityRef,  SecKeyRef *privateKeyRef );'</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        /// <param name="identityRef">MISSING</param>
        /// <param name="privateKeyRef">MISSING</param>
        /// <returns>A result code. See “Certificate, Key, and Trust Services Result Codes.”</returns>
        public static int SecIdentityCopyPrivateKey(IntPtr identityRef, out IntPtr privateKeyRef)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(IntPtr.Size);
            Marshal.WriteIntPtr(__local1, IntPtr.Zero);
            int __result = SecIdentityCopyPrivateKey_Inner(identityRef, __local1);
            privateKeyRef = Marshal.ReadIntPtr(__local1);
            Marshal.FreeHGlobal(__local1);
            return __result;
        }

        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecIdentityCopyPrivateKey")]
        private static extern int SecIdentityCopyPrivateKey_Inner(IntPtr identityRef, IntPtr privateKeyRef);


#if MACOSX_10_5
        /// <summary>
        /// <para>Obtains the system-wide identity associated with a specified domain.</para>
        /// <para>Original signature is 'OSStatus SecIdentityCopySystemIdentity(  CFStringRef domain,  SecIdentityRef *idRef,  CFStringRef *actualDomain );'</para>
        /// <para>Available in Mac OS X v10.5 and later.</para>
        /// </summary>
        /// <param name="domain">MISSING</param>
        /// <param name="idRef">MISSING</param>
        /// <param name="actualDomain">MISSING</param>
        /// <returns>A result code. See “Certificate, Key, and Trust Services Result Codes.”</returns>
        public static int SecIdentityCopySystemIdentity(NSString domain, out IntPtr idRef, out NSString actualDomain)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(IntPtr.Size);
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof (IntPtr)));
            Marshal.WriteIntPtr(__local1, IntPtr.Zero);
            Marshal.WriteIntPtr(__local2, IntPtr.Zero);
            int __result = SecIdentityCopySystemIdentity_Inner(domain, __local1, __local2);
            idRef = Marshal.ReadIntPtr(__local1);
            actualDomain = ObjectiveCRuntime.GetInstance<NSString>(Marshal.ReadIntPtr(__local2));
            Marshal.FreeHGlobal(__local1);
            Marshal.FreeHGlobal(__local2);
            return __result;
        }

        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecIdentityCopySystemIdentity")]
        private static extern int SecIdentityCopySystemIdentity_Inner([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (IdMarshaler<NSString>))] NSString domain, IntPtr idRef, IntPtr actualDomain);

#endif

#if MACOSX_10_5
        /// <summary>
        /// <para>Creates a new identity for a certificate and its associated private key.</para>
        /// <para>Original signature is 'OSStatus SecIdentityCreateWithCertificate(  CFTypeRef keychainOrArray,  SecCertificateRef certificateRef,  SecIdentityRef *identityRef );'</para>
        /// <para>Available in Mac OS X v10.5 and later.</para>
        /// </summary>
        /// <param name="keychainOrArray">MISSING</param>
        /// <param name="certificateRef">MISSING</param>
        /// <param name="identityRef">MISSING</param>
        /// <returns>A result code. See “Certificate, Key, and Trust Services Result Codes.”</returns>
        public static int SecIdentityCreateWithCertificate(IntPtr keychainOrArray, IntPtr certificateRef, out IntPtr identityRef)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(IntPtr.Size);
            Marshal.WriteIntPtr(__local1, IntPtr.Zero);
            int __result = SecIdentityCreateWithCertificate_Inner(keychainOrArray, certificateRef, __local1);
            identityRef = Marshal.ReadIntPtr(__local1);
            Marshal.FreeHGlobal(__local1);
            return __result;
        }

        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecIdentityCreateWithCertificate")]
        private static extern int SecIdentityCreateWithCertificate_Inner(IntPtr keychainOrArray, IntPtr certificateRef, IntPtr identityRef);

#endif

        /// <summary>
        /// <para>Finds the next identity matching specified search criteria</para>
        /// <para>Original signature is 'OSStatus SecIdentitySearchCopyNext (  SecIdentitySearchRef searchRef,  SecIdentityRef *identity );'</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        /// <param name="searchRef">MISSING</param>
        /// <param name="identity">MISSING</param>
        /// <returns>A result code. When there are no more identities that match the parameters specified to SecIdentitySearchCreate, errSecItemNotFound is returned. See “Certificate, Key, and Trust Services Result Codes.”</returns>
        public static int SecIdentitySearchCopyNext(IntPtr searchRef, out IntPtr identity)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(IntPtr.Size);
            Marshal.WriteIntPtr(__local1, IntPtr.Zero);
            int __result = SecIdentitySearchCopyNext_Inner(searchRef, __local1);
            identity = Marshal.ReadIntPtr(__local1);
            Marshal.FreeHGlobal(__local1);
            return __result;
        }

        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecIdentitySearchCopyNext")]
        private static extern int SecIdentitySearchCopyNext_Inner(IntPtr searchRef, IntPtr identity);


        /// <summary>
        /// <para>Creates a search object for finding identities.</para>
        /// <para>Original signature is 'OSStatus SecIdentitySearchCreate (  CFTypeRef keychainOrArray,  CSSM_KEYUSE keyUsage,  SecIdentitySearchRef *searchRef );'</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        /// <param name="keychainOrArray">MISSING</param>
        /// <param name="keyUsage">MISSING</param>
        /// <param name="searchRef">MISSING</param>
        /// <returns>A result code. See “Certificate, Key, and Trust Services Result Codes.”</returns>
        public static int SecIdentitySearchCreate(IntPtr keychainOrArray, CSSM_KEYUSE keyUsage, out IntPtr searchRef)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(IntPtr.Size);
            Marshal.WriteIntPtr(__local1, IntPtr.Zero);
            int __result = SecIdentitySearchCreate_Inner(keychainOrArray, keyUsage, __local1);
            searchRef = Marshal.ReadIntPtr(__local1);
            Marshal.FreeHGlobal(__local1);
            return __result;
        }

        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecIdentitySearchCreate")]
        private static extern int SecIdentitySearchCreate_Inner(IntPtr keychainOrArray, CSSM_KEYUSE keyUsage, IntPtr searchRef);


#if MACOSX_10_5
        /// <summary>
        /// <para>Sets the preferred identity for the specified name and key use.</para>
        /// <para>Original signature is 'OSStatus SecIdentitySetPreference(  SecIdentityRef identity,  CFStringRef name,  CSSM_KEYUSE keyUsage );'</para>
        /// <para>Available in Mac OS X v10.5 and later.</para>
        /// </summary>
        /// <param name="identity">MISSING</param>
        /// <param name="name">MISSING</param>
        /// <param name="keyUsage">MISSING</param>
        /// <returns>A result code. See “Certificate, Key, and Trust Services Result Codes.”</returns>
        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecIdentitySetPreference")]
        public static extern int SecIdentitySetPreference(IntPtr identity, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (IdMarshaler<NSString>))] NSString name, CSSM_KEYUSE keyUsage);

#endif

#if MACOSX_10_5
        /// <summary>
        /// <para>Assigns the system-wide identity to be associated with a specified domain.</para>
        /// <para>Original signature is 'OSStatus SecIdentitySetSystemIdentity(  CFStringRef domain,  SecIdentityRef idRef );'</para>
        /// <para>Available in Mac OS X v10.5 and later.</para>
        /// </summary>
        /// <param name="domain">MISSING</param>
        /// <param name="idRef">MISSING</param>
        /// <returns>A result code. See “Certificate, Key, and Trust Services Result Codes.”</returns>
        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecIdentitySetSystemIdentity")]
        public static extern int SecIdentitySetSystemIdentity([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (IdMarshaler<NSString>))] NSString domain, IntPtr idRef);

#endif

        /// <summary>
        /// <para>Creates an asymmetric key pair and stores it in a keychain.</para>
        /// <para>Original signature is 'OSStatus SecKeyCreatePair (  SecKeychainRef keychainRef,  CSSM_ALGORITHMS algorithm,  uint32 keySizeInBits,  CSSM_CC_HANDLE contextHandle,  CSSM_KEYUSE publicKeyUsage,  uint32 publicKeyAttr,  CSSM_KEYUSE privateKeyUsage,  uint32 privateKeyAttr,  SecAccessRef initialAccess,  SecKeyRef *publicKey,  SecKeyRef *privateKey );'</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        /// <param name="keychainRef">MISSING</param>
        /// <param name="algorithm">MISSING</param>
        /// <param name="keySizeInBits">MISSING</param>
        /// <param name="contextHandle">MISSING</param>
        /// <param name="publicKeyUsage">MISSING</param>
        /// <param name="publicKeyAttr">MISSING</param>
        /// <param name="privateKeyUsage">MISSING</param>
        /// <param name="privateKeyAttr">MISSING</param>
        /// <param name="initialAccess">MISSING</param>
        /// <param name="publicKey">MISSING</param>
        /// <param name="privateKey">MISSING</param>
        /// <returns>A result code. See “Certificate, Key, and Trust Services Result Codes.”</returns>
        public static int SecKeyCreatePair(IntPtr keychainRef, CSSM_ALGORITHMS algorithm, uint keySizeInBits, ulong contextHandle, CSSM_KEYUSE publicKeyUsage, uint publicKeyAttr, CSSM_KEYUSE privateKeyUsage, uint privateKeyAttr, IntPtr initialAccess, out IntPtr publicKey, out IntPtr privateKey)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(IntPtr.Size);
            IntPtr __local2 = Marshal.AllocHGlobal(IntPtr.Size);
            Marshal.WriteIntPtr(__local1, IntPtr.Zero);
            Marshal.WriteIntPtr(__local2, IntPtr.Zero);
            int __result = SecKeyCreatePair_Inner(keychainRef, algorithm, keySizeInBits, contextHandle, publicKeyUsage, publicKeyAttr, privateKeyUsage, privateKeyAttr, initialAccess, __local1, __local2);
            publicKey = Marshal.ReadIntPtr(__local1);
            privateKey = Marshal.ReadIntPtr(__local2);
            Marshal.FreeHGlobal(__local1);
            Marshal.FreeHGlobal(__local2);
            return __result;
        }

        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecKeyCreatePair")]
        private static extern int SecKeyCreatePair_Inner(IntPtr keychainRef, CSSM_ALGORITHMS algorithm, uint keySizeInBits, ulong contextHandle, CSSM_KEYUSE publicKeyUsage, uint publicKeyAttr, CSSM_KEYUSE privateKeyUsage, uint privateKeyAttr, IntPtr initialAccess, IntPtr publicKey, IntPtr privateKey);


#if MACOSX_10_5
        /// <summary>
        /// <para>Creates a symmetric key and optionally stores it in a keychain.</para>
        /// <para>Original signature is 'OSStatus SecKeyGenerate(  SecKeychainRef keychainRef,  CSSM_ALGORITHMS algorithm,  uint32 keySizeInBits,  CSSM_CC_HANDLE contextHandle,  CSSM_KEYUSE keyUsage,  uint32 keyAttr,  SecAccessRef initialAccess,  SecKeyRef* keyRef );'</para>
        /// <para>Available in Mac OS X v10.5 and later.</para>
        /// </summary>
        /// <param name="keychainRef">MISSING</param>
        /// <param name="algorithm">MISSING</param>
        /// <param name="keySizeInBits">MISSING</param>
        /// <param name="contextHandle">MISSING</param>
        /// <param name="keyUsage">MISSING</param>
        /// <param name="keyAttr">MISSING</param>
        /// <param name="initialAccess">MISSING</param>
        /// <param name="keyRef">MISSING</param>
        /// <returns>A result code. See “Certificate, Key, and Trust Services Result Codes.”</returns>
        public static int SecKeyGenerate(IntPtr keychainRef, CSSM_ALGORITHMS algorithm, uint keySizeInBits, ulong contextHandle, CSSM_KEYUSE keyUsage, uint keyAttr, IntPtr initialAccess, out IntPtr keyRef)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(IntPtr.Size);
            Marshal.WriteIntPtr(__local1, IntPtr.Zero);
            int __result = SecKeyGenerate_Inner(keychainRef, algorithm, keySizeInBits, contextHandle, keyUsage, keyAttr, initialAccess, __local1);
            keyRef = Marshal.ReadIntPtr(__local1);
            Marshal.FreeHGlobal(__local1);
            return __result;
        }

        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecKeyGenerate")]
        private static extern int SecKeyGenerate_Inner(IntPtr keychainRef, CSSM_ALGORITHMS algorithm, uint keySizeInBits, ulong contextHandle, CSSM_KEYUSE keyUsage, uint keyAttr, IntPtr initialAccess, IntPtr keyRef);

#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>Gets the block length associated with a cryptographic key.</para>
        /// <para>Original signature is 'size_t SecKeyGetBlockSize (  SecKeyRef key );'</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        /// <param name="key">MISSING</param>
        /// <returns>The block length associated with the key in bytes. If the key is an RSA key, for example, this is the size of the modulus.</returns>
        public static NSUInteger SecKeyGetBlockSize(IntPtr key)
        {
            if (ObjectiveCRuntime.Is64Bits)
            {
                return (NSUInteger) SecKeyGetBlockSize_64(key);
            }
            else
            {
                return (NSUInteger) SecKeyGetBlockSize_32(key);
            }
        }

        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecKeyGetBlockSize")]
        private static extern ulong SecKeyGetBlockSize_64(IntPtr key);

        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecKeyGetBlockSize")]
        private static extern uint SecKeyGetBlockSize_32(IntPtr key);

#endif

#if MACOSX_10_5
        /// <summary>
        /// <para>Returns an access credential for a key.</para>
        /// <para>Original signature is 'OSStatus SecKeyGetCredentials(  SecKeyRef keyRef,  CSSM_ACL_AUTHORIZATION_TAG operation,  SecCredentialType credentialType,  const CSSM_ACCESS_CREDENTIALS **outCredentials );'</para>
        /// <para>Available in Mac OS X v10.5 and later.</para>
        /// </summary>
        /// <param name="keyRef">MISSING</param>
        /// <param name="operation">MISSING</param>
        /// <param name="credentialType">MISSING</param>
        /// <param name="outCredentials">MISSING</param>
        /// <returns>A result code. See “Certificate, Key, and Trust Services Result Codes.”</returns>
        public static int SecKeyGetCredentials(IntPtr keyRef, CSSM_ACL_AUTHORIZATION_TAG operation, SecCredentialType credentialType, out IntPtr outCredentials)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(IntPtr.Size);
            Marshal.WriteIntPtr(__local1, IntPtr.Zero);
            int __result = SecKeyGetCredentials_Inner(keyRef, operation, credentialType, __local1);
            outCredentials = Marshal.ReadIntPtr(__local1);
            Marshal.FreeHGlobal(__local1);
            return __result;
        }

        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecKeyGetCredentials")]
        private static extern int SecKeyGetCredentials_Inner(IntPtr keyRef, CSSM_ACL_AUTHORIZATION_TAG operation, SecCredentialType credentialType, IntPtr outCredentials);

#endif

#if MACOSX_10_5
        /// <summary>
        /// <para>Returns the CSSM CSP handle for a key.</para>
        /// <para>Original signature is 'OSStatus SecKeyGetCSPHandle(  SecKeyRef keyRef,  CSSM_CSP_HANDLE *cspHandle );'</para>
        /// <para>Available in Mac OS X v10.5 and later.</para>
        /// </summary>
        /// <param name="keyRef">MISSING</param>
        /// <param name="cspHandle">MISSING</param>
        /// <returns>A result code. See “Certificate, Key, and Trust Services Result Codes.”</returns>
        public static int SecKeyGetCSPHandle(IntPtr keyRef, out IntPtr cspHandle)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(IntPtr.Size);
            Marshal.WriteIntPtr(__local1, IntPtr.Zero);
            int __result = SecKeyGetCSPHandle_Inner(keyRef, __local1);
            cspHandle = Marshal.ReadIntPtr(__local1);
            Marshal.FreeHGlobal(__local1);
            return __result;
        }

        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecKeyGetCSPHandle")]
        private static extern int SecKeyGetCSPHandle_Inner(IntPtr keyRef, IntPtr cspHandle);

#endif

        /// <summary>
        /// <para>Retrieves a pointer to the CSSM_KEY structure containing the key stored in a keychain item.</para>
        /// <para>Original signature is 'OSStatus SecKeyGetCSSMKey (  SecKeyRef key,  const CSSM_KEY **cssmKey );'</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        /// <param name="key">MISSING</param>
        /// <param name="cssmKey">MISSING</param>
        /// <returns>A result code. See “Certificate, Key, and Trust Services Result Codes.”</returns>
        public static int SecKeyGetCSSMKey(IntPtr key, out IntPtr cssmKey)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(IntPtr.Size);
            Marshal.WriteIntPtr(__local1, IntPtr.Zero);
            int __result = SecKeyGetCSSMKey_Inner(key, __local1);
            cssmKey = Marshal.ReadIntPtr(__local1);
            Marshal.FreeHGlobal(__local1);
            return __result;
        }

        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecKeyGetCSSMKey")]
        private static extern int SecKeyGetCSSMKey_Inner(IntPtr key, IntPtr cssmKey);


#if MACOSX_10_6
        /// <summary>
        /// <para>Returns the identities and certificates in a PKCS #12-formatted blob.</para>
        /// <para>Original signature is 'OSStatus SecPKCS12Import(  CFDataRef pkcs12_data,  CFDictionaryRef options,  CFArrayRef *items );'</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        /// <param name="pkcs12_data">MISSING</param>
        /// <param name="options">MISSING</param>
        /// <param name="items">MISSING</param>
        /// <returns>A result code. The function returns errSecSuccess if there were no errors, errSecDecode if the blob can't be read or is malformed, and errSecAuthFailed if the password was not correct or data in the blob was damaged. See “Certificate, Key, and Trust Services Result Codes.”</returns>
        public static int SecPKCS12Import(NSData pkcs12_data, NSDictionary options, out NSArray items)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof (IntPtr)));
            Marshal.WriteIntPtr(__local1, IntPtr.Zero);
            int __result = SecPKCS12Import_Inner(pkcs12_data, options, __local1);
            items = ObjectiveCRuntime.GetInstance<NSArray>(Marshal.ReadIntPtr(__local1));
            Marshal.FreeHGlobal(__local1);
            return __result;
        }

        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecPKCS12Import")]
        private static extern int SecPKCS12Import_Inner([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (IdMarshaler<NSData>))] NSData pkcs12_data, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (IdMarshaler<NSDictionary>))] NSDictionary options, IntPtr items);

#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>Returns a policy object for the default X.509 policy.</para>
        /// <para>Original signature is 'SecPolicyRef SecPolicyCreateBasicX509 (  void );'</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        /// <returns>The policy object. Call the CFRelease function to release the object when you are finished with it.</returns>
        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecPolicyCreateBasicX509")]
        public static extern IntPtr SecPolicyCreateBasicX509();

#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>Returns a policy object for evaluating SSL certificate chains.</para>
        /// <para>Original signature is 'SecPolicyRef SecPolicyCreateSSL (  Boolean server,  CFStringRef hostname );'</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        /// <param name="server">MISSING</param>
        /// <param name="hostname">MISSING</param>
        /// <returns>The policy object. Call the CFRelease function to release the object when you are finished with it.</returns>
        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecPolicyCreateSSL")]
        public static extern IntPtr SecPolicyCreateSSL(bool server, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (IdMarshaler<NSString>))] NSString hostname);

#endif

        /// <summary>
        /// <para>Retrieves a policy’s object identifier.</para>
        /// <para>Original signature is 'OSStatus SecPolicyGetOID (  SecPolicyRef policyRef,  CSSM_OID *oid );'</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        /// <param name="policyRef">MISSING</param>
        /// <param name="oid">MISSING</param>
        /// <returns>A result code. See “Certificate, Key, and Trust Services Result Codes.”</returns>
        public static int SecPolicyGetOID(IntPtr policyRef, out CSSM_DATA oid)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof (IntPtr)));
            Marshal.WriteIntPtr(__local1, IntPtr.Zero);
            int __result = SecPolicyGetOID_Inner(policyRef, __local1);
            oid = (CSSM_DATA) Marshal.PtrToStructure(__local1, typeof(CSSM_DATA));
            Marshal.FreeHGlobal(__local1);
            return __result;
        }

        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecPolicyGetOID")]
        private static extern int SecPolicyGetOID_Inner(IntPtr policyRef, IntPtr oid);


        /// <summary>
        /// <para>Retrieves the trust policy handle for a policy object.</para>
        /// <para>Original signature is 'OSStatus SecPolicyGetTPHandle (  SecPolicyRef policyRef,  CSSM_TP_HANDLE *tpHandle );'</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        /// <param name="policyRef">MISSING</param>
        /// <param name="tpHandle">MISSING</param>
        /// <returns>A result code. See “Certificate, Key, and Trust Services Result Codes.”</returns>
        public static int SecPolicyGetTPHandle(IntPtr policyRef, out IntPtr tpHandle)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(IntPtr.Size);
            Marshal.WriteIntPtr(__local1, IntPtr.Zero);
            int __result = SecPolicyGetTPHandle_Inner(policyRef, __local1);
            tpHandle = Marshal.ReadIntPtr(__local1);
            Marshal.FreeHGlobal(__local1);
            return __result;
        }

        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecPolicyGetTPHandle")]
        private static extern int SecPolicyGetTPHandle_Inner(IntPtr policyRef, IntPtr tpHandle);


        /// <summary>
        /// <para>Retrieves a policy’s value.</para>
        /// <para>Original signature is 'OSStatus SecPolicyGetValue (  SecPolicyRef policyRef,  CSSM_DATA *value );'</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        /// <param name="policyRef">MISSING</param>
        /// <param name="value">MISSING</param>
        /// <returns>A result code. See “Certificate, Key, and Trust Services Result Codes.”</returns>
        public static int SecPolicyGetValue(IntPtr policyRef, out CSSM_DATA value)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof (IntPtr)));
            Marshal.WriteIntPtr(__local1, IntPtr.Zero);
            int __result = SecPolicyGetValue_Inner(policyRef, __local1);
            value = (CSSM_DATA) Marshal.PtrToStructure(__local1, typeof(CSSM_DATA));
            Marshal.FreeHGlobal(__local1);
            return __result;
        }

        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecPolicyGetValue")]
        private static extern int SecPolicyGetValue_Inner(IntPtr policyRef, IntPtr value);


        /// <summary>
        /// <para>Retrieves a policy object for the next policy matching specified search criteria.</para>
        /// <para>Original signature is 'OSStatus SecPolicySearchCopyNext (  SecPolicySearchRef searchRef,  SecPolicyRef *policyRef );'</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        /// <param name="searchRef">MISSING</param>
        /// <param name="policyRef">MISSING</param>
        /// <returns>A result code. When there are no more policies that match the parameters specified to SecPolicySearchCreate, errSecPolicyNotFound is returned. See “Certificate, Key, and Trust Services Result Codes.”</returns>
        public static int SecPolicySearchCopyNext(IntPtr searchRef, out IntPtr policyRef)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(IntPtr.Size);
            Marshal.WriteIntPtr(__local1, IntPtr.Zero);
            int __result = SecPolicySearchCopyNext_Inner(searchRef, __local1);
            policyRef = Marshal.ReadIntPtr(__local1);
            Marshal.FreeHGlobal(__local1);
            return __result;
        }

        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecPolicySearchCopyNext")]
        private static extern int SecPolicySearchCopyNext_Inner(IntPtr searchRef, IntPtr policyRef);


        /// <summary>
        /// <para>Creates a search object for finding policies.</para>
        /// <para>Original signature is 'OSStatus SecPolicySearchCreate (  CSSM_CERT_TYPE certType,  const CSSM_OID *policyOID,  const CSSM_DATA *value,  SecPolicySearchRef *searchRef );'</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        /// <param name="certType">MISSING</param>
        /// <param name="policyOID">MISSING</param>
        /// <param name="value">MISSING</param>
        /// <param name="searchRef">MISSING</param>
        /// <returns>A result code. See “Certificate, Key, and Trust Services Result Codes.”</returns>
        public static int SecPolicySearchCreate(CSSM_CERT_TYPE certType, ref CSSM_DATA policyOID, ref CSSM_DATA value, out IntPtr searchRef)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof (IntPtr)));
            IntPtr __local2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof (IntPtr)));
            IntPtr __local3 = Marshal.AllocHGlobal(IntPtr.Size);
            Marshal.StructureToPtr(policyOID, __local1, false);
            Marshal.StructureToPtr(value, __local2, false);
            Marshal.WriteIntPtr(__local3, IntPtr.Zero);
            int __result = SecPolicySearchCreate_Inner(certType, __local1, __local2, __local3);
            policyOID = (CSSM_DATA) Marshal.PtrToStructure(__local1, typeof(CSSM_DATA));
            value = (CSSM_DATA) Marshal.PtrToStructure(__local2, typeof(CSSM_DATA));
            searchRef = Marshal.ReadIntPtr(__local3);
            Marshal.FreeHGlobal(__local1);
            Marshal.FreeHGlobal(__local2);
            Marshal.FreeHGlobal(__local3);
            return __result;
        }

        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecPolicySearchCreate")]
        private static extern int SecPolicySearchCreate_Inner(CSSM_CERT_TYPE certType, IntPtr policyOID, IntPtr value, IntPtr searchRef);


#if MACOSX_10_5
        /// <summary>
        /// <para>Sets a policy's value.</para>
        /// <para>Original signature is 'OSStatus SecPolicySetValue(  SecPolicyRef policyRef,  const CSSM_DATA *value );'</para>
        /// <para>Available in Mac OS X v10.5 and later.</para>
        /// </summary>
        /// <param name="policyRef">MISSING</param>
        /// <param name="value">MISSING</param>
        /// <returns>A result code. See “Certificate, Key, and Trust Services Result Codes.”</returns>
        public static int SecPolicySetValue(IntPtr policyRef, ref CSSM_DATA value)
        {
            IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof (IntPtr)));
            Marshal.StructureToPtr(value, __local1, false);
            int __result = SecPolicySetValue_Inner(policyRef, __local1);
            value = (CSSM_DATA) Marshal.PtrToStructure(__local1, typeof(CSSM_DATA));
            Marshal.FreeHGlobal(__local1);
            return __result;
        }

        [DllImport("/System/Library/Frameworks/Security.framework/Security", EntryPoint="SecPolicySetValue")]
        private static extern int SecPolicySetValue_Inner(IntPtr policyRef, IntPtr value);

#endif

    }

    /// <summary>
    /// <para>Indicates certificate item attributes.</para>
    /// <para>Available in Mac OS X v10.2 and later.</para>
    /// </summary>
    [GeneratedCodeAttribute("MonobjcGenerator", "0.0.0.0")]
    public enum CertificateItemAttributes : uint
    {
        /// <summary>
        /// <para>DER-encoded subject distinguished name.</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        kSecSubjectItemAttr = 0x7375626A,
        /// <summary>
        /// <para>DER-encoded issuer distinguished name.</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        kSecIssuerItemAttr = 0x69737375,
        /// <summary>
        /// <para>DER-encoded certificate serial number (without the tag and length).</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        kSecSerialNumberItemAttr = 0x736E6272,
        /// <summary>
        /// <para>Public key hash.</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        kSecPublicKeyHashItemAttr = 0x68706B79,
        /// <summary>
        /// <para>Subject key identifier.</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        kSecSubjectKeyIdentifierItemAttr = 0x736B6964,
        /// <summary>
        /// <para>Certificate type.</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        kSecCertTypeItemAttr = 0x63747970,
        /// <summary>
        /// <para>Certificate encoding.</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        kSecCertEncodingItemAttr = 0x63656E63,
    }

    /// <summary>
    /// <para>Specifies the status of a certificate.</para>
    /// <para>Available in Mac OS X v10.2 and later.</para>
    /// </summary>
    [GeneratedCodeAttribute("MonobjcGenerator", "0.0.0.0")]
    public enum CSSM_TP_APPLE_CERT_STATUS : uint
    {
        /// <summary>
        /// <para>The certificate has expired.</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        CSSM_CERT_STATUS_EXPIRED = 0x00000001,
        /// <summary>
        /// <para>The certificate is not yet valid. In addition to the expiration, or “Not Valid After,” date and time, each certificate has a “Not Valid Before” date and time.</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        CSSM_CERT_STATUS_NOT_VALID_YET = 0x00000002,
        /// <summary>
        /// <para>This is one of the certificates included in the array of certificates passed to the SecTrustCreateWithCertificates function.</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        CSSM_CERT_STATUS_IS_IN_INPUT_CERTS = 0x00000004,
        /// <summary>
        /// <para>This certificate was found in the system’s store of anchor certificates (see SecTrustSetAnchorCertificates).</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        CSSM_CERT_STATUS_IS_IN_ANCHORS = 0x00000008,
        /// <summary>
        /// <para>The certificate is a root certificate. If this bit is set but the CSSM_CERT_STATUS_IS_IN_ANCHORS bit is not, then this is an untrusted anchor.</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        CSSM_CERT_STATUS_IS_ROOT = 0x00000010,
        /// <summary>
        /// <para>The certificate was obtained through some mechanism other than the certificates stored by the operating system and those passed into the SecTrustCreateWithCertificates function. For example, the certificate might have been fetched over a network.</para>
        /// <para>Available in Mac OS X v10.3 and later.</para>
        /// </summary>
        CSSM_CERT_STATUS_IS_FROM_NET = 0x00000020,
    }

#if MACOSX_10_6
    /// <summary>
    /// <para>Specifies the type of padding to be used when creating or verifying a digital signature.</para>
    /// <para>Available in Mac OS X v10.6 and later.</para>
    /// </summary>
    [GeneratedCodeAttribute("MonobjcGenerator", "0.0.0.0")]
    public enum SecPadding : uint
    {
#if MACOSX_10_6
        /// <summary>
        /// <para>No padding.</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        kSecPaddingNone = 0,
#endif
#if MACOSX_10_6
        /// <summary>
        /// <para>PKCS1 padding.</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        kSecPaddingPKCS1 = 1,
#endif
#if MACOSX_10_6
        /// <summary>
        /// <para>Data to be signed is an MD2 hash.</para>
        /// <para>Standard ASN.1 padding is done, as well as PKCS1 padding of the underlying RSA operation. Used with SecKeyRawSign and SecKeyRawVerify only.</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        kSecPaddingPKCS1MD2 = 0x8000,
#endif
#if MACOSX_10_6
        /// <summary>
        /// <para>Data to be signed is an MD5 hash.</para>
        /// <para>Standard ASN.1 padding is done, as well as PKCS1 padding of the underlying RSA operation. Used with SecKeyRawSign and SecKeyRawVerify only.</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        kSecPaddingPKCS1MD5 = 0x8001,
#endif
#if MACOSX_10_6
        /// <summary>
        /// <para>Data to be signed is a SHA1 hash.</para>
        /// <para>Standard ASN.1 padding will be done, as well as PKCS1 padding of the underlying RSA operation. Used with SecKeyRawSign and SecKeyRawVerify only.</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        kSecPaddingPKCS1SHA1 = 0x8002,
#endif
    }
#endif

    /// <summary>
    /// <para>Specifies the trust result type.</para>
    /// <para>Available in Mac OS X v10.2 and later.</para>
    /// </summary>
    [GeneratedCodeAttribute("MonobjcGenerator", "0.0.0.0")]
    public enum SecTrustResultType : uint
    {
        /// <summary>
        /// <para>Invalid setting or result. Usually, this result indicates that the SecTrustEvaluate function did not complete successfully.</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        kSecTrustResultInvalid,
        /// <summary>
        /// <para>The user indicated that you may trust the certificate for the purposes designated in the specified policies. This value may be returned by the SecTrustEvaluate function or stored as part of the user trust settings. In the Keychain Access utility, this value is termed “Always Trust.”</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        kSecTrustResultProceed,
        /// <summary>
        /// <para>Confirmation from the user is required before proceeding. This value may be returned by the SecTrustEvaluate function or stored as part of the user trust settings. In the Keychain Access utility, this value is termed “Ask Permission.”</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        kSecTrustResultConfirm,
        /// <summary>
        /// <para>The user specified that the certificate should not be trusted. This value may be returned by the SecTrustEvaluate function or stored as part of the user trust settings. In the Keychain Access utility, this value is termed “Never Trust.”</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        kSecTrustResultDeny,
        /// <summary>
        /// <para>The user did not specify a trust setting. This value may be returned by the SecTrustEvaluate function or stored as part of the user trust settings. In the Keychain Access utility, this value is termed “Use System Policy.” This is the default user setting.</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        kSecTrustResultUnspecified,
        /// <summary>
        /// <para>Trust denied; retry after changing settings. For example, if trust is denied because the certificate has expired, you can ask the user whether to trust the certificate anyway. If the user answers yes, then use the SecTrustSettingsSetTrustSettings function to set the user trust setting to kSecTrustResultProceed and call SecTrustEvaluate again. This value may be returned by the SecTrustEvaluate function but not stored as part of the user trust settings.</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        kSecTrustResultRecoverableTrustFailure,
        /// <summary>
        /// <para>Trust denied; no simple fix is available. For example, if a certificate cannot be verified because it is corrupted, trust cannot be established without replacing the certificate. This value may be returned by the SecTrustEvaluate function but not stored as part of the user trust settings.</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        kSecTrustResultFatalTrustFailure,
        /// <summary>
        /// <para>A failure other than that of trust evaluation; for example, an internal failure of the SecTrustEvaluate function. This value may be returned by the SecTrustEvaluate function but not stored as part of the user trust settings.</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        kSecTrustResultOtherError,
    }

    /// <summary>
    /// <para>Specifies options for the AppleX509TP trust policy module’s default action.</para>
    /// <para>Available in Mac OS X v10.2 and later.</para>
    /// </summary>
    [GeneratedCodeAttribute("MonobjcGenerator", "0.0.0.0")]
    public enum CSSM_APPLE_TP_ACTION_FLAGS : uint
    {
        /// <summary>
        /// <para>Ignore the expiration date and time for all certificates.</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        CSSM_TP_ACTION_ALLOW_EXPIRED = 0x00000001,
        /// <summary>
        /// <para>First certificate is that of a certification authority (CA). By formal definition, a valid certificate chain must begin with a certificate that is not a CA. Set this bit if you want to validate a partial chain, starting with a CA and working toward the anchor, or if you want to evaluate a single self-signed certificate as a one-certificate “chain” for testing purposes.</para>
        /// <para>Available in Mac OS X v10.3 and later.</para>
        /// </summary>
        CSSM_TP_ACTION_LEAF_IS_CA = 0x00000002,
        /// <summary>
        /// <para>Enable fetching intermediate certificates over the network using http or LDAP.</para>
        /// <para>Available in Mac OS X v10.3 and later.</para>
        /// </summary>
        CSSM_TP_ACTION_FETCH_CERT_FROM_NET = 0x00000004,
        /// <summary>
        /// <para>Ignore the expiration date and time for root certificates only.</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        CSSM_TP_ACTION_ALLOW_EXPIRED_ROOT = 0x00000008,
    }

#if MACOSX_10_5
    /// <summary>
    /// <para>The credential type to be returned by SecKeyGetCredentials.</para>
    /// <para>Available in Mac OS X v10.5 and later.</para>
    /// </summary>
    [GeneratedCodeAttribute("MonobjcGenerator", "0.0.0.0")]
    public enum SecCredentialType : uint
    {
#if MACOSX_10_5
        /// <summary>
        /// <para>The default setting for determining whether to present UI is used.</para>
        /// <para>The default setting can be changed with a call to SecKeychainSetUserInteractionAllowed.</para>
        /// <para>Available in Mac OS X v10.5 and later.</para>
        /// </summary>
        kSecCredentialTypeDefault = 0,
#endif
#if MACOSX_10_5
        /// <summary>
        /// <para>Keychain operations on keys that have this credential are allowed to present UI if required.</para>
        /// <para>Available in Mac OS X v10.5 and later.</para>
        /// </summary>
        kSecCredentialTypeWithUI,
#endif
#if MACOSX_10_5
        /// <summary>
        /// <para>Keychain operations on keys that have this credential are not allowed to present UI, and will fail if UI is required.</para>
        /// <para>Available in Mac OS X v10.5 and later.</para>
        /// </summary>
        kSecCredentialTypeNoUI,
#endif
    }
#endif

#if MACOSX_10_5
    /// <summary>
    /// <para>The trust settings domains used by the trust settings API.</para>
    /// <para>Available in Mac OS X v10.5 and later.</para>
    /// </summary>
    [GeneratedCodeAttribute("MonobjcGenerator", "0.0.0.0")]
    public enum SecTrustSettingsDomain : uint
    {
#if MACOSX_10_5
        /// <summary>
        /// <para>Per-user trust settings.</para>
        /// <para>Available in Mac OS X v10.5 and later.</para>
        /// </summary>
        kSecTrustSettingsDomainUser = 0,
#endif
#if MACOSX_10_5
        /// <summary>
        /// <para>Locally administered, system-wide trust settings.</para>
        /// <para>Administrator privileges are required to make changes to this domain.</para>
        /// <para>Available in Mac OS X v10.5 and later.</para>
        /// </summary>
        kSecTrustSettingsDomainAdmin,
#endif
#if MACOSX_10_5
        /// <summary>
        /// <para>System trust settings.</para>
        /// <para>These trust settings are immutable and comprise the set of trusted root certificates supplied in Mac OS X. These settings are read-only, even by root.</para>
        /// <para>Available in Mac OS X v10.5 and later.</para>
        /// </summary>
        kSecTrustSettingsDomainSystem,
#endif
    }
#endif

#if MACOSX_10_5
    /// <summary>
    /// <para>Allowed uses for the encryption key in a certificate.</para>
    /// <para>Available in Mac OS X v10.5 and later.</para>
    /// </summary>
    [GeneratedCodeAttribute("MonobjcGenerator", "0.0.0.0")]
    public enum SecTrustSettingsKeyUsage : uint
    {
#if MACOSX_10_5
        /// <summary>
        /// <para>The key can be used to sign data or verify a signature.</para>
        /// <para>Available in Mac OS X v10.5 and later.</para>
        /// </summary>
        kSecTrustSettingsKeyUseSignature = 0x00000001,
#endif
#if MACOSX_10_5
        /// <summary>
        /// <para>The key can be used to encrypt or decrypt data.</para>
        /// <para>Available in Mac OS X v10.5 and later.</para>
        /// </summary>
        kSecTrustSettingsKeyUseEnDecryptData = 0x00000002,
#endif
#if MACOSX_10_5
        /// <summary>
        /// <para>The key can be used to encrypt or decrypt (wrap or unwrap) a key.</para>
        /// <para>Private keys must be wrapped before they can be exported from a keychain.</para>
        /// <para>Available in Mac OS X v10.5 and later.</para>
        /// </summary>
        kSecTrustSettingsKeyUseEnDecryptKey = 0x00000004,
#endif
#if MACOSX_10_5
        /// <summary>
        /// <para>The key can be used to sign a certificate or verify a signature.</para>
        /// <para>Available in Mac OS X v10.5 and later.</para>
        /// </summary>
        kSecTrustSettingsKeyUseSignCert = 0x00000008,
#endif
#if MACOSX_10_5
        /// <summary>
        /// <para>The key can be used to sign an OCSP (online certificate status protocol) message or CRL (certificate verification list), or to verify a signature.</para>
        /// <para>OCSP messages and CRLs are used to revoke certificates.</para>
        /// <para>Available in Mac OS X v10.5 and later.</para>
        /// </summary>
        kSecTrustSettingsKeyUseSignRevocation = 0x00000010,
#endif
#if MACOSX_10_5
        /// <summary>
        /// <para>The key is a private key that has been shared using a key exchange protocol, such as Diffie-Hellman key exchange.</para>
        /// <para>Available in Mac OS X v10.5 and later.</para>
        /// </summary>
        kSecTrustSettingsKeyUseKeyExchange = 0x00000020,
#endif
#if MACOSX_10_5
        /// <summary>
        /// <para>The key can be used for any purpose.</para>
        /// <para>This is the default key-use setting if no other key use is specified.</para>
        /// <para>Available in Mac OS X v10.5 and later.</para>
        /// </summary>
        kSecTrustSettingsKeyUseAny = 0xffffffff,
#endif
    }
#endif

#if MACOSX_10_5
    /// <summary>
    /// <para>Effective trust settings for usage constraints dictionaries used by the SecTrustSettingsCopyTrustSettings and SecTrustSettingsSetTrustSettings functions.</para>
    /// <para>Available in Mac OS X v10.5 and later.</para>
    /// </summary>
    [GeneratedCodeAttribute("MonobjcGenerator", "0.0.0.0")]
    public enum SecTrustSettingsResult : uint
    {
#if MACOSX_10_5
        /// <summary>
        /// <para>Never valid in a trust settings array or in an API call.</para>
        /// <para>Available in Mac OS X v10.5 and later.</para>
        /// </summary>
        kSecTrustSettingsResultInvalid = 0,
#endif
#if MACOSX_10_5
        /// <summary>
        /// <para>This root certificate is explicitly trusted.</para>
        /// <para>If the certificate is not a root (self-signed) certificate, the usage constraints dictionary is invalid.</para>
        /// <para>Available in Mac OS X v10.5 and later.</para>
        /// </summary>
        kSecTrustSettingsResultTrustRoot,
#endif
#if MACOSX_10_5
        /// <summary>
        /// <para>This non-root certificate is explicitly trusted as if it were a trusted root.</para>
        /// <para>Available in Mac OS X v10.5 and later.</para>
        /// </summary>
        kSecTrustSettingsResultTrustAsRoot,
#endif
#if MACOSX_10_5
        /// <summary>
        /// <para>This certificate is explicitly distrusted.</para>
        /// <para>Available in Mac OS X v10.5 and later.</para>
        /// </summary>
        kSecTrustSettingsResultDeny,
#endif
#if MACOSX_10_5
        /// <summary>
        /// <para>This certificate is neither trusted nor distrusted. This value can be used to specify an "allowed error" without assigning trust to a specific certificate.</para>
        /// <para>This value can be used to specify an allowed error without assigning trust to the certificate.</para>
        /// <para>Available in Mac OS X v10.5 and later.</para>
        /// </summary>
        kSecTrustSettingsResultUnspecified,
#endif
    }
#endif
}
