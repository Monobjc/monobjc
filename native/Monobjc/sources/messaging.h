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
 * @file    messaging.h
 * @brief   Contains definitions for Objective-C/.NET messaging.
 * @author  Laurent Etiemble <laurent.etiemble@monobjc.net>
 * @date    2009-2011
 */
#ifndef __MESSAGING_H__
#define __MESSAGING_H__

#include "marshal.h"
#include "support-ffi.h"

/**
 * @brief   Holds the information needed to send a message to the Objective-C runtime.
 * @par
 *          The native call is sent using libffi, so the structure stores the CIF structure.
 * @par
 *          Due to the dynamic nature of the Objective-C messaging, the structure stores the
 *          function to call because it depends on the return type.
 * @par
 *          To be able to marshal back and forth Mono objects, the structure stores type
 *          descriptors, that take care of the memory allocation, object marshalling and
 *          cleaning.
 */
typedef struct MonobjcNativeCall {
    /** @brief  The CIF structure that describe the call. */
    ffi_cif *cif;
    /** @brief  The Objective-C message to call. */
    __ffi_fn message;
    /** @brief  The Objective-C message to call for super. */
    __ffi_fn message_super;
    /** @brief  Stores the type descriptor for the return type. */
    MonobjcTypeDescriptor *return_descriptor;
    /** @brief  Stores the type descriptors for the parameters. */
    MonobjcTypeDescriptor **parameter_descriptors;
};

/**
 * @brief   Holds the information needed to send a message to the Mono runtime.
 */
typedef struct MonobjcManagedCall {
    /** @brief  The managed method to call */
    MonoMethod *method;
    /** @brief  Stores the type descriptor for the return type. */
    MonobjcTypeDescriptor *return_descriptor;
    /** @brief  Stores the type descriptors for the parameters. */
    MonobjcTypeDescriptor **parameter_descriptors;
};

/**
 * @brief   Represents a node in a hierarchical storage.
 *          Typically, the slots are lay out as:
 *          - A Root slot
 *          - A first level for the return type
 *          - A second level for the selector
 *          - All the lower level are for the parameters types
 */
typedef struct MonobjcNativeCallSlot {
    /** @brief  TODO */
    MonobjcNativeCall *call;
    /** @brief  TODO */
    GHashTable *children;
};

/**
 * @brief   Create the cache for the call descriptors.
 */
void monobjc_create_cache_for_calls();

/**
 * @brief   Destroy the cache for the call descriptors.
 */
void monobjc_destroy_cache_for_calls();

/**
 * @brief   Retrieve the call descriptor from the cache.
 * @param   return_type         The return type.
 * @param   selector            The selector of the call.
 * @param   parameters          An array of parameter.
 * @return  A call descriptor if it has been already cached, or NULL otherwise.
 */
MonobjcNativeCallSlot *monobjc_lookup_call(MonoType *return_type, SEL selector, MonoArray *parameters);

/**
 * @brief       Create a call descriptor that describes the call to make.
 * @param       return_type     The return type.
 * @param       method          The method.
 * @param       parameters      An array of parameter.
 * @return      An initialized structure containing the all the descriptors.
 * @exception   An ObjectiveCMessageException if the call cannot be prepared.
 */
MonobjcNativeCall *monobjc_call_prepare(MonoType *return_type, Method method, MonoArray *parameters);

/**
 * @brief       Execute a prepared call on the given target with the given selector.
 * @param       call            The native call descriptor.
 * @param       target          The native target.
 * @param       selector        The Objective-C selector.
 * @param       parameters      An array of parameters.
 * @param       isSuper         Whether the call is to be sent to the super class.
 * @return      The result of the call.
 * @exception   An ObjectiveCMessageException if the call failed.
 */
MonoObject *monobjc_call_invoke(MonobjcNativeCall *call, void *target, SEL selector, MonoArray *parameters, boolean_t isSuper);

/**
 * @brief   TODO: Move
 */
ffi_closure *monobjc_closure_prepare(MonoMethod *method, uint32_t nargs, MonoType *return_type, MonoType **parameter_types);

/**
 * @brief   TODO: Move
 */
void monobjc_closure_invoke(ffi_cif *cif, void *rvalue, void **avalue, void *userdata);

#endif // __MESSAGING_H__
