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

namespace Monobjc.GLKit
{
#if MACOSX_10_8
	public partial class GLKitFramework
	{
		/// <summary>
		/// <para>Converts an angle measured in degrees to radians.</para>
		/// <para>Original signature is 'float GLKMathDegreesToRadians ( float degrees );'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="degrees">MISSING</param>
		/// <returns>The converted angle in radians.</returns>
		public static float GLKMathDegreesToRadians (float degrees)
		{
			return (float) (degrees * Math.PI / 180.0d);
		}

		/// <summary>
		/// <para>Converts an angle measured in radians to degrees.</para>
		/// <para>Original signature is 'float GLKMathRadiansToDegrees ( float radians );'</para>
		/// <para>Available in OS X v10.8 and later.</para>
		/// </summary>
		/// <param name="radians">MISSING</param>
		/// <returns>The converted angle in degrees.</returns>
		public static float GLKMathRadiansToDegrees (float radians)
		{
			return (float) (radians * 180.0d / Math.PI);
		}
	}
#endif
}
