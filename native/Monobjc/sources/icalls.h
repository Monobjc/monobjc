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
 * @file    icalls.h
 * @brief   Contains definitions for internal calls.
 * @author  Laurent Etiemble <laurent.etiemble@monobjc.net>
 * @date    2009-2010
 */
#ifndef __ICALLS_H__
#define __ICALLS_H__

#include "enumerations.h"

#undef ICALL
/** @brief  Print the internal call signatures. */
#define ICALL(KEY, RTYPE, NAME, PARAMETERS)    RTYPE NAME PARAMETERS;
#include "icalls.def"

#endif // __ICALLS_H__
