//
// This file is part of Monobjc, a .NET/Objective-C bridge
// Copyright (C) 2007-2014 - Laurent Etiemble
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
 * @file    definitions.mm
 * @brief   Defines the accessors to get access to the definition of the managed entities (assemblies, images, classes, methods, etc).
 * @author  Laurent Etiemble <laurent.etiemble@monobjc.net>
 * @date    2009-2014
 */
#include "constants.h"
#include "definitions.h"
#include "domain.h"
#include "logging.h"
#include "support-mono.h"
#include "support-os.h"

#pragma mark ----- Implementation -----

void monobjc_create_definitions() {
    LOG_INFO(MONOBJC_DOMAIN_GENERAL, "Create definitions");
    
    MonobjcDomainData *data = monobjc_get_domain_data(mono_domain_get());
    
    // Assemblies
    data->Monobjc_assembly = monobjc_define_assembly(MONOBJC);
    
    // Images
    data->Monobjc_image = monobjc_define_image(data->Monobjc_assembly);
    
    // Classes
    data->Monobjc_Block_class               = monobjc_define_class(data->Monobjc_image, MONOBJC, "Block");
    data->Monobjc_Class_class               = monobjc_define_class(data->Monobjc_image, MONOBJC, "Class");
    data->Monobjc_Id_class                  = monobjc_define_class(data->Monobjc_image, MONOBJC, "Id");
    data->Monobjc_IManagedWrapper_interface = monobjc_define_class(data->Monobjc_image, MONOBJC, "IManagedWrapper");
    data->Monobjc_ObjectiveCRuntime_class   = monobjc_define_class(data->Monobjc_image, MONOBJC, "ObjectiveCRuntime");
    data->Monobjc_TypeHelper_class          = monobjc_define_class(data->Monobjc_image, MONOBJC_UTILS, "TypeHelper");
        
    // Types
    data->Monobjc_Block_type    = mono_class_get_type(data->Monobjc_Block_class);
    data->Monobjc_Class_type    = mono_class_get_type(data->Monobjc_Class_class);
    data->Monobjc_Id_type       = mono_class_get_type(data->Monobjc_Id_class);
    data->System_Void_type      = mono_class_get_type(mono_get_void_class());
    
    // Constructors
    data->Monobjc_Class_ctor_method = monobjc_define_method_by_desc(data->Monobjc_Class_class, "Class::.ctor(intptr)");
    data->Monobjc_Id_ctor_method    = monobjc_define_method_by_desc(data->Monobjc_Id_class, "Id::.ctor(intptr)");
    
    // Methods
    data->Monobjc_Block_get_NativePointer_method            = data->Monobjc_Block_class ?
	                                                          monobjc_define_method(data->Monobjc_Block_class, "get_NativePointer", 0) :
															  NULL;
    data->Monobjc_Class_GetAttributeName_method             = monobjc_define_method(data->Monobjc_Class_class, "GetAttributeName", 1);
    data->Monobjc_Class_get_WrapperType_method              = monobjc_define_method(data->Monobjc_Class_class, "get_WrapperType", 0);
    data->Monobjc_Id_get_NativePointer_method               = monobjc_define_method(data->Monobjc_Id_class, "get_NativePointer", 0);
    data->Monobjc_ObjectiveCRuntime_GenerateWrapper_method  = monobjc_define_method(data->Monobjc_ObjectiveCRuntime_class, "GenerateWrapper", 1);
    data->Monobjc_ObjectiveCRuntime_UnWrap_method           = monobjc_define_method(data->Monobjc_ObjectiveCRuntime_class, "UnWrap", 1);
    data->Monobjc_ObjectiveCRuntime_Wrap_method             = monobjc_define_method(data->Monobjc_ObjectiveCRuntime_class, "Wrap", 1);
    data->Monobjc_TypeHelper_GetUnderlyingTypeHandle_method = monobjc_define_method(data->Monobjc_TypeHelper_class, "GetUnderlyingTypeHandle", 2);
    data->Monobjc_TypeHelper_GetConverterHandle_method      = monobjc_define_method(data->Monobjc_TypeHelper_class, "GetConverterHandle", 2);
}

void monobjc_destroy_definitions() {
    LOG_INFO(MONOBJC_DOMAIN_GENERAL, "Destroy definitions");
    
    MonobjcDomainData *data = monobjc_get_domain_data(mono_domain_get());
    
    #undef DEFINITION
    /** @brief  Print the fields for definitions */
    #define DEFINITION(TYPE, NAME)    data -> NAME = NULL;
    #include "definitions.def"
}

#undef DEFINITION
/** @brief  Print the accessors for definitions */
#define DEFINITION(TYPE, NAME)    TYPE monobjc_get_##NAME() { return monobjc_get_domain_data(mono_domain_get()) -> NAME; }
#include "definitions.def"
