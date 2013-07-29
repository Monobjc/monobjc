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
 * @file    cache.mm
 * @brief   Defines the cache semantics to for the caches used in the bridge.
 * @author  Laurent Etiemble <laurent.etiemble@monobjc.net>
 * @date    2009-2013
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
    __WRAPPERS_HASHTABLE = g_hash_table_new_full(g_direct_hash, g_direct_equal, NULL, NULL);
    LOG_INFO(MONOBJC_DOMAIN_GENERAL, "Create cache for constructors");
    __CONSTRUCTORS_HASHTABLE = g_hash_table_new_full(g_direct_hash, g_direct_equal, NULL, NULL);
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
