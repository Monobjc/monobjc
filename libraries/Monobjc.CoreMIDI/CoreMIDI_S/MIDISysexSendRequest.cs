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
using System.Runtime.InteropServices;

namespace Monobjc.CoreMIDI
{
    /// <summary>
    /// <para>A request to transmit a system-exclusive event.</para>
    /// <para>This represents a request to send a single system-exclusive MIDI event to a MIDI destination asynchronously.</para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct MIDISysexSendRequest
    {
        /// <summary>
        /// <para>The endpoint to which the event is to be sent.</para>
        /// </summary>
        uint destination;
        /// <summary>
        /// <para>Initially, a pointer to the sys-ex event to be sent. MIDISendSysex will advance this pointer as bytes are sent.</para>
        /// </summary>
        IntPtr data;
        /// <summary>
        /// <para>Initially, the number of bytes to be sent. MIDISendSysex will decrement this counter as bytes are sent.</para>
        /// </summary>
        uint bytesToSend;
        /// <summary>
        /// <para>The client may set this to true at any time to abort transmission. The implementation sets this to true when all bytes have been sent.</para>
        /// </summary>
        Boolean complete;
        /// <summary>
        /// <para>Reserved.</para>
        /// </summary>
        uint reserved;
        /// <summary>
        /// <para>Called when all bytes have been sent, or after the client has set complete to true.</para>
        /// </summary>
        MIDICompletionProc completionProc;
        /// <summary>
        /// <para>Passed as a refCon to completionProc.</para>
        /// </summary>
        IntPtr completionRefCon;
    }
}