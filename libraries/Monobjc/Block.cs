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
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace Monobjc
{
#if MACOSX_10_6 && HAVE_BLOCK_SUPPORT
    /// <summary>
    ///   <para>Managed implementation of the blocks as defined in the Language Specification for Blocks[1].
    ///     Even if the implementation strictly follows the Block Implementation Specification[2], it is restricted to global block for the moment.</para>
    ///   <para>The block bridging allow a delegate function or action to be marshalled as a native block.
    ///     Its implementation points to a proxy invoker that will forward the native block invocation to the delegate function or action.</para>
    ///   <para>Currently, any delegate can be passed to create a block. For example:</para>
    ///   <list type = "table">
    ///     <listheader>
    ///       <term>Delegate</term>
    ///       <description>Equivalent block signature</description>
    ///     </listheader>
    ///     <item>
    ///       <term><see cref = "Action" /></term>
    ///       <description>void (^)()</description>
    ///     </item>
    ///     <item>
    ///       <term><see cref = "Action{T1,T2,T3}" /></term>
    ///       <description>void (^)(T1, T2, T3)</description>
    ///     </item>
    ///     <item>
    ///       <term><see cref = "Func{TResult}" /></term>
    ///       <description>TResult (^)()</description>
    ///     </item>
    ///     <item>
    ///       <term><see cref = "Func{T1,T2,TResult}" /></term>
    ///       <description>TResult (^)(T1, T2)</description>
    ///     </item>
    ///   </list>
    ///   <para>[1] Language Specification for Blocks (http://clang.llvm.org/docs/BlockLanguageSpec.txt)</para>
    ///   <para>[2] Block Implementation Specification (http://clang.llvm.org/docs/BlockImplementation.txt)</para>
    /// </summary>
    public abstract class Block : IDisposable
    {
        /// <summary>
        ///   Native pointer to the block layout structure
        /// </summary>
        private IntPtr layout;

        /// <summary>
        ///   Initializes a new instance of the <see cref = "Block" /> class.
        /// </summary>
        /// <param name = "invoker">The invoker.</param>
        protected Block(Delegate invoker)
        {
            this.Invoker = invoker;
        }

        /// <summary>
        ///   Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        ///   Releases unmanaged resources and performs other cleanup operations before the
        ///   <see cref = "Block" /> is reclaimed by garbage collection.
        /// </summary>
        ~Block()
        {
            this.Dispose(false);
        }

        /// <summary>
        ///   Releases unmanaged and - optionally - managed resources
        /// </summary>
        /// <param name = "disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (this.layout != IntPtr.Zero)
            {
                DestroyBlock(this.layout);
                this.layout = IntPtr.Zero;
            }
        }

        /// <summary>
        ///   Gets the invoked delegate.
        /// </summary>
        /// <value>The invoke.</value>
        public Delegate Invoker { get; private set; }

        /// <summary>
        ///   Gets the block invoker.
        /// </summary>
        /// <value>The block invoker.</value>
        public abstract Delegate BlockInvoker { get; }

        /// <summary>
        ///   Gets the native pointer representing this block instance.
        /// </summary>
        /// <value>The native pointer.</value>
        public IntPtr NativePointer
        {
            get
            {
                if (this.layout == IntPtr.Zero)
                {
                    // Create a block layout for a global block, with descriptor.
                    // This block will invoke a managed method through a delegate (marhsaled as a function pointer)
                    IntPtr function = Marshal.GetFunctionPointerForDelegate(this.BlockInvoker);
                    this.layout = CreateBlock(function);
                }

                return this.layout;
            }
        }

        /// <summary>
        ///   Returns a <see cref = "String" /> that represents this instance.
        /// </summary>
        /// <returns>
        ///   A <see cref = "String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            // Output this block instance in a Objective-C way:   ReturnType (^)(ParameterType1, ..., ParameterTypeN)
            MethodInfo mi = this.Invoker.GetType().GetMethod("Invoke");

            StringBuilder builder = new StringBuilder();
            builder.Append(mi.ReturnType);
            builder.Append(" (^)(");
            builder.Append(String.Join(", ", mi.GetParameters().Select(p => p.ParameterType.ToString()).ToArray()));
            builder.Append(")");
            return builder.ToString();
        }

        /// <summary>
        ///   Create the native structure of the block by using the given delegate function pointer.
        /// </summary>
        /// <param name = "function">The delegate as function pointer.</param>
        /// <returns>A pointer to the native block's structure.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern IntPtr CreateBlock(IntPtr function);

        /// <summary>
        ///   Destroy the native structure of the block.
        /// </summary>
        /// <param name = "layout">A pointer to the native block's structure to destroy.</param>
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        private static extern void DestroyBlock(IntPtr layout);
    }
#endif
}