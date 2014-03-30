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
 * @file    main.mm
 * @brief   Default loader for the Monobjc bridge.
 * @author  Laurent Etiemble <laurent.etiemble@monobjc.net>
 * @date    2009-2014
 */
#import <stdlib.h>
#import <Cocoa/Cocoa.h>

#include <mono/jit/jit.h>
#include <mono/metadata/assembly.h>

#include <monobjc.h>

int main(int argc, char *argv[]) {
    int i, index = 1, debug = 0, ret = 0;
    
    // Flag to debug command line arguments
    char *options = getenv("MONOBJC_ARGS");
    if (options && strlen(options) > 0) {
        debug = 1;
    }
    
    // Create a pool, for the processing
    @autoreleasepool {
        
        // Convert the command line arguments into an array for easy parsing
        if (debug) NSLog(@"Raw arguments");
        NSMutableArray *arguments = [NSMutableArray array];
        for(int i = 0; i < argc; i++) {
            NSString *str = [NSString stringWithCString:argv[i] encoding:[NSString defaultCStringEncoding]];
            [arguments addObject:str];
            if (debug) NSLog(@"%@", str);
        }
        
        // Get the full name of the current executable and extract the last part
        NSString *fullname = [arguments objectAtIndex:0];
        NSString *execname = [[fullname pathComponents] lastObject];
        
        // Scan all the arguments until a "*.exe" is found (or not)
        NSString *argument = nil;
        for(i = 0; i < [arguments count]; i++) {
            NSString *part = [arguments objectAtIndex:i];
            if ([[part pathExtension] isEqualToString:@"exe"]) {
                argument = part;
                break;
            }
        }
        
        // Insert options in the argument array
        options = getenv("MONO_OPTIONS");
        if (options && strlen(options) > 0) {
            if (debug) NSLog(@"Parsing MONO_OPTIONS");
            NSString *str = [NSString stringWithCString:options encoding:[NSString defaultCStringEncoding]];
            NSArray *parts = [str componentsSeparatedByString:@" "];
            for(i = 0; i < [parts count]; i++) {
                str = [parts objectAtIndex:i];
                [arguments insertObject:str atIndex:index];
                index++;
            }
        }
        
        if (!argument) {
            if (debug) NSLog(@"Adding the main assembly");
            // If the main assembly is not found, compute the assembly path in the resources
            // - For command line applications, this is the current folder
            // - For bundled applications, this is the "Contents/Resources" folder.
            NSString *assemblyArgument = [[[NSBundle mainBundle] resourcePath] stringByAppendingPathComponent:[execname stringByAppendingString:@".exe"]];
            [arguments insertObject:assemblyArgument atIndex:index];
        }
        
        // Disabled shared area to avoid /dev/shm access
        // Such access is forbidden when the bundle is sandboxed
        setenv("MONO_DISABLE_SHARED_AREA", "true", 1);
        
        // Build a new argument array
        argc = [arguments count];
        char **newargv = (char **) malloc(sizeof(char *) * (argc + 1));
        if (debug) NSLog(@"Final arguments");
        for (i = 0; i < argc; i++)
        {
            NSString *str = [arguments objectAtIndex:i];
            if (debug) NSLog(@"%@", str);
            newargv[i] = (char *) [str UTF8String];
        }
        newargv[i++] = NULL;
        
        // Call the Mono runtime
        ret = mono_main(argc, newargv);
    }
    
    return ret;
}
