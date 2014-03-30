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
 * @file    logging.mm
 * @brief   Contains definitions for logging.
 * @author  Laurent Etiemble <laurent.etiemble@monobjc.net>
 * @date    2009-2014
 */
#include <asl.h>
#include <pthread.h>
#include "logging.h"

/** @brief  Holds the current log level. */
MonobjcLogLevel monobjc_current_log_level = MONOBJC_LOG_ERROR;

/** @brief  Holds the current domains to log. */
MonobjcLogDomain monobjc_current_log_domain = MONOBJC_DOMAIN_ALL;

/** @brief  Holds the ASL message for logging. */
aslmsg monobjc_aslmsg;

#pragma mark ----- Implementation -----

void monobjc_setup_logging() {
    char *env_string;
    
    // Check if a custom log level has been specified
    env_string = getenv("MONOBJC_LOG_LEVEL");
    if (env_string) {
        if (strcmp(env_string, "error") == 0) {
            monobjc_current_log_level = MONOBJC_LOG_ERROR;
        } else if (strcmp(env_string, "warn") == 0) {
            monobjc_current_log_level = MONOBJC_LOG_WARN;
        } else if (strcmp(env_string, "info") == 0) {
            monobjc_current_log_level = MONOBJC_LOG_INFO;
        } else if (strcmp(env_string, "debug") == 0) {
            monobjc_current_log_level = MONOBJC_LOG_DEBUG;
        } else {
            monobjc_current_log_level = MONOBJC_LOG_ERROR;
        }
    }
    
    // Check if custom domains have been specified
    env_string = getenv("MONOBJC_LOG_DOMAIN");
    if (env_string) {
        if (strcmp(env_string, "all") == 0) {
            monobjc_current_log_domain = MONOBJC_DOMAIN_ALL;
        }
        
        #undef LOG_DOMAIN
        /** @brief  Print the logging domains. */
        #define LOG_DOMAIN(SYMBOL, VALUE, KEY, STRING)    else if (strcmp(env_string, KEY) == 0) { monobjc_current_log_domain = SYMBOL; }
        #include "logging.def"
            
        else {
            monobjc_current_log_domain = MONOBJC_DOMAIN_ALL;
        }
    }
    
    // Create a new ASL message to log to both syslog and stderr
    // See http://developer.apple.com/library/mac/documentation/Darwin/Reference/ManPages/man3/asl.3.html
    // See http://stackoverflow.com/questions/14201699/how-to-get-asl-log-to-appear-in-the-ios-system-console-output
    monobjc_aslmsg = asl_new(ASL_TYPE_MSG);
    asl_set(monobjc_aslmsg, ASL_KEY_READ_UID, "-1");
    asl_add_log_file(NULL, STDERR_FILENO);
}

void monobjc_log(MonobjcLogLevel log_level, MonobjcLogDomain domain, const char *format, ...) {
    if (log_level <= monobjc_current_log_level && domain & monobjc_current_log_domain) {
        va_list args;
        va_start(args, format);
        
        int level;
        switch (log_level) {
            case MONOBJC_LOG_DEBUG:
                level = ASL_LEVEL_NOTICE;
                break;
            case MONOBJC_LOG_INFO:
                level = ASL_LEVEL_NOTICE;
                break;
            case MONOBJC_LOG_WARN:
                level = ASL_LEVEL_WARNING;
                break;
            case MONOBJC_LOG_ERROR:
            default:
                level = ASL_LEVEL_ERR;
                break;
        }
        
        char *msg;
        vasprintf(&msg, format, args);
        if (msg != NULL) {
            int domain_id = 0;
            MonoDomain *domain = mono_domain_get();
            if (domain != NULL) {
                domain_id = mono_domain_get_id(domain);
            }
            asl_log(NULL, monobjc_aslmsg, level, "[Domain #%d - Thread #%u] %s", domain_id, MACH_THREAD_ID, msg);
            free(msg);
        }
        
        va_end(args);
    }
}

void monobjc_logv(MonobjcLogLevel log_level, MonobjcLogDomain domain, const char *format, va_list args) {
    if (log_level <= monobjc_current_log_level && domain & monobjc_current_log_domain) {
        int level;
        switch (log_level) {
            case MONOBJC_LOG_DEBUG:
                level = ASL_LEVEL_NOTICE;
                break;
            case MONOBJC_LOG_INFO:
                level = ASL_LEVEL_NOTICE;
                break;
            case MONOBJC_LOG_WARN:
                level = ASL_LEVEL_WARNING;
                break;
            case MONOBJC_LOG_ERROR:
            default:
                level = ASL_LEVEL_ERR;
                break;
        }
        
        char *msg;
        vasprintf(&msg, format, args);
        if (msg != NULL) {
            int domain_id = 0;
            MonoDomain *domain = mono_domain_get();
            if (domain != NULL) {
                domain_id = mono_domain_get_id(domain);
            }
            asl_log(NULL, monobjc_aslmsg, level, "[Domain #%d - Thread #%u] %s", domain_id, MACH_THREAD_ID, msg);
            free(msg);
        }
    }
}

void monobjc_dump_memory(void *ptr, int size) {
    LOG_DEBUG(MONOBJC_DOMAIN_MARSHALLING, "Dumping memory at %p", ptr);

    GString *output = NULL;
    char *str = NULL;
    uint8_t *buffer = (uint8_t *)ptr;
    for(int i = 0; i < size; i++) {
        if ((i % 4) == 0) {
            if (output) {
                str = g_string_free(output, FALSE);
                LOG_DEBUG(MONOBJC_DOMAIN_MARSHALLING, str);
                g_free(str);
            }
            output = g_string_new("");
            g_string_append_printf(output, "%p => ", buffer);
        }
        g_string_append_printf(output, "0x%x ", *buffer);
        buffer++;
    }
    
    str = g_string_free(output, FALSE);
    LOG_DEBUG(MONOBJC_DOMAIN_MARSHALLING, str);
    g_free(str);
}
