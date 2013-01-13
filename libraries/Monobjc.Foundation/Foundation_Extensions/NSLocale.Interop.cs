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
using System.IO;
using System.Reflection;
using Monobjc.Foundation;

namespace Monobjc.Foundation
{
	public partial class NSLocale
	{
		/// <summary>
		/// <para>Returns the object corresponding to the specified key.</para>
		/// <para>Original signature is '- (id)objectForKey:(id)key'</para>
		/// <para>Available in Mac OS X v10.4 and later.</para>
		/// </summary>
		/// <param name="key">The key for which to return the corresponding value. For valid values of key, see “Constants.”</param>
		/// <returns>The object corresponding to key.</returns>
		public virtual T ObjectForKey<T> (Id key) where T : Id
		{
			return ObjectiveCRuntime.SendMessage<T> (this, "objectForKey:", key);
		}
		
		/// <summary>
		/// Convert a <see cref="Monobjc.Foundation.NSLocale"/> instance into a <see cref="System.Globalization.CultureInfo"/> one.
		/// </summary>
		/// <seealso cref="https://developer.apple.com/library/mac/#documentation/MacOSX/Conceptual/BPInternational/Articles/LanguageDesignations.html"/>
		public CultureInfo ToCultureInfo ()
		{
			String language = this.ObjectForKey<NSString> (NSLocale.NSLocaleLanguageCode);
			String country = this.ObjectForKey<NSString> (NSLocale.NSLocaleCountryCode);
			
			String[] names = new String[]{
				String.Format ("{0}-{1}", language, country),
				language,
				String.Empty,
			};
			
			foreach(String name in names) {
				try {
					return CultureInfo.GetCultureInfo (name);
				} catch (Exception) {
					// Ignore
				}
			}
			
			// TODO: I18N
			throw new CultureNotFoundException("Unsupported locale: " + this.LocaleIdentifier);
		}
	}
		
	public static class NSLocale_Extensions
	{
		/// <summary>
		/// Convert a <see cref="System.Globalization.CultureInfo"/> instance into a <see cref="Monobjc.Foundation.NSLocale"/> one.
		/// </summary>
		public static NSLocale ToLocale (this CultureInfo cultureInfo)
		{
			String name = cultureInfo.ToString ();
			name = name.Replace ("-", "_");
			return new NSLocale (name).Autorelease<NSLocale> ();
		}
	}
}
