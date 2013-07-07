//
// This file is part of Monobjc, a .NET/Objective-C bridge
// Copyright (C) 2007-2013 - Laurent Etiemble
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
 * @file    icalls-Monobjc.Block.mm
 * @brief   Contains the internal calls for the Monobjc.Block type.
 * @author  Laurent Etiemble <laurent.etiemble@monobjc.net>
 * @date    2009-2013
 */
#include "blocks.h"
#include "icalls.h"
#include "logging.h"
#include "support-mono.h"
#include "support-os.h"

#pragma mark ----- Internal Calls -----

/**
 * @brief   Block copy helper that copies the GC handles when a block copy is performed.
 * @param   dst     The destination layout.
 * @param   src     The source layout.
 *
 * @remark  When copying GC handles, we assume that the objects are never collected since they were pinned.
 *          So we create new GC handles on them without testing for NULL.
 */
static void __Block_copy_helper(void *dst, void *src) {
    MonoObject *obj;
    Block_layout *dst_layout = (Block_layout *) dst;
    Block_layout *src_layout = (Block_layout *) src;
    
    if (src_layout->gchandle_thunk != 0) {
        obj = mono_gchandle_get_target(src_layout->gchandle_thunk);
        dst_layout->gchandle_thunk = mono_gchandle_new(obj, true);
    } else {
        dst_layout->gchandle_thunk = 0;
    }
    
    if (src_layout->gchandle_target != 0) {
        obj = mono_gchandle_get_target(src_layout->gchandle_target);
        dst_layout->gchandle_target = mono_gchandle_new(obj, true);
    } else {
        dst_layout->gchandle_target = 0;
    }
}

/**
 * @brief   Block copy helper that frees the GC handles when a block disposal is performed.
 * @param   src     The source layout.
 */
static void __Block_dispose_helper(void *src) {
    Block_layout *src_layout = (Block_layout *) src;
    
    if (src_layout->gchandle_thunk != 0) {
        mono_gchandle_free(src_layout->gchandle_thunk);
    }
    if (src_layout->gchandle_target != 0) {
        mono_gchandle_free(src_layout->gchandle_target);
    }
}

/**
 * @brief   Helper function to create the shared block descriptor.
 */
static Block_descriptor *__Block_create_shared_descriptor() {
    Block_descriptor *descriptor = g_new(Block_descriptor, 1);
    descriptor->reserved = 0;
    descriptor->size = sizeof(Block_layout);
    descriptor->copy = __Block_copy_helper;
    descriptor->dispose = __Block_dispose_helper;
    return descriptor;
}

/**
 * @brief   Create an Objective-C block (layout and descriptor) according to the block ABI.
 * @param   thunk_delegate  The Mono object (a System.Delegate instance) that will be called when the block is evaluated.
 * @param   target_delegate The Mono object (a System.Delegate instance) that will be executed when the block is evaluated.
 * @param   thunk_function  The function pointer derived from the thunk delegate.
 *
 * @remark  Blocks are typed as stack block even if they are created on the heap. By doing this:
 *          @li we ensure that the block is copied if it needs to be retained during a method call.
 *          @li we can safely destroy the block after the method call, even when the block is used in an asynchronous way.
 *
 * @remark  The Block API/ABI are described in the following references:
 *          @li Language Specification for Blocks http://clang.llvm.org/docs/BlockLanguageSpec.html
 *          @li Block Implementation Specification http://clang.llvm.org/docs/Block-ABI-Apple.html
 */
void *icall_Monobjc_Block_CreateBlock(MonoObject *thunk_delegate, MonoObject *target_delegate, void *thunk_function) {
    if (monobjc_are_blocks_available()) {
        // Initialize the shared descriptor once.
        // This descriptor will be used by all the block instances.
        static Block_descriptor *shared_descriptor = __Block_create_shared_descriptor();
        
        // Create the layout then
        Block_layout *layout = g_new(Block_layout, 1);
        layout->isa = objc_lookUpClass("__NSStackBlock");
        layout->flags = BLOCK_HAS_DESCRIPTOR | BLOCK_HAS_COPY_DISPOSE;
        layout->reserved = 0;
        layout->invoke = (void (*)(void *, ...)) thunk_function;
        layout->descriptor = shared_descriptor;
        layout->gchandle_thunk = (thunk_delegate != NULL) ? mono_gchandle_new(thunk_delegate, true) : 0;
        layout->gchandle_target = (target_delegate != NULL) ? mono_gchandle_new(target_delegate, true) : 0;
        
        return layout;
    } else {
        LOG_ERROR(MONOBJC_DOMAIN_GENERAL, "Blocks are not supported !!!");
        return NULL;
    }
}

/**
 * @brief   Destroy an Objective-C block layout.
 * @param   block   The Objective-C block to destroy.
 */
void icall_Monobjc_Block_DestroyBlock(void *block) {
    if (monobjc_are_blocks_available()) {
        // Cast the pointer to access the structure
        Block_layout *layout = (Block_layout *)block;
        g_free(layout);
    } else {
        LOG_ERROR(MONOBJC_DOMAIN_GENERAL, "Blocks are not supported !!!");
    }
}
