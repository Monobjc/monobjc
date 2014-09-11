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
using System;
using System.Linq;
using System.Collections.Generic;
using Monobjc.Foundation;

namespace Monobjc.AppKit
{
#if MACOSX_10_7
    public partial class NSAnimationContext
    {
        /// <summary>
        /// <para>A completion Block that is called when the animations in the grouping are completed.</para>
        /// <para>Original signature is '@property(copy) void(^completionHandler)(void)'</para>
        /// <para>Available in OS X v10.7 and later.</para>
        /// </summary>
        public virtual void SetCompletionHandler(Action completionHandler)
        {
            if (completionHandler == null) {
                this.CompletionHandler = null;
                return;
            }

            using (var block = Block.Create(completionHandler)) {
                this.CompletionHandler = block;
            }
        }
    }

    public partial class NSDraggingItem
    {
        /// <summary>
        /// <para>An array of Blocks that provide the dragging image components.</para>
        /// <para>Original signature is '@property(copy) NSArray *(^imageComponentsProvider)(void)'</para>
        /// <para>Available in OS X v10.7 and later.</para>
        /// </summary>
        public virtual void SetImageComponentsProvider(Action[] imageComponentsProvider)
        {
            if (imageComponentsProvider == null || imageComponentsProvider.Length == 0) {
                this.ImageComponentsProvider = null;
                return;
            }

            List<Block> blocks = new List<Block>();

            foreach (Action action in imageComponentsProvider) {
                Block block = Block.Create(action);
                blocks.Add(block);
            }

            List<Id> nativeBlocks = blocks.Select(b => new Id(b.NativePointer)).ToList();
            this.ImageComponentsProvider = NSArray.ArrayWithList(nativeBlocks);

            foreach (Block block in blocks) {
                block.Dispose();
            }
        }
    }
#endif
}

