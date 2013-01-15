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
using System.Runtime.InteropServices;
using Monobjc.ApplicationServices;

namespace Monobjc.AppKit
{
	/// <summary>
	/// Structure used for marshalling on 64 bits platforms.
	/// Never use this structure directly.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct NSEdgeInsets64
	{
		/// <summary>
		/// <para>The distance from the top of the source rectangle to the top of the result rectangle.</para>
		/// </summary>
		public double top;

		/// <summary>
		/// <para>The distance from the left side of the source rectangle to the left side of the result rectangle.</para>
		/// </summary>
		public double left;

		/// <summary>
		/// <para>The distance from the bottom of the source rectangle to the bottom of the result rectangle.</para>
		/// </summary>
		public double bottom;

		/// <summary>
		/// <para>The distance from the right side of the source rectangle to the right side of the result rectangle.</para>
		/// </summary>
		public double right;

		/// <summary>
		/// Initializes a new instance of the <see cref="NSEdgeInsets64"/> struct.
		/// </summary>
		/// <param name="top">The top.</param>
		/// <param name="left">The left.</param>
		/// <param name="bottom">The bottom.</param>
		/// <param name="right">The right.</param>
		public NSEdgeInsets64 (CGFloat top, CGFloat left, CGFloat bottom, CGFloat right)
		{
			this.top = top;
			this.left = left;
			this.bottom = bottom;
			this.right = right;
		}

		/// <summary>
		/// Performs an implicit conversion from <see cref="Monobjc.AppKit.NSEdgeInsets64"/> to <see cref="Monobjc.AppKit.NSEdgeInsets"/>.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator NSEdgeInsets (NSEdgeInsets64 value)
		{
			return new NSEdgeInsets (value.top, value.left, value.bottom, value.right);
		}

		/// <summary>
		/// Performs an implicit conversion from <see cref="Monobjc.AppKit.NSEdgeInsets"/> to <see cref="Monobjc.AppKit.NSEdgeInsets64"/>.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator NSEdgeInsets64 (NSEdgeInsets value)
		{
			return new NSEdgeInsets64 (value.top, value.left, value.bottom, value.right);
		}
	}
}