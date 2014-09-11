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
 * @file    icalls-Monobjc.ObjectiveCEncoding.mm
 * @brief   Contains the internal calls for the Monobjc.ObjectiveCEncoding type.
 * @author  Laurent Etiemble <laurent.etiemble@monobjc.net>
 * @date    2009-2014
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
        return type_descriptor->size;
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

/**
 * @brief   Get the natural alignement Objective-C size.
 * @param   type    The type handle.
 */
int32_t icall_Monobjc_ObjectiveCEncoding_GetTypeAlignment(MonoType *type) {
    // Check that type is a cached one
    MonobjcTypeDescriptor *type_descriptor = monobjc_get_descriptor(type, NULL);
    if (type_descriptor) {
        return type_descriptor->alignment;
	}
    
    // For all other cases, raise an exception
    char *name = mono_type_get_name(type);
    char *msg;
    asprintf(&msg, STRING_CANNOT_COMPUTE_ALIGNMENT, name);
    MonoException *exc = mono_exception_from_name_msg(monobjc_get_Monobjc_image(), MONOBJC, OBJECTIVE_C_EXCEPTION, msg);
    g_free(msg);
    g_free(name);
    
    mono_raise_exception(exc);
    
    return -1;
}
