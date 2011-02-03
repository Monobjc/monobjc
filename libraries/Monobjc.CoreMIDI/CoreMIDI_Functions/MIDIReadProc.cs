using System;

namespace Monobjc.CoreMidi
{
    /// <summary>
    /// <para>A function receiving MIDI input.</para>
    /// <para>This is a callback function through which a client receives incoming MIDI messages.</para>
    /// <para>A MIDIReadProc function pointer is passed to the MIDIInputPortCreate and MIDIDestinationCreate functions.  The CoreMIDI framework will create a high-priority receive thread on your client's behalf, and from that thread, your MIDIReadProc will be called when incoming MIDI messages arrive. Because this function is called from a separate thread, be aware of the synchronization issues when accessing data in this callback.</para>
    /// </summary>
    /// <param name="pktList">The incoming MIDI message(s).</param>
    /// <param name="readProcRefCon">The refCon you passed to MIDIInputPortCreate or MIDIDestinationCreate</param>
    /// <param name="srcConnRefCon">A refCon you passed to MIDIPortConnectSource, which identifies the source of the data.</param>
    public delegate void MIDIReadProc(IntPtr pktList, IntPtr readProcRefCon, IntPtr srcConnRefCon);
}