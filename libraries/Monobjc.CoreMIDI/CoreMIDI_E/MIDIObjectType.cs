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