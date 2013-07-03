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
 * @file    support-ffi.h
 * @brief   Contains diagnosis functions for FFI.
 * @author  Laurent Etiemble <laurent.etiemble@monobjc.net>
 * @date    2009-2013
 */
#ifndef __SUPPORT_FFI_H__
#define __SUPPORT_FFI_H__

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

#endif // __SUPPORT_FFI_H__
