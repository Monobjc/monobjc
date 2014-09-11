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
using System;
using System.Runtime.InteropServices;

namespace Monobjc.Foundation
{
	/// <summary>
	/// Used to describe a decimal number.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public partial struct NSDecimal
	{
		/// <summary>
		/// <para>A 32 bit field that contains: the exponent (8 bits), the length (4 bits), whether this instance is negative (1 bit), whether this instance is compact (1 bit) and 18 bits reserved for future use.</para>
		/// </summary>
		public int fields;
		/// <summary>
		/// The mantissa
		/// </summary>
		public ushort mantissa1, mantissa2, mantissa3, mantissa4, mantissa5, mantissa6, mantissa7, mantissa8;
		
		/// <summary>
		/// Returns the a string representation of this instance.
		/// </summary>
		/// <returns>
		/// A <see cref="T:System.String"></see> containing a representation of this instance.
		/// </returns>
		public override String ToString ()
		{
			return StringValue (this);
		}
	}
}
