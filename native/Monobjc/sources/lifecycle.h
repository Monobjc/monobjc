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
 * @file    lifecycle.h
 * @brief   Contains functions to plug into the Objective-C object lifecycle.
 * @author  Laurent Etiemble <laurent.etiemble@monobjc.net>
 * @date    2009-2013
 */
#ifndef __LIFECYCLE_H__
#define __LIFECYCLE_H__

#include "threading.h"

/** @brief  Mutex around implementation table. */
extern pthread_mutex_t __IMPLEMENTATIONS_MUTEX;

/** @brief  Shortcut macro for lock acquisition. */
#define LOCK_IMPLEMENTATIONS()                  monobjc_mutex_lock(&__IMPLEMENTATIONS_MUTEX)

/** @brief  Shortcut macro for lock release. */
#define UNLOCK_IMPLEMENTATIONS()                monobjc_mutex_unlock(&__IMPLEMENTATIONS_MUTEX)

/**
 * @brief   Setup the interception of the \c dealloc messages for the given class.
 * @param   cls     The native class to intercept.
 */
void monobjc_intercep_dealloc_for(Class cls);

#endif // __LIFECYCLE_H__
