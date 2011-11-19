//
// This file is part of Monobjc, a .NET/Objective-C bridge
// Copyright (C) 2007-2011 - Laurent Etiemble
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
using System.Collections.Generic;

namespace Monobjc
{
#if MACOSX_10_6
    partial class ObjectiveCRuntime
    {
        // Map that store block classes, according to the delegate that they wrap.
        private static readonly IDictionary<Type, Type> BLOCK_TYPES = new Dictionary<Type, Type>(16);

        /// <summary>
        ///   Creates a block with the given delegate.
        /// </summary>
        /// <param name = "delegate">The @delegate to wrap in the block.</param>
        /// <returns>A new <see cref = "Block" /> instance that wraps the delegate.</returns>
        public static Block CreateBlock(Delegate @delegate)
        {
            Type delegateType = @delegate.GetType();
            Type blockProxyType;
            // Search for an existing block proxy
            lock (BLOCK_TYPES)
            {
                if (!BLOCK_TYPES.TryGetValue(delegateType, out blockProxyType))
                {
                    blockProxyType = BlockGenerator.DefineBlockProxy(delegateType);
                    BLOCK_TYPES[delegateType] = blockProxyType;
                }
            }
            // Create a new instance of the block proxy
            return (Block) Activator.CreateInstance(blockProxyType, @delegate);
        }
    }
#endif
}