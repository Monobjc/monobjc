//
// This file is part of Monobjc, a .NET/Objective-C bridge
// Copyright (C) 2007-2013 - Laurent Etiemble
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
 * @file    icalls-Monobjc.Runtime.Messaging.mm
 * @brief   Contains the internal calls for the Monobjc.Runtime.Messaging type.
 * @author  Laurent Etiemble <laurent.etiemble@monobjc.net>
 * @date    2009-2013
 */
#include "definitions.h"
#include "domain.h"
#include "icalls.h"
#include "logging.h"
#include "messaging.h"
#include "support-objc.h"

#if !HIERARCHICAL_STORAGE
/**
 * @brief   Convert an array MonoObject objects to an array of MonoType objects.
 * @param   size        The size of the array.
 * @param   parameters  The array of MonoObject objects to convert.
 * @return  An array of MonoType objects.
 *
 * @remark  A NULL parameter is assumed to be of Monobjc.Id type.
 * @remark  This function allocates the array of MonoType objects; it is up to the caller to free it.
 */
MonoType **__extract_parameter_types(uintptr_t size, MonoArray *parameters) {
    LOG_DEBUG(MONOBJC_DOMAIN_MESSAGING, "__extract_parameter_types");
    
    // Allocate an array for the result
    MonoType **parameter_types = (size > 0) ? g_new(MonoType *, size) : NULL;
    for(uint32_t i = 0; i < size; i++) {
        MonoObject *parameter = mono_array_get(parameters, MonoObject *, i);
        
        // If the parameter has a type, store it. Otherwise, assume it is a Monobjc.Id.
        if (parameter) {
            MonoClass *parameter_class = mono_object_get_class(parameter);
            MonoType *parameter_type = mono_class_get_type(parameter_class);
            parameter_types[i] = parameter_type;
        } else {
            parameter_types[i] = monobjc_get_Monobjc_Id_type();
        }
        
        /*
        char *name = mono_type_get_name(parameter_types[i]);
        LOG_DEBUG(MONOBJC_DOMAIN_MESSAGING, "__extract_parameter_types - parameter_types[%u] = %s", i, name);
        g_free(name);
         */
    }
    
    return parameter_types;
}
#endif

#pragma mark ----- Internal Calls -----

/**
 * @brief   Send an Objective-C message to the receiver.
 * @param   return_type     The return type.
 * @param   receiver        The target receiver.
 * @param   name            The selector name.
 * @param   parameters      An array of parameters.
 * @return  The result of the call.
 *
 * @remark  Call that have void as return type, return NULL.
 */
MonoObject *icall_Monobjc_Runtime_Messaging_Call(MonoType *return_type, void *receiver, MonoString *name, MonoArray *parameters) {
    // Get the target
    id target = (id)receiver;
    
    // Get the selector
    char *str = mono_string_to_utf8(name);
    SEL selector = sel_registerName(str);
    g_free(str);
    
    /*
     char *value = mono_type_get_name(return_type);
     LOG_INFO(MONOBJC_DOMAIN_MESSAGING, "icall_Monobjc_Runtime_Messaging_Call<%s>(%p, '%s')", value, receiver, sel_getName(selector));
     g_free(value);
     */
    
    LOCK_CALLS();    
    
    MonobjcNativeCallSlot *slot = monobjc_lookup_call(return_type, selector, parameters);
    if (!slot->call) {
        // Retrieve the target method
        Class cls = object_getClass(target);
        Method method = class_getInstanceMethod(cls, selector);
        if (!method) {
            method = class_getClassMethod(cls, selector);
        }
        
        // If the call has never been sent, create the call descriptor.
        slot->call = monobjc_call_prepare(return_type, method, parameters);
    }
    
    UNLOCK_CALLS();
    
    // Do the call, using the descriptor and the parameters
    MonoObject *result = monobjc_call_invoke(slot->call, target, selector, parameters, FALSE);

    return result;
}

/**
 * @brief   Send an Objective-C message to the receiver's super.
 * @param   return_type     The return type.
 * @param   receiver        The target receiver.
 * @param   cls             The receiver's class.
 * @param   name            The selector name.
 * @param   parameters      An array of parameters.
 * @return  The result of the call.
 *
 * @remark  Call that have void as return type, return NULL.
 */
MonoObject *icall_Monobjc_Runtime_Messaging_CallSuper(MonoType *return_type, void *receiver, void *cls, MonoString *name, MonoArray *parameters) {
    // Get the target
    objc_super target;
    target.receiver = (id)receiver;
    target.super_class = class_getSuperclass((Class)cls);
    
    // Get the selector
    char *str = mono_string_to_utf8(name);
    SEL selector = sel_registerName(str);
    g_free(str);
    
    /*
    char *value = mono_type_get_name(return_type);
    LOG_INFO(MONOBJC_DOMAIN_MESSAGING, "icall_Monobjc_Runtime_Messaging_CallSuper<%s>(%p, '%s')", value, receiver, sel_getName(selector));
    g_free(value);
     */
    
    MonobjcNativeCallSlot *slot = monobjc_lookup_call(return_type, selector, parameters);
    
    LOCK_CALLS();    
    
    if (!slot->call) {
        // Retrieve the target method
        Method method = class_getInstanceMethod(target.super_class, selector);
        if (!method) {
            method = class_getClassMethod(target.super_class, selector);
        }
        
        // If the call has never been sent, create the call descriptor.
        slot->call = monobjc_call_prepare(return_type, method, parameters);
    }

    UNLOCK_CALLS();
    
    // Do the call, using the descriptor and the parameters
    MonoObject *result = monobjc_call_invoke(slot->call, &target, selector, parameters, TRUE);
    
    return result;
}
