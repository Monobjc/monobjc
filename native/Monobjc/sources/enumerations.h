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

/**
 * @file    enumerations.h
 * @brief   Contains common enumerations.
 * @author  Laurent Etiemble <laurent.etiemble@monobjc.net>
 * @date    2009-2014
 */
#ifndef __ENUMERATIONS_H__
#define __ENUMERATIONS_H__

/** @brief  Enumeration of the logging levels. */
typedef enum MonobjcLogLevel {
    /** @brief  Error log level. */
    MONOBJC_LOG_ERROR   = 0x00,
    /** @brief  Warn log level. */
    MONOBJC_LOG_WARN    = 0x01,
    /** @brief  Info log level. */
    MONOBJC_LOG_INFO    = 0x02,
    /** @brief  Debug log level. */
    MONOBJC_LOG_DEBUG   = 0x04,
} MonobjcLogLevel;

/** @brief  Enumeration of the logging domains. */
typedef enum MonobjcLogDomain {
#undef LOG_DOMAIN
    /** @brief  Print the logging domains. */
#define LOG_DOMAIN(SYMBOL, VALUE, KEY, STRING)    SYMBOL = VALUE,
#include "logging.def"
    
    /** @brief  All the domain are logged. */
    MONOBJC_DOMAIN_ALL  = 0xFFFF,
} MonobjcLogDomain;

/** @brief  Enumeration that holds values for Mac OS system version. */
typedef enum OSVersion {
    /** @brief  Default value. */
    MACOS_Unrecognized = 0x0000,
    /**
     * @brief   Value for MacOS 10.0 (Cheetah).
     * @remark  Here for compatibility reasons.
     */
    MACOS_10_0 = 0x1000,
    /**
     * @brief   Value for MacOS 10.1 (Puma).
     * @remark  Here for compatibility reasons.
     */
    MACOS_10_1 = 0x1010,
    /**
     * @brief   Value for MacOS 10.2 (Jaguar).
     * @remark  Here for compatibility reasons.
     */
    MACOS_10_2 = 0x1020,
    /**
     * @brief   Value for MacOS 10.3 (Panther).
     * @remark  Here for compatibility reasons.
     */
    MACOS_10_3 = 0x1030,
    /**
     * @brief   Value for MacOS 10.4 (Tiger).
     * @remark  This is no longer a supported platform.
     */
    MACOS_10_4 = 0x1040,
    /**
     * @brief   Value for MacOS 10.5 (Leopard).
     * @remark  This is a supported platform.
     */
    MACOS_10_5 = 0x1050,
    /**
     * @brief   Value for MacOS 10.6 (Snow Leopard).
     * @remark  This is a supported platform.
     */
    MACOS_10_6 = 0x1060,
    /**
     * @brief   Value for MacOS 10.7 (Lion).
     * @remark  This is a supported platform.
     */
    MACOS_10_7 = 0x1070,
    /**
     * @brief   Value for MacOS 10.8 (Mountain Lion).
     * @remark  This is a supported platform.
     */
    MACOS_10_8 = 0x1080,
} OSVersion;

/**
 * @brief   Specify the behavior when retrieving an instance from the cache.
 */
typedef enum RetrievalMode {
    /**
     * @brief   The retrieved instance must be assignable the expected type.
     */
    RetrievalModeStrict,
    /**
     * @brief   The retrieved instance should be assignable the expected type. If not, NULL is returned.
     */
    RetrievalModeFailSafe,
    /**
     * @brief   The retrieved instance should be assignable the expected type. If not, a new wrapper is generated.
     */
    RetrievalModeOverride,
} RetrievalMode;

#endif // __ENUMERATIONS_H__
