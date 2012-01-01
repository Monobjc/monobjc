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
/*!
 * \file    descriptor-System.Int64.mm
 * \brief   Contains the descriptor code to handle the System.Int64 type.
 * \author  Laurent Etiemble
 * \date    2009-2010
 */
#include "logging.h"
#include "marshal.h"

/*!
 * \brief   Allocates a storage zone large enough to hold a marshalled System.Int64.
 * \param   descriptor  The descriptor.
 * \param   native      TRUE if the storage zone has the native type width (direct access)
 *                      or FALSE if the zone is at least the size of pointer storage (as FFI requires it).
 * \return  A pointer to the allocated storage.
 *
 * \remark  The storage zone is at least the size of pointer storage, due to libffi requirement.
 */
static void *__alloc_native_storage_for_System_Int64(MonobjcTypeDescriptor *descriptor, boolean_t native) {
    //LOG_DEBUG(MONOBJC_DOMAIN_MARSHALLING, "__alloc_native_storage_for_System_Int64()");

    // Allocate a storage zone
    int64_t *ptr = g_new(int64_t, 1);
    return ptr;
}

/*!
 * \brief   Marshal a native value into a System.Int64 object.
 * \param   descriptor  The descriptor.
 * \param   ptr         The pointer to the storage zone that contains the native object.
 * \param   native      TRUE if the storage zone has the native type width (direct access)
 *                      or FALSE if the zone is at least the size of pointer storage (as FFI requires it).
 * \return  A fully initialized System.Int64 object.
 *
 * \remark  This function only use the storage zone. It is up to the caller to free it.
 *          Due to libffi requirement, the storage zone used is at least the size of pointer storage.
 *          This mean that smaller types are promoted before being boxed.
 */
static MonoObject *__marshal_from_native_for_System_Int64(MonobjcTypeDescriptor *descriptor, void *ptr, boolean_t native) {
    //LOG_DEBUG(MONOBJC_DOMAIN_MARSHALLING, "__marshal_from_native_for_System_Int64(%p)", ptr);

    // Box the value directly into a managed object
    MonoObject *obj = mono_value_box(mono_domain_get(), mono_get_int64_class(), ptr);
    return obj;
}

/*!
 * \brief   Marshal a System.Int64 object to its native value.
 * \param   descriptor  The descriptor.
 * \param   obj         The managed object.
 * \param   ptr         The pointer to the storage zone that will contain the native object.
 * \param   native      TRUE if the storage zone has the native type width (direct access)
 *                      or FALSE if the zone is at least the size of pointer storage (as FFI requires it).
 *
 * \remark  This function does not allocate the storage zone. It is up to the caller to allocate it and free it.
 */
static void __marshal_to_native_for_System_Int64(MonobjcTypeDescriptor *descriptor, MonoObject *obj, void *ptr, boolean_t native) {
    //LOG_DEBUG(MONOBJC_DOMAIN_MARSHALLING, "__marshal_to_native_for_System_Int64()");

    // Copy the value directly from the unboxed result
    int64_t value = *((int64_t *) mono_object_unbox(obj));
    *(int64_t *)ptr = value;
}

/*!
 * \brief   Free the previously allocated storage zone.
 * \param   ptr         The pointer to the storage zone.
 */
static void __free_native_storage_for_System_Int64(void *ptr) {
    //LOG_DEBUG(MONOBJC_DOMAIN_MARSHALLING, "__free_native_storage_for_System_Int64(%p)", ptr);

    // Free the storage zone
    g_free(ptr);
}

MonobjcTypeDescriptor *monobjc_create_descriptor_for_System_Int64() {
    LOG_DEBUG(MONOBJC_DOMAIN_MARSHALLING, "monobjc_create_descriptor_for_System_Int64");
    
    // Allocate the descriptor structure
    MonobjcTypeDescriptor *descriptor = g_new0(MonobjcTypeDescriptor, 1);
    
    // Set the type
    descriptor->type = mono_class_get_type(mono_get_int64_class());
    descriptor->boxed = 1;

    // Set the various marshaling functions
    descriptor->alloc_native_storage = __alloc_native_storage_for_System_Int64;
    descriptor->marshal_from_native = __marshal_from_native_for_System_Int64;
    descriptor->marshal_to_native = __marshal_to_native_for_System_Int64;
    descriptor->free_native_storage = __free_native_storage_for_System_Int64;

    // Set the Objective-C encoding
    descriptor->encoding = strdup("q");
    descriptor->size = sizeof(int64_t);
    descriptor->alignment = MIN(log2(descriptor->size), log2(sizeof(void *)));

    // Set the type to use with libffi
    descriptor->foreign_type = &ffi_type_sint64;

    return descriptor;
}
