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
 * @file    main.mm
 * @brief   Default loader for the Monobjc bridge.
 * @author  Laurent Etiemble <laurent.etiemble@monobjc.net>
 * @date    2009-2010
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
