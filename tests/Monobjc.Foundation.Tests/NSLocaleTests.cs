//
// This file is part of Monobjc, a .NET/Objective-C bridge
// Copyright (C) 2007-2012 - Laurent Etiemble
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
using System.Globalization;
using Monobjc.Foundation;
using NUnit.Framework;

namespace Monobjc.Foundation
{
	[TestFixture]
	[Category("NSLocale")]
	[Description("Test with NSLocale wrapper")]
	public class NSLocaleTests : WrapperTests
	{
		[Test]
		public void TestStaticCreation ()
		{
			NSLocale locale;

			locale = NSLocale.CurrentLocale;
			Check (locale);

			locale = NSLocale.SystemLocale;
			Check (locale);
		}

		[Test]
		public void TestConversion ()
		{
			NSLocale locale;
			CultureInfo info;
			
			locale = new NSLocale("en");
			Assert.AreEqual("en", locale.LocaleIdentifier.ToString(), "Identifier should be equal");
			Check (locale);
			
			info = locale.ToCultureInfo ();
			Assert.AreEqual("en", info.Name, "Display name should be equal");

			locale = new NSLocale("en-US");
			Assert.AreEqual("en-US", locale.LocaleIdentifier.ToString(), "Identifier should be equal");
			Assert.AreEqual("en", locale.ObjectForKey<NSString>(NSLocale.NSLocaleLanguageCode).ToString(), "Language values should be equal");
			Assert.AreEqual("US", locale.ObjectForKey<NSString>(NSLocale.NSLocaleCountryCode).ToString(), "Country values should be equal");
			Check (locale);
			
			info = locale.ToCultureInfo ();
			Assert.AreEqual("en-US", info.Name, "Display name should be equal");

			locale = new NSLocale("fr_FR");
			Assert.AreEqual("fr_FR", locale.LocaleIdentifier.ToString(), "Identifier should be equal");
			Assert.AreEqual("fr", locale.ObjectForKey<NSString>(NSLocale.NSLocaleLanguageCode).ToString(), "Language values should be equal");
			Assert.AreEqual("FR", locale.ObjectForKey<NSString>(NSLocale.NSLocaleCountryCode).ToString(), "Country values should be equal");
			Check (locale);
			
			info = locale.ToCultureInfo ();
			Assert.AreEqual("fr-FR", info.Name, "Display name should be equal");

			locale = new NSLocale("zh-Hant_TW");
			Assert.AreEqual("zh_TW", locale.LocaleIdentifier.ToString(), "Identifier should be equal");
			Assert.AreEqual("zh", locale.ObjectForKey<NSString>(NSLocale.NSLocaleLanguageCode).ToString(), "Language values should be equal");
			Assert.AreEqual("TW", locale.ObjectForKey<NSString>(NSLocale.NSLocaleCountryCode).ToString(), "Country values should be equal");
			Check (locale);
			
			info = locale.ToCultureInfo ();
			Assert.AreEqual("zh-TW", info.Name, "Display name should be equal");
		}

		[Test]
		public void TestEnumeration() {
			CultureInfo info;
			NSArray list;

			list = NSLocale.AvailableLocaleIdentifiers;
			Assert.IsNotNull(list);

			list = NSLocale.PreferredLanguages;
			Assert.IsNotNull(list);
		}

		private static void Check (Id @object)
		{
			Assert.IsNotNull (@object, "Instance cannot be null");
			Assert.AreNotEqual (IntPtr.Zero,  @object.NativePointer, "Native pointer cannot be null");
		}
	}
}