using System;
using System.Runtime.InteropServices;

namespace Monobjc.CoreMidi
{
    /// <summary>
    /// <para>A list of MIDI events being received from, or being sent to, one endpoint.</para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct MIDIPacketList
    {
        /// <summary>
        /// <para>The number of MIDIPackets in the list.</para>
        /// </summary>
        UInt32 numPackets;
        /// <summary>
        /// <para>An open-ended array of variable-length MIDIPackets.</para>
        /// </summary>
        IntPtr packet;
    }
}