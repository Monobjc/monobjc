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
 * @file    support-os.mm
 * @brief   Contains OS detection functions.
 * @author  Laurent Etiemble <laurent.etiemble@monobjc.net>
 * @date    2009-2014
 */
#include "logging.h"
#include "support-os.h"

/**
 * @brief   Store the current OS version.
 */
static SInt32 os_version = 0;

/**
 * @brief   Stores the current architecture descriptor.
 */
static const NXArchInfo *arch_info = NULL;

#pragma mark ----- Implementation -----

SInt32 monobjc_get_os_version() {
    if (!os_version) {
        NSOperatingSystemVersion version = [[NSProcessInfo processInfo] operatingSystemVersion];
        os_version = version.majorVersion * 256 + version.minorVersion;
    }
    return os_version;
}

const NXArchInfo *monobjc_get_arch_info() {
    if (!arch_info) {
        arch_info = NXGetLocalArchInfo();
    }
    if (!arch_info) {
        LOG_ERROR(MONOBJC_DOMAIN_GENERAL, "Cannot retrieve the processor.");
    }
    return arch_info;
}

int monobjc_are_associated_objects_available() {
    SInt32 version = monobjc_get_os_version();
    return (version >= MACOS_10_6);
}

int monobjc_are_blocks_available() {
    SInt32 version = monobjc_get_os_version();
    return (version >= MACOS_10_6);
}
