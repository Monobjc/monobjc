using System;

namespace Monobjc.CoreMidi
{
    /// <summary>
    /// <para>A callback function for notifying clients of state changes.</para>
    /// <para>This callback function is called when some aspect of the current MIDI setup changes. It is called on the runloop (thread) on which MIDIClientCreate was first called.</para>
    /// </summary>
    /// <param name="message">A structure containing information about what changed.</param>
    /// <param name="refCon">The client's refCon passed to MIDIClientCreate.</param>
    public delegate void MIDINotifyProc(IntPtr message, IntPtr refCon);
}