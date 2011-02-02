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
 * @file    descriptor-Monobjc.Class.mm
 * @brief   Contains the descriptor code to handle the Monobjc.Class type.
 * @author  Laurent Etiemble <laurent.etiemble@monobjc.net>
 * @date    2009-2010
 */
#include "definitions.h"
#include "icalls.h"
#include "logging.h"
#include "marshal.h"

/**
 * @brief   Allocates a storage zone large enough to hold a marshalled Monobjc.Class instance.
 * @param   descriptor  The descriptor.
 * @param   native      TRUE if the storage zone has the native type width (direct access)
 *                      or FALSE if the zone is at least the size of pointer storage (as FFI requires it).
 * @return  A pointer to the allocated storage.
 */
static void *__alloc_native_storage_for_Monobjc_Class(MonobjcTypeDescriptor *descriptor, boolean_t native) {
    //LOG_DEBUG(MONOBJC_DOMAIN_MARSHALLING, "__alloc_native_storage_for_Monobjc_Class()");
    
    // Allocate a storage zone
    void **ptr = g_new(void *, 1);
    
    return ptr;
}

/**
 * @brief   Marshal a native value into a Monobjc.Class instance.
 * @param   descriptor  The descriptor.
 * @param   ptr         The pointer to the storage zone that contains the native object.
 * @param   native      TRUE if the storage zone has the native type width (direct access)
 *                      or FALSE if the zone is at least the size of pointer storage (as FFI requires it).
 * @return  A fully initialized Monobjc.Class instance.
 *
 * @remark  This function only use the storage zone. It is up to the caller to free it.
 */
static MonoObject *__marshal_from_native_for_Monobjc_Class(MonobjcTypeDescriptor *descriptor, void *ptr, boolean_t native) {
    //LOG_DEBUG(MONOBJC_DOMAIN_MARSHALLING, "__marshal_from_native_for_Monobjc_Class(%p)", ptr);
    
    // Fetch the managed wrapper for the given pointer
    void *value = *(void **)ptr;
    MonoObject *obj = icall_Monobjc_ObjectiveCRuntime_GetInstance(descriptor->type, value, FALSE);
    
    return obj;
}

/**
 * @brief   Marshal a Monobjc.Class object to its native value.
 * @param   descriptor  The descriptor.
 * @param   obj         The managed object.
 * @param   ptr         The pointer to the storage zone that will contain the native object.
 * @param   native      TRUE if the storage zone has the native type width (direct access)
 *                      or FALSE if the zone is at least the size of pointer storage (as FFI requires it).
 *
 * @remark  This function does not free the storage zone. It is up to the caller to free it.
 */
static void __marshal_to_native_for_Monobjc_Class(MonobjcTypeDescriptor *descriptor, MonoObject *obj, void *ptr, boolean_t native) {
    //LOG_DEBUG(MONOBJC_DOMAIN_MARSHALLING, "__marshal_to_native_for_Monobjc_Class()");
    
    // Get the field value directly
    void *value;
    mono_field_get_value(obj, monobjc_get_Monobjc_Id_pointer_field(), &value);
    *(void **)ptr = value;
}

/**
 * @brief   Free the previously allocated storage zone.
 * @param   ptr         The pointer to the storage zone.
 */
static void __free_native_storage_for_Monobjc_Class(void *ptr) {
    //LOG_DEBUG(MONOBJC_DOMAIN_MARSHALLING, "__free_native_storage_for_Monobjc_Class(%p)", ptr);

    // Free the storage zone
    g_free(ptr);
}    

MonobjcTypeDescriptor *monobjc_create_descriptor_for_Monobjc_Class() {
    LOG_DEBUG(MONOBJC_DOMAIN_MARSHALLING, "monobjc_create_descriptor_for_Monobjc_Class");
    
    // Allocate the descriptor structure
    MonobjcTypeDescriptor *descriptor = g_new0(MonobjcTypeDescriptor, 1);
    
    // Set the type
    descriptor->type = monobjc_get_Monobjc_Class_type();
    descriptor->boxed = 0;

    // Set the various marshaling functions
    descriptor->alloc_native_storage = __alloc_native_storage_for_Monobjc_Class;
    descriptor->marshal_from_native = __marshal_from_native_for_Monobjc_Class;
    descriptor->marshal_to_native = __marshal_to_native_for_Monobjc_Class;
    descriptor->free_native_storage = __free_native_storage_for_Monobjc_Class;
    
    // Set the Objective-C encoding
    descriptor->encoding = strdup("#");
    descriptor->size = sizeof(void *);
    descriptor->alignment = log2(sizeof(void *));

    // Set the type to use with libffi
    descriptor->foreign_type = &ffi_type_pointer;
    
    return descriptor;
}
