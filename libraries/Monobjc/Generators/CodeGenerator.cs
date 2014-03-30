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
namespace Monobjc.Generators
{
	/// <summary>
	///   Base class for .NET code generator.
	/// </summary>
	internal partial class CodeGenerator
	{
		/// <summary>
		///   Initializes a new instance of the <see cref = "CodeGenerator" /> class.
		/// </summary>
		/// <param name = "assembly">The assembly.</param>
		/// <param name = "is64Bits"></param>
		protected CodeGenerator (DynamicAssembly assembly, bool is64Bits)
		{
			this.Assembly = assembly;
			this.Is64Bits = is64Bits;
		}

		/// <summary>
		///   Dynamic assembly that will hold the dynamic .NET code emitted.
		/// </summary>
		protected DynamicAssembly Assembly { get; private set; }

		/// <summary>
		///   Whether the current platform is 64 bits or not.
		/// </summary>
		protected bool Is64Bits { get; private set; }
	}
}