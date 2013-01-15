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
 * @file    monobjc.mm
 * @brief   Contains exposed functions for the bridging library.
 * @author  Laurent Etiemble <laurent.etiemble@monobjc.net>
 * @date    2009-2012
 */
#include <dlfcn.h>
#include "icalls.h"
#include "glib.h"
#include "logging.h"
#include "monobjc.h"
#include "threading.h"

#pragma mark ----- Implementation -----

/**
 * @brief   Balking flag for initialization.
 */
static boolean_t initialized = false;

void monobjc_install_bridge() {
    // Avoid multiple initialization
    if (initialized) {
        return;
    }
    initialized = true;
    
    // Install the logging first
    monobjc_setup_logging();
    
    LOG_INFO(MONOBJC_DOMAIN_GENERAL, "Setting up the bridge...");
    
    LOG_INFO(MONOBJC_DOMAIN_GENERAL, "Installing internal calls...");
    
    // Output the addition code
    #undef ICALL
    #define ICALL(KEY, RTYPE, NAME, PARAMETERS)    mono_add_internal_call(ICALLTYPE "::" KEY, (void *) NAME);
    #include "icalls.def"
    
    LOG_INFO(MONOBJC_DOMAIN_GENERAL, "Internal calls installed");
}

void *monobjc_load_framework(const char *framework) {
    void *handle = NULL;
    
    // Install the bridge before loading the framework
    monobjc_install_bridge();
    
    LOG_DEBUG(MONOBJC_DOMAIN_GENERAL, "Loading framework '%s'", framework);
    
    // We set an auto-release pool for the scope
    NSAutoreleasePool *pool = [[NSAutoreleasePool alloc] init];

    // Convert the name to ease formatting
    NSString *framework_name = [NSString stringWithUTF8String:framework];
    
    NSArray *paths = [NSArray arrayWithObjects:
                      // Probing in system scope
                      [NSString stringWithFormat:@"/System/Library/Frameworks/%@.framework/%@", framework_name, framework_name],
                      // Probing in library scope
                      [NSString stringWithFormat:@"/Library/Frameworks/%@.framework/%@", framework_name, framework_name],
                      // Probing in user scope
                      [NSString stringWithFormat:@"~/Library/Frameworks/%@.framework/%@", framework_name, framework_name],
                      // Probing in private scope
                      [NSString stringWithFormat:@"%@/Frameworks/%@.framework/%@", [[NSBundle mainBundle] bundlePath], framework_name, framework_name],
                      nil];
    
    // Iterate over each path
    for(NSUInteger i = 0; i < [paths count]; i++) {
        NSString *path = [paths objectAtIndex:i];
        if ([[NSFileManager defaultManager] fileExistsAtPath:path]) {
            handle = dlopen([path UTF8String], RTLD_LAZY);
            if (handle) {
                break;
            }
            char *error_message = dlerror();
            LOG_WARNING(MONOBJC_DOMAIN_GENERAL, "Failed to load '%s' framework\n%s", framework, error_message);
        }
    }
    
bail:
    // Destroy the pool
    [pool release];
    
    return handle;
}

void *monobjc_get_symbol(const char *framework, const char *name) {
    void *symbol = NULL;

    LOG_DEBUG(MONOBJC_DOMAIN_GENERAL, "Loading symbol '%s' in framework '%s'", name, framework);
    
    // Load the framework
    void *handle = monobjc_load_framework(framework);
    if (handle) {
        // Locate the address of the symbol
        symbol = dlsym(handle, name);
        dlclose(handle);
    }
    
    return symbol;
}
