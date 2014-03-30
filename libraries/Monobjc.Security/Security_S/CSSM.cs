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
    public struct CSSM_DATA
    {
        public IntPtr Length; /* in bytes */
        public IntPtr Data;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_GUID
    {
        public UInt32 Data1;
        public UInt16 Data2;
        public UInt16 Data3;
        public UInt32 Data4;
    }

    public enum CSSM_KEY_HIERARCHY : uint
    {
        CSSM_KEY_HIERARCHY_NONE = 0,
        CSSM_KEY_HIERARCHY_INTEG = 1,
        CSSM_KEY_HIERARCHY_EXPORT = 2
    }

    public enum CSSM_PVC_MODE : uint
    {
        CSSM_PVC_NONE = 0,
        CSSM_PVC_APP = 1,
        CSSM_PVC_SP = 2
    }

    public enum CSSM_PRIVILEGE_SCOPE : uint
    {
        CSSM_PRIVILEGE_SCOPE_NONE = 0,
        CSSM_PRIVILEGE_SCOPE_PROCESS = 1,
        CSSM_PRIVILEGE_SCOPE_THREAD = 2
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_VERSION
    {
        public UInt32 Major;
        public UInt32 Minor;
    }

    public enum CSSM_SERVICE_MASK : uint
    {
        CSSM_SERVICE_CSSM = 0x1,
        CSSM_SERVICE_CSP = 0x2,
        CSSM_SERVICE_DL = 0x4,
        CSSM_SERVICE_CL = 0x8,
        CSSM_SERVICE_TP = 0x10,
        CSSM_SERVICE_AC = 0x20,
        CSSM_SERVICE_KR = 0x40
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_SUBSERVICE_UID
    {
        public CSSM_GUID Guid;
        public CSSM_VERSION Version;
        public UInt32 SubserviceId;
        public UInt32 SubserviceType;
    }

    public enum CSSM_MODULE_EVENT : uint
    {
        CSSM_NOTIFY_INSERT = 1,
        CSSM_NOTIFY_REMOVE = 2,
        CSSM_NOTIFY_FAULT = 3
    } ;

    public delegate int CSSM_API_ModuleEventHandler(ref CSSM_GUID ModuleGuid, IntPtr AppNotifyCallbackCtx, UInt32 SubserviceId, uint ServiceType, uint EventType);

    public enum CSSM_ATTACH_FLAGS : uint
    {
        CSSM_ATTACH_READ_ONLY = 0x00000001
    }

    public enum CSSM_USEE_TAG : ulong
    {
        CSSM_USEE_LAST = 0xFF,
        CSSM_USEE_NONE = 0,
        CSSM_USEE_DOMESTIC = 1,
        CSSM_USEE_FINANCIAL = 2,
        CSSM_USEE_KRLE = 3,
        CSSM_USEE_KRENT = 4,
        CSSM_USEE_SSL = 5,
        CSSM_USEE_AUTHENTICATION = 6,
        CSSM_USEE_KEYEXCH = 7,
        CSSM_USEE_MEDICAL = 8,
        CSSM_USEE_INSURANCE = 9,
        CSSM_USEE_WEAK = 10
    }

    public enum CSSM_NET_ADDRESS_TYPE : uint
    {
        CSSM_ADDR_NONE = 0,
        CSSM_ADDR_CUSTOM = 1,
        CSSM_ADDR_URL = 2, /* char* */
        CSSM_ADDR_SOCKADDR = 3,
        CSSM_ADDR_NAME = 4 /* char* - qualified by access method */
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_NET_ADDRESS
    {
        public CSSM_NET_ADDRESS_TYPE AddressType;
        public CSSM_DATA Address;
    }

    public enum CSSM_NET_PROTOCOL : uint
    {
        CSSM_NET_PROTO_NONE = 0, /* local */
        CSSM_NET_PROTO_CUSTOM = 1, /* proprietary implementation */
        CSSM_NET_PROTO_UNSPECIFIED = 2, /* implementation default */
        CSSM_NET_PROTO_LDAP = 3, /* light weight directory access protocol */
        CSSM_NET_PROTO_LDAPS = 4, /* ldap/ssl where SSL initiates the connection */
        CSSM_NET_PROTO_LDAPNS = 5, /* ldap where ldap negotiates an SSL session */
        CSSM_NET_PROTO_X500DAP = 6, /* x.500 Directory access protocol */
        CSSM_NET_PROTO_FTP = 7, /* ftp for cert/crl fetch */
        CSSM_NET_PROTO_FTPS = 8, /* ftp/ssl/tls where SSL/TLS initiates the connection */
        CSSM_NET_PROTO_OCSP = 9, /* online certificate status protocol */
        CSSM_NET_PROTO_CMP = 10, /* the cert request protocol in PKIX3 */
        CSSM_NET_PROTO_CMPS = 11 /* The ssl/tls derivative of CMP */
    } ;

    public delegate int CSSM_CALLBACK(out CSSM_DATA OutData, IntPtr CallerCtx);

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_CRYPTO_DATA
    {
        public CSSM_DATA Param;
        public CSSM_CALLBACK Callback;
        public IntPtr CallerCtx;
    }

    public enum CSSM_WORDID_TYPE
    {
        CSSM_WORDID__UNK_ = -1, /* not in dictionary */
        CSSM_WORDID__NLU_ = 0, /* not yet looked up */
        CSSM_WORDID__STAR_ = 1,
        CSSM_WORDID_A = 2,
        CSSM_WORDID_ACL = 3,
        CSSM_WORDID_ALPHA = 4,
        CSSM_WORDID_B = 5,
        CSSM_WORDID_BER = 6,
        CSSM_WORDID_BINARY = 7,
        CSSM_WORDID_BIOMETRIC = 8,
        CSSM_WORDID_C = 9,
        CSSM_WORDID_CANCELED = 10,
        CSSM_WORDID_CERT = 11,
        CSSM_WORDID_COMMENT = 12,
        CSSM_WORDID_CRL = 13,
        CSSM_WORDID_CUSTOM = 14,
        CSSM_WORDID_D = 15,
        CSSM_WORDID_DATE = 16,
        CSSM_WORDID_DB_DELETE = 17,
        CSSM_WORDID_DB_EXEC_STORED_QUERY = 18,
        CSSM_WORDID_DB_INSERT = 19,
        CSSM_WORDID_DB_MODIFY = 20,
        CSSM_WORDID_DB_READ = 21,
        CSSM_WORDID_DBS_CREATE = 22,
        CSSM_WORDID_DBS_DELETE = 23,
        CSSM_WORDID_DECRYPT = 24,
        CSSM_WORDID_DELETE = 25,
        CSSM_WORDID_DELTA_CRL = 26,
        CSSM_WORDID_DER = 27,
        CSSM_WORDID_DERIVE = 28,
        CSSM_WORDID_DISPLAY = 29,
        CSSM_WORDID_DO = 30,
        CSSM_WORDID_DSA = 31,
        CSSM_WORDID_DSA_SHA1 = 32,
        CSSM_WORDID_E = 33,
        CSSM_WORDID_ELGAMAL = 34,
        CSSM_WORDID_ENCRYPT = 35,
        CSSM_WORDID_ENTRY = 36,
        CSSM_WORDID_EXPORT_CLEAR = 37,
        CSSM_WORDID_EXPORT_WRAPPED = 38,
        CSSM_WORDID_G = 39,
        CSSM_WORDID_GE = 40,
        CSSM_WORDID_GENKEY = 41,
        CSSM_WORDID_HASH = 42,
        CSSM_WORDID_HASHED_PASSWORD = 43,
        CSSM_WORDID_HASHED_SUBJECT = 44,
        CSSM_WORDID_HAVAL = 45,
        CSSM_WORDID_IBCHASH = 46,
        CSSM_WORDID_IMPORT_CLEAR = 47,
        CSSM_WORDID_IMPORT_WRAPPED = 48,
        CSSM_WORDID_INTEL = 49,
        CSSM_WORDID_ISSUER = 50,
        CSSM_WORDID_ISSUER_INFO = 51,
        CSSM_WORDID_K_OF_N = 52,
        CSSM_WORDID_KEA = 53,
        CSSM_WORDID_KEYHOLDER = 54,
        CSSM_WORDID_L = 55,
        CSSM_WORDID_LE = 56,
        CSSM_WORDID_LOGIN = 57,
        CSSM_WORDID_LOGIN_NAME = 58,
        CSSM_WORDID_MAC = 59,
        CSSM_WORDID_MD2 = 60,
        CSSM_WORDID_MD2WITHRSA = 61,
        CSSM_WORDID_MD4 = 62,
        CSSM_WORDID_MD5 = 63,
        CSSM_WORDID_MD5WITHRSA = 64,
        CSSM_WORDID_N = 65,
        CSSM_WORDID_NAME = 66,
        CSSM_WORDID_NDR = 67,
        CSSM_WORDID_NHASH = 68,
        CSSM_WORDID_NOT_AFTER = 69,
        CSSM_WORDID_NOT_BEFORE = 70,
        CSSM_WORDID_NULL = 71,
        CSSM_WORDID_NUMERIC = 72,
        CSSM_WORDID_OBJECT_HASH = 73,
        CSSM_WORDID_ONE_TIME = 74,
        CSSM_WORDID_ONLINE = 75,
        CSSM_WORDID_OWNER = 76,
        CSSM_WORDID_P = 77,
        CSSM_WORDID_PAM_NAME = 78,
        CSSM_WORDID_PASSWORD = 79,
        CSSM_WORDID_PGP = 80,
        CSSM_WORDID_PREFIX = 81,
        CSSM_WORDID_PRIVATE_KEY = 82,
        CSSM_WORDID_PROMPTED_BIOMETRIC = 83,
        CSSM_WORDID_PROMPTED_PASSWORD = 84,
        CSSM_WORDID_PROPAGATE = 85,
        CSSM_WORDID_PROTECTED_BIOMETRIC = 86,
        CSSM_WORDID_PROTECTED_PASSWORD = 87,
        CSSM_WORDID_PROTECTED_PIN = 88,
        CSSM_WORDID_PUBLIC_KEY = 89,
        CSSM_WORDID_PUBLIC_KEY_FROM_CERT = 90,
        CSSM_WORDID_Q = 91,
        CSSM_WORDID_RANGE = 92,
        CSSM_WORDID_REVAL = 93,
        CSSM_WORDID_RIPEMAC = 94,
        CSSM_WORDID_RIPEMD = 95,
        CSSM_WORDID_RIPEMD160 = 96,
        CSSM_WORDID_RSA = 97,
        CSSM_WORDID_RSA_ISO9796 = 98,
        CSSM_WORDID_RSA_PKCS = 99,
        CSSM_WORDID_RSA_PKCS_MD5 = 100,
        CSSM_WORDID_RSA_PKCS_SHA1 = 101,
        CSSM_WORDID_RSA_PKCS1 = 102,
        CSSM_WORDID_RSA_PKCS1_MD5 = 103,
        CSSM_WORDID_RSA_PKCS1_SHA1 = 104,
        CSSM_WORDID_RSA_PKCS1_SIG = 105,
        CSSM_WORDID_RSA_RAW = 106,
        CSSM_WORDID_SDSIV1 = 107,
        CSSM_WORDID_SEQUENCE = 108,
        CSSM_WORDID_SET = 109,
        CSSM_WORDID_SEXPR = 110,
        CSSM_WORDID_SHA1 = 111,
        CSSM_WORDID_SHA1WITHDSA = 112,
        CSSM_WORDID_SHA1WITHECDSA = 113,
        CSSM_WORDID_SHA1WITHRSA = 114,
        CSSM_WORDID_SIGN = 115,
        CSSM_WORDID_SIGNATURE = 116,
        CSSM_WORDID_SIGNED_NONCE = 117,
        CSSM_WORDID_SIGNED_SECRET = 118,
        CSSM_WORDID_SPKI = 119,
        CSSM_WORDID_SUBJECT = 120,
        CSSM_WORDID_SUBJECT_INFO = 121,
        CSSM_WORDID_TAG = 122,
        CSSM_WORDID_THRESHOLD = 123,
        CSSM_WORDID_TIME = 124,
        CSSM_WORDID_URI = 125,
        CSSM_WORDID_VERSION = 126,
        CSSM_WORDID_X509_ATTRIBUTE = 127,
        CSSM_WORDID_X509V1 = 128,
        CSSM_WORDID_X509V2 = 129,
        CSSM_WORDID_X509V3 = 130,
        CSSM_WORDID_X9_ATTRIBUTE = 131,
        CSSM_WORDID_VENDOR_START = 0x00010000,
        CSSM_WORDID_VENDOR_END = 0x7FFF0000
    }

    public enum CSSM_LIST_ELEMENT_TYPE : uint
    {
        CSSM_LIST_ELEMENT_DATUM = 0x00,
        CSSM_LIST_ELEMENT_SUBLIST = 0x01,
        CSSM_LIST_ELEMENT_WORDID = 0x02
    }

    public enum CSSM_LIST_TYPE : uint
    {
        CSSM_LIST_TYPE_UNKNOWN = 0,
        CSSM_LIST_TYPE_CUSTOM = 1,
        CSSM_LIST_TYPE_SEXPR = 2
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_LIST
    {
        public CSSM_LIST_TYPE ListType; /* type of this list */
        public IntPtr Head; /* head of the list */
        public IntPtr Tail; /* tail of the list */
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_LIST_ELEMENT
    {
        public IntPtr extElement; /* next list element */
        public CSSM_WORDID_TYPE WordID; /* integer identifier associated */
        /* with a Word value */
        public CSSM_LIST_ELEMENT_TYPE ElementType;
        public IntPtr Element;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_TUPLE
    {
        /* 5-tuple definition */
        public CSSM_LIST Issuer; /* issuer, or empty if ACL */
        public CSSM_LIST Subject; /* subject */
        public Int32 Delegate; /* permission to delegate */
        public CSSM_LIST AuthorizationTag; /* authorization field */
        public CSSM_LIST ValidityPeriod; /* validity information (dates) */
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_TUPLEGROUP
    {
        public UInt32 NumberOfTuples;
        public IntPtr Tuples;
    }

    public enum CSSM_SAMPLE_TYPE
    {
        CSSM_SAMPLE_TYPE_PASSWORD = CSSM_WORDID_TYPE.CSSM_WORDID_PASSWORD,
        CSSM_SAMPLE_TYPE_HASHED_PASSWORD = CSSM_WORDID_TYPE.CSSM_WORDID_HASHED_PASSWORD,
        CSSM_SAMPLE_TYPE_PROTECTED_PASSWORD = CSSM_WORDID_TYPE.CSSM_WORDID_PROTECTED_PASSWORD,
        CSSM_SAMPLE_TYPE_PROMPTED_PASSWORD = CSSM_WORDID_TYPE.CSSM_WORDID_PROMPTED_PASSWORD,
        CSSM_SAMPLE_TYPE_SIGNED_NONCE = CSSM_WORDID_TYPE.CSSM_WORDID_SIGNED_NONCE,
        CSSM_SAMPLE_TYPE_SIGNED_SECRET = CSSM_WORDID_TYPE.CSSM_WORDID_SIGNED_SECRET,
        CSSM_SAMPLE_TYPE_BIOMETRIC = CSSM_WORDID_TYPE.CSSM_WORDID_BIOMETRIC,
        CSSM_SAMPLE_TYPE_PROTECTED_BIOMETRIC = CSSM_WORDID_TYPE.CSSM_WORDID_PROTECTED_BIOMETRIC,
        CSSM_SAMPLE_TYPE_PROMPTED_BIOMETRIC = CSSM_WORDID_TYPE.CSSM_WORDID_PROMPTED_BIOMETRIC,
        CSSM_SAMPLE_TYPE_THRESHOLD = CSSM_WORDID_TYPE.CSSM_WORDID_THRESHOLD
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_SAMPLE
    {
        public CSSM_LIST TypedSample;
        public IntPtr Verifier;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_SAMPLEGROUP
    {
        public UInt32 NumberOfSamples;
        public IntPtr Samples;
    }

    public delegate IntPtr CSSM_MALLOC(IntPtr size, IntPtr allocref);

    public delegate void CSSM_FREE(IntPtr memblock, IntPtr allocref);

    public delegate IntPtr CSSM_REALLOC(IntPtr memblock, IntPtr size, IntPtr allocref);

    public delegate IntPtr CSSM_CALLOC(uint num, IntPtr size, IntPtr allocref);

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_MEMORY_FUNCS
    {
        public CSSM_MALLOC malloc_func;
        public CSSM_FREE free_func;
        public CSSM_REALLOC realloc_func;
        public CSSM_CALLOC calloc_func;
        public IntPtr AllocRef;
    }

    public delegate int CSSM_CHALLENGE_CALLBACK(IntPtr Challenge, IntPtr Reponse, IntPtr CallerCtx, IntPtr MemFuncs);

    public enum CSSM_CERT_TYPE : uint
    {
        CSSM_CERT_UNKNOWN = 0x00,
        CSSM_CERT_X_509v1 = 0x01,
        CSSM_CERT_X_509v2 = 0x02,
        CSSM_CERT_X_509v3 = 0x03,
        CSSM_CERT_PGP = 0x04,
        CSSM_CERT_SPKI = 0x05,
        CSSM_CERT_SDSIv1 = 0x06,
        CSSM_CERT_Intel = 0x08,
        CSSM_CERT_X_509_ATTRIBUTE = 0x09, /* X.509 attribute cert */
        CSSM_CERT_X9_ATTRIBUTE = 0x0A, /* X9 attribute cert */
        CSSM_CERT_TUPLE = 0x0B,
        CSSM_CERT_ACL_ENTRY = 0x0C,
        CSSM_CERT_MULTIPLE = 0x7FFE,
        CSSM_CERT_LAST = 0x7FFF,
        /* Applications wishing to define their own custom certificate
           type should define and publicly document a uint32 value greater
           than the CSSM_CL_CUSTOM_CERT_TYPE */
        CSSM_CL_CUSTOM_CERT_TYPE = 0x08000
    } ;

    public enum CSSM_CERT_ENCODING : uint
    {
        CSSM_CERT_ENCODING_UNKNOWN = 0x00,
        CSSM_CERT_ENCODING_CUSTOM = 0x01,
        CSSM_CERT_ENCODING_BER = 0x02,
        CSSM_CERT_ENCODING_DER = 0x03,
        CSSM_CERT_ENCODING_NDR = 0x04,
        CSSM_CERT_ENCODING_SEXPR = 0x05,
        CSSM_CERT_ENCODING_PGP = 0x06,
        CSSM_CERT_ENCODING_MULTIPLE = 0x7FFE,
        CSSM_CERT_ENCODING_LAST = 0x7FFF,
        /* Applications wishing to define their own custom certificate
           encoding should create a uint32 value greater than the
           CSSM_CL_CUSTOM_CERT_ENCODING */
        CSSM_CL_CUSTOM_CERT_ENCODING = 0x8000
    } ;

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_ENCODED_CERT
    {
        public CSSM_CERT_TYPE CertType; /* type of certificate */
        public CSSM_CERT_ENCODING CertEncoding; /* encoding for this packed cert */
        public CSSM_DATA CertBlob; /* packed cert */
    }

    public enum CSSM_CERT_PARSE_FORMAT : uint
    {
        CSSM_CERT_PARSE_FORMAT_NONE = 0x00,
        CSSM_CERT_PARSE_FORMAT_CUSTOM = 0x01, /* void* */
        CSSM_CERT_PARSE_FORMAT_SEXPR = 0x02, /* CSSM_LIST */
        CSSM_CERT_PARSE_FORMAT_COMPLEX = 0x03, /* void* */
        CSSM_CERT_PARSE_FORMAT_OID_NAMED = 0x04, /* CSSM_FIELDGROUP */
        CSSM_CERT_PARSE_FORMAT_TUPLE = 0x05, /* CSSM_TUPLE */
        CSSM_CERT_PARSE_FORMAT_MULTIPLE = 0x7FFE,
        /* multiple forms, each cert carries a
           parse format indicator */
        CSSM_CERT_PARSE_FORMAT_LAST = 0x7FFF,
        /* Applications wishing to define their
           own custom parse format should create
           a * uint32 value greater than the
           CSSM_CL_CUSTOM_CERT_PARSE_FORMAT */
        CSSM_CL_CUSTOM_CERT_PARSE_FORMAT = 0x8000
    } ;

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_PARSED_CERT
    {
        public CSSM_CERT_TYPE CertType; /* certificate type */
        public CSSM_CERT_PARSE_FORMAT ParsedCertFormat;
        /* struct of ParsedCert */
        public IntPtr ParsedCert; /* parsed cert (to be typecast) */
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_CERT_PAIR
    {
        public CSSM_ENCODED_CERT EncodedCert; /* an encoded certificate blob */
        public CSSM_PARSED_CERT ParsedCert; /* equivalent parsed certificate */
    }

    public enum CSSM_CERTGROUP_TYPE : uint
    {
        CSSM_CERTGROUP_DATA = 0x00,
        CSSM_CERTGROUP_ENCODED_CERT = 0x01,
        CSSM_CERTGROUP_PARSED_CERT = 0x02,
        CSSM_CERTGROUP_CERT_PAIR = 0x03
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_CERTGROUP
    {
        public CSSM_CERT_TYPE CertType;
        public CSSM_CERT_ENCODING CertEncoding;
        public UInt32 NumCerts; /* # of certificates in this list */
        public IntPtr GroupList;
        public CSSM_CERTGROUP_TYPE CertGroupType;
        /* type of structure in the GroupList */
        public IntPtr Reserved; /* reserved for implementation dependent use */
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_BASE_CERTS
    {
        public IntPtr TPHandle;
        public IntPtr CLHandle;
        public IntPtr Certs;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_ACCESS_CREDENTIALS
    {
        public IntPtr EntryTag;
        public CSSM_BASE_CERTS BaseCerts;
        public CSSM_SAMPLEGROUP Samples;
        public CSSM_CHALLENGE_CALLBACK Callback;
        public IntPtr CallerCtx;
    }

    public enum CSSM_ACL_SUBJECT_TYPE
    {
        CSSM_ACL_SUBJECT_TYPE_ANY = CSSM_WORDID_TYPE.CSSM_WORDID__STAR_,
        CSSM_ACL_SUBJECT_TYPE_THRESHOLD = CSSM_WORDID_TYPE.CSSM_WORDID_THRESHOLD,
        CSSM_ACL_SUBJECT_TYPE_PASSWORD = CSSM_WORDID_TYPE.CSSM_WORDID_PASSWORD,
        CSSM_ACL_SUBJECT_TYPE_PROTECTED_PASSWORD = CSSM_WORDID_TYPE.CSSM_WORDID_PROTECTED_PASSWORD,
        CSSM_ACL_SUBJECT_TYPE_PROMPTED_PASSWORD = CSSM_WORDID_TYPE.CSSM_WORDID_PROMPTED_PASSWORD,
        CSSM_ACL_SUBJECT_TYPE_PUBLIC_KEY = CSSM_WORDID_TYPE.CSSM_WORDID_PUBLIC_KEY,
        CSSM_ACL_SUBJECT_TYPE_HASHED_SUBJECT = CSSM_WORDID_TYPE.CSSM_WORDID_HASHED_SUBJECT,
        CSSM_ACL_SUBJECT_TYPE_BIOMETRIC = CSSM_WORDID_TYPE.CSSM_WORDID_BIOMETRIC,
        CSSM_ACL_SUBJECT_TYPE_PROTECTED_BIOMETRIC = CSSM_WORDID_TYPE.CSSM_WORDID_PROTECTED_BIOMETRIC,
        CSSM_ACL_SUBJECT_TYPE_PROMPTED_BIOMETRIC = CSSM_WORDID_TYPE.CSSM_WORDID_PROMPTED_BIOMETRIC,
        CSSM_ACL_SUBJECT_TYPE_LOGIN_NAME = CSSM_WORDID_TYPE.CSSM_WORDID_LOGIN_NAME,
        CSSM_ACL_SUBJECT_TYPE_EXT_PAM_NAME = CSSM_WORDID_TYPE.CSSM_WORDID_PAM_NAME
    } ;

    public enum CSSM_ACL_AUTHORIZATION_TAG
    {
        /* All vendor specific constants must be in the number range
           starting at CSSM_ACL_AUTHORIZATION_TAG_VENDOR_DEFINED_START */
        CSSM_ACL_AUTHORIZATION_TAG_VENDOR_DEFINED_START = 0x00010000,
        /* No restrictions. Permission to perform all operations on
           the resource or available to an ACL owner.  */
        CSSM_ACL_AUTHORIZATION_ANY = CSSM_WORDID_TYPE.CSSM_WORDID__STAR_,
        /* Defined authorization tag values for CSPs */
        CSSM_ACL_AUTHORIZATION_LOGIN = CSSM_WORDID_TYPE.CSSM_WORDID_LOGIN,
        CSSM_ACL_AUTHORIZATION_GENKEY = CSSM_WORDID_TYPE.CSSM_WORDID_GENKEY,
        CSSM_ACL_AUTHORIZATION_DELETE = CSSM_WORDID_TYPE.CSSM_WORDID_DELETE,
        CSSM_ACL_AUTHORIZATION_EXPORT_WRAPPED = CSSM_WORDID_TYPE.CSSM_WORDID_EXPORT_WRAPPED,
        CSSM_ACL_AUTHORIZATION_EXPORT_CLEAR = CSSM_WORDID_TYPE.CSSM_WORDID_EXPORT_CLEAR,
        CSSM_ACL_AUTHORIZATION_IMPORT_WRAPPED = CSSM_WORDID_TYPE.CSSM_WORDID_IMPORT_WRAPPED,
        CSSM_ACL_AUTHORIZATION_IMPORT_CLEAR = CSSM_WORDID_TYPE.CSSM_WORDID_IMPORT_CLEAR,
        CSSM_ACL_AUTHORIZATION_SIGN = CSSM_WORDID_TYPE.CSSM_WORDID_SIGN,
        CSSM_ACL_AUTHORIZATION_ENCRYPT = CSSM_WORDID_TYPE.CSSM_WORDID_ENCRYPT,
        CSSM_ACL_AUTHORIZATION_DECRYPT = CSSM_WORDID_TYPE.CSSM_WORDID_DECRYPT,
        CSSM_ACL_AUTHORIZATION_MAC = CSSM_WORDID_TYPE.CSSM_WORDID_MAC,
        CSSM_ACL_AUTHORIZATION_DERIVE = CSSM_WORDID_TYPE.CSSM_WORDID_DERIVE,
        /* Defined authorization tag values for DLs */
        CSSM_ACL_AUTHORIZATION_DBS_CREATE = CSSM_WORDID_TYPE.CSSM_WORDID_DBS_CREATE,
        CSSM_ACL_AUTHORIZATION_DBS_DELETE = CSSM_WORDID_TYPE.CSSM_WORDID_DBS_DELETE,
        CSSM_ACL_AUTHORIZATION_DB_READ = CSSM_WORDID_TYPE.CSSM_WORDID_DB_READ,
        CSSM_ACL_AUTHORIZATION_DB_INSERT = CSSM_WORDID_TYPE.CSSM_WORDID_DB_INSERT,
        CSSM_ACL_AUTHORIZATION_DB_MODIFY = CSSM_WORDID_TYPE.CSSM_WORDID_DB_MODIFY,
        CSSM_ACL_AUTHORIZATION_DB_DELETE = CSSM_WORDID_TYPE.CSSM_WORDID_DB_DELETE
    } ;

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_AUTHORIZATIONGROUP
    {
        public UInt32 NumberOfAuthTags;
        public IntPtr AuthTags;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_ACL_VALIDITY_PERIOD
    {
        public CSSM_DATA StartDate;
        public CSSM_DATA EndDate;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_ACL_ENTRY_PROTOTYPE
    {
        public CSSM_LIST TypedSubject;
        public Int32 Delegate;
        public CSSM_AUTHORIZATIONGROUP Authorization;
        public CSSM_ACL_VALIDITY_PERIOD TimeRange;
        public IntPtr EntryTag;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_ACL_OWNER_PROTOTYPE
    {
        public CSSM_LIST TypedSubject;
        public Int32 Delegate;
    }

    public delegate int CSSM_ACL_SUBJECT_CALLBACK(IntPtr SubjectRequest, IntPtr SubjectResponse, IntPtr CallerContext, IntPtr MemFuncs);

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_ACL_ENTRY_INPUT
    {
        public CSSM_ACL_ENTRY_PROTOTYPE Prototype;
        public CSSM_ACL_SUBJECT_CALLBACK Callback;
        public IntPtr CallerContext;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_RESOURCE_CONTROL_CONTEXT
    {
        public IntPtr AccessCred;
        public CSSM_ACL_ENTRY_INPUT InitialAclEntry;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_ACL_ENTRY_INFO
    {
        public CSSM_ACL_ENTRY_PROTOTYPE EntryPublicInfo;
        public IntPtr EntryHandle;
    }

    public enum CSSM_ACL_EDIT_MODE : uint
    {
        CSSM_ACL_EDIT_MODE_ADD = 1,
        CSSM_ACL_EDIT_MODE_DELETE = 2,
        CSSM_ACL_EDIT_MODE_REPLACE = 3
    } ;

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_ACL_EDIT
    {
        public CSSM_ACL_EDIT_MODE EditMode;
        public IntPtr OldEntryHandle;
        public IntPtr NewEntry;
    }

    public delegate void CSSM_PROC_ADDR();

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_FUNC_NAME_ADDR
    {
        public IntPtr Name;
        public CSSM_PROC_ADDR Address;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_DATE
    {
        public UInt32 Year;
        public UInt16 Month;
        public UInt16 Day;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_RANGE
    {
        public UInt32 Min; /* inclusive minimum value */
        public UInt32 Max; /* inclusive maximum value */
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_QUERY_SIZE_DATA
    {
        public UInt32 SizeInputBlock; /* size of input data block */
        public UInt32 SizeOutputBlock; /* size of resulting output data block */
    }

    public enum CSSM_HEADERVERSION : uint
    {
        CSSM_KEYHEADER_VERSION = 2
    } ;

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_KEY_SIZE
    {
        public UInt32 LogicalKeySizeInBits; /* Logical key size in bits */
        public UInt32 EffectiveKeySizeInBits; /* Effective key size in bits */
    }

    public enum CSSM_KEYBLOB_TYPE : uint
    {
        CSSM_KEYBLOB_RAW = 0, /* The blob is a clear, raw key */
        CSSM_KEYBLOB_REFERENCE = 2, /* The blob is a reference to a key */
        CSSM_KEYBLOB_WRAPPED = 3, /* The blob is a wrapped RAW key */
        CSSM_KEYBLOB_OTHER = 0xFFFFFFFF
    } ;

    public enum CSSM_KEYBLOB_FORMAT : uint
    {
        /* Raw Format */
        CSSM_KEYBLOB_RAW_FORMAT_NONE = 0,
        /* No further conversion need to be done */
        CSSM_KEYBLOB_RAW_FORMAT_PKCS1 = 1, /* RSA PKCS1 V1.5 */
        CSSM_KEYBLOB_RAW_FORMAT_PKCS3 = 2, /* RSA PKCS3 V1.5 */
        CSSM_KEYBLOB_RAW_FORMAT_MSCAPI = 3, /* Microsoft CAPI V2.0 */
        CSSM_KEYBLOB_RAW_FORMAT_PGP = 4, /* PGP V */
        CSSM_KEYBLOB_RAW_FORMAT_FIPS186 = 5, /* US Gov. FIPS 186 - DSS V */
        CSSM_KEYBLOB_RAW_FORMAT_BSAFE = 6, /* RSA Bsafe V3.0 */
        CSSM_KEYBLOB_RAW_FORMAT_CCA = 9, /* CCA clear public key blob */
        CSSM_KEYBLOB_RAW_FORMAT_PKCS8 = 10, /* RSA PKCS8 V1.2 */
        CSSM_KEYBLOB_RAW_FORMAT_SPKI = 11, /* SPKI Specification */
        CSSM_KEYBLOB_RAW_FORMAT_OCTET_STRING = 12,
        CSSM_KEYBLOB_RAW_FORMAT_OTHER = 0xFFFFFFFF, /* Other, CSP defined */

        /* Wrapped Format */
        CSSM_KEYBLOB_WRAPPED_FORMAT_NONE = 0,
        /* No further conversion need to be done */
        CSSM_KEYBLOB_WRAPPED_FORMAT_PKCS8 = 1, /* RSA PKCS8 V1.2 */
        CSSM_KEYBLOB_WRAPPED_FORMAT_PKCS7 = 2,
        CSSM_KEYBLOB_WRAPPED_FORMAT_MSCAPI = 3,
        CSSM_KEYBLOB_WRAPPED_FORMAT_OTHER = 0xFFFFFFFF, /* Other, CSP defined */

        /* Reference Format */
        CSSM_KEYBLOB_REF_FORMAT_INTEGER = 0, /* Reference is a number or handle */
        CSSM_KEYBLOB_REF_FORMAT_STRING = 1, /* Reference is a string or label */
        CSSM_KEYBLOB_REF_FORMAT_SPKI = 2, /* Reference is an SPKI S-expression */
        /* to be evaluated to locate the key */
        CSSM_KEYBLOB_REF_FORMAT_OTHER = 0xFFFFFFFF, /* Other, CSP defined */
    } ;

    public enum CSSM_KEYCLASS : uint
    {
        CSSM_KEYCLASS_PUBLIC_KEY = 0, /* Key is public key */
        CSSM_KEYCLASS_PRIVATE_KEY = 1, /* Key is private key */
        CSSM_KEYCLASS_SESSION_KEY = 2, /* Key is session or symmetric key */
        CSSM_KEYCLASS_SECRET_PART = 3, /* Key is part of secret key */
        CSSM_KEYCLASS_OTHER = 0xFFFFFFFF /* Other */
    } ;

    public enum CSSM_KEYATTR_FLAGS : uint
    {
        /* Valid only during call to an API. Will never be valid when set in a key header */
        CSSM_KEYATTR_RETURN_DEFAULT = 0x00000000,
        CSSM_KEYATTR_RETURN_DATA = 0x10000000,
        CSSM_KEYATTR_RETURN_REF = 0x20000000,
        CSSM_KEYATTR_RETURN_NONE = 0x40000000,
        /* Valid during an API call and in a key header */
        CSSM_KEYATTR_PERMANENT = 0x00000001,
        CSSM_KEYATTR_PRIVATE = 0x00000002,
        CSSM_KEYATTR_MODIFIABLE = 0x00000004,
        CSSM_KEYATTR_SENSITIVE = 0x00000008,
        CSSM_KEYATTR_EXTRACTABLE = 0x00000020,
        /* Valid only in a key header generated by a CSP, not valid during an API call */
        CSSM_KEYATTR_ALWAYS_SENSITIVE = 0x00000010,
        CSSM_KEYATTR_NEVER_EXTRACTABLE = 0x00000040
    } ;

    public enum CSSM_KEYUSE : uint
    {
        CSSM_KEYUSE_ANY = 0x80000000,
        CSSM_KEYUSE_ENCRYPT = 0x00000001,
        CSSM_KEYUSE_DECRYPT = 0x00000002,
        CSSM_KEYUSE_SIGN = 0x00000004,
        CSSM_KEYUSE_VERIFY = 0x00000008,
        CSSM_KEYUSE_SIGN_RECOVER = 0x00000010,
        CSSM_KEYUSE_VERIFY_RECOVER = 0x00000020,
        CSSM_KEYUSE_WRAP = 0x00000040,
        CSSM_KEYUSE_UNWRAP = 0x00000080,
        CSSM_KEYUSE_DERIVE = 0x00000100
    } ;

    public enum CSSM_ALGORITHMS : uint
    {
        CSSM_ALGID_NONE = 0,
        CSSM_ALGID_CUSTOM = CSSM_ALGID_NONE + 1,
        CSSM_ALGID_DH = CSSM_ALGID_NONE + 2,
        CSSM_ALGID_PH = CSSM_ALGID_NONE + 3,
        CSSM_ALGID_KEA = CSSM_ALGID_NONE + 4,
        CSSM_ALGID_MD2 = CSSM_ALGID_NONE + 5,
        CSSM_ALGID_MD4 = CSSM_ALGID_NONE + 6,
        CSSM_ALGID_MD5 = CSSM_ALGID_NONE + 7,
        CSSM_ALGID_SHA1 = CSSM_ALGID_NONE + 8,
        CSSM_ALGID_NHASH = CSSM_ALGID_NONE + 9,
        CSSM_ALGID_HAVAL = CSSM_ALGID_NONE + 10,
        CSSM_ALGID_RIPEMD = CSSM_ALGID_NONE + 11,
        CSSM_ALGID_IBCHASH = CSSM_ALGID_NONE + 12,
        CSSM_ALGID_RIPEMAC = CSSM_ALGID_NONE + 13,
        CSSM_ALGID_DES = CSSM_ALGID_NONE + 14,
        CSSM_ALGID_DESX = CSSM_ALGID_NONE + 15,
        CSSM_ALGID_RDES = CSSM_ALGID_NONE + 16,
        CSSM_ALGID_3DES_3KEY_EDE = CSSM_ALGID_NONE + 17,
        CSSM_ALGID_3DES_2KEY_EDE = CSSM_ALGID_NONE + 18,
        CSSM_ALGID_3DES_1KEY_EEE = CSSM_ALGID_NONE + 19,
        CSSM_ALGID_3DES_3KEY = CSSM_ALGID_3DES_3KEY_EDE,
        CSSM_ALGID_3DES_3KEY_EEE = CSSM_ALGID_NONE + 20,
        CSSM_ALGID_3DES_2KEY = CSSM_ALGID_3DES_2KEY_EDE,
        CSSM_ALGID_3DES_2KEY_EEE = CSSM_ALGID_NONE + 21,
        CSSM_ALGID_3DES_1KEY = CSSM_ALGID_3DES_3KEY_EEE,
        CSSM_ALGID_IDEA = CSSM_ALGID_NONE + 22,
        CSSM_ALGID_RC2 = CSSM_ALGID_NONE + 23,
        CSSM_ALGID_RC5 = CSSM_ALGID_NONE + 24,
        CSSM_ALGID_RC4 = CSSM_ALGID_NONE + 25,
        CSSM_ALGID_SEAL = CSSM_ALGID_NONE + 26,
        CSSM_ALGID_CAST = CSSM_ALGID_NONE + 27,
        CSSM_ALGID_BLOWFISH = CSSM_ALGID_NONE + 28,
        CSSM_ALGID_SKIPJACK = CSSM_ALGID_NONE + 29,
        CSSM_ALGID_LUCIFER = CSSM_ALGID_NONE + 30,
        CSSM_ALGID_MADRYGA = CSSM_ALGID_NONE + 31,
        CSSM_ALGID_FEAL = CSSM_ALGID_NONE + 32,
        CSSM_ALGID_REDOC = CSSM_ALGID_NONE + 33,
        CSSM_ALGID_REDOC3 = CSSM_ALGID_NONE + 34,
        CSSM_ALGID_LOKI = CSSM_ALGID_NONE + 35,
        CSSM_ALGID_KHUFU = CSSM_ALGID_NONE + 36,
        CSSM_ALGID_KHAFRE = CSSM_ALGID_NONE + 37,
        CSSM_ALGID_MMB = CSSM_ALGID_NONE + 38,
        CSSM_ALGID_GOST = CSSM_ALGID_NONE + 39,
        CSSM_ALGID_SAFER = CSSM_ALGID_NONE + 40,
        CSSM_ALGID_CRAB = CSSM_ALGID_NONE + 41,
        CSSM_ALGID_RSA = CSSM_ALGID_NONE + 42,
        CSSM_ALGID_DSA = CSSM_ALGID_NONE + 43,
        CSSM_ALGID_MD5WithRSA = CSSM_ALGID_NONE + 44,
        CSSM_ALGID_MD2WithRSA = CSSM_ALGID_NONE + 45,
        CSSM_ALGID_ElGamal = CSSM_ALGID_NONE + 46,
        CSSM_ALGID_MD2Random = CSSM_ALGID_NONE + 47,
        CSSM_ALGID_MD5Random = CSSM_ALGID_NONE + 48,
        CSSM_ALGID_SHARandom = CSSM_ALGID_NONE + 49,
        CSSM_ALGID_DESRandom = CSSM_ALGID_NONE + 50,
        CSSM_ALGID_SHA1WithRSA = CSSM_ALGID_NONE + 51,
        CSSM_ALGID_CDMF = CSSM_ALGID_NONE + 52,
        CSSM_ALGID_CAST3 = CSSM_ALGID_NONE + 53,
        CSSM_ALGID_CAST5 = CSSM_ALGID_NONE + 54,
        CSSM_ALGID_GenericSecret = CSSM_ALGID_NONE + 55,
        CSSM_ALGID_ConcatBaseAndKey = CSSM_ALGID_NONE + 56,
        CSSM_ALGID_ConcatKeyAndBase = CSSM_ALGID_NONE + 57,
        CSSM_ALGID_ConcatBaseAndData = CSSM_ALGID_NONE + 58,
        CSSM_ALGID_ConcatDataAndBase = CSSM_ALGID_NONE + 59,
        CSSM_ALGID_XORBaseAndData = CSSM_ALGID_NONE + 60,
        CSSM_ALGID_ExtractFromKey = CSSM_ALGID_NONE + 61,
        CSSM_ALGID_SSL3PreMasterGen = CSSM_ALGID_NONE + 62,
        CSSM_ALGID_SSL3MasterDerive = CSSM_ALGID_NONE + 63,
        CSSM_ALGID_SSL3KeyAndMacDerive = CSSM_ALGID_NONE + 64,
        CSSM_ALGID_SSL3MD5_MAC = CSSM_ALGID_NONE + 65,
        CSSM_ALGID_SSL3SHA1_MAC = CSSM_ALGID_NONE + 66,
        CSSM_ALGID_PKCS5_PBKDF1_MD5 = CSSM_ALGID_NONE + 67,
        CSSM_ALGID_PKCS5_PBKDF1_MD2 = CSSM_ALGID_NONE + 68,
        CSSM_ALGID_PKCS5_PBKDF1_SHA1 = CSSM_ALGID_NONE + 69,
        CSSM_ALGID_WrapLynks = CSSM_ALGID_NONE + 70,
        CSSM_ALGID_WrapSET_OAEP = CSSM_ALGID_NONE + 71,
        CSSM_ALGID_BATON = CSSM_ALGID_NONE + 72,
        CSSM_ALGID_ECDSA = CSSM_ALGID_NONE + 73,
        CSSM_ALGID_MAYFLY = CSSM_ALGID_NONE + 74,
        CSSM_ALGID_JUNIPER = CSSM_ALGID_NONE + 75,
        CSSM_ALGID_FASTHASH = CSSM_ALGID_NONE + 76,
        CSSM_ALGID_3DES = CSSM_ALGID_NONE + 77,
        CSSM_ALGID_SSL3MD5 = CSSM_ALGID_NONE + 78,
        CSSM_ALGID_SSL3SHA1 = CSSM_ALGID_NONE + 79,
        CSSM_ALGID_FortezzaTimestamp = CSSM_ALGID_NONE + 80,
        CSSM_ALGID_SHA1WithDSA = CSSM_ALGID_NONE + 81,
        CSSM_ALGID_SHA1WithECDSA = CSSM_ALGID_NONE + 82,
        CSSM_ALGID_DSA_BSAFE = CSSM_ALGID_NONE + 83,
        CSSM_ALGID_ECDH = CSSM_ALGID_NONE + 84,
        CSSM_ALGID_ECMQV = CSSM_ALGID_NONE + 85,
        CSSM_ALGID_PKCS12_SHA1_PBE = CSSM_ALGID_NONE + 86,
        CSSM_ALGID_ECNRA = CSSM_ALGID_NONE + 87,
        CSSM_ALGID_SHA1WithECNRA = CSSM_ALGID_NONE + 88,
        CSSM_ALGID_ECES = CSSM_ALGID_NONE + 89,
        CSSM_ALGID_ECAES = CSSM_ALGID_NONE + 90,
        CSSM_ALGID_SHA1HMAC = CSSM_ALGID_NONE + 91,
        CSSM_ALGID_FIPS186Random = CSSM_ALGID_NONE + 92,
        CSSM_ALGID_ECC = CSSM_ALGID_NONE + 93,
        CSSM_ALGID_MQV = CSSM_ALGID_NONE + 94,
        CSSM_ALGID_NRA = CSSM_ALGID_NONE + 95,
        CSSM_ALGID_IntelPlatformRandom = CSSM_ALGID_NONE + 96,
        CSSM_ALGID_UTC = CSSM_ALGID_NONE + 97,
        CSSM_ALGID_HAVAL3 = CSSM_ALGID_NONE + 98,
        CSSM_ALGID_HAVAL4 = CSSM_ALGID_NONE + 99,
        CSSM_ALGID_HAVAL5 = CSSM_ALGID_NONE + 100,
        CSSM_ALGID_TIGER = CSSM_ALGID_NONE + 101,
        CSSM_ALGID_MD5HMAC = CSSM_ALGID_NONE + 102,
        CSSM_ALGID_PKCS5_PBKDF2 = CSSM_ALGID_NONE + 103,
        CSSM_ALGID_RUNNING_COUNTER = CSSM_ALGID_NONE + 104,
        CSSM_ALGID_LAST = CSSM_ALGID_NONE + 0x7FFFFFFF,
        /* All algorithms IDs that are vendor specific, and not
           part of the CSSM specification should be defined relative
           to CSSM_ALGID_VENDOR_DEFINED. */
        CSSM_ALGID_VENDOR_DEFINED = CSSM_ALGID_NONE + 0x80000000
    } ;

    public enum CSSM_ENCRYPT_MODE : uint
    {
        CSSM_ALGMODE_NONE = 0,
        CSSM_ALGMODE_CUSTOM = CSSM_ALGMODE_NONE + 1,
        CSSM_ALGMODE_ECB = CSSM_ALGMODE_NONE + 2,
        CSSM_ALGMODE_ECBPad = CSSM_ALGMODE_NONE + 3,
        CSSM_ALGMODE_CBC = CSSM_ALGMODE_NONE + 4,
        CSSM_ALGMODE_CBC_IV8 = CSSM_ALGMODE_NONE + 5,
        CSSM_ALGMODE_CBCPadIV8 = CSSM_ALGMODE_NONE + 6,
        CSSM_ALGMODE_CFB = CSSM_ALGMODE_NONE + 7,
        CSSM_ALGMODE_CFB_IV8 = CSSM_ALGMODE_NONE + 8,
        CSSM_ALGMODE_CFBPadIV8 = CSSM_ALGMODE_NONE + 9,
        CSSM_ALGMODE_OFB = CSSM_ALGMODE_NONE + 10,
        CSSM_ALGMODE_OFB_IV8 = CSSM_ALGMODE_NONE + 11,
        CSSM_ALGMODE_OFBPadIV8 = CSSM_ALGMODE_NONE + 12,
        CSSM_ALGMODE_COUNTER = CSSM_ALGMODE_NONE + 13,
        CSSM_ALGMODE_BC = CSSM_ALGMODE_NONE + 14,
        CSSM_ALGMODE_PCBC = CSSM_ALGMODE_NONE + 15,
        CSSM_ALGMODE_CBCC = CSSM_ALGMODE_NONE + 16,
        CSSM_ALGMODE_OFBNLF = CSSM_ALGMODE_NONE + 17,
        CSSM_ALGMODE_PBC = CSSM_ALGMODE_NONE + 18,
        CSSM_ALGMODE_PFB = CSSM_ALGMODE_NONE + 19,
        CSSM_ALGMODE_CBCPD = CSSM_ALGMODE_NONE + 20,
        CSSM_ALGMODE_PUBLIC_KEY = CSSM_ALGMODE_NONE + 21,
        CSSM_ALGMODE_PRIVATE_KEY = CSSM_ALGMODE_NONE + 22,
        CSSM_ALGMODE_SHUFFLE = CSSM_ALGMODE_NONE + 23,
        CSSM_ALGMODE_ECB64 = CSSM_ALGMODE_NONE + 24,
        CSSM_ALGMODE_CBC64 = CSSM_ALGMODE_NONE + 25,
        CSSM_ALGMODE_OFB64 = CSSM_ALGMODE_NONE + 26,
        CSSM_ALGMODE_CFB32 = CSSM_ALGMODE_NONE + 28,
        CSSM_ALGMODE_CFB16 = CSSM_ALGMODE_NONE + 29,
        CSSM_ALGMODE_CFB8 = CSSM_ALGMODE_NONE + 30,
        CSSM_ALGMODE_WRAP = CSSM_ALGMODE_NONE + 31,
        CSSM_ALGMODE_PRIVATE_WRAP = CSSM_ALGMODE_NONE + 32,
        CSSM_ALGMODE_RELAYX = CSSM_ALGMODE_NONE + 33,
        CSSM_ALGMODE_ECB128 = CSSM_ALGMODE_NONE + 34,
        CSSM_ALGMODE_ECB96 = CSSM_ALGMODE_NONE + 35,
        CSSM_ALGMODE_CBC128 = CSSM_ALGMODE_NONE + 36,
        CSSM_ALGMODE_OAEP_HASH = CSSM_ALGMODE_NONE + 37,
        CSSM_ALGMODE_PKCS1_EME_V15 = CSSM_ALGMODE_NONE + 38,
        CSSM_ALGMODE_PKCS1_EME_OAEP = CSSM_ALGMODE_NONE + 39,
        CSSM_ALGMODE_PKCS1_EMSA_V15 = CSSM_ALGMODE_NONE + 40,
        CSSM_ALGMODE_ISO_9796 = CSSM_ALGMODE_NONE + 41,
        CSSM_ALGMODE_X9_31 = CSSM_ALGMODE_NONE + 42,
        CSSM_ALGMODE_LAST = CSSM_ALGMODE_NONE + 0x7FFFFFFF,
        /* All algorithms modes that are vendor specific, and
           not part of the CSSM specification should be defined
           relative to CSSM_ALGMODE_VENDOR_DEFINED. */
        CSSM_ALGMODE_VENDOR_DEFINED = CSSM_ALGMODE_NONE + 0x80000000
    } ;

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_KEYHEADER
    {
        public CSSM_HEADERVERSION HeaderVersion; /* Key header version */
        public CSSM_GUID CspId; /* GUID of CSP generating the key */
        public CSSM_KEYBLOB_TYPE BlobType; /* See BlobType enum */
        public CSSM_KEYBLOB_FORMAT Format; /* Raw or Reference format */
        public CSSM_ALGORITHMS AlgorithmId; /* Algorithm ID of key */
        public CSSM_KEYCLASS KeyClass; /* Public/Private/Secret, etc. */
        public UInt32 LogicalKeySizeInBits; /* Logical key size in bits */
        public CSSM_KEYATTR_FLAGS KeyAttr; /* Attribute flags */
        public CSSM_KEYUSE KeyUsage; /* Key use flags */
        public CSSM_DATE StartDate; /* Effective date of key */
        public CSSM_DATE EndDate; /* Expiration date of key */
        public CSSM_ALGORITHMS WrapAlgorithmId; /* == CSSM_ALGID_NONE if clear key */
        public CSSM_ENCRYPT_MODE WrapMode; /* if alg supports multiple wrapping modes */
        public UInt32 Reserved;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_KEY
    {
        public CSSM_KEYHEADER KeyHeader; /* Fixed length key header */
        public CSSM_DATA KeyData; /* Variable length key data */
    }

    public enum CSSM_CSPTYPE : uint
    {
        CSSM_CSP_SOFTWARE = 1,
        CSSM_CSP_HARDWARE = CSSM_CSP_SOFTWARE + 1,
        CSSM_CSP_HYBRID = CSSM_CSP_SOFTWARE + 2
    } ;

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_DL_DB_HANDLE
    {
        public IntPtr DLHandle;
        public IntPtr DBHandle;
    }

    public enum CSSM_CONTEXT_TYPE : uint
    {
        CSSM_ALGCLASS_NONE = 0,
        CSSM_ALGCLASS_CUSTOM = CSSM_ALGCLASS_NONE + 1,
        CSSM_ALGCLASS_SIGNATURE = CSSM_ALGCLASS_NONE + 2,
        CSSM_ALGCLASS_SYMMETRIC = CSSM_ALGCLASS_NONE + 3,
        CSSM_ALGCLASS_DIGEST = CSSM_ALGCLASS_NONE + 4,
        CSSM_ALGCLASS_RANDOMGEN = CSSM_ALGCLASS_NONE + 5,
        CSSM_ALGCLASS_UNIQUEGEN = CSSM_ALGCLASS_NONE + 6,
        CSSM_ALGCLASS_MAC = CSSM_ALGCLASS_NONE + 7,
        CSSM_ALGCLASS_ASYMMETRIC = CSSM_ALGCLASS_NONE + 8,
        CSSM_ALGCLASS_KEYGEN = CSSM_ALGCLASS_NONE + 9,
        CSSM_ALGCLASS_DERIVEKEY = CSSM_ALGCLASS_NONE + 10
    } ;

    /* Attribute data type tags */

    public enum CSSM_ATTRIBUTE_DATA_TYPE : uint
    {
        CSSM_ATTRIBUTE_DATA_NONE = 0x00000000,
        CSSM_ATTRIBUTE_DATA_UINT32 = 0x10000000,
        CSSM_ATTRIBUTE_DATA_CSSM_DATA = 0x20000000,
        CSSM_ATTRIBUTE_DATA_CRYPTO_DATA = 0x30000000,
        CSSM_ATTRIBUTE_DATA_KEY = 0x40000000,
        CSSM_ATTRIBUTE_DATA_STRING = 0x50000000,
        CSSM_ATTRIBUTE_DATA_DATE = 0x60000000,
        CSSM_ATTRIBUTE_DATA_RANGE = 0x70000000,
        CSSM_ATTRIBUTE_DATA_ACCESS_CREDENTIALS = 0x80000000,
        CSSM_ATTRIBUTE_DATA_VERSION = 0x01000000,
        CSSM_ATTRIBUTE_DATA_DL_DB_HANDLE = 0x02000000,
        CSSM_ATTRIBUTE_DATA_KR_PROFILE = 0x03000000,
        CSSM_ATTRIBUTE_TYPE_MASK = 0xFF000000
    } ;

    public enum CSSM_ATTRIBUTE_TYPE : uint
    {
        CSSM_ATTRIBUTE_NONE = 0,
        CSSM_ATTRIBUTE_CUSTOM = CSSM_ATTRIBUTE_DATA_TYPE.CSSM_ATTRIBUTE_DATA_CSSM_DATA | 1,
        CSSM_ATTRIBUTE_DESCRIPTION = CSSM_ATTRIBUTE_DATA_TYPE.CSSM_ATTRIBUTE_DATA_STRING | 2,
        CSSM_ATTRIBUTE_KEY = CSSM_ATTRIBUTE_DATA_TYPE.CSSM_ATTRIBUTE_DATA_KEY | 3,
        CSSM_ATTRIBUTE_INIT_VECTOR = CSSM_ATTRIBUTE_DATA_TYPE.CSSM_ATTRIBUTE_DATA_CSSM_DATA | 4,
        CSSM_ATTRIBUTE_SALT = CSSM_ATTRIBUTE_DATA_TYPE.CSSM_ATTRIBUTE_DATA_CSSM_DATA | 5,
        CSSM_ATTRIBUTE_PADDING = CSSM_ATTRIBUTE_DATA_TYPE.CSSM_ATTRIBUTE_DATA_UINT32 | 6,
        CSSM_ATTRIBUTE_RANDOM = CSSM_ATTRIBUTE_DATA_TYPE.CSSM_ATTRIBUTE_DATA_CSSM_DATA | 7,
        CSSM_ATTRIBUTE_SEED = CSSM_ATTRIBUTE_DATA_TYPE.CSSM_ATTRIBUTE_DATA_CRYPTO_DATA | 8,
        CSSM_ATTRIBUTE_PASSPHRASE = CSSM_ATTRIBUTE_DATA_TYPE.CSSM_ATTRIBUTE_DATA_CRYPTO_DATA | 9,
        CSSM_ATTRIBUTE_KEY_LENGTH = CSSM_ATTRIBUTE_DATA_TYPE.CSSM_ATTRIBUTE_DATA_UINT32 | 10,
        CSSM_ATTRIBUTE_KEY_LENGTH_RANGE = CSSM_ATTRIBUTE_DATA_TYPE.CSSM_ATTRIBUTE_DATA_RANGE | 11,
        CSSM_ATTRIBUTE_BLOCK_SIZE = CSSM_ATTRIBUTE_DATA_TYPE.CSSM_ATTRIBUTE_DATA_UINT32 | 12,
        CSSM_ATTRIBUTE_OUTPUT_SIZE = CSSM_ATTRIBUTE_DATA_TYPE.CSSM_ATTRIBUTE_DATA_UINT32 | 13,
        CSSM_ATTRIBUTE_ROUNDS = CSSM_ATTRIBUTE_DATA_TYPE.CSSM_ATTRIBUTE_DATA_UINT32 | 14,
        CSSM_ATTRIBUTE_IV_SIZE = CSSM_ATTRIBUTE_DATA_TYPE.CSSM_ATTRIBUTE_DATA_UINT32 | 15,
        CSSM_ATTRIBUTE_ALG_PARAMS = CSSM_ATTRIBUTE_DATA_TYPE.CSSM_ATTRIBUTE_DATA_CSSM_DATA | 16,
        CSSM_ATTRIBUTE_LABEL = CSSM_ATTRIBUTE_DATA_TYPE.CSSM_ATTRIBUTE_DATA_CSSM_DATA | 17,
        CSSM_ATTRIBUTE_KEY_TYPE = CSSM_ATTRIBUTE_DATA_TYPE.CSSM_ATTRIBUTE_DATA_UINT32 | 18,
        CSSM_ATTRIBUTE_MODE = CSSM_ATTRIBUTE_DATA_TYPE.CSSM_ATTRIBUTE_DATA_UINT32 | 19,
        CSSM_ATTRIBUTE_EFFECTIVE_BITS = CSSM_ATTRIBUTE_DATA_TYPE.CSSM_ATTRIBUTE_DATA_UINT32 | 20,
        CSSM_ATTRIBUTE_START_DATE = CSSM_ATTRIBUTE_DATA_TYPE.CSSM_ATTRIBUTE_DATA_DATE | 21,
        CSSM_ATTRIBUTE_END_DATE = CSSM_ATTRIBUTE_DATA_TYPE.CSSM_ATTRIBUTE_DATA_DATE | 22,
        CSSM_ATTRIBUTE_KEYUSAGE = CSSM_ATTRIBUTE_DATA_TYPE.CSSM_ATTRIBUTE_DATA_UINT32 | 23,
        CSSM_ATTRIBUTE_KEYATTR = CSSM_ATTRIBUTE_DATA_TYPE.CSSM_ATTRIBUTE_DATA_UINT32 | 24,
        CSSM_ATTRIBUTE_VERSION = CSSM_ATTRIBUTE_DATA_TYPE.CSSM_ATTRIBUTE_DATA_VERSION | 25,
        CSSM_ATTRIBUTE_PRIME = CSSM_ATTRIBUTE_DATA_TYPE.CSSM_ATTRIBUTE_DATA_CSSM_DATA | 26,
        CSSM_ATTRIBUTE_BASE = CSSM_ATTRIBUTE_DATA_TYPE.CSSM_ATTRIBUTE_DATA_CSSM_DATA | 27,
        CSSM_ATTRIBUTE_SUBPRIME = CSSM_ATTRIBUTE_DATA_TYPE.CSSM_ATTRIBUTE_DATA_CSSM_DATA | 28,
        CSSM_ATTRIBUTE_ALG_ID = CSSM_ATTRIBUTE_DATA_TYPE.CSSM_ATTRIBUTE_DATA_UINT32 | 29,
        CSSM_ATTRIBUTE_ITERATION_COUNT = CSSM_ATTRIBUTE_DATA_TYPE.CSSM_ATTRIBUTE_DATA_UINT32 | 30,
        CSSM_ATTRIBUTE_ROUNDS_RANGE = CSSM_ATTRIBUTE_DATA_TYPE.CSSM_ATTRIBUTE_DATA_RANGE | 31,
        CSSM_ATTRIBUTE_KRPROFILE_LOCAL = CSSM_ATTRIBUTE_DATA_TYPE.CSSM_ATTRIBUTE_DATA_KR_PROFILE | 32,
        CSSM_ATTRIBUTE_KRPROFILE_REMOTE = CSSM_ATTRIBUTE_DATA_TYPE.CSSM_ATTRIBUTE_DATA_KR_PROFILE | 33,
        CSSM_ATTRIBUTE_CSP_HANDLE = CSSM_ATTRIBUTE_DATA_TYPE.CSSM_ATTRIBUTE_DATA_UINT32 | 34,
        CSSM_ATTRIBUTE_DL_DB_HANDLE = CSSM_ATTRIBUTE_DATA_TYPE.CSSM_ATTRIBUTE_DATA_DL_DB_HANDLE | 35,
        CSSM_ATTRIBUTE_ACCESS_CREDENTIALS = CSSM_ATTRIBUTE_DATA_TYPE.CSSM_ATTRIBUTE_DATA_ACCESS_CREDENTIALS | 36,
        CSSM_ATTRIBUTE_PUBLIC_KEY_FORMAT = CSSM_ATTRIBUTE_DATA_TYPE.CSSM_ATTRIBUTE_DATA_UINT32 | 37,
        CSSM_ATTRIBUTE_PRIVATE_KEY_FORMAT = CSSM_ATTRIBUTE_DATA_TYPE.CSSM_ATTRIBUTE_DATA_UINT32 | 38,
        CSSM_ATTRIBUTE_SYMMETRIC_KEY_FORMAT = CSSM_ATTRIBUTE_DATA_TYPE.CSSM_ATTRIBUTE_DATA_UINT32 | 39,
        CSSM_ATTRIBUTE_WRAPPED_KEY_FORMAT = CSSM_ATTRIBUTE_DATA_TYPE.CSSM_ATTRIBUTE_DATA_UINT32 | 40
    } ;

    public enum CSSM_PADDING : uint
    {
        CSSM_PADDING_NONE = 0,
        CSSM_PADDING_CUSTOM = CSSM_PADDING_NONE + 1,
        CSSM_PADDING_ZERO = CSSM_PADDING_NONE + 2,
        CSSM_PADDING_ONE = CSSM_PADDING_NONE + 3,
        CSSM_PADDING_ALTERNATE = CSSM_PADDING_NONE + 4,
        CSSM_PADDING_FF = CSSM_PADDING_NONE + 5,
        CSSM_PADDING_PKCS5 = CSSM_PADDING_NONE + 6,
        CSSM_PADDING_PKCS7 = CSSM_PADDING_NONE + 7,
        CSSM_PADDING_CIPHERSTEALING = CSSM_PADDING_NONE + 8,
        CSSM_PADDING_RANDOM = CSSM_PADDING_NONE + 9,
        CSSM_PADDING_PKCS1 = CSSM_PADDING_NONE + 10,
        /* All padding types that are vendor specific, and not
           part of the CSSM specification should be defined
           relative to CSSM_PADDING_VENDOR_DEFINED. */
        CSSM_PADDING_VENDOR_DEFINED = CSSM_PADDING_NONE + 0x80000000
    } ;

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_CONTEXT_ATTRIBUTE
    {
        public CSSM_ATTRIBUTE_TYPE AttributeType;
        public UInt32 AttributeLength;
        public IntPtr Attribute;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_CONTEXT
    {
        public CSSM_CONTEXT_TYPE ContextType;
        public CSSM_ALGORITHMS AlgorithmType;
        public UInt32 NumberOfAttributes;
        public IntPtr ContextAttributes;
        public IntPtr CSPHandle;
        public int Privileged;
        public UInt32 /*CSSM_KR_POLICY_FLAGS*/ EncryptionProhibited;
        public UInt32 WorkFactor;
        public UInt32 Reserved; /* reserved for future use */
    }

    public enum CSSM_SC_FLAGS : uint
    {
        CSSM_CSP_TOK_RNG = 0x00000001,
        CSSM_CSP_TOK_CLOCK_EXISTS = 0x00000040
    } ;

    public enum CSSM_CSP_READER_FLAGS : uint
    {
        CSSM_CSP_RDR_TOKENPRESENT = 0x00000001,
        /* Token is present in reader/slot */
        CSSM_CSP_RDR_EXISTS = 0x00000002,
        /* Device is a reader with a
           removable token */
        CSSM_CSP_RDR_HW = 0x00000004
        /* Slot is a hardware slot */
    } ;

    public enum CSSM_CSP_FLAGS : uint
    {
        CSSM_CSP_TOK_WRITE_PROTECTED = 0x00000002,
        CSSM_CSP_TOK_LOGIN_REQUIRED = 0x00000004,
        CSSM_CSP_TOK_USER_PIN_INITIALIZED = 0x00000008,
        CSSM_CSP_TOK_PROT_AUTHENTICATION = 0x00000100,
        CSSM_CSP_TOK_USER_PIN_EXPIRED = 0x00100000,
        CSSM_CSP_TOK_SESSION_KEY_PASSWORD = 0x00200000,
        CSSM_CSP_TOK_PRIVATE_KEY_PASSWORD = 0x00400000,
        CSSM_CSP_STORES_PRIVATE_KEYS = 0x01000000,
        CSSM_CSP_STORES_PUBLIC_KEYS = 0x02000000,
        CSSM_CSP_STORES_SESSION_KEYS = 0x04000000,
        CSSM_CSP_STORES_CERTIFICATES = 0x08000000,
        CSSM_CSP_STORES_GENERIC = 0x10000000
    } ;

    public enum CSSM_PKCS_OAEP_MGF : uint
    {
        CSSM_PKCS_OAEP_MGF_NONE = 0,
        CSSM_PKCS_OAEP_MGF1_SHA1 = CSSM_PKCS_OAEP_MGF_NONE + 1,
        CSSM_PKCS_OAEP_MGF1_MD5 = CSSM_PKCS_OAEP_MGF_NONE + 2
    } ;

    public enum CSSM_PKCS_OAEP_PSOURCE : uint
    {
        CSSM_PKCS_OAEP_PSOURCE_NONE = 0,
        CSSM_PKCS_OAEP_PSOURCE_Pspecified = CSSM_PKCS_OAEP_PSOURCE_NONE + 1
    } ;

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_PKCS1_OAEP_PARAMS
    {
        public UInt32 HashAlgorithm;
        public CSSM_DATA HashParams;
        public CSSM_PKCS_OAEP_MGF MGF;
        public CSSM_DATA MGFParams;
        public CSSM_PKCS_OAEP_PSOURCE PSource;
        public CSSM_DATA PSourceParams;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_CSP_OPERATIONAL_STATISTICS
    {
        public int UserAuthenticated;
        /* CSSM_TRUE if the user is logged in to the token, CSSM_FALSE otherwise. */
        public CSSM_CSP_FLAGS DeviceFlags;
        public UInt32 TokenMaxSessionCount; /* Exported by Cryptoki modules. */
        public UInt32 TokenOpenedSessionCount;
        public UInt32 TokenMaxRWSessionCount;
        public UInt32 TokenOpenedRWSessionCount;
        public UInt32 TokenTotalPublicMem; /* Storage space statistics. */
        public UInt32 TokenFreePublicMem;
        public UInt32 TokenTotalPrivateMem;
        public UInt32 TokenFreePrivateMem;
    }

    //enum {
    //    CSSM_VALUE_NOT_AVAILABLE =		(uint32)(~0)
    //};

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_PKCS5_PBKDF1_PARAMS
    {
        public CSSM_DATA Passphrase;
        public CSSM_DATA InitVector;
    }

    public enum CSSM_PKCS5_PBKDF2_PRF : uint
    {
        CSSM_PKCS5_PBKDF2_PRF_HMAC_SHA1 = 0
    } ;

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_PKCS5_PBKDF2_PARAMS
    {
        public CSSM_DATA Passphrase;
        public CSSM_PKCS5_PBKDF2_PRF PseudoRandomFunction;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_KEA_DERIVE_PARAMS
    {
        public CSSM_DATA Rb;
        public CSSM_DATA Yb;
    }


    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_TP_AUTHORITY_ID
    {
        public IntPtr AuthorityCert;
        public IntPtr AuthorityLocation;
    }

    public enum CSSM_TP_AUTHORITY_REQUEST_TYPE : uint
    {
        CSSM_TP_AUTHORITY_REQUEST_CERTISSUE = 0x01,
        CSSM_TP_AUTHORITY_REQUEST_CERTREVOKE = 0x02,
        CSSM_TP_AUTHORITY_REQUEST_CERTSUSPEND = 0x03,
        CSSM_TP_AUTHORITY_REQUEST_CERTRESUME = 0x04,
        CSSM_TP_AUTHORITY_REQUEST_CERTVERIFY = 0x05,
        CSSM_TP_AUTHORITY_REQUEST_CERTNOTARIZE = 0x06,
        CSSM_TP_AUTHORITY_REQUEST_CERTUSERECOVER = 0x07,
        CSSM_TP_AUTHORITY_REQUEST_CRLISSUE = 0x100
    } ;

    public delegate int CSSM_TP_VERIFICATION_RESULTS_CALLBACK(IntPtr ModuleHandle, IntPtr CallerCtx, IntPtr VerifiedCert);

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_FIELD
    {
        public CSSM_DATA FieldOid;
        public CSSM_DATA FieldValue;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_TP_POLICYINFO
    {
        public UInt32 NumberOfPolicyIds;
        public IntPtr PolicyIds;
        public IntPtr PolicyControl;
    }

    public enum CSSM_TP_SERVICES : uint
    {
        /* bit masks for additional Authority services available through TP */
        CSSM_TP_KEY_ARCHIVE = 0x0001, /* archive cert & keys */
        CSSM_TP_CERT_PUBLISH = 0x0002, /* register cert in directory */
        CSSM_TP_CERT_NOTIFY_RENEW = 0x0004, /* notify at renewal time */
        CSSM_TP_CERT_DIR_UPDATE = 0x0008, /* update cert registry entry */
        CSSM_TP_CRL_DISTRIBUTE = 0x0010 /* push CRL to everyone */
    } ;

    public enum CSSM_TP_ACTION : uint
    {
        CSSM_TP_ACTION_DEFAULT = 0
    } ;

    public enum CSSM_TP_STOP_ON : uint
    {
        CSSM_TP_STOP_ON_POLICY = 0, /* use the pre-defined stopping criteria */
        CSSM_TP_STOP_ON_NONE = 1, /* evaluate all condition whether TRUE or FALSE */
        CSSM_TP_STOP_ON_FIRST_PASS = 2, /* stop evaluation at first TRUE */
        CSSM_TP_STOP_ON_FIRST_FAIL = 3 /* stop evaluation at first FALSE */
    } ;

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_DL_DB_LIST
    {
        public UInt32 NumHandles;
        public IntPtr DLDBHandle;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_TP_CALLERAUTH_CONTEXT
    {
        public CSSM_TP_POLICYINFO Policy;
        public IntPtr VerifyTime;
        public CSSM_TP_STOP_ON VerificationAbortOn;
        public CSSM_TP_VERIFICATION_RESULTS_CALLBACK CallbackWithVerifiedCert;
        public UInt32 NumberOfAnchorCerts;
        public IntPtr AnchorCerts;
        public IntPtr DBList;
        public IntPtr CallerCredentials;
    }

    public enum CSSM_CRL_PARSE_FORMAT : uint
    {
        CSSM_CRL_PARSE_FORMAT_NONE = 0x00,
        CSSM_CRL_PARSE_FORMAT_CUSTOM = 0x01,
        CSSM_CRL_PARSE_FORMAT_SEXPR = 0x02,
        CSSM_CRL_PARSE_FORMAT_COMPLEX = 0x03,
        CSSM_CRL_PARSE_FORMAT_OID_NAMED = 0x04,
        CSSM_CRL_PARSE_FORMAT_TUPLE = 0x05,
        CSSM_CRL_PARSE_FORMAT_MULTIPLE = 0x7FFE,
        CSSM_CRL_PARSE_FORMAT_LAST = 0x7FFF,
        /* Applications wishing to define their own custom parse
           format should create a uint32 value greater than the
           CSSM_CL_CUSTOM_CRL_PARSE_FORMAT */
        CSSM_CL_CUSTOM_CRL_PARSE_FORMAT = 0x8000
    } ;

    /* From CL. */

    public enum CSSM_CRL_TYPE : uint
    {
        CSSM_CRL_TYPE_UNKNOWN = 0x00,
        CSSM_CRL_TYPE_X_509v1 = 0x01,
        CSSM_CRL_TYPE_X_509v2 = 0x02,
        CSSM_CRL_TYPE_SPKI = 0x03,
        CSSM_CRL_TYPE_MULTIPLE = 0x7FFE
    } ;

    public enum CSSM_CRL_ENCODING : uint
    {
        CSSM_CRL_ENCODING_UNKNOWN = 0x00,
        CSSM_CRL_ENCODING_CUSTOM = 0x01,
        CSSM_CRL_ENCODING_BER = 0x02,
        CSSM_CRL_ENCODING_DER = 0x03,
        CSSM_CRL_ENCODING_BLOOM = 0x04,
        CSSM_CRL_ENCODING_SEXPR = 0x05,
        CSSM_CRL_ENCODING_MULTIPLE = 0x7FFE
    } ;

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_ENCODED_CRL
    {
        public CSSM_CRL_TYPE CrlType; /* type of CRL */
        public CSSM_CRL_ENCODING CrlEncoding; /* encoding for this packed CRL */
        public CSSM_DATA CrlBlob; /* packed CRL */
    }

    /* TP Again. */

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_PARSED_CRL
    {
        public CSSM_CRL_TYPE CrlType; /* CRL type */
        public CSSM_CRL_PARSE_FORMAT ParsedCrlFormat;
        /* struct of ParsedCrl */
        public IntPtr ParsedCrl; /* parsed CRL (to be typecast) */
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_CRL_PAIR
    {
        public CSSM_ENCODED_CRL EncodedCrl; /* an encoded CRL blob */
        public CSSM_PARSED_CRL ParsedCrl; /* equivalent parsed CRL */
    }

    public enum CSSM_CRLGROUP_TYPE : uint
    {
        CSSM_CRLGROUP_DATA = 0x00,
        CSSM_CRLGROUP_ENCODED_CRL = 0x01,
        CSSM_CRLGROUP_PARSED_CRL = 0x02,
        CSSM_CRLGROUP_CRL_PAIR = 0x03
    } ;

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_CRLGROUP
    {
        public CSSM_CRL_TYPE CrlType;
        public CSSM_CRL_ENCODING CrlEncoding;
        public UInt32 NumberOfCrls;
        public IntPtr GroupCrlList;
        public CSSM_CRLGROUP_TYPE CrlGroupType;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_FIELDGROUP
    {
        public int NumberOfFields; /* number of fields in the array */
        public IntPtr Fields; /* array of fields */
    }

    public enum CSSM_EVIDENCE_FORM : uint
    {
        CSSM_EVIDENCE_FORM_UNSPECIFIC = 0x0,
        CSSM_EVIDENCE_FORM_CERT = 0x1,
        CSSM_EVIDENCE_FORM_CRL = 0x2,
        CSSM_EVIDENCE_FORM_CERT_ID = 0x3,
        CSSM_EVIDENCE_FORM_CRL_ID = 0x4,
        CSSM_EVIDENCE_FORM_VERIFIER_TIME = 0x5,
        CSSM_EVIDENCE_FORM_CRL_THISTIME = 0x6,
        CSSM_EVIDENCE_FORM_CRL_NEXTTIME = 0x7,
        CSSM_EVIDENCE_FORM_POLICYINFO = 0x8,
        CSSM_EVIDENCE_FORM_TUPLEGROUP = 0x9
    } ;

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_EVIDENCE
    {
        public CSSM_EVIDENCE_FORM EvidenceForm;
        public IntPtr Evidence; /* Evidence content */
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_TP_VERIFY_CONTEXT
    {
        public CSSM_TP_ACTION Action;
        public CSSM_DATA ActionData;
        public CSSM_CRLGROUP Crls;
        public IntPtr Cred;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_TP_VERIFY_CONTEXT_RESULT
    {
        public UInt32 NumberOfEvidences;
        public IntPtr Evidence;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_TP_REQUEST_SET
    {
        public UInt32 NumberOfRequests;
        public IntPtr Requests;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_TP_RESULT_SET
    {
        public UInt32 NumberOfResults;
        public IntPtr Results;
    }

    public enum CSSM_TP_CONFIRM_STATUS : uint
    {
        CSSM_TP_CONFIRM_STATUS_UNKNOWN = 0x0,
        /* indeterminate */
        CSSM_TP_CONFIRM_ACCEPT = 0x1,
        /* accept results of executing a
           submit-retrieve function pair */
        CSSM_TP_CONFIRM_REJECT = 0x2
        /* reject results of executing a
           submit-retrieve function pair */
    } ;

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_TP_CONFIRM_RESPONSE
    {
        public UInt32 NumberOfResponses;
        public IntPtr Responses;
    }

    //enum {
    //    CSSM_ESTIMATED_TIME_UNKNOWN =		-1
    //};

    //enum {
    //    CSSM_ELAPSED_TIME_UNKNOWN =			-1,
    //    CSSM_ELAPSED_TIME_COMPLETE =		-2
    //};

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_TP_CERTISSUE_INPUT
    {
        public CSSM_SUBSERVICE_UID CSPSubserviceUid;
        public IntPtr CLHandle;
        public UInt32 NumberOfTemplateFields;
        public IntPtr SubjectCertFields;
        public CSSM_TP_SERVICES MoreServiceRequests;
        public UInt32 NumberOfServiceControls;
        public IntPtr ServiceControls;
        public IntPtr UserCredentials;
    }

    public enum CSSM_TP_CERTISSUE_STATUS : uint
    {
        CSSM_TP_CERTISSUE_STATUS_UNKNOWN = 0x0,
        /* indeterminate */
        CSSM_TP_CERTISSUE_OK = 0x1,
        /* cert issued as requested */
        CSSM_TP_CERTISSUE_OKWITHCERTMODS = 0x2,
        /* cert issued but cert contents were
           updated by the issuing authority */
        CSSM_TP_CERTISSUE_OKWITHSERVICEMODS = 0x3,
        /* cert issued but some requested backend
           services were not performed by the
           issuing authority */
        CSSM_TP_CERTISSUE_REJECTED = 0x4,
        /* cert was not issued due to some error
           condition */
        CSSM_TP_CERTISSUE_NOT_AUTHORIZED = 0x5,
        /* cert was not issued, the request was
           not authorized */
        CSSM_TP_CERTISSUE_WILL_BE_REVOKED = 0x6
        /* cert was issued, but TP has initiated
           a revocation of the certificate */
    } ;

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_TP_CERTISSUE_OUTPUT
    {
        public CSSM_TP_CERTISSUE_STATUS IssueStatus;
        public IntPtr CertGroup;
        public CSSM_TP_SERVICES PerformedServiceRequests;
    }

    public enum CSSM_TP_CERTCHANGE_ACTION : uint
    {
        CSSM_TP_CERTCHANGE_NONE = 0x0, /* no change */
        CSSM_TP_CERTCHANGE_REVOKE = 0x1, /* Revoke the certificate */
        /* This action type indicates a request to revoke a single
           certificate. Notice of the revocation operation remains
           in affect until the certificate itself expires. Revocation
           should be used to permanently remove a certificate from use. */
        CSSM_TP_CERTCHANGE_HOLD = 0x2, /* Hold/suspend the certificate */
        /* This action type indicates a request to suspend a
           single certificate. A suspension operation implies
           that the requester intends, at some time in the future,
           to request that the certificate be released from hold,
           making it available for use again. Placing a hold on
           a certificate does not obligate the requester to
           request a release. In practice, a certificate may
           remain on hold until the certificate itself expires.
           Revocation should be used to permanently remove a
           certificate from use. */
        CSSM_TP_CERTCHANGE_RELEASE = 0x3 /* Release the held certificate */
        /* This action type indicates a request to release a
           single certificate currently on hold. A release
           operation makes a certificate available for use again.
           Revocation should be used to permanently remove a
           certificate from use. */
    } ;

    public enum CSSM_TP_CERTCHANGE_REASON : uint
    {
        CSSM_TP_CERTCHANGE_REASON_UNKNOWN = 0x0,
        /* unspecified */
        CSSM_TP_CERTCHANGE_REASON_KEYCOMPROMISE = 0x1,
        /* Subject key believed to be compromised */
        CSSM_TP_CERTCHANGE_REASON_CACOMPROMISE = 0x2,
        /* CAís key believed to be compromised */
        CSSM_TP_CERTCHANGE_REASON_CEASEOPERATION = 0x3,
        /* certificate holder ceases operation under
           the jurisdiction of this certificate */
        CSSM_TP_CERTCHANGE_REASON_AFFILIATIONCHANGE = 0x4,
        /* certificate holder has moved from this
           jurisdiction */
        CSSM_TP_CERTCHANGE_REASON_SUPERCEDED = 0x5,
        /* certificate holder as issued a new, superceding
           certificate */
        CSSM_TP_CERTCHANGE_REASON_SUSPECTEDCOMPROMISE = 0x6,
        /* certificate could be compromised */
        CSSM_TP_CERTCHANGE_REASON_HOLDRELEASE = 0x7
        /* certificate holder resumes operation under the
           jurisdiction of this certificate */
    } ;

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_TP_CERTCHANGE_INPUT
    {
        public CSSM_TP_CERTCHANGE_ACTION Action;
        public CSSM_TP_CERTCHANGE_REASON Reason;
        public IntPtr CLHandle;
        public IntPtr Cert;
        public IntPtr ChangeInfo;
        public IntPtr StartTime;
        public IntPtr CallerCredentials;
    }

    public enum CSSM_TP_CERTCHANGE_STATUS : uint
    {
        CSSM_TP_CERTCHANGE_STATUS_UNKNOWN = 0x0,
        /* indeterminate */
        CSSM_TP_CERTCHANGE_OK = 0x1,
        /* cert state was successfully changed
           beginning at the specified time */
        CSSM_TP_CERTCHANGE_OKWITHNEWTIME = 0x2,
        /* cert state was successfully changed,
           at a modified effective time */
        CSSM_TP_CERTCHANGE_WRONGCA = 0x3,
        /* cert state was not changed, the
           selected CA is not authorized to
           change the cert state */
        CSSM_TP_CERTCHANGE_REJECTED = 0x4,
        /* cert state was not changed due to some
           error condition */
        CSSM_TP_CERTCHANGE_NOT_AUTHORIZED = 0x5
        /* cert state was not changed, the
           requester is not authorized to change
           the cert state */
    } ;

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_TP_CERTCHANGE_OUTPUT
    {
        public CSSM_TP_CERTCHANGE_STATUS ActionStatus;
        public CSSM_FIELD RevokeInfo;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_TP_CERTVERIFY_INPUT
    {
        public IntPtr CLHandle;
        public IntPtr Cert;
        public IntPtr VerifyContext;
    }

    public enum CSSM_TP_CERTVERIFY_STATUS : uint
    {
        CSSM_TP_CERTVERIFY_UNKNOWN = 0x0,
        CSSM_TP_CERTVERIFY_VALID = 0x1,
        CSSM_TP_CERTVERIFY_INVALID = 0x2,
        CSSM_TP_CERTVERIFY_REVOKED = 0x3,
        CSSM_TP_CERTVERIFY_SUSPENDED = 0x4,
        CSSM_TP_CERTVERIFY_EXPIRED = 0x5,
        CSSM_TP_CERTVERIFY_NOT_VALID_YET = 0x6,
        CSSM_TP_CERTVERIFY_INVALID_AUTHORITY = 0x7,
        CSSM_TP_CERTVERIFY_INVALID_SIGNATURE = 0x8,
        CSSM_TP_CERTVERIFY_INVALID_CERT_VALUE = 0x9,
        CSSM_TP_CERTVERIFY_INVALID_CERTGROUP = 0xA,
        CSSM_TP_CERTVERIFY_INVALID_POLICY = 0xB,
        CSSM_TP_CERTVERIFY_INVALID_POLICY_IDS = 0xC,
        CSSM_TP_CERTVERIFY_INVALID_BASIC_CONSTRAINTS = 0xD,
        CSSM_TP_CERTVERIFY_INVALID_CRL_DIST_PT = 0xE,
        CSSM_TP_CERTVERIFY_INVALID_NAME_TREE = 0xF,
        CSSM_TP_CERTVERIFY_UNKNOWN_CRITICAL_EXT = 0x10
    } ;

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_TP_CERTVERIFY_OUTPUT
    {
        public CSSM_TP_CERTVERIFY_STATUS VerifyStatus;
        public UInt32 NumberOfEvidence;
        public IntPtr Evidence;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_TP_CERTNOTARIZE_INPUT
    {
        public IntPtr CLHandle;
        public UInt32 NumberOfFields;
        public IntPtr MoreFields;
        public IntPtr SignScope;
        public UInt32 ScopeSize;
        public CSSM_TP_SERVICES MoreServiceRequests;
        public UInt32 NumberOfServiceControls;
        public IntPtr ServiceControls;
        public IntPtr UserCredentials;
    }

    public enum CSSM_TP_CERTNOTARIZE_STATUS : uint
    {
        CSSM_TP_CERTNOTARIZE_STATUS_UNKNOWN = 0x0,
        /* indeterminate */
        CSSM_TP_CERTNOTARIZE_OK = 0x1,
        /* cert fields were added and the result was
           notarized as requested */
        CSSM_TP_CERTNOTARIZE_OKWITHOUTFIELDS = 0x2,
        /* non-conflicting cert fields were added,
           conflicting cert fields were ignored,
           and the result was notarized as requested */
        CSSM_TP_CERTNOTARIZE_OKWITHSERVICEMODS = 0x3,
        /* cert fields were added and the result was
           notarized as requested, but some requested
           backend services were not performed by the
           notary */
        CSSM_TP_CERTNOTARIZE_REJECTED = 0x4,
        /* cert was not notarized due to some error
           condition */
        CSSM_TP_CERTNOTARIZE_NOT_AUTHORIZED = 0x5
        /* cert was not notarized, the request was
           not authorized */
    } ;

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_TP_CERTNOTARIZE_OUTPUT
    {
        public CSSM_TP_CERTNOTARIZE_STATUS NotarizeStatus;
        public IntPtr NotarizedCertGroup;
        public CSSM_TP_SERVICES PerformedServiceRequests;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_TP_CERTRECLAIM_INPUT
    {
        public IntPtr CLHandle;
        public UInt32 NumberOfSelectionFields;
        public IntPtr SelectionFields;
        public IntPtr UserCredentials;
    }

    public enum CSSM_TP_CERTRECLAIM_STATUS : uint
    {
        CSSM_TP_CERTRECLAIM_STATUS_UNKNOWN = 0x0,
        /* indeterminate */
        CSSM_TP_CERTRECLAIM_OK = 0x1,
        /* a set of one or more certificates were
           returned by the CA for local recovery
           of the associated private key */
        CSSM_TP_CERTRECLAIM_NOMATCH = 0x2,
        /* no certificates owned by the requester
           were found matching the specified
           selection fields */
        CSSM_TP_CERTRECLAIM_REJECTED = 0x3,
        /* certificate reclamation failed due
           to some error condition */
        CSSM_TP_CERTRECLAIM_NOT_AUTHORIZED = 0x4
        /* certificate reclamation was not
           performed, the request was not
           authorized */
    } ;

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_TP_CERTRECLAIM_OUTPUT
    {
        public CSSM_TP_CERTRECLAIM_STATUS ReclaimStatus;
        public IntPtr ReclaimedCertGroup;
        public long KeyCacheHandle;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_TP_CRLISSUE_INPUT
    {
        public IntPtr CLHandle;
        public UInt32 CrlIdentifier;
        public IntPtr CrlThisTime;
        public IntPtr PolicyIdentifier;
        public IntPtr CallerCredentials;
    }

    public enum CSSM_TP_CRLISSUE_STATUS : uint
    {
        CSSM_TP_CRLISSUE_STATUS_UNKNOWN = 0x0,
        /* indeterminate */
        CSSM_TP_CRLISSUE_OK = 0x1,
        /* a copy of the most current CRL was
           issued as requested and the time for
           issuing the next CRL is also returned */
        CSSM_TP_CRLISSUE_NOT_CURRENT = 0x2,
        /* either no CRL has been issued since
           the CRL identified in the request, or
           it is not time to issue an updated CRL.
           no CRL has been returned, but the time
           for issuing the next CRL is included
           in the results */
        CSSM_TP_CRLISSUE_INVALID_DOMAIN = 0x3,
        /* CRL domain was not recognized or was
           outside the CA jurisdiction, no CRL or
           time for the next CRL has been
           returned. */
        CSSM_TP_CRLISSUE_UNKNOWN_IDENTIFIER = 0x4,
        /* unrecognized CRL identifier, no CRL or
           time for the next CRL has been
           returned. */
        CSSM_TP_CRLISSUE_REJECTED = 0x5,
        /* CRL was not issued due to some error
           condition, no CRL or time for the next
           CRL has been returned. */
        CSSM_TP_CRLISSUE_NOT_AUTHORIZED = 0x6
        /* CRL was not issued, the request was
           not authorized, no CRL or time for the
           next CRL has been returned. */
    } ;

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_TP_CRLISSUE_OUTPUT
    {
        public CSSM_TP_CRLISSUE_STATUS IssueStatus;
        public IntPtr Crl;
        public IntPtr CrlNextTime;
    }

    public enum CSSM_TP_FORM_TYPE : uint
    {
        CSSM_TP_FORM_TYPE_GENERIC = 0x0,
        CSSM_TP_FORM_TYPE_REGISTRATION = 0x1
    } ;

    public enum CSSM_CL_TEMPLATE_TYPE : uint
    {
        CSSM_CL_TEMPLATE_INTERMEDIATE_CERT = 1,
        /* for X509 certificates, a fully-formed
           encoded certificate with empty signature field */
        CSSM_CL_TEMPLATE_PKIX_CERTTEMPLATE = 2
        /* as defined in RFC2511, section 5 CertTemplate */
    } ;

    public enum CSSM_CERT_BUNDLE_TYPE : uint
    {
        CSSM_CERT_BUNDLE_UNKNOWN = 0x00,
        CSSM_CERT_BUNDLE_CUSTOM = 0x01,
        CSSM_CERT_BUNDLE_PKCS7_SIGNED_DATA = 0x02,
        CSSM_CERT_BUNDLE_PKCS7_SIGNED_ENVELOPED_DATA = 0x03,
        CSSM_CERT_BUNDLE_PKCS12 = 0x04,
        CSSM_CERT_BUNDLE_PFX = 0x05,
        CSSM_CERT_BUNDLE_SPKI_SEQUENCE = 0x06,
        CSSM_CERT_BUNDLE_PGP_KEYRING = 0x07,
        CSSM_CERT_BUNDLE_LAST = 0x7FFF,
        /* Applications wishing to define their own custom certificate
           bundle type should define and publicly document a uint32
           value greater than CSSM_CL_CUSTOM_CERT_BUNDLE_TYPE */
        CSSM_CL_CUSTOM_CERT_BUNDLE_TYPE = 0x8000
    } ;

    public enum CSSM_CERT_BUNDLE_ENCODING : uint
    {
        CSSM_CERT_BUNDLE_ENCODING_UNKNOWN = 0x00,
        CSSM_CERT_BUNDLE_ENCODING_CUSTOM = 0x01,
        CSSM_CERT_BUNDLE_ENCODING_BER = 0x02,
        CSSM_CERT_BUNDLE_ENCODING_DER = 0x03,
        CSSM_CERT_BUNDLE_ENCODING_SEXPR = 0x04,
        CSSM_CERT_BUNDLE_ENCODING_PGP = 0x05
    } ;

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_CERT_BUNDLE_HEADER
    {
        public CSSM_CERT_BUNDLE_TYPE BundleType;
        public CSSM_CERT_BUNDLE_ENCODING BundleEncoding;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_CERT_BUNDLE
    {
        public CSSM_CERT_BUNDLE_HEADER BundleHeader;
        public CSSM_DATA Bundle;
    }

    //enum {
    //    CSSM_FIELDVALUE_COMPLEX_DATA_TYPE =			0xFFFFFFFF
    //};

    public enum CSSM_DB_ATTRIBUTE_NAME_FORMAT : uint
    {
        CSSM_DB_ATTRIBUTE_NAME_AS_STRING = 0,
        CSSM_DB_ATTRIBUTE_NAME_AS_OID = 1,
        CSSM_DB_ATTRIBUTE_NAME_AS_INTEGER = 2
    } ;

    public enum CSSM_DB_ATTRIBUTE_FORMAT : uint
    {
        CSSM_DB_ATTRIBUTE_FORMAT_STRING = 0,
        CSSM_DB_ATTRIBUTE_FORMAT_SINT32 = 1,
        CSSM_DB_ATTRIBUTE_FORMAT_UINT32 = 2,
        CSSM_DB_ATTRIBUTE_FORMAT_BIG_NUM = 3,
        CSSM_DB_ATTRIBUTE_FORMAT_REAL = 4,
        CSSM_DB_ATTRIBUTE_FORMAT_TIME_DATE = 5,
        CSSM_DB_ATTRIBUTE_FORMAT_BLOB = 6,
        CSSM_DB_ATTRIBUTE_FORMAT_MULTI_UINT32 = 7,
        CSSM_DB_ATTRIBUTE_FORMAT_COMPLEX = 8
    } ;

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_DB_ATTRIBUTE_INFO
    {
        public CSSM_DB_ATTRIBUTE_NAME_FORMAT AttributeNameFormat;
        public IntPtr Label;
        public CSSM_DB_ATTRIBUTE_FORMAT AttributeFormat;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_DB_ATTRIBUTE_DATA
    {
        public CSSM_DB_ATTRIBUTE_INFO Info;
        public UInt32 NumberOfValues;
        public IntPtr Value;
    }

    public enum CSSM_DB_RECORDTYPE : uint
    {
        /* Schema Management Name Space Range Definition*/
        CSSM_DB_RECORDTYPE_SCHEMA_START = 0x00000000,
        CSSM_DB_RECORDTYPE_SCHEMA_END = CSSM_DB_RECORDTYPE_SCHEMA_START + 4,
        /* Open Group Application Name Space Range Definition*/
        CSSM_DB_RECORDTYPE_OPEN_GROUP_START = 0x0000000A,
        CSSM_DB_RECORDTYPE_OPEN_GROUP_END = CSSM_DB_RECORDTYPE_OPEN_GROUP_START + 8,
        /* Industry At Large Application Name Space Range Definition */
        CSSM_DB_RECORDTYPE_APP_DEFINED_START = 0x80000000,
        CSSM_DB_RECORDTYPE_APP_DEFINED_END = 0xffffffff,
        /* Record Types defined in the Schema Management Name Space */
        CSSM_DL_DB_SCHEMA_INFO = CSSM_DB_RECORDTYPE_SCHEMA_START + 0,
        CSSM_DL_DB_SCHEMA_INDEXES = CSSM_DB_RECORDTYPE_SCHEMA_START + 1,
        CSSM_DL_DB_SCHEMA_ATTRIBUTES = CSSM_DB_RECORDTYPE_SCHEMA_START + 2,
        CSSM_DL_DB_SCHEMA_PARSING_MODULE = CSSM_DB_RECORDTYPE_SCHEMA_START + 3,
        /* Record Types defined in the Open Group Application Name Space */
        CSSM_DL_DB_RECORD_ANY = CSSM_DB_RECORDTYPE_OPEN_GROUP_START + 0,
        CSSM_DL_DB_RECORD_CERT = CSSM_DB_RECORDTYPE_OPEN_GROUP_START + 1,
        CSSM_DL_DB_RECORD_CRL = CSSM_DB_RECORDTYPE_OPEN_GROUP_START + 2,
        CSSM_DL_DB_RECORD_POLICY = CSSM_DB_RECORDTYPE_OPEN_GROUP_START + 3,
        CSSM_DL_DB_RECORD_GENERIC = CSSM_DB_RECORDTYPE_OPEN_GROUP_START + 4,
        CSSM_DL_DB_RECORD_PUBLIC_KEY = CSSM_DB_RECORDTYPE_OPEN_GROUP_START + 5,
        CSSM_DL_DB_RECORD_PRIVATE_KEY = CSSM_DB_RECORDTYPE_OPEN_GROUP_START + 6,
        CSSM_DL_DB_RECORD_SYMMETRIC_KEY = CSSM_DB_RECORDTYPE_OPEN_GROUP_START + 7,
        CSSM_DL_DB_RECORD_ALL_KEYS = CSSM_DB_RECORDTYPE_OPEN_GROUP_START + 8
    } ;

    public enum CSSM_DB_CERT_USE : uint
    {
        CSSM_DB_CERT_USE_TRUSTED = 0x00000001, /* application-defined as trusted */
        CSSM_DB_CERT_USE_SYSTEM = 0x00000002, /* the CSSM system cert */
        CSSM_DB_CERT_USE_OWNER = 0x00000004, /* private key owned by system user*/
        CSSM_DB_CERT_USE_REVOKED = 0x00000008, /* revoked cert -15913 used w CRL APIs */
        CSSM_DB_CERT_USE_SIGNING = 0x00000010, /* use cert for signing only */
        CSSM_DB_CERT_USE_PRIVACY = 0x00000020 /* use cert for confidentiality only */
    } ;

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_DB_RECORD_ATTRIBUTE_INFO
    {
        public CSSM_DB_RECORDTYPE DataRecordType;
        public UInt32 NumberOfAttributes;
        public IntPtr AttributeInfo;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_DB_RECORD_ATTRIBUTE_DATA
    {
        public CSSM_DB_RECORDTYPE DataRecordType;
        public UInt32 SemanticInformation;
        public UInt32 NumberOfAttributes;
        public IntPtr AttributeData;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_DB_PARSING_MODULE_INFO
    {
        public CSSM_DB_RECORDTYPE RecordType;
        public CSSM_SUBSERVICE_UID ModuleSubserviceUid;
    }

    public enum CSSM_DB_INDEX_TYPE : uint
    {
        CSSM_DB_INDEX_UNIQUE = 0,
        CSSM_DB_INDEX_NONUNIQUE = 1
    } ;

    public enum CSSM_DB_INDEXED_DATA_LOCATION : uint
    {
        CSSM_DB_INDEX_ON_UNKNOWN = 0,
        CSSM_DB_INDEX_ON_ATTRIBUTE = 1,
        CSSM_DB_INDEX_ON_RECORD = 2
    } ;

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_DB_INDEX_INFO
    {
        public CSSM_DB_INDEX_TYPE IndexType;
        public CSSM_DB_INDEXED_DATA_LOCATION IndexedDataLocation;
        public CSSM_DB_ATTRIBUTE_INFO Info;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_DB_UNIQUE_RECORD
    {
        public CSSM_DB_INDEX_INFO RecordLocator;
        public CSSM_DATA RecordIdentifier;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_DB_RECORD_INDEX_INFO
    {
        public CSSM_DB_RECORDTYPE DataRecordType;
        public UInt32 NumberOfIndexes;
        public IntPtr IndexInfo;
    }

    public enum CSSM_DB_ACCESS_TYPE : uint
    {
        CSSM_DB_ACCESS_READ = 0x00001,
        CSSM_DB_ACCESS_WRITE = 0x00002,
        CSSM_DB_ACCESS_PRIVILEGED = 0x00004 /* versus user mode */
    } ;

    public enum CSSM_DB_MODIFY_MODE : uint
    {
        CSSM_DB_MODIFY_ATTRIBUTE_NONE = 0,
        CSSM_DB_MODIFY_ATTRIBUTE_ADD = CSSM_DB_MODIFY_ATTRIBUTE_NONE + 1,
        CSSM_DB_MODIFY_ATTRIBUTE_DELETE = CSSM_DB_MODIFY_ATTRIBUTE_NONE + 2,
        CSSM_DB_MODIFY_ATTRIBUTE_REPLACE = CSSM_DB_MODIFY_ATTRIBUTE_NONE + 3
    } ;

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_DBINFO
    {
        /* meta information about each record type stored in this
        data store including meta information about record
        attributes and indexes */
        public UInt32 NumberOfRecordTypes;
        public IntPtr DefaultParsingModules;
        public IntPtr RecordAttributeNames;
        public IntPtr RecordIndexes;
        /* access restrictions for opening this data store */
        public int IsLocal;
        public IntPtr AccessPath; /* URL, dir path, etc. */
        public IntPtr Reserved;
    }

    public enum CSSM_DB_OPERATOR : uint
    {
        CSSM_DB_EQUAL = 0,
        CSSM_DB_NOT_EQUAL = 1,
        CSSM_DB_LESS_THAN = 2,
        CSSM_DB_GREATER_THAN = 3,
        CSSM_DB_CONTAINS = 4,
        CSSM_DB_CONTAINS_INITIAL_SUBSTRING = 5,
        CSSM_DB_CONTAINS_FINAL_SUBSTRING = 6
    } ;

    public enum CSSM_DB_CONJUNCTIVE : uint
    {
        CSSM_DB_NONE = 0,
        CSSM_DB_AND = 1,
        CSSM_DB_OR = 2
    } ;

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_SELECTION_PREDICATE
    {
        public CSSM_DB_OPERATOR DbOperator;
        public CSSM_DB_ATTRIBUTE_DATA Attribute;
    }

    //enum {
    //    CSSM_QUERY_TIMELIMIT_NONE =			0
    //};

    //enum {
    //    CSSM_QUERY_SIZELIMIT_NONE =			0
    //};

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_QUERY_LIMITS
    {
        public UInt32 TimeLimit; /* in seconds */
        public UInt32 SizeLimit; /* max. number of records to return */
    }

    public enum CSSM_QUERY_FLAGS : uint
    {
        CSSM_QUERY_RETURN_DATA = 0x01
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_QUERY
    {
        public CSSM_DB_RECORDTYPE RecordType;
        public CSSM_DB_CONJUNCTIVE Conjunctive;
        public UInt32 NumSelectionPredicates;
        public IntPtr SelectionPredicate;
        public CSSM_QUERY_LIMITS QueryLimits;
        public CSSM_QUERY_FLAGS QueryFlags;
    }

    public enum CSSM_DLTYPE : uint
    {
        CSSM_DL_UNKNOWN = 0,
        CSSM_DL_CUSTOM = 1,
        CSSM_DL_LDAP = 2,
        CSSM_DL_ODBC = 3,
        CSSM_DL_PKCS11 = 4,
        CSSM_DL_FFS = 5, /* flat file system */
        CSSM_DL_MEMORY = 6,
        CSSM_DL_REMOTEDIR = 7
    } ;

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_DL_PKCS11_ATTRIBUTE
    {
        public UInt32 DeviceAccessFlags;
    }

    //enum {
    //    CSSM_DB_DATASTORES_UNKNOWN =		0xFFFFFFFF
    //};

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_NAME_LIST
    {
        public UInt32 NumStrings;
        public IntPtr String;
    }

    public enum CSSM_DB_RETRIEVAL_MODES : uint
    {
        CSSM_DB_TRANSACTIONAL_MODE = 0,
        CSSM_DB_FILESYSTEMSCAN_MODE = 1
    } ;

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_DB_SCHEMA_ATTRIBUTE_INFO
    {
        public UInt32 AttributeId;
        public IntPtr AttributeName;
        public CSSM_DATA AttributeNameID;
        public CSSM_DB_ATTRIBUTE_FORMAT DataType;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CSSM_DB_SCHEMA_INDEX_INFO
    {
        public UInt32 AttributeId;
        public UInt32 IndexId;
        public CSSM_DB_INDEX_TYPE IndexType;
        public CSSM_DB_INDEXED_DATA_LOCATION IndexedDataLocation;
    }
}