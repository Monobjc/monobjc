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
 * @file    threading.mm
 * @brief   Contains functions to control native/managed thread interaction.
 * @author  Laurent Etiemble <laurent.etiemble@monobjc.net>
 * @date    2009-2010
 */
#include <dlfcn.h>
#include "logging.h"
#include "threading.h"

#if defined(THREAD_MANAGEMENT)

/** @brief  Static storage for the thread key. */
static pthread_key_t __foreign_thread_key = PTK_FRAMEWORK_MONOBJC_KEY1;

/** @brief  Symbol address for "pthread_key_init_np()" function (from Apple). */
static PTHREAD_KEY_INIT_NP __pthread_key_init_np = NULL;

/** @brief  Symbol address for "GC_thread GC_lookup_thread(pthread_t)" function (from Mono). */
static MONO_GC_LOOKUP_THREAD __mono_gc_lookup_thread = NULL;

/** @brief  Symbol address for "void GC_thread_deregister_foreign(void *)" function (from Mono). */
static MONO_GC_THREAD_DEREGISTER_FOREIGN __mono_gc_thread_deregister_foreign = NULL;

/*! @brief  List of the thread entries. */
static GHashTable *__THREADS = NULL;

/*! @brief  Mutex for the thread entries list. */
static pthread_mutex_t __THREADS_MUTEX;

/*! @brief  Shortcut macro for lock acquisition. */
#define LOCK_THREADS()      MONOBJC_MUTEX_LOCK(&__THREADS_MUTEX)

/** @brief  Shortcut macro for lock release. */
#define UNLOCK_THREADS()    MONOBJC_MUTEX_UNLOCK(&__THREADS_MUTEX)

/**
 * @brief   Destructor function called when TSD are cleared.
 * @param   data    The thread data.
 */
static void __TSD_destructor(void *data) {
    MonobjcThreadEntry *entry = (MonobjcThreadEntry *) data;
    
    // Get the thread getting clean up
    LOG_INFO(MONOBJC_DOMAIN_THREADING, "Cleaning TSD for thread 0x%lx (count=0x%x)", entry->id, entry->tsd_count);
    
    // Increment the de-registering count
    entry->tsd_count++;
    
    if (entry->tsd_count < PTHREAD_DESTRUCTOR_ITERATIONS) {
        // Until we reach the call limit, re-set TSD value in order to be called again
        pthread_setspecific(__foreign_thread_key, entry);
    } else {
        // Once we reach the call limit, truly de-register the thread
        LOG_INFO(MONOBJC_DOMAIN_THREADING, "Cleaning thread 0x%lx", entry->id);    

        // Check if Mono's runtime still holds a reference to this thread
        void *data = __mono_gc_lookup_thread(entry->id);
        if (data) {
            // If yes, then clean it for good
            LOG_INFO(MONOBJC_DOMAIN_THREADING, "Mono still holds a reference to thread 0x%lx", entry->id);    
            __mono_gc_thread_deregister_foreign(data);
        }
        
        LOCK_THREADS();
        
        // Remove the thread entry from our list
        g_hash_table_remove(__THREADS, entry->id);
        g_free(entry);
        
        UNLOCK_THREADS();
    }
}

#pragma mark ----- Implementation -----

void monobjc_setup_thread_management() {
    // Create access mutex
    MONOBJC_MUTEX_INIT(&__THREADS_MUTEX, FALSE);
    
    // Create the thread tables
    __THREADS = g_hash_table_new(g_direct_hash, g_direct_equal);
    
    // We look up non-portable Apple extension for TSD:
    // - It does not exist on Mac OS X 10.4
    // - It exist on Mac OS X 10.5 and later
    __pthread_key_init_np = (PTHREAD_KEY_INIT_NP) dlsym(RTLD_DEFAULT, "pthread_key_init_np");
    
    // Plug a TSD value, so our destructor is called
    if (__pthread_key_init_np) {
        LOG_DEBUG(MONOBJC_DOMAIN_THREADING, "Using Apple extensions for TSD");            
        __pthread_key_init_np(PTK_FRAMEWORK_MONOBJC_KEY1, __TSD_destructor);
    } else {
        LOG_DEBUG(MONOBJC_DOMAIN_THREADING, "Using POSIX for TSD");            
        pthread_key_create(&__foreign_thread_key, __TSD_destructor);
    }
    
    // We search function by look up to deal with two cases:
    // - Launch by mono command (the symbol is in the mono executable)
    // - Launch as a bundle (the symbol is in the libmono library)
    __mono_gc_thread_deregister_foreign    = (MONO_GC_THREAD_DEREGISTER_FOREIGN)    dlsym(RTLD_DEFAULT, "GC_thread_deregister_foreign");
    __mono_gc_lookup_thread                = (MONO_GC_LOOKUP_THREAD)                dlsym(RTLD_DEFAULT, "GC_lookup_thread");
    
    if (__mono_gc_lookup_thread && __mono_gc_thread_deregister_foreign) {
        LOG_INFO(MONOBJC_DOMAIN_THREADING, "Hooking into Mono's runtime with the libgc API");
    } else {
        LOG_WARNING(MONOBJC_DOMAIN_THREADING, "Cannot hook into Mono's runtime. Crashes may happen !!!");
    }
}

void monobjc_enroll_thread(pthread_t id) {
    LOCK_THREADS();
    
    // Add new thread entry to the list if it is not there
    MonobjcThreadEntry *entry = (MonobjcThreadEntry *) g_hash_table_lookup(__THREADS, id);
    if (!entry) {
        LOG_INFO(MONOBJC_DOMAIN_THREADING, "Enrolling thread 0x%lx", id);
        
        // Create the entry
        entry = g_new(MonobjcThreadEntry, 1);
        entry->id = id;
        entry->tsd_count = 0;
        g_hash_table_insert(__THREADS, entry->id, entry);
        
        // Set TSD
        pthread_setspecific(__foreign_thread_key, entry);
    }
    
    UNLOCK_THREADS();
}

#endif
