namespace Monobjc.CoreMidi
{
    /// <summary>
    /// <para>The error constants unique to Core MIDI.</para>
    /// <para>These are the error constants that are unique to Core MIDI. Note that Core MIDI functions may return other codes that are not listed here.</para>
    /// <para>Available in Mac OS X v10.4 and later.</para>
    /// </summary>
    public enum MIDIErrors
    {
        /// <summary>
        /// <para>An invalid MIDIClientRef was passed.</para>
        /// <para>Available in Mac OS X v10.4 and later.</para>
        /// </summary>
        kMIDIInvalidClient = -10830,
        /// <summary>
        /// <para>An invalid MIDIPortRef was passed.</para>
        /// <para>Available in Mac OS X v10.4 and later.</para>
        /// </summary>
        kMIDIInvalidPort = -10831,
        /// <summary>
        /// <para>A source endpoint was passed to a function expecting a destination, or vice versa.</para>
        /// <para>Available in Mac OS X v10.4 and later.</para>
        /// </summary>
        kMIDIWrongEndpointType = -10832,
        /// <summary>
        /// <para>Attempt to close a non-existant connection.</para>
        /// <para>Available in Mac OS X v10.4 and later.</para>
        /// </summary>
        kMIDINoConnection = -10833,
        /// <summary>
        /// <para>An invalid MIDIEndpointRef was passed.</para>
        /// <para>Available in Mac OS X v10.4 and later.</para>
        /// </summary>
        kMIDIUnknownEndpoint = -10834,
        /// <summary>
        /// <para>Attempt to query a property not set on the object.</para>
        /// <para>Available in Mac OS X v10.4 and later.</para>
        /// </summary>
        kMIDIUnknownProperty = -10835,
        /// <summary>
        /// <para>Attempt to set a property with a value not of the correct type.</para>
        /// <para>Available in Mac OS X v10.4 and later.</para>
        /// </summary>
        kMIDIWrongPropertyType = -10836,
        /// <summary>
        /// <para>Internal error; there is no current MIDI setup object.</para>
        /// <para>Available in Mac OS X v10.4 and later.</para>
        /// </summary>
        kMIDINoCurrentSetup = -10837,
        /// <summary>
        /// <para>Communication with MIDIServer failed.</para>
        /// <para>Available in Mac OS X v10.4 and later.</para>
        /// </summary>
        kMIDIMessageSendErr = -10838,
        /// <summary>
        /// <para>Unable to start MIDIServer.</para>
        /// <para>Available in Mac OS X v10.4 and later.</para>
        /// </summary>
        kMIDIServerStartErr = -10839,
        /// <summary>
        /// <para>Unable to read the saved state.</para>
        /// <para>Available in Mac OS X v10.4 and later.</para>
        /// </summary>
        kMIDISetupFormatErr = -10840,
        /// <summary>
        /// <para>A driver is calling a non-I/O function in the server from a thread other than the server's main thread.</para>
        /// <para>Available in Mac OS X v10.4 and later.</para>
        /// </summary>
        kMIDIWrongThread = -10841,
        /// <summary>
        /// <para>The requested object does not exist.</para>
        /// <para>Available in Mac OS X v10.4 and later.</para>
        /// </summary>
        kMIDIObjectNotFound = -10842,
        /// <summary>
        /// <para>Attempt to set a non-unique kMIDIPropertyUniqueID on an object.</para>
        /// <para>Available in Mac OS X v10.4 and later.</para>
        /// </summary>
        kMIDIIDNotUnique = -10843
    }
}