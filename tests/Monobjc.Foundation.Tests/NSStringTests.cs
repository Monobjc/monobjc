//
// This file is part of Monobjc, a .NET/Objective-C bridge
// Copyright (C) 2007-2011 - Laurent Etiemble
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
        public void TestExceptions()
        {
            Assert.Throws<ObjectiveCMessagingException>(() => { NSString str1 = NSString.StringWithUTF8String(null); });
        }

        private static void Check(NSString str, int length)
        {
            Assert.IsNotNull(str, "String cannot be null");
            Assert.AreNotEqual(IntPtr.Zero, str.NativePointer, "Native pointer cannot be null");
            Assert.AreEqual(length, str.Length, "String has wrong size");
        }
    }
}