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
 * @file    main.mm
 * @brief   Default loader for the Monobjc bridge.
 * @author  Laurent Etiemble <laurent.etiemble@monobjc.net>
 * @date    2009-2012
 */
#import <stdlib.h>
#import <Cocoa/Cocoa.h>

#include <mono/jit/jit.h>
#include <mono/metadata/assembly.h>

#include <monobjc.h>

int main(int argc, char *argv[]) {
    int i, index = 1, debug = 0;
    
    // Flag to debug command line arguments
    char *options = getenv("MONOBJC_ARGS");
    if (options && strlen(options) > 0) {
        debug = 1;
    }

    // Create a pool, for the processing
    NSAutoreleasePool *pool = [[NSAutoreleasePool alloc] init];

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

    // Disabled shared area
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
    int ret = mono_main(argc, newargv);

    [pool release];

    return ret;
}
