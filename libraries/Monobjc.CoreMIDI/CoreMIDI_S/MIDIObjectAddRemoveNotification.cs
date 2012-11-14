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
using System;
using System.Runtime.InteropServices;

namespace Monobjc.CoreMIDI
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