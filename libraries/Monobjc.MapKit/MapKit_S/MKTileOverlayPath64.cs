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
using System.Runtime.InteropServices;
using Monobjc.ApplicationServices;

namespace Monobjc.MapKit
{
    /// <summary>
    /// Structure used for marshalling on 64 bits platforms.
    /// Never use this structure directly.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct MKTileOverlayPath64
    {
        /// <summary>
        /// The index of the tile along the x axis of the map.
        /// </summary>
        public long x;

        /// <summary>
        /// The index of the tile along the y axis of the map.
        /// </summary>
        public long y;

        /// <summary>
        /// The zoom level number for the tile. At level 0, the map displays the entire world; at level 1, the map displays 1/4 of the world; at level 2, the map displays 1/16 of the world, and so on.
        /// </summary>
        public long z;

        /// <summary>
        /// Initializes a new instance of the <see cref="Monobjc.MapKit.MKTileOverlayPath64"/> struct.
        /// </summary>
        public MKTileOverlayPath64(long x, long y, long z){
            this.x = x;
            this.y = y;
            this.z = z;
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="Monobjc.MapKit.MKTileOverlayPath64"/> to <see cref="Monobjc.MapKit.MKTileOverlayPath"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator MKTileOverlayPath(MKTileOverlayPath64 value)
        {
            return new MKTileOverlayPath((int)value.x, (int)value.y, (int)value.z);
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="Monobjc.MapKit.MKTileOverlayPath"/> to <see cref="Monobjc.MapKit.MKTileOverlayPath64"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator MKTileOverlayPath64(MKTileOverlayPath value)
        {
            return new MKTileOverlayPath64(value.x, value.y, value.z);
        }
    }
}