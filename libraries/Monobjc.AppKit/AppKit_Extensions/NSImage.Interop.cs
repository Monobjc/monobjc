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
using System.IO;
using System.Reflection;
using Monobjc.Foundation;

namespace Monobjc.AppKit
{
    public partial class NSImage
    {
        /// <summary>
        /// Create a <see cref="NSImage"/> from a file.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <returns>An autoreleased <see cref="NSImage"/> instance</returns>
        public static NSImage ImageFromFile(NSString filename)
        {
            NSImage result = null;
            if (filename != null)
            {
                NSData data = NSData.DataWithContentsOfFile(filename);
                result = new NSImage(data);
                result.Autorelease();
            }
            return result;
        }

        /// <summary>
        /// Create a <see cref="NSImage"/> from a stream.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <returns>An autoreleased <see cref="NSImage"/> instance</returns>
        public static NSImage ImageFromStream(Stream stream)
        {
            NSImage result = null;
            if (stream != null)
            {
                byte[] buffer = new byte[stream.Length];
                stream.Read(buffer, 0, (int)stream.Length);

                NSData data = new NSData(buffer);
                result = new NSImage(data);
                data.Release();

                result.Autorelease();
            }
            return result;
        }

        /// <summary>
        /// <para>Create a <see cref="NSImage"/> from a manifest resource stream.</para>
        /// <para>Once retrieved, the instance is named and cached.</para>
        /// </summary>
        /// <param name="type">The type whose assembly contains the manifest resource.</param>
        /// <param name="resourceName">Name of the resource.</param>
        /// <returns>An autoreleased <see cref="NSImage"/> instance</returns>
        public static NSImage ImageFromResource(Type type, String resourceName)
        {
            Assembly assembly = type.Assembly;

            String imageName = assembly.GetName().FullName + "." + resourceName;
            NSImage image = ImageNamed(imageName);
            if (image == null)
            {
                using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                {
                    if (stream != null)
                    {
                        image = ImageFromStream(stream);
                        image.SetName(imageName);
                        stream.Close();
                    }
                }
            }

            return image;
        }
    }
}