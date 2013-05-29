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
using Monobjc.Foundation;

namespace Monobjc.AppKit
{
    public partial class NSImage
    {
        private const String ENCRYPTED_PREFIX = "$Encrypted$";

        /// <summary>
        /// <para>Returns the NSImage instance associated with the specified name (from an encrypted content).</para>
        /// </summary>
        /// <param name="name">The name associated with the desired image.</param>
        /// <param name="encryptionSeed">The encryption seed to use.</param>
        /// <returns>The NSImage object associated with the specified name, or nil if no such image was found.</returns>
        public static NSImage ImageEncryptedNamed(NSString name, NSString encryptionSeed)
        {
            NSString fullName = ENCRYPTED_PREFIX + name;

            // Search for an object whose name was explicitly set
            NSImage image = NSImage.ImageNamed(fullName);
            if (image != null)
            {
                return image;
            }

            // Search the application's main bundle for a file whose name matches the specified string.
            NSString path = NSBundle.MainBundle.PathForImageResource(name);
            if (path != null)
            {
                image = ImageFromEncryptedPath(path, encryptionSeed);
                if (image != null)
                {
                    image.SetName(fullName);
                }
            }

            return image;
        }

        /// <summary>
        /// Decrypts the given data and return an image.
        /// </summary>
        /// <param name="encryptedData">The encrypted artwork data.</param>
        /// <param name="encryptionSeed">The encryption seed to use.</param>
        /// <returns>The decrypted artwork image.</returns>
        public static NSImage ImageFromEncryptedData(NSData encryptedData, NSString encryptionSeed)
        {
            NSData decryptedData = NSData.DecryptData(encryptedData, encryptionSeed);
            NSImage image = new NSImage(decryptedData);
            return image.SafeAutorelease<NSImage>();
        }
        
        /// <summary>
        /// Decrypts the given resource and return an image.
        /// </summary>
        /// <param name="path">The image resource path.</param>
        /// <param name="encryptionSeed">The encryption seed to use.</param>
        /// <returns>The decrypted artwork image.</returns>
        public static NSImage ImageFromEncryptedPath(NSString path, NSString encryptionSeed)
        {
            NSData encryptedData = NSData.DataWithContentsOfFile(path);
            return ImageFromEncryptedData(encryptedData, encryptionSeed);
        }
        
        /// <summary>
        /// Decrypts the given resource and return an image.
        /// </summary>
        /// <param name="name">The image resource name.</param>
        /// <param name="encryptionSeed">The encryption seed to use.</param>
        /// <returns>The decrypted artwork image.</returns>
        public static NSImage ImageFromEncryptedResource(NSString name, NSString encryptionSeed)
        {
            NSString path = NSBundle.MainBundle.PathForImageResource(name);
            return ImageFromEncryptedPath(path, encryptionSeed);
        }
    }
}
