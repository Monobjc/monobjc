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
 * @file    lifecycle.mm
 * @brief   Contains functions to plug into the Objective-C object lifecycle.
 * @author  Laurent Etiemble <laurent.etiemble@monobjc.net>
 * @date    2009-2010
 */
#include "cache.h"
#include "domain.h"
#include "glib.h"
#include "lifecycle.h"
#include "logging.h"
#include "support-objc.h"
#include "threading.h"

/*! @brief  Hashtable that contains original implementations for dealloc messages. */
static GHashTable *__IMPLEMENTATIONS = NULL; 

/**
 * @brief   Static function that handle invocations to 'dealloc' messages.
 */
static void __dealloc_interceptor(id target, SEL name) {
    LOG_DEBUG(MONOBJC_DOMAIN_INSTANCES, "Intercepting dealloc for target=0x%lx", target);
    
    // Get the root meta class of the target
    Class root_meta_class = target->isa->isa->isa;
    
    LOG_DEBUG(MONOBJC_DOMAIN_INSTANCES, "Target Root Meta Class is %s", class_getName(root_meta_class));
    
    // Get the implementation for the target root class
    IMP implementation = (IMP) g_hash_table_lookup(__IMPLEMENTATIONS, root_meta_class);
    
    // Remove the target in every domain
    monobjc_remove_instance_in_domains(target);
    
    // This is a strategic place to enroll the thread in our list
    //monobjc_enroll_thread(pthread_self());
    
    // Call original implementation so everything get back to normal
    implementation(target, name);
}

#pragma mark ----- Implementation -----

void monobjc_intercep_dealloc_for(Class cls) {
    if (!__IMPLEMENTATIONS) {
        __IMPLEMENTATIONS = g_hash_table_new(g_direct_hash, g_direct_equal);
    }

    // Get the root meta class
    Class root_meta_class = cls->isa->isa;
    
    // Check if we already deal with the root meta class
    if (g_hash_table_lookup(__IMPLEMENTATIONS, root_meta_class)) {
        return;
    }
    
    LOG_INFO(MONOBJC_DOMAIN_INSTANCES, "Intercept dealloc for class %s", class_getName(cls));
    
#if TARGET_CPU_X86 || TARGET_CPU_PPC
    IMP implementation = class_replaceMethod(cls, @selector(dealloc), (IMP) __dealloc_interceptor, "v8@0:4");
#elif TARGET_CPU_X86_64 || TARGET_CPU_PPC64
    IMP implementation= class_replaceMethod(cls, @selector(dealloc), (IMP) __dealloc_interceptor, "v16@0:8");
#else
#error Unsupported CPU
#endif
    
    // Store the implementation in the map
    g_hash_table_insert(__IMPLEMENTATIONS, root_meta_class, (void *) implementation);
}
