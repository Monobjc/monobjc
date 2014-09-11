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

namespace Monobjc.Security
{
    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_X509_ALGORITHM_IDENTIFIER
    {
        public CSSM_DATA algorithm;
        public CSSM_DATA parameters;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_X509_TYPE_VALUE_PAIR
    {
        public CSSM_DATA type;
        public byte valueType; /* The Tag to be used when */
        /*this value is BER encoded */
        public CSSM_DATA value;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_X509_RDN
    {
        public UInt32 numberOfPairs;
        public IntPtr AttributeTypeAndValue;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_X509_NAME
    {
        public UInt32 numberOfRDNs;
        public IntPtr RelativeDistinguishedName;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_X509_SUBJECT_PUBLIC_KEY_INFO
    {
        public CSSM_X509_ALGORITHM_IDENTIFIER algorithm;
        public CSSM_DATA subjectPublicKey;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_X509_TIME
    {
        public byte timeType;
        public CSSM_DATA time;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_X509_VALIDITY
    {
        public CSSM_X509_TIME notBefore;
        public CSSM_X509_TIME notAfter;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct cssm_x509ext_basicConstraints
    {
        public int cA;
        public int pathLenConstraintPresent;
        public UInt32 pathLenConstraint;
    }

    public enum CSSM_X509EXT_DATA_FORMAT
    {
        CSSM_X509_DATAFORMAT_ENCODED = 0,
        CSSM_X509_DATAFORMAT_PARSED,
        CSSM_X509_DATAFORMAT_PAIR
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_X509EXT_TAGandVALUE
    {
        public byte type;
        public CSSM_DATA value;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_X509EXT_PAIR
    {
        public CSSM_X509EXT_TAGandVALUE tagAndValue;
        public IntPtr parsedValue;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_X509_EXTENSION
    {
        public CSSM_DATA extnId;
        public int critical;
        public CSSM_X509EXT_DATA_FORMAT format;
        public IntPtr value;
        public CSSM_DATA BERvalue;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_X509_EXTENSIONS
    {
        public UInt32 numberOfExtensions;
        public IntPtr extensions;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_X509_TBS_CERTIFICATE
    {
        public CSSM_DATA version;
        public CSSM_DATA serialNumber;
        public CSSM_X509_ALGORITHM_IDENTIFIER signature;
        public CSSM_X509_NAME issuer;
        public CSSM_X509_VALIDITY validity;
        public CSSM_X509_NAME subject;
        public CSSM_X509_SUBJECT_PUBLIC_KEY_INFO subjectPublicKeyInfo;
        public CSSM_DATA issuerUniqueIdentifier;
        public CSSM_DATA subjectUniqueIdentifier;
        public CSSM_X509_EXTENSIONS extensions;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_X509_SIGNATURE
    {
        public CSSM_X509_ALGORITHM_IDENTIFIER algorithmIdentifier;
        public CSSM_DATA encrypted;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_X509_SIGNED_CERTIFICATE
    {
        public CSSM_X509_TBS_CERTIFICATE certificate;
        public CSSM_X509_SIGNATURE signature;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_X509EXT_POLICYQUALIFIERINFO
    {
        public CSSM_DATA policyQualifierId;
        public CSSM_DATA value;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_X509EXT_POLICYQUALIFIERS
    {
        public UInt32 numberOfPolicyQualifiers;
        public IntPtr policyQualifier;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_X509EXT_POLICYINFO
    {
        public CSSM_DATA policyIdentifier;
        public CSSM_X509EXT_POLICYQUALIFIERS policyQualifiers;
    }


    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_X509_REVOKED_CERT_ENTRY
    {
        public CSSM_DATA certificateSerialNumber;
        public CSSM_X509_TIME revocationDate;
        public CSSM_X509_EXTENSIONS extensions;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_X509_REVOKED_CERT_LIST
    {
        public UInt32 numberOfRevokedCertEntries;
        public IntPtr revokedCertEntry;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_X509_TBS_CERTLIST
    {
        public CSSM_DATA version;
        public CSSM_X509_ALGORITHM_IDENTIFIER signature;
        public CSSM_X509_NAME issuer;
        public CSSM_X509_TIME thisUpdate;
        public CSSM_X509_TIME nextUpdate;
        public IntPtr revokedCertificates;
        public CSSM_X509_EXTENSIONS extensions;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_X509_SIGNED_CRL
    {
        public CSSM_X509_TBS_CERTLIST tbsCertList;
        public CSSM_X509_SIGNATURE signature;
    }
}