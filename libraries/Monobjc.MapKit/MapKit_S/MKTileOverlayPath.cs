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
    /// Use this structure to specify the index values for a single tile.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    [ObjectiveCUnderlyingType(typeof(MKTileOverlayPath), Is64Bits = false)]
    [ObjectiveCUnderlyingType(typeof(MKTileOverlayPath64), Is64Bits = true)]
    public partial struct MKTileOverlayPath
    {
        /// <summary>
        /// The index of the tile along the x axis of the map.
        /// </summary>
        public int x;

        /// <summary>
        /// The index of the tile along the y axis of the map.
        /// </summary>
        public int y;

        /// <summary>
        /// The zoom level number for the tile. At level 0, the map displays the entire world; at level 1, the map displays 1/4 of the world; at level 2, the map displays 1/16 of the world, and so on.
        /// </summary>
        public int z;

        /// <summary>
        /// Initializes a new instance of the <see cref="Monobjc.MapKit.MKTileOverlayPath"/> struct.
        /// </summary>
        public MKTileOverlayPath(int x, int y, int z){
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }
#endif
}
