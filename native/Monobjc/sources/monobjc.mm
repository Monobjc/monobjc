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
 * @file    monobjc.mm
 * @brief   Contains exposed functions for the bridging library.
 * @author  Laurent Etiemble <laurent.etiemble@monobjc.net>
 * @date    2009-2014
 */
#include <dlfcn.h>
#include "domain.h"
#include "icalls.h"
#include "glib.h"
#include "logging.h"
#include "lifecycle.h"
#include "monobjc.h"
#include "threading.h"

static void __monobjc_init_mutexes() {
    // Required to be re-entrant
    monobjc_mutex_init(&__DOMAINS_MUTEX, TRUE);
    // Not required to be re-entrant
    monobjc_mutex_init(&__IMPLEMENTATIONS_MUTEX, FALSE);
}

static void __monobjc_destroy_mutexes() {
    monobjc_mutex_destroy(&__DOMAINS_MUTEX);
    monobjc_mutex_destroy(&__IMPLEMENTATIONS_MUTEX);
}

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
    
    // Create global mutexes and cleanup on exit
    __monobjc_init_mutexes();
    atexit(&__monobjc_destroy_mutexes);
    
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
    @autoreleasepool {
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
            NSString *path = [[paths objectAtIndex:i] stringByExpandingTildeInPath];
            if ([[NSFileManager defaultManager] fileExistsAtPath:path]) {
                handle = dlopen([path UTF8String], RTLD_LAZY);
                if (handle) {
                    break;
                }
                char *error_message = dlerror();
                LOG_WARNING(MONOBJC_DOMAIN_GENERAL, "Failed to load '%s' framework\n%s", framework, error_message);
            }
        }
    }
    
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
