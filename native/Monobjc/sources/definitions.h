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
 * @file    definitions.h
 * @brief   Defines the accessors to get access to the definition of the managed entities (assemblies, images, classes, methods, etc).
 * @author  Laurent Etiemble <laurent.etiemble@monobjc.net>
 * @date    2009-2013
 */
#ifndef __DEFINITIONS_H__
#define __DEFINITIONS_H__

#undef DEFINITION
/** @brief  Print the accessors for definitions */
#define DEFINITION(TYPE, NAME)    TYPE monobjc_get_##NAME();
#include "definitions.def"

/**
 * @brief   Create the various definitions of the managed entities (assemblies, images, classes, methods, etc).
 */
void monobjc_create_definitions();

/**
 * @brief   Destroy the various definitions of the managed entities (assemblies, images, classes, methods, etc).
 */
void monobjc_destroy_definitions();

#endif // __DEFINITIONS_H__
