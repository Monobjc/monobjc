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
 * @file    objc-support.h
 * @brief   Defines Objective-C runtime functions.
 * @author  Laurent Etiemble <laurent.etiemble@monobjc.net>
 * @date    2009-2010
 */
#ifndef __OBJC_SUPPORT_H__
#define __OBJC_SUPPORT_H__

/**
 * @brief   TODO
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

#if MAC_OS_X_VERSION_MIN_REQUIRED < MAC_OS_X_VERSION_10_5

#include <objc/objc-class.h>

/**
 * @brief   Allocates a list of method list slots.
 * @param   The number of list slots to allocate.
 * @return  A list a method lists.
 */
objc_method_list **objc_method_list_alloc(int count);

/**
 * @brief   Returns the name of a class.
 * @para    cls     A class object.
 * @return  The name of the class, or the empty string if cls is Nil.
 */
#define class_getName(cls)                  (cls) != nil ? (cls)->name : ""

/**
 * @brief   Returns the superclass of a class.
 * @para    cls     A class object.
 * @return  The superclass of the class, or Nil if cls is a root class, or Nil if cls is Nil.
 */
#define class_getSuperclass(cls)            (cls) != nil ? (cls)->super_class : nil

/**
 * @brief   Returns a Boolean value that indicates whether a class object is a metaclass.
 * @para    cls     A class object.
 * @return  YES if cls is a metaclass, NO if cls is a non-meta class, NO if cls is Nil.
 */
#define class_isMetaClass(cls)              (cls) != nil ? (cls)->info & CLS_META : NO

/**
 * @brief   Adds a new method to a class with a given name and implementation.
 * @param   cls     The class to which to add a method.
 * @param   name    A selector that specifies the name of the method being added.
 * @param   imp     A function which is the implementation of the new method. The function must take at least two arguments—self and _cmd.
 * @param   types   An array of characters that describe the types of the arguments to the method.
 * @return  YES if the method was added successfully, otherwise NO (for example, the class already contains a method implementation with that name).
 *
 * @remark  In Mac OS X 10.4, method addition is done as follow:
 *          @li Create of a method list structure.
 *          @li Add the method to the method list.
 *          @li Add of the method list to the class.
 */
BOOL class_addMethod(Class cls, SEL name, IMP imp, char *types);

/**
 * @brief   Replaces the implementation of a method for a given class.
 * @param   cls     The class you want to modify.
 * @param   name    A selector that identifies the method whose implementation you want to replace.
 * @param   imp     The new implementation for the method identified by name for the class identified by cls.
 * @param   types   An array of characters that describe the types of the arguments to the method.
 * @return  The previous implementation of the method identified by name for the class identified by cls.
 */
IMP class_replaceMethod(Class cls, SEL name, IMP imp, const char *types);

/**
 * @brief   Returns the name of an instance variable.
 * @param   ivar    The instance variable to inspect.
 * @return  A C string containing the instance variable's name.
 */
#define    ivar_getName(ivar)               ivar->ivar_name

/**
 * @brief   Returns the offset of an instance variable.
 * @param   ivar    The instance variable to inspect.
 * @return  The offset of the instance variable in the class layout.
 */
#define    ivar_getOffset(ivar)             ivar->ivar_offset

/**
 * @brief   Returns the type string of an instance variable.
 * @param   ivar    The instance variable to inspect.
 * @return  A C string containing the instance variable's type encoding.
 */
#define    ivar_getTypeEncoding(ivar)       ivar->ivar_type

/**
 * @brief   Returns a string describing a single parameter type of a method.
 * @param   method  The method to inspect.
 * @param   index   The index of the parameter to inspect.
 * @return  A C string describing the type of the parameter at index index, or NULL if method has no parameter index index. You must free the string with free().
 */
char *method_copyArgumentType(Method method, unsigned int index);

/**
 * @brief   Returns a string describing a method's return type.
 * @param   method  The method to inspect.
 * @return  A C string describing the return type. You must free the string with free().
 */
char *method_copyReturnType(Method method);

/**
 * @brief   Returns the name of a method.
 * @param   method  The method to inspect.
 * @return  A pointer of type SEL.
 *
 * @remark  To get the method name as a C string, call sel_getName(method_getName(method)).
 */
#define method_getName(method)              method != nil ? method->method_name : nil

/**
 * @brief   Returns the implementation of a method.
 * @param   method  The method to inspect.
 * @return  A function pointer of type IMP.
 */
#define method_getImplementation(method)    method != nil ? method->method_imp : NULL

/**
 * @brief   Sets the implementation of a method.
 * @param   method  The method to inspect.
 * @param   imp     The new implementation of the method.
 * @return  The previous implementation of the method.
 */
IMP method_setImplementation(Method method, IMP imp);

/**
 * @brief   Returns a string describing a method's parameter and return types.
 * @param   method  The method to inspect.
 * @return  A C string. The string may be NULL.
 */
#define method_getTypeEncoding(method)      method != nil ? method->method_types : nil

/**
 * @brief   Returns the class of an object.
 * @param   object  The object you want to inspect.
 * @return  The class object of which object is an instance, or Nil if object is nil.
 */
#define object_getClass(obj)                obj != nil ? [obj class] : nil

#endif

#endif // __OBJC_SUPPORT_H__
