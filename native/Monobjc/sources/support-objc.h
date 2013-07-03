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
 * @file    support-objc.h
 * @brief   Defines Objective-C runtime functions.
 * @author  Laurent Etiemble <laurent.etiemble@monobjc.net>
 * @date    2009-2013
 */
#ifndef __SUPPORT_OBJC_H__
#define __SUPPORT_OBJC_H__

/**
 * @brief   Compare two encoding strings.
 * @param   encoding1   The first encoding.
 * @param   encoding2   The second encoding.
 * @return  Returns 1 if encodings are equals, 0 otherwise.
 */
int monobjc_compare_encoding(const char *encoding1, const char *encoding2);

/**
 * @brief   Strip all the unnecessary prefix and delimiters from a type encoding.
 *          Encoding for structure are flatten to make fields contiguious.
 * @par
 *          Primitive type are unchanged: 'i' => 'i'
 * @par
 *          Pointer type are stripped   : '^i' => '^'
 * @par
 *          Modifiers are removed       : 'Vv' => 'v'
 * @par
 *          Structure type are flatten  : '{NSPoint=ff}' => 'ff'
 * @par
 *          Structure type are flatten  : '{NSRect={NSPoint=ff}{NSSize=ff}' => 'ffff'
 * @param   encoding    The type encoding.
 * @return  The flatten encoding.
 * @remark  It is up to the caller to free the returned string.
 */
char *monobjc_flatten_type(const char *encoding);

/**
 * @brief   Return the offset to the end of the first type encoding.
 * @param   type    The type encoding. It can contains multiple types.
 * @param   end     The stop character.
 * @return  The offset of the stop character if found.
 * @remark  Freely inspired from Objective-C runtime utility functions.
 */
int monobjc_subtype_until(const char *type, char end);

/**
 * @brief   Skip the first type encoding of the given string.
 * @param   type    The type encoding containing multiple types.
 * @return  A pointer past the first type encoding.
 * @remark  Freely inspired from Objective-C runtime utility functions.
 */
const char *monobjc_skip_first_type(const char *type);

#endif // __SUPPORT_OBJC_H__
