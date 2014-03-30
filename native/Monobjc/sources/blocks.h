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
 * @file    blocks.h
 * @brief   Private headers for blocks.
 * @author  Laurent Etiemble <laurent.etiemble@monobjc.net>
 * @date    2009-2014
 */
#ifndef __BLOCKS_H__
#define __BLOCKS_H__

/** @brief  The flags applicable to a block. */
enum {
    BLOCK_REFCOUNT_MASK =     (0xffff),     /**< @brief  Mask used to store the reference count. */
    BLOCK_NEEDS_FREE =        (1 << 24),    /**< @brief  The block needs to be freed. */
    BLOCK_HAS_COPY_DISPOSE =  (1 << 25),    /**< @brief  The block has a copy/dispose helper functions. */
    BLOCK_HAS_CTOR =          (1 << 26),    /**< @brief  Helpers have C++ code. */
    BLOCK_IS_GC =             (1 << 27),    /**< @brief  The block can be collected. */
    BLOCK_IS_GLOBAL =         (1 << 28),    /**< @brief  The block is global. */
    BLOCK_HAS_DESCRIPTOR =    (1 << 29)     /**< @brief  The block has a descriptor. */
};

/** @brief  The block descriptor. */
struct Block_descriptor {
    unsigned long int reserved;             /**< @brief  Reserved. */
    unsigned long int size;                 /**< @brief  The size of the block (layout and variables). */
    void (*copy)(void *dst, void *src);     /**< @brief  The copy helper function. */
    void (*dispose)(void *);                /**< @brief  The dispose helper function. */
};

/** @brief  The block layout. */
struct Block_layout {
    void *isa;                              /**< @brief  Block's class. */
    int flags;                              /**< @brief  Block's flags. */
    int reserved;                           /**< @brief  Reserved. */
    void (*invoke)(void *, ...);            /**< @brief  The block's function. */
    struct Block_descriptor *descriptor;    /**< @brief  The block's descriptor. */
    /* Imported Variables */
    uint32_t gchandle_thunk;                /**< @brief  The thunk delegate pinned GC handle. */
    uint32_t gchandle_target;               /**< @brief  The target delegate pinned GC handle. */
};

/**
 * @brief   Dump the block layout. Useful for debugging purpose.
 * @param   block   The block to dump.
 *
 * @remark  This function is for debug purpose.
 */
const char *monobjc_block_dump(const void *block);

#endif // __BLOCKS_H__
