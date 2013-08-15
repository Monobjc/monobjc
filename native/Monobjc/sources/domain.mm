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
 * @file    domain.mm
 * @brief   Contains the per-domain structure and functions.
 * @author  Laurent Etiemble <laurent.etiemble@monobjc.net>
 * @date    2009-2013
 */
#include "cache.h"
#include "domain.h"
#include "glib.h"
#include "logging.h"

/** @brief  List of the domain data. */
static GSList *__DOMAINS_DATA = NULL;

#pragma mark ----- Implementation -----

void monobjc_create_domain_data() {
    MonoDomain *domain = mono_domain_get();
    MonobjcDomainData *data = monobjc_get_domain_data(domain);
    if (data) {
        LOG_ERROR(MONOBJC_DOMAIN_GENERAL, "Cannot call monobjc_create_domain_data twice.");
    }
    data = g_new(MonobjcDomainData, 1);
    data->identifier = mono_domain_get_id(domain);
    LOG_INFO(MONOBJC_DOMAIN_GENERAL, "Creating Monobjc domain data for domain #%d", data->identifier);
    __DOMAINS_DATA = g_slist_append(__DOMAINS_DATA, data);
}

void monobjc_destroy_domain_data() {
    MonoDomain *domain = mono_domain_get();
    MonobjcDomainData *data = monobjc_get_domain_data(domain);
    if (!data) {
        LOG_ERROR(MONOBJC_DOMAIN_GENERAL, "Cannot call monobjc_destroy_domain_data on NULL data.");
    }
    else {
        LOG_INFO(MONOBJC_DOMAIN_GENERAL, "Destroying Monobjc domain data for domain #%d", data->identifier);
        __DOMAINS_DATA = g_slist_remove(__DOMAINS_DATA, data);
        g_free(data);
    }
}

MonobjcDomainData *monobjc_get_domain_data(MonoDomain *domain) {
    if (domain == NULL) {
        [NSException raise:NSInvalidArgumentException format:@"The domain is NULL. Verify that the thread has been attached."];
    }

    int32_t identifier = mono_domain_get_id(domain);
    GSList *current = __DOMAINS_DATA;
    while(current) {
        MonobjcDomainData *data = (MonobjcDomainData *) current->data;
        if (data->identifier == identifier) {
            return data;
        }
        current = g_slist_next(current);
    }
    return NULL;
}

void monobjc_remove_instance_in_domains(void *ptr) {
    GSList *current = __DOMAINS_DATA;
    while(current) {
        MonobjcDomainData *data = (MonobjcDomainData *) current->data;
        monobjc_cache_remove_instance_in_domain(ptr, data);
        current = g_slist_next(current);
    }
}
