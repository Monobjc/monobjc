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
 * @file    icalls-Monobjc.Logger.mm
 * @brief   Contains the internal calls for the Monobjc.Id type.
 * @author  Laurent Etiemble <laurent.etiemble@monobjc.net>
 * @date    2009-2010
 */
#include "icalls.h"
#include "logging.h"

#pragma mark ----- Internal Calls -----

/**
 * @brief   Return whether the DEBUG level is enabled.
 * @return  TRUE is the level is enabled, FALSE otherwise.
 */
boolean_t icall_Monobjc_Logger_IsDebugEnabled(void) {
    return (monobjc_current_log_level >= MONOBJC_LOG_DEBUG);
}

/**
 * @brief   Return whether the INFO level is enabled.
 * @return  TRUE is the level is enabled, FALSE otherwise.
 */
boolean_t icall_Monobjc_Logger_IsInfoEnabled(void) {
    return (monobjc_current_log_level >= MONOBJC_LOG_INFO);
}

/**
 * @brief   Return whether the WARNING level is enabled.
 * @return  TRUE is the level is enabled, FALSE otherwise.
 */
boolean_t icall_Monobjc_Logger_IsWarningEnabled(void) {
    return (monobjc_current_log_level >= MONOBJC_LOG_WARN);
}

/**
 * @brief   Return whether the ERROR level is enabled.
 * @return  TRUE is the level is enabled, FALSE otherwise.
 */
boolean_t icall_Monobjc_Logger_IsErrorEnabled(void) {
    return (monobjc_current_log_level >= MONOBJC_LOG_ERROR);
}

/**
 * @brief   Output a DEBUG statement.
 * @param   source      The log source.
 * @param   message     The message.
 */
void icall_Monobjc_Logger_LogDebugMessage(MonoString *source, MonoString *message) {
    char *src = mono_string_to_utf8(source);
    char *str = mono_string_to_utf8(message);
    monobjc_log(MONOBJC_LOG_DEBUG, MONOBJC_DOMAIN_MANAGED, "[%s] - %s", src, str);
    g_free(str);
    g_free(src);
}

/**
 * @brief   Output an INFO statement.
 * @param   source      The log source.
 * @param   message     The message.
 */
void icall_Monobjc_Logger_LogInfoMessage(MonoString *source, MonoString *message) {
    char *src = mono_string_to_utf8(source);
    char *str = mono_string_to_utf8(message);
    monobjc_log(MONOBJC_LOG_INFO, MONOBJC_DOMAIN_MANAGED, "[%s] - %s", src, str);
    g_free(str);
    g_free(src);
}

/**
 * @brief   Output a WARNING statement.
 * @param   source      The log source.
 * @param   message     The message.
 */
void icall_Monobjc_Logger_LogWarningMessage(MonoString *source, MonoString *message) {
    char *src = mono_string_to_utf8(source);
    char *str = mono_string_to_utf8(message);
    monobjc_log(MONOBJC_LOG_WARN, MONOBJC_DOMAIN_MANAGED, "[%s] - %s", src, str);
    g_free(str);
    g_free(src);
}

/**
 * @brief   Output an ERROR statement.
 * @param   source      The log source.
 * @param   message     The message.
 */
void icall_Monobjc_Logger_LogErrorMessage(MonoString *source, MonoString *message) {
    char *src = mono_string_to_utf8(source);
    char *str = mono_string_to_utf8(message);
    monobjc_log(MONOBJC_LOG_ERROR, MONOBJC_DOMAIN_MANAGED, "[%s] - %s", src, str);
    g_free(str);
    g_free(src);
}
