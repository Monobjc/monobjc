// 
// This file is part of Monobjc, a .NET/Objective-C bridge
// Copyright (C) 2007-2012 - Laurent Etiemble
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
 * @date    2009-2012
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

#endif // __THREADING_H__
