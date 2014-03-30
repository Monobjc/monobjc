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
using NUnit.Framework;

namespace Monobjc.Foundation
{
	[TestFixture]
	[Category("NSArray")]
	public class NSArrayTests : WrapperTests
	{
		[Test]
		public void TestStaticCreation ()
		{
			NSArray array = NSArray.Array;
			Check (array);

			Class cls = array.Class;
			Check (cls);

			uint count = array.Count;
			Assert.AreEqual (0, count, "Length must be 0");

			array = NSArray.ArrayWithObject (NSString.String);
			Check (array);
		}

		[Test]
		public void TestVarArgsCreation ()
		{
			NSArray array;

			array = NSArray.ArrayWithObjects (NSNumber.NumberWithInt (123), NSString.StringWithUTF8String ("TEST"), null);
			Check (array);

			array = NSArray.ArrayWithObjects (NSNumber.NumberWithInt (123), NSNumber.NumberWithInt (456), NSNumber.NumberWithInt (789), null);
			Check (array);

			array = NSArray.ArrayWithObjects (NSNumber.NumberWithInt (123), NSString.String, NSNumber.NumberWithInt (789), null);
			Check (array);
		}

		[Test]
		public void TestObjectAtIndex ()
		{
			NSString str1 = NSString.StringWithUTF8String ("ABC");
			NSString str2 = NSString.StringWithUTF8String ("DEF");
			NSString str3 = NSString.StringWithUTF8String ("GHI");
			
			NSArray array = NSArray.ArrayWithObjects (str2, str3, str1, null);
			Check (array);

			for (int i = 0; i < 100; i++) {
				for (int j = 0; j < 3; j++) {
					Id id = array.ObjectAtIndex (j);
					NSString str = array.ObjectAtIndex<NSString> (j);
					Assert.AreEqual (id.NativePointer, str.NativePointer, "Pointer must be equal");
				}
			}
		}
        
        [Test]
        public void TestBlock1 ()
        {
            NSString str1 = NSString.StringWithUTF8String ("ABC");
            NSString str2 = NSString.StringWithUTF8String ("DEF");
            NSString str3 = NSString.StringWithUTF8String ("GHI");

            NSArray array = NSArray.ArrayWithObjects (str2, str3, str1, null);
            Check (array);

            NSComparator sorter = delegate(Id id1, Id id2) {
                //Console.WriteLine(id1.SendMessage<NSString>("description") + " <-> " + id2.SendMessage<NSString>("description"));
                return id1.SendMessage<NSComparisonResult> ("compare:", id2);
            };

            NSArray sorted = array.SortedArrayUsingComparator (sorter);
            Check (sorted);

            Assert.True (sorted.ObjectAtIndex<NSString> (0).IsEqualToString (str1), "Elements must be sorted");
            Assert.True (sorted.ObjectAtIndex<NSString> (1).IsEqualToString (str2), "Elements must be sorted");
            Assert.True (sorted.ObjectAtIndex<NSString> (2).IsEqualToString (str3), "Elements must be sorted");
        }

//        [Test]
//        public void TestBlock2 ()
//        {
//            NSString str1 = NSString.StringWithUTF8String ("ABC");
//            NSString str2 = NSString.StringWithUTF8String ("DEF");
//            NSString str3 = NSString.StringWithUTF8String ("GHI");
//
//            NSArray array = NSArray.ArrayWithObjects (str2, str3, str1, null);
//            Check (array);
//
//            int count = 0;
//            Action_Id_NSUInteger_ref_bool enumerator = delegate(Id obj, NSUInteger idx, ref bool stop) {
//                count++;
//            };
//
//            array.EnumerateObjectsUsingBlock(enumerator);
//
//            Assert.AreEqual(3, count);
//        }

		private static void Check (Id @object)
		{
			Assert.IsNotNull (@object, "Instance cannot be null");
			Assert.AreNotEqual (IntPtr.Zero,  @object.NativePointer, "Native pointer cannot be null");
		}
	}
}
