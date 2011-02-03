using System;
using System.Runtime.InteropServices;

namespace Monobjc.CoreMidi
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