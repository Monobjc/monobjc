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
using System.Runtime.InteropServices;

namespace Monobjc.ApplicationServices
{
    /// <summary>
    /// <para>Defines a structure containing pointers to client-defined callback functions that manage the sending of data for a sequential-access data provider.</para>
    /// <para>Available in Mac OS X v10.0 and later.</para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct CGDataProviderCallbacks
    {
        /// <summary>
        /// A pointer to a function that copies data from the provider. For more information, see CGDataProviderGetBytesCallback.
        /// </summary>
        public CGDataProviderGetBytesCallback getBytes;

        /// <summary>
        /// A pointer to a function that Quartz calls to advance the stream of data supplied by the provider. For more information, see CGDataProviderSkipBytesCallback.
        /// </summary>
        public CGDataProviderSkipBytesCallback skipBytes;

        /// <summary>
        /// A pointer to a function Quartz calls to return the provider to the beginning of the data stream. For more information, see CGDataProviderRewindCallback.
        /// </summary>
        public CGDataProviderRewindCallback rewind;

        /// <summary>
        /// A pointer to a function that handles clean-up for the data provider, or NULL. For more information, see CGDataProviderReleaseInfoCallback.
        /// </summary>
        public CGDataProviderReleaseInfoCallback releaseProvider;
    }
}