// 
// This file is part of Monobjc, a .NET/Objective-C bridge
// Copyright (C) 2007-2012 - Laurent Etiemble
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
 * @file    support-mono.mm
 * @brief   Contains functions to retrieve Mono entities definitions.
 * @author  Laurent Etiemble <laurent.etiemble@monobjc.net>
 * @date    2009-2012
 */
#include "logging.h"
#include "support-mono.h"

#pragma mark ----- Implementation -----

MonoAssembly *monobjc_define_assembly(const char *name) {
    LOG_DEBUG(MONOBJC_DOMAIN_GENERAL, "monobjc_define_assembly '%s'", name);
    MonoAssembly *assembly = mono_domain_assembly_open(mono_domain_get(), name);
    if (!assembly) {
        LOG_ERROR(MONOBJC_DOMAIN_GENERAL, "Failed to get the definition for assembly '%s'.", assembly);
    }
    return assembly;
}

MonoImage *monobjc_define_image(MonoAssembly *assembly) {
    LOG_DEBUG(MONOBJC_DOMAIN_GENERAL, "monobjc_define_image");
    MonoImage *image = mono_assembly_get_image(assembly);
    if (!image) {
        LOG_ERROR(MONOBJC_DOMAIN_GENERAL, "Failed to get definition for an assembly.");
    }
    return image;
}

MonoClass *monobjc_define_class(MonoImage *image, const char *name_space, const char *name) {
    LOG_DEBUG(MONOBJC_DOMAIN_GENERAL, "monobjc_define_class '%s'", name);
    MonoClass *klass = mono_class_from_name(image, name_space, name);
	// Don't throw an error if the class is missing, because we rely on the fact that class may not be found
    return klass;
}

MonoMethod *monobjc_define_method(MonoClass *klass, const char *name, int param_count) {
    LOG_DEBUG(MONOBJC_DOMAIN_GENERAL, "monobjc_define_method '%s'", name);
    MonoMethod *method = mono_class_get_method_from_name(klass, name, param_count);
    if (!method) {
        LOG_ERROR(MONOBJC_DOMAIN_GENERAL, "Failed to get the definition for method '%s'.", name);
    }
    return method;
}

MonoMethod *monobjc_define_method_by_desc(MonoClass *klass, const char *name) {
    LOG_DEBUG(MONOBJC_DOMAIN_GENERAL, "monobjc_define_method_by_desc '%s'", name);
    MonoMethodDesc *desc = mono_method_desc_new(name, FALSE);
    if (!desc) {
        LOG_ERROR(MONOBJC_DOMAIN_GENERAL, "Failed to create the description for method '%s'.", name);
    }
    MonoMethod *method = mono_method_desc_search_in_class(desc, klass);
    mono_method_desc_free(desc);
    if (!method) {
        LOG_ERROR(MONOBJC_DOMAIN_GENERAL, "Failed to get the definition for method '%s'.", name);
    }
    return method;
}

MonoClassField *monobjc_define_field(MonoClass *klass, const char *name) {
    LOG_DEBUG(MONOBJC_DOMAIN_GENERAL, "monobjc_define_field '%s'", name);
    MonoClassField *field = mono_class_get_field_from_name(klass, name);
    if (!field) {
        LOG_ERROR(MONOBJC_DOMAIN_GENERAL, "Failed to get the definition for field '%s'.", name);
    }
    return field;
}

void *monobjc_define_internal_call(MonoClass *klass, const char *name, int param_count) {
    LOG_DEBUG(MONOBJC_DOMAIN_GENERAL, "monobjc_define_internal_call '%s'", name);
    MonoMethod *method = monobjc_define_method(klass, name, param_count);
    if (!method) {
        LOG_ERROR(MONOBJC_DOMAIN_GENERAL, "Failed to get the definition for method '%s'.", name);
    }
    void *ptr = mono_lookup_internal_call(method);
    if (!ptr) {
        LOG_ERROR(MONOBJC_DOMAIN_GENERAL, "Failed to get the internal call for method '%s'.", name);
    }
    return ptr;
}

void *monobjc_define_internal_call_by_desc(MonoClass *klass, const char *name) {
    LOG_DEBUG(MONOBJC_DOMAIN_GENERAL, "monobjc_define_internal_call_by_desc '%s'", name);
    MonoMethodDesc *desc = mono_method_desc_new(name, FALSE);
    if (!desc) {
        LOG_ERROR(MONOBJC_DOMAIN_GENERAL, "Failed to create the description for method '%s'.", name);
    }
    MonoMethod *method = mono_method_desc_search_in_class(desc, klass);
    mono_method_desc_free(desc);
    if (!method) {
        LOG_ERROR(MONOBJC_DOMAIN_GENERAL, "Failed to get the definition for method '%s'.", name);
    }
    void *ptr = mono_lookup_internal_call(method);
    if (!ptr) {
        LOG_ERROR(MONOBJC_DOMAIN_GENERAL, "Failed to get the internal call for method '%s'.", name);
    }
    return ptr;
}

MonoMethod *monobjc_get_wrapper_constructor(MonoClass *klass) {
    void *iter = NULL;
    MonoMethod *method = NULL;
    while(MonoMethod *m = mono_class_get_methods(klass, &iter)) {
        const char *name = mono_method_get_name(m);
        char *desc = mono_signature_get_desc(mono_method_signature(m), FALSE);
        if (strcmp(".ctor", name) == 0 &&
            strcmp("intptr", desc) == 0) {
            method = m;
            g_free(desc);
            break;
        }
        g_free(desc);
    }
    if (!method) {
        LOG_ERROR(MONOBJC_DOMAIN_GENERAL, "Failed to get the wrapper constructor for '%s'.", mono_class_get_name(klass));
    }
    return method;
}

/** @brief  CIL attribute for interfaces. */
#define TYPE_ATTRIBUTE_INTERFACE    0x00000020

boolean_t monobjc_type_is_interface(MonoType *type) {
    MonoClass *klass = mono_type_get_class(type);
    // The test may be incompleted...
    return ((mono_class_get_flags(klass) & TYPE_ATTRIBUTE_INTERFACE) == TYPE_ATTRIBUTE_INTERFACE);
}
