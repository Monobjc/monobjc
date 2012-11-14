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

namespace Monobjc.CoreMIDI
{
    /// <summary>
    /// <para>A function receiving MIDI input.</para>
    /// <para>This is a callback function through which a client receives incoming MIDI messages.</para>
    /// <para>A MIDIReadProc function pointer is passed to the MIDIInputPortCreate and MIDIDestinationCreate functions.  The CoreMIDI framework will create a high-priority receive thread on your client's behalf, and from that thread, your MIDIReadProc will be called when incoming MIDI messages arrive. Because this function is called from a separate thread, be aware of the synchronization issues when accessing data in this callback.</para>
    /// </summary>
    /// <param name="pktList">The incoming MIDI message(s).</param>
    /// <param name="readProcRefCon">The refCon you passed to MIDIInputPortCreate or MIDIDestinationCreate</param>
    /// <param name="srcConnRefCon">A refCon you passed to MIDIPortConnectSource, which identifies the source of the data.</param>
    public delegate void MIDIReadProc(ref MIDIPacketList pktList, IntPtr readProcRefCon, IntPtr srcConnRefCon);
}