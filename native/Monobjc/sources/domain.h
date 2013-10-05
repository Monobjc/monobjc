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
 * @file    domain.h
 * @brief   Contains the per-domain structure and functions.
 * @author  Laurent Etiemble <laurent.etiemble@monobjc.net>
 * @date    2009-2013
 */
#ifndef __DOMAIN_H__
#define __DOMAIN_H__

#include "threading.h"

/**
 * @brief   Per-domain data needed by the bridge.
 *          This data structure allows multiple .NET domains to use the bridge.
 */
typedef struct MonobjcDomainData {
    /** @brief  The domain identifier. */
    int32_t identifier;
    
    /** @brief  The domain token to suffix managed types. */
    char *token;
    
    #undef DEFINITION
    /** @brief  Print the fields for the definitions */
    #define DEFINITION(TYPE, NAME)    TYPE NAME;
    #include "definitions.def"
    
    /** @brief  Cache for the calls. */
    GHashTable *CALLS_HASHTABLE;
    /** @brief  Cache for the descriptors. */
    GHashTable *DESCRIPTORS_HASHTABLE;
    /** @brief  Cache for the instances. */
    GHashTable *INSTANCES_HASHTABLE;
    /** @brief  Cache for the wrappers. */
    GHashTable *WRAPPERS_HASHTABLE;
    /** @brief  Cache for the wrappers. */
    GHashTable *CONSTRUCTORS_HASHTABLE;
    
    /** @brief  Mutex to guard access to #CALLS_HASHTABLE. */
    pthread_mutex_t CALLS_MUTEX;
    /** @brief  Mutex to guard access to #DESCRIPTORS_HASHTABLE. */
    pthread_mutex_t DESCRIPTORS_MUTEX;
    /** @brief  Mutex to guard access to #INSTANCES_HASHTABLE. */
    pthread_mutex_t INSTANCES_MUTEX;
} MonobjcDomainData;


/** @brief  Mutex to protect domain data. */
extern pthread_mutex_t __DOMAINS_MUTEX;


/** @brief  Shortcut macro for lock acquisition. */
#define LOCK_DOMAINS()              monobjc_mutex_lock(&__DOMAINS_MUTEX)

/** @brief  Shortcut macro for lock release. */
#define UNLOCK_DOMAINS()            monobjc_mutex_unlock(&__DOMAINS_MUTEX)


/** @brief  Shortcut accessor to the hashtable that serves as a cache for the calls. */
#define __CALLS_HASHTABLE           monobjc_get_domain_data(mono_domain_get())->CALLS_HASHTABLE

/** @brief  Shortcut accessor to the mutex for the calls' hashtable. */
#define __CALLS_MUTEX               monobjc_get_domain_data(mono_domain_get())->CALLS_MUTEX

/** @brief  Shortcut macro for lock acquisition. */
#define LOCK_CALLS()                monobjc_mutex_lock(&__CALLS_MUTEX)

/** @brief  Shortcut macro for lock release. */
#define UNLOCK_CALLS()              monobjc_mutex_unlock(&__CALLS_MUTEX)


/** @brief  Shortcut accessor to the hashtable that serves as a cache for the descriptors. */
#define __DESCRIPTORS_HASHTABLE     monobjc_get_domain_data(mono_domain_get())->DESCRIPTORS_HASHTABLE

/** @brief  Shortcut accessor to the mutex for the descriptors' hashtable. */
#define __DESCRIPTORS_MUTEX         monobjc_get_domain_data(mono_domain_get())->DESCRIPTORS_MUTEX

/** @brief  Shortcut macro for lock acquisition. */
#define LOCK_DESCRIPTORS()          monobjc_mutex_lock(&__DESCRIPTORS_MUTEX)

/** @brief  Shortcut macro for lock release. */
#define UNLOCK_DESCRIPTORS()        monobjc_mutex_unlock(&__DESCRIPTORS_MUTEX)


/** @brief  Shortcut accessor to the hashtable that serves as a cache for the instances. */
#define __INSTANCES_HASHTABLE       monobjc_get_domain_data(mono_domain_get())->INSTANCES_HASHTABLE

/** @brief  Shortcut accessor to the mutex for the instances' hashtable. */
#define __INSTANCES_MUTEX           monobjc_get_domain_data(mono_domain_get())->INSTANCES_MUTEX

/** @brief  Shortcut macro for lock acquisition.
 *  @remark Note that LOCK_DOMAINS() must always be called prior to LOCK_INSTANCES() to avoid
 *          deadlock since monobjc_remove_instance_in_domains acquires the __DOMAINS_MUTEX and
 *          waits on the __INSTANCES_MUTEX. The __INSTANCES_MUTEX can't be released from another
 *          thread if that thread doesn't hold the __DOMAINS_MUTEX because monobjc_get_domain_data
 *          has to take the __DOMAINS_MUTEX lock.
 */
#define LOCK_INSTANCES()            LOCK_DOMAINS(); monobjc_mutex_lock(&__INSTANCES_MUTEX)

/** @brief  Shortcut macro for lock release. */
#define UNLOCK_INSTANCES()          monobjc_mutex_unlock(&__INSTANCES_MUTEX); UNLOCK_DOMAINS()


/** @brief  Shortcut accessor to the hashtable that serves as a cache for the wrappers. */
#define __WRAPPERS_HASHTABLE        monobjc_get_domain_data(mono_domain_get())->WRAPPERS_HASHTABLE

/** @brief  Shortcut accessor to the hashtable that serves as a cache for the constructors. */
#define __CONSTRUCTORS_HASHTABLE    monobjc_get_domain_data(mono_domain_get())->CONSTRUCTORS_HASHTABLE

/**
 * @brief   Create the domain data for the current domain.
 */
void monobjc_create_domain_data(const char *domain_token);

/**
 * @brief   Destroy the domain data for the current domain.
 */
void monobjc_destroy_domain_data();

/**
 * @brief   Retrieve the domain data for the given domain.
 * @param   domain  The domain.
 * @return  The domain data.
 */
MonobjcDomainData *monobjc_get_domain_data(MonoDomain *domain);

/**
 * @brief   Iterate over the domain data to remove the given instance.
 * @param   ptr    The instance.
 */
void monobjc_remove_instance_in_domains(void *ptr);

/**
 * @brief   Enable automatic generation of domain tokens.
 */
void monobjc_enable_auto_domain_tokens();

#endif // __DOMAIN_H__
