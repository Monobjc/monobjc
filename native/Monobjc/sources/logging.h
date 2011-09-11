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
 * @file    logging.h
 * @brief   Contains definitions for logging.
 * @author  Laurent Etiemble <laurent.etiemble@monobjc.net>
 * @date    2009-2011
 */
#ifndef __LOGGING_H__
#define __LOGGING_H__

#include "enumerations.h"

/** @brief  Default message appended when an error is logged. */
#define BUGREPORT_MESSAGE    "If this is not really the expected behavior, please report it to http://tracker.monobjc.net/"

/*! @brief  Holds the current level to log. */
extern MonobjcLogLevel monobjc_current_log_level;

/*! @brief  Holds the current domains to log. */
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

/*! @brief  Shortcut macro for ERROR log. */
#define LOG_ERROR(domain, format, ...)      monobjc_log(MONOBJC_LOG_ERROR, domain, format "%s", ##__VA_ARGS__, " " BUGREPORT_MESSAGE)

/*! @brief  Shortcut macro for WARNING log. */
#define LOG_WARNING(domain, format, ...)    monobjc_log(MONOBJC_LOG_WARN, domain, format, ##__VA_ARGS__)

/*! @brief  Shortcut macro for INFO log. */
#define LOG_INFO(domain, format, ...)       monobjc_log(MONOBJC_LOG_INFO, domain, format, ##__VA_ARGS__)

/*! @brief  Shortcut macro for DEBUG log. */
#define LOG_DEBUG(domain, format, ...)      monobjc_log(MONOBJC_LOG_DEBUG, domain, format, ##__VA_ARGS__)

#endif // __LOGGING_H__
