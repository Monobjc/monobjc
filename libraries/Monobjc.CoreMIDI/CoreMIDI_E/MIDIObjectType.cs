namespace Monobjc.CoreMidi
{
    /// <summary>
    /// <para>Signifies the type of a MIDIObject.</para>
    /// <para>Available in Mac OS X v10.4 and later.</para>
    /// </summary>
    public enum MIDIObjectType  {
        /// <summary>
        /// <para>Available in Mac OS X v10.4 and later.</para>
        /// </summary>
        kMIDIObjectType_Other = -1,
        /// <summary>
        /// <para>Available in Mac OS X v10.4 and later.</para>
        /// </summary>
        kMIDIObjectType_Device = 0,
        /// <summary>
        /// <para>Available in Mac OS X v10.4 and later.</para>
        /// </summary>
        kMIDIObjectType_Entity = 1,
        /// <summary>
        /// <para>Available in Mac OS X v10.4 and later.</para>
        /// </summary>
        kMIDIObjectType_Source = 2,
        /// <summary>
        /// <para>Available in Mac OS X v10.4 and later.</para>
        /// </summary>
        kMIDIObjectType_Destination = 3,
        /// <summary>
        /// <para>Available in Mac OS X v10.4 and later.</para>
        /// </summary>
        kMIDIObjectType_ExternalMask = 0x10,
        /// <summary>
        /// <para>Available in Mac OS X v10.4 and later.</para>
        /// </summary>
        kMIDIObjectType_ExternalDevice = kMIDIObjectType_ExternalMask | kMIDIObjectType_Device,
        /// <summary>
        /// <para>Available in Mac OS X v10.4 and later.</para>
        /// </summary>
        kMIDIObjectType_ExternalEntity = kMIDIObjectType_ExternalMask | kMIDIObjectType_Entity,
        /// <summary>
        /// <para>Available in Mac OS X v10.4 and later.</para>
        /// </summary>
        kMIDIObjectType_ExternalSource = kMIDIObjectType_ExternalMask | kMIDIObjectType_Source,
        /// <summary>
        /// <para>Available in Mac OS X v10.4 and later.</para>
        /// </summary>
        kMIDIObjectType_ExternalDestination = kMIDIObjectType_ExternalMask | kMIDIObjectType_Destination 
    }
}