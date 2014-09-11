//
// This file is part of Monobjc, a .NET/Objective-C bridge
// Copyright (C) 2007-2014 - Laurent Etiemble
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
// 
namespace Monobjc.CoreMIDI
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