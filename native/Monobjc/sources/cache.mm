// 
// This file is part of Monobjc, a .NET/Objective-C bridge
// Copyright (C) 2007-2011 - Laurent Etiemble
// 
// Monobjc is free software: you can redistribute it and/or modify
// it under the terms void *of the GNU Lesser General Public License as published
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
 * @file    cache.mm
 * @brief   Defines the cache semantics to for the caches used in the bridge.
 * @author  Laurent Etiemble <laurent.etiemble@monobjc.net>
 * @date    2009-2010
 */
#include "cache.h"
#include "definitions.h"
#include "domain.h"
#include "logging.h"

/**
 * @brief   Destruction callback for the instance.
 * @param   allocator   The allocator.
 * @param   value       The instance to destroy.
 */
static void __destroy_instance(void *value) {
    uint32_t gchandle = (uint32_t) ((intptr_t) value);
    LOG_DEBUG(MONOBJC_DOMAIN_INSTANCES, "Destroying GCHandle to %p", mono_gchandle_get_target(gchandle));
    mono_gchandle_free(gchandle);
}

#pragma mark ----- Implementation -----

void monobjc_create_caches() {
    MONOBJC_MUTEX_INIT(&__INSTANCES_MUTEX, FALSE);
    
    LOG_INFO(MONOBJC_DOMAIN_GENERAL, "Create cache for instances");
    __INSTANCES_HASHTABLE = g_hash_table_new_full(g_direct_hash, g_direct_equal, NULL, __destroy_instance);
    LOG_INFO(MONOBJC_DOMAIN_GENERAL, "Create cache for wrappers");
    __WRAPPERS_HASHTABLE = g_hash_table_new_full(g_str_hash, g_str_equal, NULL, NULL);
    LOG_INFO(MONOBJC_DOMAIN_GENERAL, "Create cache for constructors");
    __CONSTRUCTORS_HASHTABLE = g_hash_table_new_full(g_str_hash, g_str_equal, NULL, NULL);
}

void monobjc_destroy_caches() {
    LOG_INFO(MONOBJC_DOMAIN_GENERAL, "Destroy cache for instances");
    g_hash_table_destroy(__INSTANCES_HASHTABLE);
    LOG_INFO(MONOBJC_DOMAIN_GENERAL, "Destroy cache for wrappers");
    g_hash_table_destroy(__WRAPPERS_HASHTABLE);
    LOG_INFO(MONOBJC_DOMAIN_GENERAL, "Destroy cache for constructors");
    g_hash_table_destroy(__CONSTRUCTORS_HASHTABLE);
    
    MONOBJC_MUTEX_FREE(&__INSTANCES_MUTEX);
}

void monobjc_cache_map_instance(void *ptr, MonoObject *wrapper) {
    LOG_DEBUG(MONOBJC_DOMAIN_INSTANCES, "Map instance %p", ptr);
    uint32_t gchandle = mono_gchandle_new(wrapper, FALSE);
    g_hash_table_insert(__INSTANCES_HASHTABLE, ptr, (void *) gchandle);
}

MonoObject *monobjc_cache_lookup_instance(void *ptr) {
    LOG_DEBUG(MONOBJC_DOMAIN_INSTANCES, "Look up instance for %p", ptr);
    MonoObject *result = NULL;
    void *value = g_hash_table_lookup(__INSTANCES_HASHTABLE, ptr);
    if (value) {
        uint32_t gchandle = (uint32_t) ((intptr_t) value);
        result = mono_gchandle_get_target(gchandle);
    }
    return result;
}

void monobjc_cache_remove_instance(void *ptr) {
    LOG_DEBUG(MONOBJC_DOMAIN_INSTANCES, "Remove instance for %p", ptr);
    g_hash_table_remove(__INSTANCES_HASHTABLE, ptr);
}

void monobjc_cache_remove_instance_in_domain(void *ptr, MonobjcDomainData *domain_data) {
    LOG_DEBUG(MONOBJC_DOMAIN_INSTANCES, "Remove instance for %p in domain #%d", ptr, domain_data->identifier);
    g_hash_table_remove(domain_data->INSTANCES_HASHTABLE, ptr);
}
