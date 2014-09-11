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
using Monobjc.Types;

namespace Monobjc.Generators
{
    [ObjectiveCCategory("NSObject")]
    public static class DummyCategoryVariousParameters
    {
        [ObjectiveCMessage("methodParameter1")]
        public static void MethodParameter1(this TSObject target, bool arg1) {}

        [ObjectiveCMessage("methodParameter2")]
        public static void MethodParameter2(this TSObject target, char arg1, short arg2, int arg3, long arg4) {}

        [ObjectiveCMessage("methodParameter3")]
        public static void MethodParameter3(this TSObject target, byte arg1, ushort arg2, uint arg3, ulong arg4) {}

        [ObjectiveCMessage("methodParameter4")]
        public static void MethodParameter4(this TSObject target, IntPtr arg1, Class arg2, Id arg3, String arg4) {}

        [ObjectiveCMessage("methodParameter5")]
        public static void MethodParameter5(this TSObject target, TSWindingRule arg1) {}

        [ObjectiveCMessage("methodParameter6")]
        public static void MethodParameter6(this TSObject target, float arg1, double arg2) {}
    }

    public static class DummyCategoryVariousParameters_Proxy
    {
        public static readonly MethodParameter1_Monobjc_Types_TSObject_System_Boolean_Invoker MethodParameter1_Monobjc_Types_TSObject_System_Boolean_Delegate = MethodParameter1_Monobjc_Types_TSObject_System_Boolean;

        public static readonly MethodParameter2_Monobjc_Types_TSObject_System_Char_System_Int16_System_Int32_System_Int64_Invoker MethodParameter2_Monobjc_Types_TSObject_System_Char_System_Int16_System_Int32_System_Int64_Delegate =
            MethodParameter2_Monobjc_Types_TSObject_System_Char_System_Int16_System_Int32_System_Int64;

        public static readonly MethodParameter3_Monobjc_Types_TSObject_System_Byte_System_UInt16_System_UInt32_System_UInt64_Invoker MethodParameter3_Monobjc_Types_TSObject_System_Byte_System_UInt16_System_UInt32_System_UInt64_Delegate =
            MethodParameter3_Monobjc_Types_TSObject_System_Byte_System_UInt16_System_UInt32_System_UInt64;

        public static readonly MethodParameter4_Monobjc_Types_TSObject_System_IntPtr_Monobjc_Class_Monobjc_Id_System_String_Invoker MethodParameter4_Monobjc_Types_TSObject_System_IntPtr_Monobjc_Class_Monobjc_Id_System_String_Delegate =
            MethodParameter4_Monobjc_Types_TSObject_System_IntPtr_Monobjc_Class_Monobjc_Id_System_String;

        public static readonly MethodParameter5_Monobjc_Types_TSObject_Monobjc_Types_TSWindingRule_Invoker MethodParameter5_Monobjc_Types_TSObject_Monobjc_Types_TSWindingRule_Delegate = MethodParameter5_Monobjc_Types_TSObject_Monobjc_Types_TSWindingRule;
        public static readonly MethodParameter6_Monobjc_Types_TSObject_System_Single_System_Double_Invoker MethodParameter6_Monobjc_Types_TSObject_System_Single_System_Double_Delegate = MethodParameter6_Monobjc_Types_TSObject_System_Single_System_Double;

        public static void MethodParameter1_Monobjc_Types_TSObject_System_Boolean(IntPtr receiver, IntPtr selector, bool arg1)
        {
            ObjectiveCRuntime.GetInstance<TSObject>(receiver).MethodParameter1(arg1);
        }

        public static void MethodParameter2_Monobjc_Types_TSObject_System_Char_System_Int16_System_Int32_System_Int64(IntPtr receiver, IntPtr selector, char arg1, short arg2, int arg3, long arg4)
        {
            ObjectiveCRuntime.GetInstance<TSObject>(receiver).MethodParameter2(arg1, arg2, arg3, arg4);
        }

        public static void MethodParameter3_Monobjc_Types_TSObject_System_Byte_System_UInt16_System_UInt32_System_UInt64(IntPtr receiver, IntPtr selector, byte arg1, ushort arg2, uint arg3, ulong arg4)
        {
            ObjectiveCRuntime.GetInstance<TSObject>(receiver).MethodParameter3(arg1, arg2, arg3, arg4);
        }

        public static void MethodParameter4_Monobjc_Types_TSObject_System_IntPtr_Monobjc_Class_Monobjc_Id_System_String(IntPtr receiver, IntPtr selector, IntPtr arg1, IntPtr arg2, IntPtr arg3, string arg4)
        {
            ObjectiveCRuntime.GetInstance<TSObject>(receiver).MethodParameter4(arg1, ObjectiveCRuntime.GetInstance<Class>(arg2), ObjectiveCRuntime.GetInstance<Id>(arg3), arg4);
        }

        public static void MethodParameter5_Monobjc_Types_TSObject_Monobjc_Types_TSWindingRule(IntPtr receiver, IntPtr selector, int arg1)
        {
            ObjectiveCRuntime.GetInstance<TSObject>(receiver).MethodParameter5((TSWindingRule) arg1);
        }

        public static void MethodParameter6_Monobjc_Types_TSObject_System_Single_System_Double(IntPtr receiver, IntPtr selector, float arg1, double arg2)
        {
            ObjectiveCRuntime.GetInstance<TSObject>(receiver).MethodParameter6(arg1, arg2);
        }

        public delegate void MethodParameter1_Monobjc_Types_TSObject_System_Boolean_Invoker(IntPtr receiver, IntPtr selector, bool arg1);

        public delegate void MethodParameter2_Monobjc_Types_TSObject_System_Char_System_Int16_System_Int32_System_Int64_Invoker(IntPtr receiver, IntPtr selector, char arg1, short arg2, int arg3, long arg4);

        public delegate void MethodParameter3_Monobjc_Types_TSObject_System_Byte_System_UInt16_System_UInt32_System_UInt64_Invoker(IntPtr receiver, IntPtr selector, byte arg1, ushort arg2, uint arg3, ulong arg4);

        public delegate void MethodParameter4_Monobjc_Types_TSObject_System_IntPtr_Monobjc_Class_Monobjc_Id_System_String_Invoker(IntPtr receiver, IntPtr selector, IntPtr arg1, IntPtr arg2, IntPtr arg3, string arg4);

        public delegate void MethodParameter5_Monobjc_Types_TSObject_Monobjc_Types_TSWindingRule_Invoker(IntPtr receiver, IntPtr selector, int arg1);

        public delegate void MethodParameter6_Monobjc_Types_TSObject_System_Single_System_Double_Invoker(IntPtr receiver, IntPtr selector, float arg1, double arg2);
    }

    [ObjectiveCCategory("NSArray")]
    public static class DummyCategoryVariousReturns
    {
        [ObjectiveCMessage("boolMethod")]
        public static bool BoolMethod(this TSArray target)
        {
            return false;
        }

        [ObjectiveCMessage("charMethod")]
        public static char CharMethod(this TSArray target)
        {
            return 'A';
        }

        [ObjectiveCMessage("shortMethod")]
        public static short ShortMethod(this TSArray target)
        {
            return 0;
        }

        [ObjectiveCMessage("intMethod")]
        public static int IntMethod(this TSArray target)
        {
            return 0;
        }

        [ObjectiveCMessage("longMethod")]
        public static long LongMethod(this TSArray target)
        {
            return 0;
        }

        [ObjectiveCMessage("byteMethod")]
        public static byte ByteMethod(this TSArray target)
        {
            return 0;
        }

        [ObjectiveCMessage("ushortMethod")]
        public static ushort UshortMethod(this TSArray target)
        {
            return 0;
        }

        [ObjectiveCMessage("uintMethod")]
        public static uint UintMethod(this TSArray target)
        {
            return 0;
        }

        [ObjectiveCMessage("ulongMethod")]
        public static ulong UlongMethod(this TSArray target)
        {
            return 0;
        }

        [ObjectiveCMessage("floatMethod")]
        public static float FloatMethod(this TSArray target)
        {
            return 0;
        }

        [ObjectiveCMessage("doubleMethod")]
        public static double DoubleMethod(this TSArray target)
        {
            return 0;
        }

        [ObjectiveCMessage("pointerMethod")]
        public static IntPtr PointerMethod(this TSArray target)
        {
            return IntPtr.Zero;
        }

        [ObjectiveCMessage("classMethod")]
        public static Class ClassMethod(this TSArray target)
        {
            return null;
        }

        [ObjectiveCMessage("classMethod")]
        public static Id IdMethod(this TSArray target)
        {
            return null;
        }

        [ObjectiveCMessage("wrapperMethod")]
        public static IManagedWrapper WrapperMethod(this TSArray target)
        {
            return null;
        }

        [ObjectiveCMessage("enumMethod")]
        public static TSWindingRule EnumMethod(this TSArray target)
        {
            return TSWindingRule.NSEvenOddWindingRule;
        }
    }

    public static class DummyCategoryVariousReturns_Proxy
    {
        public static readonly BoolMethod_Monobjc_Types_TSArray_Invoker BoolMethod_Monobjc_Types_TSArray_Delegate = BoolMethod_Monobjc_Types_TSArray;
        public static readonly ByteMethod_Monobjc_Types_TSArray_Invoker ByteMethod_Monobjc_Types_TSArray_Delegate = ByteMethod_Monobjc_Types_TSArray;
        public static readonly CharMethod_Monobjc_Types_TSArray_Invoker CharMethod_Monobjc_Types_TSArray_Delegate = CharMethod_Monobjc_Types_TSArray;
        public static readonly ClassMethod_Monobjc_Types_TSArray_Invoker ClassMethod_Monobjc_Types_TSArray_Delegate = ClassMethod_Monobjc_Types_TSArray;
        public static readonly DoubleMethod_Monobjc_Types_TSArray_Invoker DoubleMethod_Monobjc_Types_TSArray_Delegate = DoubleMethod_Monobjc_Types_TSArray;
        public static readonly EnumMethod_Monobjc_Types_TSArray_Invoker EnumMethod_Monobjc_Types_TSArray_Delegate = EnumMethod_Monobjc_Types_TSArray;
        public static readonly FloatMethod_Monobjc_Types_TSArray_Invoker FloatMethod_Monobjc_Types_TSArray_Delegate = FloatMethod_Monobjc_Types_TSArray;
        public static readonly IdMethod_Monobjc_Types_TSArray_Invoker IdMethod_Monobjc_Types_TSArray_Delegate = IdMethod_Monobjc_Types_TSArray;
        public static readonly IntMethod_Monobjc_Types_TSArray_Invoker IntMethod_Monobjc_Types_TSArray_Delegate = IntMethod_Monobjc_Types_TSArray;
        public static readonly LongMethod_Monobjc_Types_TSArray_Invoker LongMethod_Monobjc_Types_TSArray_Delegate = LongMethod_Monobjc_Types_TSArray;
        public static readonly PointerMethod_Monobjc_Types_TSArray_Invoker PointerMethod_Monobjc_Types_TSArray_Delegate = PointerMethod_Monobjc_Types_TSArray;
        public static readonly ShortMethod_Monobjc_Types_TSArray_Invoker ShortMethod_Monobjc_Types_TSArray_Delegate = ShortMethod_Monobjc_Types_TSArray;
        public static readonly UintMethod_Monobjc_Types_TSArray_Invoker UintMethod_Monobjc_Types_TSArray_Delegate = UintMethod_Monobjc_Types_TSArray;
        public static readonly UlongMethod_Monobjc_Types_TSArray_Invoker UlongMethod_Monobjc_Types_TSArray_Delegate = UlongMethod_Monobjc_Types_TSArray;
        public static readonly UshortMethod_Monobjc_Types_TSArray_Invoker UshortMethod_Monobjc_Types_TSArray_Delegate = UshortMethod_Monobjc_Types_TSArray;
        public static readonly WrapperMethod_Monobjc_Types_TSArray_Invoker WrapperMethod_Monobjc_Types_TSArray_Delegate = WrapperMethod_Monobjc_Types_TSArray;

        public static bool BoolMethod_Monobjc_Types_TSArray(IntPtr receiver, IntPtr selector)
        {
            return ObjectiveCRuntime.GetInstance<TSArray>(receiver).BoolMethod();
        }

        public static byte ByteMethod_Monobjc_Types_TSArray(IntPtr receiver, IntPtr selector)
        {
            return ObjectiveCRuntime.GetInstance<TSArray>(receiver).ByteMethod();
        }

        public static char CharMethod_Monobjc_Types_TSArray(IntPtr receiver, IntPtr selector)
        {
            return ObjectiveCRuntime.GetInstance<TSArray>(receiver).CharMethod();
        }

        public static IntPtr ClassMethod_Monobjc_Types_TSArray(IntPtr receiver, IntPtr selector)
        {
            Class class2 = ObjectiveCRuntime.GetInstance<TSArray>(receiver).ClassMethod();
            return ((class2 == null) ? IntPtr.Zero : class2.NativePointer);
        }

        public static double DoubleMethod_Monobjc_Types_TSArray(IntPtr receiver, IntPtr selector)
        {
            return ObjectiveCRuntime.GetInstance<TSArray>(receiver).DoubleMethod();
        }

        public static int EnumMethod_Monobjc_Types_TSArray(IntPtr receiver, IntPtr selector)
        {
            return (int) ObjectiveCRuntime.GetInstance<TSArray>(receiver).EnumMethod();
        }

        public static float FloatMethod_Monobjc_Types_TSArray(IntPtr receiver, IntPtr selector)
        {
            return ObjectiveCRuntime.GetInstance<TSArray>(receiver).FloatMethod();
        }

        public static IntPtr IdMethod_Monobjc_Types_TSArray(IntPtr receiver, IntPtr selector)
        {
            Id id = ObjectiveCRuntime.GetInstance<TSArray>(receiver).IdMethod();
            return ((id == null) ? IntPtr.Zero : id.NativePointer);
        }

        public static int IntMethod_Monobjc_Types_TSArray(IntPtr receiver, IntPtr selector)
        {
            return ObjectiveCRuntime.GetInstance<TSArray>(receiver).IntMethod();
        }

        public static long LongMethod_Monobjc_Types_TSArray(IntPtr receiver, IntPtr selector)
        {
            return ObjectiveCRuntime.GetInstance<TSArray>(receiver).LongMethod();
        }

        public static IntPtr PointerMethod_Monobjc_Types_TSArray(IntPtr receiver, IntPtr selector)
        {
            return ObjectiveCRuntime.GetInstance<TSArray>(receiver).PointerMethod();
        }

        public static short ShortMethod_Monobjc_Types_TSArray(IntPtr receiver, IntPtr selector)
        {
            return ObjectiveCRuntime.GetInstance<TSArray>(receiver).ShortMethod();
        }

        public static uint UintMethod_Monobjc_Types_TSArray(IntPtr receiver, IntPtr selector)
        {
            return ObjectiveCRuntime.GetInstance<TSArray>(receiver).UintMethod();
        }

        public static ulong UlongMethod_Monobjc_Types_TSArray(IntPtr receiver, IntPtr selector)
        {
            return ObjectiveCRuntime.GetInstance<TSArray>(receiver).UlongMethod();
        }

        public static ushort UshortMethod_Monobjc_Types_TSArray(IntPtr receiver, IntPtr selector)
        {
            return ObjectiveCRuntime.GetInstance<TSArray>(receiver).UshortMethod();
        }

        public static IntPtr WrapperMethod_Monobjc_Types_TSArray(IntPtr receiver, IntPtr selector)
        {
            IManagedWrapper wrapper = ObjectiveCRuntime.GetInstance<TSArray>(receiver).WrapperMethod();
            return ((wrapper == null) ? IntPtr.Zero : wrapper.NativePointer);
        }

        public delegate bool BoolMethod_Monobjc_Types_TSArray_Invoker(IntPtr receiver, IntPtr selector);

        public delegate byte ByteMethod_Monobjc_Types_TSArray_Invoker(IntPtr receiver, IntPtr selector);

        public delegate char CharMethod_Monobjc_Types_TSArray_Invoker(IntPtr receiver, IntPtr selector);

        public delegate IntPtr ClassMethod_Monobjc_Types_TSArray_Invoker(IntPtr receiver, IntPtr selector);

        public delegate double DoubleMethod_Monobjc_Types_TSArray_Invoker(IntPtr receiver, IntPtr selector);

        public delegate int EnumMethod_Monobjc_Types_TSArray_Invoker(IntPtr receiver, IntPtr selector);

        public delegate float FloatMethod_Monobjc_Types_TSArray_Invoker(IntPtr receiver, IntPtr selector);

        public delegate IntPtr IdMethod_Monobjc_Types_TSArray_Invoker(IntPtr receiver, IntPtr selector);

        public delegate int IntMethod_Monobjc_Types_TSArray_Invoker(IntPtr receiver, IntPtr selector);

        public delegate long LongMethod_Monobjc_Types_TSArray_Invoker(IntPtr receiver, IntPtr selector);

        public delegate IntPtr PointerMethod_Monobjc_Types_TSArray_Invoker(IntPtr receiver, IntPtr selector);

        public delegate short ShortMethod_Monobjc_Types_TSArray_Invoker(IntPtr receiver, IntPtr selector);

        public delegate uint UintMethod_Monobjc_Types_TSArray_Invoker(IntPtr receiver, IntPtr selector);

        public delegate ulong UlongMethod_Monobjc_Types_TSArray_Invoker(IntPtr receiver, IntPtr selector);

        public delegate ushort UshortMethod_Monobjc_Types_TSArray_Invoker(IntPtr receiver, IntPtr selector);

        public delegate IntPtr WrapperMethod_Monobjc_Types_TSArray_Invoker(IntPtr receiver, IntPtr selector);
    }

    [ObjectiveCCategory("NSString")]
    public static class DummyCategoryVariousParametersVariableTypes
    {
        [ObjectiveCMessage("methodParameter1")]
        public static void MethodParameter1(this TSString target, TSIntegerEnumeration arg1, TSUIntegerEnumeration arg2) {}

        [ObjectiveCMessage("methodParameter2")]
        public static void MethodParameter2(this TSString target, TSInteger arg1, TSUInteger arg2, TSFloat arg3) {}

        [ObjectiveCMessage("methodParameter3")]
        public static void MethodParameter3(this TSString target, TSRange arg1) {}

        [ObjectiveCMessage("methodParameter4")]
        public static void MethodParameter4(this TSString target, TSPoint arg1, TSSize arg2, TSRect arg3) {}
    }

    public static class DummyCategoryVariousParametersVariableTypes32Bits_Proxy
    {
        public static readonly MethodParameter1_Monobjc_Types_TSString_Monobjc_Types_TSIntegerEnumeration_Monobjc_Types_TSUIntegerEnumeration_Invoker
            MethodParameter1_Monobjc_Types_TSString_Monobjc_Types_TSIntegerEnumeration_Monobjc_Types_TSUIntegerEnumeration_Delegate = MethodParameter1_Monobjc_Types_TSString_Monobjc_Types_TSIntegerEnumeration_Monobjc_Types_TSUIntegerEnumeration;

        public static readonly MethodParameter2_Monobjc_Types_TSString_Monobjc_Types_TSInteger_Monobjc_Types_TSUInteger_Monobjc_Types_TSFloat_Invoker
            MethodParameter2_Monobjc_Types_TSString_Monobjc_Types_TSInteger_Monobjc_Types_TSUInteger_Monobjc_Types_TSFloat_Delegate = MethodParameter2_Monobjc_Types_TSString_Monobjc_Types_TSInteger_Monobjc_Types_TSUInteger_Monobjc_Types_TSFloat;

        public static readonly MethodParameter3_Monobjc_Types_TSString_Monobjc_Types_TSRange_Invoker MethodParameter3_Monobjc_Types_TSString_Monobjc_Types_TSRange_Delegate = MethodParameter3_Monobjc_Types_TSString_Monobjc_Types_TSRange;

        public static readonly MethodParameter4_Monobjc_Types_TSString_Monobjc_Types_TSPoint_Monobjc_Types_TSSize_Monobjc_Types_TSRect_Invoker MethodParameter4_Monobjc_Types_TSString_Monobjc_Types_TSPoint_Monobjc_Types_TSSize_Monobjc_Types_TSRect_Delegate
            = MethodParameter4_Monobjc_Types_TSString_Monobjc_Types_TSPoint_Monobjc_Types_TSSize_Monobjc_Types_TSRect;

        public static void MethodParameter1_Monobjc_Types_TSString_Monobjc_Types_TSIntegerEnumeration_Monobjc_Types_TSUIntegerEnumeration(IntPtr receiver, IntPtr selector, int arg1, uint arg2)
        {
            ObjectiveCRuntime.GetInstance<TSString>(receiver).MethodParameter1((TSIntegerEnumeration) arg1, (TSUIntegerEnumeration) arg2);
        }

        public static void MethodParameter2_Monobjc_Types_TSString_Monobjc_Types_TSInteger_Monobjc_Types_TSUInteger_Monobjc_Types_TSFloat(IntPtr receiver, IntPtr selector, int arg1, uint arg2, float arg3)
        {
            ObjectiveCRuntime.GetInstance<TSString>(receiver).MethodParameter2(arg1, arg2, arg3);
        }

        public static void MethodParameter3_Monobjc_Types_TSString_Monobjc_Types_TSRange(IntPtr receiver, IntPtr selector, TSRange arg1)
        {
            ObjectiveCRuntime.GetInstance<TSString>(receiver).MethodParameter3(arg1);
        }

        public static void MethodParameter4_Monobjc_Types_TSString_Monobjc_Types_TSPoint_Monobjc_Types_TSSize_Monobjc_Types_TSRect(IntPtr receiver, IntPtr selector, TSPoint arg1, TSSize arg2, TSRect arg3)
        {
            ObjectiveCRuntime.GetInstance<TSString>(receiver).MethodParameter4(arg1, arg2, arg3);
        }

        public delegate void MethodParameter1_Monobjc_Types_TSString_Monobjc_Types_TSIntegerEnumeration_Monobjc_Types_TSUIntegerEnumeration_Invoker(IntPtr receiver, IntPtr selector, int arg1, uint arg2);

        public delegate void MethodParameter2_Monobjc_Types_TSString_Monobjc_Types_TSInteger_Monobjc_Types_TSUInteger_Monobjc_Types_TSFloat_Invoker(IntPtr receiver, IntPtr selector, int arg1, uint arg2, float arg3);

        public delegate void MethodParameter3_Monobjc_Types_TSString_Monobjc_Types_TSRange_Invoker(IntPtr receiver, IntPtr selector, TSRange arg1);

        public delegate void MethodParameter4_Monobjc_Types_TSString_Monobjc_Types_TSPoint_Monobjc_Types_TSSize_Monobjc_Types_TSRect_Invoker(IntPtr receiver, IntPtr selector, TSPoint arg1, TSSize arg2, TSRect arg3);
    }

    public static class DummyCategoryVariousReturnsVariableTypes32Bits_Proxy
    {
        public static readonly FloatMethod_Monobjc_Types_TSControl_Invoker FloatMethod_Monobjc_Types_TSControl_Delegate = FloatMethod_Monobjc_Types_TSControl;
        public static readonly IntegerMethod_Monobjc_Types_TSControl_Invoker IntegerMethod_Monobjc_Types_TSControl_Delegate = IntegerMethod_Monobjc_Types_TSControl;
        public static readonly PointMethod_Monobjc_Types_TSControl_Invoker PointMethod_Monobjc_Types_TSControl_Delegate = PointMethod_Monobjc_Types_TSControl;
        public static readonly RangeMethod_Monobjc_Types_TSControl_Invoker RangeMethod_Monobjc_Types_TSControl_Delegate = RangeMethod_Monobjc_Types_TSControl;
        public static readonly RectMethod_Monobjc_Types_TSControl_Invoker RectMethod_Monobjc_Types_TSControl_Delegate = RectMethod_Monobjc_Types_TSControl;
        public static readonly UIntegerMethod_Monobjc_Types_TSControl_Invoker UIntegerMethod_Monobjc_Types_TSControl_Delegate = UIntegerMethod_Monobjc_Types_TSControl;
        public static readonly UnsignedEnumerationMethod_Monobjc_Types_TSControl_Invoker UnsignedEnumerationMethod_Monobjc_Types_TSControl_Delegate = UnsignedEnumerationMethod_Monobjc_Types_TSControl;
        public static readonly WindingEnumerationMethod_Monobjc_Types_TSControl_Invoker WindingEnumerationMethod_Monobjc_Types_TSControl_Delegate = WindingEnumerationMethod_Monobjc_Types_TSControl;

        public static float FloatMethod_Monobjc_Types_TSControl(IntPtr receiver, IntPtr selector)
        {
            return ObjectiveCRuntime.GetInstance<TSControl>(receiver).FloatMethod();
        }

        public static int IntegerMethod_Monobjc_Types_TSControl(IntPtr receiver, IntPtr selector)
        {
            return ObjectiveCRuntime.GetInstance<TSControl>(receiver).IntegerMethod();
        }

        public static TSPoint PointMethod_Monobjc_Types_TSControl(IntPtr receiver, IntPtr selector)
        {
            return ObjectiveCRuntime.GetInstance<TSControl>(receiver).PointMethod();
        }

        public static TSRange RangeMethod_Monobjc_Types_TSControl(IntPtr receiver, IntPtr selector)
        {
            return ObjectiveCRuntime.GetInstance<TSControl>(receiver).RangeMethod();
        }

        public static TSRect RectMethod_Monobjc_Types_TSControl(IntPtr receiver, IntPtr selector)
        {
            return ObjectiveCRuntime.GetInstance<TSControl>(receiver).RectMethod();
        }

        public static uint UIntegerMethod_Monobjc_Types_TSControl(IntPtr receiver, IntPtr selector)
        {
            return ObjectiveCRuntime.GetInstance<TSControl>(receiver).UIntegerMethod();
        }

        public static uint UnsignedEnumerationMethod_Monobjc_Types_TSControl(IntPtr receiver, IntPtr selector)
        {
            return (uint) ObjectiveCRuntime.GetInstance<TSControl>(receiver).UnsignedEnumerationMethod();
        }

        public static int WindingEnumerationMethod_Monobjc_Types_TSControl(IntPtr receiver, IntPtr selector)
        {
            return (int) ObjectiveCRuntime.GetInstance<TSControl>(receiver).WindingEnumerationMethod();
        }

        public delegate float FloatMethod_Monobjc_Types_TSControl_Invoker(IntPtr receiver, IntPtr selector);

        public delegate int IntegerMethod_Monobjc_Types_TSControl_Invoker(IntPtr receiver, IntPtr selector);

        public delegate TSPoint PointMethod_Monobjc_Types_TSControl_Invoker(IntPtr receiver, IntPtr selector);

        public delegate TSRange RangeMethod_Monobjc_Types_TSControl_Invoker(IntPtr receiver, IntPtr selector);

        public delegate TSRect RectMethod_Monobjc_Types_TSControl_Invoker(IntPtr receiver, IntPtr selector);

        public delegate uint UIntegerMethod_Monobjc_Types_TSControl_Invoker(IntPtr receiver, IntPtr selector);

        public delegate uint UnsignedEnumerationMethod_Monobjc_Types_TSControl_Invoker(IntPtr receiver, IntPtr selector);

        public delegate int WindingEnumerationMethod_Monobjc_Types_TSControl_Invoker(IntPtr receiver, IntPtr selector);
    }

    [ObjectiveCCategory("NSControl")]
    public static class DummyCategoryVariousReturnsVariableTypes
    {
        [ObjectiveCMessage("signedEnumerationMethod")]
        public static TSIntegerEnumeration WindingEnumerationMethod(this TSControl target)
        {
            return TSIntegerEnumeration.NSEvenOddWindingRule;
        }

        [ObjectiveCMessage("unsignedEnumerationMethod")]
        public static TSUIntegerEnumeration UnsignedEnumerationMethod(this TSControl target)
        {
            return TSUIntegerEnumeration.NSEvenOddWindingRule;
        }

        [ObjectiveCMessage("integerMethod")]
        public static TSInteger IntegerMethod(this TSControl target)
        {
            return 0;
        }

        [ObjectiveCMessage("uintegerMethod")]
        public static TSUInteger UIntegerMethod(this TSControl target)
        {
            return 0;
        }

        [ObjectiveCMessage("floatMethod")]
        public static TSFloat FloatMethod(this TSControl target)
        {
            return 0;
        }

        [ObjectiveCMessage("rangeMethod")]
        public static TSRange RangeMethod(this TSControl target)
        {
            return new TSRange();
        }

        [ObjectiveCMessage("pointMethod")]
        public static TSPoint PointMethod(this TSControl target)
        {
            return new TSPoint();
        }

        [ObjectiveCMessage("rectMethod")]
        public static TSRect RectMethod(this TSControl target)
        {
            return new TSRect();
        }
    }

    public static class DummyCategoryVariousParametersVariableTypes64Bits_Proxy
    {
        public static readonly MethodParameter1_Monobjc_Types_TSString_Monobjc_Types_TSIntegerEnumeration_Monobjc_Types_TSUIntegerEnumeration_Invoker
            MethodParameter1_Monobjc_Types_TSString_Monobjc_Types_TSIntegerEnumeration_Monobjc_Types_TSUIntegerEnumeration_Delegate = MethodParameter1_Monobjc_Types_TSString_Monobjc_Types_TSIntegerEnumeration_Monobjc_Types_TSUIntegerEnumeration;

        public static readonly MethodParameter2_Monobjc_Types_TSString_Monobjc_Types_TSInteger_Monobjc_Types_TSUInteger_Monobjc_Types_TSFloat_Invoker
            MethodParameter2_Monobjc_Types_TSString_Monobjc_Types_TSInteger_Monobjc_Types_TSUInteger_Monobjc_Types_TSFloat_Delegate = MethodParameter2_Monobjc_Types_TSString_Monobjc_Types_TSInteger_Monobjc_Types_TSUInteger_Monobjc_Types_TSFloat;

        public static readonly MethodParameter3_Monobjc_Types_TSString_Monobjc_Types_TSRange_Invoker MethodParameter3_Monobjc_Types_TSString_Monobjc_Types_TSRange_Delegate = MethodParameter3_Monobjc_Types_TSString_Monobjc_Types_TSRange;

        public static readonly MethodParameter4_Monobjc_Types_TSString_Monobjc_Types_TSPoint_Monobjc_Types_TSSize_Monobjc_Types_TSRect_Invoker MethodParameter4_Monobjc_Types_TSString_Monobjc_Types_TSPoint_Monobjc_Types_TSSize_Monobjc_Types_TSRect_Delegate
            = MethodParameter4_Monobjc_Types_TSString_Monobjc_Types_TSPoint_Monobjc_Types_TSSize_Monobjc_Types_TSRect;

        public static void MethodParameter1_Monobjc_Types_TSString_Monobjc_Types_TSIntegerEnumeration_Monobjc_Types_TSUIntegerEnumeration(IntPtr receiver, IntPtr selector, long arg1, ulong arg2)
        {
            ObjectiveCRuntime.GetInstance<TSString>(receiver).MethodParameter1((TSIntegerEnumeration) arg1, (TSUIntegerEnumeration) arg2);
        }

        public static void MethodParameter2_Monobjc_Types_TSString_Monobjc_Types_TSInteger_Monobjc_Types_TSUInteger_Monobjc_Types_TSFloat(IntPtr receiver, IntPtr selector, long arg1, ulong arg2, double arg3)
        {
            ObjectiveCRuntime.GetInstance<TSString>(receiver).MethodParameter2(arg1, arg2, arg3);
        }

        public static void MethodParameter3_Monobjc_Types_TSString_Monobjc_Types_TSRange(IntPtr receiver, IntPtr selector, TSRange64 arg1)
        {
            ObjectiveCRuntime.GetInstance<TSString>(receiver).MethodParameter3(arg1);
        }

        public static void MethodParameter4_Monobjc_Types_TSString_Monobjc_Types_TSPoint_Monobjc_Types_TSSize_Monobjc_Types_TSRect(IntPtr receiver, IntPtr selector, TSPoint64 arg1, TSSize64 arg2, TSRect64 arg3)
        {
            ObjectiveCRuntime.GetInstance<TSString>(receiver).MethodParameter4(arg1, arg2, arg3);
        }

        public delegate void MethodParameter1_Monobjc_Types_TSString_Monobjc_Types_TSIntegerEnumeration_Monobjc_Types_TSUIntegerEnumeration_Invoker(IntPtr receiver, IntPtr selector, long arg1, ulong arg2);

        public delegate void MethodParameter2_Monobjc_Types_TSString_Monobjc_Types_TSInteger_Monobjc_Types_TSUInteger_Monobjc_Types_TSFloat_Invoker(IntPtr receiver, IntPtr selector, long arg1, ulong arg2, double arg3);

        public delegate void MethodParameter3_Monobjc_Types_TSString_Monobjc_Types_TSRange_Invoker(IntPtr receiver, IntPtr selector, TSRange64 arg1);

        public delegate void MethodParameter4_Monobjc_Types_TSString_Monobjc_Types_TSPoint_Monobjc_Types_TSSize_Monobjc_Types_TSRect_Invoker(IntPtr receiver, IntPtr selector, TSPoint64 arg1, TSSize64 arg2, TSRect64 arg3);
    }

    public static class DummyCategoryVariousReturnsVariableTypes64Bits_Proxy
    {
        public static readonly FloatMethod_Monobjc_Types_TSControl_Invoker FloatMethod_Monobjc_Types_TSControl_Delegate = FloatMethod_Monobjc_Types_TSControl;
        public static readonly IntegerMethod_Monobjc_Types_TSControl_Invoker IntegerMethod_Monobjc_Types_TSControl_Delegate = IntegerMethod_Monobjc_Types_TSControl;
        public static readonly PointMethod_Monobjc_Types_TSControl_Invoker PointMethod_Monobjc_Types_TSControl_Delegate = PointMethod_Monobjc_Types_TSControl;
        public static readonly RangeMethod_Monobjc_Types_TSControl_Invoker RangeMethod_Monobjc_Types_TSControl_Delegate = RangeMethod_Monobjc_Types_TSControl;
        public static readonly RectMethod_Monobjc_Types_TSControl_Invoker RectMethod_Monobjc_Types_TSControl_Delegate = RectMethod_Monobjc_Types_TSControl;
        public static readonly UIntegerMethod_Monobjc_Types_TSControl_Invoker UIntegerMethod_Monobjc_Types_TSControl_Delegate = UIntegerMethod_Monobjc_Types_TSControl;
        public static readonly UnsignedEnumerationMethod_Monobjc_Types_TSControl_Invoker UnsignedEnumerationMethod_Monobjc_Types_TSControl_Delegate = UnsignedEnumerationMethod_Monobjc_Types_TSControl;
        public static readonly WindingEnumerationMethod_Monobjc_Types_TSControl_Invoker WindingEnumerationMethod_Monobjc_Types_TSControl_Delegate = WindingEnumerationMethod_Monobjc_Types_TSControl;

        public static double FloatMethod_Monobjc_Types_TSControl(IntPtr receiver, IntPtr selector)
        {
            return ObjectiveCRuntime.GetInstance<TSControl>(receiver).FloatMethod();
        }

        public static long IntegerMethod_Monobjc_Types_TSControl(IntPtr receiver, IntPtr selector)
        {
            return ObjectiveCRuntime.GetInstance<TSControl>(receiver).IntegerMethod();
        }

        public static TSPoint64 PointMethod_Monobjc_Types_TSControl(IntPtr receiver, IntPtr selector)
        {
            return ObjectiveCRuntime.GetInstance<TSControl>(receiver).PointMethod();
        }

        public static TSRange64 RangeMethod_Monobjc_Types_TSControl(IntPtr receiver, IntPtr selector)
        {
            return ObjectiveCRuntime.GetInstance<TSControl>(receiver).RangeMethod();
        }

        public static TSRect64 RectMethod_Monobjc_Types_TSControl(IntPtr receiver, IntPtr selector)
        {
            return ObjectiveCRuntime.GetInstance<TSControl>(receiver).RectMethod();
        }

        public static ulong UIntegerMethod_Monobjc_Types_TSControl(IntPtr receiver, IntPtr selector)
        {
            return ObjectiveCRuntime.GetInstance<TSControl>(receiver).UIntegerMethod();
        }

        public static ulong UnsignedEnumerationMethod_Monobjc_Types_TSControl(IntPtr receiver, IntPtr selector)
        {
            return (ulong) ObjectiveCRuntime.GetInstance<TSControl>(receiver).UnsignedEnumerationMethod();
        }

        public static long WindingEnumerationMethod_Monobjc_Types_TSControl(IntPtr receiver, IntPtr selector)
        {
            return (long) ObjectiveCRuntime.GetInstance<TSControl>(receiver).WindingEnumerationMethod();
        }

        public delegate double FloatMethod_Monobjc_Types_TSControl_Invoker(IntPtr receiver, IntPtr selector);

        public delegate long IntegerMethod_Monobjc_Types_TSControl_Invoker(IntPtr receiver, IntPtr selector);

        public delegate TSPoint64 PointMethod_Monobjc_Types_TSControl_Invoker(IntPtr receiver, IntPtr selector);

        public delegate TSRange64 RangeMethod_Monobjc_Types_TSControl_Invoker(IntPtr receiver, IntPtr selector);

        public delegate TSRect64 RectMethod_Monobjc_Types_TSControl_Invoker(IntPtr receiver, IntPtr selector);

        public delegate ulong UIntegerMethod_Monobjc_Types_TSControl_Invoker(IntPtr receiver, IntPtr selector);

        public delegate ulong UnsignedEnumerationMethod_Monobjc_Types_TSControl_Invoker(IntPtr receiver, IntPtr selector);

        public delegate long WindingEnumerationMethod_Monobjc_Types_TSControl_Invoker(IntPtr receiver, IntPtr selector);
    }
}