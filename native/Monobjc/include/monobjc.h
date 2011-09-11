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
 * @file    monobjc.h
 * @brief   Contains exposed functions for the bridging library.
 * @author  Laurent Etiemble <laurent.etiemble@monobjc.net>
 * @date    2009-2011
 */
#ifndef __MONOBJC_H__
#define __MONOBJC_H__

#ifdef  __cplusplus
extern "C" {
#endif

/**
 * @brief   Entry point for the installation of the bridge.
 *          This function installs the logging engine and
 *          add the internals calls for the bridge's type.
 */
__attribute__((visibility("default")))
void monobjc_install_bridge();

/**
 * @brief   Loads a Mac OS framework bundle by searching for the common places.
 * @param   framework   The name of the framework to load.
 * @return  A handle to the framework bundle; NULL if the framework bundle cannot be found.
 */
__attribute__((visibility("default")))
void *monobjc_load_framework(const char *framework);

/**
 * @brief   Looks up a symbol into the given Mac OS framework bundle.
 * @param   framework   The name of the framework containing the symbol.
 * @param   name        The name of the symbol to lookup.
 * @return  A handle to the symbol; NULL if the framework or the symbol cannot be found.
 */
__attribute__((visibility("default")))
void *monobjc_get_symbol(const char *framework, const char *name);

/**
 * @brief   Entry point for Mono runtime. This function is
 *          not found anywhere, so we put the declaration here.
 * @param   argc    The arguments' count.
 * @param   argv    The arguments' values.
 * @return  The result of the execution.
 */
int mono_main(int argc, char* argv[]); 

#ifdef  __cplusplus
}
#endif

#endif // __MONOBJC_H__
