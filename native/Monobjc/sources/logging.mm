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
 * @file    logging.mm
 * @brief   Contains definitions for logging.
 * @author  Laurent Etiemble <laurent.etiemble@monobjc.net>
 * @date    2009-2011
 */
#include "logging.h"

/*! @brief  Holds the current log level. */
MonobjcLogLevel monobjc_current_log_level = MONOBJC_LOG_ERROR;

/*! @brief  Holds the current domains to log. */
MonobjcLogDomain monobjc_current_log_domain = MONOBJC_DOMAIN_ALL;

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
        /*! @brief  Print the logging domains. */
        #define LOG_DOMAIN(SYMBOL, VALUE, KEY, STRING)    else if (strcmp(env_string, KEY) == 0) { monobjc_current_log_domain = SYMBOL; }
        #include "logging.def"
            
        else {
            monobjc_current_log_domain = MONOBJC_DOMAIN_ALL;
        }
    }
}

void monobjc_log(MonobjcLogLevel log_level, MonobjcLogDomain domain, const char *format, ...) {
    if (log_level <= monobjc_current_log_level && domain & monobjc_current_log_domain) {
        va_list args;
        va_start(args, format);
        switch (log_level) {
            case MONOBJC_LOG_DEBUG:
                printf("[DEBUG] "); vprintf(format, args); printf("\n");
                break;
            case MONOBJC_LOG_INFO:
                printf("[INFO ] "); vprintf(format, args); printf("\n");
                break;
            case MONOBJC_LOG_WARN:
                printf("[WARN ] "); vprintf(format, args); printf("\n");
                break;
            case MONOBJC_LOG_ERROR:
            default:
                printf("[ERROR] "); vprintf(format, args); printf("\n");
                break;
        }
        va_end(args);
    }
}

void monobjc_logv(MonobjcLogLevel log_level, MonobjcLogDomain domain, const char *format, va_list args) {
    if (log_level <= monobjc_current_log_level && domain & monobjc_current_log_domain) {
        switch (log_level) {
            case MONOBJC_LOG_DEBUG:
                printf("[DEBUG] "); vprintf(format, args); printf("\n");
                break;
            case MONOBJC_LOG_INFO:
                printf("[INFO ] "); vprintf(format, args); printf("\n");
                break;
            case MONOBJC_LOG_WARN:
                printf("[WARN ] "); vprintf(format, args); printf("\n");
                break;
            case MONOBJC_LOG_ERROR:
            default:
                printf("[ERROR] "); vprintf(format, args); printf("\n");
                break;
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
