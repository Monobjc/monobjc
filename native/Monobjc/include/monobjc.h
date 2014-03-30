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
 * @file    monobjc.h
 * @brief   Contains exposed functions for the bridging library.
 * @author  Laurent Etiemble <laurent.etiemble@monobjc.net>
 * @date    2009-2014
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
