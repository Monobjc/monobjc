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
 * @file    support-os.h
 * @brief   Contains OS detection functions.
 * @author  Laurent Etiemble <laurent.etiemble@monobjc.net>
 * @date    2009-2011
 */
#ifndef __SUPPORT_OS_H__
#define __SUPPORT_OS_H__

#include <mach-o/arch.h>

#pragma mark ----- Functions -----

/**
 * @brief   Return the current version of Mac OS X.
 * @return  A normalized value for the version. For example:
 *          @li 1047 for Mac OS X 10.4.7.
 *          @li 1058 for Mac OS X 10.5.8.
 */
SInt32 monobjc_get_os_version();

/**
 * @brief   Return the current architecture descriptor.
 * @return  A structure descrbing the architecture.
 */
const NXArchInfo *monobjc_get_arch_info();

/**
 * @brief   Checks if associated objects are supported.
 * @return  Returns 1 if associated objects are supported, 0 otherwise.
 */
int monobjc_are_associated_objects_available();

/**
 * @brief   Checks if blocks are supported.
 * @return  Returns 1 if blocks are supported, 0 otherwise.
 */
int monobjc_are_blocks_available();

#endif // __SUPPORT_OS_H__
