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
using System.Runtime.InteropServices;

namespace Monobjc.MapKit
{
#if MACOSX_10_9
    /// <summary>
    /// Size information as measured on a two-dimensional map projection.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public partial struct MKMapSize
    {
        /// <summary>
        /// The width value. The units of this value are map points.
        /// </summary>
        public double width;

        /// <summary>
        /// The height value. The units of this value are map points.
        /// </summary>
        public double height;

        /// <summary>
        /// Initializes a new instance of the <see cref="Monobjc.GLKit.MKMapSize"/> struct.
        /// </summary>
        public MKMapSize(double width, double height){
            this.width = width;
            this.height = height;
        }
    }
#endif
}
