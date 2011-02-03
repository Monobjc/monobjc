using System;
using System.Runtime.InteropServices;

namespace Monobjc.CoreMidi
{
    /// <summary>
    /// <para>A message describing the addition or removal of an object.</para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct MIDIObjectAddRemoveNotification
    {
        /// <summary>
        /// type of message
        /// </summary>
        MIDINotificationMessageID messageID;
        /// <summary>
        /// size of the entire message, including messageID and messageSize
        /// </summary>
        UInt32 messageSize;
        /// <summary>
        /// the parent of the added or removed object (possibly NULL)
        /// </summary>
        uint parent;
        /// <summary>
        /// the type of the parent object (undefined if parent is NULL)
        /// </summary>
        MIDIObjectType parentType;
        /// <summary>
        /// the added or removed object
        /// </summary>
        uint child;
        /// <summary>
        /// the type of the added or removed object
        /// </summary>
        MIDIObjectType childType;
    }
}