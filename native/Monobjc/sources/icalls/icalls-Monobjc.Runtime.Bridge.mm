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
 * @file    icalls-Monobjc.Runtime.Bridge.mm
 * @brief   Contains the internal calls for the Monobjc.Runtime.Bridge type.
 * @author  Laurent Etiemble <laurent.etiemble@monobjc.net>
 * @date    2009-2013
 */
#include "definitions.h"
#include "icalls.h"
#include "lifecycle.h"
#include "logging.h"
#include "marshal.h"
#include "messaging.h"
#include "support-objc.h"

#pragma mark ----- Internal Calls -----

/**
 * @brief   Add the specified method to the given class. Both legacy and modern Objective-C runtimes are supported.
 * @param   target              The Objective-C class instance.
 * @param   meta                Whether to add the methods to the class or its meta-class.
 * @param   method              The runtime method handle to the method to add.
 * @param   method_name         An array of MonoString object for the method names.
 * @param   method_encoding     An array of MonoString object for the method type encodings.
 */
void icall_Monobjc_Runtime_Bridge_AddMethod(void *target, boolean_t meta, MonoMethod *method, MonoString *method_name, MonoString *method_encoding) {
    // Get the method signature and extract:
    // - The number of arguments
    // - The return type
    // - The parameter types
    MonoMethodSignature *sig = mono_method_signature(method);
    uint32_t nargs = mono_signature_get_param_count(sig);
    MonoType *return_type = mono_signature_get_return_type(sig);
    MonoType **parameter_types = g_new(MonoType *, nargs);
    MonoType **current = parameter_types;
    void *iter = NULL;
    while ((*current = mono_signature_get_params(sig, &iter))) {
        current++;
    }
    
    // The implementation is a closure that will perform the actual call
    ffi_closure *closure = monobjc_closure_prepare(method, nargs, return_type, parameter_types);
    IMP implementation = (IMP) closure;        
    
    // Select either the class or the meta-class
    Class cls = meta ? object_getClass((Class) target) : (Class) target;

    // Convert string objects
    char *name = mono_string_to_utf8(method_name);
    char *encoding = mono_string_to_utf8(method_encoding);
    
    LOG_DEBUG(MONOBJC_DOMAIN_GENERAL, "Adding method to '%s': '%s' encoded by '%s'", class_getName(cls), name, encoding);
    
    // Add the method list to the class or the meta-class
    class_addMethod(cls, sel_registerName(name), implementation, encoding);
}

/**
 * @brief   Add the specified methods to the given class. Both legacy and modern Objective-C runtimes are supported.
 * @param   target                  The Objective-C class instance.
 * @param   meta                    Whether to add the methods to the class or its meta-class.
 * @param   method_names            An array of MonoString object for the method names.
 * @param   method_implementations  An array of IntPtr object for the method implementations.
 * @param   method_encodings        An array of MonoString object for the method type encodings.
 */
void icall_Monobjc_Runtime_Bridge_AddMethods(void *target, boolean_t meta, MonoArray *method_names, MonoArray *method_implementations, MonoArray *method_encodings) {
    // Select either the class or the meta-class
    Class cls = meta ? object_getClass((Class) target) : (Class) target;
    
    // Access to the address of the first element.
    uintptr_t size = mono_array_length(method_implementations);
    int32_t method_implementations_element_size = mono_class_array_element_size(mono_get_intptr_class());
    IMP *method_implementations_addr = (IMP *) mono_array_addr_with_size(method_implementations, method_implementations_element_size, 0);
    
    // Iterate over methods to add them to the class or the meta-class
    for(uint32_t index = 0; index < size; index++) {
        // Extract method data
        IMP implementation = method_implementations_addr[index];        
        MonoString *method_name = (MonoString *)mono_array_get(method_names, MonoString *, index);
        char *name = mono_string_to_utf8(method_name);
        MonoString *method_encoding = (MonoString *)mono_array_get(method_encodings, MonoString *, index);
        char *encoding = mono_string_to_utf8(method_encoding);
        
        LOG_DEBUG(MONOBJC_DOMAIN_GENERAL, "Adding method to '%s': '%s' encoded by '%s'", class_getName(cls), name, encoding);
        
        // Add the method list to the class or the meta-class
        class_addMethod(cls, sel_registerName(name), implementation, encoding);
    }
}

/**
 * @brief   Create a new class definition with its instance variables. Both legacy and modern Objective-C runtimes are supported.
 *
 * @par        
 *          In Mac OS X 10.4, class registration follows these steps:
 *          @li Compute the storage size for ivars (the base-class size plus the declared ones).
 *          @li Create and definitions of the class and its meta-class.
 *          @li Add the ivars definition to the class.
 *          @li Register the class in the runtime.
 * @par        
 *          In Mac OS X 10.5 and higher, class registration follows these steps:
 *          @li Compute the storage size for ivars (only the declared ones).
 *          @li Allocate the class pair (class and its meta-class).
 *          @li Add the ivars definition to the class.
 *          @li Register the class in the runtime.
 * 
 * @param   class_name          The class name.
 * @param   super_class_name    The super class name.
 * @param   ivar_names          An array of MonoString object for the instance variable names.
 * @param   ivar_types          An array of MonoType object for the instance variable types.
 * @return  The class wrapper for the newly created class.
 *
 * @remark  Alignment of instance variable has an influence on the extra bytes needed to define a class.
 * @remark  TODO: Insert Graph
 */
MonoObject *icall_Monobjc_Runtime_Bridge_CreateClass(MonoString *class_name, MonoString *super_class_name, MonoArray *ivar_names, MonoArray *ivar_types) {
    // Extract the super class
    char *name = mono_string_to_utf8(super_class_name);
    Class super_class = objc_getClass(name);
    g_free(name);
    
#if MAC_OS_X_VERSION_MIN_REQUIRED < MAC_OS_X_VERSION_10_5
    // Allocates method list slots
    struct objc_method_list **method_list = objc_method_list_alloc(16);
    struct objc_method_list **meta_method_list = objc_method_list_alloc(4);
    
    name = mono_string_to_utf8(class_name);
    
    LOG_DEBUG(MONOBJC_DOMAIN_GENERAL, "Creating class-pair for '%s'", name);
    
    // Allocate the meta-class
    Class meta_class = g_new(objc_class, 1);
    meta_class->isa = super_class->isa->isa;
    meta_class->super_class = super_class->isa;
    meta_class->name = strdup(name);
    meta_class->version = 0;
    meta_class->info = CLS_META | CLS_INITIALIZED | CLS_METHOD_ARRAY;
    meta_class->instance_size = super_class->isa->instance_size;
    meta_class->ivars = NULL;
    meta_class->methodLists = meta_method_list;
    meta_class->cache = NULL;
    meta_class->protocols = NULL;
    
    // Allocate the class
    Class cls = g_new(objc_class, 1);
    cls->isa = meta_class;
    cls->super_class = super_class;
    cls->name = meta_class->name;
    cls->version = 0;
    cls->info = CLS_CLASS | CLS_METHOD_ARRAY;
    cls->instance_size = super_class->instance_size;
    cls->ivars = NULL;
    cls->methodLists = method_list;
    cls->cache = NULL;
    cls->protocols = NULL;
    
    g_free(name);
    
    // Access to the address of the first element.
    uintptr_t size = mono_array_length(ivar_types);
    int32_t ivar_types_element_size = mono_class_array_element_size(mono_get_intptr_class());
    MonoType **ivar_types_addr = (MonoType **) mono_array_addr_with_size(ivar_types, ivar_types_element_size, 0);
    
    // Allocate a ivar list that hold the methods
    objc_ivar_list *list = (objc_ivar_list *) g_malloc(sizeof(objc_ivar_list) + sizeof(objc_ivar) * size);
    list->ivar_count = size;
    
    // Iterate over ivars to compute the extra size and the add them to the list
    objc_ivar *ivar = list->ivar_list;
    for(uint32_t index = 0; index < size; index++, ivar++) {
        MonoType *type = ivar_types_addr[index];
        MonobjcTypeDescriptor *descriptor = monobjc_get_descriptor(type, NULL);
        
        // Compute offset with the ivar alignment
        int32_t offset = cls->instance_size;
        int32_t alignment_mask = (1 << descriptor->alignment) - 1;
        offset = (offset + alignment_mask) & ~alignment_mask;
        
        // Extra bytes depends on the ivar alignment
        cls->instance_size = offset + descriptor->size;
        
        // Set the ivar
        MonoString *ivar_name = (MonoString *)mono_array_get(ivar_names, MonoString *, index);
        name = mono_string_to_utf8(ivar_name);
        
        LOG_DEBUG(MONOBJC_DOMAIN_GENERAL, "Add IVar '%s' encoded with '%s'", name, descriptor->encoding);
        
        ivar->ivar_name = strdup(name);
        ivar->ivar_type = strdup(descriptor->encoding);
        ivar->ivar_offset = offset;
        
        g_free(name);
    }
    
    // Assign the ivar list to the class
    cls->ivars = list;
    
    // Register the class into the runtime
    objc_addClass(cls);
#else
    // Hold the storage size for the ivars
    size_t extra_bytes = 0;
    
    // Access to the address of the first element.
    uintptr_t size = mono_array_length(ivar_types);
    int32_t ivar_types_element_size = mono_class_array_element_size(mono_get_intptr_class());
    MonoType **ivar_types_addr = (MonoType **) mono_array_addr_with_size(ivar_types, ivar_types_element_size, 0);
    
    // Iterate over ivars to compute the extra size
    for(uint32_t index = 0; index < size; index++) {
        MonoType *type = ivar_types_addr[index];
        MonobjcTypeDescriptor *descriptor = monobjc_get_descriptor(type, NULL);
        
        // Compute offset with the ivar alignment
        size_t offset = extra_bytes;
        size_t alignment_mask = (1 << descriptor->alignment) - 1;
        offset = (offset + alignment_mask) & ~alignment_mask;
        
        // Extra bytes depends on the ivar alignment
        extra_bytes = offset + descriptor->size;
    }
    
    // Do the actual class pair allocation
    name = mono_string_to_utf8(class_name);
    
    LOG_DEBUG(MONOBJC_DOMAIN_GENERAL, "Creating class-pair for '%s'", name);
    
    Class cls = objc_allocateClassPair(super_class, name, extra_bytes);
    g_free(name);
    
    // Iterate over ivars to add them to the class
    for(uint32_t index = 0; index < size; index++) {
        MonoType *type = ivar_types_addr[index];
        MonobjcTypeDescriptor *descriptor = monobjc_get_descriptor(type, NULL);
        
        // Add the ivar
        MonoString *ivar_name = (MonoString *)mono_array_get(ivar_names, MonoString *, index);
        name = mono_string_to_utf8(ivar_name);
        
        LOG_DEBUG(MONOBJC_DOMAIN_GENERAL, "Add IVar '%s' encoded with '%s'", name, descriptor->encoding);
        
        class_addIvar(cls, name, descriptor->size, descriptor->alignment, descriptor->encoding);
        
        g_free(name);
    }
    
    // Register the class into the runtime
    objc_registerClassPair(cls);
#endif
    
    return icall_Monobjc_Class_Get_intptr(cls);
}

/**
 * @brief   Setup the interception of the @c dealloc messages for the given class.
 * @param   obj     The wrapper of the class to intercept.
 */
void icall_Monobjc_Runtime_Bridge_InterceptDeallocFor(MonoObject *obj) {
    MonoObject *result = mono_runtime_invoke(monobjc_get_Monobjc_Id_get_NativePointer_method(), obj, NULL, NULL);
    void *target = *(void **) mono_object_unbox(result);

    Class cls = (Class) target;
    LOG_DEBUG(MONOBJC_DOMAIN_GENERAL, "Called icall_Monobjc_Runtime_Bridge_InterceptDeallocFor %s", class_getName(cls));
    
    monobjc_intercep_dealloc_for(cls);
}
