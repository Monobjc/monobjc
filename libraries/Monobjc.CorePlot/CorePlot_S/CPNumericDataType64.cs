//
// This file is part of Monobjc, a .NET/Objective-C bridge
// Copyright (C) 2007-2011 - Laurent Etiemble
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

namespace Monobjc.CorePlot
{
    ///<summary>
    /// Structure used for marshalling on 64 bits platforms.
    /// Never use this structure directly.
    ///</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct CPNumericDataType64
    {
        /// <summary>
        /// Data type format
        /// </summary>
        public CPDataTypeFormat dataTypeFormat;

        /// <summary>
        /// Number of bytes in each sample
        /// </summary>
        public ulong sampleBytes;

        /// <summary>
        /// Byte order
        /// </summary>
        public long byteOrder;

        /// <summary>
        /// Initializes a new instance of the <see cref="CPNumericDataType64"/> struct.
        /// </summary>
        /// <param name="dataTypeFormat">The data type format.</param>
        /// <param name="sampleBytes">The sample bytes.</param>
        /// <param name="byteOrder">The byte order.</param>
        public CPNumericDataType64(CPDataTypeFormat dataTypeFormat, ulong sampleBytes, long byteOrder)
        {
            this.dataTypeFormat = dataTypeFormat;
            this.sampleBytes = sampleBytes;
            this.byteOrder = byteOrder;
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="Monobjc.CorePlot.CPNumericDataType64"/> to <see cref="Monobjc.CorePlot.CPNumericDataType"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator CPNumericDataType(CPNumericDataType64 value)
        {
            return new CPNumericDataType(value.dataTypeFormat, (uint) value.sampleBytes, (int) value.byteOrder);
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="Monobjc.CorePlot.CPNumericDataType"/> to <see cref="Monobjc.CorePlot.CPNumericDataType64"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator CPNumericDataType64(CPNumericDataType value)
        {
            return new CPNumericDataType64(value.dataTypeFormat, value.sampleBytes, value.byteOrder);
        }
    }
}