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
 * @file    threading.h
 * @brief   Contains functions to control native/managed thread interaction.
 * @author  Laurent Etiemble <laurent.etiemble@monobjc.net>
 * @date    2009-2010
 */
#ifndef __THREADING_H__
#define __THREADING_H__

#include <pthread.h>

/*!
 * @brief   Initialize a mutex.
 * @param   mutex       A pointer to a mutex to initialize.
 * @param   reentrant   Whether the mutex should be re-entrant.
 */
#define MONOBJC_MUTEX_INIT(mutex, reentrant)                            \
    pthread_mutexattr_t attrs;                                          \
    pthread_mutexattr_init(&attrs);                                     \
    if (reentrant) {                                                    \
        pthread_mutexattr_settype(&attrs, PTHREAD_MUTEX_RECURSIVE);     \
    } else {                                                            \
        pthread_mutexattr_settype(&attrs, PTHREAD_MUTEX_ERRORCHECK);    \
    }                                                                   \
    pthread_mutex_init(mutex, &attrs);

/**
 * @brief   Lock a mutex.
 * @param   mutex       The mutex to lock.
 */
#define MONOBJC_MUTEX_LOCK(mutex)   pthread_mutex_lock(mutex);

/**
 * @brief   Unlock a mutex.
 * @param   mutex       The mutex to unlock.
 */
#define MONOBJC_MUTEX_UNLOCK(mutex) pthread_mutex_unlock(mutex);

/**
 * @brief   Destroy a mutex.
 * @param   mutex       The mutex to destroy.
 */
#define MONOBJC_MUTEX_FREE(mutex)   pthread_mutex_destroy(mutex);

#pragma mark -----

#if defined(THREAD_MANAGEMENT)

/** 
 * @brief   Statically assigned thread key for Monobjc TSD.
 * @remark  See http://www.opensource.apple.com/source/Libc/Libc-583/pthreads/pthread_machdep.h
 */
#define PTK_FRAMEWORK_MONOBJC_KEY1 240

/**
 * @brief   Structure to store each thread related data
 */
typedef struct MonobjcThreadEntry {
    /** @brief  The pthread_t structure of the thread */
    pthread_t id;
    /** @brief  The TSD destruction count */
    int tsd_count;
};

/** 
 * @brief   Function pointer for the "pthread_key_init_np()" function.
 * @remark  See http://www.opensource.apple.com/source/Libc/Libc-583/pthreads/pthread_tsd.c
 */
typedef int (*PTHREAD_KEY_INIT_NP)(int, void (*)(void *));

/*! @brief  Function pointer for the "GC_thread GC_lookup_thread(pthread_t)" function. */
typedef void *(*MONO_GC_LOOKUP_THREAD)(pthread_t);

/** @brief  Function pointer for the "void GC_thread_deregister_foreign(void *)" function. */
typedef void (*MONO_GC_THREAD_DEREGISTER_FOREIGN)(void *);

/**
 * @brief   Enroll the give thread to the thread list, if it is not added yet.
 * @param   id  The identifier of the thread.
 */
void monobjc_enroll_thread(pthread_t id);

/**
 * @brief   Setup the thread management for the bridge.
 */
void monobjc_setup_thread_management();

#endif

#endif // __THREADING_H__
