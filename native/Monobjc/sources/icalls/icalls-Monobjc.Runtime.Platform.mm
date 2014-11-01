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
 * @file    icalls-Monobjc.Runtime.Platform.mm
 * @brief   Contains the internal calls for the Monobjc.Runtime.Platform type.
 * @author  Laurent Etiemble <laurent.etiemble@monobjc.net>
 * @date    2009-2014
 */
#include "constants.h"
#include "icalls.h"
#include "logging.h"
#include "support-os.h"

#pragma mark ----- Internal Calls -----

/**
 * @brief   Return the descriptor of the processor of the system.
 * @return  A system dependent description.
 */
MonoString *icall_Monobjc_Runtime_Platform_GetProcessor(void) {
    const NXArchInfo *info = monobjc_get_arch_info();
    return mono_string_new(mono_domain_get(), info->description);
}

/**
 * @brief   Return the current version of Mac OS X.
 * @return  A normalized value for the version. For example:
 *          @li 1040 for Mac OS X 10.4, whatever the patch level is.
 *          @li 1050 for Mac OS X 10.5, whatever the patch level is.
 */
OSVersion icall_Monobjc_Runtime_Platform_GetOSVersion(void) {
    SInt32 version = monobjc_get_os_version();
    return (OSVersion) version;
}

/**
 * @brief   Return whether the platform is 32 or 64 bits.
 * @return  TRUE if the platform is 64 bits, FALSE otherwise.
 */
boolean_t icall_Monobjc_Runtime_Platform_Is64Bits(void) {
    return IS64BITS;
}

/**
 * @brief   Return whether the platform uses the big and little endianness.
 * @return  TRUE if the platform uses big-endianness, FALSE otherwise.
 */
boolean_t icall_Monobjc_Runtime_Platform_IsBigEndian(void) {
#if TARGET_RT_BIG_ENDIAN
    return true;
#elif TARGET_RT_LITTLE_ENDIAN
    return false;
#else
    #error Unsupported Endianness
#endif
}
