//
// This file is part of Monobjc, a .NET/Objective-C bridge
// Copyright (C) 2007-2011 - Laurent Etiemble
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
    public static partial class MIDISetup
    {
        /// <summary>
        /// <para>Original signature is 'externOSStatusMIDIDeviceAddEntity(   MIDIDeviceRefdevice,   CFStringRefname,   Booleanembedded,   ItemCountnumSourceEndpoints,   ItemCountnumDestinationEndpoints,   MIDIEntityRef *newEntity) ;'</para>
        /// <para>Available in VERSION and later.</para>
        /// </summary>
        /// <param name="e">MISSING</param>
        /// <param name="e">MISSING</param>
        /// <param name="d">MISSING</param>
        /// <param name="s">MISSING</param>
        /// <param name="s">MISSING</param>
        /// <param name="newEntity">MISSING</param>
        /// <returns>An OSStatus result code.</returns>
        [DllImport("/System/Library/Frameworks/CoreMIDI.framework/CoreMIDI", EntryPoint="MIDIDeviceAddEntity")]
        public static extern int MIDIDeviceAddEntity(MIDIDeviceRefdevic e, CFStringRefnam e, Booleanembedde d, ItemCountnumSourceEndpoint s, ItemCountnumDestinationEndpoint s, MIDIEntityRef * newEntity);


        /// <summary>
        /// <para>Original signature is 'externOSStatusMIDIDeviceRemoveEntity(   MIDIDeviceRefdevice,   MIDIEntityRefentity) ;'</para>
        /// <para>Available in VERSION and later.</para>
        /// </summary>
        /// <param name="e">MISSING</param>
        /// <param name="y">MISSING</param>
        /// <returns>An OSStatus result code.</returns>
        [DllImport("/System/Library/Frameworks/CoreMIDI.framework/CoreMIDI", EntryPoint="MIDIDeviceRemoveEntity")]
        public static extern int MIDIDeviceRemoveEntity(MIDIDeviceRefdevic e, MIDIEntityRefentit y);


        /// <summary>
        /// <para>Original signature is 'externOSStatusMIDIEntityAddOrRemoveEndpoints(   MIDIEntityRefentity,   ItemCountnumSourceEndpoints,   ItemCountnumDestinationEndpoints);'</para>
        /// <para>Available in VERSION and later.</para>
        /// </summary>
        /// <param name="y">MISSING</param>
        /// <param name="s">MISSING</param>
        /// <param name="s">MISSING</param>
        /// <returns>An OSStatus result code.</returns>
        [DllImport("/System/Library/Frameworks/CoreMIDI.framework/CoreMIDI", EntryPoint="MIDIEntityAddOrRemoveEndpoints")]
        public static extern int MIDIEntityAddOrRemoveEndpoints(MIDIEntityRefentit y, ItemCountnumSourceEndpoint s, ItemCountnumDestinationEndpoint s);


        /// <summary>
        /// <para>Create a new external MIDI device.</para>
        /// <para>Original signature is 'externOSStatusMIDIExternalDeviceCreate(   CFStringRefname,   CFStringRefmanufacturer,   CFStringRefmodel,   MIDIDeviceRef *outDevice) ;'</para>
        /// <para>Available in VERSION and later.</para>
        /// </summary>
        /// <param name="e">MISSING</param>
        /// <param name="r">MISSING</param>
        /// <param name="l">MISSING</param>
        /// <param name="outDevice">MISSING</param>
        /// <returns>An OSStatus result code.</returns>
        [DllImport("/System/Library/Frameworks/CoreMIDI.framework/CoreMIDI", EntryPoint="MIDIExternalDeviceCreate")]
        public static extern int MIDIExternalDeviceCreate(CFStringRefnam e, CFStringRefmanufacture r, CFStringRefmode l, MIDIDeviceRef * outDevice);


        /// <summary>
        /// <para>Returns a list of installed MIDI drivers for serial port MIDI devices.</para>
        /// <para>Original signature is 'externOSStatusMIDIGetSerialPortDrivers(   CFArrayRef *outDriverNames );'</para>
        /// <para>Available in VERSION and later.</para>
        /// </summary>
        /// <param name="outDriverNames">MISSING</param>
        /// <returns>An OSStatus result code.</returns>
        [DllImport("/System/Library/Frameworks/CoreMIDI.framework/CoreMIDI", EntryPoint="MIDIGetSerialPortDrivers")]
        public static extern int MIDIGetSerialPortDrivers(CFArrayRef * outDriverNames);


        /// <summary>
        /// <para>Returns the MIDI driver that owns a serial port.</para>
        /// <para>Original signature is 'externOSStatusMIDIGetSerialPortOwner(   CFStringRefportName,   CFStringRef *outDriverName );'</para>
        /// <para>Available in VERSION and later.</para>
        /// </summary>
        /// <param name="e">MISSING</param>
        /// <param name="outDriverName">MISSING</param>
        /// <returns>An OSStatus result code.</returns>
        [DllImport("/System/Library/Frameworks/CoreMIDI.framework/CoreMIDI", EntryPoint="MIDIGetSerialPortOwner")]
        public static extern int MIDIGetSerialPortOwner(CFStringRefportNam e, CFStringRef * outDriverName);


        /// <summary>
        /// <para>Specifies the MIDI driver that owns a serial port.</para>
        /// <para>Original signature is 'externOSStatusMIDISetSerialPortOwner(   CFStringRefportName,   CFStringRefdriverName );'</para>
        /// <para>Available in VERSION and later.</para>
        /// </summary>
        /// <param name="e">MISSING</param>
        /// <param name="e">MISSING</param>
        /// <returns>An OSStatus result code.</returns>
        [DllImport("/System/Library/Frameworks/CoreMIDI.framework/CoreMIDI", EntryPoint="MIDISetSerialPortOwner")]
        public static extern int MIDISetSerialPortOwner(CFStringRefportNam e, CFStringRefdriverNam e);


        /// <summary>
        /// <para>Adds a driver-owner MIDI device to the current MIDISetup</para>
        /// <para>Original signature is 'externOSStatusMIDISetupAddDevice(   MIDIDeviceRefdevice );'</para>
        /// <para>Available in VERSION and later.</para>
        /// </summary>
        /// <param name="e">MISSING</param>
        /// <returns></returns>
        [DllImport("/System/Library/Frameworks/CoreMIDI.framework/CoreMIDI", EntryPoint="MIDISetupAddDevice")]
        public static extern int AddDevice(MIDIDeviceRefdevic e);


        /// <summary>
        /// <para>Adds an external MIDI device to the current MIDISetup</para>
        /// <para>Original signature is 'externOSStatusMIDISetupAddExternalDevice(   MIDIDeviceRefdevice );'</para>
        /// <para>Available in VERSION and later.</para>
        /// </summary>
        /// <param name="e">MISSING</param>
        /// <returns></returns>
        [DllImport("/System/Library/Frameworks/CoreMIDI.framework/CoreMIDI", EntryPoint="MIDISetupAddExternalDevice")]
        public static extern int AddExternalDevice(MIDIDeviceRefdevic e);


        /// <summary>
        /// <para>Interrogates drivers, to discover what hardware is present.</para>
        /// <para>As of CoreMIDI 1.1, it is usually not necessary to call this function, as CoreMIDI manages a single persistent</para>
        /// <para>MIDISetup itself.</para>
        /// <para>Original signature is 'externOSStatusMIDISetupCreate(   MIDISetupRef *outSetup );'</para>
        /// <para>Available in VERSION and later.</para>
        /// </summary>
        /// <param name="outSetup">MISSING</param>
        /// <returns>An OSStatus result code.</returns>
        [DllImport("/System/Library/Frameworks/CoreMIDI.framework/CoreMIDI", EntryPoint="MIDISetupCreate")]
        public static extern int Create(MIDISetupRef * outSetup);


        /// <summary>
        /// <para>Dispose a MIDISetup object.</para>
        /// <para>As of CoreMIDI 1.1, it is usually not necessary to call this function, as CoreMIDI manages a single persistent</para>
        /// <para>MIDISetup itself.</para>
        /// <para>Original signature is 'externOSStatusMIDISetupDispose(   MIDISetupRefsetup );'</para>
        /// <para>Available in VERSION and later.</para>
        /// </summary>
        /// <param name="p">MISSING</param>
        /// <returns>An OSStatus result code.</returns>
        [DllImport("/System/Library/Frameworks/CoreMIDI.framework/CoreMIDI", EntryPoint="MIDISetupDispose")]
        public static extern int Dispose(MIDISetupRefsetu p);


        /// <summary>
        /// <para>Create a MIDISetup object from an XML stream.</para>
        /// <para>As of CoreMIDI 1.1, it is usually not necessary to call this function, as CoreMIDI manages a single persistent</para>
        /// <para>MIDISetup itself.</para>
        /// <para>Original signature is 'externOSStatusMIDISetupFromData(   CFDataRefdata,   MIDISetupRef *outSetup);'</para>
        /// <para>Available in VERSION and later.</para>
        /// </summary>
        /// <param name="a">MISSING</param>
        /// <param name="outSetup">MISSING</param>
        /// <returns>An OSStatus result code.</returns>
        [DllImport("/System/Library/Frameworks/CoreMIDI.framework/CoreMIDI", EntryPoint="MIDISetupFromData")]
        public static extern int FromData(CFDataRefdat a, MIDISetupRef * outSetup);


        /// <summary>
        /// <para>Return the system's current MIDISetup.</para>
        /// <para>As of CoreMIDI 1.1, it is usually not necessary to call this function, as CoreMIDI manages a single persistent</para>
        /// <para>MIDISetup itself.</para>
        /// <para>Original signature is 'externOSStatusMIDISetupGetCurrent(   MIDISetupRef *outSetup );'</para>
        /// <para>Available in VERSION and later.</para>
        /// </summary>
        /// <param name="outSetup">MISSING</param>
        /// <returns>An OSStatus result code.</returns>
        [DllImport("/System/Library/Frameworks/CoreMIDI.framework/CoreMIDI", EntryPoint="MIDISetupGetCurrent")]
        public static extern int GetCurrent(MIDISetupRef * outSetup);


        /// <summary>
        /// <para>Install a MIDISetup as the system's current state.</para>
        /// <para>A client can create a MIDISetup object using MIDISetupCreate, or MIDISetupFromData. This function will</para>
        /// <para>install this state as the current state of the system, possibly changing the devices visible to clients.</para>
        /// <para>As of CoreMIDI 1.1, it is usually not necessary to call</para>
        /// <para>this function, as CoreMIDI manages a single persistent MIDISetup itself.</para>
        /// <para>Original signature is 'externOSStatusMIDISetupInstall(   MIDISetupRefsetup );'</para>
        /// <para>Available in VERSION and later.</para>
        /// </summary>
        /// <param name="p">MISSING</param>
        /// <returns>An OSStatus result code.</returns>
        [DllImport("/System/Library/Frameworks/CoreMIDI.framework/CoreMIDI", EntryPoint="MIDISetupInstall")]
        public static extern int Install(MIDISetupRefsetu p);


        /// <summary>
        /// <para>Removes a driver-owned MIDI device from the current MIDISetup</para>
        /// <para>Original signature is 'externOSStatusMIDISetupRemoveDevice(   MIDIDeviceRefdevice );'</para>
        /// <para>Available in VERSION and later.</para>
        /// </summary>
        /// <param name="e">MISSING</param>
        /// <returns></returns>
        [DllImport("/System/Library/Frameworks/CoreMIDI.framework/CoreMIDI", EntryPoint="MIDISetupRemoveDevice")]
        public static extern int RemoveDevice(MIDIDeviceRefdevic e);


        /// <summary>
        /// <para>Removes an external MIDI device from the current MIDISetup</para>
        /// <para>Original signature is 'externOSStatusMIDISetupRemoveExternalDevice(   MIDIDeviceRefdevice );'</para>
        /// <para>Available in VERSION and later.</para>
        /// </summary>
        /// <param name="e">MISSING</param>
        /// <returns></returns>
        [DllImport("/System/Library/Frameworks/CoreMIDI.framework/CoreMIDI", EntryPoint="MIDISetupRemoveExternalDevice")]
        public static extern int RemoveExternalDevice(MIDIDeviceRefdevic e);


        /// <summary>
        /// <para>Create an XML representation of a MIDISetup object.</para>
        /// <para>As of CoreMIDI 1.1, it is usually not necessary to call this function, as CoreMIDI manages a single persistent</para>
        /// <para>MIDISetup itself.</para>
        /// <para>Original signature is 'externOSStatusMIDISetupToData(   MIDISetupRefsetup,   CFDataRef *outData );'</para>
        /// <para>Available in VERSION and later.</para>
        /// </summary>
        /// <param name="p">MISSING</param>
        /// <param name="outData">MISSING</param>
        /// <returns>An OSStatus result code.</returns>
        [DllImport("/System/Library/Frameworks/CoreMIDI.framework/CoreMIDI", EntryPoint="MIDISetupToData")]
        public static extern int ToData(MIDISetupRefsetu p, CFDataRef * outData);


    }
}
