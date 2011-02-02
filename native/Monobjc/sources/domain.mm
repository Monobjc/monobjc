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
 * @file    domain.mm
 * @brief   Contains the per-domain structure and functions.
 * @author  Laurent Etiemble <laurent.etiemble@monobjc.net>
 * @date    2009-2010
 */
#include "cache.h"
#include "domain.h"
#include "glib.h"
#include "logging.h"

/*! @brief  List of the domain data. */
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
    LOG_INFO(MONOBJC_DOMAIN_GENERAL, "Destroying Monobjc domain data for domain #%d", data->identifier);
    __DOMAINS_DATA = g_slist_remove(__DOMAINS_DATA, data);
    g_free(data);
}

MonobjcDomainData *monobjc_get_domain_data(MonoDomain *domain) {
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
