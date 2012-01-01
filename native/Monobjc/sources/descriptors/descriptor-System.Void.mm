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
 * @file    descriptor-System.Void.mm
 * @brief   Contains the descriptor code to handle the System.Void type.
 * @author  Laurent Etiemble <laurent.etiemble@monobjc.net>
 * @date    2009-2012
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
