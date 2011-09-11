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
 * @file    blocks.h
 * @brief   Private headers for blocks.
 * @author  Laurent Etiemble <laurent.etiemble@monobjc.net>
 * @date    2009-2011
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
    unsigned long int size;                 /**< @brief  The size of the block (layout and variables. */
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
    /* Imported variables. */
};

#endif // __BLOCKS_H__
