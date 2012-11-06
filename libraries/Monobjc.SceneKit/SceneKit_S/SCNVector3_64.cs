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

namespace Monobjc.SceneKit
{
#if MACOSX_10_8
	/// <summary>
	/// Structure used for marshalling on 64 bits platforms.
	/// Never use this structure directly.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public partial struct SCNVector3_64
	{
		public double x;
		public double y;
		public double z;

		/// <summary>
		/// Initializes a new instance of the <see cref="Monobjc.SceneKit.SCNVector3_64"/> struct.
		/// </summary>
		public SCNVector3_64(CGFloat x, CGFloat y, CGFloat z)
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}

		/// <summary>
		/// Performs an implicit conversion from <see cref="Monobjc.SceneKit.SCNVector3_64"/> to <see cref="Monobjc.SceneKit.SCNVector3"/>.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator SCNVector3(SCNVector3_64 value)
		{
			return new SCNVector3(value.x, value.y, value.z);
		}
		
		/// <summary>
		/// Performs an implicit conversion from <see cref="Monobjc.SceneKit.SCNVector3"/> to <see cref="Monobjc.SceneKit.SCNVector3_64"/>.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator SCNVector3_64(SCNVector3 value)
		{
			return new SCNVector3_64(value.x, value.y, value.z);
		}
	}
#endif
}
