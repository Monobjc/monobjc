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
 * @file    icalls-Monobjc.Id.mm
 * @brief   Contains the internal calls for the Monobjc.Id type.
 * @author  Laurent Etiemble <laurent.etiemble@monobjc.net>
 * @date    2009-2011
 */
#include "cache.h"
#include "domain.h"
#include "icalls.h"
#include "logging.h"
#include "marshal.h"
#include "support-objc.h"

#pragma mark ----- Internal Calls -----

/**
 * @brief   Get the value for the instance variable of the native instance.
 * @param   type    The type handle of the instance variable.
 * @param   ptr     The Objective-C native instance.
 * @param   name    The name of the instance variable.
 * @return  The value of the instance variable.
 */
MonoObject *icall_Monobjc_Id_GetInstanceVariable(MonoType *type, void *ptr, MonoString *name) {
    MonoObject *result = NULL;
    
    MonobjcTypeDescriptor *descriptor = monobjc_get_descriptor(type, NULL);
    void *storage = descriptor->alloc_native_storage(descriptor, TRUE);
    
    char *variable_name = mono_string_to_utf8(name);
    LOG_DEBUG(MONOBJC_DOMAIN_INSTANCES, "Getting instance variable '%s'", variable_name);

    //monobjc_dump_memory(ptr, 24);
    
    // Special case for large instance variables
    if (descriptor->size > sizeof(void *)) {
        // We access directly to the instance layout
        // Note: The following code is non GC compatible, as it does not use the write-barrier
        Ivar v = class_getInstanceVariable(object_getClass((id) ptr), variable_name);
        void *offset = (void *) ((char *)ptr + ivar_getOffset(v));
        memcpy(storage, offset, descriptor->size);
    } else {
        object_getInstanceVariable((id) ptr, variable_name, (void **) storage);    
    }
    
    // Process the result value
    if (descriptor->convert_to_managed) {
        void *args[1];
        args[0] = storage;
            
        // Convert the value type and marshal back the result
        result = mono_runtime_invoke(descriptor->convert_to_managed, NULL, args, NULL);
    } else {
        // Marshal back the result
        result = descriptor->marshal_from_native(descriptor, storage, TRUE);
    }
	
    descriptor->free_native_storage(storage);

    g_free(variable_name);
    
    return result;
}

/**
 * @brief   Set the value for the instance variable of the native instance.
 * @param   type    The type handle of the instance variable.
 * @param   ptr     The Objective-C native instance.
 * @param   name    The name of the instance variable.
 * @param   value   The value of the instance variable.
 */
void icall_Monobjc_Id_SetInstanceVariable(MonoType *type, void *ptr, MonoString *name, MonoObject *value) {
    MonobjcTypeDescriptor *descriptor = monobjc_get_descriptor(type, NULL);
	
    // Convert the managed type if needed
    if (descriptor->convert_from_managed) {
        void *args[1];
        args[0] = mono_object_unbox(value);
         
        value = mono_runtime_invoke(descriptor->convert_from_managed, NULL, args, NULL);
    }
	
    void *storage = descriptor->alloc_native_storage(descriptor, TRUE);
    descriptor->marshal_to_native(descriptor, value, storage, TRUE);

    char *variable_name = mono_string_to_utf8(name);
    LOG_DEBUG(MONOBJC_DOMAIN_INSTANCES, "Setting instance variable '%s'", variable_name);

    //monobjc_dump_memory(ptr, 24);
    
    // Special case for large instance variables
    if (descriptor->size > sizeof(void *)) {
        // We access directly to the layout
        // Note: The following code is non GC compatible, as it does not use the write-barrier
        Ivar v = class_getInstanceVariable(object_getClass((id) ptr), variable_name);
        void *offset = (void *) ((char *)ptr + ivar_getOffset(v));
        memcpy(offset, storage, descriptor->size);
    } else {
        object_setInstanceVariable((id) ptr, variable_name, *(void **) storage);
    }
    
    descriptor->free_native_storage(storage);
    
    //monobjc_dump_memory(ptr, 24);
    
    g_free(variable_name);
}

/**
 * @brief   Associate the given wrapper to the native instance.
 * @param   ptr     The Objective-C native instance.
 * @param   wrapper The instance wrapper to map.
 */
void icall_Monobjc_Id_MapInstance(void *ptr, MonoObject *wrapper) {
    LOG_INFO(MONOBJC_DOMAIN_INSTANCES, "icall_Monobjc_Id_MapInstance(%p)", ptr);
    monobjc_cache_map_instance(ptr, wrapper);
}
