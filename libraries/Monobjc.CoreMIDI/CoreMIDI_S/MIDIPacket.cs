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

namespace Monobjc.CoreMIDI
{
    /// <summary>   
    /// <para>A collection of simultaneous MIDI events.</para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct MIDIPacket
    {
        /// <summary>
        /// <para>The time at which the events occurred, if receiving MIDI, or, if sending MIDI, the time at which the events are to be played. Zero means "now." The time stamp applies to the first MIDI byte in the packet.</para>
        /// </summary>
		public ulong timeStamp;
        /// <summary>
        /// <para>The number of valid MIDI bytes which follow, in data. (It may be larger than 256 bytes if the packet is dynamically allocated.)</para>
        /// </summary>
		public ushort length;
        /// <summary>
        /// <para>A variable-length stream of MIDI messages. Running status is not allowed. In the case of system-exclusive messages, a packet may only contain a single message, or portion of one, with no other MIDI events. The MIDI messages in the packet must always be complete, except for system-exclusive. (This is declared to be 256 bytes in length so clients don't have to create custom data structures in simple situations.)</para>
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
		public byte[] data;
    }
}
