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
 * @file    constants.h
 * @brief   Contains common constants.
 * @author  Laurent Etiemble <laurent.etiemble@monobjc.net>
 * @date    2009-2011
 */
#ifndef __CONSTANTS_H__
#define __CONSTANTS_H__

#if TARGET_RT_64_BIT
#define IS64BITS    true
#else
#define IS64BITS    false
#endif

#pragma mark ----- Shortcuts -----

/** @brief  Key used to store wrapped exception in NSException instance. */
#define EXCEPTION_WRAP_KEY                  @"Managed Exception"

/** @brief  Macro for Monobjc assembly and namespace. */
#define MONOBJC                             "Monobjc"

/** @brief  Macro for Monobjc.Utils namespace. */
#define MONOBJC_UTILS                       "Monobjc.Utils"

/** @brief  Macro for ObjectiveCException type. */
#define OBJECTIVE_C_EXCEPTION               "ObjectiveCException"

/** @brief  Macro for ObjectiveCMessagingException type. */
#define OBJECTIVE_C_MESSAGING_EXCEPTION     "ObjectiveCMessagingException"

#pragma mark ----- Predefined messages -----

/*! @brief  Resource string. */
#define ASSERTION_FAILED                    "Assertion `%s' failed"

/*! @brief  Resource string. */
#define STRING_CANNOT_LOAD_FRAMEWORK        "Cannot load framework '%s'"

/** @brief  Resource string. */
#define STRING_CANNOT_COMPUTE_ENCODING      "Cannot compute encoding for type %s"

/** @brief  Resource string. */
#define STRING_CANNOT_COMPUTE_SIZE          "Cannot compute size for type %s"

/** @brief  Resource string. */
#define STRING_CANNOT_COMPUTE_ALIGNMENT     "Cannot compute alignment for type %s"

/** @brief  Resource string. */
#define STRING_CANNOT_CREATE_DESCRIPTOR     "Cannot create a descriptor for %s"

/** @brief  Resource string. */
#define STRING_CANNOT_PREPARE_CALL          "Cannot prepare the call for %s"

#endif // __CONSTANTS_H__
