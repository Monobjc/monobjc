namespace Monobjc.CoreMidi
{
    /// <summary>
    /// <para>Signifies the type of a MIDINotification.</para>
    /// <para>Available in Mac OS X v10.4 and later.</para>
    /// </summary>
    public enum MIDINotificationMessageID
    {
        /// <summary>
        /// <para>Some aspect of the current MIDISetup has changed. No data. Should ignore this message if messages 2-6 are handled.</para>
        /// <para>Available in Mac OS X v10.4 and later.</para>
        /// </summary>
        kMIDIMsgSetupChanged = 1,
        /// <summary>
        /// <para>A device, entity or endpoint was added. Structure is MIDIObjectAddRemoveNotification.</para>
        /// <para>Available in Mac OS X v10.4 and later.</para>
        /// </summary>
        kMIDIMsgObjectAdded = 2,
        /// <summary>
        /// <para>A device, entity or endpoint was removed. Structure is MIDIObjectAddRemoveNotification.</para>
        /// <para>Available in Mac OS X v10.4 and later.</para>
        /// </summary>
        kMIDIMsgObjectRemoved = 3,
        /// <summary>
        /// <para>An object's property was changed. Structure is MIDIObjectPropertyChangeNotification.</para>
        /// <para>Available in Mac OS X v10.4 and later.</para>
        /// </summary>
        kMIDIMsgPropertyChanged = 4,
        /// <summary>
        /// <para>A persistent MIDI Thru connection was created or destroyed. No data.</para>
        /// <para>Available in Mac OS X v10.4 and later.</para>
        /// </summary>
        kMIDIMsgThruConnectionsChanged = 5,
        /// <summary>
        /// <para>A persistent MIDI Thru connection was created or destroyed. No data.</para>
        /// <para>Available in Mac OS X v10.4 and later.</para>
        /// </summary>
        kMIDIMsgSerialPortOwnerChanged = 6,
        /// <summary>
        /// <para>A driver I/O error occurred.</para>
        /// <para>Available in Mac OS X v10.4 and later.</para>
        /// </summary>
        kMIDIMsgIOError = 7
    }
}