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
namespace Monobjc.CoreMIDI
{
	/// <summary>
	/// <para>Values specifying a type of MIDI transformation, as found in the transform member of MIDITransform.</para>
	/// </summary>
	public enum MIDITransformType
	{
		/// <summary>
		/// <para>no transformation (param unused)</para>
		/// </summary>
		kMIDITransform_None = 0, 
		/// <summary>
		/// <para>filter out the specified event type (param unused)</para>
		/// </summary>
		kMIDITransform_FilterOut = 1, 
		/// <summary>
		/// <para>transform one control number to another; param is destination control number</para>
		/// </summary>
		kMIDITransform_MapControl = 2, 
		/// <summary>
		/// <para>add param to values</para>
		/// </summary>
		kMIDITransform_Add = 8, 
		/// <summary>
		/// <para>multiple value by the fixed point number in param, which is in fixed point: bbbb.bbbb bbbb bbbb</para>
		/// </summary>
		kMIDITransform_Scale = 9, 
		/// <summary>
		/// <para>the value's minimum value is param</para>
		/// </summary>
		kMIDITransform_MinValue = 10, 
		/// <summary>
		/// <para>the value's maximum value is param</para>
		/// </summary>
		kMIDITransform_MaxValue = 11, 
		/// <summary>
		/// <para>transform the value using a map; param is the index of the map in the connection's array of maps.</para>
		/// </summary>
		kMIDITransform_MapValue = 12 
	}
}
