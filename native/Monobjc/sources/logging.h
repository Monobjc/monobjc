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
 * @file    logging.h
 * @brief   Contains definitions for logging.
 * @author  Laurent Etiemble <laurent.etiemble@monobjc.net>
 * @date    2009-2014
 */
#ifndef __LOGGING_H__
#define __LOGGING_H__

#include "enumerations.h"

#define MACH_THREAD_ID      pthread_mach_thread_np(pthread_self())

/** @brief  Default message appended when an error is logged. */
#define BUGREPORT_MESSAGE   "If this is not really the expected behavior, please report it to http://tracker.monobjc.net/"

/** @brief  Holds the current level to log. */
extern MonobjcLogLevel monobjc_current_log_level;

/** @brief  Holds the current domains to log. */
extern MonobjcLogDomain monobjc_current_log_domain;

/**
 * @brief   Setup the logging engine.
 */
void monobjc_setup_logging();

/**
 * @brief   Output a log statement.
 * @param   log_level   The level for the log.
 * @param   domain      The domain for the log.
 * @param   format      The format string to use.
 * @param   ...         The arguments for the formatting.
 */
void monobjc_log(MonobjcLogLevel log_level, MonobjcLogDomain domain, const char *format, ...);

/**
 * @brief   Output a log statement.
 * @param   log_level   The level for the log.
 * @param   domain      The domain for the log.
 * @param   format      The format string to use.
 * @param   args        The arguments for the formatting.
 */
void monobjc_logv(MonobjcLogLevel log_level, MonobjcLogDomain domain, const char *format, va_list args);

/**
 * @brief   Output a memory dump.
 * @param   ptr         The pointer where to start the dump.
 * @param   size        The size of the dump.
 */
void monobjc_dump_memory(void *ptr, int size);

/** @brief  Shortcut macro for ERROR log. */
#define LOG_ERROR(domain, format, ...)      monobjc_log(MONOBJC_LOG_ERROR, domain, format "%s", ##__VA_ARGS__, " " BUGREPORT_MESSAGE)

/** @brief  Shortcut macro for WARNING log. */
#define LOG_WARNING(domain, format, ...)    monobjc_log(MONOBJC_LOG_WARN, domain, format, ##__VA_ARGS__)

/** @brief  Shortcut macro for INFO log. */
#define LOG_INFO(domain, format, ...)       monobjc_log(MONOBJC_LOG_INFO, domain, format, ##__VA_ARGS__)

/** @brief  Shortcut macro for DEBUG log. */
#define LOG_DEBUG(domain, format, ...)      monobjc_log(MONOBJC_LOG_DEBUG, domain, format, ##__VA_ARGS__)

#endif // __LOGGING_H__
