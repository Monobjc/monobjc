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
using Monobjc.Foundation;

namespace Monobjc.CorePlot
{
    public partial class CPTRangePlot
    {
        /// <summary>
        ///   <para>X values.</para>
        /// </summary>
        public static readonly NSNumber FieldX = new NSNumber((int) CPTRangePlotField.CPTRangePlotFieldX);

        /// <summary>
        ///   <para>Y values.</para>
        /// </summary>
        public static readonly NSNumber FieldY = new NSNumber((int) CPTRangePlotField.CPTRangePlotFieldY);

        /// <summary>
        ///   <para>relative High values.</para>
        /// </summary>
        public static readonly NSNumber FieldHigh = new NSNumber((int) CPTRangePlotField.CPTRangePlotFieldHigh);

        /// <summary>
        ///   <para>relative Low values.</para>
        /// </summary>
        public static readonly NSNumber FieldLow = new NSNumber((int) CPTRangePlotField.CPTRangePlotFieldLow);

        /// <summary>
        ///   <para>relative Left values.</para>
        /// </summary>
        public static readonly NSNumber FieldLeft = new NSNumber((int) CPTRangePlotField.CPTRangePlotFieldLeft);

        /// <summary>
        ///   <para>relative Right values.</para>
        /// </summary>
        public static readonly NSNumber FieldRight = new NSNumber((int) CPTRangePlotField.CPTRangePlotFieldRight);
    }
}