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
 * @file    ffi-support.h
 * @brief   Contains diagnosis functions for FFI.
 * @author  Laurent Etiemble <laurent.etiemble@monobjc.net>
 * @date    2009-2010
 */
#ifndef __FFI_SUPPORT_H__
#define __FFI_SUPPORT_H__

#include <ffi/ffi.h>

#pragma mark ----- Function Pointers -----

/** @brief  Typeless function pointer used by FFI. */
typedef void (*__ffi_fn)(void); 

/**
 * @brief   Function pointer for FFI closure.
 * @param   cif         The CIF structure describing the call.
 * @param   rvalue      A pointer to the return value.
 * @param   avalue      A pointer to the array of parameters.
 * @param   userdata    The user data provided when the closure was created.
 */
typedef void (*__ffi_closure)(ffi_cif *cif, void *rvalue, void **avalue, void *userdata);

#pragma mark ----- Helper Functions -----

/**
 * @brief   Build the string representation of the FFI type.
 * @param   type    The type.
 * @return  A string containing the type representation.
 *
 * @remark  It is up to the caller to free the generated string.
 */
char *monobjc_get_ffi_type_string(ffi_type *type);

/**
 * @brief   Build the string representation of the FFI CIF structure.
 * @param   cif     The FFI CIF structure.
 * @return  A string containing the FFI CIF representation.
 *
 * @remark  It is up to the caller to free the generated string.
 */
char *monobjc_get_ffi_cif_string(ffi_cif *cif);

/**
 * @brief   Print the FFI CIF structure.
 * @param   cif     The FFI CIF structure.
 */
void monobjc_print_ffi_cif(ffi_cif *cif);

#endif // __FFI_SUPPORT_H__
