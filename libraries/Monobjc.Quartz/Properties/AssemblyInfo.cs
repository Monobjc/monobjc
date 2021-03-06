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
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[assembly: AssemblyTitle("Monobjc Bridge - Quartz Library")]
[assembly: AssemblyDescription("Monobjc Bridge Quartz Library")]
[assembly: AssemblyCompany("Monobjc Project")]
[assembly: AssemblyProduct("Monobjc Bridge Project")]
[assembly: AssemblyCopyright("Copyright (c) Monobjc Project 2007-2014 - Licensed under MIT License")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: NeutralResourcesLanguage("en-US")]
[assembly: ComVisible(false)]
[assembly: Guid("8599f052-b263-d333-feb1-7a3ea9fa5004")]

#if TESTING
[assembly: InternalsVisibleTo("Monobjc.Quartz.Tests")]
[assembly: AssemblyConfigurationAttribute("Debug")]
#else
[assembly: AssemblyConfigurationAttribute("Release")]
#endif

#if MACOSX_10_9
[assembly: AssemblyVersionAttribute("10.9.0.0")]
[assembly: AssemblyFileVersionAttribute("10.9.0.0")]
#elif MACOSX_10_8
[assembly: AssemblyVersionAttribute("10.8.0.0")]
[assembly: AssemblyFileVersionAttribute("10.8.0.0")]
#elif MACOSX_10_7
[assembly: AssemblyVersionAttribute("10.7.0.0")]
[assembly: AssemblyFileVersionAttribute("10.7.0.0")]
#else
[assembly: AssemblyVersionAttribute("10.6.0.0")]
[assembly: AssemblyFileVersionAttribute("10.6.0.0")]
#endif
