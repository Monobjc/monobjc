//
// This file is part of Monobjc, a .NET/Objective-C bridge
// Copyright (C) 2007-2013 - Laurent Etiemble
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
	/// <para>Describes a set of MIDI routings and transformations.</para>
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct MIDIThruConnectionParams
	{
		public uint version;
		public uint numSources;
		public MIDIThruConnectionEndpoint source1;
		public MIDIThruConnectionEndpoint source2;
		public MIDIThruConnectionEndpoint source3;
		public MIDIThruConnectionEndpoint source4;
		public MIDIThruConnectionEndpoint source5;
		public MIDIThruConnectionEndpoint source6;
		public MIDIThruConnectionEndpoint source7;
		public MIDIThruConnectionEndpoint source8;
		public uint numDestinations;
		public MIDIThruConnectionEndpoint destination1;
		public MIDIThruConnectionEndpoint destination2;
		public MIDIThruConnectionEndpoint destination3;
		public MIDIThruConnectionEndpoint destination4;
		public MIDIThruConnectionEndpoint destination5;
		public MIDIThruConnectionEndpoint destination6;
		public MIDIThruConnectionEndpoint destination7;
		public MIDIThruConnectionEndpoint destination8;
		public byte channelMap01;
		public byte channelMap02;
		public byte channelMap03;
		public byte channelMap04;
		public byte channelMap05;
		public byte channelMap06;
		public byte channelMap07;
		public byte channelMap08;
		public byte channelMap09;
		public byte channelMap10;
		public byte channelMap11;
		public byte channelMap12;
		public byte channelMap13;
		public byte channelMap14;
		public byte channelMap15;
		public byte channelMap16;
		public byte lowVelocity;
		public byte highVelocity;
		public byte lowNote;
		public byte highNote;
		public MIDITransform noteNumber;
		public MIDITransform velocity;
		public MIDITransform keyPressure;
		public MIDITransform channelPressure;
		public MIDITransform programChange;
		public MIDITransform pitchBend;
		public byte filterOutSysEx;
		public byte filterOutMTC;
		public byte filterOutBeatClock;
		public byte filterOutTuneRequest;
		public byte reserved2_1;
		public byte reserved2_2;
		public byte reserved2_3;
		public byte filterOutAllControls;
		public ushort numControlTransforms;
		public ushort numMaps;
		public ushort reserved3_1;
		public ushort reserved3_2;
		public ushort reserved3_3;
		public ushort reserved3_4;  
		// remainder of structure is variable-length: 
		// MIDIControlTransform controls[]; 
		// MIDIValueMap maps[];

		public void SetSourceEndpoint (int i, MIDIThruConnectionEndpoint endpoint)
		{
			switch (i) {
			case 0:
				this.source1 = endpoint;
				break;
			case 1:
				this.source2 = endpoint;
				break;
			case 2:
				this.source3 = endpoint;
				break;
			case 3:
				this.source4 = endpoint;
				break;
			case 4:
				this.source5 = endpoint;
				break;
			case 5:
				this.source6 = endpoint;
				break;
			case 6:
				this.source7 = endpoint;
				break;
			case 7:
				this.source8 = endpoint;
				break;
			default:
				throw new IndexOutOfRangeException ();
			}
		}

		public void SetDestinationEndpoint (int i, MIDIThruConnectionEndpoint endpoint)
		{
			switch (i) {
			case 0:
				this.destination1 = endpoint;
				break;
			case 1:
				this.destination2 = endpoint;
				break;
			case 2:
				this.destination3 = endpoint;
				break;
			case 3:
				this.destination4 = endpoint;
				break;
			case 4:
				this.destination5 = endpoint;
				break;
			case 5:
				this.destination6 = endpoint;
				break;
			case 6:
				this.destination7 = endpoint;
				break;
			case 7:
				this.destination8 = endpoint;
				break;
			default:
				throw new IndexOutOfRangeException ();
			}
		}

		public void SetChannelMap (byte[] map)
		{
			if (map.Length > 0) {
				this.channelMap01 = map [0];
			}
			if (map.Length > 1) {
				this.channelMap02 = map [1];
			}
			if (map.Length > 2) {
				this.channelMap03 = map [2];
			}
			if (map.Length > 3) {
				this.channelMap04 = map [3];
			}
			if (map.Length > 4) {
				this.channelMap05 = map [4];
			}
			if (map.Length > 5) {
				this.channelMap06 = map [5];
			}
			if (map.Length > 6) {
				this.channelMap07 = map [6];
			}
			if (map.Length > 7) {
				this.channelMap08 = map [7];
			}
			if (map.Length > 8) {
				this.channelMap09 = map [8];
			}
			if (map.Length > 9) {
				this.channelMap10 = map [9];
			}
			if (map.Length > 10) {
				this.channelMap11 = map [10];
			}
			if (map.Length > 11) {
				this.channelMap12 = map [11];
			}
			if (map.Length > 12) {
				this.channelMap13 = map [12];
			}
			if (map.Length > 13) {
				this.channelMap14 = map [13];
			}
			if (map.Length > 14) {
				this.channelMap15 = map [14];
			}
			if (map.Length > 15) {
				this.channelMap16 = map [15];
			}
		}
	}
}
