// 
// This file is part of Monobjc, a .NET/Objective-C bridge
// Copyright (C) 2007-2012 - Laurent Etiemble
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
 * @file    support-os.mm
 * @brief   Contains OS detection functions.
 * @author  Laurent Etiemble <laurent.etiemble@monobjc.net>
 * @date    2009-2012
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
        if (Gestalt(gestaltSystemVersion, &os_version) < 0) {
            LOG_ERROR(MONOBJC_DOMAIN_GENERAL, "Cannot retrieve the system version.");
        }
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
    return (version >= 0x1060);
}

int monobjc_are_blocks_available() {
    SInt32 version = monobjc_get_os_version();
    return (version >= 0x1060);
}
