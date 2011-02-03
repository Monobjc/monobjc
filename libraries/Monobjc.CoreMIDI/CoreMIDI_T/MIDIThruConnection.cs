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

using Monobjc;
using Monobjc.Foundation;
using System;
using System.CodeDom.Compiler;
using System.Globalization;
using System.Runtime.InteropServices;

namespace Monobjc.CoreMIDI
{
    public static partial class MIDIThruConnection
    {
        /// <summary>
        /// <para>Creates a thru connection.</para>
        /// <para>Original signature is 'externOSStatusMIDIThruConnectionCreate(   CFStringRefinPersistentOwnerID,   CFDataRefinConnectionParams,   MIDIThruConnectionRef *outConnection ) ;'</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        /// <param name="D">MISSING</param>
        /// <param name="s">MISSING</param>
        /// <param name="outConnection">MISSING</param>
        /// <returns>An OSStatus result code.</returns>
        [DllImport("/System/Library/Frameworks/CoreMIDI.framework/CoreMIDI", EntryPoint="MIDIThruConnectionCreate")]
        public static extern int Create(CFStringRefinPersistentOwnerI D, CFDataRefinConnectionParam s, MIDIThruConnectionRef * outConnection);


        /// <summary>
        /// <para>Disposes a thru connection.</para>
        /// <para>Original signature is 'externOSStatusMIDIThruConnectionDispose(   MIDIThruConnectionRefconnection ) ;'</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        /// <param name="n">MISSING</param>
        /// <returns>An OSStatus result code.</returns>
        [DllImport("/System/Library/Frameworks/CoreMIDI.framework/CoreMIDI", EntryPoint="MIDIThruConnectionDispose")]
        public static extern int Dispose(MIDIThruConnectionRefconnectio n);


        /// <summary>
        /// <para>Returns all of the persistent thru connections created by a client.</para>
        /// <para>Original signature is 'externOSStatusMIDIThruConnectionFind(   CFStringRefinPersistentOwnerID,   CFDataRef *outConnectionList ) ;'</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        /// <param name="D">MISSING</param>
        /// <param name="outConnectionList">MISSING</param>
        /// <returns>An OSStatus result code.</returns>
        [DllImport("/System/Library/Frameworks/CoreMIDI.framework/CoreMIDI", EntryPoint="MIDIThruConnectionFind")]
        public static extern int Find(CFStringRefinPersistentOwnerI D, CFDataRef * outConnectionList);


        /// <summary>
        /// <para>Obtains a thru connection's MIDIThruConnectionParams.</para>
        /// <para>Original signature is 'externOSStatusMIDIThruConnectionGetParams(   MIDIThruConnectionRefconnection,   CFDataRef *outConnectionParams ) ;'</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        /// <param name="n">MISSING</param>
        /// <param name="outConnectionParams">MISSING</param>
        /// <returns>An OSStatus result code.</returns>
        [DllImport("/System/Library/Frameworks/CoreMIDI.framework/CoreMIDI", EntryPoint="MIDIThruConnectionGetParams")]
        public static extern int GetParams(MIDIThruConnectionRefconnectio n, CFDataRef * outConnectionParams);


        /// <summary>
        /// <para>Fills a MIDIThruConnectionParams with default values.</para>
        /// <para>Original signature is 'externvoidMIDIThruConnectionParamsInitialize(   MIDIThruConnectionParams *inConnectionParams ) ;'</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        /// <param name="inConnectionParams">MISSING</param>
        [DllImport("/System/Library/Frameworks/CoreMIDI.framework/CoreMIDI", EntryPoint="MIDIThruConnectionParamsInitialize")]
        public static extern void ParamsInitialize(MIDIThruConnectionParams * inConnectionParams);


        /// <summary>
        /// <para>Alters a thru connection's MIDIThruConnectionParams.</para>
        /// <para>Original signature is 'externOSStatusMIDIThruConnectionSetParams(   MIDIThruConnectionRefconnection,   CFDataRefinConnectionParams ) ;'</para>
        /// <para>Available in Mac OS X v10.2 and later.</para>
        /// </summary>
        /// <param name="n">MISSING</param>
        /// <param name="s">MISSING</param>
        /// <returns>An OSStatus result code.</returns>
        [DllImport("/System/Library/Frameworks/CoreMIDI.framework/CoreMIDI", EntryPoint="MIDIThruConnectionSetParams")]
        public static extern int SetParams(MIDIThruConnectionRefconnectio n, CFDataRefinConnectionParam s);


    }
}
