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
using Monobjc.CoreLocation;

namespace Monobjc.MapKit
{
#if MACOSX_10_9
    /// <summary>
    /// A structure that defines the area spanned by a map region.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public partial struct MKCoordinateRegion
    {
        /// <summary>
        /// The center point of the region.
        /// </summary>
        public CLLocationCoordinate2D center;

        /// <summary>
        /// The horizontal and vertical span representing the amount of map to display. The span also defines the current zoom level used by the map view object.
        /// </summary>
        public MKCoordinateSpan span;

        /// <summary>
        /// Initializes a new instance of the <see cref="Monobjc.GLKit.MKCoordinateSpan"/> struct.
        /// </summary>
        public MKCoordinateRegion(CLLocationCoordinate2D center, MKCoordinateSpan span){
            this.center = center;
            this.span = span;
        }
    }
#endif
}
