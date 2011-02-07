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
 * @file    icalls-Monobjc.ObjectiveCRuntime.mm
 * @brief   Contains the internal calls for the Monobjc.ObjectiveCRuntime type.
 * @author  Laurent Etiemble <laurent.etiemble@monobjc.net>
 * @date    2009-2010
 */
#include <dlfcn.h>
#include "cache.h"
#include "constants.h"
#include "definitions.h"
#include "domain.h"
#include "icalls.h"
#include "logging.h"
#include "marshal.h"
#include "messaging.h"
#include "support-mono.h"

#pragma mark ----- Internal Calls -----

/**
 * @brief   Internal call to bootstrap the bridge.
 */
void icall_Monobjc_ObjectiveCRuntime_Bootstrap(void) {
    LOG_INFO(MONOBJC_DOMAIN_GENERAL, "Bootstrapping the bridge...");
    
    monobjc_create_domain_data();
    
    monobjc_create_definitions();
    monobjc_create_default_descriptors();
    monobjc_create_cache_for_calls();
    monobjc_create_caches();
}

/**
 * @brief   Internal call to cleanup the bridge.
 */
void icall_Monobjc_ObjectiveCRuntime_CleanUp(void) {
    LOG_INFO(MONOBJC_DOMAIN_GENERAL, "Cleaning up the bridge...");
    
    monobjc_destroy_caches();
    monobjc_destroy_cache_for_calls();
    monobjc_destroy_descriptors();
    monobjc_destroy_definitions();
    
    monobjc_destroy_domain_data();
}

/**
 * @brief   Internal call to retrieve a cached or created instance.
 * @param   type        The type of the instance.
 * @param   ptr         The native pointer.
 * @param   fail_safe   Whether the retrieval can return NULL.
 * @return  Return the required instance by taking it from the cache or by creating it.
 *
 * @remark  TODO: Insert Graph
 */
MonoObject *icall_Monobjc_ObjectiveCRuntime_GetInstance(MonoType *type, void *ptr, boolean_t fail_safe) {
    void *args[1];
    
    // If the pointer is null, return NULL
    if (!ptr) {
        return NULL;
    }
    
    LOCK_INSTANCES();
    
    MonoObject *wrapper = monobjc_cache_lookup_instance(ptr);
    if (wrapper) {
        LOG_DEBUG(MONOBJC_DOMAIN_INSTANCES, "icall_Monobjc_ObjectiveCRuntime_GetInstanceInternal - Found instance for %p", ptr);        
        
        // Check that the wrapper found can be assigned to the requested type.
        MonoClass *wrapper_class = mono_object_get_class(wrapper);
        MonoClass *requested_class = mono_type_get_class(type);
        if (mono_class_is_assignable_from(requested_class, wrapper_class)) {
            goto bail;
        }
                
        // The wrapper is not valid, so set it to NULL
        wrapper = NULL;
        
        LOG_INFO(MONOBJC_DOMAIN_INSTANCES, "Requested %s but found %s for %p", mono_class_get_name(requested_class), mono_class_get_name(wrapper_class), ptr);
        
        // Retrieve the classname associated to the type
        args[0] = mono_type_get_object(mono_domain_get(), type);
        
        MonoString *attribute_name = (MonoString *) mono_runtime_invoke(monobjc_get_Monobjc_Class_GetAttributeName_method(), NULL, args, NULL);
        
        // Retrieve the class associated to the type
        char *name = mono_string_to_utf8(attribute_name);
        Class cls = objc_lookUpClass(name);
        g_free(name);
        
        // Check the native pointer can be assigned
        if (![(id)ptr isKindOfClass:cls]) {
            // If specified, failure can be safely ignored
            if (fail_safe) {
                goto bail;
            }
            // Drop a message to warn the user about incompatibility
            LOG_WARNING(MONOBJC_DOMAIN_INSTANCES, "Incompatble classes: requested %s but found %s for %p", mono_class_get_name(requested_class), mono_class_get_name(wrapper_class), ptr);
        }
    }
    
    // The wrapper is either not found or needs re-wrapping
    if (!wrapper) {
        LOG_DEBUG(MONOBJC_DOMAIN_INSTANCES, "icall_Monobjc_ObjectiveCRuntime_GetInstanceInternal - Creating new instance for %p", ptr);
        
        MonoType *wrapper_type = type;        
        
        // If the requested type is an interface, we search for its wrapping type.
        if (monobjc_type_is_interface(type)) {
            wrapper_type = (MonoType *) g_hash_table_lookup(__WRAPPERS_HASHTABLE, type);
            if (!wrapper_type) {
                args[0] = mono_type_get_object(mono_domain_get(), type);
                
                // As result is boxed, 
                MonoObject *obj = mono_runtime_invoke(monobjc_get_Monobjc_ObjectiveCRuntime_GenerateWrapper_method(), NULL, args, NULL);
                wrapper_type = *(MonoType **) mono_object_unbox(obj);
                
                g_hash_table_insert(__WRAPPERS_HASHTABLE, type, wrapper_type);
            }
        }

        // We retrieve the class from the type
        MonoClass *klass = mono_type_get_class(wrapper_type);
        
        // We need the one-parameter constructor from the wrapper
        MonoMethod *constructor = (MonoMethod *) g_hash_table_lookup(__CONSTRUCTORS_HASHTABLE, klass);
        if (!constructor) {
            constructor = monobjc_get_wrapper_constructor(klass);
            
            g_hash_table_insert(__CONSTRUCTORS_HASHTABLE, klass, constructor);
        }
        
        args[0] = &ptr;
        
        // We create a new wrapper for this instance
        wrapper = mono_object_new(mono_domain_get(), klass);
        mono_runtime_invoke(constructor, wrapper, args, NULL);
    }

bail:
    UNLOCK_INSTANCES();
    
    return wrapper;
}
