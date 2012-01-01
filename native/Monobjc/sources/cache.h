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
 * @file    cache.h
 * @brief   Defines the cache semantics to for the caches used in the bridge.
 * @author  Laurent Etiemble <laurent.etiemble@monobjc.net>
 * @date    2009-2012
 */
#ifndef __CACHE_H__
#define __CACHE_H__

#include "domain.h"

/**
 * @brief   Create the instance related caches used by the bridge.
 */
void monobjc_create_caches();

/**
 * @brief   Destroy the instance related cache used by the bridge.
 */
void monobjc_destroy_caches();

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
