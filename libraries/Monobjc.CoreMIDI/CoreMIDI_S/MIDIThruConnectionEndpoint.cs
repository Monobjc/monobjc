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
using System.Runtime.InteropServices;

namespace Monobjc.CoreMIDI
{
	/// <summary>
	/// <para>Describes a source or destination in a MIDIThruConnection.</para>
	/// <para>When creating one of these, you can leave uniqueID 0 if the endpoint exists and you are passing its MIDIEndpointRef.</para>
	/// <para>When obtaining one of these from CoreMIDI, endpointRef may be NULL if it doesn't exist, but the uniqueID will always be non-zero.</para>
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct MIDIThruConnectionEndpoint
	{
		/// <summary>
		/// <para>The endpoint specified as a MIDIEndpointRef.</para>
		/// </summary>
		public uint endpointRef;
		/// <summary>
		/// <para>The endpoint specified by its uniqueID.</para>
		/// </summary>
		public int uniqueID;
	}
}
