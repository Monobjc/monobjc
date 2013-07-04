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
 * @brief   Create an Objective-C block (layout and descriptor) according to the block ABI.
 * @param   function    The function to invoke.
 *
 * @remark  The Block ABI is described in the following references:
 *          @li Language Specification for Blocks http://clang.llvm.org/docs/BlockLanguageSpec.html
 *          @li Block Implementation Specification http://clang.llvm.org/docs/Block-ABI-Apple.html
 */
void *icall_Monobjc_Block_CreateBlock(void *function) {
    if (monobjc_are_blocks_available()) {
        // Create the descriptor first
        Block_descriptor *descriptor = g_new(Block_descriptor, 1);
        descriptor->reserved = 0;
        descriptor->size = sizeof(Block_layout);
        descriptor->copy = NULL;
        descriptor->dispose = NULL;
        
        // Create the layout then
        Block_layout *layout = g_new(Block_layout, 1);
        layout->isa = objc_lookUpClass("__NSGlobalBlock");
        layout->flags = BLOCK_IS_GLOBAL | BLOCK_HAS_DESCRIPTOR;
        layout->reserved = 0;
        layout->invoke = (void (*)(void *, ...)) function;
        layout->descriptor = descriptor;
        
        return layout;
    } else {
        LOG_ERROR(MONOBJC_DOMAIN_GENERAL, "Blocks are not supported !!!");
        return NULL;
    }
}

/**
 * @brief   Destroy an Objective-C block (layout and descriptor).
 * @param   block   The Objective-C block to destroy.
 */
void icall_Monobjc_Block_DestroyBlock(void *block) {
    if (monobjc_are_blocks_available()) {
        // Cast the pointer to access the structure
        Block_layout *layout = (Block_layout *)block;
        if (layout->descriptor &&
            (layout->flags & BLOCK_HAS_DESCRIPTOR) == BLOCK_HAS_DESCRIPTOR) {
            // Destroy the descriptor if present
            g_free(layout->descriptor);
        }
        
        g_free(layout);
    } else {
        LOG_ERROR(MONOBJC_DOMAIN_GENERAL, "Blocks are not supported !!!");
    }
}
