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
using Monobjc.ApplicationServices;

namespace Monobjc.Foundation
{
	/// <summary>
	/// Extension method to go back and forth between NSXXX and CGXXX structures.
	/// </summary>
	public static class GeometryExtensions
	{
		public static NSPoint ToNSPoint (this CGPoint origin)
		{
			return new NSPoint (origin.x, origin.y);
		}
		
		public static CGPoint ToCGPoint (this NSPoint origin)
		{
			return new CGPoint (origin.x, origin.y);
		}

		public static NSSize ToNSSize (this CGSize size)
		{
			return new NSSize (size.width, size.height);
		}
		
		public static CGSize ToCGSize (this NSSize size)
		{
			return new CGSize (size.width, size.height);
		}

		public static NSRect ToNSRect (this CGRect rect)
		{
			return new NSRect (rect.origin.x, rect.origin.y, rect.size.width, rect.size.height);
		}

		public static CGRect ToCGRect (this NSRect rect)
		{
			return new CGRect (rect.origin.x, rect.origin.y, rect.size.width, rect.size.height);
		}
	}
}