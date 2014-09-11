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
 * @file    constants.h
 * @brief   Contains common constants.
 * @author  Laurent Etiemble <laurent.etiemble@monobjc.net>
 * @date    2009-2014
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

/** @brief  Resource string. */
#define ASSERTION_FAILED                    "Assertion `%s' failed"

/** @brief  Resource string. */
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
