//
// This file is part of Monobjc, a .NET/Objective-C bridge
// Copyright (C) 2007-2013 - Laurent Etiemble
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
    [Category("NSString")]
    [Description("Test with NSString wrapper")]
    public class NSStringTests : WrapperTests
    {
        [Test]
        public void TestStaticCreation()
        {
            NSString str = NSString.String;
            Check(str, 0);

            str = NSString.StringWithUTF8String("ABCDEFGHIJKLMNOPQRSTUVWXYZ");
            Check(str, 26);

            str = NSString.StringWithString(str);
            Check(str, 26);
        }

        [Test]
        public void TestOperations()
		{
            NSString str1 = NSString.StringWithUTF8String("abcdefghijklmnopqrstuvwxyz");
            Check(str1, 26);

            NSString str2 = NSString.StringWithUTF8String("ABCDEFGHIJKLMNOPQRSTUVWXYZ");
            Check(str2, 26);

            NSString str3 = str1.UppercaseString;
            Check(str3, 26);

            NSString str4 = str2.LowercaseString;
            Check(str4, 26);

            Assert.IsFalse(str1.IsEqualToString(str2), "Strings cannot be equals");
            Assert.IsFalse(str3.IsEqualToString(str4), "Strings cannot be equals");
            Assert.IsTrue(str1.IsEqualToString(str4), "Strings must be equals");
            Assert.IsTrue(str2.IsEqualToString(str3), "Strings must be equals");

            NSString str5 = str1.SubstringToIndex(13);
            Check(str5, 13);

            NSString str6 = str2.SubstringFromIndex(13);
            Check(str6, 13);
        }

        [Test]
        public void TestEncoding()
        {
            // Check ASCII characters
            NSString str1 = NSString.StringWithUTF8String("abcdefghijklmnopqrstuvwxyz");
            Check(str1, 26);
            String tostr1 = str1.ToString();
            Assert.AreEqual(26, tostr1.Length, "String has the wrong size");
            Assert.AreEqual("abcdefghijklmnopqrstuvwxyz", tostr1, "String must match");

            // Check Cyrillic characters
            NSString str2 = NSString.StringWithUTF8String("АБВГДЕЖЗИЙКЛМНОП");
            Check(str2, 16);
            String tostr2 = str2.ToString();
            Assert.AreEqual(16, tostr2.Length, "String has the wrong size");
            Assert.AreEqual("АБВГДЕЖЗИЙКЛМНОП", tostr2, "String must match");
            
            // Check Devanagari characters
            NSString str3 = NSString.StringWithUTF8String("ऑऒओऔ");
            Check(str3, 4);
            String tostr3 = str3.ToString();
            Assert.AreEqual(4, tostr3.Length, "String has the wrong size");
            Assert.AreEqual("ऑऒओऔ", tostr3, "String must match");

            // Check Cherokee characters
            NSString str4 = NSString.StringWithUTF8String("ᎰᎱᎲᎳᎴ");
            Check(str4, 5);
            String tostr4 = str4.ToString();
            Assert.AreEqual(5, tostr4.Length, "String has the wrong size");
            Assert.AreEqual("ᎰᎱᎲᎳᎴ", tostr4, "String must match");
            
            // Check Mathematical Symbols characters
            NSString str5 = NSString.StringWithUTF8String("∀∁∂∃∄∅∆∇∈∉∊∋");
            Check(str5, 12);
            String tostr5 = str5.ToString();
            Assert.AreEqual(12, tostr5.Length, "String has the wrong size");
            Assert.AreEqual("∀∁∂∃∄∅∆∇∈∉∊∋", tostr5, "String must match");

            // Check CJK Unified Ideographs characters
            NSString str6 = NSString.StringWithUTF8String("瀀瀁瀂瀃瀄瀅瀆瀇瀈瀉瀊瀋瀌瀍");
            Check(str6, 14);
            String tostr6 = str6.ToString();
            Assert.AreEqual(14, tostr6.Length, "String has the wrong size");
            Assert.AreEqual("瀀瀁瀂瀃瀄瀅瀆瀇瀈瀉瀊瀋瀌瀍", tostr6, "String must match");
        }

        [Test]
        public void TestExceptions()
        {
            Assert.Throws<ObjectiveCMessagingException>(() => { NSString.StringWithUTF8String(null); });
        }

        private static void Check(NSString str, int length)
        {
            Assert.IsNotNull(str, "String cannot be null");
            Assert.AreNotEqual(IntPtr.Zero, str.NativePointer, "Native pointer cannot be null");
            Assert.AreEqual(length, str.Length, "String has the wrong size");
        }
    }
}