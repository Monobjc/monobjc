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

namespace Monobjc.AppKit
{
    public static class NSBundle_MonobjcAdditions
    {
        /// <summary>
        /// 	<para>Unarchives the contents of the nib found in resources and links them to a specific owner object.</para>
        /// </summary>
        /// <param name="bundle">The bundle.</param>
        /// <param name="type">The type whose assmelby contains the nib resource.</param>
        /// <param name="resourceName">The name of the nib file, which need not include the .nib extension. The file name should not include path information. The object in the owner parameter determines the location in which to look for the nib file.</param>
        /// <param name="owner">The object to assign as the nib FIle's Owner. If the class of this object has an associated bundle, that bundle is searched for the specified nib file; otherwise, this method looks in the main bundle.</param>
        /// <returns>
        /// YES if the nib file was loaded successfully; otherwise, NO.
        /// </returns>
        [Obsolete]
        public static bool LoadNibResourceNamedOwner(this NSBundle bundle, Type type, NSString resourceName, Id owner)
        {
            bool result = false;
            Assembly assembly = type.Assembly;

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                if (stream != null)
                {
                    byte[] buffer = new byte[stream.Length];
                    stream.Read(buffer, 0, (int)stream.Length);
                    stream.Close();

                    String fileName = Path.GetTempFileName();
                    File.WriteAllBytes(fileName, buffer);

					NSNib nib = new NSNib(NSURL.URLWithString(fileName));
					NSArray topLevelObjects;
					result = nib.InstantiateNibWithOwnerTopLevelObjects(owner, out topLevelObjects);
					nib.Release();

                    File.Delete(fileName);
                }
            }

            return result;
        }
    }
}
