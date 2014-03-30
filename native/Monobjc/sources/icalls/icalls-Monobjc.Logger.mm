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
 * @file    icalls-Monobjc.Logger.mm
 * @brief   Contains the internal calls for the Monobjc.Id type.
 * @author  Laurent Etiemble <laurent.etiemble@monobjc.net>
 * @date    2009-2014
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
