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
using System.IO;
using System.Reflection;
using Monobjc.AppKit;
using Monobjc.Foundation;
using System.Linq;
using System.Collections.Generic;

namespace Monobjc.AppKit
{
	public partial class NSNib
	{
		public static bool InstantiateNibWithOwnerTopLevelObjects (NSString resourceName, Id owner)
		{
			if (resourceName == null) {
				throw new ArgumentNullException("resourceName");
			}
			if (owner == null) {
				throw new ArgumentNullException("owner");
			}
			return InstantiateNibWithOwnerTopLevelObjects (owner.GetType (), resourceName, owner);
		}
		
		public static bool InstantiateNibWithOwnerTopLevelObjects (Type type, NSString resourceName, Id owner)
		{
			if (resourceName == null) {
				throw new ArgumentNullException("resourceName");
			}

			Assembly assembly = type.Assembly;
			Logger.Info("NSNib", "Searching for '" + resourceName + "' resource in " + assembly.FullName);

			// Lookup the resource name
			IEnumerable<String> resources = assembly.GetManifestResourceNames ().Where(r => r.StartsWith(resourceName));
			if (resources.Count() == 0) {
				return false;
			}
			foreach(String r in resources) {
				Logger.Info("NSNib", "Found '" + r + "'");
			}

			IList<String> candidates = new List<String> ();

			// Check the invariant culture
			String key = resourceName;
			Logger.Info("NSNib", "Probing '" + key + "'...");
			String candidate = resources.FirstOrDefault (r => String.Equals (r, key));
			if (candidate != null) {
				candidates.Add (candidate);
			}

			// Check preferred cultures
			NSArray languages = NSLocale.PreferredLanguages;
			foreach(NSString language in languages.GetEnumerator<NSString>()) {
				key = resourceName + "." + language;
				Logger.Info("NSNib", "Probing '" + key + "'...");
				candidate = resources.FirstOrDefault (r => String.Equals (r, key));
				if (candidate != null) {
					candidates.Add (candidate);
				}
			}

			if (candidates.Count == 0) {
				return false;
			}
			
			bool result = false;
			String name = candidates.First();
			String fileName = Path.Combine (Path.GetTempPath (), Path.GetTempFileName ());
			
			using (Stream fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write)) {
				using (Stream resourceStream = assembly.GetManifestResourceStream(name)) {
					resourceStream.CopyTo (fileStream);
				}
			}
					
			NSNib nib = new NSNib (NSURL.FileURLWithPath (fileName));
			NSArray topLevelObjects;
#if MACOSX_10_8
			result = nib.InstantiateWithOwnerTopLevelObjects(owner, out topLevelObjects);
#else
			result = nib.InstantiateNibWithOwnerTopLevelObjects (owner, out topLevelObjects);
#endif
			nib.Release ();
	
			File.Delete (fileName);

			return result;
		}
	}
}
