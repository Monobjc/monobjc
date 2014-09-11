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
 * @file    threading.mm
 * @brief   Contains functions to control native/managed thread interaction.
 * @author  Laurent Etiemble <laurent.etiemble@monobjc.net>
 * @date    2009-2014
 */
#include "logging.h"
#include "threading.h"

/**
 * @brief   Helper function to convert a mutex error into a readable string.
 * @param   error   The error to convert.
 * @return  The readable string.
 */
static const char *pthread_error_to_string(int error) {
    switch (error) {
        case EAGAIN:
            return "[EAGAIN] The mutex could not be acquired because the maximum number of recursive locks for mutex has been exceeded.";
        case EBUSY:
            return "[EBUSY] The mutex could not be acquired because it was already locked.";
        case EINVAL:
            return "[EINVAL] The value specified by mutex does not refer to an initialised mutex object or the mutex was created with the protocol attribute having the value PTHREAD_PRIO_PROTECT and the calling thread's priority is higher than the mutex's current priority ceiling.";
        case EDEADLK:
            return "[EDEADLK] The current thread already owns the mutex.";
        case EPERM:
            return "[EPERM] The current thread does not own the mutex.";
        default:
            return "Unkown";
    }
}

#pragma mark ----- Implementation -----

void monobjc_mutex_init(pthread_mutex_t *mutex, boolean_t reentrant) {
    pthread_mutexattr_t attrs;
    pthread_mutexattr_init(&attrs);
    if (reentrant) {
        pthread_mutexattr_settype(&attrs, PTHREAD_MUTEX_RECURSIVE);
    } else {
        pthread_mutexattr_settype(&attrs, PTHREAD_MUTEX_ERRORCHECK);
    }
    pthread_mutex_init(mutex, &attrs);
}

void monobjc_mutex_lock(pthread_mutex_t *mutex) {
    // Results must be checked to detect logic errors while coding
    int result = pthread_mutex_lock(mutex);
    if (result != 0) {
        LOG_ERROR(MONOBJC_DOMAIN_GENERAL, "pthread_mutex_lock failed: %s", pthread_error_to_string(result));
        abort();
    }
}

void monobjc_mutex_unlock(pthread_mutex_t *mutex) {
    // Results must be checked to detect logic errors while coding
    int result = pthread_mutex_unlock(mutex);
    if (result != 0) {
        LOG_ERROR(MONOBJC_DOMAIN_GENERAL, "pthread_mutex_unlock failed: %s", pthread_error_to_string(result));
        abort();
    }
}

void monobjc_mutex_destroy(pthread_mutex_t *mutex) {
    pthread_mutex_destroy(mutex);
}
