//
// This file is part of Monobjc, a .NET/Objective-C bridge
// Copyright (C) 2007-2013 - Laurent Etiemble
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
 * @file    support-os.h
 * @brief   Contains OS detection functions.
 * @author  Laurent Etiemble <laurent.etiemble@monobjc.net>
 * @date    2009-2013
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
