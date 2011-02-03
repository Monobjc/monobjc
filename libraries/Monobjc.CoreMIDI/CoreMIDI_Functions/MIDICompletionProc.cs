using System;

namespace Monobjc.CoreMidi
{
    /// <summary>
    /// <para>A function called when a system-exclusive event has been completely sent.</para>
    /// <para>Callback function to notify the client of the completion of a call to MIDISendSysex.</para>
    /// </summary>
    /// <param name="request">The MIDISysexSendRequest which has completed, or been aborted.</param>
    public delegate void MIDICompletionProc(IntPtr request);
}