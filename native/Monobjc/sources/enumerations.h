// 
// This file is part of Monobjc, a .NET/Objective-C bridge
// Copyright (C) 2007-2011 - Laurent Etiemble
// 
// Monobjc is free software: you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published
// by the Free Software Foundation, either version 3 of the License, or
// any later version.
// 
// Monobjc is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public License
// along with Monobjc. If not, see <http://www.gnu.org/licenses/>.
// 
/**
 * @file    enumerations.h
 * @brief   Contains common enumerations.
 * @author  Laurent Etiemble <laurent.etiemble@monobjc.net>
 * @date    2009-2010
 */
#ifndef __ENUMERATIONS_H__
#define __ENUMERATIONS_H__

/*! @brief  Enumeration of the logging levels. */
typedef enum MonobjcLogLevel {
    /*! @brief  Error log level. */
    MONOBJC_LOG_ERROR   = 0x00,
    /*! @brief  Warn log level. */
    MONOBJC_LOG_WARN    = 0x01,
    /*! @brief  Info log level. */
    MONOBJC_LOG_INFO    = 0x02,
    /*! @brief  Debug log level. */
    MONOBJC_LOG_DEBUG   = 0x04,
};

/*! @brief  Enumeration of the logging domains. */
typedef enum MonobjcLogDomain {
#undef LOG_DOMAIN
    /** @brief  Print the logging domains. */
#define LOG_DOMAIN(SYMBOL, VALUE, KEY, STRING)    SYMBOL = VALUE,
#include "logging.def"
    
    /*! @brief  All the domain are logged. */
    MONOBJC_DOMAIN_ALL  = 0xFFFF,
};

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
     * @remark  This is a supported platform.
     */
    MACOS_10_4 = 0x1040,
    /**
     * @brief   Value for MacOS 10.5 (Leopard).
     * @remark  This is a supported platform.
     */
    MACOS_10_5 = 0x1050,
    /**
     * @brief   Value for MacOS 10.5 (Snow Leopard).
     * @remark  This is a supported platform.
     */
    MACOS_10_6 = 0x1060,
};

#endif // __ENUMERATIONS_H__
