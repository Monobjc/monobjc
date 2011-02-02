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
using Monobjc.Types;
using NUnit.Framework;

namespace Monobjc
{
    [TestFixture]
    [Category("Runtime")]
    [Category("Exposal")]
    [Category("Messaging")]
    [Category("Categories")]
    [Description("Test messaging to the exposed classes")]
    public class CategoriesMessagingTests : RuntimeTests
    {
        [Test]
        public void TestArrayCategoryMessaging()
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

            // Use the category
            count = objc_sendMsg_uint(array, sel_registerName("retrieveCount"));
            Assert.AreEqual(values.Length, count, "Array's count is wrong");

            // Release the array
            objc_sendMsg_void(array, this.sel_release);
        }

        [Test]
        public void TestObjectCategoryMessaging()
        {
            // Create an object
            IntPtr array = objc_sendMsg_IntPtr(this.cls_NSMutableArray, this.sel_alloc);
            Assert.AreNotEqual(IntPtr.Zero, array, "NSMutableArray allocation failed");
            array = objc_sendMsg_IntPtr(array, this.sel_init);
            Assert.AreNotEqual(IntPtr.Zero, array, "NSMutableArray initialization failed");

            uint count1 = objc_sendMsg_uint(array, sel_registerName("retainCount"));
            uint count2 = objc_sendMsg_uint(array, sel_registerName("retrieveRetainCount"));
            Assert.AreEqual(count1, count2, "Retain count must be equals");

            // Release the array
            objc_sendMsg_void(array, this.sel_release);
        }

        [Test]
        public void TestStringCategoryMessaging()
        {
            // Create an object
            IntPtr str = objc_sendMsg_IntPtr(this.cls_NSString, this.sel_string);
            Assert.AreNotEqual(IntPtr.Zero, str, "NSString allocation failed");

            uint count1 = objc_sendMsg_uint(str, sel_registerName("length"));
            uint count2 = objc_sendMsg_uint(str, sel_registerName("retrieveLength"));
            Assert.AreEqual(count1, count2, "Length must be equals");
        }

        /*
        [Test]
        public void TestMessagingException()
        {
            int value = new Random().Next(0, 1000);
            TSObject instance = new TSObject();
            
            try
            {
                ObjectiveCRuntime.SendMessage(instance, "throwNotImplementedException:", value);
                Assert.Fail("Exception should have thrown");
            }
            catch(NotImplementedException ex)
            {
                Assert.IsTrue(true);
            }
            instance.Release();
        }
        */
    }

    [ObjectiveCCategory("NSObject")]
    public static class NSObject_Retrieve
    {
        [ObjectiveCMessage("retrieveRetainCount")]
        public static uint RetrieveRetainCount(this TSObject target)
        {
            return ObjectiveCRuntime.SendMessage<uint>(target, "retainCount");
        }
    }

    [ObjectiveCCategory("NSArray")]
    public static class NSArray_Retrieve
    {
        [ObjectiveCMessage("retrieveCount")]
        public static uint RetrieveCount(this TSArray target)
        {
            return ObjectiveCRuntime.SendMessage<uint>(target, "count");
        }
    }

    [ObjectiveCCategory("NSString")]
    public static class NSString_Retrieve
    {
        [ObjectiveCMessage("retrieveLength")]
        public static uint RetrieveLength(this TSString target)
        {
            return ObjectiveCRuntime.SendMessage<uint>(target, "length");
        }
    }

    [ObjectiveCCategory("NSObject")]
    public static class NSObject_Exceptions
    {
        [ObjectiveCMessage("throwNotImplementedException:")]
        public static void ThrowNotImplementedException(this TSObject target, int value)
        {
            //throw new NotImplementedException("value=" + value);
        }
    }
}