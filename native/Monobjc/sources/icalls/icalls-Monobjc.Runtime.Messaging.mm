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
 * @file    icalls-Monobjc.Runtime.Messaging.mm
 * @brief   Contains the internal calls for the Monobjc.Runtime.Messaging type.
 * @author  Laurent Etiemble <laurent.etiemble@monobjc.net>
 * @date    2009-2010
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
