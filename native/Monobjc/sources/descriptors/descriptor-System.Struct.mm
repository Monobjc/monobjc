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
 * @file    descriptor-System.Struct.mm
 * @brief   Contains the descriptor code to handle the System.Struct type.
 * @author  Laurent Etiemble <laurent.etiemble@monobjc.net>
 * @date    2009-2014
 */
#include "logging.h"
#include "marshal.h"

/**
 * @brief   Allocates a storage zone large enough to hold a marshalled System.Struct.
 * @param   descriptor  The descriptor.
 * @param   native      TRUE if the storage zone has the native type width (direct access)
 *                      or FALSE if the zone is at least the size of pointer storage (as FFI requires it).
 * @return  A pointer to the allocated storage.
 *
 * @remark  The storage zone will have the native size computed in the descriptor.
 */
static void *__alloc_native_storage_for_System_Struct(MonobjcTypeDescriptor *descriptor, boolean_t native) {
    //LOG_DEBUG(MONOBJC_DOMAIN_MARSHALLING, "__alloc_native_storage_for_System_Struct()");
    
    // Allocate a storage zone
    void *ptr = g_malloc(descriptor->size);
    
    return ptr;
}

/**
 * @brief   Marshal a native value into a System.Struct subclass object.
 * @param   descriptor  The descriptor.
 * @param   ptr         The pointer to the storage zone that contains the native object.
 * @param   native      TRUE if the storage zone has the native type width (direct access)
 *                      or FALSE if the zone is at least the size of pointer storage (as FFI requires it).
 * @return  A fully initialized System.Struct subclass object.
 *
 * @remark  This function only use the storage zone. It is up to the caller to free it.
 */
static MonoObject *__marshal_from_native_for_System_Struct(MonobjcTypeDescriptor *descriptor, void *ptr, boolean_t native) {
    //LOG_DEBUG(MONOBJC_DOMAIN_MARSHALLING, "__marshal_from_native_for_System_Struct(%p)", ptr);
    
    // Box the native value in a new structure
    MonoClass *klass = mono_type_get_class(descriptor->type);
    MonoObject *obj = mono_value_box(mono_domain_get(), klass, ptr);
    
    return obj;
}

/**
 * @brief   Marshal a System.Struct object to its native value.
 * @param   descriptor  The descriptor.
 * @param   obj         The managed object.
 * @param   ptr         The pointer to the storage zone that will contain the native object.
 * @param   native      TRUE if the storage zone has the native type width (direct access)
 *                      or FALSE if the zone is at least the size of pointer storage (as FFI requires it).
 *
 * @remark  This function does not free the storage zone. It is up to the caller to free it.
 */
static void __marshal_to_native_for_System_Struct(MonobjcTypeDescriptor *descriptor, MonoObject *obj, void *ptr, boolean_t native) {
    //LOG_DEBUG(MONOBJC_DOMAIN_MARSHALLING, "__marshal_to_native_for_System_Struct()");
    
    // Unbox the structure to the pointer
    void *value = mono_object_unbox(obj);
    memcpy(ptr, value, descriptor->size);
}

/**
 * @brief   Free the previously allocated storage zone.
 * @param   ptr         The pointer to the storage zone.
 */
static void __free_native_storage_for_System_Struct(void *ptr) {
    //LOG_DEBUG(MONOBJC_DOMAIN_MARSHALLING, "__free_native_storage_for_System_Struct(%p)", ptr);
    
    // Free the storage zone
    g_free(ptr);
}

MonobjcTypeDescriptor *monobjc_create_descriptor_for_System_Struct(MonoType *type, const char *encoding, int32_t size, ffi_type *foreign_type) {
    char *name = mono_type_get_name(type);
    LOG_DEBUG(MONOBJC_DOMAIN_MARSHALLING, "monobjc_create_descriptor_for_System_Struct(%s, %s, %d)", name, encoding, size);
    g_free(name);
    
    // Allocate the descriptor structure
    MonobjcTypeDescriptor *descriptor = g_new0(MonobjcTypeDescriptor, 1);
    
    // Set the type
    descriptor->type = type;
    descriptor->boxed = 1;

    // Set the various marshaling functions
    descriptor->alloc_native_storage = __alloc_native_storage_for_System_Struct;
    descriptor->marshal_from_native = __marshal_from_native_for_System_Struct;
    descriptor->marshal_to_native = __marshal_to_native_for_System_Struct;
    descriptor->free_native_storage = __free_native_storage_for_System_Struct;
    
    // Set the Objective-C encoding
    descriptor->encoding = strdup(encoding);
    descriptor->size = size;
    descriptor->alignment = MIN(log2(size), log2(sizeof(void *)));
    
    // Set the type to use with libffi
    descriptor->foreign_type = foreign_type;
    
    return descriptor;
}
