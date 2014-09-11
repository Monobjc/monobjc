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
 * @file    descriptor-System.Void.mm
 * @brief   Contains the descriptor code to handle the System.Void type.
 * @author  Laurent Etiemble <laurent.etiemble@monobjc.net>
 * @date    2009-2014
 */
#include "logging.h"
#include "marshal.h"

/**
 * @brief   Does nothing.
 * @param   descriptor  The descriptor.
 * @param   native      TRUE if the storage zone has the native type width (direct access)
 *                      or FALSE if the zone is at least the size of pointer storage (as FFI requires it).
 * @return  NULL.
 */
static void *__alloc_native_storage_for_System_Void(MonobjcTypeDescriptor *descriptor, boolean_t native) {
    //LOG_DEBUG(MONOBJC_DOMAIN_MARSHALLING, "__alloc_native_storage_for_System_Void()");
    return NULL;
}

/**
 * @brief   Does nothing.
 * @param   descriptor  The descriptor.
 * @param   ptr         The pointer to the storage zone that contains the native object.
 * @param   native      TRUE if the storage zone has the native type width (direct access)
 *                      or FALSE if the zone is at least the size of pointer storage (as FFI requires it).
 * @return  NULL.
 */
static MonoObject *__marshal_from_native_for_System_Void(MonobjcTypeDescriptor *descriptor, void *ptr, boolean_t native) {
    //LOG_DEBUG(MONOBJC_DOMAIN_MARSHALLING, "__marshal_from_native_for_System_Void(%p)", ptr);
    return NULL;
}

/**
 * @brief   Does nothing.
 * @param   descriptor  The descriptor.
 * @param   obj         The managed object.
 * @param   ptr         The pointer to the storage zone that will contain the native object.
 * @param   native      TRUE if the storage zone has the native type width (direct access)
 *                      or FALSE if the zone is at least the size of pointer storage (as FFI requires it).
 *
 * @remark  This function does not free the storage zone. It is up to the caller to free it.
 */
static void __marshal_to_native_for_System_Void(MonobjcTypeDescriptor *descriptor, MonoObject *obj, void *ptr, boolean_t native) {
    //LOG_DEBUG(MONOBJC_DOMAIN_MARSHALLING, "__marshal_to_native_for_System_Void()");
}

/**
 * @brief   Does nothing.
 * @param   ptr         The pointer to the storage zone.
 */
static void __free_native_storage_for_System_Void(void *ptr) {
    //LOG_DEBUG(MONOBJC_DOMAIN_MARSHALLING, "__free_native_storage_for_System_Void(%p)", ptr);
}

MonobjcTypeDescriptor *monobjc_create_descriptor_for_System_Void() {
    LOG_DEBUG(MONOBJC_DOMAIN_MARSHALLING, "monobjc_create_descriptor_for_System_Void");
    
    // Allocate the descriptor structure
    MonobjcTypeDescriptor *descriptor = g_new0(MonobjcTypeDescriptor, 1);
    
    // Set the type to NULL (to ease the tests)
    descriptor->type = NULL;
    descriptor->boxed = 0;
    
    // Set the various marshaling functions
    descriptor->alloc_native_storage = __alloc_native_storage_for_System_Void;
    descriptor->marshal_from_native = __marshal_from_native_for_System_Void;
    descriptor->marshal_to_native = __marshal_to_native_for_System_Void;
    descriptor->free_native_storage = __free_native_storage_for_System_Void;
    
    // Set the Objective-C encoding
    descriptor->encoding = strdup("v");
    descriptor->size = sizeof(int32_t);
    descriptor->alignment = MIN(log2(descriptor->size), log2(sizeof(int32_t)));
    
    // Set the type to use with libffi
    descriptor->foreign_type = &ffi_type_void;
    
    return descriptor;
}
