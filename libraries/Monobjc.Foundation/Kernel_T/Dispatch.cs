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

using Monobjc;
using Monobjc.Foundation;
using System;
using System.CodeDom.Compiler;
using System.Globalization;
using System.Runtime.InteropServices;

namespace Monobjc.Kernel
{
    public static partial class Dispatch
    {
#if MACOSX_10_6
        /// <summary>
        /// <para>Enqueue a block for execution at the specified time.</para>
        /// <para>Original signature is 'void dispatch_after(  dispatch_time_t when,  dispatch_queue_t queue,  dispatch_block_t block);'</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        /// <param name="when">MISSING</param>
        /// <param name="queue">MISSING</param>
        /// <param name="block">MISSING</param>
        public static void dispatch_after(long when, IntPtr queue, Action block)
        {
            Block __local1 = ObjectiveCRuntime.CreateBlock(block);
            dispatch_after_Inner(when, queue, __local1);
            __local1.Dispose();
        }

        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_after")]
        private static extern void dispatch_after_Inner(long when, IntPtr queue, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (BlockMarshaler))] Block block);

#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>Enqueues an application-defined function for execution at a specified time.</para>
        /// <para>Original signature is 'void dispatch_after_f(  dispatch_time_t when,  dispatch_queue_t queue,  void *context,  dispatch_function_t work);'</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        /// <param name="when">MISSING</param>
        /// <param name="queue">MISSING</param>
        /// <param name="context">MISSING</param>
        /// <param name="work">MISSING</param>
        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_after_f")]
        public static extern void dispatch_after_f(long when, IntPtr queue, IntPtr context, dispatch_function_t work);

#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>Submits a block to a dispatch queue for multiple invocations.</para>
        /// <para>Original signature is 'void dispatch_apply(  size_t iterations,  dispatch_queue_t queue,  void (^block)(  size_t));'</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        /// <param name="iterations">MISSING</param>
        /// <param name="queue">MISSING</param>
        /// <param name="block">MISSING</param>
        public static void dispatch_apply(NSUInteger iterations, IntPtr queue, Action<NSUInteger> block)
        {
            if (ObjectiveCRuntime.Is64Bits)
            {
                Block __local1 = ObjectiveCRuntime.CreateBlock(block);
                dispatch_apply_64((ulong) iterations, queue, __local1);
                __local1.Dispose();
            }
            else
            {
                Block __local1 = ObjectiveCRuntime.CreateBlock(block);
                dispatch_apply_32((uint) iterations, queue, __local1);
                __local1.Dispose();
            }
        }

        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_apply")]
        private static extern void dispatch_apply_64(ulong iterations, IntPtr queue, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (BlockMarshaler))] Block block);

        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_apply")]
        private static extern void dispatch_apply_32(uint iterations, IntPtr queue, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (BlockMarshaler))] Block block);

#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>Submits an application-defined function to a dispatch queue for multiple invocations.</para>
        /// <para>Original signature is 'void dispatch_apply_f(  size_t iterations,  dispatch_queue_t queue,  void *context,  void (*work)(void *, size_t));'</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        /// <param name="iterations">MISSING</param>
        /// <param name="queue">MISSING</param>
        /// <param name="context">MISSING</param>
        /// <param name="work">MISSING</param>
        public static void dispatch_apply_f(NSUInteger iterations, IntPtr queue, IntPtr context, dispatch_function_tc work)
        {
            if (ObjectiveCRuntime.Is64Bits)
            {
                dispatch_apply_f_64((ulong) iterations, queue, context, work);
            }
            else
            {
                dispatch_apply_f_32((uint) iterations, queue, context, work);
            }
        }

        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_apply_f")]
        private static extern void dispatch_apply_f_64(ulong iterations, IntPtr queue, IntPtr context, dispatch_function_tc work);

        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_apply_f")]
        private static extern void dispatch_apply_f_32(uint iterations, IntPtr queue, IntPtr context, dispatch_function_tc work);

#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>Submits a block for asynchronous execution on a dispatch queue and returns immediately.</para>
        /// <para>Original signature is 'void dispatch_async(  dispatch_queue_t queue,  dispatch_block_t block);'</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        /// <param name="queue">MISSING</param>
        /// <param name="block">MISSING</param>
        public static void dispatch_async(IntPtr queue, Action block)
        {
            Block __local1 = ObjectiveCRuntime.CreateBlock(block);
            dispatch_async_Inner(queue, __local1);
            __local1.Dispose();
        }

        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_async")]
        private static extern void dispatch_async_Inner(IntPtr queue, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (BlockMarshaler))] Block block);

#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>Submits an application-defined function for asynchronous execution on a dispatch queue and returns immediately.</para>
        /// <para>Original signature is 'void dispatch_async_f(  dispatch_queue_t queue,  void *context,  dispatch_function_t work);'</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        /// <param name="queue">MISSING</param>
        /// <param name="context">MISSING</param>
        /// <param name="work">MISSING</param>
        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_async_f")]
        public static extern void dispatch_async_f(IntPtr queue, IntPtr context, dispatch_function_t work);

#endif

#if MACOSX_10_7
        /// <summary>
        /// <para>Submits a barrier block for asynchronous execution and returns immediately.</para>
        /// <para>Original signature is 'void dispatch_barrier_async(  dispatch_queue_t queue,  dispatch_block_t block);'</para>
        /// <para>Available in Mac OS X v10.7 and later.</para>
        /// </summary>
        /// <param name="queue">MISSING</param>
        /// <param name="block">MISSING</param>
        public static void dispatch_barrier_async(IntPtr queue, Action block)
        {
            Block __local1 = ObjectiveCRuntime.CreateBlock(block);
            dispatch_barrier_async_Inner(queue, __local1);
            __local1.Dispose();
        }

        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_barrier_async")]
        private static extern void dispatch_barrier_async_Inner(IntPtr queue, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (BlockMarshaler))] Block block);

#endif

#if MACOSX_10_7
        /// <summary>
        /// <para>Submits a barrier function for asynchronous execution and returns immediately.</para>
        /// <para>Original signature is 'void dispatch_barrier_async_f(  dispatch_queue_t queue,  void* context,  dispatch_function_t work);'</para>
        /// <para>Available in Mac OS X v10.7 and later.</para>
        /// </summary>
        /// <param name="queue">MISSING</param>
        /// <param name="context">MISSING</param>
        /// <param name="work">MISSING</param>
        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_barrier_async_f")]
        public static extern void dispatch_barrier_async_f(IntPtr queue, IntPtr context, dispatch_function_t work);

#endif

#if MACOSX_10_7
        /// <summary>
        /// <para>Submits a barrier block object for execution and waits until that block completes.</para>
        /// <para>Original signature is 'void dispatch_barrier_sync(  dispatch_queue_t queue,  dispatch_block_t block);'</para>
        /// <para>Available in Mac OS X v10.7 and later.</para>
        /// </summary>
        /// <param name="queue">MISSING</param>
        /// <param name="block">MISSING</param>
        public static void dispatch_barrier_sync(IntPtr queue, Action block)
        {
            Block __local1 = ObjectiveCRuntime.CreateBlock(block);
            dispatch_barrier_sync_Inner(queue, __local1);
            __local1.Dispose();
        }

        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_barrier_sync")]
        private static extern void dispatch_barrier_sync_Inner(IntPtr queue, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (BlockMarshaler))] Block block);

#endif

#if MACOSX_10_7
        /// <summary>
        /// <para>Submits a barrier function for execution and waits until that function completes.</para>
        /// <para>Original signature is 'void dispatch_barrier_sync_f(  dispatch_queue_t queue,  void* context,  dispatch_function_t work);'</para>
        /// <para>Available in Mac OS X v10.7 and later.</para>
        /// </summary>
        /// <param name="queue">MISSING</param>
        /// <param name="context">MISSING</param>
        /// <param name="work">MISSING</param>
        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_barrier_sync_f")]
        public static extern void dispatch_barrier_sync_f(IntPtr queue, IntPtr context, dispatch_function_t work);

#endif

#if MACOSX_10_7
        /// <summary>
        /// <para>Traverses the memory of a dispatch data object and executes custom code on each region.</para>
        /// <para>Original signature is 'bool dispatch_data_apply(  dispatch_data_t data,  dispatch_data_applier_t applier);'</para>
        /// <para>Available in Mac OS X v10.7 and later.</para>
        /// </summary>
        /// <param name="data">MISSING</param>
        /// <param name="applier">MISSING</param>
        /// <returns>A Boolean indicating whether the traversal completed successfully. Typically, this value is true if the applier block was executed on all of the regions or there was nothing to traverse. If it is false, it means the block terminated the traversal early.</returns>
        public static bool dispatch_data_apply(IntPtr data, Func<IntPtr, NSUInteger, IntPtr, NSUInteger, bool> applier)
        {
            Block __local1 = ObjectiveCRuntime.CreateBlock(applier);
            bool __result = dispatch_data_apply_Inner(data, __local1);
            __local1.Dispose();
            return __result;
        }

        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_data_apply")]
        private static extern bool dispatch_data_apply_Inner(IntPtr data, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (BlockMarshaler))] Block applier);

#endif

#if MACOSX_10_7
        /// <summary>
        /// <para>Returns a data object containing a portion of the data in another data object.</para>
        /// <para>Original signature is 'dispatch_data_t dispatch_data_copy_region(  dispatch_data_t data,  size_t location,  size_t *offset_ptr);'</para>
        /// <para>Available in Mac OS X v10.7 and later.</para>
        /// </summary>
        /// <param name="data">MISSING</param>
        /// <param name="location">MISSING</param>
        /// <param name="offset_ptr">MISSING</param>
        /// <returns>A dispatch data object whose memory region contains the specified location.</returns>
        public static IntPtr dispatch_data_copy_region(IntPtr data, NSUInteger location, out NSUInteger offset_ptr)
        {
            if (ObjectiveCRuntime.Is64Bits)
            {
                IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof (ulong)));
                IntPtr __result = dispatch_data_copy_region_64(data, (ulong) location, __local1);
                offset_ptr = (NSUInteger) (ulong) Marshal.PtrToStructure(__local1, typeof(ulong));
                Marshal.FreeHGlobal(__local1);
                return __result;
            }
            else
            {
                IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof (uint)));
                IntPtr __result = dispatch_data_copy_region_32(data, (uint) location, __local1);
                offset_ptr = (NSUInteger) (uint) Marshal.PtrToStructure(__local1, typeof(uint));
                Marshal.FreeHGlobal(__local1);
                return __result;
            }
        }

        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_data_copy_region")]
        private static extern IntPtr dispatch_data_copy_region_64(IntPtr data, ulong location, IntPtr offset_ptr);

        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_data_copy_region")]
        private static extern IntPtr dispatch_data_copy_region_32(IntPtr data, uint location, IntPtr offset_ptr);

#endif

#if MACOSX_10_7
        /// <summary>
        /// <para>Creates a new dispatch data object with the specified memory buffer.</para>
        /// <para>Original signature is 'dispatch_data_t dispatch_data_create(  const void *buffer,  size_t size,  dispatch_queue_t queue,  dispatch_block_t destructor);'</para>
        /// <para>Available in Mac OS X v10.7 and later.</para>
        /// </summary>
        /// <param name="buffer">MISSING</param>
        /// <param name="size">MISSING</param>
        /// <param name="queue">MISSING</param>
        /// <param name="destructor">MISSING</param>
        /// <returns>A new data object containing the desired data. This object is retained initially. It is your responsibility to release the data object when you are done using it.If buffer is NULL or size is 0, this function returns an empty dispatch object.</returns>
        public static IntPtr dispatch_data_create(IntPtr buffer, NSUInteger size, IntPtr queue, Action destructor)
        {
            if (ObjectiveCRuntime.Is64Bits)
            {
                Block __local1 = ObjectiveCRuntime.CreateBlock(destructor);
                IntPtr __result = dispatch_data_create_64(buffer, (ulong) size, queue, __local1);
                __local1.Dispose();
                return __result;
            }
            else
            {
                Block __local1 = ObjectiveCRuntime.CreateBlock(destructor);
                IntPtr __result = dispatch_data_create_32(buffer, (uint) size, queue, __local1);
                __local1.Dispose();
                return __result;
            }
        }

        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_data_create")]
        private static extern IntPtr dispatch_data_create_64(IntPtr buffer, ulong size, IntPtr queue, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (BlockMarshaler))] Block destructor);

        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_data_create")]
        private static extern IntPtr dispatch_data_create_32(IntPtr buffer, uint size, IntPtr queue, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (BlockMarshaler))] Block destructor);

#endif

#if MACOSX_10_7
        /// <summary>
        /// <para>Returns a new dispatch data object consisting of the concatenated data from two other data objects.</para>
        /// <para>Original signature is 'dispatch_data_t dispatch_data_create_concat(  dispatch_data_t data1,  dispatch_data_t data2);'</para>
        /// <para>Available in Mac OS X v10.7 and later.</para>
        /// </summary>
        /// <param name="data1">MISSING</param>
        /// <param name="data2">MISSING</param>
        /// <returns>A new dispatch data object containing the concatenated memory.</returns>
        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_data_create_concat")]
        public static extern IntPtr dispatch_data_create_concat(IntPtr data1, IntPtr data2);

#endif

#if MACOSX_10_7
        /// <summary>
        /// <para>Returns a new dispatch data object containing a contiguous representation of the specified object’s memory.</para>
        /// <para>Original signature is 'dispatch_data_t dispatch_data_create_map(  dispatch_data_t data,  const void **buffer_ptr,  size_t *size_ptr);'</para>
        /// <para>Available in Mac OS X v10.7 and later.</para>
        /// </summary>
        /// <param name="data">MISSING</param>
        /// <param name="buffer_ptr">MISSING</param>
        /// <param name="size_ptr">MISSING</param>
        /// <returns>A new dispatch data object containing the contiguous version of the memory managed by the object in the data parameter.</returns>
        public static IntPtr dispatch_data_create_map(IntPtr data, IntPtr buffer_ptr, out NSUInteger size_ptr)
        {
            if (ObjectiveCRuntime.Is64Bits)
            {
                IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof (ulong)));
                IntPtr __result = dispatch_data_create_map_64(data, buffer_ptr, __local1);
                size_ptr = (NSUInteger) (ulong) Marshal.PtrToStructure(__local1, typeof(ulong));
                Marshal.FreeHGlobal(__local1);
                return __result;
            }
            else
            {
                IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof (uint)));
                IntPtr __result = dispatch_data_create_map_32(data, buffer_ptr, __local1);
                size_ptr = (NSUInteger) (uint) Marshal.PtrToStructure(__local1, typeof(uint));
                Marshal.FreeHGlobal(__local1);
                return __result;
            }
        }

        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_data_create_map")]
        private static extern IntPtr dispatch_data_create_map_64(IntPtr data, IntPtr buffer_ptr, IntPtr size_ptr);

        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_data_create_map")]
        private static extern IntPtr dispatch_data_create_map_32(IntPtr data, IntPtr buffer_ptr, IntPtr size_ptr);

#endif

#if MACOSX_10_7
        /// <summary>
        /// <para>Returns a new dispatch data object whose contents consist of a portion of another object’s memory region.</para>
        /// <para>Original signature is 'dispatch_data_t dispatch_data_create_subrange(  dispatch_data_t data,  size_t offset,  size_t length);'</para>
        /// <para>Available in Mac OS X v10.7 and later.</para>
        /// </summary>
        /// <param name="data">MISSING</param>
        /// <param name="offset">MISSING</param>
        /// <param name="length">MISSING</param>
        /// <returns>A new dispatch data object whose memory is a subrange of the memory associated with the object in the data parameter.</returns>
        public static IntPtr dispatch_data_create_subrange(IntPtr data, NSUInteger offset, NSUInteger length)
        {
            if (ObjectiveCRuntime.Is64Bits)
            {
                return dispatch_data_create_subrange_64(data, (ulong) offset, (ulong) length);
            }
            else
            {
                return dispatch_data_create_subrange_32(data, (uint) offset, (uint) length);
            }
        }

        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_data_create_subrange")]
        private static extern IntPtr dispatch_data_create_subrange_64(IntPtr data, ulong offset, ulong length);

        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_data_create_subrange")]
        private static extern IntPtr dispatch_data_create_subrange_32(IntPtr data, uint offset, uint length);

#endif

#if MACOSX_10_7
        /// <summary>
        /// <para>Returns the logical size of the memory managed by a dispatch data object</para>
        /// <para>Original signature is 'size_t dispatch_data_get_size(  dispatch_data_t data);'</para>
        /// <para>Available in Mac OS X v10.7 and later.</para>
        /// </summary>
        /// <param name="data">MISSING</param>
        /// <returns>The number of bytes represented by the data object.</returns>
        public static NSUInteger dispatch_data_get_size(IntPtr data)
        {
            if (ObjectiveCRuntime.Is64Bits)
            {
                return (NSUInteger) dispatch_data_get_size_64(data);
            }
            else
            {
                return (NSUInteger) dispatch_data_get_size_32(data);
            }
        }

        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_data_get_size")]
        private static extern ulong dispatch_data_get_size_64(IntPtr data);

        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_data_get_size")]
        private static extern uint dispatch_data_get_size_32(IntPtr data);

#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>Programmatically logs debug information about a dispatch object.</para>
        /// <para>Original signature is 'void dispatch_debug(  dispatch_object_t object,  const char *message,  ...);'</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        /// <param name="object">MISSING</param>
        /// <param name="message">MISSING</param>
        /// <param name="values">MISSING</param>
        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_debug")]
        public static extern void dispatch_debug(IntPtr @object, String message, params Object[] values);

#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>Returns the application-defined context of an object.</para>
        /// <para>Original signature is 'void * dispatch_get_context(  dispatch_object_t object);'</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        /// <param name="object">MISSING</param>
        /// <returns>The context of the object; can be NULL.</returns>
        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_get_context")]
        public static extern IntPtr dispatch_get_context(IntPtr @object);

#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>Returns the queue on which the currently executing block is running.</para>
        /// <para>Original signature is 'dispatch_queue_t dispatch_get_current_queue(  void);'</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        /// <returns>Returns the current queue.</returns>
        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_get_current_queue")]
        public static extern IntPtr dispatch_get_current_queue();

#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>Returns a well-known global concurrent queue of a given priority level.</para>
        /// <para>Original signature is 'dispatch_queue_t dispatch_get_global_queue(  long priority,  unsigned long flags);'</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        /// <param name="priority">MISSING</param>
        /// <param name="flags">MISSING</param>
        /// <returns>Returns the requested global queue.</returns>
        public static IntPtr dispatch_get_global_queue(NSInteger priority, NSUInteger flags)
        {
            if (ObjectiveCRuntime.Is64Bits)
            {
                return dispatch_get_global_queue_64((long) priority, (ulong) flags);
            }
            else
            {
                return dispatch_get_global_queue_32((int) priority, (uint) flags);
            }
        }

        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_get_global_queue")]
        private static extern IntPtr dispatch_get_global_queue_64(long priority, ulong flags);

        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_get_global_queue")]
        private static extern IntPtr dispatch_get_global_queue_32(int priority, uint flags);

#endif

#if MACOSX_10_7
        /// <summary>
        /// <para>Returns the value for the key associated with the current dispatch queue.</para>
        /// <para>Original signature is 'void* dispatch_get_specific(const void *key);'</para>
        /// <para>Available in Mac OS X v10.7 and later.</para>
        /// </summary>
        /// <param name="key">MISSING</param>
        /// <returns>The context value for the specified key; otherwise NULL if the key was not set for the queue (or its target queue) or the queue is a global concurrent queue.</returns>
        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_get_specific")]
        public static extern IntPtr dispatch_get_specific(IntPtr key);

#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>Submits a block to a dispatch queue and associates the block with the specified dispatch group.</para>
        /// <para>Original signature is 'void dispatch_group_async(  dispatch_group_t group,  dispatch_queue_t queue,  dispatch_block_t block);'</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        /// <param name="group">MISSING</param>
        /// <param name="queue">MISSING</param>
        /// <param name="block">MISSING</param>
        public static void dispatch_group_async(IntPtr group, IntPtr queue, Action block)
        {
            Block __local1 = ObjectiveCRuntime.CreateBlock(block);
            dispatch_group_async_Inner(group, queue, __local1);
            __local1.Dispose();
        }

        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_group_async")]
        private static extern void dispatch_group_async_Inner(IntPtr group, IntPtr queue, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (BlockMarshaler))] Block block);

#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>Submits an application-defined function to a dispatch queue and associates it with the specified dispatch group.</para>
        /// <para>Original signature is 'void dispatch_group_async_f(  dispatch_group_t group,  dispatch_queue_t queue,  void *context,  dispatch_function_t work);'</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        /// <param name="group">MISSING</param>
        /// <param name="queue">MISSING</param>
        /// <param name="context">MISSING</param>
        /// <param name="work">MISSING</param>
        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_group_async_f")]
        public static extern void dispatch_group_async_f(IntPtr group, IntPtr queue, IntPtr context, dispatch_function_t work);

#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>Creates a new group with which block objects can be associated.</para>
        /// <para>Original signature is 'dispatch_group_t dispatch_group_create(  void);'</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        /// <returns>The newly created group, or NULL on failure.</returns>
        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_group_create")]
        public static extern IntPtr dispatch_group_create();

#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>Explicitly indicates that a block has entered the group.</para>
        /// <para>Original signature is 'void dispatch_group_enter(  dispatch_group_t group);'</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        /// <param name="group">MISSING</param>
        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_group_enter")]
        public static extern void dispatch_group_enter(IntPtr group);

#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>Explicitly indicates that a block in the group has completed.</para>
        /// <para>Original signature is 'void dispatch_group_leave(  dispatch_group_t group);'</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        /// <param name="group">MISSING</param>
        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_group_leave")]
        public static extern void dispatch_group_leave(IntPtr group);

#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>Schedules a block object to be submitted to a queue when a group of previously submitted block objects have completed.</para>
        /// <para>Original signature is 'void dispatch_group_notify(  dispatch_group_t group,  dispatch_queue_t queue,  dispatch_block_t block);'</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        /// <param name="group">MISSING</param>
        /// <param name="queue">MISSING</param>
        /// <param name="block">MISSING</param>
        public static void dispatch_group_notify(IntPtr group, IntPtr queue, Action block)
        {
            Block __local1 = ObjectiveCRuntime.CreateBlock(block);
            dispatch_group_notify_Inner(group, queue, __local1);
            __local1.Dispose();
        }

        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_group_notify")]
        private static extern void dispatch_group_notify_Inner(IntPtr group, IntPtr queue, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (BlockMarshaler))] Block block);

#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>Schedules an application-defined function to be submitted to a queue when a group of previously submitted block objects have completed.</para>
        /// <para>Original signature is 'void dispatch_group_notify_f(  dispatch_group_t group,  dispatch_queue_t queue,  void *context,  dispatch_function_t work);'</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        /// <param name="group">MISSING</param>
        /// <param name="queue">MISSING</param>
        /// <param name="context">MISSING</param>
        /// <param name="work">MISSING</param>
        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_group_notify_f")]
        public static extern void dispatch_group_notify_f(IntPtr group, IntPtr queue, IntPtr context, dispatch_function_t work);

#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>Waits synchronously for the previously submitted block objects to complete; returns if the blocks do not complete before the specified timeout period has elapsed.</para>
        /// <para>Original signature is 'long dispatch_group_wait(  dispatch_group_t group,  dispatch_time_t timeout);'</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        /// <param name="group">MISSING</param>
        /// <param name="timeout">MISSING</param>
        /// <returns>Returns zero on success (all blocks associated with the group completed before the specified timeout) or non-zero on error (timeout occurred).</returns>
        public static NSInteger dispatch_group_wait(IntPtr group, long timeout)
        {
            if (ObjectiveCRuntime.Is64Bits)
            {
                return (NSInteger) dispatch_group_wait_64(group, timeout);
            }
            else
            {
                return (NSInteger) dispatch_group_wait_32(group, timeout);
            }
        }

        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_group_wait")]
        private static extern long dispatch_group_wait_64(IntPtr group, long timeout);

        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_group_wait")]
        private static extern int dispatch_group_wait_32(IntPtr group, long timeout);

#endif

#if MACOSX_10_7
        /// <summary>
        /// <para>Closes the specified channel to new read and write operations.</para>
        /// <para>Original signature is 'void dispatch_io_close(  dispatch_io_t channel,  dispatch_io_close_flags_t flags);'</para>
        /// <para>Available in Mac OS X v10.7 and later.</para>
        /// </summary>
        /// <param name="channel">MISSING</param>
        /// <param name="flags">MISSING</param>
        public static void dispatch_io_close(IntPtr channel, NSUInteger flags)
        {
            if (ObjectiveCRuntime.Is64Bits)
            {
                dispatch_io_close_64(channel, (ulong) flags);
            }
            else
            {
                dispatch_io_close_32(channel, (uint) flags);
            }
        }

        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_io_close")]
        private static extern void dispatch_io_close_64(IntPtr channel, ulong flags);

        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_io_close")]
        private static extern void dispatch_io_close_32(IntPtr channel, uint flags);

#endif

#if MACOSX_10_7
        /// <summary>
        /// <para>Creates a dispatch I/O channel and associates it with the specified file descriptor.</para>
        /// <para>Original signature is 'dispatch_io_t dispatch_io_create(  dispatch_io_type_t type,  dispatch_fd_t fd,  dispatch_queue_t queue,  void (^cleanup_handler)(int error));'</para>
        /// <para>Available in Mac OS X v10.7 and later.</para>
        /// </summary>
        /// <param name="type">MISSING</param>
        /// <param name="fd">MISSING</param>
        /// <param name="queue">MISSING</param>
        /// <param name="cleanup_handler">MISSING</param>
        /// <returns>The dispatch I/O channel or NULL if an error occurred. The returned object is retained before it is returned; it is your responsibility to close the channel and then release this object when you are done using it.</returns>
        public static IntPtr dispatch_io_create(NSUInteger type, int fd, IntPtr queue, Action<int> cleanup_handler)
        {
            if (ObjectiveCRuntime.Is64Bits)
            {
                return dispatch_io_create_64((ulong) type, fd, queue, cleanup_handler);
            }
            else
            {
                return dispatch_io_create_32((uint) type, fd, queue, cleanup_handler);
            }
        }

        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_io_create")]
        private static extern IntPtr dispatch_io_create_64(ulong type, int fd, IntPtr queue, Action<int> cleanup_handler);

        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_io_create")]
        private static extern IntPtr dispatch_io_create_32(uint type, int fd, IntPtr queue, Action<int> cleanup_handler);

#endif

#if MACOSX_10_7
        /// <summary>
        /// <para>Creates a dispatch I/O channel with the associated path name.</para>
        /// <para>Original signature is 'dispatch_io_t dispatch_io_create_with_path(  dispatch_io_type_t type,  const char* path,  int oflag,  mode_t mode,  dispatch_queue_t queue,  void (^cleanup_handler)(int error));'</para>
        /// <para>Available in Mac OS X v10.7 and later.</para>
        /// </summary>
        /// <param name="type">MISSING</param>
        /// <param name="path">MISSING</param>
        /// <param name="oflag">MISSING</param>
        /// <param name="mode">MISSING</param>
        /// <param name="queue">MISSING</param>
        /// <param name="cleanup_handler">MISSING</param>
        /// <returns>The dispatch I/O channel or NULL if an error occurred. The returned object is retained before it is returned; it is your responsibility to close the channel and then release this object when you are done using it.</returns>
        public static IntPtr dispatch_io_create_with_path(NSUInteger type, String path, int oflag, ushort mode, IntPtr queue, Action<NSUInteger> cleanup_handler)
        {
            if (ObjectiveCRuntime.Is64Bits)
            {
                Block __local1 = ObjectiveCRuntime.CreateBlock(cleanup_handler);
                IntPtr __result = dispatch_io_create_with_path_64((ulong) type, path, oflag, mode, queue, __local1);
                __local1.Dispose();
                return __result;
            }
            else
            {
                Block __local1 = ObjectiveCRuntime.CreateBlock(cleanup_handler);
                IntPtr __result = dispatch_io_create_with_path_32((uint) type, path, oflag, mode, queue, __local1);
                __local1.Dispose();
                return __result;
            }
        }

        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_io_create_with_path")]
        private static extern IntPtr dispatch_io_create_with_path_64(ulong type, String path, int oflag, ushort mode, IntPtr queue, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (BlockMarshaler))] Block cleanup_handler);

        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_io_create_with_path")]
        private static extern IntPtr dispatch_io_create_with_path_32(uint type, String path, int oflag, ushort mode, IntPtr queue, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (BlockMarshaler))] Block cleanup_handler);

#endif

#if MACOSX_10_7
        /// <summary>
        /// <para>Schedules an asynchronous read operation on the specified channel.</para>
        /// <para>Original signature is 'void dispatch_io_read(  dispatch_io_t channel,  off_t offset,  size_t length,  dispatch_queue_t queue,  dispatch_io_handler_t io_handler);'</para>
        /// <para>Available in Mac OS X v10.7 and later.</para>
        /// </summary>
        /// <param name="channel">MISSING</param>
        /// <param name="offset">MISSING</param>
        /// <param name="length">MISSING</param>
        /// <param name="queue">MISSING</param>
        /// <param name="io_handler">MISSING</param>
        public static void dispatch_io_read(IntPtr channel, long offset, NSUInteger length, IntPtr queue, Action<bool, IntPtr, int> io_handler)
        {
            if (ObjectiveCRuntime.Is64Bits)
            {
                Block __local1 = ObjectiveCRuntime.CreateBlock(io_handler);
                dispatch_io_read_64(channel, offset, (ulong) length, queue, __local1);
                __local1.Dispose();
            }
            else
            {
                Block __local1 = ObjectiveCRuntime.CreateBlock(io_handler);
                dispatch_io_read_32(channel, offset, (uint) length, queue, __local1);
                __local1.Dispose();
            }
        }

        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_io_read")]
        private static extern void dispatch_io_read_64(IntPtr channel, long offset, ulong length, IntPtr queue, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (BlockMarshaler))] Block io_handler);

        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_io_read")]
        private static extern void dispatch_io_read_32(IntPtr channel, long offset, uint length, IntPtr queue, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (BlockMarshaler))] Block io_handler);

#endif

#if MACOSX_10_7
        /// <summary>
        /// <para>Sets the maximum number of bytes to process before enqueueing a handler block.</para>
        /// <para>Original signature is 'void dispatch_io_set_high_water(  dispatch_io_t channel,  size_t high_water);'</para>
        /// <para>Available in Mac OS X v10.7 and later.</para>
        /// </summary>
        /// <param name="channel">MISSING</param>
        /// <param name="high_water">MISSING</param>
        public static void dispatch_io_set_high_water(IntPtr channel, NSUInteger high_water)
        {
            if (ObjectiveCRuntime.Is64Bits)
            {
                dispatch_io_set_high_water_64(channel, (ulong) high_water);
            }
            else
            {
                dispatch_io_set_high_water_32(channel, (uint) high_water);
            }
        }

        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_io_set_high_water")]
        private static extern void dispatch_io_set_high_water_64(IntPtr channel, ulong high_water);

        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_io_set_high_water")]
        private static extern void dispatch_io_set_high_water_32(IntPtr channel, uint high_water);

#endif

#if MACOSX_10_7
        /// <summary>
        /// <para>Sets the interval (in nanoseconds) at which to invoke the I/O handlers for the channel.</para>
        /// <para>Original signature is 'void dispatch_io_set_interval(  dispatch_io_t channel,  uint64_t interval,  dispatch_io_interval_flags_t flags);'</para>
        /// <para>Available in Mac OS X v10.7 and later.</para>
        /// </summary>
        /// <param name="channel">MISSING</param>
        /// <param name="interval">MISSING</param>
        /// <param name="flags">MISSING</param>
        public static void dispatch_io_set_interval(IntPtr channel, ulong interval, NSUInteger flags)
        {
            if (ObjectiveCRuntime.Is64Bits)
            {
                dispatch_io_set_interval_64(channel, interval, (ulong) flags);
            }
            else
            {
                dispatch_io_set_interval_32(channel, interval, (uint) flags);
            }
        }

        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_io_set_interval")]
        private static extern void dispatch_io_set_interval_64(IntPtr channel, ulong interval, ulong flags);

        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_io_set_interval")]
        private static extern void dispatch_io_set_interval_32(IntPtr channel, ulong interval, uint flags);

#endif

#if MACOSX_10_7
        /// <summary>
        /// <para>Sets the minimum number of bytes to process before enqueueing a handler block.</para>
        /// <para>Original signature is 'void dispatch_io_set_low_water(  dispatch_io_t channel,  size_t low_water);'</para>
        /// <para>Available in Mac OS X v10.7 and later.</para>
        /// </summary>
        /// <param name="channel">MISSING</param>
        /// <param name="low_water">MISSING</param>
        public static void dispatch_io_set_low_water(IntPtr channel, NSUInteger low_water)
        {
            if (ObjectiveCRuntime.Is64Bits)
            {
                dispatch_io_set_low_water_64(channel, (ulong) low_water);
            }
            else
            {
                dispatch_io_set_low_water_32(channel, (uint) low_water);
            }
        }

        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_io_set_low_water")]
        private static extern void dispatch_io_set_low_water_64(IntPtr channel, ulong low_water);

        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_io_set_low_water")]
        private static extern void dispatch_io_set_low_water_32(IntPtr channel, uint low_water);

#endif

#if MACOSX_10_7
        /// <summary>
        /// <para>Schedules an asynchronous write operation for the specified channel.</para>
        /// <para>Original signature is 'void dispatch_io_write(  dispatch_io_t channel,  off_t offset,  dispatch_data_t data,  dispatch_queue_t queue,  dispatch_io_handler_t io_handler);'</para>
        /// <para>Available in Mac OS X v10.7 and later.</para>
        /// </summary>
        /// <param name="channel">MISSING</param>
        /// <param name="offset">MISSING</param>
        /// <param name="data">MISSING</param>
        /// <param name="queue">MISSING</param>
        /// <param name="io_handler">MISSING</param>
        public static void dispatch_io_write(IntPtr channel, long offset, IntPtr data, IntPtr queue, Action<bool, IntPtr, int> io_handler)
        {
            Block __local1 = ObjectiveCRuntime.CreateBlock(io_handler);
            dispatch_io_write_Inner(channel, offset, data, queue, __local1);
            __local1.Dispose();
        }

        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_io_write")]
        private static extern void dispatch_io_write_Inner(IntPtr channel, long offset, IntPtr data, IntPtr queue, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (BlockMarshaler))] Block io_handler);

#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>Executes blocks submitted to the main queue.</para>
        /// <para>Original signature is 'void dispatch_main(  void);'</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_main")]
        public static extern void dispatch_main();

#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>Executes a block object once and only once for the lifetime of an application.</para>
        /// <para>Original signature is 'void dispatch_once(  dispatch_once_t *predicate,  dispatch_block_t block);'</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        /// <param name="predicate">MISSING</param>
        /// <param name="block">MISSING</param>
        public static void dispatch_once(out NSInteger predicate, Action block)
        {
            if (ObjectiveCRuntime.Is64Bits)
            {
                IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof (long)));
                Block __local2 = ObjectiveCRuntime.CreateBlock(block);
                dispatch_once_64(__local1, __local2);
                predicate = (NSInteger) (long) Marshal.PtrToStructure(__local1, typeof(long));
                Marshal.FreeHGlobal(__local1);
                __local2.Dispose();
            }
            else
            {
                IntPtr __local1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof (int)));
                Block __local2 = ObjectiveCRuntime.CreateBlock(block);
                dispatch_once_32(__local1, __local2);
                predicate = (NSInteger) (int) Marshal.PtrToStructure(__local1, typeof(int));
                Marshal.FreeHGlobal(__local1);
                __local2.Dispose();
            }
        }

        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_once")]
        private static extern void dispatch_once_64(IntPtr predicate, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (BlockMarshaler))] Block block);

        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_once")]
        private static extern void dispatch_once_32(IntPtr predicate, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (BlockMarshaler))] Block block);

#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>Creates a new dispatch queue to which blocks can be submitted.</para>
        /// <para>Original signature is 'dispatch_queue_t dispatch_queue_create(  const char *label  dispatch_queue_attr_t attr);'</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        /// <param name="label">MISSING</param>
        /// <returns>The newly created dispatch queue.</returns>
        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_queue_create")]
        public static extern IntPtr dispatch_queue_create(String label);

#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>Returns the label specified for the queue when the queue was created.</para>
        /// <para>Original signature is 'const char * dispatch_queue_get_label(dispatch_queue_t queue);'</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        /// <param name="queue">MISSING</param>
        /// <returns>The label of the queue. The result can be NULL if the application does not provide a label when it creates the queue.</returns>
        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_queue_get_label")]
        public static extern IntPtr dispatch_queue_get_label(IntPtr queue);

#endif

#if MACOSX_10_7
        /// <summary>
        /// <para>Gets the value for the key associated with the specified dispatch queue.</para>
        /// <para>Original signature is 'void* dispatch_queue_get_specific(dispatch_queue_t queue, const void *key);'</para>
        /// <para>Available in Mac OS X v10.7 and later.</para>
        /// </summary>
        /// <param name="queue">MISSING</param>
        /// <param name="key">MISSING</param>
        /// <returns>The context data associated with key or NULL if no context was found.</returns>
        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_queue_get_specific")]
        public static extern IntPtr dispatch_queue_get_specific(IntPtr queue, IntPtr key);

#endif

#if MACOSX_10_7
        /// <summary>
        /// <para>Sets the key/value data for the specified dispatch queue.</para>
        /// <para>Original signature is 'void dispatch_queue_set_specific(dispatch_queue_t queue, const void* key, void *context, dispatch_function_t destructor);'</para>
        /// <para>Available in Mac OS X v10.7 and later.</para>
        /// </summary>
        /// <param name="queue">MISSING</param>
        /// <param name="key">MISSING</param>
        /// <param name="context">MISSING</param>
        /// <param name="destructor">MISSING</param>
        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_queue_set_specific")]
        public static extern void dispatch_queue_set_specific(IntPtr queue, IntPtr key, IntPtr context, dispatch_function_t destructor);

#endif

#if MACOSX_10_7
        /// <summary>
        /// <para>Schedule an asynchronous read operation using the specified file descriptor.</para>
        /// <para>Original signature is 'void dispatch_read(  dispatch_fd_t fd,  size_t length,  dispatch_queue_t queue,  void (^handler)(dispatch_data_t data, int error));'</para>
        /// <para>Available in Mac OS X v10.7 and later.</para>
        /// </summary>
        /// <param name="fd">MISSING</param>
        /// <param name="length">MISSING</param>
        /// <param name="queue">MISSING</param>
        /// <param name="handler">MISSING</param>
        public static void dispatch_read(int fd, NSUInteger length, IntPtr queue, Action<IntPtr, int> handler)
        {
            if (ObjectiveCRuntime.Is64Bits)
            {
                Block __local1 = ObjectiveCRuntime.CreateBlock(handler);
                dispatch_read_64(fd, (ulong) length, queue, __local1);
                __local1.Dispose();
            }
            else
            {
                Block __local1 = ObjectiveCRuntime.CreateBlock(handler);
                dispatch_read_32(fd, (uint) length, queue, __local1);
                __local1.Dispose();
            }
        }

        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_read")]
        private static extern void dispatch_read_64(int fd, ulong length, IntPtr queue, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (BlockMarshaler))] Block handler);

        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_read")]
        private static extern void dispatch_read_32(int fd, uint length, IntPtr queue, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (BlockMarshaler))] Block handler);

#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>Decrements the reference (retain) count of a dispatch object.</para>
        /// <para>Original signature is 'void dispatch_release(  dispatch_object_t object);'</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        /// <param name="object">MISSING</param>
        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_release")]
        public static extern void dispatch_release(IntPtr @object);

#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>Resume the invocation of block objects on a dispatch object.</para>
        /// <para>Original signature is 'void dispatch_resume(  dispatch_object_t object);'</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        /// <param name="object">MISSING</param>
        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_resume")]
        public static extern void dispatch_resume(IntPtr @object);

#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>Increments the reference (retain) count of a dispatch object.</para>
        /// <para>Original signature is 'void dispatch_retain(  dispatch_object_t object);'</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        /// <param name="object">MISSING</param>
        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_retain")]
        public static extern void dispatch_retain(IntPtr @object);

#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>Creates new counting semaphore with an initial value.</para>
        /// <para>Original signature is 'dispatch_semaphore_t dispatch_semaphore_create(  long value);'</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        /// <param name="value">MISSING</param>
        /// <returns>The newly created semaphore, or NULL on failure.</returns>
        public static IntPtr dispatch_semaphore_create(NSInteger value)
        {
            if (ObjectiveCRuntime.Is64Bits)
            {
                return dispatch_semaphore_create_64((long) value);
            }
            else
            {
                return dispatch_semaphore_create_32((int) value);
            }
        }

        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_semaphore_create")]
        private static extern IntPtr dispatch_semaphore_create_64(long value);

        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_semaphore_create")]
        private static extern IntPtr dispatch_semaphore_create_32(int value);

#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>Signals (increments) a semaphore.</para>
        /// <para>Original signature is 'long dispatch_semaphore_signal(  dispatch_semaphore_t dsema);'</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        /// <param name="dsema">MISSING</param>
        /// <returns>This function returns non-zero if a thread is woken. Otherwise, zero is returned.</returns>
        public static NSInteger dispatch_semaphore_signal(IntPtr dsema)
        {
            if (ObjectiveCRuntime.Is64Bits)
            {
                return (NSInteger) dispatch_semaphore_signal_64(dsema);
            }
            else
            {
                return (NSInteger) dispatch_semaphore_signal_32(dsema);
            }
        }

        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_semaphore_signal")]
        private static extern long dispatch_semaphore_signal_64(IntPtr dsema);

        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_semaphore_signal")]
        private static extern int dispatch_semaphore_signal_32(IntPtr dsema);

#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>Waits for (decrements) a semaphore.</para>
        /// <para>Original signature is 'long dispatch_semaphore_wait(  dispatch_semaphore_t dsema,  dispatch_time_t timeout);'</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        /// <param name="dsema">MISSING</param>
        /// <param name="timeout">MISSING</param>
        /// <returns>Returns zero on success, or non-zero if the timeout occurred.</returns>
        public static NSInteger dispatch_semaphore_wait(IntPtr dsema, long timeout)
        {
            if (ObjectiveCRuntime.Is64Bits)
            {
                return (NSInteger) dispatch_semaphore_wait_64(dsema, timeout);
            }
            else
            {
                return (NSInteger) dispatch_semaphore_wait_32(dsema, timeout);
            }
        }

        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_semaphore_wait")]
        private static extern long dispatch_semaphore_wait_64(IntPtr dsema, long timeout);

        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_semaphore_wait")]
        private static extern int dispatch_semaphore_wait_32(IntPtr dsema, long timeout);

#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>Associates an application-defined context with the object.</para>
        /// <para>Original signature is 'void dispatch_set_context(  dispatch_object_t object,  void *context);'</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        /// <param name="object">MISSING</param>
        /// <param name="context">MISSING</param>
        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_set_context")]
        public static extern void dispatch_set_context(IntPtr @object, IntPtr context);

#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>Sets the finalizer function for a dispatch object.</para>
        /// <para>Original signature is 'void dispatch_set_finalizer_f(  dispatch_object_t object,  dispatch_function_t finalizer);'</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        /// <param name="object">MISSING</param>
        /// <param name="finalizer">MISSING</param>
        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_set_finalizer_f")]
        public static extern void dispatch_set_finalizer_f(IntPtr @object, dispatch_function_t finalizer);

#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>Sets the target queue for the given object.</para>
        /// <para>Original signature is 'void dispatch_set_target_queue(  dispatch_object_t object,  dispatch_queue_t queue);'</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        /// <param name="object">MISSING</param>
        /// <param name="queue">MISSING</param>
        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_set_target_queue")]
        public static extern void dispatch_set_target_queue(IntPtr @object, IntPtr queue);

#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>Asynchronously cancels the dispatch source, preventing any further invocation of its event handler block.</para>
        /// <para>Original signature is 'void dispatch_source_cancel(  dispatch_source_t source);'</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        /// <param name="source">MISSING</param>
        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_source_cancel")]
        public static extern void dispatch_source_cancel(IntPtr source);

#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>Creates a new dispatch source to monitor low-level system objects and automatically submit a handler block to a dispatch queue in response to events.</para>
        /// <para>Original signature is 'dispatch_source_t dispatch_source_create(  dispatch_source_type_t type,  uintptr_t handle,  unsigned long mask,  dispatch_queue_t queue);'</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        /// <param name="type">MISSING</param>
        /// <param name="handle">MISSING</param>
        /// <param name="mask">MISSING</param>
        /// <param name="queue">MISSING</param>
        /// <returns>A new dispatch source object or NULL if the dispatch source could not be created.</returns>
        public static IntPtr dispatch_source_create(IntPtr type, IntPtr handle, NSUInteger mask, IntPtr queue)
        {
            if (ObjectiveCRuntime.Is64Bits)
            {
                return dispatch_source_create_64(type, handle, (ulong) mask, queue);
            }
            else
            {
                return dispatch_source_create_32(type, handle, (uint) mask, queue);
            }
        }

        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_source_create")]
        private static extern IntPtr dispatch_source_create_64(IntPtr type, IntPtr handle, ulong mask, IntPtr queue);

        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_source_create")]
        private static extern IntPtr dispatch_source_create_32(IntPtr type, IntPtr handle, uint mask, IntPtr queue);

#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>Returns pending data for the dispatch source.</para>
        /// <para>Original signature is 'unsigned long dispatch_source_get_data(  dispatch_source_t source);'</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        /// <param name="source">MISSING</param>
        /// <returns>The return value should be interpreted according to the type of the dispatch source, and can be one of the following:</returns>
        public static NSUInteger dispatch_source_get_data(IntPtr source)
        {
            if (ObjectiveCRuntime.Is64Bits)
            {
                return (NSUInteger) dispatch_source_get_data_64(source);
            }
            else
            {
                return (NSUInteger) dispatch_source_get_data_32(source);
            }
        }

        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_source_get_data")]
        private static extern ulong dispatch_source_get_data_64(IntPtr source);

        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_source_get_data")]
        private static extern uint dispatch_source_get_data_32(IntPtr source);

#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>Returns the underlying system handle associated with the specified dispatch source.</para>
        /// <para>Original signature is 'uintptr_t dispatch_source_get_handle(  dispatch_source_t source);'</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        /// <param name="source">MISSING</param>
        /// <returns>The return value should be interpreted according to the type of the dispatch source, and can be one of the following handles:</returns>
        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_source_get_handle")]
        public static extern IntPtr dispatch_source_get_handle(IntPtr source);

#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>Returns the mask of events monitored by the dispatch source.</para>
        /// <para>Original signature is 'unsigned long dispatch_source_get_mask(  dispatch_source_t source);'</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        /// <param name="source">MISSING</param>
        /// <returns>The return value should be interpreted according to the type of the dispatch source, and can be one of the following flag sets:</returns>
        public static NSUInteger dispatch_source_get_mask(IntPtr source)
        {
            if (ObjectiveCRuntime.Is64Bits)
            {
                return (NSUInteger) dispatch_source_get_mask_64(source);
            }
            else
            {
                return (NSUInteger) dispatch_source_get_mask_32(source);
            }
        }

        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_source_get_mask")]
        private static extern ulong dispatch_source_get_mask_64(IntPtr source);

        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_source_get_mask")]
        private static extern uint dispatch_source_get_mask_32(IntPtr source);

#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>Merges data into a dispatch source of type DISPATCH_SOURCE_TYPE_DATA_ADD or DISPATCH_SOURCE_TYPE_DATA_OR and submits its event handler block to its target queue.</para>
        /// <para>Original signature is 'void dispatch_source_merge_data(  dispatch_source_t source,  unsigned long value);'</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        /// <param name="source">MISSING</param>
        /// <param name="value">MISSING</param>
        public static void dispatch_source_merge_data(IntPtr source, NSUInteger value)
        {
            if (ObjectiveCRuntime.Is64Bits)
            {
                dispatch_source_merge_data_64(source, (ulong) value);
            }
            else
            {
                dispatch_source_merge_data_32(source, (uint) value);
            }
        }

        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_source_merge_data")]
        private static extern void dispatch_source_merge_data_64(IntPtr source, ulong value);

        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_source_merge_data")]
        private static extern void dispatch_source_merge_data_32(IntPtr source, uint value);

#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>Sets the cancellation handler block for the given dispatch source.</para>
        /// <para>Original signature is 'void dispatch_source_set_cancel_handler(  dispatch_source_t source,  dispatch_block_t cancel_handler);'</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        /// <param name="source">MISSING</param>
        /// <param name="cancel_handler">MISSING</param>
        public static void dispatch_source_set_cancel_handler(IntPtr source, Action cancel_handler)
        {
            Block __local1 = ObjectiveCRuntime.CreateBlock(cancel_handler);
            dispatch_source_set_cancel_handler_Inner(source, __local1);
            __local1.Dispose();
        }

        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_source_set_cancel_handler")]
        private static extern void dispatch_source_set_cancel_handler_Inner(IntPtr source, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (BlockMarshaler))] Block cancel_handler);

#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>Sets the cancellation handler function for the given dispatch source.</para>
        /// <para>Original signature is 'void dispatch_source_set_cancel_handler_f(  dispatch_source_t source,  dispatch_function_t cancel_handler);'</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        /// <param name="source">MISSING</param>
        /// <param name="cancel_handler">MISSING</param>
        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_source_set_cancel_handler_f")]
        public static extern void dispatch_source_set_cancel_handler_f(IntPtr source, dispatch_function_t cancel_handler);

#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>Sets the event handler block for the given dispatch source.</para>
        /// <para>Original signature is 'void dispatch_source_set_event_handler(  dispatch_source_t source,  dispatch_block_t handler);'</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        /// <param name="source">MISSING</param>
        /// <param name="handler">MISSING</param>
        public static void dispatch_source_set_event_handler(IntPtr source, Action handler)
        {
            Block __local1 = ObjectiveCRuntime.CreateBlock(handler);
            dispatch_source_set_event_handler_Inner(source, __local1);
            __local1.Dispose();
        }

        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_source_set_event_handler")]
        private static extern void dispatch_source_set_event_handler_Inner(IntPtr source, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (BlockMarshaler))] Block handler);

#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>Sets the event handler function for the given dispatch source.</para>
        /// <para>Original signature is 'void dispatch_source_set_event_handler_f(  dispatch_source_t source,  dispatch_function_t handler);'</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        /// <param name="source">MISSING</param>
        /// <param name="handler">MISSING</param>
        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_source_set_event_handler_f")]
        public static extern void dispatch_source_set_event_handler_f(IntPtr source, dispatch_function_t handler);

#endif

#if MACOSX_10_7
        /// <summary>
        /// <para>Sets the registration handler block for the given dispatch source.</para>
        /// <para>Original signature is 'void dispatch_source_set_registration_handler(  dispatch_source_t source,  dispatch_block_t registration_handler);'</para>
        /// <para>Available in Mac OS X v10.7 and later.</para>
        /// </summary>
        /// <param name="source">MISSING</param>
        /// <param name="registration_handler">MISSING</param>
        public static void dispatch_source_set_registration_handler(IntPtr source, Action registration_handler)
        {
            Block __local1 = ObjectiveCRuntime.CreateBlock(registration_handler);
            dispatch_source_set_registration_handler_Inner(source, __local1);
            __local1.Dispose();
        }

        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_source_set_registration_handler")]
        private static extern void dispatch_source_set_registration_handler_Inner(IntPtr source, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (BlockMarshaler))] Block registration_handler);

#endif

#if MACOSX_10_7
        /// <summary>
        /// <para>Sets the registration handler function for the given dispatch source.</para>
        /// <para>Original signature is 'void dispatch_source_set_registration_handler_f(  dispatch_source_t source,  dispatch_function_t registration_handler);'</para>
        /// <para>Available in Mac OS X v10.7 and later.</para>
        /// </summary>
        /// <param name="source">MISSING</param>
        /// <param name="registration_handler">MISSING</param>
        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_source_set_registration_handler_f")]
        public static extern void dispatch_source_set_registration_handler_f(IntPtr source, dispatch_function_t registration_handler);

#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>Sets a start time, interval, and leeway value for a timer source.</para>
        /// <para>Original signature is 'void dispatch_source_set_timer(  dispatch_source_t source,  dispatch_time_t start,  uint64_t interval,  uint64_t leeway);'</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        /// <param name="source">MISSING</param>
        /// <param name="start">MISSING</param>
        /// <param name="interval">MISSING</param>
        /// <param name="leeway">MISSING</param>
        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_source_set_timer")]
        public static extern void dispatch_source_set_timer(IntPtr source, long start, ulong interval, ulong leeway);

#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>Tests whether the given dispatch source has been canceled.</para>
        /// <para>Original signature is 'long dispatch_source_testcancel(  dispatch_source_t source);'</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        /// <param name="source">MISSING</param>
        /// <returns>Non-zero if canceled and zero if not canceled.</returns>
        public static NSInteger dispatch_source_testcancel(IntPtr source)
        {
            if (ObjectiveCRuntime.Is64Bits)
            {
                return (NSInteger) dispatch_source_testcancel_64(source);
            }
            else
            {
                return (NSInteger) dispatch_source_testcancel_32(source);
            }
        }

        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_source_testcancel")]
        private static extern long dispatch_source_testcancel_64(IntPtr source);

        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_source_testcancel")]
        private static extern int dispatch_source_testcancel_32(IntPtr source);

#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>Suspends the invocation of block objects on a dispatch object.</para>
        /// <para>Original signature is 'void dispatch_suspend(  dispatch_object_t object);'</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        /// <param name="object">MISSING</param>
        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_suspend")]
        public static extern void dispatch_suspend(IntPtr @object);

#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>Submits a block object for execution on a dispatch queue and waits until that block completes.</para>
        /// <para>Original signature is 'void dispatch_sync(  dispatch_queue_t queue,  dispatch_block_t block);'</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        /// <param name="queue">MISSING</param>
        /// <param name="block">MISSING</param>
        public static void dispatch_sync(IntPtr queue, Action block)
        {
            Block __local1 = ObjectiveCRuntime.CreateBlock(block);
            dispatch_sync_Inner(queue, __local1);
            __local1.Dispose();
        }

        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_sync")]
        private static extern void dispatch_sync_Inner(IntPtr queue, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (BlockMarshaler))] Block block);

#endif

#if MACOSX_10_6
        /// <summary>
        /// <para>Submits an application-defined function for synchronous execution on a dispatch queue.</para>
        /// <para>Original signature is 'void dispatch_sync_f(  dispatch_queue_t queue,  void *context,  dispatch_function_t work);'</para>
        /// <para>Available in Mac OS X v10.6 and later.</para>
        /// </summary>
        /// <param name="queue">MISSING</param>
        /// <param name="context">MISSING</param>
        /// <param name="work">MISSING</param>
        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_sync_f")]
        public static extern void dispatch_sync_f(IntPtr queue, IntPtr context, dispatch_function_t work);

#endif

#if MACOSX_10_7
        /// <summary>
        /// <para>Schedule an asynchronous write operation using the specified file descriptor.</para>
        /// <para>Original signature is 'void dispatch_write(  dispatch_fd_t fd,  dispatch_data_t data,  dispatch_queue_t queue,  void (^handler)(dispatch_data_t data, int error));'</para>
        /// <para>Available in Mac OS X v10.7 and later.</para>
        /// </summary>
        /// <param name="fd">MISSING</param>
        /// <param name="data">MISSING</param>
        /// <param name="queue">MISSING</param>
        /// <param name="handler">MISSING</param>
        public static void dispatch_write(int fd, IntPtr data, IntPtr queue, Action<IntPtr, int> handler)
        {
            Block __local1 = ObjectiveCRuntime.CreateBlock(handler);
            dispatch_write_Inner(fd, data, queue, __local1);
            __local1.Dispose();
        }

        [DllImport(
#if MACOSX_10_7
"/usr/lib/system/libdispatch"
#elif MACOSX_10_6
"/usr/lib/libSystem"
#endif
, EntryPoint="dispatch_write")]
        private static extern void dispatch_write_Inner(int fd, IntPtr data, IntPtr queue, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (BlockMarshaler))] Block handler);

#endif

    }

    /// <summary>
    /// <para>Used to select the appropriate global concurrent queue.</para>
    /// </summary>
    [ObjectiveCUnderlyingTypeAttribute(typeof(int), Is64Bits = false)]
    [ObjectiveCUnderlyingTypeAttribute(typeof(long), Is64Bits = true)]
    [GeneratedCodeAttribute("MonobjcGenerator", "0.0.0.0")]
    public enum dispatch_queue_priority_t : int
    {
        /// <summary>
        /// <para>Items dispatched to the queue run at high priority; the queue is scheduled for execution before any default priority or low priority queue.</para>
        /// </summary>
        DISPATCH_QUEUE_PRIORITY_HIGH = 2,
        /// <summary>
        /// <para>Items dispatched to the queue run at the default priority; the queue is scheduled for execution after all high priority queues have been scheduled, but before any low priority queues have been scheduled.</para>
        /// </summary>
        DISPATCH_QUEUE_PRIORITY_DEFAULT = 0,
        /// <summary>
        /// <para>Items dispatched to the queue run at low priority; the queue is scheduled for execution after all default priority and high priority queues have been scheduled.</para>
        /// </summary>
        DISPATCH_QUEUE_PRIORITY_LOW = -2,
    }

    /// <summary>
    /// <para>Mach send event flags.</para>
    /// </summary>
    [ObjectiveCUnderlyingTypeAttribute(typeof(uint), Is64Bits = false)]
    [ObjectiveCUnderlyingTypeAttribute(typeof(ulong), Is64Bits = true)]
    [GeneratedCodeAttribute("MonobjcGenerator", "0.0.0.0")]
    public enum dispatch_source_mach_send_flags_t : uint
    {
        /// <summary>
        /// <para>The receive right corresponding to the given send right was destroyed.</para>
        /// </summary>
        DISPATCH_MACH_SEND_DEAD = 0x1,
    }

    /// <summary>
    /// <para>Process event flags.</para>
    /// </summary>
    [ObjectiveCUnderlyingTypeAttribute(typeof(uint), Is64Bits = false)]
    [ObjectiveCUnderlyingTypeAttribute(typeof(ulong), Is64Bits = true)]
    [GeneratedCodeAttribute("MonobjcGenerator", "0.0.0.0")]
    public enum dispatch_source_proc_flags_t : uint
    {
        /// <summary>
        /// <para>The process has exited (perhaps cleanly, perhaps not).</para>
        /// </summary>
        DISPATCH_PROC_EXIT = 0x80000000,
        /// <summary>
        /// <para>The process has created one or more child processes.</para>
        /// </summary>
        DISPATCH_PROC_FORK = 0x40000000,
        /// <summary>
        /// <para>The process has become another executable image via an exec or posix_spawn function family call.</para>
        /// </summary>
        DISPATCH_PROC_EXEC = 0x20000000,
        /// <summary>
        /// <para>A Unix signal was delivered to the process.</para>
        /// </summary>
        DISPATCH_PROC_SIGNAL = 0x08000000,
    }

    /// <summary>
    /// <para>File-system object event flags.</para>
    /// </summary>
    [ObjectiveCUnderlyingTypeAttribute(typeof(uint), Is64Bits = false)]
    [ObjectiveCUnderlyingTypeAttribute(typeof(ulong), Is64Bits = true)]
    [GeneratedCodeAttribute("MonobjcGenerator", "0.0.0.0")]
    public enum dispatch_source_vnode_flags_t : uint
    {
        /// <summary>
        /// <para>The file-system object was deleted from the namespace.</para>
        /// </summary>
        DISPATCH_VNODE_DELETE = 0x1,
        /// <summary>
        /// <para>The file-system object data changed.</para>
        /// </summary>
        DISPATCH_VNODE_WRITE = 0x2,
        /// <summary>
        /// <para>The file-system object changed in size.</para>
        /// </summary>
        DISPATCH_VNODE_EXTEND = 0x4,
        /// <summary>
        /// <para>The file-system object metadata changed.</para>
        /// </summary>
        DISPATCH_VNODE_ATTRIB = 0x8,
        /// <summary>
        /// <para>The file-system object link count changed.</para>
        /// </summary>
        DISPATCH_VNODE_LINK = 0x10,
        /// <summary>
        /// <para>The file-system object was renamed in the namespace.</para>
        /// </summary>
        DISPATCH_VNODE_RENAME = 0x20,
        /// <summary>
        /// <para>The file-system object was revoked.</para>
        /// </summary>
        DISPATCH_VNODE_REVOKE = 0x40,
    }
}
