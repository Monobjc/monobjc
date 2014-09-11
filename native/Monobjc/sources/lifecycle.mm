//
// This file is part of Monobjc, a .NET/Objective-C bridge
// Copyright (C) 2007-2014 - Laurent Etiemble
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
 * @file    lifecycle.mm
 * @brief   Contains functions to plug into the Objective-C object lifecycle.
 * @author  Laurent Etiemble <laurent.etiemble@monobjc.net>
 * @date    2009-2014
 */
#include "cache.h"
#include "domain.h"
#include "glib.h"
#include "lifecycle.h"
#include "logging.h"
#include "support-objc.h"
#include "threading.h"

pthread_mutex_t __IMPLEMENTATIONS_MUTEX;

/** @brief  Hashtable that contains original implementations for dealloc messages. */
static GHashTable *__IMPLEMENTATIONS = NULL; 

/**
 * @brief   Static function that handle invocations to 'dealloc' messages.
 */
static void __dealloc_interceptor(id target, SEL name) {
    LOG_DEBUG(MONOBJC_DOMAIN_INSTANCES, "Intercepting dealloc for target=0x%lx", target);
    
    // Get the root meta class of the target
    Class root_meta_class = object_getClass(object_getClass(object_getClass(target)));
    
    LOG_DEBUG(MONOBJC_DOMAIN_INSTANCES, "Target Root Meta Class is %s", class_getName(root_meta_class));
    
    // Get the implementation for the target root class
    LOCK_IMPLEMENTATIONS();
    IMP implementation = (IMP) g_hash_table_lookup(__IMPLEMENTATIONS, root_meta_class);
    UNLOCK_IMPLEMENTATIONS();
    
    // Remove the target in every domain
    monobjc_remove_instance_in_domains(target);
    
    // This is a strategic place to enroll the thread in our list
    //monobjc_enroll_thread(pthread_self());
    
    // Call original implementation so everything get back to normal
    implementation(target, name);
}

#pragma mark ----- Implementation -----

void monobjc_intercep_dealloc_for(Class cls) {
    LOCK_IMPLEMENTATIONS();

    if (!__IMPLEMENTATIONS) {
        __IMPLEMENTATIONS = g_hash_table_new(g_direct_hash, g_direct_equal);
    }

    // Get the root meta class
    Class root_meta_class = cls->isa->isa;
    
    // Check if we already deal with the root meta class
    if (g_hash_table_lookup(__IMPLEMENTATIONS, root_meta_class)) {
        UNLOCK_IMPLEMENTATIONS();
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

    UNLOCK_IMPLEMENTATIONS();
}
