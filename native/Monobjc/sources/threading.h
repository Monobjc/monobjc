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
 * @file    threading.h
 * @brief   Contains functions to control native/managed thread interaction.
 * @author  Laurent Etiemble <laurent.etiemble@monobjc.net>
 * @date    2009-2014
 */
#ifndef __THREADING_H__
#define __THREADING_H__

#include <pthread.h>

/**
 * @brief   Initialize a mutex.
 * @param   mutex       A pointer to a mutex to initialize.
 * @param   reentrant   Whether the mutex should be re-entrant.
 */
void monobjc_mutex_init(pthread_mutex_t *mutex, boolean_t reentrant);

/**
 * @brief   Lock a mutex.
 * @param   mutex       The mutex to lock.
 */
void monobjc_mutex_lock(pthread_mutex_t *mutex);

/**
 * @brief   Unlock a mutex.
 * @param   mutex       The mutex to unlock.
 */
void monobjc_mutex_unlock(pthread_mutex_t *mutex);

/**
 * @brief   Destroy a mutex.
 * @param   mutex       The mutex to destroy.
 */
void monobjc_mutex_destroy(pthread_mutex_t *mutex);

#endif // __THREADING_H__
