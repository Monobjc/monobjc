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
 * @file    blocks.mm
 * @brief   Defines some helper methods for block debugging.
 * @author  Laurent Etiemble <laurent.etiemble@monobjc.net>
 * @date    2013-2014
 */
#include "blocks.h"

const char *monobjc_block_dump(const void *block) {
    struct Block_layout *closure = (struct Block_layout *)block;
    static char buffer[512];
    char *cp = buffer;
    if (closure == NULL) {
        sprintf(cp, "NULL passed to _Block_dump\n");
        return buffer;
    }
    if (! (closure->flags & BLOCK_HAS_DESCRIPTOR)) {
        printf("Block compiled by obsolete compiler, please recompile source for this Block\n");
        exit(1);
    }
    cp += sprintf(cp, "^%p (new layout) =\n", (void *)closure);
    if (closure->isa == NULL) {
        cp += sprintf(cp, "isa: NULL\n");
    }
    cp += sprintf(cp, "isa: %s\n", class_getName((Class) closure->isa));
    cp += sprintf(cp, "flags:");
    if (closure->flags & BLOCK_HAS_DESCRIPTOR) {
        cp += sprintf(cp, " HASDESCRIPTOR");
    }
    if (closure->flags & BLOCK_NEEDS_FREE) {
        cp += sprintf(cp, " FREEME");
    }
    if (closure->flags & BLOCK_IS_GC) {
        cp += sprintf(cp, " ISGC");
    }
    if (closure->flags & BLOCK_HAS_COPY_DISPOSE) {
        cp += sprintf(cp, " HASHELP");
    }
    if (closure->flags & BLOCK_HAS_CTOR) {
        cp += sprintf(cp, " HASCTOR");
    }
    cp += sprintf(cp, "\nrefcount: %u\n", closure->flags & BLOCK_REFCOUNT_MASK);
    cp += sprintf(cp, "invoke: %p\n", (void *)(uintptr_t)closure->invoke);
    {
        struct Block_descriptor *dp = closure->descriptor;
        cp += sprintf(cp, "descriptor: %p\n", (void *)dp);
        cp += sprintf(cp, "descriptor->reserved: %lu\n", dp->reserved);
        cp += sprintf(cp, "descriptor->size: %lu\n", dp->size);
        
        if (closure->flags & BLOCK_HAS_COPY_DISPOSE) {
            cp += sprintf(cp, "descriptor->copy helper: %p\n", (void *)(uintptr_t)dp->copy);
            cp += sprintf(cp, "descriptor->dispose helper: %p\n", (void *)(uintptr_t)dp->dispose);
        }
    }
    return buffer;
}
