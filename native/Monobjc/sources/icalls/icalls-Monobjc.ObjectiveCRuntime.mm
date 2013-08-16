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
 * @file    icalls-Monobjc.ObjectiveCRuntime.mm
 * @brief   Contains the internal calls for the Monobjc.ObjectiveCRuntime type.
 * @author  Laurent Etiemble <laurent.etiemble@monobjc.net>
 * @date    2009-2013
 */
#include <dlfcn.h>
#include "cache.h"
#include "constants.h"
#include "definitions.h"
#include "enumerations.h"
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
void icall_Monobjc_ObjectiveCRuntime_Bootstrap(MonoString *domain_token) {
    LOG_INFO(MONOBJC_DOMAIN_GENERAL, "Bootstrapping the bridge...");
    
    // Put a pool in place since we're going to use autoreleased Objective-C
    // objects in some of these methods.
    @autoreleasepool {
        MonoException *exc = NULL;
        
        char *domain_token_utf8 = domain_token == NULL ? NULL : mono_string_to_utf8(domain_token);
        
        LOCK_DOMAINS();
        @try {
            monobjc_create_domain_data(domain_token_utf8);
            monobjc_create_definitions();
            monobjc_create_default_descriptors();
            monobjc_create_cache_for_calls();
            monobjc_create_caches();
        }
        @catch (NSException *ex) {
            LOG_DEBUG(MONOBJC_DOMAIN_GENERAL, "Native exception caught and rethrown as managed: %s", [[ex description] UTF8String]);
            
            // Encapsulate the native exception (before the domain data is initialized)
            MonoAssembly *assembly = monobjc_define_assembly(MONOBJC);
            MonoImage *image = monobjc_define_image(assembly);
            exc = mono_exception_from_name_msg(image, MONOBJC, OBJECTIVE_C_EXCEPTION, [[ex description] UTF8String]);
        }
        @finally {
            UNLOCK_DOMAINS();
            g_free(domain_token_utf8);
        }
        
        // If there is an exception, raise it now
        if (exc) {
            mono_raise_exception(exc);
        }
    }
}

/**
 * @brief   Internal call to cleanup the bridge.
 */
void icall_Monobjc_ObjectiveCRuntime_CleanUp(void) {
    LOG_INFO(MONOBJC_DOMAIN_GENERAL, "Cleaning up the bridge...");
    
    LOCK_DOMAINS();
    monobjc_destroy_caches();
    monobjc_destroy_cache_for_calls();
    monobjc_destroy_descriptors();
    monobjc_destroy_definitions();
    monobjc_destroy_domain_data();
    UNLOCK_DOMAINS();
}

/**
 * @brief   Internal call to retrieve a cached or created instance.
 * @param   type    The type of the instance.
 * @param   ptr     The native pointer.
 * @param   mode    The retrieval mode.
 * @return  Return the required instance by taking it from the cache or by creating it.
 *
 * @remark  TODO: Insert Graph
 */
MonoObject *icall_Monobjc_ObjectiveCRuntime_GetInstance(MonoType *type, void *ptr, RetrievalMode mode) {
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
        
        if (mode != RetrievalModeOverride) {
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
                if (mode == RetrievalModeFailSafe) {
                    goto bail;
                }
                // Drop a message to warn the user about incompatibility
                LOG_WARNING(MONOBJC_DOMAIN_INSTANCES, "Incompatible classes: requested %s but found %s for %p", mono_class_get_name(requested_class), mono_class_get_name(wrapper_class), ptr);
            }
        }
    }
    
    // The wrapper is either not found or needs re-wrapping
    if (!wrapper) {
        LOG_DEBUG(MONOBJC_DOMAIN_INSTANCES, "icall_Monobjc_ObjectiveCRuntime_GetInstanceInternal - Creating new instance for %p of requested type %s", ptr, mono_class_get_name(mono_type_get_class(type)));
        
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

/**
 * @brief   Internal call to enable automatic generation of domain tokens.
 */
void icall_Monobjc_ObjectiveCRuntime_EnableAutoDomainTokens() {
    // Put a pool in place since we're going to use autoreleased Objective-C
    // objects in some of these methods.
    @autoreleasepool {
        @try {
            monobjc_enable_auto_domain_tokens();
        }
        @catch (NSException *ex) {
            LOG_DEBUG(MONOBJC_DOMAIN_GENERAL, "Native exception caught and rethrown as managed: %s", [[ex description] UTF8String]);
            
            // Encapsulate the native exception (before the domain data is initialized)
            MonoAssembly *assembly = monobjc_define_assembly(MONOBJC);
            MonoImage *image = monobjc_define_image(assembly);
            MonoException *exc = mono_exception_from_name_msg(image, MONOBJC, OBJECTIVE_C_EXCEPTION, [[ex description] UTF8String]);
            mono_raise_exception(exc);
        }
    }
}

MonoString *icall_Monobjc_ObjectiveCRuntime_GetDomainToken() {
    MonoDomain *domain = mono_domain_get();
    MonobjcDomainData *data = monobjc_get_domain_data(domain);
    if (!data || !data->token) {
        return NULL;
    }
    // Right now this method is only called once per domain
    // and then cached on the managed side, otherwise we
    // would want to cache a MonoString in data instead of UTF8.
    return mono_string_new(domain, data->token);
}
