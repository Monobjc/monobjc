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
 * @file    support-objc.h
 * @brief   Defines Objective-C runtime functions.
 * @author  Laurent Etiemble <laurent.etiemble@monobjc.net>
 * @date    2009-2012
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
