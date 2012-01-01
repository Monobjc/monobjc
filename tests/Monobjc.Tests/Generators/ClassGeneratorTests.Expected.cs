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
using System.Runtime.InteropServices;
using Monobjc.Types;

namespace Monobjc.Generators
{
    [ObjectiveCClass("DummyClassEmpty")]
    public class DummyClassEmpty : TSObject
    {
        public DummyClassEmpty() {}

        public DummyClassEmpty(IntPtr value) : base(value) {}
    }

    public static class DummyClassEmpty_Proxy {}

    [ObjectiveCClass("DummyClassOneField")]
    public class DummyClassOneField : TSObject
    {
        [ObjectiveCIVar("field1")]
        public Id field1 { get; set; }

        public DummyClassOneField() {}

        public DummyClassOneField(IntPtr value) : base(value) {}
    }

    public static class DummyClassOneField_Proxy {}

    [ObjectiveCClass("DummyClassMoreField")]
    public class DummyClassMoreField : TSObject
    {
        [ObjectiveCIVar("field1")]
        public Id field1 { get; set; }

        [ObjectiveCIVar("field2")]
        public int field2 { get; set; }

        [ObjectiveCIVar("field3")]
        public long field3 { get; set; }

        public DummyClassMoreField() {}

        public DummyClassMoreField(IntPtr value) : base(value) {}
    }

    public static class DummyClassMoreField_Proxy {}

    [ObjectiveCClass("DummyClassStatic")]
    public class DummyClassStaticInstance : TSObject
    {
        public DummyClassStaticInstance() {}

        public DummyClassStaticInstance(IntPtr value) : base(value) {}

        [ObjectiveCMessage("methodInstanceInt")]
        public void MethodInstanceInt(int arg1) {}

        [ObjectiveCMessage("methodStaticInt")]
        public static void MethodStaticInt(int arg1) {}

        [ObjectiveCMessage("returnInstanceInt")]
        public int ReturnInstanceInt(int arg1)
        {
            return 0;
        }

        [ObjectiveCMessage("returnStaticInt")]
        public static int ReturnStaticInt(int arg1)
        {
            return 0;
        }
    }

    public static class DummyClassStaticInstance_Proxy
    {
        public static readonly MethodInstanceInt_System_Int32_Invoker MethodInstanceInt_System_Int32_Delegate = MethodInstanceInt_System_Int32;
        public static readonly MethodStaticInt_System_Int32_Invoker MethodStaticInt_System_Int32_Delegate = MethodStaticInt_System_Int32;
        public static readonly ReturnInstanceInt_System_Int32_Invoker ReturnInstanceInt_System_Int32_Delegate = ReturnInstanceInt_System_Int32;
        public static readonly ReturnStaticInt_System_Int32_Invoker ReturnStaticInt_System_Int32_Delegate = ReturnStaticInt_System_Int32;

        public static void MethodInstanceInt_System_Int32(IntPtr receiver, IntPtr selector, int arg1)
        {
            ObjectiveCRuntime.GetInstance<DummyClassStaticInstance>(receiver).MethodInstanceInt(arg1);
        }

        public static void MethodStaticInt_System_Int32(IntPtr receiver, IntPtr selector, int arg1)
        {
            DummyClassStaticInstance.MethodStaticInt(arg1);
        }

        public static int ReturnInstanceInt_System_Int32(IntPtr receiver, IntPtr selector, int arg1)
        {
            return ObjectiveCRuntime.GetInstance<DummyClassStaticInstance>(receiver).ReturnInstanceInt(arg1);
        }

        public static int ReturnStaticInt_System_Int32(IntPtr receiver, IntPtr selector, int arg1)
        {
            return DummyClassStaticInstance.ReturnStaticInt(arg1);
        }

        public delegate void MethodInstanceInt_System_Int32_Invoker(IntPtr receiver, IntPtr selector, int arg1);

        public delegate void MethodStaticInt_System_Int32_Invoker(IntPtr receiver, IntPtr selector, int arg1);

        public delegate int ReturnInstanceInt_System_Int32_Invoker(IntPtr receiver, IntPtr selector, int arg1);

        public delegate int ReturnStaticInt_System_Int32_Invoker(IntPtr receiver, IntPtr selector, int arg1);
    }

    [ObjectiveCClass("DummyClassVariousParameters")]
    public class DummyClassVariousParameters : TSObject
    {
        public DummyClassVariousParameters() {}

        public DummyClassVariousParameters(IntPtr value) : base(value) {}

        [ObjectiveCMessage("methodParameter1")]
        public void MethodParameter1(bool arg1) {}

        [ObjectiveCMessage("methodParameter2")]
        public void MethodParameter2(char arg1, short arg2, int arg3, long arg4) {}

        [ObjectiveCMessage("methodParameter3")]
        public void MethodParameter3(byte arg1, ushort arg2, uint arg3, ulong arg4) {}

        [ObjectiveCMessage("methodParameter4")]
        public void MethodParameter4(IntPtr arg1, Class arg2, Id arg3, String arg4) {}

        [ObjectiveCMessage("methodParameter5")]
        public void MethodParameter5(TSWindingRule arg1) {}

        [ObjectiveCMessage("methodParameter6")]
        public void MethodParameter6(float arg1, double arg2) {}
    }

    public static class DummyClassVariousParameters_Proxy
    {
        public static readonly MethodParameter1_System_Boolean_Invoker MethodParameter1_System_Boolean_Delegate = MethodParameter1_System_Boolean;
        public static readonly MethodParameter2_System_Char_System_Int16_System_Int32_System_Int64_Invoker MethodParameter2_System_Char_System_Int16_System_Int32_System_Int64_Delegate = MethodParameter2_System_Char_System_Int16_System_Int32_System_Int64;

        public static readonly MethodParameter3_System_Byte_System_UInt16_System_UInt32_System_UInt64_Invoker MethodParameter3_System_Byte_System_UInt16_System_UInt32_System_UInt64_Delegate =
            MethodParameter3_System_Byte_System_UInt16_System_UInt32_System_UInt64;

        public static readonly MethodParameter4_System_IntPtr_Monobjc_Class_Monobjc_Id_System_String_Invoker MethodParameter4_System_IntPtr_Monobjc_Class_Monobjc_Id_System_String_Delegate =
            MethodParameter4_System_IntPtr_Monobjc_Class_Monobjc_Id_System_String;

        public static readonly MethodParameter5_Monobjc_Types_TSWindingRule_Invoker MethodParameter5_Monobjc_Types_TSWindingRule_Delegate = MethodParameter5_Monobjc_Types_TSWindingRule;
        public static readonly MethodParameter6_System_Single_System_Double_Invoker MethodParameter6_System_Single_System_Double_Delegate = MethodParameter6_System_Single_System_Double;

        public static void MethodParameter1_System_Boolean(IntPtr receiver, IntPtr selector, bool arg1)
        {
            ObjectiveCRuntime.GetInstance<DummyClassVariousParameters>(receiver).MethodParameter1(arg1);
        }

        public static void MethodParameter2_System_Char_System_Int16_System_Int32_System_Int64(IntPtr receiver, IntPtr selector, char arg1, short arg2, int arg3, long arg4)
        {
            ObjectiveCRuntime.GetInstance<DummyClassVariousParameters>(receiver).MethodParameter2(arg1, arg2, arg3, arg4);
        }

        public static void MethodParameter3_System_Byte_System_UInt16_System_UInt32_System_UInt64(IntPtr receiver, IntPtr selector, byte arg1, ushort arg2, uint arg3, ulong arg4)
        {
            ObjectiveCRuntime.GetInstance<DummyClassVariousParameters>(receiver).MethodParameter3(arg1, arg2, arg3, arg4);
        }

        public static void MethodParameter4_System_IntPtr_Monobjc_Class_Monobjc_Id_System_String(IntPtr receiver, IntPtr selector, IntPtr arg1, IntPtr arg2, IntPtr arg3, string arg4)
        {
            ObjectiveCRuntime.GetInstance<DummyClassVariousParameters>(receiver).MethodParameter4(arg1, ObjectiveCRuntime.GetInstance<Class>(arg2), ObjectiveCRuntime.GetInstance<Id>(arg3), arg4);
        }

        public static void MethodParameter5_Monobjc_Types_TSWindingRule(IntPtr receiver, IntPtr selector, int arg1)
        {
            ObjectiveCRuntime.GetInstance<DummyClassVariousParameters>(receiver).MethodParameter5((TSWindingRule) arg1);
        }

        public static void MethodParameter6_System_Single_System_Double(IntPtr receiver, IntPtr selector, float arg1, double arg2)
        {
            ObjectiveCRuntime.GetInstance<DummyClassVariousParameters>(receiver).MethodParameter6(arg1, arg2);
        }

        public delegate void MethodParameter1_System_Boolean_Invoker(IntPtr receiver, IntPtr selector, bool arg1);

        public delegate void MethodParameter2_System_Char_System_Int16_System_Int32_System_Int64_Invoker(IntPtr receiver, IntPtr selector, char arg1, short arg2, int arg3, long arg4);

        public delegate void MethodParameter3_System_Byte_System_UInt16_System_UInt32_System_UInt64_Invoker(IntPtr receiver, IntPtr selector, byte arg1, ushort arg2, uint arg3, ulong arg4);

        public delegate void MethodParameter4_System_IntPtr_Monobjc_Class_Monobjc_Id_System_String_Invoker(IntPtr receiver, IntPtr selector, IntPtr arg1, IntPtr arg2, IntPtr arg3, string arg4);

        public delegate void MethodParameter5_Monobjc_Types_TSWindingRule_Invoker(IntPtr receiver, IntPtr selector, int arg1);

        public delegate void MethodParameter6_System_Single_System_Double_Invoker(IntPtr receiver, IntPtr selector, float arg1, double arg2);
    }

    [ObjectiveCClass("DummyClassVariousReturns")]
    public class DummyClassVariousReturns : TSObject
    {
        public DummyClassVariousReturns() {}

        public DummyClassVariousReturns(IntPtr value) : base(value) {}

        [ObjectiveCMessage("boolMethod")]
        public bool BoolMethod()
        {
            return false;
        }

        [ObjectiveCMessage("charMethod")]
        public static char CharMethod()
        {
            return 'A';
        }

        [ObjectiveCMessage("shortMethod")]
        public short ShortMethod()
        {
            return 0;
        }

        [ObjectiveCMessage("intMethod")]
        public static int IntMethod()
        {
            return 0;
        }

        [ObjectiveCMessage("longMethod")]
        public long LongMethod()
        {
            return 0;
        }

        [ObjectiveCMessage("byteMethod")]
        public static byte ByteMethod()
        {
            return 0;
        }

        [ObjectiveCMessage("ushortMethod")]
        public ushort UshortMethod()
        {
            return 0;
        }

        [ObjectiveCMessage("uintMethod")]
        public static uint UintMethod()
        {
            return 0;
        }

        [ObjectiveCMessage("ulongMethod")]
        public ulong UlongMethod()
        {
            return 0;
        }

        [ObjectiveCMessage("floatMethod")]
        public static float FloatMethod()
        {
            return 0;
        }

        [ObjectiveCMessage("doubleMethod")]
        public double DoubleMethod()
        {
            return 0;
        }

        [ObjectiveCMessage("pointerMethod")]
        public static IntPtr PointerMethod()
        {
            return IntPtr.Zero;
        }

        [ObjectiveCMessage("classMethod")]
        public Class ClassMethod()
        {
            return null;
        }

        [ObjectiveCMessage("classMethod")]
        public static Id IdMethod()
        {
            return null;
        }

        [ObjectiveCMessage("wrapperMethod")]
        public IManagedWrapper WrapperMethod()
        {
            return null;
        }

        [ObjectiveCMessage("enumMethod")]
        public static TSWindingRule EnumMethod()
        {
            return TSWindingRule.NSEvenOddWindingRule;
        }
    }

    public static class DummyClassVariousReturns_Proxy
    {
        public static readonly BoolMethod_Invoker BoolMethod_Delegate = BoolMethod;
        public static readonly ByteMethod_Invoker ByteMethod_Delegate = ByteMethod;
        public static readonly CharMethod_Invoker CharMethod_Delegate = CharMethod;
        public static readonly ClassMethod_Invoker ClassMethod_Delegate = ClassMethod;
        public static readonly DoubleMethod_Invoker DoubleMethod_Delegate = DoubleMethod;
        public static readonly EnumMethod_Invoker EnumMethod_Delegate = EnumMethod;
        public static readonly FloatMethod_Invoker FloatMethod_Delegate = FloatMethod;
        public static readonly IdMethod_Invoker IdMethod_Delegate = IdMethod;
        public static readonly IntMethod_Invoker IntMethod_Delegate = IntMethod;
        public static readonly LongMethod_Invoker LongMethod_Delegate = LongMethod;
        public static readonly PointerMethod_Invoker PointerMethod_Delegate = PointerMethod;
        public static readonly ShortMethod_Invoker ShortMethod_Delegate = ShortMethod;
        public static readonly UintMethod_Invoker UintMethod_Delegate = UintMethod;
        public static readonly UlongMethod_Invoker UlongMethod_Delegate = UlongMethod;
        public static readonly UshortMethod_Invoker UshortMethod_Delegate = UshortMethod;
        public static readonly WrapperMethod_Invoker WrapperMethod_Delegate = WrapperMethod;

        public static bool BoolMethod(IntPtr receiver, IntPtr selector)
        {
            return ObjectiveCRuntime.GetInstance<DummyClassVariousReturns>(receiver).BoolMethod();
        }

        public static byte ByteMethod(IntPtr receiver, IntPtr selector)
        {
            return DummyClassVariousReturns.ByteMethod();
        }

        public static char CharMethod(IntPtr receiver, IntPtr selector)
        {
            return DummyClassVariousReturns.CharMethod();
        }

        public static IntPtr ClassMethod(IntPtr receiver, IntPtr selector)
        {
            Class class2 = ObjectiveCRuntime.GetInstance<DummyClassVariousReturns>(receiver).ClassMethod();
            return ((class2 == null) ? IntPtr.Zero : class2.NativePointer);
        }

        public static double DoubleMethod(IntPtr receiver, IntPtr selector)
        {
            return ObjectiveCRuntime.GetInstance<DummyClassVariousReturns>(receiver).DoubleMethod();
        }

        public static int EnumMethod(IntPtr receiver, IntPtr selector)
        {
            return (int) DummyClassVariousReturns.EnumMethod();
        }

        public static float FloatMethod(IntPtr receiver, IntPtr selector)
        {
            return DummyClassVariousReturns.FloatMethod();
        }

        public static IntPtr IdMethod(IntPtr receiver, IntPtr selector)
        {
            Id id = DummyClassVariousReturns.IdMethod();
            return ((id == null) ? IntPtr.Zero : id.NativePointer);
        }

        public static int IntMethod(IntPtr receiver, IntPtr selector)
        {
            return DummyClassVariousReturns.IntMethod();
        }

        public static long LongMethod(IntPtr receiver, IntPtr selector)
        {
            return ObjectiveCRuntime.GetInstance<DummyClassVariousReturns>(receiver).LongMethod();
        }

        public static IntPtr PointerMethod(IntPtr receiver, IntPtr selector)
        {
            return DummyClassVariousReturns.PointerMethod();
        }

        public static short ShortMethod(IntPtr receiver, IntPtr selector)
        {
            return ObjectiveCRuntime.GetInstance<DummyClassVariousReturns>(receiver).ShortMethod();
        }

        public static uint UintMethod(IntPtr receiver, IntPtr selector)
        {
            return DummyClassVariousReturns.UintMethod();
        }

        public static ulong UlongMethod(IntPtr receiver, IntPtr selector)
        {
            return ObjectiveCRuntime.GetInstance<DummyClassVariousReturns>(receiver).UlongMethod();
        }

        public static ushort UshortMethod(IntPtr receiver, IntPtr selector)
        {
            return ObjectiveCRuntime.GetInstance<DummyClassVariousReturns>(receiver).UshortMethod();
        }

        public static IntPtr WrapperMethod(IntPtr receiver, IntPtr selector)
        {
            IManagedWrapper wrapper = ObjectiveCRuntime.GetInstance<DummyClassVariousReturns>(receiver).WrapperMethod();
            return ((wrapper == null) ? IntPtr.Zero : wrapper.NativePointer);
        }

        public delegate bool BoolMethod_Invoker(IntPtr receiver, IntPtr selector);

        public delegate byte ByteMethod_Invoker(IntPtr receiver, IntPtr selector);

        public delegate char CharMethod_Invoker(IntPtr receiver, IntPtr selector);

        public delegate IntPtr ClassMethod_Invoker(IntPtr receiver, IntPtr selector);

        public delegate double DoubleMethod_Invoker(IntPtr receiver, IntPtr selector);

        public delegate int EnumMethod_Invoker(IntPtr receiver, IntPtr selector);

        public delegate float FloatMethod_Invoker(IntPtr receiver, IntPtr selector);

        public delegate IntPtr IdMethod_Invoker(IntPtr receiver, IntPtr selector);

        public delegate int IntMethod_Invoker(IntPtr receiver, IntPtr selector);

        public delegate long LongMethod_Invoker(IntPtr receiver, IntPtr selector);

        public delegate IntPtr PointerMethod_Invoker(IntPtr receiver, IntPtr selector);

        public delegate short ShortMethod_Invoker(IntPtr receiver, IntPtr selector);

        public delegate uint UintMethod_Invoker(IntPtr receiver, IntPtr selector);

        public delegate ulong UlongMethod_Invoker(IntPtr receiver, IntPtr selector);

        public delegate ushort UshortMethod_Invoker(IntPtr receiver, IntPtr selector);

        public delegate IntPtr WrapperMethod_Invoker(IntPtr receiver, IntPtr selector);
    }

    [ObjectiveCClass("DummyClassParametersByRef")]
    public class DummyClassParametersByRef : TSObject
    {
        public DummyClassParametersByRef() {}

        public DummyClassParametersByRef(IntPtr value) : base(value) {}

        [ObjectiveCMessage("methodParameter1")]
        public void MethodParameter1(ref bool arg1) {}

        [ObjectiveCMessage("methodParameter2")]
        public int MethodParameter2(ref char arg1, ref short arg2, ref int arg3, ref long arg4)
        {
            return 0;
        }

        [ObjectiveCMessage("methodParameter3")]
        public void MethodParameter3(ref byte arg1, ref ushort arg2, ref uint arg3, ref ulong arg4) {}

        [ObjectiveCMessage("methodParameter4")]
        public int MethodParameter4(ref IntPtr arg1, ref Class arg2, ref Id arg3)
        {
            return 0;
        }

        [ObjectiveCMessage("methodParameter5")]
        public int MethodParameter5(ref TSWindingRule arg1)
        {
            return 0;
        }

        [ObjectiveCMessage("methodParameter6")]
        public int MethodParameter6(ref float arg1, ref double arg2)
        {
            return 0;
        }
    }

    public static class DummyClassParametersByRef_Proxy
    {
        public static readonly MethodParameter1_System_Boolean_Invoker MethodParameter1_System_Boolean_Delegate = MethodParameter1_System_Boolean;
        public static readonly MethodParameter2_System_Char_System_Int16_System_Int32_System_Int64_Invoker MethodParameter2_System_Char_System_Int16_System_Int32_System_Int64_Delegate = MethodParameter2_System_Char_System_Int16_System_Int32_System_Int64;

        public static readonly MethodParameter3_System_Byte_System_UInt16_System_UInt32_System_UInt64_Invoker MethodParameter3_System_Byte_System_UInt16_System_UInt32_System_UInt64_Delegate =
            MethodParameter3_System_Byte_System_UInt16_System_UInt32_System_UInt64;

        public static readonly MethodParameter4_System_IntPtr_Monobjc_Class_Monobjc_Id_Invoker MethodParameter4_System_IntPtr_Monobjc_Class_Monobjc_Id_Delegate = MethodParameter4_System_IntPtr_Monobjc_Class_Monobjc_Id;
        public static readonly MethodParameter5_Monobjc_Types_TSWindingRule_Invoker MethodParameter5_Monobjc_Types_TSWindingRule_Delegate = MethodParameter5_Monobjc_Types_TSWindingRule;
        public static readonly MethodParameter6_System_Single_System_Double_Invoker MethodParameter6_System_Single_System_Double_Delegate = MethodParameter6_System_Single_System_Double;

        public static void MethodParameter1_System_Boolean(IntPtr receiver, IntPtr selector, IntPtr arg1)
        {
            DummyClassParametersByRef instance = ObjectiveCRuntime.GetInstance<DummyClassParametersByRef>(receiver);
            bool flag = Marshal.ReadInt32(arg1) != 0;
            instance.MethodParameter1(ref flag);
            Marshal.WriteInt32(arg1, (flag ? 1 : 0));
        }

        public static int MethodParameter2_System_Char_System_Int16_System_Int32_System_Int64(IntPtr receiver, IntPtr selector, IntPtr arg1, IntPtr arg2, IntPtr arg3, IntPtr arg4)
        {
            DummyClassParametersByRef instance = ObjectiveCRuntime.GetInstance<DummyClassParametersByRef>(receiver);
            char ch = (char) Marshal.ReadInt16(arg1);
            short num2 = Marshal.ReadInt16(arg2);
            int num3 = Marshal.ReadInt32(arg3);
            long num4 = Marshal.ReadInt64(arg4);
            int num = instance.MethodParameter2(ref ch, ref num2, ref num3, ref num4);
            Marshal.WriteInt16(arg1, ch);
            Marshal.WriteInt16(arg2, num2);
            Marshal.WriteInt32(arg3, num3);
            Marshal.WriteInt64(arg4, num4);
            return num;
        }

        public static void MethodParameter3_System_Byte_System_UInt16_System_UInt32_System_UInt64(IntPtr receiver, IntPtr selector, IntPtr arg1, IntPtr arg2, IntPtr arg3, IntPtr arg4)
        {
            DummyClassParametersByRef instance = ObjectiveCRuntime.GetInstance<DummyClassParametersByRef>(receiver);
            byte num = Marshal.ReadByte(arg1);
            ushort num2 = (ushort) Marshal.ReadInt16(arg2);
            uint num3 = (uint) Marshal.ReadInt32(arg3);
            ulong num4 = (ulong) Marshal.ReadInt64(arg4);
            instance.MethodParameter3(ref num, ref num2, ref num3, ref num4);
            Marshal.WriteByte(arg1, num);
            Marshal.WriteInt16(arg2, (short) num2);
            Marshal.WriteInt32(arg3, (int) num3);
            Marshal.WriteInt64(arg4, (long) num4);
        }

        public static int MethodParameter4_System_IntPtr_Monobjc_Class_Monobjc_Id(IntPtr receiver, IntPtr selector, IntPtr arg1, IntPtr arg2, IntPtr arg3)
        {
            DummyClassParametersByRef instance = ObjectiveCRuntime.GetInstance<DummyClassParametersByRef>(receiver);
            IntPtr ptr = Marshal.ReadIntPtr(arg1);
            Class clazz = ObjectiveCRuntime.GetInstance<Class>(Marshal.ReadIntPtr(arg2));
            Id id = ObjectiveCRuntime.GetInstance<Id>(Marshal.ReadIntPtr(arg3));
            int num = instance.MethodParameter4(ref ptr, ref clazz, ref id);
            Marshal.WriteIntPtr(arg1, ptr);
            Marshal.WriteIntPtr(arg2, (clazz == null) ? IntPtr.Zero : clazz.NativePointer);
            Marshal.WriteIntPtr(arg3, (id == null) ? IntPtr.Zero : id.NativePointer);
            return num;
        }

        public static int MethodParameter5_Monobjc_Types_TSWindingRule(IntPtr receiver, IntPtr selector, IntPtr arg1)
        {
            DummyClassParametersByRef instance = ObjectiveCRuntime.GetInstance<DummyClassParametersByRef>(receiver);
            TSWindingRule rule = (TSWindingRule) Marshal.ReadInt32(arg1);
            int num = instance.MethodParameter5(ref rule);
            Marshal.WriteInt32(arg1, (int) rule);
            return num;
        }

        public static int MethodParameter6_System_Single_System_Double(IntPtr receiver, IntPtr selector, IntPtr arg1, IntPtr arg2)
        {
            DummyClassParametersByRef instance = ObjectiveCRuntime.GetInstance<DummyClassParametersByRef>(receiver);
            float num2 = (float) Marshal.PtrToStructure(arg1, typeof (float));
            double num3 = (double) Marshal.PtrToStructure(arg2, typeof (double));
            int num = instance.MethodParameter6(ref num2, ref num3);
            Marshal.StructureToPtr(num2, arg1, false);
            Marshal.StructureToPtr(num3, arg2, false);
            return num;
        }

        public delegate void MethodParameter1_System_Boolean_Invoker(IntPtr receiver, IntPtr selector, IntPtr arg1);

        public delegate int MethodParameter2_System_Char_System_Int16_System_Int32_System_Int64_Invoker(IntPtr receiver, IntPtr selector, IntPtr arg1, IntPtr arg2, IntPtr arg3, IntPtr arg4);

        public delegate void MethodParameter3_System_Byte_System_UInt16_System_UInt32_System_UInt64_Invoker(IntPtr receiver, IntPtr selector, IntPtr arg1, IntPtr arg2, IntPtr arg3, IntPtr arg4);

        public delegate int MethodParameter4_System_IntPtr_Monobjc_Class_Monobjc_Id_Invoker(IntPtr receiver, IntPtr selector, IntPtr arg1, IntPtr arg2, IntPtr arg3);

        public delegate int MethodParameter5_Monobjc_Types_TSWindingRule_Invoker(IntPtr receiver, IntPtr selector, IntPtr arg1);

        public delegate int MethodParameter6_System_Single_System_Double_Invoker(IntPtr receiver, IntPtr selector, IntPtr arg1, IntPtr arg2);
    }

    [ObjectiveCClass("DummyClassParametersOut")]
    public class DummyClassParametersOut : TSObject
    {
        public DummyClassParametersOut() {}

        public DummyClassParametersOut(IntPtr value) : base(value) {}

        [ObjectiveCMessage("methodParameter1")]
        public void MethodParameter1(out bool arg1)
        {
            arg1 = false;
        }

        [ObjectiveCMessage("methodParameter2")]
        public int MethodParameter2(out char arg1, out short arg2, out int arg3, out long arg4)
        {
            arg1 = '1';
            arg2 = 0;
            arg3 = 0;
            arg4 = 0;
            return 0;
        }

        [ObjectiveCMessage("methodParameter3")]
        public void MethodParameter3(out byte arg1, out ushort arg2, out uint arg3, out ulong arg4)
        {
            arg1 = 0;
            arg2 = 0;
            arg3 = 0;
            arg4 = 0;
        }

        [ObjectiveCMessage("methodParameter4")]
        public int MethodParameter4(out IntPtr arg1, out Class arg2, out Id arg3)
        {
            arg1 = IntPtr.Zero;
            arg2 = null;
            arg3 = null;
            return 0;
        }

        [ObjectiveCMessage("methodParameter5")]
        public int MethodParameter5(out TSWindingRule arg1)
        {
            arg1 = TSWindingRule.NSEvenOddWindingRule;
            return 0;
        }

        [ObjectiveCMessage("methodParameter6")]
        public int MethodParameter6(out float arg1, out double arg2)
        {
            arg1 = 0;
            arg2 = 0;
            return 0;
        }
    }

    public static class DummyClassParametersOut_Proxy
    {
        public static readonly MethodParameter1_System_Boolean_Invoker MethodParameter1_System_Boolean_Delegate = MethodParameter1_System_Boolean;
        public static readonly MethodParameter2_System_Char_System_Int16_System_Int32_System_Int64_Invoker MethodParameter2_System_Char_System_Int16_System_Int32_System_Int64_Delegate = MethodParameter2_System_Char_System_Int16_System_Int32_System_Int64;

        public static readonly MethodParameter3_System_Byte_System_UInt16_System_UInt32_System_UInt64_Invoker MethodParameter3_System_Byte_System_UInt16_System_UInt32_System_UInt64_Delegate =
            MethodParameter3_System_Byte_System_UInt16_System_UInt32_System_UInt64;

        public static readonly MethodParameter4_System_IntPtr_Monobjc_Class_Monobjc_Id_Invoker MethodParameter4_System_IntPtr_Monobjc_Class_Monobjc_Id_Delegate = MethodParameter4_System_IntPtr_Monobjc_Class_Monobjc_Id;
        public static readonly MethodParameter5_Monobjc_Types_TSWindingRule_Invoker MethodParameter5_Monobjc_Types_TSWindingRule_Delegate = MethodParameter5_Monobjc_Types_TSWindingRule;
        public static readonly MethodParameter6_System_Single_System_Double_Invoker MethodParameter6_System_Single_System_Double_Delegate = MethodParameter6_System_Single_System_Double;

        public static void MethodParameter1_System_Boolean(IntPtr receiver, IntPtr selector, IntPtr arg1)
        {
            bool flag;
            ObjectiveCRuntime.GetInstance<DummyClassParametersOut>(receiver).MethodParameter1(out flag);
            Marshal.WriteInt32(arg1, (flag ? 1 : 0));
        }

        public static int MethodParameter2_System_Char_System_Int16_System_Int32_System_Int64(IntPtr receiver, IntPtr selector, IntPtr arg1, IntPtr arg2, IntPtr arg3, IntPtr arg4)
        {
            char ch;
            short num2;
            int num3;
            long num4;
            int num = ObjectiveCRuntime.GetInstance<DummyClassParametersOut>(receiver).MethodParameter2(out ch, out num2, out num3, out num4);
            Marshal.WriteInt16(arg1, ch);
            Marshal.WriteInt16(arg2, num2);
            Marshal.WriteInt32(arg3, num3);
            Marshal.WriteInt64(arg4, num4);
            return num;
        }

        public static void MethodParameter3_System_Byte_System_UInt16_System_UInt32_System_UInt64(IntPtr receiver, IntPtr selector, IntPtr arg1, IntPtr arg2, IntPtr arg3, IntPtr arg4)
        {
            byte num;
            ushort num2;
            uint num3;
            ulong num4;
            ObjectiveCRuntime.GetInstance<DummyClassParametersOut>(receiver).MethodParameter3(out num, out num2, out num3, out num4);
            Marshal.WriteByte(arg1, num);
            Marshal.WriteInt16(arg2, (short) num2);
            Marshal.WriteInt32(arg3, (int) num3);
            Marshal.WriteInt64(arg4, (long) num4);
        }

        public static int MethodParameter4_System_IntPtr_Monobjc_Class_Monobjc_Id(IntPtr receiver, IntPtr selector, IntPtr arg1, IntPtr arg2, IntPtr arg3)
        {
            IntPtr ptr;
            Class class2;
            Id id;
            int num = ObjectiveCRuntime.GetInstance<DummyClassParametersOut>(receiver).MethodParameter4(out ptr, out class2, out id);
            Marshal.WriteIntPtr(arg1, ptr);
            Marshal.WriteIntPtr(arg2, (class2 == null) ? IntPtr.Zero : class2.NativePointer);
            Marshal.WriteIntPtr(arg3, (id == null) ? IntPtr.Zero : id.NativePointer);
            return num;
        }

        public static int MethodParameter5_Monobjc_Types_TSWindingRule(IntPtr receiver, IntPtr selector, IntPtr arg1)
        {
            TSWindingRule rule;
            int num = ObjectiveCRuntime.GetInstance<DummyClassParametersOut>(receiver).MethodParameter5(out rule);
            Marshal.WriteInt32(arg1, (int) rule);
            return num;
        }

        public static int MethodParameter6_System_Single_System_Double(IntPtr receiver, IntPtr selector, IntPtr arg1, IntPtr arg2)
        {
            float num2;
            double num3;
            int num = ObjectiveCRuntime.GetInstance<DummyClassParametersOut>(receiver).MethodParameter6(out num2, out num3);
            Marshal.StructureToPtr(num2, arg1, false);
            Marshal.StructureToPtr(num3, arg2, false);
            return num;
        }

        public delegate void MethodParameter1_System_Boolean_Invoker(IntPtr receiver, IntPtr selector, IntPtr arg1);

        public delegate int MethodParameter2_System_Char_System_Int16_System_Int32_System_Int64_Invoker(IntPtr receiver, IntPtr selector, IntPtr arg1, IntPtr arg2, IntPtr arg3, IntPtr arg4);

        public delegate void MethodParameter3_System_Byte_System_UInt16_System_UInt32_System_UInt64_Invoker(IntPtr receiver, IntPtr selector, IntPtr arg1, IntPtr arg2, IntPtr arg3, IntPtr arg4);

        public delegate int MethodParameter4_System_IntPtr_Monobjc_Class_Monobjc_Id_Invoker(IntPtr receiver, IntPtr selector, IntPtr arg1, IntPtr arg2, IntPtr arg3);

        public delegate int MethodParameter5_Monobjc_Types_TSWindingRule_Invoker(IntPtr receiver, IntPtr selector, IntPtr arg1);

        public delegate int MethodParameter6_System_Single_System_Double_Invoker(IntPtr receiver, IntPtr selector, IntPtr arg1, IntPtr arg2);
    }

    [ObjectiveCClass("DummyClassVariousParametersVariableTypes")]
    public class DummyClassVariousParametersVariableTypes : TSObject
    {
        public DummyClassVariousParametersVariableTypes() {}

        public DummyClassVariousParametersVariableTypes(IntPtr value) : base(value) {}

        [ObjectiveCMessage("methodParameter1")]
        public void MethodParameter1(TSIntegerEnumeration arg1, TSUIntegerEnumeration arg2) {}

        [ObjectiveCMessage("methodParameter2")]
        public static void MethodParameter2(TSInteger arg1, TSUInteger arg2, TSFloat arg3) {}

        [ObjectiveCMessage("methodParameter3")]
        public void MethodParameter3(TSRange arg1) {}

        [ObjectiveCMessage("methodParameter4")]
        public static void MethodParameter4(TSPoint arg1, TSSize arg2, TSRect arg3) {}
    }

    public static class DummyClassVariousParametersVariableTypes32Bits_Proxy
    {
        public static readonly MethodParameter1_Monobjc_Types_TSIntegerEnumeration_Monobjc_Types_TSUIntegerEnumeration_Invoker MethodParameter1_Monobjc_Types_TSIntegerEnumeration_Monobjc_Types_TSUIntegerEnumeration_Delegate =
            MethodParameter1_Monobjc_Types_TSIntegerEnumeration_Monobjc_Types_TSUIntegerEnumeration;

        public static readonly MethodParameter2_Monobjc_Types_TSInteger_Monobjc_Types_TSUInteger_Monobjc_Types_TSFloat_Invoker MethodParameter2_Monobjc_Types_TSInteger_Monobjc_Types_TSUInteger_Monobjc_Types_TSFloat_Delegate =
            MethodParameter2_Monobjc_Types_TSInteger_Monobjc_Types_TSUInteger_Monobjc_Types_TSFloat;

        public static readonly MethodParameter3_Monobjc_Types_TSRange_Invoker MethodParameter3_Monobjc_Types_TSRange_Delegate = MethodParameter3_Monobjc_Types_TSRange;

        public static readonly MethodParameter4_Monobjc_Types_TSPoint_Monobjc_Types_TSSize_Monobjc_Types_TSRect_Invoker MethodParameter4_Monobjc_Types_TSPoint_Monobjc_Types_TSSize_Monobjc_Types_TSRect_Delegate =
            MethodParameter4_Monobjc_Types_TSPoint_Monobjc_Types_TSSize_Monobjc_Types_TSRect;

        public static void MethodParameter1_Monobjc_Types_TSIntegerEnumeration_Monobjc_Types_TSUIntegerEnumeration(IntPtr receiver, IntPtr selector, int arg1, uint arg2)
        {
            ObjectiveCRuntime.GetInstance<DummyClassVariousParametersVariableTypes>(receiver).MethodParameter1((TSIntegerEnumeration) arg1, (TSUIntegerEnumeration) arg2);
        }

        public static void MethodParameter2_Monobjc_Types_TSInteger_Monobjc_Types_TSUInteger_Monobjc_Types_TSFloat(IntPtr receiver, IntPtr selector, int arg1, uint arg2, float arg3)
        {
            DummyClassVariousParametersVariableTypes.MethodParameter2(arg1, arg2, arg3);
        }

        public static void MethodParameter3_Monobjc_Types_TSRange(IntPtr receiver, IntPtr selector, TSRange arg1)
        {
            ObjectiveCRuntime.GetInstance<DummyClassVariousParametersVariableTypes>(receiver).MethodParameter3(arg1);
        }

        public static void MethodParameter4_Monobjc_Types_TSPoint_Monobjc_Types_TSSize_Monobjc_Types_TSRect(IntPtr receiver, IntPtr selector, TSPoint arg1, TSSize arg2, TSRect arg3)
        {
            DummyClassVariousParametersVariableTypes.MethodParameter4(arg1, arg2, arg3);
        }

        public delegate void MethodParameter1_Monobjc_Types_TSIntegerEnumeration_Monobjc_Types_TSUIntegerEnumeration_Invoker(IntPtr receiver, IntPtr selector, int arg1, uint arg2);

        public delegate void MethodParameter2_Monobjc_Types_TSInteger_Monobjc_Types_TSUInteger_Monobjc_Types_TSFloat_Invoker(IntPtr receiver, IntPtr selector, int arg1, uint arg2, float arg3);

        public delegate void MethodParameter3_Monobjc_Types_TSRange_Invoker(IntPtr receiver, IntPtr selector, TSRange arg1);

        public delegate void MethodParameter4_Monobjc_Types_TSPoint_Monobjc_Types_TSSize_Monobjc_Types_TSRect_Invoker(IntPtr receiver, IntPtr selector, TSPoint arg1, TSSize arg2, TSRect arg3);
    }

    public static class DummyClassVariousParametersVariableTypes64Bits_Proxy
    {
        public static readonly MethodParameter1_Monobjc_Types_TSIntegerEnumeration_Monobjc_Types_TSUIntegerEnumeration_Invoker MethodParameter1_Monobjc_Types_TSIntegerEnumeration_Monobjc_Types_TSUIntegerEnumeration_Delegate =
            MethodParameter1_Monobjc_Types_TSIntegerEnumeration_Monobjc_Types_TSUIntegerEnumeration;

        public static readonly MethodParameter2_Monobjc_Types_TSInteger_Monobjc_Types_TSUInteger_Monobjc_Types_TSFloat_Invoker MethodParameter2_Monobjc_Types_TSInteger_Monobjc_Types_TSUInteger_Monobjc_Types_TSFloat_Delegate =
            MethodParameter2_Monobjc_Types_TSInteger_Monobjc_Types_TSUInteger_Monobjc_Types_TSFloat;

        public static readonly MethodParameter3_Monobjc_Types_TSRange_Invoker MethodParameter3_Monobjc_Types_TSRange_Delegate = MethodParameter3_Monobjc_Types_TSRange;

        public static readonly MethodParameter4_Monobjc_Types_TSPoint_Monobjc_Types_TSSize_Monobjc_Types_TSRect_Invoker MethodParameter4_Monobjc_Types_TSPoint_Monobjc_Types_TSSize_Monobjc_Types_TSRect_Delegate =
            MethodParameter4_Monobjc_Types_TSPoint_Monobjc_Types_TSSize_Monobjc_Types_TSRect;

        public static void MethodParameter1_Monobjc_Types_TSIntegerEnumeration_Monobjc_Types_TSUIntegerEnumeration(IntPtr receiver, IntPtr selector, long arg1, ulong arg2)
        {
            ObjectiveCRuntime.GetInstance<DummyClassVariousParametersVariableTypes>(receiver).MethodParameter1((TSIntegerEnumeration) arg1, (TSUIntegerEnumeration) arg2);
        }

        public static void MethodParameter2_Monobjc_Types_TSInteger_Monobjc_Types_TSUInteger_Monobjc_Types_TSFloat(IntPtr receiver, IntPtr selector, long arg1, ulong arg2, double arg3)
        {
            DummyClassVariousParametersVariableTypes.MethodParameter2(arg1, arg2, arg3);
        }

        public static void MethodParameter3_Monobjc_Types_TSRange(IntPtr receiver, IntPtr selector, TSRange64 arg1)
        {
            ObjectiveCRuntime.GetInstance<DummyClassVariousParametersVariableTypes>(receiver).MethodParameter3(arg1);
        }

        public static void MethodParameter4_Monobjc_Types_TSPoint_Monobjc_Types_TSSize_Monobjc_Types_TSRect(IntPtr receiver, IntPtr selector, TSPoint64 arg1, TSSize64 arg2, TSRect64 arg3)
        {
            DummyClassVariousParametersVariableTypes.MethodParameter4(arg1, arg2, arg3);
        }

        public delegate void MethodParameter1_Monobjc_Types_TSIntegerEnumeration_Monobjc_Types_TSUIntegerEnumeration_Invoker(IntPtr receiver, IntPtr selector, long arg1, ulong arg2);

        public delegate void MethodParameter2_Monobjc_Types_TSInteger_Monobjc_Types_TSUInteger_Monobjc_Types_TSFloat_Invoker(IntPtr receiver, IntPtr selector, long arg1, ulong arg2, double arg3);

        public delegate void MethodParameter3_Monobjc_Types_TSRange_Invoker(IntPtr receiver, IntPtr selector, TSRange64 arg1);

        public delegate void MethodParameter4_Monobjc_Types_TSPoint_Monobjc_Types_TSSize_Monobjc_Types_TSRect_Invoker(IntPtr receiver, IntPtr selector, TSPoint64 arg1, TSSize64 arg2, TSRect64 arg3);
    }

    [ObjectiveCClass("DummyClassVariousParametersVariableTypes")]
    public class DummyClassVariousReturnsVariableTypes : TSObject
    {
        public DummyClassVariousReturnsVariableTypes() {}

        public DummyClassVariousReturnsVariableTypes(IntPtr value) : base(value) {}

        [ObjectiveCMessage("signedEnumerationMethod")]
        public static TSIntegerEnumeration WindingEnumerationMethod()
        {
            return TSIntegerEnumeration.NSEvenOddWindingRule;
        }

        [ObjectiveCMessage("unsignedEnumerationMethod")]
        public static TSUIntegerEnumeration UnsignedEnumerationMethod()
        {
            return TSUIntegerEnumeration.NSEvenOddWindingRule;
        }

        [ObjectiveCMessage("integerMethod")]
        public static TSInteger IntegerMethod()
        {
            return 0;
        }

        [ObjectiveCMessage("uintegerMethod")]
        public static TSUInteger UIntegerMethod()
        {
            return 0;
        }

        [ObjectiveCMessage("floatMethod")]
        public static TSFloat FloatMethod()
        {
            return 0;
        }

        [ObjectiveCMessage("rangeMethod")]
        public static TSRange RangeMethod()
        {
            return new TSRange();
        }

        [ObjectiveCMessage("pointMethod")]
        public static TSPoint PointMethod()
        {
            return new TSPoint();
        }

        [ObjectiveCMessage("rectMethod")]
        public static TSRect RectMethod()
        {
            return new TSRect();
        }
    }

    public static class DummyClassVariousReturnsVariableTypes32Bits_Proxy
    {
        public static readonly FloatMethod_Invoker FloatMethod_Delegate = FloatMethod;
        public static readonly IntegerMethod_Invoker IntegerMethod_Delegate = IntegerMethod;
        public static readonly PointMethod_Invoker PointMethod_Delegate = PointMethod;
        public static readonly RangeMethod_Invoker RangeMethod_Delegate = RangeMethod;
        public static readonly RectMethod_Invoker RectMethod_Delegate = RectMethod;
        public static readonly UIntegerMethod_Invoker UIntegerMethod_Delegate = UIntegerMethod;
        public static readonly UnsignedEnumerationMethod_Invoker UnsignedEnumerationMethod_Delegate = UnsignedEnumerationMethod;
        public static readonly WindingEnumerationMethod_Invoker WindingEnumerationMethod_Delegate = WindingEnumerationMethod;

        public static float FloatMethod(IntPtr receiver, IntPtr selector)
        {
            return DummyClassVariousReturnsVariableTypes.FloatMethod();
        }

        public static int IntegerMethod(IntPtr receiver, IntPtr selector)
        {
            return DummyClassVariousReturnsVariableTypes.IntegerMethod();
        }

        public static TSPoint PointMethod(IntPtr receiver, IntPtr selector)
        {
            return DummyClassVariousReturnsVariableTypes.PointMethod();
        }

        public static TSRange RangeMethod(IntPtr receiver, IntPtr selector)
        {
            return DummyClassVariousReturnsVariableTypes.RangeMethod();
        }

        public static TSRect RectMethod(IntPtr receiver, IntPtr selector)
        {
            return DummyClassVariousReturnsVariableTypes.RectMethod();
        }

        public static uint UIntegerMethod(IntPtr receiver, IntPtr selector)
        {
            return DummyClassVariousReturnsVariableTypes.UIntegerMethod();
        }

        public static uint UnsignedEnumerationMethod(IntPtr receiver, IntPtr selector)
        {
            return (uint) DummyClassVariousReturnsVariableTypes.UnsignedEnumerationMethod();
        }

        public static int WindingEnumerationMethod(IntPtr receiver, IntPtr selector)
        {
            return (int) DummyClassVariousReturnsVariableTypes.WindingEnumerationMethod();
        }

        public delegate float FloatMethod_Invoker(IntPtr receiver, IntPtr selector);

        public delegate int IntegerMethod_Invoker(IntPtr receiver, IntPtr selector);

        public delegate TSPoint PointMethod_Invoker(IntPtr receiver, IntPtr selector);

        public delegate TSRange RangeMethod_Invoker(IntPtr receiver, IntPtr selector);

        public delegate TSRect RectMethod_Invoker(IntPtr receiver, IntPtr selector);

        public delegate uint UIntegerMethod_Invoker(IntPtr receiver, IntPtr selector);

        public delegate uint UnsignedEnumerationMethod_Invoker(IntPtr receiver, IntPtr selector);

        public delegate int WindingEnumerationMethod_Invoker(IntPtr receiver, IntPtr selector);
    }

    public static class DummyClassVariousReturnsVariableTypes64Bits_Proxy
    {
        public static readonly FloatMethod_Invoker FloatMethod_Delegate = FloatMethod;
        public static readonly IntegerMethod_Invoker IntegerMethod_Delegate = IntegerMethod;
        public static readonly PointMethod_Invoker PointMethod_Delegate = PointMethod;
        public static readonly RangeMethod_Invoker RangeMethod_Delegate = RangeMethod;
        public static readonly RectMethod_Invoker RectMethod_Delegate = RectMethod;
        public static readonly UIntegerMethod_Invoker UIntegerMethod_Delegate = UIntegerMethod;
        public static readonly UnsignedEnumerationMethod_Invoker UnsignedEnumerationMethod_Delegate = UnsignedEnumerationMethod;
        public static readonly WindingEnumerationMethod_Invoker WindingEnumerationMethod_Delegate = WindingEnumerationMethod;

        public static double FloatMethod(IntPtr receiver, IntPtr selector)
        {
            return DummyClassVariousReturnsVariableTypes.FloatMethod();
        }

        public static long IntegerMethod(IntPtr receiver, IntPtr selector)
        {
            return DummyClassVariousReturnsVariableTypes.IntegerMethod();
        }

        public static TSPoint64 PointMethod(IntPtr receiver, IntPtr selector)
        {
            return DummyClassVariousReturnsVariableTypes.PointMethod();
        }

        public static TSRange64 RangeMethod(IntPtr receiver, IntPtr selector)
        {
            return DummyClassVariousReturnsVariableTypes.RangeMethod();
        }

        public static TSRect64 RectMethod(IntPtr receiver, IntPtr selector)
        {
            return DummyClassVariousReturnsVariableTypes.RectMethod();
        }

        public static ulong UIntegerMethod(IntPtr receiver, IntPtr selector)
        {
            return DummyClassVariousReturnsVariableTypes.UIntegerMethod();
        }

        public static ulong UnsignedEnumerationMethod(IntPtr receiver, IntPtr selector)
        {
            return (ulong) DummyClassVariousReturnsVariableTypes.UnsignedEnumerationMethod();
        }

        public static long WindingEnumerationMethod(IntPtr receiver, IntPtr selector)
        {
            return (long) DummyClassVariousReturnsVariableTypes.WindingEnumerationMethod();
        }

        public delegate double FloatMethod_Invoker(IntPtr receiver, IntPtr selector);

        public delegate long IntegerMethod_Invoker(IntPtr receiver, IntPtr selector);

        public delegate TSPoint64 PointMethod_Invoker(IntPtr receiver, IntPtr selector);

        public delegate TSRange64 RangeMethod_Invoker(IntPtr receiver, IntPtr selector);

        public delegate TSRect64 RectMethod_Invoker(IntPtr receiver, IntPtr selector);

        public delegate ulong UIntegerMethod_Invoker(IntPtr receiver, IntPtr selector);

        public delegate ulong UnsignedEnumerationMethod_Invoker(IntPtr receiver, IntPtr selector);

        public delegate long WindingEnumerationMethod_Invoker(IntPtr receiver, IntPtr selector);
    }

    [ObjectiveCClass("DummyClassParametersByRefVariableTypes")]
    public class DummyClassParametersByRefVariableTypes : TSObject
    {
        public DummyClassParametersByRefVariableTypes() {}

        public DummyClassParametersByRefVariableTypes(IntPtr value) : base(value) {}

        [ObjectiveCMessage("methodParameter1")]
        public void MethodParameter1(ref TSIntegerEnumeration arg1, ref TSUIntegerEnumeration arg2) {}

        [ObjectiveCMessage("methodParameter2")]
        public static void MethodParameter2(ref TSInteger arg1, ref TSUInteger arg2, ref TSFloat arg3) {}

        [ObjectiveCMessage("methodParameter3")]
        public void MethodParameter3(ref TSRange arg1) {}

        [ObjectiveCMessage("methodParameter4")]
        public static void MethodParameter4(ref TSPoint arg1, ref TSSize arg2, ref TSRect arg3) {}
    }

    public static class DummyClassParametersByRefVariableTypes32Bits_Proxy
    {
        public static readonly MethodParameter1_Monobjc_Types_TSIntegerEnumeration_Monobjc_Types_TSUIntegerEnumeration_Invoker MethodParameter1_Monobjc_Types_TSIntegerEnumeration_Monobjc_Types_TSUIntegerEnumeration_Delegate =
            MethodParameter1_Monobjc_Types_TSIntegerEnumeration_Monobjc_Types_TSUIntegerEnumeration;

        public static readonly MethodParameter2_Monobjc_Types_TSInteger_Monobjc_Types_TSUInteger_Monobjc_Types_TSFloat_Invoker MethodParameter2_Monobjc_Types_TSInteger_Monobjc_Types_TSUInteger_Monobjc_Types_TSFloat_Delegate =
            MethodParameter2_Monobjc_Types_TSInteger_Monobjc_Types_TSUInteger_Monobjc_Types_TSFloat;

        public static readonly MethodParameter3_Monobjc_Types_TSRange_Invoker MethodParameter3_Monobjc_Types_TSRange_Delegate = MethodParameter3_Monobjc_Types_TSRange;

        public static readonly MethodParameter4_Monobjc_Types_TSPoint_Monobjc_Types_TSSize_Monobjc_Types_TSRect_Invoker MethodParameter4_Monobjc_Types_TSPoint_Monobjc_Types_TSSize_Monobjc_Types_TSRect_Delegate =
            MethodParameter4_Monobjc_Types_TSPoint_Monobjc_Types_TSSize_Monobjc_Types_TSRect;

        public static void MethodParameter1_Monobjc_Types_TSIntegerEnumeration_Monobjc_Types_TSUIntegerEnumeration(IntPtr receiver, IntPtr selector, IntPtr arg1, IntPtr arg2)
        {
            DummyClassParametersByRefVariableTypes instance = ObjectiveCRuntime.GetInstance<DummyClassParametersByRefVariableTypes>(receiver);
            TSIntegerEnumeration enumeration = (TSIntegerEnumeration) Marshal.ReadInt32(arg1);
            TSUIntegerEnumeration enumeration2 = (TSUIntegerEnumeration) (uint) Marshal.ReadInt32(arg2);
            instance.MethodParameter1(ref enumeration, ref enumeration2);
            Marshal.WriteInt32(arg1, (int) enumeration);
            Marshal.WriteInt32(arg2, (int) (uint) enumeration2);
        }

        public static void MethodParameter2_Monobjc_Types_TSInteger_Monobjc_Types_TSUInteger_Monobjc_Types_TSFloat(IntPtr receiver, IntPtr selector, IntPtr arg1, IntPtr arg2, IntPtr arg3)
        {
            TSInteger integer = Marshal.ReadInt32(arg1);
            TSUInteger integer2 = (uint) Marshal.ReadInt32(arg2);
            TSFloat num = (float) Marshal.PtrToStructure(arg3, typeof (float));
            DummyClassParametersByRefVariableTypes.MethodParameter2(ref integer, ref integer2, ref num);
            Marshal.WriteInt32(arg1, integer);
            Marshal.WriteInt32(arg2, (int) (uint) integer2);
            Marshal.StructureToPtr((float) num, arg3, false);
        }

        public static void MethodParameter3_Monobjc_Types_TSRange(IntPtr receiver, IntPtr selector, IntPtr arg1)
        {
            DummyClassParametersByRefVariableTypes instance = ObjectiveCRuntime.GetInstance<DummyClassParametersByRefVariableTypes>(receiver);
            TSRange range = (TSRange) Marshal.PtrToStructure(arg1, typeof (TSRange));
            instance.MethodParameter3(ref range);
            Marshal.StructureToPtr(range, arg1, false);
        }

        public static void MethodParameter4_Monobjc_Types_TSPoint_Monobjc_Types_TSSize_Monobjc_Types_TSRect(IntPtr receiver, IntPtr selector, IntPtr arg1, IntPtr arg2, IntPtr arg3)
        {
            TSPoint point = (TSPoint) Marshal.PtrToStructure(arg1, typeof (TSPoint));
            TSSize size = (TSSize) Marshal.PtrToStructure(arg2, typeof (TSSize));
            TSRect rect = (TSRect) Marshal.PtrToStructure(arg3, typeof (TSRect));
            DummyClassParametersByRefVariableTypes.MethodParameter4(ref point, ref size, ref rect);
            Marshal.StructureToPtr(point, arg1, false);
            Marshal.StructureToPtr(size, arg2, false);
            Marshal.StructureToPtr(rect, arg3, false);
        }

        public delegate void MethodParameter1_Monobjc_Types_TSIntegerEnumeration_Monobjc_Types_TSUIntegerEnumeration_Invoker(IntPtr receiver, IntPtr selector, IntPtr arg1, IntPtr arg2);

        public delegate void MethodParameter2_Monobjc_Types_TSInteger_Monobjc_Types_TSUInteger_Monobjc_Types_TSFloat_Invoker(IntPtr receiver, IntPtr selector, IntPtr arg1, IntPtr arg2, IntPtr arg3);

        public delegate void MethodParameter3_Monobjc_Types_TSRange_Invoker(IntPtr receiver, IntPtr selector, IntPtr arg1);

        public delegate void MethodParameter4_Monobjc_Types_TSPoint_Monobjc_Types_TSSize_Monobjc_Types_TSRect_Invoker(IntPtr receiver, IntPtr selector, IntPtr arg1, IntPtr arg2, IntPtr arg3);
    }

    public static class DummyClassParametersByRefVariableTypes64Bits_Proxy
    {
        public static readonly MethodParameter1_Monobjc_Types_TSIntegerEnumeration_Monobjc_Types_TSUIntegerEnumeration_Invoker MethodParameter1_Monobjc_Types_TSIntegerEnumeration_Monobjc_Types_TSUIntegerEnumeration_Delegate =
            MethodParameter1_Monobjc_Types_TSIntegerEnumeration_Monobjc_Types_TSUIntegerEnumeration;

        public static readonly MethodParameter2_Monobjc_Types_TSInteger_Monobjc_Types_TSUInteger_Monobjc_Types_TSFloat_Invoker MethodParameter2_Monobjc_Types_TSInteger_Monobjc_Types_TSUInteger_Monobjc_Types_TSFloat_Delegate =
            MethodParameter2_Monobjc_Types_TSInteger_Monobjc_Types_TSUInteger_Monobjc_Types_TSFloat;

        public static readonly MethodParameter3_Monobjc_Types_TSRange_Invoker MethodParameter3_Monobjc_Types_TSRange_Delegate = MethodParameter3_Monobjc_Types_TSRange;

        public static readonly MethodParameter4_Monobjc_Types_TSPoint_Monobjc_Types_TSSize_Monobjc_Types_TSRect_Invoker MethodParameter4_Monobjc_Types_TSPoint_Monobjc_Types_TSSize_Monobjc_Types_TSRect_Delegate =
            MethodParameter4_Monobjc_Types_TSPoint_Monobjc_Types_TSSize_Monobjc_Types_TSRect;

        public static void MethodParameter1_Monobjc_Types_TSIntegerEnumeration_Monobjc_Types_TSUIntegerEnumeration(IntPtr receiver, IntPtr selector, IntPtr arg1, IntPtr arg2)
        {
            DummyClassParametersByRefVariableTypes instance = ObjectiveCRuntime.GetInstance<DummyClassParametersByRefVariableTypes>(receiver);
            TSIntegerEnumeration enumeration = (TSIntegerEnumeration) Marshal.ReadInt64(arg1);
            TSUIntegerEnumeration enumeration2 = (TSUIntegerEnumeration) (ulong) Marshal.ReadInt64(arg2);
            instance.MethodParameter1(ref enumeration, ref enumeration2);
            Marshal.WriteInt64(arg1, (long) enumeration);
            Marshal.WriteInt64(arg2, (long) (ulong) enumeration2);
        }

        public static void MethodParameter2_Monobjc_Types_TSInteger_Monobjc_Types_TSUInteger_Monobjc_Types_TSFloat(IntPtr receiver, IntPtr selector, IntPtr arg1, IntPtr arg2, IntPtr arg3)
        {
            TSInteger integer = Marshal.ReadInt64(arg1);
            TSUInteger integer2 = (ulong) Marshal.ReadInt64(arg2);
            TSFloat num = (double) Marshal.PtrToStructure(arg3, typeof (double));
            DummyClassParametersByRefVariableTypes.MethodParameter2(ref integer, ref integer2, ref num);
            Marshal.WriteInt64(arg1, integer);
            Marshal.WriteInt64(arg2, (long) (ulong) integer2);
            Marshal.StructureToPtr((double) num, arg3, false);
        }

        public static void MethodParameter3_Monobjc_Types_TSRange(IntPtr receiver, IntPtr selector, IntPtr arg1)
        {
            DummyClassParametersByRefVariableTypes instance = ObjectiveCRuntime.GetInstance<DummyClassParametersByRefVariableTypes>(receiver);
            TSRange range = (TSRange64) Marshal.PtrToStructure(arg1, typeof (TSRange64));
            instance.MethodParameter3(ref range);
            Marshal.StructureToPtr((TSRange64) range, arg1, false);
        }

        public static void MethodParameter4_Monobjc_Types_TSPoint_Monobjc_Types_TSSize_Monobjc_Types_TSRect(IntPtr receiver, IntPtr selector, IntPtr arg1, IntPtr arg2, IntPtr arg3)
        {
            TSPoint point = (TSPoint64) Marshal.PtrToStructure(arg1, typeof (TSPoint64));
            TSSize size = (TSSize64) Marshal.PtrToStructure(arg2, typeof (TSSize64));
            TSRect rect = (TSRect64) Marshal.PtrToStructure(arg3, typeof (TSRect64));
            DummyClassParametersByRefVariableTypes.MethodParameter4(ref point, ref size, ref rect);
            Marshal.StructureToPtr((TSPoint64) point, arg1, false);
            Marshal.StructureToPtr((TSSize64) size, arg2, false);
            Marshal.StructureToPtr((TSRect64) rect, arg3, false);
        }

        public delegate void MethodParameter1_Monobjc_Types_TSIntegerEnumeration_Monobjc_Types_TSUIntegerEnumeration_Invoker(IntPtr receiver, IntPtr selector, IntPtr arg1, IntPtr arg2);

        public delegate void MethodParameter2_Monobjc_Types_TSInteger_Monobjc_Types_TSUInteger_Monobjc_Types_TSFloat_Invoker(IntPtr receiver, IntPtr selector, IntPtr arg1, IntPtr arg2, IntPtr arg3);

        public delegate void MethodParameter3_Monobjc_Types_TSRange_Invoker(IntPtr receiver, IntPtr selector, IntPtr arg1);

        public delegate void MethodParameter4_Monobjc_Types_TSPoint_Monobjc_Types_TSSize_Monobjc_Types_TSRect_Invoker(IntPtr receiver, IntPtr selector, IntPtr arg1, IntPtr arg2, IntPtr arg3);
    }

    [ObjectiveCClass("DummyClassParametersOutVariableTypes")]
    public class DummyClassParametersOutVariableTypes : TSObject
    {
        public DummyClassParametersOutVariableTypes() {}

        public DummyClassParametersOutVariableTypes(IntPtr value) : base(value) {}

        [ObjectiveCMessage("methodParameter1")]
        public void MethodParameter1(out TSIntegerEnumeration arg1, out TSUIntegerEnumeration arg2)
        {
            arg1 = TSIntegerEnumeration.NSEvenOddWindingRule;
            arg2 = TSUIntegerEnumeration.NSEvenOddWindingRule;
        }

        [ObjectiveCMessage("methodParameter2")]
        public static void MethodParameter2(out TSInteger arg1, out TSUInteger arg2, out TSFloat arg3)
        {
            arg1 = 0;
            arg2 = 0;
            arg3 = 0;
        }

        [ObjectiveCMessage("methodParameter3")]
        public void MethodParameter3(out TSRange arg1)
        {
            arg1 = new TSRange();
        }

        [ObjectiveCMessage("methodParameter4")]
        public static void MethodParameter4(out TSPoint arg1, out TSSize arg2, out TSRect arg3)
        {
            arg1 = new TSPoint();
            arg2 = new TSSize();
            arg3 = new TSRect();
        }
    }

    public static class DummyClassParametersOutVariableTypes32Bits_Proxy
    {
        public static readonly MethodParameter1_Monobjc_Types_TSIntegerEnumeration_Monobjc_Types_TSUIntegerEnumeration_Invoker MethodParameter1_Monobjc_Types_TSIntegerEnumeration_Monobjc_Types_TSUIntegerEnumeration_Delegate =
            MethodParameter1_Monobjc_Types_TSIntegerEnumeration_Monobjc_Types_TSUIntegerEnumeration;

        public static readonly MethodParameter2_Monobjc_Types_TSInteger_Monobjc_Types_TSUInteger_Monobjc_Types_TSFloat_Invoker MethodParameter2_Monobjc_Types_TSInteger_Monobjc_Types_TSUInteger_Monobjc_Types_TSFloat_Delegate =
            MethodParameter2_Monobjc_Types_TSInteger_Monobjc_Types_TSUInteger_Monobjc_Types_TSFloat;

        public static readonly MethodParameter3_Monobjc_Types_TSRange_Invoker MethodParameter3_Monobjc_Types_TSRange_Delegate = MethodParameter3_Monobjc_Types_TSRange;

        public static readonly MethodParameter4_Monobjc_Types_TSPoint_Monobjc_Types_TSSize_Monobjc_Types_TSRect_Invoker MethodParameter4_Monobjc_Types_TSPoint_Monobjc_Types_TSSize_Monobjc_Types_TSRect_Delegate =
            MethodParameter4_Monobjc_Types_TSPoint_Monobjc_Types_TSSize_Monobjc_Types_TSRect;

        public static void MethodParameter1_Monobjc_Types_TSIntegerEnumeration_Monobjc_Types_TSUIntegerEnumeration(IntPtr receiver, IntPtr selector, IntPtr arg1, IntPtr arg2)
        {
            TSIntegerEnumeration enumeration;
            TSUIntegerEnumeration enumeration2;
            ObjectiveCRuntime.GetInstance<DummyClassParametersOutVariableTypes>(receiver).MethodParameter1(out enumeration, out enumeration2);
            Marshal.WriteInt32(arg1, (int) enumeration);
            Marshal.WriteInt32(arg2, (int) (uint) enumeration2);
        }

        public static void MethodParameter2_Monobjc_Types_TSInteger_Monobjc_Types_TSUInteger_Monobjc_Types_TSFloat(IntPtr receiver, IntPtr selector, IntPtr arg1, IntPtr arg2, IntPtr arg3)
        {
            TSInteger integer;
            TSUInteger integer2;
            TSFloat num;
            DummyClassParametersOutVariableTypes.MethodParameter2(out integer, out integer2, out num);
            Marshal.WriteInt32(arg1, integer);
            Marshal.WriteInt32(arg2, (int) (uint) integer2);
            Marshal.StructureToPtr((float) num, arg3, false);
        }

        public static void MethodParameter3_Monobjc_Types_TSRange(IntPtr receiver, IntPtr selector, IntPtr arg1)
        {
            TSRange range;
            ObjectiveCRuntime.GetInstance<DummyClassParametersOutVariableTypes>(receiver).MethodParameter3(out range);
            Marshal.StructureToPtr(range, arg1, false);
        }

        public static void MethodParameter4_Monobjc_Types_TSPoint_Monobjc_Types_TSSize_Monobjc_Types_TSRect(IntPtr receiver, IntPtr selector, IntPtr arg1, IntPtr arg2, IntPtr arg3)
        {
            TSPoint point;
            TSSize size;
            TSRect rect;
            DummyClassParametersOutVariableTypes.MethodParameter4(out point, out size, out rect);
            Marshal.StructureToPtr(point, arg1, false);
            Marshal.StructureToPtr(size, arg2, false);
            Marshal.StructureToPtr(rect, arg3, false);
        }

        public delegate void MethodParameter1_Monobjc_Types_TSIntegerEnumeration_Monobjc_Types_TSUIntegerEnumeration_Invoker(IntPtr receiver, IntPtr selector, IntPtr arg1, IntPtr arg2);

        public delegate void MethodParameter2_Monobjc_Types_TSInteger_Monobjc_Types_TSUInteger_Monobjc_Types_TSFloat_Invoker(IntPtr receiver, IntPtr selector, IntPtr arg1, IntPtr arg2, IntPtr arg3);

        public delegate void MethodParameter3_Monobjc_Types_TSRange_Invoker(IntPtr receiver, IntPtr selector, IntPtr arg1);

        public delegate void MethodParameter4_Monobjc_Types_TSPoint_Monobjc_Types_TSSize_Monobjc_Types_TSRect_Invoker(IntPtr receiver, IntPtr selector, IntPtr arg1, IntPtr arg2, IntPtr arg3);
    }

    public static class DummyClassParametersOutVariableTypes64Bits_Proxy
    {
        public static readonly MethodParameter1_Monobjc_Types_TSIntegerEnumeration_Monobjc_Types_TSUIntegerEnumeration_Invoker MethodParameter1_Monobjc_Types_TSIntegerEnumeration_Monobjc_Types_TSUIntegerEnumeration_Delegate =
            MethodParameter1_Monobjc_Types_TSIntegerEnumeration_Monobjc_Types_TSUIntegerEnumeration;

        public static readonly MethodParameter2_Monobjc_Types_TSInteger_Monobjc_Types_TSUInteger_Monobjc_Types_TSFloat_Invoker MethodParameter2_Monobjc_Types_TSInteger_Monobjc_Types_TSUInteger_Monobjc_Types_TSFloat_Delegate =
            MethodParameter2_Monobjc_Types_TSInteger_Monobjc_Types_TSUInteger_Monobjc_Types_TSFloat;

        public static readonly MethodParameter3_Monobjc_Types_TSRange_Invoker MethodParameter3_Monobjc_Types_TSRange_Delegate = MethodParameter3_Monobjc_Types_TSRange;

        public static readonly MethodParameter4_Monobjc_Types_TSPoint_Monobjc_Types_TSSize_Monobjc_Types_TSRect_Invoker MethodParameter4_Monobjc_Types_TSPoint_Monobjc_Types_TSSize_Monobjc_Types_TSRect_Delegate =
            MethodParameter4_Monobjc_Types_TSPoint_Monobjc_Types_TSSize_Monobjc_Types_TSRect;

        public static void MethodParameter1_Monobjc_Types_TSIntegerEnumeration_Monobjc_Types_TSUIntegerEnumeration(IntPtr receiver, IntPtr selector, IntPtr arg1, IntPtr arg2)
        {
            TSIntegerEnumeration enumeration;
            TSUIntegerEnumeration enumeration2;
            ObjectiveCRuntime.GetInstance<DummyClassParametersOutVariableTypes>(receiver).MethodParameter1(out enumeration, out enumeration2);
            Marshal.WriteInt64(arg1, (long) enumeration);
            Marshal.WriteInt64(arg2, (long) (ulong) enumeration2);
        }

        public static void MethodParameter2_Monobjc_Types_TSInteger_Monobjc_Types_TSUInteger_Monobjc_Types_TSFloat(IntPtr receiver, IntPtr selector, IntPtr arg1, IntPtr arg2, IntPtr arg3)
        {
            TSInteger integer;
            TSUInteger integer2;
            TSFloat num;
            DummyClassParametersOutVariableTypes.MethodParameter2(out integer, out integer2, out num);
            Marshal.WriteInt64(arg1, integer);
            Marshal.WriteInt64(arg2, (long) (ulong) integer2);
            Marshal.StructureToPtr((double) num, arg3, false);
        }

        public static void MethodParameter3_Monobjc_Types_TSRange(IntPtr receiver, IntPtr selector, IntPtr arg1)
        {
            TSRange range;
            ObjectiveCRuntime.GetInstance<DummyClassParametersOutVariableTypes>(receiver).MethodParameter3(out range);
            Marshal.StructureToPtr((TSRange64) range, arg1, false);
        }

        public static void MethodParameter4_Monobjc_Types_TSPoint_Monobjc_Types_TSSize_Monobjc_Types_TSRect(IntPtr receiver, IntPtr selector, IntPtr arg1, IntPtr arg2, IntPtr arg3)
        {
            TSPoint point;
            TSSize size;
            TSRect rect;
            DummyClassParametersOutVariableTypes.MethodParameter4(out point, out size, out rect);
            Marshal.StructureToPtr((TSPoint64) point, arg1, false);
            Marshal.StructureToPtr((TSSize64) size, arg2, false);
            Marshal.StructureToPtr((TSRect64) rect, arg3, false);
        }

        public delegate void MethodParameter1_Monobjc_Types_TSIntegerEnumeration_Monobjc_Types_TSUIntegerEnumeration_Invoker(IntPtr receiver, IntPtr selector, IntPtr arg1, IntPtr arg2);

        public delegate void MethodParameter2_Monobjc_Types_TSInteger_Monobjc_Types_TSUInteger_Monobjc_Types_TSFloat_Invoker(IntPtr receiver, IntPtr selector, IntPtr arg1, IntPtr arg2, IntPtr arg3);

        public delegate void MethodParameter3_Monobjc_Types_TSRange_Invoker(IntPtr receiver, IntPtr selector, IntPtr arg1);

        public delegate void MethodParameter4_Monobjc_Types_TSPoint_Monobjc_Types_TSSize_Monobjc_Types_TSRect_Invoker(IntPtr receiver, IntPtr selector, IntPtr arg1, IntPtr arg2, IntPtr arg3);
    }
}