//
// This file is part of Monobjc, a .NET/Objective-C bridge
// Copyright (C) 2007-2012 - Laurent Etiemble
//
// Monobjc is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// any later version.
//
// Monobjc is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with Monobjc.  If not, see <http://www.gnu.org/licenses/>.
//
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Monobjc.Generators;
using NUnit.Framework;

namespace Monobjc
{
#if MACOSX_10_6
    [TestFixture]
    [Category("Blocks")]
    [Category("Runtime")]
    [Description("Test Blocks with dynamically generated classes")]
    public class BlockTests : RuntimeTests
    {
        private BlockGenerator generator;
        private readonly IDictionary<Type, Type> blocks = new Dictionary<Type, Type>();

        [Test]
        public void TestBlock01()
        {
            IntPtr number;
            int value;
            int[] values = new int[256];
			
            // Create random values
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = new Random().Next(1, 65535);
            }

            // Put zero at random index
            values[new Random().Next(values.Length)] = 0;

            // Create a mutable array
            IntPtr array = objc_sendMsg_IntPtr(this.cls_NSMutableArray, this.sel_alloc);
            Assert.AreNotEqual(IntPtr.Zero, array, "NSMutableArray allocation failed");
            array = objc_sendMsg_IntPtr(array, this.sel_init);
            Assert.AreNotEqual(IntPtr.Zero, array, "NSMutableArray initialization failed");

            // Add elements
            for (int i = 0; i < values.Length; i++)
            {
                number = objc_sendMsg_IntPtr_int(this.cls_NSNumber, this.sel_numberWithInt, values[i]);
                Assert.AreNotEqual(IntPtr.Zero, number, "NSNumber '" + values[i] + "' initialization failed");
                objc_sendMsg_void_IntPtr(array, this.sel_addObject, number);
            }

            // Checking the count
            uint count = objc_sendMsg_uint(array, this.sel_count);
            Assert.AreEqual(values.Length, count, "Array's count is wrong");

            // Checking elements
            for (int i = 0; i < values.Length; i++)
            {
                number = objc_sendMsg_IntPtr_uint(array, this.sel_objectAtIndex, (uint) i);
                Assert.AreNotEqual(IntPtr.Zero, number, "Object at index " + i + " is nil");
                value = objc_sendMsg_int(number, this.sel_intValue);
                Assert.AreEqual(values[i], value, "Object at index " + i + " is wrong");
            }

            int lastValue = 0;
            uint zeroIndex = 0;

//			// Enumerate wit a block: void (^)(id, NSUInteger, BOOL *)
//			// TODO: Adapt to 64 bits
//            Block block1 = this.GetBlock((Action<IntPtr, uint, IntPtr>) delegate(IntPtr ptr1, uint ui1, IntPtr ptr2)
//                                                                            {
//                                                                                int v = objc_sendMsg_int(ptr1, this.sel_intValue);
//                                                                                if (v == 0)
//                                                                                {
//                                                                                    // Store the index of the zero value and stop enumeration
//                                                                                    zeroIndex = ui1;
//                                                                                    Marshal.WriteInt32(ptr2, 1);
//                                                                                    return;
//                                                                                }
//                                                                                // Store value if non-zero. On exit, contains the last non-zero value
//                                                                                lastValue = v;
//                                                                            });
//            {
//                // Enumerate in forward order
//                Assert.AreNotEqual(IntPtr.Zero, block1.NativePointer, "Block native structure is nil");
//                objc_sendMsg_void_IntPtr(array, this.sel_enumerateObjectsUsingBlock, block1.NativePointer);
//                int index = Array.FindIndex(values, (v) => (v == 0));
//                Assert.AreEqual(index, zeroIndex, "Index of zero value is wrong");
//                Assert.AreEqual(values[index - 1], lastValue, "Last non-zero value is wrong");
//            }
//            block1.Dispose();

//          // Enumerate wit a block: void (^)(id, NSUInteger, BOOL *)
//			// TODO: Adapt to 64 bits
//			Block block2 = this.GetBlock((Action<IntPtr, uint, IntPtr>) delegate(IntPtr ptr1, uint ui1, IntPtr ptr2)
//                                                                            {
//                                                                                int v = objc_sendMsg_int(ptr1, this.sel_intValue);
//                                                                                if (v == 0)
//                                                                                {
//                                                                                    // Store the index of the zero value and stop enumeration
//                                                                                    zeroIndex = ui1;
//                                                                                    Marshal.WriteInt32(ptr2, 1);
//                                                                                    return;
//                                                                                }
//                                                                                // Store value if non-zero. On exit, contains the last non-zero value
//                                                                                lastValue = v;
//                                                                            });
//            {
//                // Enumerate in backward order
//                Assert.AreNotEqual(IntPtr.Zero, block2.NativePointer, "Block native structure is nil");
//				// TODO: Adapt to 64 bits
//				objc_sendMsg_void_uint_IntPtr(array, this.sel_enumerateObjectsWithOptionsusingBlock, 2 /* NSEnumerateReverse */, block2.NativePointer);
//                int index = Array.FindIndex(values, (v) => (v == 0));
//                Assert.AreEqual(index, zeroIndex, "Index of zero value is wrong");
//                Assert.AreEqual(values[index + 1], lastValue, "Last non-zero value is wrong");
//            }
//            block2.Dispose();

            // Release the array
            objc_sendMsg_void(array, this.sel_release);
		}

        [Test]
        public void TestBlock02()
        {
            IntPtr number;
            int value;
            int[] values = new int[256];

            // Create random values
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = new Random().Next(1, 65535);
            }

            // Create a mutable array
            IntPtr array = objc_sendMsg_IntPtr(this.cls_NSMutableArray, this.sel_alloc);
            Assert.AreNotEqual(IntPtr.Zero, array, "NSMutableArray allocation failed");
            array = objc_sendMsg_IntPtr(array, this.sel_init);
            Assert.AreNotEqual(IntPtr.Zero, array, "NSMutableArray initialization failed");

            // Add elements
            for (int i = 0; i < values.Length; i++)
            {
                number = objc_sendMsg_IntPtr_int(this.cls_NSNumber, this.sel_numberWithInt, values[i]);
                Assert.AreNotEqual(IntPtr.Zero, number, "NSNumber '" + values[i] + "' initialization failed");
                objc_sendMsg_void_IntPtr(array, this.sel_addObject, number);
            }

            // Checking the count
            uint count = objc_sendMsg_uint(array, this.sel_count);
            Assert.AreEqual(values.Length, count, "Array's count is wrong");

            // Checking elements
            for (int i = 0; i < values.Length; i++)
            {
                number = objc_sendMsg_IntPtr_uint(array, this.sel_objectAtIndex, (uint) i);
                Assert.AreNotEqual(IntPtr.Zero, number, "Object at index " + i + " is nil");
                value = objc_sendMsg_int(number, this.sel_intValue);
                Assert.AreEqual(values[i], value, "Object at index " + i + " is wrong");
            }

            // Sort with a block: NSComparisonResult (^)(id, id)
            IntPtr sorted;
            Block block = this.GetBlock((Func<IntPtr, IntPtr, int>) delegate(IntPtr ptr1, IntPtr ptr2) { return objc_sendMsg_int_IntPtr(ptr1, this.sel_compare, ptr2); });
            {
                Assert.AreNotEqual(IntPtr.Zero, block.NativePointer, "Block native structure is nil");
                sorted = objc_sendMsg_IntPtr_IntPtr(array, this.sel_sortedArrayUsingComparator, block.NativePointer);
                Assert.AreNotEqual(IntPtr.Zero, sorted, "Method call failed");
                // Retain the result for the check
                objc_sendMsg_IntPtr(sorted, this.sel_retain);
            }
            block.Dispose();

            // Checking the count
            count = objc_sendMsg_uint(sorted, this.sel_count);
            Assert.AreEqual(values.Length, count, "Array's count is wrong");

            // Checking elements
            Array.Sort(values);
            for (int i = 0; i < values.Length; i++)
            {
                number = objc_sendMsg_IntPtr_uint(sorted, this.sel_objectAtIndex, (uint) i);
                Assert.AreNotEqual(IntPtr.Zero, number, "Object at index " + i + " is nil");
                value = objc_sendMsg_int(number, this.sel_intValue);
                Assert.AreEqual(values[i], value, "Object at index " + i + " is wrong");
            }

            // Release the sorted array
            objc_sendMsg_void(sorted, this.sel_release);

            // Release the array
            objc_sendMsg_void(array, this.sel_release);
        }

        private Block GetBlock(Delegate block)
        {
            if (this.generator == null)
            {
                DynamicAssembly assembly = new DynamicAssembly("BlockGeneratedTests", "MyModule");
                this.generator = new BlockGenerator(assembly, false);
            }

            Type delegateType = block.GetType();
            Type blockProxyType;

            lock (this.blocks)
            {
                if (!this.blocks.TryGetValue(delegateType, out blockProxyType))
                {
                    blockProxyType = this.generator.DefineBlockProxy(delegateType);
                    this.blocks[delegateType] = blockProxyType;
                }
            }

            return (Block) Activator.CreateInstance(blockProxyType, block);
        }
    }
#endif
}