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
 * @file    support-mono.h
 * @brief   Contains functions to retrieve Mono entities definitions.
 * @author  Laurent Etiemble <laurent.etiemble@monobjc.net>
 * @date    2009-2012
 */
#ifndef __SUPPORT_MONO_H__
#define __SUPPORT_MONO_H__

/**
 * @brief   Check the expression related to the given argument.
 * @param   arg     Argument to check.
 * @param   expr    Expression to evaluate.
 */
#define MONOBJC_CHECK_ARG(arg, expr)                    \
if (!(expr)) {                                          \
    MonoException *ex;                                  \
    char *msg;                                          \
    asprintf(&msg, ASSERTION_FAILED, #expr);            \
    ex = mono_get_exception_argument(#arg, msg);        \
    g_free(msg);                                        \
    mono_raise_exception (ex);                          \
}

/**
 * @brief   Check that the given argument is not NULL.
 * @param   arg     Argument to check.
 */
#define MONOBJC_CHECK_ARG_NULL(arg)                     \
    if (!arg) {                                         \
        MonoException *ex;                              \
        ex = mono_get_exception_argument_null(#arg);    \
        mono_raise_exception (ex);                      \
    }

/**
 * @brief   Retrieve the assembly.
 * @param   name    The name of the assembly.
 * @return  The assembly object.
 */
MonoAssembly *monobjc_define_assembly(const char *name);

/**
 * @brief   Retrieve the image of an assembly.
 * @param   assembly    The assembly.
 * @return  The image of the assembly.
 */
MonoImage *monobjc_define_image(MonoAssembly *assembly);

/**
 * @brief   Retrieve the definition of a class.
 * @param   image       The image containing the class.
 * @param   name_space  The namespace of the class.
 * @param   name        The name of the class.
 * @return  The class object.
 */
MonoClass *monobjc_define_class(MonoImage *image, const char *name_space, const char *name);

/**
 * @brief    Retrieve the definition of a method.
 * @param    klass          The class containing the method.
 * @param    name           The name of the method.
 * @param    param_count    The number of parameters.
 * @return  The method object ready to be invoked.
 */
MonoMethod *monobjc_define_method(MonoClass *klass, const char *name, int param_count);

/**
 * @brief   Retrieve the definition of a method by using a description.
 * @param   klass   The class containing the method.
 * @param   name    The description of the method.
 * @return  The method object ready to be invoked.
 */
MonoMethod *monobjc_define_method_by_desc(MonoClass *klass, const char *name);

/**
 * @brief   Retrieve the definition of a field.
 * @param   klass   The class containing the field.
 * @param   name    The name of the field.
 * @return  The class field.
 */
MonoClassField *monobjc_define_field(MonoClass *klass, const char *name);

/**
 * @brief   Retrieve the definition of an internal call.
 * @param   klass       The class containing the internal call.
 * @param   name        The name of the internal call.
 * @param   param_count The number of parameters.
 * @return  A function pointer to the internal call.
 */
void *monobjc_define_internal_call(MonoClass *klass, const char *name, int param_count);

/**
 * @brief   Retrieve the definition of an internal call by using a description.
 * @param   klass   The class containing the internal call.
 * @param   name    The description of the internal call.
 * @return  A function pointer to the internal call.
 */
void *monobjc_define_internal_call_by_desc(MonoClass *klass, const char *name);

/**
 * @brief   TODO
 */
MonoMethod *monobjc_get_wrapper_constructor(MonoClass *klass);

/**
 * @brief   Test a type to know if it is an interface.
 * @param   type    The type to test.
 * @return  TRUE is the type is an interface, FALSE otherwise.
 */
boolean_t monobjc_type_is_interface(MonoType *type);

#endif // __SUPPORT_MONO_H__
