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
 * @file    icalls-Monobjc.Class.mm
 * @brief   Contains the internal calls for the Monobjc.Class type.
 * @author  Laurent Etiemble <laurent.etiemble@monobjc.net>
 * @date    2009-2011
 */
#include "cache.h"
#include "definitions.h"
#include "icalls.h"
#include "logging.h"
#include "support-objc.h"

#pragma mark ----- Internal Calls -----

/**
 * @brief   Retrieve the class wrapper for the class instance.
 * @param   ptr     The Objective-C class instance.
 * @return  A class wrapper for the class.
 */
MonoObject *icall_Monobjc_Class_Get_intptr(void *ptr) {
    LOG_INFO(MONOBJC_DOMAIN_INSTANCES, "icall_Monobjc_Class_Get_intptr(%p)", ptr);
    
    // Try to fetch the class wrapper from the instance cache
    return icall_Monobjc_ObjectiveCRuntime_GetInstance(monobjc_get_Monobjc_Class_type(), ptr, FALSE);
}

/**
 * @brief   Retrieve the class instance for the given name.
 * @param   class_name  The name of the class.
 * @return  A class wrapper if the class is found, NULL otherwise.
 */
MonoObject *icall_Monobjc_Class_Get_string(MonoString *class_name) {
    char *name = mono_string_to_utf8(class_name);
    LOG_INFO(MONOBJC_DOMAIN_INSTANCES, "icall_Monobjc_Class_Get_string(\"%s\")", name);
    
    // Lookup the native class by its name
    Class cls = objc_lookUpClass(name);
    g_free(name);
    
    // Fetch the class wrapper or return NULL
    // It is ok to return NULL if the class is not loaded
    return (cls) ? icall_Monobjc_Class_Get_intptr((void *) cls) : NULL;
}    
    
/**
 * @brief   Retrieve the name of the given class instance.
 * @param   ptr     The Objective-C class instance.
 * @return  The name of the class.
 */
MonoString *icall_Monobjc_Class_GetName(void *ptr) {
    LOG_INFO(MONOBJC_DOMAIN_INSTANCES, "icall_Monobjc_Class_GetName(%p)", ptr);
    
    // Get the name for the class
    Class cls = (Class) ptr;
    const char *name = class_getName(cls);
    
    // Create a managed string for the name
    MonoString *str = mono_string_new(mono_domain_get(), name);
    return str;
}

/**
 * @brief   Retrieve the super class of the given class instance.
 * @param   ptr     The Objective-C class instance.
 * @return  A class wrapper if the suerp class is found, NULL otherwise.
 */
MonoObject *icall_Monobjc_Class_GetSuperClass(void *ptr) {
    LOG_INFO(MONOBJC_DOMAIN_INSTANCES, "icall_Monobjc_Class_GetSuperClass(%p)", ptr);

    // Get the class's super class
    Class cls = (Class) ptr;
    Class superCls = class_getSuperclass(cls);

    // Get the class wrapper or return NULL.
    // It is ok to return NULL (NSObject and NSProxy do not have superclass)
    return superCls ? icall_Monobjc_Class_Get_intptr((void *) superCls) : NULL;
}

/**
 * @brief   Test if the class is already present in cache for the given name.
 * @param   class_name  The name of the class.
 * @return  TRUE if the class has already been mapped.
 */
boolean_t icall_Monobjc_Class_IsMapped(MonoString *class_name) {
    char *name = mono_string_to_utf8(class_name);
    LOG_INFO(MONOBJC_DOMAIN_INSTANCES, "icall_Monobjc_Class_IsMapped(\"%s\")", name);
    
    // Lookup the native class by its name
    Class cls = objc_lookUpClass(name);
    g_free(name);
    
    if (cls) {
        LOCK_INSTANCES();
        
        // Fetch the class wrapper
        MonoObject *wrapper = monobjc_cache_lookup_instance((void *) cls);
        
        UNLOCK_INSTANCES();
        
        return (wrapper != NULL);
    }
    
    return FALSE;
}    
