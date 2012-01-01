//
// This file is part of Monobjc, a .NET/Objective-C bridge
// Copyright (C) 2007-2012 - Laurent Etiemble
//
// Monobjc is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// any later version.
//
// Monobjc is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with Monobjc.  If not, see <http://www.gnu.org/licenses/>.
//
using System;

namespace Monobjc.Generators.Cecil
{
    //
    // ByteBuffer.cs
    //
    // Author:
    //   Jb Evain (jbevain@novell.com)
    //
    // (C) 2009 - 2010 Novell, Inc. (http://www.novell.com)
    //
    // Permission is hereby granted, free of charge, to any person obtaining
    // a copy of this software and associated documentation files (the
    // "Software"), to deal in the Software without restriction, including
    // without limitation the rights to use, copy, modify, merge, publish,
    // distribute, sublicense, and/or sell copies of the Software, and to
    // permit persons to whom the Software is furnished to do so, subject to
    // the following conditions:
    //
    // The above copyright notice and this permission notice shall be
    // included in all copies or substantial portions of the Software.
    //
    // THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
    // EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
    // MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
    // NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
    // LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
    // OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
    // WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
    //
    internal class ByteBuffer
    {
        internal byte[] buffer;
        internal int position;

        public ByteBuffer(byte[] buffer)
        {
            this.buffer = buffer;
        }

        public byte ReadByte()
        {
            this.CheckCanRead(1);
            return this.buffer[this.position++];
        }

        public byte[] ReadBytes(int length)
        {
            this.CheckCanRead(length);
            byte[] value = new byte[length];
            Buffer.BlockCopy(this.buffer, this.position, value, 0, length);
            this.position += length;
            return value;
        }

        public short ReadInt16()
        {
            this.CheckCanRead(2);
            short value = (short) (this.buffer[this.position]
                                   | (this.buffer[this.position + 1] << 8));
            this.position += 2;
            return value;
        }

        public int ReadInt32()
        {
            this.CheckCanRead(4);
            int value = this.buffer[this.position]
                        | (this.buffer[this.position + 1] << 8)
                        | (this.buffer[this.position + 2] << 16)
                        | (this.buffer[this.position + 3] << 24);
            this.position += 4;
            return value;
        }

        public long ReadInt64()
        {
            this.CheckCanRead(8);
            uint low = (uint) (this.buffer[this.position]
                               | (this.buffer[this.position + 1] << 8)
                               | (this.buffer[this.position + 2] << 16)
                               | (this.buffer[this.position + 3] << 24));

            uint high = (uint) (this.buffer[this.position + 4]
                                | (this.buffer[this.position + 5] << 8)
                                | (this.buffer[this.position + 6] << 16)
                                | (this.buffer[this.position + 7] << 24));

            long value = (((long) high) << 32) | low;
            this.position += 8;
            return value;
        }

        public float ReadSingle()
        {
            if (!BitConverter.IsLittleEndian)
            {
                byte[] bytes = this.ReadBytes(4);
                Array.Reverse(bytes);
                return BitConverter.ToSingle(bytes, 0);
            }

            this.CheckCanRead(4);
            float value = BitConverter.ToSingle(this.buffer, this.position);
            this.position += 4;
            return value;
        }

        public double ReadDouble()
        {
            if (!BitConverter.IsLittleEndian)
            {
                byte[] bytes = this.ReadBytes(8);
                Array.Reverse(bytes);
                return BitConverter.ToDouble(bytes, 0);
            }

            this.CheckCanRead(8);
            double value = BitConverter.ToDouble(this.buffer, this.position);
            this.position += 8;
            return value;
        }

        private void CheckCanRead(int count)
        {
            if (this.position + count > this.buffer.Length)
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }
}