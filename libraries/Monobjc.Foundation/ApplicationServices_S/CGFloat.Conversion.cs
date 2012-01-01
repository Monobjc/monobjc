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

using Monobjc.Foundation;



namespace Monobjc.ApplicationServices
{
    public partial struct CGFloat
    {

        public static implicit operator sbyte(CGFloat value)

        {

            return (sbyte)value.value;

        }

        public static implicit operator CGFloat(sbyte value)

        {

            return new CGFloat(value);

        }



        public static implicit operator short(CGFloat value)

        {

            return (short)value.value;

        }

        public static implicit operator CGFloat(short value)

        {

            return new CGFloat(value);

        }



        public static implicit operator int(CGFloat value)

        {

            return (int)value.value;

        }

        public static implicit operator CGFloat(int value)

        {

            return new CGFloat(value);

        }



        public static implicit operator long(CGFloat value)

        {

            return (long)value.value;

        }

        public static implicit operator CGFloat(long value)

        {

            return new CGFloat(value);

        }



        public static implicit operator byte(CGFloat value)

        {

            return (byte)value.value;

        }

        public static implicit operator CGFloat(byte value)

        {

            return new CGFloat(value);

        }



        public static implicit operator ushort(CGFloat value)

        {

            return (ushort)value.value;

        }

        public static implicit operator CGFloat(ushort value)

        {

            return new CGFloat(value);

        }



        public static implicit operator uint(CGFloat value)

        {

            return (uint)value.value;

        }

        public static implicit operator CGFloat(uint value)

        {

            return new CGFloat(value);

        }



        public static implicit operator ulong(CGFloat value)

        {

            return (ulong)value.value;

        }

        public static implicit operator CGFloat(ulong value)

        {

            return new CGFloat(value);

        }



        public static implicit operator float(CGFloat value)
        {
            return value.value;
        }
        public static implicit operator CGFloat(float value)
        {
            return new CGFloat(value);
        }

        public static implicit operator double(CGFloat value)
        {
            return value.value;
        }
        public static implicit operator CGFloat(double value)
        {
            return new CGFloat((float)value);
        }



        public static implicit operator NSInteger(CGFloat value)

        {

            return new NSInteger((int)value.value);

        }

        public static implicit operator NSUInteger(CGFloat value)

        {

            return new NSUInteger((uint)value.value);

        }

    }
}