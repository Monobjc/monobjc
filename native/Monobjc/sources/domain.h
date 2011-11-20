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
 * @file    domain.h
 * @brief   Contains the per-domain structure and functions.
 * @author  Laurent Etiemble <laurent.etiemble@monobjc.net>
 * @date    2009-2011
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
    
    /*! @brief  Mutex to guard access to #CALLS_HASHTABLE. */
    pthread_mutex_t CALLS_MUTEX;
    /*! @brief  Mutex to guard access to #DESCRIPTORS_HASHTABLE. */
    pthread_mutex_t DESCRIPTORS_MUTEX;
    /*! @brief  Mutex to guard access to #INSTANCES_HASHTABLE. */
    pthread_mutex_t INSTANCES_MUTEX;
} MonobjcDomainData;


/** @brief  Shortcut accessor to the hashtable that serves as a cache for the calls. */
#define __CALLS_HASHTABLE           monobjc_get_domain_data(mono_domain_get())->CALLS_HASHTABLE

/** @brief  Shortcut accessor to the mutex for the calls' hashtable. */
#define __CALLS_MUTEX               monobjc_get_domain_data(mono_domain_get())->CALLS_MUTEX

/** @brief  Shortcut macro for lock acquisition. */
#define LOCK_CALLS()                MONOBJC_MUTEX_LOCK(&__CALLS_MUTEX)

/** @brief  Shortcut macro for lock release. */
#define UNLOCK_CALLS()              MONOBJC_MUTEX_UNLOCK(&__CALLS_MUTEX)


/** @brief  Shortcut accessor to the hashtable that serves as a cache for the descriptors. */
#define __DESCRIPTORS_HASHTABLE     monobjc_get_domain_data(mono_domain_get())->DESCRIPTORS_HASHTABLE

/** @brief  Shortcut accessor to the mutex for the descriptors' hashtable. */
#define __DESCRIPTORS_MUTEX         monobjc_get_domain_data(mono_domain_get())->DESCRIPTORS_MUTEX

/** @brief  Shortcut macro for lock acquisition. */
#define LOCK_DESCRIPTORS()          MONOBJC_MUTEX_LOCK(&__DESCRIPTORS_MUTEX)

/** @brief  Shortcut macro for lock release. */
#define UNLOCK_DESCRIPTORS()        MONOBJC_MUTEX_UNLOCK(&__DESCRIPTORS_MUTEX)


/** @brief  Shortcut accessor to the hashtable that serves as a cache for the instances. */
#define __INSTANCES_HASHTABLE       monobjc_get_domain_data(mono_domain_get())->INSTANCES_HASHTABLE

/** @brief  Shortcut accessor to the mutex for the instances' hashtable. */
#define __INSTANCES_MUTEX           monobjc_get_domain_data(mono_domain_get())->INSTANCES_MUTEX

/** @brief  Shortcut macro for lock acquisition. */
#define LOCK_INSTANCES()            MONOBJC_MUTEX_LOCK(&__INSTANCES_MUTEX)

/** @brief  Shortcut macro for lock release. */
#define UNLOCK_INSTANCES()          MONOBJC_MUTEX_UNLOCK(&__INSTANCES_MUTEX)


/** @brief  Shortcut accessor to the hashtable that serves as a cache for the wrappers. */
#define __WRAPPERS_HASHTABLE        monobjc_get_domain_data(mono_domain_get())->WRAPPERS_HASHTABLE

/** @brief  Shortcut accessor to the hashtable that serves as a cache for the constructors. */
#define __CONSTRUCTORS_HASHTABLE    monobjc_get_domain_data(mono_domain_get())->CONSTRUCTORS_HASHTABLE

/**
 * @brief   Create the domain data for the current domain.
 */
void monobjc_create_domain_data();

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

/*!
 * @brief   Iterate over the domain data to remove the given instance.
 * @param   ptr    The instance.
 */
void monobjc_remove_instance_in_domains(void *ptr);

#endif // __DOMAIN_H__
