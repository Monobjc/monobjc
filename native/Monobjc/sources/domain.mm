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
 * @file    domain.mm
 * @brief   Contains the per-domain structure and functions.
 * @author  Laurent Etiemble <laurent.etiemble@monobjc.net>
 * @date    2009-2014
 */
#include "cache.h"
#include "constants.h"
#include "definitions.h"
#include "domain.h"
#include "glib.h"
#include "logging.h"

pthread_mutex_t __DOMAINS_MUTEX;

/** @brief  List of the domain data. */
static GSList *__DOMAINS_DATA = NULL;

/** @brief  True if domain tokens can be auto-assigned. */
static boolean_t __enable_auto_domain_tokens = FALSE;

/** @brief  True if the caller can still change the auto domain token option. */
static boolean_t __enable_auto_domain_tokens_mutable = TRUE;

/** @brief  The domain counter for default token assignment. */
static volatile int32_t __domain_token_counter = 0;

/** 
 * @brief  True if at least one domain had an empty domain token and
 *         was not mangling names. There can be only one. Never turn
 *         off the flag once activated.
 */
static boolean_t __pass_through_domain_actived;

#pragma mark ----- Implementation -----

void monobjc_create_domain_data(const char *domain_token) {
    MonoDomain *domain = mono_domain_get();
    MonobjcDomainData *data = monobjc_get_domain_data(domain);
    if (data) {
        // This is fatal and cannot be handled. Raise an exception.
        [NSException raise:[NSString stringWithUTF8String:OBJECTIVE_C_EXCEPTION] format:@"%@ Domain #%d - Thread #%u", @"Cannot call monobjc_create_domain_data twice.", data->identifier, MACH_THREAD_ID];
    }
    
    // Verify that the domain is eligible
    char *token = NULL;
    if (!domain_token) {
        if (__pass_through_domain_actived) {
            if (__enable_auto_domain_tokens) {
                // Increment the global counter (protected by the domain lock)
                __domain_token_counter++;
                
                // Create a string with the count
                CFMutableStringRef uuid = CFStringCreateMutable(kCFAllocatorDefault, 0);
                CFStringAppendFormat(uuid, NULL, CFSTR("%d"), __domain_token_counter);
                
                // Get the final token
                CFIndex length = CFStringGetLength(uuid);
                token = g_new0(char, length + 1);
                CFStringGetCString(uuid, token, length + 1, kCFStringEncodingASCII);
                CFRelease(uuid);
            } else {
                [NSException raise:[NSString stringWithUTF8String:OBJECTIVE_C_EXCEPTION] format:@"%@ Domain #%d - Thread #%u", @"Cannot bootstrap a second domain without a token for name mangling because a pass through domain already exists and auto domain tokens are disabled.", mono_domain_get_id(domain), MACH_THREAD_ID];
            }
        } else {
            __pass_through_domain_actived = TRUE;
        }
    } else {
        token = g_strdup(domain_token);
    }
    
    // A domain has been created, don't allow the setting to change
    __enable_auto_domain_tokens_mutable = FALSE;
    
    // Create the domain data
    data = g_new(MonobjcDomainData, 1);
    data->identifier = mono_domain_get_id(domain);
    data->token = token;
    
    LOG_INFO(MONOBJC_DOMAIN_GENERAL, "Creating Monobjc domain data for domain #%d with token '%s' from thread #%u", data->identifier, data->token == NULL ? "none" : data->token, MACH_THREAD_ID);
    __DOMAINS_DATA = g_slist_append(__DOMAINS_DATA, data);
}

void monobjc_destroy_domain_data() {
    MonoDomain *domain = mono_domain_get();
    MonobjcDomainData *data = monobjc_get_domain_data(domain);
    if (!data) {
        // This is fatal and cannot be handled. Raise an exception.
        [NSException raise:[NSString stringWithUTF8String:OBJECTIVE_C_EXCEPTION] format:@"%@ Domain #%d - Thread #%u", @"Cannot call monobjc_destroy_domain_data on NULL data.", mono_domain_get_id(domain), MACH_THREAD_ID];
    } else {
        LOG_INFO(MONOBJC_DOMAIN_GENERAL, "Destroying Monobjc domain data for domain #%d from thread #%u", data->identifier, MACH_THREAD_ID);
        __DOMAINS_DATA = g_slist_remove(__DOMAINS_DATA, data);
        if (!__DOMAINS_DATA) {
            __enable_auto_domain_tokens_mutable = TRUE;
        }
        g_free(data->token);
        g_free(data);
    }
}

MonobjcDomainData *monobjc_get_domain_data(MonoDomain *domain) {
    if (domain == NULL) {
        [NSException raise:NSInvalidArgumentException format:@"The domain is NULL. Verify that the thread has been attached."];
    }

    int32_t identifier = mono_domain_get_id(domain);
    LOCK_DOMAINS();
    GSList *current = __DOMAINS_DATA;
    while(current) {
        MonobjcDomainData *data = (MonobjcDomainData *) current->data;
        if (data->identifier == identifier) {
            UNLOCK_DOMAINS();
            return data;
        }
        current = g_slist_next(current);
    }
    UNLOCK_DOMAINS();
    return NULL;
}

void monobjc_remove_instance_in_domains(void *ptr) {
    LOCK_DOMAINS();
    GSList *current = __DOMAINS_DATA;
    while(current) {
        MonobjcDomainData *data = (MonobjcDomainData *) current->data;
        monobjc_mutex_lock(&data->INSTANCES_MUTEX);
        monobjc_cache_remove_instance_in_domain(ptr, data);
        monobjc_mutex_unlock(&data->INSTANCES_MUTEX);
        current = g_slist_next(current);
    }
    UNLOCK_DOMAINS();
}

void monobjc_enable_auto_domain_tokens() {
    if (__enable_auto_domain_tokens) {
        return;
    }
    
    if (!__enable_auto_domain_tokens_mutable) {
        [NSException raise:[NSString stringWithUTF8String:OBJECTIVE_C_EXCEPTION] format:@"%@", @"Cannot enable auto domain tokens because a domain has already been initialized."];
    }
    __enable_auto_domain_tokens = TRUE;
}
