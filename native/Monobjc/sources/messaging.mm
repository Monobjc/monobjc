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
 * @file    messaging.mm
 * @brief   Contains definitions for Objective-C/.NET messaging.
 * @author  Laurent Etiemble <laurent.etiemble@monobjc.net>
 * @date    2009-2014
 */
#include <sys/mman.h>
#include "cache.h"
#include "constants.h"
#include "definitions.h"
#include "domain.h"
#include "logging.h"
#include "marshal.h"
#include "messaging.h"
#include "support-ffi.h"
#include "support-objc.h"
#include "support-mono.h"

/**
 * @brief   Print the string representation of the messaging function.
 * @param   message The messaging function.
 */
void __print_message(__ffi_fn message) {
    if (message == (__ffi_fn)objc_msgSend) {
        LOG_DEBUG(MONOBJC_DOMAIN_MESSAGING, "Message is 'objc_msgSend'");
    }
#if TARGET_CPU_X86 || TARGET_CPU_X86_64
    if (message == (__ffi_fn)objc_msgSend_fpret) {
        LOG_DEBUG(MONOBJC_DOMAIN_MESSAGING, "Message is 'objc_msgSend_fpret'");
    }
#endif
    if (message == (__ffi_fn)objc_msgSend_stret) {
        LOG_DEBUG(MONOBJC_DOMAIN_MESSAGING, "Message is 'objc_msgSend_stret'");
    }
    if (message == (__ffi_fn)objc_msgSendSuper) {
        LOG_DEBUG(MONOBJC_DOMAIN_MESSAGING, "Message is 'objc_msgSendSuper'");
    }
    if (message == (__ffi_fn)objc_msgSendSuper_stret) {
        LOG_DEBUG(MONOBJC_DOMAIN_MESSAGING, "Message is 'objc_msgSendSuper_stret'");
    }
}

/**
 * @brief   Return the appropriate message to send for the given type descriptor.
 * @param   descriptor  The type descriptor.
 * @param   is_super    If the call is sent to super.
 * @return  The Objective-C messaging function to use.
 */
__ffi_fn __get_message(MonobjcTypeDescriptor *descriptor, boolean_t is_super) {
    __ffi_fn message = NULL;
    
    ffi_type *foreign_type = descriptor->foreign_type;
    
    // Case: structures (other that primitive types)
    if (foreign_type->type == FFI_TYPE_STRUCT) {
#if TARGET_CPU_X86 || TARGET_CPU_X86_64
        // On Intel processors, small structure can be returned right in registers:
        // - On 32 bits, a small structure size must be 1, 2, 4 or 8 bytes wide.
        // - On 64 bits, a small structure size must be 1, 2, 4, 8 or 16 bytes wide.
        switch (descriptor->size) {
            case 1: case 2: case 4: case 8:
                message = is_super ? (__ffi_fn)objc_msgSendSuper : (__ffi_fn)objc_msgSend;
                break;
#if TARGET_CPU_X86_64
            case 16:
                message = is_super ? (__ffi_fn)objc_msgSendSuper : (__ffi_fn)objc_msgSend;
                break;
#endif
            default:
                message = is_super ? (__ffi_fn)objc_msgSendSuper_stret : (__ffi_fn)objc_msgSend_stret;
                break;
        }
#elif TARGET_CPU_PPC || TARGET_CPU_PPC64
        // On PowerPC processors, structure are always return on the stack
        message = is_super ? (__ffi_fn)objc_msgSendSuper_stret : (__ffi_fn)objc_msgSend_stret;
#else
#error Unsupported CPU Type
#endif
    }
    // Case: floating-point types
    else if (foreign_type == &ffi_type_float ||
             foreign_type == &ffi_type_double) {
#if TARGET_CPU_X86 || TARGET_CPU_X86_64
        // On Intel processors, there is a special floating-point messaging function to use.
        // The reason is described in the following post: http://lists.apple.com/archives/Objc-language/2006/Jun/msg00012.html
        return is_super ? (__ffi_fn)objc_msgSendSuper : (__ffi_fn)objc_msgSend_fpret;
#elif TARGET_CPU_PPC || TARGET_CPU_PPC64
        // On PowerPC processors, there is no dedicated floating-point messaging funcion.
        return is_super ? (__ffi_fn)objc_msgSendSuper : (__ffi_fn)objc_msgSend;
#else
#error Unsupported CPU Type
#endif
    }
    // Case: all other types
    else {
        message = is_super ? (__ffi_fn)objc_msgSendSuper : (__ffi_fn)objc_msgSend;
    }
    
    __print_message(message);
    
    return message;
}

/**
 * @brief   Destruction callback for a native call.
 * @param   allocator   The allocator.
 * @param   value       The call to destroy.
 */
static void __destroy_nativecall(void *value) {
    MonobjcNativeCall *call = (MonobjcNativeCall *) value;
    
    LOG_DEBUG(MONOBJC_DOMAIN_MARSHALLING, "Destroying native call %s", monobjc_get_ffi_cif_string(call->cif));
    
    g_free(call->cif->arg_types);
    g_free(call->parameter_descriptors);
    g_free(call->cif);
    g_free(call);
}

static void __destroy_nativecallslot(void *value) {
    MonobjcNativeCallSlot *slot = (MonobjcNativeCallSlot *) value;
    
    if (slot->call) {
        __destroy_nativecall(slot->call);
    }
    g_hash_table_destroy(slot->children);
}

#pragma mark ----- Implementation -----

void monobjc_create_cache_for_calls() {
    LOG_INFO(MONOBJC_DOMAIN_GENERAL, "Create cache for calls");
    __CALLS_HASHTABLE = g_hash_table_new_full(g_direct_hash, g_direct_equal, NULL, __destroy_nativecallslot);
    monobjc_mutex_init(&__CALLS_MUTEX, FALSE);
}

void monobjc_destroy_cache_for_calls() {
    LOG_INFO(MONOBJC_DOMAIN_GENERAL, "Destroy cache for calls");
    g_hash_table_destroy(__CALLS_HASHTABLE);
    monobjc_mutex_destroy(&__CALLS_MUTEX);
}

MonobjcNativeCallSlot *monobjc_lookup_call(MonoType *return_type, SEL selector, MonoArray *parameters) {
    MonobjcNativeCallSlot *slot = NULL;
    GHashTable *current = __CALLS_HASHTABLE;
    
    // The first level of storage is the return type.
    slot = (MonobjcNativeCallSlot *) g_hash_table_lookup(current, return_type);
    if (!slot) {
        slot = g_new0(MonobjcNativeCallSlot, 1);
        slot->children = g_hash_table_new_full(g_direct_hash, g_direct_equal, NULL, __destroy_nativecallslot);
        g_hash_table_insert(current, return_type, slot);
    }
    current = slot->children;
    
    // The second level of storage is the selector.
    slot = (MonobjcNativeCallSlot *) g_hash_table_lookup(current, selector);
    if (!slot) {
        slot = g_new0(MonobjcNativeCallSlot, 1);
        slot->children = g_hash_table_new_full(g_direct_hash, g_direct_equal, NULL, __destroy_nativecallslot);
        g_hash_table_insert(current, selector, slot);
    }
    current = slot->children;
    
    // The other level of storage are the parameter types.
    size_t size = mono_array_length(parameters);
    for(uint32_t i = 0; i < size; i++) {
        MonoObject *parameter = mono_array_get(parameters, MonoObject *, i);
        MonoType *parameter_type;
        
        // If the parameter has a type, store it. Otherwise, assume it is a Monobjc.Id.
        if (parameter) {
            MonoClass *parameter_class = mono_object_get_class(parameter);
            parameter_type = mono_class_get_type(parameter_class);
        } else {
            parameter_type = monobjc_get_Monobjc_Id_type();
        }
        
        // Create a new slot for each parameter type if it does not exist
        slot = (MonobjcNativeCallSlot *) g_hash_table_lookup(current, parameter_type);
        if (!slot) {
            slot = g_new0(MonobjcNativeCallSlot, 1);
            slot->children = g_hash_table_new_full(g_direct_hash, g_direct_equal, NULL, __destroy_nativecallslot);
            g_hash_table_insert(current, parameter_type, slot);
        }
        current = slot->children;
    }
    
    // Return the slot matching the call signature.
    return slot;
}

MonobjcNativeCall *monobjc_call_prepare(MonoType *return_type, Method method, MonoArray *parameters) {
    LOG_DEBUG(MONOBJC_DOMAIN_MESSAGING, "Preparing native call for '%s'", method_getName(method));
    
    // The arguments are 'receiver', 'selector' and the 'parameters', hence the +2
    size_t nargs = mono_array_length(parameters) + 2;
    
    // Allocate the native call structure
    MonobjcNativeCall *call = g_new(MonobjcNativeCall, 1);
    call->cif = g_new(ffi_cif, 1);
    
    // Get the descriptor and the foreign type for the return type 
    char *return_type_encoding = method_copyReturnType(method);
    call->return_descriptor = monobjc_get_descriptor(return_type, return_type_encoding);
    g_free(return_type_encoding);
    ffi_type *rtype = call->return_descriptor->foreign_type;
    
    // Compute the message as it depends on the return type
    call->message = __get_message(call->return_descriptor, FALSE);
    call->message_super = __get_message(call->return_descriptor, TRUE);
    
    // Get the descriptor and the foreign type for the parameters
    call->parameter_descriptors = g_new(MonobjcTypeDescriptor *, nargs);
    ffi_type **atypes = g_new(ffi_type *, nargs);
    
    // The first two parameters ('receiver', 'selector') are well known, let's make simple
    call->parameter_descriptors[0] = NULL;
    atypes[0] = &ffi_type_pointer;
    call->parameter_descriptors[1] = NULL;
    atypes[1] = &ffi_type_pointer;
    
    // For the others, use the descriptor and the foreign type
    for(uint32_t i = 2; i < nargs; i++) {
        MonoObject *parameter = mono_array_get(parameters, MonoObject *, i - 2);
        MonoType *parameter_type;
        
        // If the parameter has a type, store it. Otherwise, assume it is a Monobjc.Id.
        if (parameter) {
            MonoClass *parameter_class = mono_object_get_class(parameter);
            parameter_type = mono_class_get_type(parameter_class);
        } else {
            parameter_type = monobjc_get_Monobjc_Id_type();
        }
        
        char *argument_type_encoding = method_copyArgumentType(method, i);
        call->parameter_descriptors[i] = monobjc_get_descriptor(parameter_type, argument_type_encoding);
        g_free(argument_type_encoding);
        atypes[i] = call->parameter_descriptors[i]->foreign_type;
    }
    
    // Prepare the native call
    ffi_status status = ffi_prep_cif(call->cif, FFI_DEFAULT_ABI, nargs, rtype, atypes);
    if (status != FFI_OK) {
        LOG_WARNING(MONOBJC_DOMAIN_MESSAGING, "Native call preparation failed with %d for '%s'", status, method_getName(method));
        
        // Clean everything
        g_free(atypes);
        g_free(call->parameter_descriptors);
        g_free(call->cif);
        g_free(call);
        call = NULL;
        
        // Raise an exception
        char *msg;
        asprintf(&msg, STRING_CANNOT_PREPARE_CALL, sel_getName(method_getName(method)));
        MonoException *exc = mono_exception_from_name_msg(monobjc_get_Monobjc_image(), MONOBJC, OBJECTIVE_C_MESSAGING_EXCEPTION, msg);
        g_free(msg);
        mono_raise_exception(exc);
    } else {
        LOG_DEBUG(MONOBJC_DOMAIN_MESSAGING, "Native call preparation succeed for '%s'", method_getName(method));
        monobjc_print_ffi_cif(call->cif);
    }
    
    return call;
}

MonoObject *monobjc_call_invoke(MonobjcNativeCall *call, void *target, SEL selector, MonoArray *parameters, boolean_t is_super) {
    LOG_DEBUG(MONOBJC_DOMAIN_MESSAGING, "monobjc_call_invoke: selector = '%s'", sel_getName(selector));
    
    MonoObject *result = NULL;
    uint32_t nargs = call->cif->nargs;
    MonobjcTypeDescriptor *returnDescriptor = call->return_descriptor;
    
    // Allocate space for return value
    void *rvalue = returnDescriptor->alloc_native_storage(returnDescriptor, FALSE);
    
    // Allocate space for parameters
    void **avalue = g_new(void *, nargs);
    
    // Marshal the target and the selector directly
    avalue[0] = &target;
    avalue[1] = &selector;
    
    // Marshal the parameters
    for(uint32_t i = 2; i < nargs; i++) {
        MonoObject *obj = mono_array_get(parameters, MonoObject *, i - 2);
        MonobjcTypeDescriptor *descriptor = call->parameter_descriptors[i];
        
        // Convert the managed type if needed
        if (descriptor->convert_from_managed) {
            void *args[1];
            args[0] = mono_object_unbox(obj);
            
            obj = mono_runtime_invoke(descriptor->convert_from_managed, NULL, args, NULL);
        }
        
        // Marshal the value to native
        avalue[i] = descriptor->alloc_native_storage(descriptor, FALSE);
        descriptor->marshal_to_native(descriptor, obj, avalue[i], FALSE);
    }
    
    MonoException *exc = NULL;
    
    @try {
        // Do the actual call
        ffi_call(call->cif, is_super ? call->message_super : call->message, rvalue, avalue);

        // Process the result value
        if (returnDescriptor->convert_to_managed) {
            void *args[1];
            args[0] = rvalue;
            
            // Convert the value type and marshal back the result
            result = mono_runtime_invoke(returnDescriptor->convert_to_managed, NULL, args, NULL);
        } else {
            // Marshal back the result
            result = call->return_descriptor->marshal_from_native(call->return_descriptor, rvalue, FALSE);
        }
    }
    @catch (NSException *ex) {
        LOG_DEBUG(MONOBJC_DOMAIN_MESSAGING, "Native exception caught: %s", [[ex description] UTF8String]);
        
        // Encapsulate the native exception
        exc = mono_exception_from_name_msg(monobjc_get_Monobjc_image(), MONOBJC, OBJECTIVE_C_MESSAGING_EXCEPTION, [[ex description] UTF8String]);
    }
    @finally {
        // Clean parameters
        for(uint32_t i = 2; i < nargs; i++) {
            MonobjcTypeDescriptor *descriptor = call->parameter_descriptors[i];
            descriptor->free_native_storage(avalue[i]);
        }
        
        // Clean space for parameters
        g_free(avalue);
        
        // Clean space for result value
        returnDescriptor->free_native_storage(rvalue);
    }
    
    // If there is an exception, raise it now
    if (exc) {
        LOG_DEBUG(MONOBJC_DOMAIN_MESSAGING, "Throwing exception");
        mono_raise_exception(exc);
    }
    
    return result;
}

ffi_closure *monobjc_closure_prepare(MonoMethod *method, uint32_t nargs, MonoType *return_type, MonoType **parameter_types) {
    LOG_DEBUG(MONOBJC_DOMAIN_MESSAGING, "monobjc_closure_prepare");
    
    // Create the user data for the closure
    MonobjcManagedCall *call = g_new(MonobjcManagedCall, 1);
    call->method = method;
    
    // Get the descriptor and the foreign type for the return type 
    call->return_descriptor = monobjc_get_descriptor(return_type, NULL);
    ffi_type *rtype = call->return_descriptor->foreign_type;
    
    // Get the descriptor and the foreign type for the parameters
    call->parameter_descriptors = g_new(MonobjcTypeDescriptor *, nargs);
    ffi_type **atypes = g_new(ffi_type *, nargs);
    
    // Use the descriptor and the foreign type of the descriptor
    for(uint32_t i = 0; i < nargs; i++) {
        MonoType *parameter_type = parameter_types[i];
        call->parameter_descriptors[i] = monobjc_get_descriptor(parameter_type, NULL);
        atypes[i] = call->parameter_descriptors[i]->foreign_type;
    }
    
    // Allocate the CIF structure
    ffi_cif *cif = g_new(ffi_cif, 1);
    
    // Prepare the cif call
    ffi_status status = ffi_prep_cif(cif, FFI_DEFAULT_ABI, nargs, rtype, atypes);
    if (status != FFI_OK) {
        g_free(cif);
        g_free(atypes);
        g_free(call->parameter_descriptors);
        g_free(call);
        
        LOG_ERROR(MONOBJC_DOMAIN_MESSAGING, "TODO");
    }
    
    // Allocate the closure on mapped memory
    ffi_closure *closure = (ffi_closure *) mmap(NULL, sizeof(ffi_closure), PROT_READ | PROT_WRITE, MAP_ANON | MAP_PRIVATE, -1, 0);
    if (closure < 0) {
        g_free(cif);
        g_free(atypes);
        g_free(call->parameter_descriptors);
        g_free(call);
        
        LOG_ERROR(MONOBJC_DOMAIN_MESSAGING, "TODO");
    }
    
    // Prepare the closure
    status = ffi_prep_closure(closure, cif, monobjc_closure_invoke, call);
    if (status != FFI_OK) {
        munmap(closure, sizeof(ffi_closure));
        
        g_free(cif);
        g_free(atypes);
        g_free(call->parameter_descriptors);
        g_free(call);
        
        LOG_ERROR(MONOBJC_DOMAIN_MESSAGING, "TODO");
    }

    // Make the mapped memory protected and executable
    int ret = mprotect(closure, sizeof(closure), PROT_READ | PROT_EXEC);
    if (ret != 0) {
        munmap(closure, sizeof(ffi_closure));
        
        g_free(cif);
        g_free(atypes);
        g_free(call->parameter_descriptors);
        g_free(call);
        
        LOG_ERROR(MONOBJC_DOMAIN_MESSAGING, "TODO %d", ret);
    }
    
    return closure;
}

/** @todo: the closure invocation still does not work as expected !!! */
void monobjc_closure_invoke(ffi_cif *cif, void *rvalue, void **avalue, void *userdata) {
    LOG_DEBUG(MONOBJC_DOMAIN_MESSAGING, "monobjc_closure_invoke");
    
    // Retrieve parameters
    uint32_t nargs = cif->nargs;
    MonobjcManagedCall *call = (MonobjcManagedCall *)userdata;
    
    // Allocate pointer array for arguments
    void **args = g_new(void *, nargs);
    
    // Marshal the parameters
    for(uint32_t i = 0; i < nargs; i++) {
        MonobjcTypeDescriptor *descriptor = call->parameter_descriptors[i];
        if (descriptor->boxed) {
            // Copy the boxed type ???
            /*
            MonoObject *obj = descriptor->marshal_from_native(descriptor, avalue[i], FALSE);
            void *ptr = descriptor->alloc_native_storage(descriptor, FALSE);
            descriptor->marshal_to_native(descriptor, obj, ptr, FALSE);
            args[i] = ptr;
             */
            args[i] = avalue[i];
        } else {
            MonoObject *obj = descriptor->marshal_from_native(descriptor, avalue[i], FALSE);
            args[i] = obj;
        }
    }
    
    // Do the actual invocation
    MonoObject *exc = NULL;
    MonoObject *obj = mono_runtime_invoke(call->method, NULL, args, &exc);
    
    // Free the parameters
    for(uint32_t i = 0; i < nargs; i++) {
        MonobjcTypeDescriptor *descriptor = call->parameter_descriptors[i];
        if (descriptor->boxed) {
            g_free(args[i]);
        }
    }
    
    g_free(args);
    
    if (!exc) {
        // Marshal the return value
        call->return_descriptor->marshal_to_native(call->return_descriptor, obj, rvalue, FALSE);
    } else {
        MonoMethod *method = monobjc_define_method(mono_get_exception_class(), "ToString", 0);
        MonoString *result = (MonoString *) mono_runtime_invoke(method, exc, NULL, NULL);
        
        char *value = mono_string_to_utf8(result);
        NSException *e = [NSException exceptionWithName:@"ManagedCallException" 
                                                 reason:[NSString stringWithUTF8String:value] 
                                               userInfo:NULL];
        g_free(value);
        
        [e raise];
    }
}
