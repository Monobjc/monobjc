//
// This file is part of Monobjc, a .NET/Objective-C bridge
// Copyright (C) 2007-2012 - Laurent Etiemble
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

using Monobjc;
using Monobjc.Foundation;
using System;
using System.CodeDom.Compiler;
using System.Globalization;
using System.Runtime.InteropServices;

namespace Monobjc.CoreMIDI
{
    public static partial class MIDIServices
    {
        /// <summary>
        /// <para>Creates a MIDIClient object.</para>
        /// <para>Original signature is 'externOSStatusMIDIClientCreate(   CFStringRefname,   MIDINotifyProcnotifyProc,   void *notifyRefCon,   MIDIClientRef *outClient );'</para>
        /// <para>Available in VERSION and later.</para>
        /// </summary>
        /// <param name="e">MISSING</param>
        /// <param name="c">MISSING</param>
        /// <param name="notifyRefCon">MISSING</param>
        /// <param name="outClient">MISSING</param>
        /// <returns>An OSStatus result code.</returns>
        [DllImport("/System/Library/Frameworks/CoreMIDI.framework/CoreMIDI", EntryPoint="MIDIClientCreate")]
        public static extern int MIDIClientCreate(CFStringRefnam e, MIDINotifyProcnotifyPro c, IntPtr notifyRefCon, MIDIClientRef * outClient);


        /// <summary>
        /// <para>Disposes a MIDIClient object.</para>
        /// <para>Original signature is 'externOSStatusMIDIClientDispose(   MIDIClientRefclient );'</para>
        /// <para>Available in VERSION and later.</para>
        /// </summary>
        /// <param name="t">MISSING</param>
        /// <returns>An OSStatus result code.</returns>
        [DllImport("/System/Library/Frameworks/CoreMIDI.framework/CoreMIDI", EntryPoint="MIDIClientDispose")]
        public static extern int MIDIClientDispose(MIDIClientRefclien t);


        /// <summary>
        /// <para>Creates a virtual destination in a client.</para>
        /// <para>Original signature is 'externOSStatusMIDIDestinationCreate(   MIDIClientRefclient,   CFStringRefname,   MIDIReadProcreadProc,   void *refCon,   MIDIEndpointRef *outDest );'</para>
        /// <para>Available in VERSION and later.</para>
        /// </summary>
        /// <param name="t">MISSING</param>
        /// <param name="e">MISSING</param>
        /// <param name="c">MISSING</param>
        /// <param name="refCon">MISSING</param>
        /// <param name="outDest">MISSING</param>
        /// <returns>An OSStatus result code.</returns>
        [DllImport("/System/Library/Frameworks/CoreMIDI.framework/CoreMIDI", EntryPoint="MIDIDestinationCreate")]
        public static extern int MIDIDestinationCreate(MIDIClientRefclien t, CFStringRefnam e, MIDIReadProcreadPro c, IntPtr refCon, MIDIEndpointRef * outDest);


        /// <summary>
        /// <para>Returns one of a given device's entities.</para>
        /// <para>Original signature is 'externMIDIEntityRefMIDIDeviceGetEntity(   MIDIDeviceRefdevice,   ItemCountentityIndex0 );'</para>
        /// <para>Available in VERSION and later.</para>
        /// </summary>
        /// <param name="e">MISSING</param>
        /// <param name="0">MISSING</param>
        /// <returns>A reference to an entity, or NULL if an error occurred.</returns>
        [DllImport("/System/Library/Frameworks/CoreMIDI.framework/CoreMIDI", EntryPoint="MIDIDeviceGetEntity")]
        public static extern uint MIDIDeviceGetEntity(MIDIDeviceRefdevic e, ItemCountentityIndex 0);


        /// <summary>
        /// <para>Returns the number of entities in a given device.</para>
        /// <para>Original signature is 'externItemCountMIDIDeviceGetNumberOfEntities(   MIDIDeviceRefdevice );'</para>
        /// <para>Available in VERSION and later.</para>
        /// </summary>
        /// <param name="e">MISSING</param>
        /// <returns>The number of entities the device contains, or 0 if an error occurred.</returns>
        [DllImport("/System/Library/Frameworks/CoreMIDI.framework/CoreMIDI", EntryPoint="MIDIDeviceGetNumberOfEntities")]
        public static extern ItemCount MIDIDeviceGetNumberOfEntities(MIDIDeviceRefdevic e);


        /// <summary>
        /// <para>Disposes a virtual source or destination your client created.</para>
        /// <para>Original signature is 'externOSStatusMIDIEndpointDispose(   MIDIEndpointRefendpt );'</para>
        /// <para>Available in VERSION and later.</para>
        /// </summary>
        /// <param name="t">MISSING</param>
        /// <returns>An OSStatus result code.</returns>
        [DllImport("/System/Library/Frameworks/CoreMIDI.framework/CoreMIDI", EntryPoint="MIDIEndpointDispose")]
        public static extern int MIDIEndpointDispose(MIDIEndpointRefendp t);


        /// <summary>
        /// <para>Returns an endpoint's entity.</para>
        /// <para>Original signature is 'externOSStatusMIDIEndpointGetEntity(   MIDIEndpointRefinEndpoint,   MIDIEntityRef *outEntity);'</para>
        /// <para>Available in VERSION and later.</para>
        /// </summary>
        /// <param name="t">MISSING</param>
        /// <param name="outEntity">MISSING</param>
        /// <returns></returns>
        [DllImport("/System/Library/Frameworks/CoreMIDI.framework/CoreMIDI", EntryPoint="MIDIEndpointGetEntity")]
        public static extern int MIDIEndpointGetEntity(MIDIEndpointRefinEndpoin t, MIDIEntityRef * outEntity);


        /// <summary>
        /// <para>Returns one of a given entity's destinations.</para>
        /// <para>Original signature is 'externMIDIEndpointRefMIDIEntityGetDestination(   MIDIEntityRefentity,   ItemCountdestIndex0 );'</para>
        /// <para>Available in VERSION and later.</para>
        /// </summary>
        /// <param name="y">MISSING</param>
        /// <param name="0">MISSING</param>
        /// <returns>A reference to a destination, or NULL if an error occurred.</returns>
        [DllImport("/System/Library/Frameworks/CoreMIDI.framework/CoreMIDI", EntryPoint="MIDIEntityGetDestination")]
        public static extern uint MIDIEntityGetDestination(MIDIEntityRefentit y, ItemCountdestIndex 0);


        /// <summary>
        /// <para>Returns an entity's device.</para>
        /// <para>Original signature is 'externOSStatusMIDIEntityGetDevice(   MIDIEntityRefinEntity,   MIDIDeviceRef *outDevice);'</para>
        /// <para>Available in VERSION and later.</para>
        /// </summary>
        /// <param name="y">MISSING</param>
        /// <param name="outDevice">MISSING</param>
        /// <returns></returns>
        [DllImport("/System/Library/Frameworks/CoreMIDI.framework/CoreMIDI", EntryPoint="MIDIEntityGetDevice")]
        public static extern int MIDIEntityGetDevice(MIDIEntityRefinEntit y, MIDIDeviceRef * outDevice);


        /// <summary>
        /// <para>Returns the number of destinations in a given entity.</para>
        /// <para>Original signature is 'externItemCountMIDIEntityGetNumberOfDestinations(   MIDIEntityRefentity );'</para>
        /// <para>Available in VERSION and later.</para>
        /// </summary>
        /// <param name="y">MISSING</param>
        /// <returns>The number of destinations the entity contains, or 0 if an error occurred.</returns>
        [DllImport("/System/Library/Frameworks/CoreMIDI.framework/CoreMIDI", EntryPoint="MIDIEntityGetNumberOfDestinations")]
        public static extern ItemCount MIDIEntityGetNumberOfDestinations(MIDIEntityRefentit y);


        /// <summary>
        /// <para>Returns the number of sources in a given entity.</para>
        /// <para>Original signature is 'externItemCountMIDIEntityGetNumberOfSources(   MIDIEntityRefentity );'</para>
        /// <para>Available in VERSION and later.</para>
        /// </summary>
        /// <param name="y">MISSING</param>
        /// <returns>The number of sources the entity contains, or 0 if an error occurred.</returns>
        [DllImport("/System/Library/Frameworks/CoreMIDI.framework/CoreMIDI", EntryPoint="MIDIEntityGetNumberOfSources")]
        public static extern ItemCount MIDIEntityGetNumberOfSources(MIDIEntityRefentit y);


        /// <summary>
        /// <para>Returns one of a given entity's sources.</para>
        /// <para>Original signature is 'externMIDIEndpointRefMIDIEntityGetSource(   MIDIEntityRefentity,   ItemCountsourceIndex0 );'</para>
        /// <para>Available in VERSION and later.</para>
        /// </summary>
        /// <param name="y">MISSING</param>
        /// <param name="0">MISSING</param>
        /// <returns>A reference to a source, or NULL if an error occurred.</returns>
        [DllImport("/System/Library/Frameworks/CoreMIDI.framework/CoreMIDI", EntryPoint="MIDIEntityGetSource")]
        public static extern uint MIDIEntityGetSource(MIDIEntityRefentit y, ItemCountsourceIndex 0);


        /// <summary>
        /// <para>Unschedules previously-sent packets.</para>
        /// <para>Original signature is 'externOSStatusMIDIFlushOutput(   MIDIEndpointRefdest );'</para>
        /// <para>Available in VERSION and later.</para>
        /// </summary>
        /// <param name="t">MISSING</param>
        /// <returns></returns>
        [DllImport("/System/Library/Frameworks/CoreMIDI.framework/CoreMIDI", EntryPoint="MIDIFlushOutput")]
        public static extern int MIDIFlushOutput(MIDIEndpointRefdes t);


        /// <summary>
        /// <para>Returns one of the destinations in the system.</para>
        /// <para>Original signature is 'externMIDIEndpointRefMIDIGetDestination(   ItemCountdestIndex0 );'</para>
        /// <para>Available in VERSION and later.</para>
        /// </summary>
        /// <param name="0">MISSING</param>
        /// <returns>A reference to a destination, or NULL if an error occurred.</returns>
        [DllImport("/System/Library/Frameworks/CoreMIDI.framework/CoreMIDI", EntryPoint="MIDIGetDestination")]
        public static extern uint MIDIGetDestination(ItemCountdestIndex 0);


        /// <summary>
        /// <para>Returns one of the devices in the system.</para>
        /// <para>Original signature is 'externMIDIDeviceRefMIDIGetDevice(   ItemCountdeviceIndex0 );'</para>
        /// <para>Available in VERSION and later.</para>
        /// </summary>
        /// <param name="0">MISSING</param>
        /// <returns>A reference to a device, or NULL if an error occurred.</returns>
        [DllImport("/System/Library/Frameworks/CoreMIDI.framework/CoreMIDI", EntryPoint="MIDIGetDevice")]
        public static extern uint MIDIGetDevice(ItemCountdeviceIndex 0);


        /// <summary>
        /// <para>Returns one of the external devices in the system.</para>
        /// <para>Original signature is 'externMIDIDeviceRefMIDIGetExternalDevice(   ItemCountdeviceIndex0 );'</para>
        /// <para>Available in VERSION and later.</para>
        /// </summary>
        /// <param name="0">MISSING</param>
        /// <returns>A reference to a device, or NULL if an error occurred.</returns>
        [DllImport("/System/Library/Frameworks/CoreMIDI.framework/CoreMIDI", EntryPoint="MIDIGetExternalDevice")]
        public static extern uint MIDIGetExternalDevice(ItemCountdeviceIndex 0);


        /// <summary>
        /// <para>Returns one of the sources in the system.</para>
        /// <para>Original signature is 'externMIDIEndpointRefMIDIGetSource(   ItemCountsourceIndex0 );'</para>
        /// <para>Available in VERSION and later.</para>
        /// </summary>
        /// <param name="0">MISSING</param>
        /// <returns>A reference to a source, or NULL if an error occurred.</returns>
        [DllImport("/System/Library/Frameworks/CoreMIDI.framework/CoreMIDI", EntryPoint="MIDIGetSource")]
        public static extern uint MIDIGetSource(ItemCountsourceIndex 0);


        /// <summary>
        /// <para>Creates an input port through which the client may receive incoming MIDI messages from any MIDI source.</para>
        /// <para>Original signature is 'externOSStatusMIDIInputPortCreate(   MIDIClientRefclient,   CFStringRefportName,   MIDIReadProcreadProc,   void *refCon,   MIDIPortRef *outPort );'</para>
        /// <para>Available in VERSION and later.</para>
        /// </summary>
        /// <param name="t">MISSING</param>
        /// <param name="e">MISSING</param>
        /// <param name="c">MISSING</param>
        /// <param name="refCon">MISSING</param>
        /// <param name="outPort">MISSING</param>
        /// <returns>An OSStatus result code.</returns>
        [DllImport("/System/Library/Frameworks/CoreMIDI.framework/CoreMIDI", EntryPoint="MIDIInputPortCreate")]
        public static extern int MIDIInputPortCreate(MIDIClientRefclien t, CFStringRefportNam e, MIDIReadProcreadPro c, IntPtr refCon, MIDIPortRef * outPort);


        /// <summary>
        /// <para>Locates a device, external device, entity, or endpoint by its uniqueID.</para>
        /// <para>Original signature is 'externOSStatusMIDIObjectFindByUniqueID(   MIDIUniqueIDinUniqueID,   MIDIObjectRef *outObject,   MIDIObjectType *outObjectType) ;'</para>
        /// <para>Available in VERSION and later.</para>
        /// </summary>
        /// <param name="D">MISSING</param>
        /// <param name="outObject">MISSING</param>
        /// <param name="outObjectType">MISSING</param>
        /// <returns>An OSStatus error code, including kMIDIObjectNotFound if there is no object with the specified uniqueID.</returns>
        [DllImport("/System/Library/Frameworks/CoreMIDI.framework/CoreMIDI", EntryPoint="MIDIObjectFindByUniqueID")]
        public static extern int MIDIObjectFindByUniqueID(MIDIUniqueIDinUniqueI D, MIDIObjectRef * outObject, MIDIObjectType * outObjectType);


        /// <summary>
        /// <para>Gets an object's data-type property.</para>
        /// <para>Original signature is 'externOSStatusMIDIObjectGetDataProperty(   MIDIObjectRefobj,   CFStringRefpropertyID,   CFDataRef *outData );'</para>
        /// <para>Available in VERSION and later.</para>
        /// </summary>
        /// <param name="j">MISSING</param>
        /// <param name="D">MISSING</param>
        /// <param name="outData">MISSING</param>
        /// <returns>An OSStatus result code.</returns>
        [DllImport("/System/Library/Frameworks/CoreMIDI.framework/CoreMIDI", EntryPoint="MIDIObjectGetDataProperty")]
        public static extern int MIDIObjectGetDataProperty(MIDIObjectRefob j, CFStringRefpropertyI D, CFDataRef * outData);


        /// <summary>
        /// <para>Gets an object's dictionary-type property.</para>
        /// <para>Original signature is 'externOSStatusMIDIObjectGetDictionaryProperty(   MIDIObjectRefobj,   CFStringRefpropertyID,   CFDictionaryRef *outDict ) ;'</para>
        /// <para>Available in VERSION and later.</para>
        /// </summary>
        /// <param name="j">MISSING</param>
        /// <param name="D">MISSING</param>
        /// <param name="outDict">MISSING</param>
        /// <returns>An OSStatus result code.</returns>
        [DllImport("/System/Library/Frameworks/CoreMIDI.framework/CoreMIDI", EntryPoint="MIDIObjectGetDictionaryProperty")]
        public static extern int MIDIObjectGetDictionaryProperty(MIDIObjectRefob j, CFStringRefpropertyI D, CFDictionaryRef * outDict);


        /// <summary>
        /// <para>Gets an object's integer-type property.</para>
        /// <para>Original signature is 'externOSStatusMIDIObjectGetIntegerProperty(   MIDIObjectRefobj,   CFStringRefpropertyID,   SInt32 *outValue );'</para>
        /// <para>Available in VERSION and later.</para>
        /// </summary>
        /// <param name="j">MISSING</param>
        /// <param name="D">MISSING</param>
        /// <param name="outValue">MISSING</param>
        /// <returns>An OSStatus result code.</returns>
        [DllImport("/System/Library/Frameworks/CoreMIDI.framework/CoreMIDI", EntryPoint="MIDIObjectGetIntegerProperty")]
        public static extern int MIDIObjectGetIntegerProperty(MIDIObjectRefob j, CFStringRefpropertyI D, SInt32 * outValue);


        /// <summary>
        /// <para>Gets all of an object's properties.</para>
        /// <para>Original signature is 'externOSStatusMIDIObjectGetProperties(   MIDIObjectRefobj,   CFPropertyListRef *outProperties,   Booleandeep );'</para>
        /// <para>Available in VERSION and later.</para>
        /// </summary>
        /// <param name="j">MISSING</param>
        /// <param name="outProperties">MISSING</param>
        /// <param name="p">MISSING</param>
        /// <returns>An OSStatus result code.</returns>
        [DllImport("/System/Library/Frameworks/CoreMIDI.framework/CoreMIDI", EntryPoint="MIDIObjectGetProperties")]
        public static extern int MIDIObjectGetProperties(MIDIObjectRefob j, CFPropertyListRef * outProperties, Booleandee p);


        /// <summary>
        /// <para>Gets an object's string-type property.</para>
        /// <para>Original signature is 'externOSStatusMIDIObjectGetStringProperty(   MIDIObjectRefobj,   CFStringRefpropertyID,   CFStringRef *str );'</para>
        /// <para>Available in VERSION and later.</para>
        /// </summary>
        /// <param name="j">MISSING</param>
        /// <param name="D">MISSING</param>
        /// <param name="str">MISSING</param>
        /// <returns>An OSStatus result code.</returns>
        [DllImport("/System/Library/Frameworks/CoreMIDI.framework/CoreMIDI", EntryPoint="MIDIObjectGetStringProperty")]
        public static extern int MIDIObjectGetStringProperty(MIDIObjectRefob j, CFStringRefpropertyI D, CFStringRef * str);


        /// <summary>
        /// <para>Removes an object's property.</para>
        /// <para>Original signature is 'externOSStatusMIDIObjectRemoveProperty(   MIDIObjectRefobj,   CFStringRefpropertyID ) ;'</para>
        /// <para>Available in VERSION and later.</para>
        /// </summary>
        /// <param name="j">MISSING</param>
        /// <param name="D">MISSING</param>
        /// <returns>An OSStatus result code.</returns>
        [DllImport("/System/Library/Frameworks/CoreMIDI.framework/CoreMIDI", EntryPoint="MIDIObjectRemoveProperty")]
        public static extern int MIDIObjectRemoveProperty(MIDIObjectRefob j, CFStringRefpropertyI D);


        /// <summary>
        /// <para>Sets an object's data-type property.</para>
        /// <para>Original signature is 'externOSStatusMIDIObjectSetDataProperty(   MIDIObjectRefobj,   CFStringRefpropertyID,   CFDataRefdata );'</para>
        /// <para>Available in VERSION and later.</para>
        /// </summary>
        /// <param name="j">MISSING</param>
        /// <param name="D">MISSING</param>
        /// <param name="a">MISSING</param>
        /// <returns>An OSStatus result code.</returns>
        [DllImport("/System/Library/Frameworks/CoreMIDI.framework/CoreMIDI", EntryPoint="MIDIObjectSetDataProperty")]
        public static extern int MIDIObjectSetDataProperty(MIDIObjectRefob j, CFStringRefpropertyI D, CFDataRefdat a);


        /// <summary>
        /// <para>Sets an object's dictionary-type property.</para>
        /// <para>Original signature is 'externOSStatusMIDIObjectSetDictionaryProperty(   MIDIObjectRefobj,   CFStringRefpropertyID,   CFDictionaryRefdata );'</para>
        /// <para>Available in VERSION and later.</para>
        /// </summary>
        /// <param name="j">MISSING</param>
        /// <param name="D">MISSING</param>
        /// <param name="a">MISSING</param>
        /// <returns>An OSStatus result code.</returns>
        [DllImport("/System/Library/Frameworks/CoreMIDI.framework/CoreMIDI", EntryPoint="MIDIObjectSetDictionaryProperty")]
        public static extern int MIDIObjectSetDictionaryProperty(MIDIObjectRefob j, CFStringRefpropertyI D, CFDictionaryRefdat a);


        /// <summary>
        /// <para>Sets an object's integer-type property.</para>
        /// <para>Original signature is 'externOSStatusMIDIObjectSetIntegerProperty(   MIDIObjectRefobj,   CFStringRefpropertyID,   SInt32value );'</para>
        /// <para>Available in VERSION and later.</para>
        /// </summary>
        /// <param name="j">MISSING</param>
        /// <param name="D">MISSING</param>
        /// <param name="e">MISSING</param>
        /// <returns>An OSStatus result code.</returns>
        [DllImport("/System/Library/Frameworks/CoreMIDI.framework/CoreMIDI", EntryPoint="MIDIObjectSetIntegerProperty")]
        public static extern int MIDIObjectSetIntegerProperty(MIDIObjectRefob j, CFStringRefpropertyI D, SInt32valu e);


        /// <summary>
        /// <para>Sets an object's string-type property.</para>
        /// <para>Original signature is 'externOSStatusMIDIObjectSetStringProperty(   MIDIObjectRefobj,   CFStringRefpropertyID,   CFStringRefstr );'</para>
        /// <para>Available in VERSION and later.</para>
        /// </summary>
        /// <param name="j">MISSING</param>
        /// <param name="D">MISSING</param>
        /// <param name="r">MISSING</param>
        /// <returns>An OSStatus result code.</returns>
        [DllImport("/System/Library/Frameworks/CoreMIDI.framework/CoreMIDI", EntryPoint="MIDIObjectSetStringProperty")]
        public static extern int MIDIObjectSetStringProperty(MIDIObjectRefob j, CFStringRefpropertyI D, CFStringRefst r);


        /// <summary>
        /// <para>Creates an output port through which the client may send outgoing MIDI messages to any MIDI destination.</para>
        /// <para>Original signature is 'externOSStatusMIDIOutputPortCreate(   MIDIClientRefclient,   CFStringRefportName,   MIDIPortRef *outPort );'</para>
        /// <para>Available in VERSION and later.</para>
        /// </summary>
        /// <param name="t">MISSING</param>
        /// <param name="e">MISSING</param>
        /// <param name="outPort">MISSING</param>
        /// <returns>An OSStatus result code.</returns>
        [DllImport("/System/Library/Frameworks/CoreMIDI.framework/CoreMIDI", EntryPoint="MIDIOutputPortCreate")]
        public static extern int MIDIOutputPortCreate(MIDIClientRefclien t, CFStringRefportNam e, MIDIPortRef * outPort);


        /// <summary>
        /// <para>Adds a MIDI event to a MIDIPacketList.</para>
        /// <para>Original signature is 'externMIDIPacket*MIDIPacketListAdd(   MIDIPacketList *pktlist,   ByteCountlistSize,   MIDIPacket *curPacket,   MIDITimeStamptime,   ByteCountnData,   constByte *data);'</para>
        /// <para>Available in VERSION and later.</para>
        /// </summary>
        /// <param name="pktlist">MISSING</param>
        /// <param name="e">MISSING</param>
        /// <param name="curPacket">MISSING</param>
        /// <param name="e">MISSING</param>
        /// <param name="a">MISSING</param>
        /// <param name="data">MISSING</param>
        /// <returns>Returns null if there was not room in the packet for the event; otherwise returns a packet pointer which should be passed as curPacket in a subsequent call to this function.</returns>
        [DllImport("/System/Library/Frameworks/CoreMIDI.framework/CoreMIDI", EntryPoint="MIDIPacketListAdd")]
        public static extern MIDIPacket* MIDIPacketListAdd(MIDIPacketList * pktlist, ByteCountlistSiz e, MIDIPacket * curPacket, MIDITimeStamptim e, ByteCountnDat a, constByte * data);


        /// <summary>
        /// <para>Prepares a MIDIPacketList to be built up dynamically.</para>
        /// <para>Original signature is 'externMIDIPacket*MIDIPacketListInit(   MIDIPacketList *pktlist );'</para>
        /// <para>Available in VERSION and later.</para>
        /// </summary>
        /// <param name="pktlist">MISSING</param>
        /// <returns>A pointer to the first MIDIPacket in the packet list.</returns>
        [DllImport("/System/Library/Frameworks/CoreMIDI.framework/CoreMIDI", EntryPoint="MIDIPacketListInit")]
        public static extern MIDIPacket* MIDIPacketListInit(MIDIPacketList * pktlist);


        /// <summary>
        /// <para>Advances a MIDIPacket pointer to the MIDIPacket which immediately follows it in memory if it is part of a MIDIPacketList.</para>
        /// <para>Original signature is 'externMIDIPacket*MIDIPacketNext(   MIDIPacket *pkt );'</para>
        /// </summary>
        /// <param name="pkt">MISSING</param>
        /// <returns>The subsequent packet in the MIDIPacketList.</returns>
        [DllImport("/System/Library/Frameworks/CoreMIDI.framework/CoreMIDI", EntryPoint="MIDIPacketNext")]
        public static extern MIDIPacket* MIDIPacketNext(MIDIPacket * pkt);


        /// <summary>
        /// <para>Establishes a connection from a source to a client's input port.</para>
        /// <para>Original signature is 'externOSStatusMIDIPortConnectSource(   MIDIPortRefport,   MIDIEndpointRefsource,   void *connRefCon );'</para>
        /// <para>Available in VERSION and later.</para>
        /// </summary>
        /// <param name="t">MISSING</param>
        /// <param name="e">MISSING</param>
        /// <param name="connRefCon">MISSING</param>
        /// <returns>An OSStatus result code.</returns>
        [DllImport("/System/Library/Frameworks/CoreMIDI.framework/CoreMIDI", EntryPoint="MIDIPortConnectSource")]
        public static extern int MIDIPortConnectSource(MIDIPortRefpor t, MIDIEndpointRefsourc e, IntPtr connRefCon);


        /// <summary>
        /// <para>Closes a previously-established source-to-input port connection.</para>
        /// <para>Original signature is 'externOSStatusMIDIPortDisconnectSource(   MIDIPortRefport,   MIDIEndpointRefsource );'</para>
        /// <para>Available in VERSION and later.</para>
        /// </summary>
        /// <param name="t">MISSING</param>
        /// <param name="e">MISSING</param>
        /// <returns>An OSStatus result code.</returns>
        [DllImport("/System/Library/Frameworks/CoreMIDI.framework/CoreMIDI", EntryPoint="MIDIPortDisconnectSource")]
        public static extern int MIDIPortDisconnectSource(MIDIPortRefpor t, MIDIEndpointRefsourc e);


        /// <summary>
        /// <para>Disposes a MIDIPort object.</para>
        /// <para>Original signature is 'externOSStatusMIDIPortDispose(   MIDIPortRefport );'</para>
        /// <para>Available in VERSION and later.</para>
        /// </summary>
        /// <param name="t">MISSING</param>
        /// <returns>An OSStatus result code.</returns>
        [DllImport("/System/Library/Frameworks/CoreMIDI.framework/CoreMIDI", EntryPoint="MIDIPortDispose")]
        public static extern int MIDIPortDispose(MIDIPortRefpor t);


        /// <summary>
        /// <para>Distributes incoming MIDI from a source to the client input ports which are connected to that source.</para>
        /// <para>Original signature is 'externOSStatusMIDIReceived(   MIDIEndpointRefsrc,   constMIDIPacketList *pktlist );'</para>
        /// <para>Available in VERSION and later.</para>
        /// </summary>
        /// <param name="c">MISSING</param>
        /// <param name="pktlist">MISSING</param>
        /// <returns>An OSStatus result code.</returns>
        [DllImport("/System/Library/Frameworks/CoreMIDI.framework/CoreMIDI", EntryPoint="MIDIReceived")]
        public static extern int MIDIReceived(MIDIEndpointRefsr c, constMIDIPacketList * pktlist);


        /// <summary>
        /// <para>Sends MIDI to a destination.</para>
        /// <para>Original signature is 'externOSStatusMIDISend(   MIDIPortRefport,   MIDIEndpointRefdest,   constMIDIPacketList *pktlist );'</para>
        /// <para>Available in VERSION and later.</para>
        /// </summary>
        /// <param name="t">MISSING</param>
        /// <param name="t">MISSING</param>
        /// <param name="pktlist">MISSING</param>
        /// <returns>An OSStatus result code.</returns>
        [DllImport("/System/Library/Frameworks/CoreMIDI.framework/CoreMIDI", EntryPoint="MIDISend")]
        public static extern int MIDISend(MIDIPortRefpor t, MIDIEndpointRefdes t, constMIDIPacketList * pktlist);


        /// <summary>
        /// <para>Sends a single system-exclusive event, asynchronously.</para>
        /// <para>Original signature is 'externOSStatusMIDISendSysex(   MIDISysexSendRequest *request );'</para>
        /// <para>Available in VERSION and later.</para>
        /// </summary>
        /// <param name="request">MISSING</param>
        /// <returns>An OSStatus result code.</returns>
        [DllImport("/System/Library/Frameworks/CoreMIDI.framework/CoreMIDI", EntryPoint="MIDISendSysex")]
        public static extern int MIDISendSysex(MIDISysexSendRequest * request);


        /// <summary>
        /// <para>Creates a virtual source in a client.</para>
        /// <para>Original signature is 'externOSStatusMIDISourceCreate(   MIDIClientRefclient,   CFStringRefname,   MIDIEndpointRef *outSrc );'</para>
        /// <para>Available in VERSION and later.</para>
        /// </summary>
        /// <param name="t">MISSING</param>
        /// <param name="e">MISSING</param>
        /// <param name="outSrc">MISSING</param>
        /// <returns>An OSStatus result code.</returns>
        [DllImport("/System/Library/Frameworks/CoreMIDI.framework/CoreMIDI", EntryPoint="MIDISourceCreate")]
        public static extern int MIDISourceCreate(MIDIClientRefclien t, CFStringRefnam e, MIDIEndpointRef * outSrc);


    }
}
