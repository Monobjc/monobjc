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
using System;
using System.Runtime.InteropServices;

namespace Monobjc.Types
{
    [ObjectiveCProtocol("NSObject")]
    public interface ITSObject : IManagedWrapper
    {
        [ObjectiveCMessage("isMemberOfClass:")]
        bool IsMemberOfClass(Class aClass);

        [ObjectiveCMessage("performSelector:")]
        Id PerformSelector(IntPtr aSelector);

        [ObjectiveCMessage("respondsToSelector:")]
        bool RespondsToSelector(IntPtr aSelector);

        TSUInteger Hash { [ObjectiveCMessage("hash")]
        get; }

        bool IsProxy { [ObjectiveCMessage("isProxy")]
        get; }

        Class Superclass { [ObjectiveCMessage("superclass")]
        get; }
    }

    [ObjectiveCClass("NSObject", InterceptDealloc = true)]
    public class TSObject : Id
    {
        public TSObject() {}
        public TSObject(IntPtr value) : base(value) {}
        protected TSObject(String selector, Object firstParameter, params Object[] otherParameters) : base(selector, firstParameter, otherParameters) {}

        public virtual Id Init()
        {
            return ObjectiveCRuntime.SendMessage<Id>(this, "init");
        }
    }

    [ObjectiveCClass("NSAutoreleasePool")]
    public class TSAutoreleasePool : TSObject
    {
        public TSAutoreleasePool() {}
        public TSAutoreleasePool(IntPtr value) : base(value) {}
    }

    [ObjectiveCClass("NSString")]
    public class TSString : TSObject
    {
        public TSString() {}
        public TSString(IntPtr value) : base(value) {}
    }

    [ObjectiveCClass("NSArray")]
    public class TSArray : TSObject
    {
        public TSArray() {}
        public TSArray(IntPtr value) : base(value) {}
    }

    [ObjectiveCClass("NSNumber")]
    public class TSNumber : TSObject
    {
        public TSNumber() {}
        public TSNumber(IntPtr value) : base(value) {}
    }

    [ObjectiveCClass("NSControl")]
    public class TSControl : TSObject
    {
        public TSControl() {}
        public TSControl(IntPtr value) : base(value) {}
    }

    [ObjectiveCClass("NSWindow")]
    public class TSWindow : TSObject
    {
        public TSWindow() {}
        public TSWindow(IntPtr value) : base(value) {}
    }

    public enum TSWindingRule
    {
        NSNonZeroWindingRule = 0,
        NSEvenOddWindingRule = 1
    }

    [ObjectiveCUnderlyingType(typeof (int), Is64Bits = false)]
    [ObjectiveCUnderlyingType(typeof (long), Is64Bits = true)]
    public enum TSIntegerEnumeration
    {
        NSNonZeroWindingRule = 0,
        NSEvenOddWindingRule = 1
    }

    [ObjectiveCUnderlyingType(typeof (uint), Is64Bits = false)]
    [ObjectiveCUnderlyingType(typeof (ulong), Is64Bits = true)]
    public enum TSUIntegerEnumeration : uint
    {
        NSNonZeroWindingRule = 0,
        NSEvenOddWindingRule = 1
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct TSByte
    {
        public byte x;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct TSShort
    {
        public short x;
    }

    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    [ObjectiveCUnderlyingType(typeof (float), Is64Bits = false)]
    [ObjectiveCUnderlyingType(typeof (double), Is64Bits = true)]
    public struct TSFloat
    {
        public float value;

        private TSFloat(float value)
        {
            this.value = value;
        }

        public static implicit operator TSFloat(float value)
        {
            return new TSFloat(value);
        }

        public static implicit operator float(TSFloat value)
        {
            return value.value;
        }

        public static implicit operator TSFloat(double value)
        {
            return new TSFloat((float) value);
        }

        public static implicit operator double(TSFloat value)
        {
            return value.value;
        }
    }

    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    [ObjectiveCUnderlyingType(typeof (int), Is64Bits = false)]
    [ObjectiveCUnderlyingType(typeof (long), Is64Bits = true)]
    public struct TSInteger
    {
        public int value;

        public TSInteger(int value)
        {
            this.value = value;
        }

        public static implicit operator TSInteger(int value)
        {
            return new TSInteger(value);
        }

        public static implicit operator int(TSInteger value)
        {
            return value.value;
        }

        public static implicit operator TSInteger(long value)
        {
            return new TSInteger((int) value);
        }

        public static implicit operator long(TSInteger value)
        {
            return value.value;
        }
    }

    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    [ObjectiveCUnderlyingType(typeof (uint), Is64Bits = false)]
    [ObjectiveCUnderlyingType(typeof (ulong), Is64Bits = true)]
    public struct TSUInteger
    {
        public uint value;

        private TSUInteger(uint value)
        {
            this.value = value;
        }

        public static implicit operator TSUInteger(uint value)
        {
            return new TSUInteger(value);
        }

        public static implicit operator uint(TSUInteger value)
        {
            return value.value;
        }

        public static implicit operator TSUInteger(ulong value)
        {
            return new TSUInteger((uint) value);
        }

        public static implicit operator ulong(TSUInteger value)
        {
            return value.value;
        }
    }

    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    [ObjectiveCUnderlyingType(typeof (TSPoint), Is64Bits = false)]
    [ObjectiveCUnderlyingType(typeof (TSPoint64), Is64Bits = true)]
    public struct TSPoint
    {
        public float x;
        public float y;

        public TSPoint(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct TSPoint64
    {
        public double x;
        public double y;

        public TSPoint64(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public static implicit operator TSPoint(TSPoint64 value)
        {
            return new TSPoint((float) value.x, (float) value.y);
        }

        public static implicit operator TSPoint64(TSPoint value)
        {
            return new TSPoint64(value.x, value.y);
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    [ObjectiveCUnderlyingType(typeof (TSSize), Is64Bits = false)]
    [ObjectiveCUnderlyingType(typeof (TSSize64), Is64Bits = true)]
    public struct TSSize
    {
        public float width;
        public float height;

        public TSSize(float width, float height)
        {
            this.width = width;
            this.height = height;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct TSSize64
    {
        public double width;
        public double height;

        public TSSize64(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        public static implicit operator TSSize(TSSize64 value)
        {
            return new TSSize((float) value.width, (float) value.height);
        }

        public static implicit operator TSSize64(TSSize value)
        {
            return new TSSize64(value.width, value.height);
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    [ObjectiveCUnderlyingType(typeof (TSRect), Is64Bits = false)]
    [ObjectiveCUnderlyingType(typeof (TSRect64), Is64Bits = true)]
    public struct TSRect
    {
        public TSPoint origin;
        public TSSize size;

        public TSRect(TSPoint origin, TSSize size)
        {
            this.origin = origin;
            this.size = size;
        }

        public TSRect(float x, float y, float width, float height)
        {
            this.origin.x = x;
            this.origin.y = y;
            this.size.width = width;
            this.size.height = height;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct TSRect64
    {
        public TSPoint64 origin;
        public TSSize64 size;

        public TSRect64(TSPoint64 origin, TSSize64 size)
        {
            this.origin = origin;
            this.size = size;
        }

        public TSRect64(double x, double y, double width, double height)
        {
            this.origin.x = x;
            this.origin.y = y;
            this.size.width = width;
            this.size.height = height;
        }

        public static implicit operator TSRect(TSRect64 value)
        {
            return new TSRect(value.origin, value.size);
        }

        public static implicit operator TSRect64(TSRect value)
        {
            return new TSRect64(value.origin, value.size);
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    [ObjectiveCUnderlyingType(typeof (TSRange), Is64Bits = false)]
    [ObjectiveCUnderlyingType(typeof (TSRange64), Is64Bits = true)]
    public struct TSRange
    {
        public uint location;
        public uint length;

        public TSRange(uint location, uint length)
        {
            this.location = location;
            this.length = length;
        }

        public override string ToString()
        {
            return "TSRange(location=" + this.location + ", length=" + this.length + ")";
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct TSRange64
    {
        public ulong location;
        public ulong length;

        public TSRange64(ulong location, ulong length)
        {
            this.location = location;
            this.length = length;
        }

        public static implicit operator TSRange(TSRange64 value)
        {
            return new TSRange((uint) value.location, (uint) value.length);
        }

        public static implicit operator TSRange64(TSRange value)
        {
            return new TSRange64(value.location, value.length);
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct TSDecimal
    {
        public int fields;
        public ushort mantissa1, mantissa2, mantissa3, mantissa4, mantissa5, mantissa6, mantissa7, mantissa8;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct TSBig
    {
        public TSRect rect1;
        public TSRect rect2;

        public TSBig(TSRect rect1, TSRect rect2)
        {
            this.rect1 = rect1;
            this.rect2 = rect2;
        }
    }
}