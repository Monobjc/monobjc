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
#import <Cocoa/Cocoa.h>

#include "ffi.h"
#include <sys/mman.h>

typedef void (*FUNCTION)(id receiver, SEL selector);

static void proxy(ffi_cif *cif, void *rvalue, void **avalue, void *userdata) {
    NSString *str = (NSString *)userdata;
    NSLog(@"In closure %@", str);
}

int main(int argc, char **argv) {

    ffi_type *rtype = &ffi_type_void;
    ffi_type *atypes[2];
    atypes[0] = &ffi_type_pointer;
    atypes[1] = &ffi_type_pointer;
    
    ffi_cif *cif = (ffi_cif *) malloc(sizeof(ffi_cif));
    
    ffi_status status = ffi_prep_cif(cif, FFI_DEFAULT_ABI, 2, rtype, atypes);

    ffi_closure *closure = (ffi_closure *) mmap(NULL, sizeof(ffi_closure), PROT_READ | PROT_WRITE, MAP_ANON | MAP_PRIVATE, -1, 0);

    NSString *str = [[NSString alloc] initWithString:@"Test Data"];
    status = ffi_prep_closure(closure, cif, proxy, str);

    int ret = mprotect(closure, sizeof(closure), PROT_READ | PROT_EXEC);
    
    ((FUNCTION) closure)(NULL, NULL);
    
    return 0;
}
