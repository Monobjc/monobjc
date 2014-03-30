//
// This file is part of Monobjc, a .NET/Objective-C bridge
// Copyright (C) 2007-2014 - Laurent Etiemble
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
using System.Runtime.InteropServices;
using NUnit.Framework;

namespace Monobjc
{
    public class RuntimeTests
    {
        protected IntPtr cls_NSArray;
        protected IntPtr cls_NSAutoreleasePool;
        protected IntPtr cls_NSIndexSet;
        protected IntPtr cls_NSMutableArray;
        protected IntPtr cls_NSNumber;
        protected IntPtr cls_NSString;
        protected IntPtr cls_NSValue;

        protected IntPtr sel_alloc;
        protected IntPtr sel_addObject;
        protected IntPtr sel_autorelease;
        protected IntPtr sel_boolValue;
        protected IntPtr sel_compare;
        protected IntPtr sel_count;
        protected IntPtr sel_doubleValue;
        protected IntPtr sel_enumerateObjectsUsingBlock;
        protected IntPtr sel_enumerateObjectsWithOptionsusingBlock;
        protected IntPtr sel_floatValue;
        protected IntPtr sel_frame;
        protected IntPtr sel_init;
        protected IntPtr sel_intValue;
        protected IntPtr sel_length;
        protected IntPtr sel_mainScreen;
        protected IntPtr sel_numberWithBool;
        protected IntPtr sel_numberWithDouble;
        protected IntPtr sel_numberWithFloat;
        protected IntPtr sel_numberWithInt;
        protected IntPtr sel_numberWithShort;
        protected IntPtr sel_objectAtIndex;
        protected IntPtr sel_retain;
        protected IntPtr sel_release;
        protected IntPtr sel_shortValue;
        protected IntPtr sel_sortedArrayUsingComparator;
        protected IntPtr sel_isEqualToValue;
        protected IntPtr sel_pointValue;
        protected IntPtr sel_rangeValue;
        protected IntPtr sel_rectValue;
        protected IntPtr sel_sizeValue;
        protected IntPtr sel_string;
        protected IntPtr sel_stringWithUTF8String;
        protected IntPtr sel_stringWithCharactersLength;
        protected IntPtr sel_stringWithString;
        protected IntPtr sel_valueWithPoint;
        protected IntPtr sel_valueWithRange;
        protected IntPtr sel_valueWithRect;
        protected IntPtr sel_valueWithSize;

        private IntPtr pool;

        [TestFixtureSetUp]
        public virtual void TestFixtureSetUp()
        {
            // Loading Frameworks
            LoadSystemFramework("Cocoa");
            // Prepare the runtime			
            ObjectiveCRuntime.Initialize();

            // Get Classes
            this.cls_NSArray = GetClass("NSArray");
            this.cls_NSAutoreleasePool = GetClass("NSAutoreleasePool");
            this.cls_NSIndexSet = GetClass("NSIndexSet");
            this.cls_NSMutableArray = GetClass("NSMutableArray");
            this.cls_NSNumber = GetClass("NSNumber");
            this.cls_NSString = GetClass("NSString");
            this.cls_NSValue = GetClass("NSValue");

            // Get Selectors
            this.sel_alloc = GetSelector("alloc");
            this.sel_addObject = GetSelector("addObject:");
            this.sel_autorelease = GetSelector("autorelease");
            this.sel_boolValue = GetSelector("boolValue");
            this.sel_compare = GetSelector("compare:");
            this.sel_count = GetSelector("count");
            this.sel_doubleValue = GetSelector("doubleValue");
            this.sel_enumerateObjectsUsingBlock = GetSelector("enumerateObjectsUsingBlock:");
            this.sel_enumerateObjectsWithOptionsusingBlock = GetSelector("enumerateObjectsWithOptions:usingBlock:");
            this.sel_floatValue = GetSelector("floatValue");
            this.sel_frame = GetSelector("frame");
            this.sel_init = GetSelector("init");
            this.sel_intValue = GetSelector("intValue");
            this.sel_isEqualToValue = GetSelector("isEqualToValue:");
            this.sel_length = GetSelector("length");
            this.sel_mainScreen = GetSelector("mainScreen");
            this.sel_numberWithBool = GetSelector("numberWithBool:");
            this.sel_numberWithDouble = GetSelector("numberWithDouble:");
            this.sel_numberWithFloat = GetSelector("numberWithFloat:");
            this.sel_numberWithInt = GetSelector("numberWithInt:");
            this.sel_numberWithShort = GetSelector("numberWithShort:");
            this.sel_sortedArrayUsingComparator = GetSelector("sortedArrayUsingComparator:");
            this.sel_objectAtIndex = GetSelector("objectAtIndex:");
            this.sel_pointValue = GetSelector("pointValue");
            this.sel_rangeValue = GetSelector("rangeValue");
            this.sel_rectValue = GetSelector("rectValue");
            this.sel_retain = GetSelector("retain");
            this.sel_release = GetSelector("release");
            this.sel_shortValue = GetSelector("shortValue");
            this.sel_sizeValue = GetSelector("sizeValue");
            this.sel_string = GetSelector("string");
            this.sel_stringWithUTF8String = GetSelector("stringWithUTF8String:");
            this.sel_stringWithCharactersLength = GetSelector("stringWithCharacters:length:");
            this.sel_stringWithString = GetSelector("stringWithString:");
            this.sel_valueWithPoint = GetSelector("valueWithPoint:");
            this.sel_valueWithRange = GetSelector("valueWithRange:");
            this.sel_valueWithRect = GetSelector("valueWithRect:");
            this.sel_valueWithSize = GetSelector("valueWithSize:");
        }

        [SetUp]
        public void SetUp()
        {
            // Create an autorelease pool
            this.pool = objc_sendMsg_IntPtr(this.cls_NSAutoreleasePool, this.sel_alloc);
            Assert.AreNotEqual(IntPtr.Zero, this.pool, "NSAutoreleasePool allocation failed");
            this.pool = objc_sendMsg_IntPtr(this.pool, this.sel_init);
            Assert.AreNotEqual(IntPtr.Zero, this.pool, "NSAutoreleasePool initialization failed");
        }

        [TearDown]
        public void TearDown()
        {
            // Release the pool
            objc_sendMsg_void(this.pool, this.sel_release);
        }

        protected static void LoadSystemFramework(String name)
        {
            dlopen(String.Format("/System/Library/Frameworks/{0}.Framework/{0}", name), 0x02);
        }

        protected static IntPtr GetClass(String name)
        {
            IntPtr ptr = objc_getClass(name);
            Assert.AreNotEqual(IntPtr.Zero, ptr, "Class '" + name + "' must exists.");
            return ptr;
        }

        protected static IntPtr GetSelector(String name)
        {
            IntPtr ptr = sel_registerName(name);
            Assert.AreNotEqual(IntPtr.Zero, ptr, "Selector '" + name + "' must exists.");
            return ptr;
        }

        [DllImport("libSystem", CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern IntPtr dlopen([MarshalAs(UnmanagedType.LPStr)] String path, int type);

        [DllImport("libobjc", CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern IntPtr objc_getClass([MarshalAs(UnmanagedType.LPStr)] String aClassName);

        [DllImport("libobjc", CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern IntPtr sel_registerName([MarshalAs(UnmanagedType.LPStr)] String str);

        [DllImport("libobjc", EntryPoint = "objc_msgSend")]
        public static extern void objc_sendMsg_void(IntPtr theReceiver, IntPtr theSelector);

        [DllImport("libobjc", EntryPoint = "objc_msgSend")]
        public static extern void objc_sendMsg_void_IntPtr(IntPtr theReceiver, IntPtr theSelector, IntPtr ptr1);

        [DllImport("libobjc", EntryPoint = "objc_msgSend")]
        public static extern void objc_sendMsg_void_uint_IntPtr(IntPtr theReceiver, IntPtr theSelector, uint ui1, IntPtr ptr1);

        [DllImport("libobjc", EntryPoint = "objc_msgSend")]
        public static extern bool objc_sendMsg_bool_bool(IntPtr theReceiver, IntPtr theSelector, bool b1);

        [DllImport("libobjc", EntryPoint = "objc_msgSend")]
        public static extern IntPtr objc_sendMsg_IntPtr(IntPtr theReceiver, IntPtr theSelector);

        [DllImport("libobjc", EntryPoint = "objc_msgSend")]
        public static extern IntPtr objc_sendMsg_IntPtr_IntPtr(IntPtr theReceiver, IntPtr theSelector, IntPtr ptr1);

        [DllImport("libobjc", EntryPoint = "objc_msgSend")]
        public static extern IntPtr objc_sendMsg_IntPtr_int(IntPtr theReceiver, IntPtr theSelector, int i1);

        [DllImport("libobjc", EntryPoint = "objc_msgSend")]
        public static extern IntPtr objc_sendMsg_IntPtr_uint(IntPtr theReceiver, IntPtr theSelector, uint ui1);

        [DllImport("libobjc", EntryPoint = "objc_msgSend")]
        public static extern int objc_sendMsg_int(IntPtr theReceiver, IntPtr theSelector);

        [DllImport("libobjc", EntryPoint = "objc_msgSend")]
        public static extern int objc_sendMsg_int_IntPtr(IntPtr theReceiver, IntPtr theSelector, IntPtr ptr1);

		[DllImport("libobjc", EntryPoint = "objc_msgSend")]
		public static extern uint objc_sendMsg_uint(IntPtr theReceiver, IntPtr theSelector);
		
		[DllImport("libobjc", EntryPoint = "objc_msgSend")]
		public static extern ulong objc_sendMsg_ulong(IntPtr theReceiver, IntPtr theSelector);
		
		[DllImport("libobjc", EntryPoint = "objc_msgSend")]
        public static extern uint objc_sendMsg_uint_IntPtr(IntPtr theReceiver, IntPtr theSelector, IntPtr ptr1);

        [DllImport("libobjc", CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern IntPtr object_getInstanceVariable(IntPtr target, [MarshalAs(UnmanagedType.LPStr)] String name, IntPtr value);

        [DllImport("libobjc", CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern IntPtr object_setInstanceVariable(IntPtr target, [MarshalAs(UnmanagedType.LPStr)] String name, IntPtr value);
    }
}