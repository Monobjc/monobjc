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
using System.Globalization;

namespace Monobjc.Foundation
{
    public partial class NSUnarchiver
    {
        /// <summary>
        /// <para>Decodes and returns the object archived in a given NSData object.</para>
        /// <para>Original signature is '+ (id)unarchiveObjectWithData:(NSData *)data'</para>
        /// <para>Available in Mac OS X v10.0 and later.</para>
        /// </summary>
        /// <param name="data">An NSData object that contains an archive created using NSArchiver.</param>
        /// <returns>The object, or object graph, that was archived in data. Returns nil if data cannot be unarchived.</returns>
        public static T UnarchiveObjectWithData<T>(NSData data) where T : Id
        {
            return ObjectiveCRuntime.SendMessage<T>(NSUnarchiverClass, "unarchiveObjectWithData:", data);
        }

        /// <summary>
        /// <para>Decodes and returns the object archived in the file path.</para>
        /// <para>Original signature is '+ (id)unarchiveObjectWithFile:(NSString *)path'</para>
        /// <para>Available in Mac OS X v10.0 and later.</para>
        /// </summary>
        /// <param name="path">The path to a file than contains an archive created using NSArchiver.</param>
        /// <returns>The object, or object graph, that was archived in the file at path. Returns nil if the file at path cannot be unarchived.</returns>
        public static T UnarchiveObjectWithFile<T>(NSString path) where T : Id
        {
            return ObjectiveCRuntime.SendMessage<T>(NSUnarchiverClass, "unarchiveObjectWithFile:", path);
        }
    }
}