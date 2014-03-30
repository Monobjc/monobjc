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
using System.Runtime.InteropServices;

namespace Monobjc.ApplicationServices
{
    /// <summary>
    /// <para>Defines pointers to client-defined callback functions that manage the sending of data for a direct-access data provider.</para>
    /// <para>Available in Mac OS X v10.5 and later.</para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct CGDataProviderDirectCallbacks
    {
        /// <summary>
        /// The version of this structure. It should be set to 0.
        /// </summary>
        public uint version;

        /// <summary>
        /// A pointer to a function that returns a pointer to the provider's data. For more information, see CGDataProviderGetBytePointerCallback.
        /// </summary>
        public CGDataProviderGetBytePointerCallback getBytePointer;

        /// <summary>
        /// A pointer to a function that Quartz calls to release a pointer to the provider's data. For more information, see CGDataProviderReleaseBytePointerCallback.
        /// </summary>
        public CGDataProviderReleaseBytePointerCallback releaseBytePointer;

        /// <summary>
        /// A pointer to a function that copies data from the provider.
        /// </summary>
        public CGDataProviderGetBytesAtPositionCallback getBytesAtPosition;

        /// <summary>
        /// A pointer to a function that handles clean-up for the data provider, or NULL. For more information, see CGDataProviderReleaseInfoCallback.
        /// </summary>
        public CGDataProviderReleaseInfoCallback releaseInfo;
    }
}