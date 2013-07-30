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
 * @file    cache.h
 * @brief   Defines the cache semantics to for the caches used in the bridge.
 * @author  Laurent Etiemble <laurent.etiemble@monobjc.net>
 * @date    2009-2013
 */
#ifndef __CACHE_H__
#define __CACHE_H__

#include "domain.h"

/**
 * @brief   Create the caches used by the bridge.
 */
void monobjc_create_caches();

/**
 * @brief   Destroy the caches used by the bridge.
 */
void monobjc_destroy_caches();

/**
 * @brief   Dump the caches used by the bridge.
 *
 * @remark  This function is for debug purpose.
 */
void monobjc_dump_caches();

#pragma mark ----- Instances functions -----

/**
 * @brief   Map a native instance to its managed wrapper.
 * @param   ptr             The native instance.
 * @param   wrapper         The managed object that wraps the native instance.
 * @remark  The managed wrapper will be referenced to avoid garbage collection.
 */
void monobjc_cache_map_instance(void *ptr, MonoObject *wrapper);

/**
 * @brief   Lookup the native instance in the instances cache.
 * @param   ptr             The native instance.
 * @return  The managed object that wraps the native object or NULL if the native instance is not mapped.
 */
MonoObject *monobjc_cache_lookup_instance(void *ptr);

/**
 * @brief   Remove a native instance and its wrapper from the cache.
 * @param   ptr             The native instance.
 */
void monobjc_cache_remove_instance(void *ptr);

/**
 * @brief   Remove a native instance and its wrapper from the cache.
 * @param   ptr             The native instance.
 * @param   domain_data     The domain.
 */
void monobjc_cache_remove_instance_in_domain(void *ptr, MonobjcDomainData *domain_data);

#endif // __CACHE_H__
