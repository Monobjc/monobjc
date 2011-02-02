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
 * @file    definitions.h
 * @brief   Defines the accessors to get access to the definition of the managed entities (assemblies, images, classes, methods, etc).
 * @author  Laurent Etiemble <laurent.etiemble@monobjc.net>
 * @date    2009-2010
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
