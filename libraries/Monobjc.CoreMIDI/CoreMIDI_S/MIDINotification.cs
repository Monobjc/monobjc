using System;
using System.Runtime.InteropServices;

namespace Monobjc.CoreMidi
{
    /// <summary>
    /// <para>A message describing a system state change.</para>
    /// <para>A MIDINotification is a structure passed to a MIDINotifyProc, when CoreMIDI wishes to inform a client of a change in the state of the system.</para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct MIDINotification
    {
        /// <summary>
        /// <para>type of message</para>
        /// </summary>
        MIDINotificationMessageID messageID;
        /// <summary>
        /// <para>size of the entire message, including messageID and messageSize</para>
        /// </summary>
        UInt32 messageSize;
    }
}