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
using Monobjc.Foundation;
using System.Collections.Generic;

namespace Monobjc.GLKit
{
	public class Environment : TestEnvironment
	{
		public override bool IsAvailable {
			get {
#if MACOSX_10_8
				return ObjectiveCRuntime.Is64Bits;
#else
				return false;
#endif
			}
		}
		
		public override IEnumerable<string> Frameworks {
			get { return new[] { "Foundation", "AppKit", "GLKit" }; }
		}
		
		public override string AssemblyName {
			get { return "Monobjc.GLKit"; }
		}
		
		public override void EnsureAssemblyIsReferenced ()
		{
			GLKTextureLoader dummy = null;
		}
	}
}
