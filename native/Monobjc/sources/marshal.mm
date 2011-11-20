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
 * @file    marshal.mm
 * @brief   Contains various marshal functions to convert managed objects.
 * @author  Laurent Etiemble <laurent.etiemble@monobjc.net>
 * @date    2009-2011
 */
#include "cache.h"
#include "constants.h"
#include "definitions.h"
#include "domain.h"
#include "logging.h"
#include "marshal.h"
#include "support-objc.h"
#include "support-os.h"

/**
 * @brief   Destruction callback for the descriptor.
 * @param   value       The descriptor to destroy.
 */
static void __destroy_descriptor(void *value) {
    MonobjcTypeDescriptor *descriptor = (MonobjcTypeDescriptor *) value;
    
    LOG_DEBUG(MONOBJC_DOMAIN_MARSHALLING, "Destroying descriptor '%s'", descriptor->encoding);
    
    // Free the type encoding
    g_free(descriptor->encoding);
    
    // Free the ffi_type if it was created
    ffi_type *foreign_type = descriptor->foreign_type;
    if (foreign_type->type == FFI_TYPE_STRUCT) {
        g_free(foreign_type->elements);
        g_free(foreign_type);
    }
    
    // Free the structure
    g_free(descriptor);
}

/**
 * @brief   Map a descriptor to a type.
 * @param   type        The type to marshal.
 * @param   encoding    The associated type encoding or NULL if not required.
 * @param   descriptor  The associated descriptor.
 */
void __map_descriptor(MonoType *type, MonobjcTypeDescriptor *descriptor) {
    char *name = mono_type_get_name(type);
    LOG_DEBUG(MONOBJC_DOMAIN_MARSHALLING, "Mapping descriptor for %s", name);
    g_hash_table_insert(__DESCRIPTORS_HASHTABLE, strdup(name), descriptor);
    g_free(name);
}

/**
 * @brief   Lookup the type in the descriptor cache.
 * @param   type   The type to describe.
 * @param   encoding    The associated type encoding or NULL if not required.
 * @return  The descriptor for the given type.
 */
MonobjcTypeDescriptor *__lookup_descriptor(MonoType *type) {
    char *name = mono_type_get_name(type);
    LOG_DEBUG(MONOBJC_DOMAIN_MARSHALLING, "Lookup descriptor for %s", name);
    MonobjcTypeDescriptor *descriptor = NULL;
    descriptor = (MonobjcTypeDescriptor *) g_hash_table_lookup(__DESCRIPTORS_HASHTABLE, name);
    g_free(name);
    return descriptor;
}

/**
 * @brief   Make a copy of the descriptor.
 * @param   descriptor  The descriptor to copy.
 * @return  The descriptor for the given type.
 */
MonobjcTypeDescriptor *__copy_descriptor(MonobjcTypeDescriptor *descriptor) {
    MonobjcTypeDescriptor *copy = g_new0(MonobjcTypeDescriptor, 1);
    
    copy->type = descriptor->type;
    copy->boxed = descriptor->boxed;
    
    copy->alloc_native_storage = descriptor->alloc_native_storage;
    copy->marshal_from_native = descriptor->marshal_from_native;
    copy->marshal_to_native = descriptor->marshal_to_native;
    copy->free_native_storage = descriptor->free_native_storage;
    
    copy->encoding = strdup(descriptor->encoding);
    copy->size = descriptor->size;
    copy->alignment = descriptor->alignment;
    
    // Make a deep copy of the foreign type
    ffi_type *foreign_type = descriptor->foreign_type;
    if (foreign_type->type == FFI_TYPE_STRUCT) {
        // Create a copy of the structure type.
        copy->foreign_type = g_new(ffi_type, 1);
        copy->foreign_type->alignment = 0;
        copy->foreign_type->elements = NULL;
        copy->foreign_type->size = 0;
        copy->foreign_type->type = FFI_TYPE_STRUCT;
        
        // Iterate to get the field count
        // when the last element is null
        ffi_type **current = foreign_type->elements;
        uint32_t field_count = 0;
        while (*current) {
            current++;
            field_count++;
        }
        
        // Copy the structure's elements
        copy->foreign_type->elements = g_new0(ffi_type *, field_count + 1);
        memcpy(copy->foreign_type->elements, foreign_type->elements, field_count * sizeof(ffi_type *));
    } else {
        copy->foreign_type = foreign_type;
    }
    
    copy->convert_from_managed = descriptor->convert_from_managed;
    copy->convert_to_managed = descriptor->convert_to_managed;
    
    return copy;
}

#pragma mark ----- Implementation -----

void monobjc_create_default_descriptors() {
    LOG_INFO(MONOBJC_DOMAIN_GENERAL, "Create cache for descriptors");
    MONOBJC_MUTEX_INIT(&__DESCRIPTORS_MUTEX, TRUE);
    __DESCRIPTORS_HASHTABLE = g_hash_table_new_full(g_str_hash, g_str_equal, g_free, __destroy_descriptor);

    // Create marshalers for Monobjc types
    if (monobjc_get_Monobjc_Block_class() && monobjc_are_blocks_available()) {
        __map_descriptor(monobjc_get_Monobjc_Block_type(),          monobjc_create_descriptor_for_Monobjc_Block());
    }
    __map_descriptor(monobjc_get_Monobjc_Class_type(),              monobjc_create_descriptor_for_Monobjc_Class());
    __map_descriptor(monobjc_get_Monobjc_Id_type(),                 monobjc_create_descriptor_for_Monobjc_Id(monobjc_get_Monobjc_Id_type()));
    
    // Create marshaler for System types
    __map_descriptor(mono_class_get_type(mono_get_boolean_class()), monobjc_create_descriptor_for_System_Boolean());
    __map_descriptor(mono_class_get_type(mono_get_byte_class()),    monobjc_create_descriptor_for_System_Byte());
    __map_descriptor(mono_class_get_type(mono_get_char_class()),    monobjc_create_descriptor_for_System_Char());
    __map_descriptor(mono_class_get_type(mono_get_int16_class()),   monobjc_create_descriptor_for_System_Int16());
    __map_descriptor(mono_class_get_type(mono_get_int32_class()),   monobjc_create_descriptor_for_System_Int32());
    __map_descriptor(mono_class_get_type(mono_get_int64_class()),   monobjc_create_descriptor_for_System_Int64());
    __map_descriptor(mono_class_get_type(mono_get_intptr_class()),  monobjc_create_descriptor_for_System_IntPtr());
    __map_descriptor(mono_class_get_type(mono_get_sbyte_class()),   monobjc_create_descriptor_for_System_SByte());
    __map_descriptor(mono_class_get_type(mono_get_string_class()),  monobjc_create_descriptor_for_System_String());
    __map_descriptor(mono_class_get_type(mono_get_uint16_class()),  monobjc_create_descriptor_for_System_UInt16());
    __map_descriptor(mono_class_get_type(mono_get_uint32_class()),  monobjc_create_descriptor_for_System_UInt32());
    __map_descriptor(mono_class_get_type(mono_get_uint64_class()),  monobjc_create_descriptor_for_System_UInt64());
    __map_descriptor(mono_class_get_type(mono_get_void_class()),    monobjc_create_descriptor_for_System_Void());
    
    // Create marshalers for floating-point types
    __map_descriptor(mono_class_get_type(mono_get_double_class()),  monobjc_create_descriptor_for_System_Struct(mono_class_get_type(mono_get_double_class()), "d", sizeof(gdouble), &ffi_type_double));
    __map_descriptor(mono_class_get_type(mono_get_single_class()),  monobjc_create_descriptor_for_System_Struct(mono_class_get_type(mono_get_single_class()), "f", sizeof(gfloat), &ffi_type_float));
}

void monobjc_destroy_descriptors() {
    LOG_INFO(MONOBJC_DOMAIN_GENERAL, "Destroy cache for descriptors");
    g_hash_table_destroy(__DESCRIPTORS_HASHTABLE);
    MONOBJC_MUTEX_FREE(&__DESCRIPTORS_MUTEX);
}

MonobjcTypeDescriptor *monobjc_get_descriptor(MonoType *type, char *encoding, bool canFail) {
    char *name = mono_type_get_name(type);
    LOG_DEBUG(MONOBJC_DOMAIN_MARSHALLING, "Get descriptor for %s", name);
    
    // Storage for the exception
    MonoException *exc = NULL;
    
    LOCK_DESCRIPTORS();
    
    // Check if descriptor is cached
    MonobjcTypeDescriptor *descriptor = __lookup_descriptor(type);
    if (!descriptor) {
        LOG_DEBUG(MONOBJC_DOMAIN_MARSHALLING, "Creating descriptor for %s", name);
        
        // Get the class of the type
        MonoClass *klass = mono_type_get_class(type);
        
        // Case: By-ref type
        if (mono_type_is_byref(type)) {
            // The descriptor for a by-ref type is a pointer one
            MonoType *referenced_type = mono_class_get_type(mono_get_intptr_class());
            MonobjcTypeDescriptor *referenced_descriptor = monobjc_get_descriptor(referenced_type, NULL);
            
            // Copy the descriptor
            descriptor = __copy_descriptor(referenced_descriptor);
            
            // Store the descriptor
            __map_descriptor(type, descriptor);
        }
        // Case: Enumerations
        else if (mono_class_is_enum(klass)) {
            void *args[2];
            bool is64bits = IS64BITS;
            args[0] = mono_type_get_object(mono_domain_get(), type);
            args[1] = &is64bits;
            
            // The encoding for an enum is the one for its real type
            MonoObject *obj = mono_runtime_invoke(monobjc_get_Monobjc_TypeHelper_GetUnderlyingTypeHandle_method(), NULL, args, NULL);
            MonoType *underlyingType = *(MonoType **) mono_object_unbox(obj);
            
            // Get the descriptor
            MonobjcTypeDescriptor *underlying_descriptor = monobjc_get_descriptor(underlyingType, NULL);
            
            // Copy the descriptor
            descriptor = __copy_descriptor(underlying_descriptor);
            
            // Retrieve the converter methods
			args[0] = mono_type_get_object(mono_domain_get(), type);
			args[1] = mono_type_get_object(mono_domain_get(), underlyingType);
			obj = mono_runtime_invoke(monobjc_get_Monobjc_TypeHelper_GetConverterHandle_method(), NULL, args, NULL);
			descriptor->convert_from_managed = *(MonoMethod **) mono_object_unbox(obj);
			args[0] = mono_type_get_object(mono_domain_get(), underlyingType);
			args[1] = mono_type_get_object(mono_domain_get(), type);
			obj = mono_runtime_invoke(monobjc_get_Monobjc_TypeHelper_GetConverterHandle_method(), NULL, args, NULL);
			descriptor->convert_to_managed = *(MonoMethod **) mono_object_unbox(obj);
            
            // Store the descriptor
            __map_descriptor(type, descriptor);
        }
        // Case: Structures
        else if (mono_type_get_type(type) == MONO_TYPE_VALUETYPE) {
            void *args[2];
            bool is64bits = IS64BITS;
            args[0] = mono_type_get_object(mono_domain_get(), type);
            args[1] = &is64bits;
            
            // The encoding for a struct is the one for its real type (as ti may depend on the bitness of the platform)
            MonoObject *obj = mono_runtime_invoke(monobjc_get_Monobjc_TypeHelper_GetUnderlyingTypeHandle_method(), NULL, args, NULL);
            MonoType *underlyingType = *(MonoType **) mono_object_unbox(obj);
            
            // Get the class of the real type
            klass = mono_type_get_class(underlyingType);            
            
            // Get the underlying descriptor
            MonobjcTypeDescriptor *underlying_descriptor = __lookup_descriptor(underlyingType);
            if (underlying_descriptor) {
                // Copy the descriptor
                descriptor = __copy_descriptor(underlying_descriptor);
                
                // Store the descriptor
                __map_descriptor(type, descriptor);
            } else {
                // Set the encoding prologue
                GString *buffer = g_string_new("{");
                g_string_append_printf(buffer, "%s=", mono_class_get_name(klass));
                
                void *iter;
                MonoClassField *field;
                
                // Iterate over the fields to count the public non-static ones
                iter = NULL;
                uint32_t field_count = 0;
                while((field = mono_class_get_fields(klass, &iter))) {
                    uint32_t flags = mono_field_get_flags(field);
                    if ((flags & MONO_FIELD_ATTR_PUBLIC) == MONO_FIELD_ATTR_PUBLIC &&
                        (flags & MONO_FIELD_ATTR_STATIC) == 0) {
                        field_count++;
                    }
                }
                
                // Allocate the foreign type for the structure
                ffi_type *foreign_type = g_new(ffi_type, 1);
                foreign_type->alignment = 0;
                foreign_type->elements = g_new(ffi_type *, field_count + 1); // This is a NULL terminated array
                foreign_type->size = 0;
                foreign_type->type = FFI_TYPE_STRUCT;
                
                // Iterate over the fields to compute the public non-static ones
                iter = NULL;
                int32_t structure_size = 0;
                ffi_type **current_element = foreign_type->elements;
                while((field = mono_class_get_fields(klass, &iter))) {
                    uint32_t flags = mono_field_get_flags(field);
                    if ((flags & MONO_FIELD_ATTR_PUBLIC) == MONO_FIELD_ATTR_PUBLIC &&
                        (flags & MONO_FIELD_ATTR_STATIC) == 0) {
                        // Get the encoding for the field
                        MonoType *field_type = mono_field_get_type(field);
                        MonobjcTypeDescriptor *field_descriptor = monobjc_get_descriptor(field_type, NULL);
                        
                        // Append the encoding
                        g_string_append(buffer, field_descriptor->encoding);
                        
                        // Append the size
                        //structure_size += MAX(field_descriptor->size, sizeof(void *));
                        structure_size += field_descriptor->size;
                        
                        // Append the foreing type
                        *current_element = field_descriptor->foreign_type;
                        current_element++;
                    }
                }
                *current_element = NULL;
                
                // Set the encoding epilogue
                g_string_append(buffer, "}");
                
                // Create the descriptor
                char *structure_encoding = g_string_free(buffer, FALSE);
                descriptor = monobjc_create_descriptor_for_System_Struct(underlyingType, structure_encoding, structure_size, foreign_type);
                g_free(structure_encoding);
                
                // Store the descriptor
                __map_descriptor(type, descriptor);
            }
			
            // Retrieve the converter methods
			args[0] = mono_type_get_object(mono_domain_get(), type);
			args[1] = mono_type_get_object(mono_domain_get(), underlyingType);
			obj = mono_runtime_invoke(monobjc_get_Monobjc_TypeHelper_GetConverterHandle_method(), NULL, args, NULL);
			descriptor->convert_from_managed = *(MonoMethod **) mono_object_unbox(obj);
			args[0] = mono_type_get_object(mono_domain_get(), underlyingType);
			args[1] = mono_type_get_object(mono_domain_get(), type);
			obj = mono_runtime_invoke(monobjc_get_Monobjc_TypeHelper_GetConverterHandle_method(), NULL, args, NULL);
			descriptor->convert_to_managed = *(MonoMethod **) mono_object_unbox(obj);
        }
        // Case: Monobjc.Id subclasses and Monobjc.IManagedWrapper implementations
        else if (mono_class_is_assignable_from(monobjc_get_Monobjc_IManagedWrapper_interface(), klass) ||
				 mono_class_is_subclass_of(klass, monobjc_get_Monobjc_IManagedWrapper_interface(), TRUE)) {
            // For every subclasses or implementation, the descriptor is the same
            descriptor = monobjc_create_descriptor_for_Monobjc_Id(type);
            
            // Store the descriptor
            __map_descriptor(type, descriptor);
        }
        // Case: Block subclasses
        else if (monobjc_get_Monobjc_Block_class() && mono_class_is_subclass_of(klass, monobjc_get_Monobjc_Block_class(), FALSE)) {
            // For every subclasses, the descriptor is the same
            descriptor = monobjc_create_descriptor_for_Monobjc_Block();
            
            // Store the descriptor
            __map_descriptor(type, descriptor);
        }
        // Case: Any other cases
        else {
            // For all other cases, raise an exception
            char *msg;
            asprintf(&msg, STRING_CANNOT_CREATE_DESCRIPTOR, name);
            exc = mono_exception_from_name_msg(monobjc_get_Monobjc_image(), MONOBJC, OBJECTIVE_C_EXCEPTION, msg);
            g_free(msg);
        }
    } else{
        LOG_DEBUG(MONOBJC_DOMAIN_MARSHALLING, "Found descriptor for %s", name);
    }
    
    // Check if encodings are matching
    if (encoding && monobjc_compare_encoding(descriptor->encoding, encoding)) {
        LOG_WARNING(MONOBJC_DOMAIN_MARSHALLING, "Mismatch between encoding '%s' and '%s'.", descriptor->encoding, encoding);
    }

    UNLOCK_DESCRIPTORS();
    
    g_free(name);
    
    // Raise the exception if any
    if (!canFail && exc) {
        mono_raise_exception(exc);
    }
    
    return descriptor;
}
