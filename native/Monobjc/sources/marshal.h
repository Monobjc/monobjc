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
 * @file    marshal.h
 * @brief   Contains various marshal functions to convert managed objects.
 * @author  Laurent Etiemble <laurent.etiemble@monobjc.net>
 * @date    2009-2012
 */
#ifndef __MARSHAL_H__
#define __MARSHAL_H__

#include <ffi/ffi.h>

// Forward declaration.
struct MonobjcTypeDescriptor;

/**
 * @brief   Allocates a storage zone for the given descriptor.
 * @param   descriptor  The descriptor.
 * @param   native      TRUE if the storage zone has the native type width (direct access)
 *                      or FALSE if the zone is at least the size of pointer storage (as FFI requires it).
 * @return  A pointer to the allocated storage.
 *
 * @remark  It is up to the caller to free the storage zone.
 */
typedef void *(*ALLOC_NATIVE_STORAGE)(MonobjcTypeDescriptor *, boolean_t);

/**
 * @brief   Marshal a native value into a managed object.
 * @param   descriptor  The descriptor.
 * @param   ptr         The pointer to the storage zone that contains the native object.
 * @param   native      TRUE if the storage zone has the native type width (direct access)
 *                      or FALSE if the zone is at least the size of pointer storage (as FFI requires it).
 * @return  A fully initialized object, result of the convertsion of the native object.
 *
 * @remark  This function only use the storage zone. It is up to the caller to free it.
 */
typedef MonoObject *(*MARSHAL_FROM_NATIVE)(MonobjcTypeDescriptor *, void *, boolean_t);

/**
 * @brief   Marshal an object to its native value.
 * @param   descriptor  The descriptor.
 * @param   obj         The managed object.
 * @param   ptr         The pointer to the storage zone that will contain the native object.
 * @param   native      TRUE if the storage zone has the native type width (direct access)
 *                      or FALSE if the zone is at least the size of pointer storage (as FFI requires it).
 *
 * @remark  This function only use the storage zone. It is up to the caller to allocate and to free it.
 */
typedef void (*MARSHAL_TO_NATIVE)(MonobjcTypeDescriptor *, MonoObject *, void *, boolean_t);

/**
 * @brief   Free a previously allocated storage zone.
 * @param   ptr         The pointer to the storage zone.
 */
typedef void (*FREE_NATIVE_STORAGE)(void *);

/**
 * @brief   Describe a type for the messaging.
 *          It contains the Mono type, the marshalling function, the Objective-C encoding values
 *          and the FFI type to use.
 */
typedef struct MonobjcTypeDescriptor {
    /** @brief  The Mono type. */
    MonoType *type;
    /** @brief  Whether the type is boxed. */
    int32_t boxed;

    /** @brief  The allocation function. */
    ALLOC_NATIVE_STORAGE alloc_native_storage;
    /** @brief  The managed-to-native marshalling function. */
    MARSHAL_FROM_NATIVE marshal_from_native;
    /** @brief  The native-to-managed marshalling function. */
    MARSHAL_TO_NATIVE marshal_to_native;
    /** @brief  The destruction function. */
    FREE_NATIVE_STORAGE free_native_storage;

    /*! @brief  The Objective-C encoding. */
    char *encoding;
    /*! @brief  The Objective-C storage size. */
    int32_t size;
    /** @brief  The Objective-C alignment. */
    int32_t alignment;

    /** @brief  The FFI type. */
    ffi_type *foreign_type;
    
    /** @brief  A conversion method from the managed type to the real type. Only applicable to value_type. */
    MonoMethod *convert_from_managed;    
    /** @brief  A conversion method from the real type to the managed type. Only applicable to value_type. */
    MonoMethod *convert_to_managed;
} MonobjcTypeDescriptor;

#pragma mark ----- Descriptor functions -----

/**
 * @brief   Create the descriptors for primitive types, structures and instance objects.
 */
void monobjc_create_default_descriptors();

/**
 * @brief   Destroy the descriptors for primitive types, structures and instance objects.
 */
void monobjc_destroy_descriptors();

/**
 * @brief   Get a descriptor for a type.
 *          The descriptor can either be retrieved from the cache or created on-the-fly.
 * @param   type        The type to describe.
 * @param   encoding    The associated type encoding or NULL if not required.
 * @return  The descriptor for the given type.
 */
MonobjcTypeDescriptor *monobjc_get_descriptor(MonoType *type, char *encoding, bool canFail = false);

#pragma mark ----- Creator functions -----

/** @brief  Create the descriptor for "Monobjc.Block". */
MonobjcTypeDescriptor *monobjc_create_descriptor_for_Monobjc_Block();

/** @brief  Create the descriptor for "Monobjc.Class". */
MonobjcTypeDescriptor *monobjc_create_descriptor_for_Monobjc_Class();

/**
 * @brief   Create the descriptor for "Monobjc.Id" and its subclasses.
 * @param   type    The type to describe.
 */
MonobjcTypeDescriptor *monobjc_create_descriptor_for_Monobjc_Id(MonoType *type);

/** @brief  Create the descriptor for "System.Boolean". */
MonobjcTypeDescriptor *monobjc_create_descriptor_for_System_Boolean();

/** @brief  Create the descriptor for "System.Byte". */
MonobjcTypeDescriptor *monobjc_create_descriptor_for_System_Byte();

/** @brief  Create the descriptor for "System.Char". */
MonobjcTypeDescriptor *monobjc_create_descriptor_for_System_Char();

/** @brief  Create the descriptor for "System.Int16". */
MonobjcTypeDescriptor *monobjc_create_descriptor_for_System_Int16();

/** @brief  Create the descriptor for "System.Int32". */
MonobjcTypeDescriptor *monobjc_create_descriptor_for_System_Int32();

/** @brief  Create the descriptor for "System.Int64". */
MonobjcTypeDescriptor *monobjc_create_descriptor_for_System_Int64();

/** @brief  Create the descriptor for "System.IntPtr". */
MonobjcTypeDescriptor *monobjc_create_descriptor_for_System_IntPtr();

/** @brief  Create the descriptor for "System.SByte". */
MonobjcTypeDescriptor *monobjc_create_descriptor_for_System_SByte();

/** @brief  Create the descriptor for "System.String". */
MonobjcTypeDescriptor *monobjc_create_descriptor_for_System_String();

/**
 * @brief   Create the descriptor for "System.Struct" and its subclasses.
 * @param   type            The type to describe.
 * @param   encoding        The Objective-C encoding.
 * @param   size            The storage size.
 * @param   foreign_type    The FFI type.
 */
MonobjcTypeDescriptor *monobjc_create_descriptor_for_System_Struct(MonoType *type, const char *encoding, int32_t size, ffi_type *foreign_type);

/** @brief  Create the descriptor for "System.UInt16". */
MonobjcTypeDescriptor *monobjc_create_descriptor_for_System_UInt16();

/** @brief  Create the descriptor for "System.UInt32". */
MonobjcTypeDescriptor *monobjc_create_descriptor_for_System_UInt32();

/** @brief  Create the descriptor for "System.UInt64". */
MonobjcTypeDescriptor *monobjc_create_descriptor_for_System_UInt64();

/** @brief  Create the descriptor for "System.Void". */
MonobjcTypeDescriptor *monobjc_create_descriptor_for_System_Void();

#endif // __MARSHAL_H__
