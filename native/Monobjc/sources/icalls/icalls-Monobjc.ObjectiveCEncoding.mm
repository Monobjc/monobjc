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
 * @file    icalls-Monobjc.ObjectiveCEncoding.mm
 * @brief   Contains the internal calls for the Monobjc.ObjectiveCEncoding type.
 * @author  Laurent Etiemble <laurent.etiemble@monobjc.net>
 * @date    2009-2010
 */
#include "constants.h"
#include "definitions.h"
#include "icalls.h"
#include "logging.h"
#include "marshal.h"

#pragma mark ----- Internal Calls -----

/**
 * @brief   Get the type Objective-C encoding.
 * @param   type    The type handle.
 */
MonoString *icall_Monobjc_ObjectiveCEncoding_GetTypeEncoding(MonoType *type) {
    // Check that type is a cached one
    MonobjcTypeDescriptor *type_descriptor = monobjc_get_descriptor(type, NULL);
    if (type_descriptor) {
        MonoString *str = mono_string_new(mono_domain_get(), type_descriptor->encoding);
        return str;
    }
    
    // For all other cases, raise an exception
    char *name = mono_type_get_name(type);
    char *msg;
    asprintf(&msg, STRING_CANNOT_COMPUTE_ENCODING, name);
    MonoException *exc = mono_exception_from_name_msg(monobjc_get_Monobjc_image(), MONOBJC, OBJECTIVE_C_EXCEPTION, msg);
    g_free(msg);
    g_free(name);
    
    mono_raise_exception(exc);
    
    return NULL;
}

/**
 * @brief   Get the type Objective-C size.
 * @param   type    The type handle.
 */
int32_t icall_Monobjc_ObjectiveCEncoding_GetTypeSize(MonoType *type) {
    // Check that type is a cached one
    MonobjcTypeDescriptor *type_descriptor = monobjc_get_descriptor(type, NULL);
    if (type_descriptor) {
        return MAX(type_descriptor->size, sizeof(void *));
    }
    
    // For all other cases, raise an exception
    char *name = mono_type_get_name(type);
    char *msg;
    asprintf(&msg, STRING_CANNOT_COMPUTE_SIZE, name);
    MonoException *exc = mono_exception_from_name_msg(monobjc_get_Monobjc_image(), MONOBJC, OBJECTIVE_C_EXCEPTION, msg);
    g_free(msg);
    g_free(name);
    
    mono_raise_exception(exc);
    
    return -1;
}
