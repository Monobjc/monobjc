using System.Runtime.InteropServices;
using Monobjc.Foundation;

namespace Monobjc.CoreMidi
{
    /// <summary>
    /// <para>A message describing the addition or removal of an object.</para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct MIDIObjectPropertyChangeNotification
    {
        /// <summary>
        /// <para>type of message</para>
        /// </summary>
        MIDINotificationMessageID messageID;
        /// <summary>
        /// <para>size of the entire message, including messageID and messageSize</para>
        /// </summary>
        uint messageSize;
        /// <summary>
        /// <para>the object whose property has changed</para>
        /// </summary>
        uint @object;
        /// <summary>
        /// <para>the type of the object whose property has changed</para>
        /// </summary>
        MIDIObjectType objectType;
        /// <summary>
        /// <para>the name of the changed property</para>
        /// </summary>
        NSString propertyName;
    }
}