using System.Runtime.InteropServices;

namespace Monobjc.CoreMidi
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
        ulong timeStamp;
        /// <summary>
        /// <para>The number of valid MIDI bytes which follow, in data. (It may be larger than 256 bytes if the packet is dynamically allocated.)</para>
        /// </summary>
        ushort length;
        /// <summary>
        /// <para>A variable-length stream of MIDI messages. Running status is not allowed. In the case of system-exclusive messages, a packet may only contain a single message, or portion of one, with no other MIDI events. The MIDI messages in the packet must always be complete, except for system-exclusive. (This is declared to be 256 bytes in length so clients don't have to create custom data structures in simple situations.)</para>
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        byte[] data;
    }
}