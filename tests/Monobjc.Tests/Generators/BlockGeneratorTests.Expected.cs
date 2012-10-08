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
using Monobjc;
using Monobjc.Types;
using System.Runtime.InteropServices;

namespace Monobjc.Generators
{
#if MACOSX_10_6
    /// <summary>
    ///   Block: void (^)()
    /// </summary>
    public class Block_Void : Block
    {
        public readonly ExecuteInvoker blockInvoker;

        public Block_Void(Delegate block)
            : base(block)
        {
            this.blockInvoker = new ExecuteInvoker(this.Execute);
        }

        public void Execute(IntPtr layout)
        {
            ((Action) this.Invoker)();
        }

        public override Delegate BlockInvoker
        {
            get { return this.blockInvoker; }
        }

        public delegate void ExecuteInvoker(IntPtr layout);
    }

    /// <summary>
    ///   Block: void (^)(bool)
    /// </summary>
    public class Block_Void_Boolean : Block
    {
        public readonly ExecuteInvoker blockInvoker;

        public Block_Void_Boolean(Delegate block)
            : base(block)
        {
            this.blockInvoker = new ExecuteInvoker(this.Execute);
        }

        public void Execute(IntPtr layout, bool arg1)
        {
            ((Action<bool>) base.Invoker)(arg1);
        }

        public override Delegate BlockInvoker
        {
            get { return this.blockInvoker; }
        }

        public delegate void ExecuteInvoker(IntPtr layout, bool arg1);
    }

    /// <summary>
    ///   Block: void (^)(byte, ushort, uint, ulong)
    /// </summary>
    public class Block_Void_Byte_UInt16_UInt32_UInt64 : Block
    {
        public readonly ExecuteInvoker blockInvoker;

        public Block_Void_Byte_UInt16_UInt32_UInt64(Delegate block)
            : base(block)
        {
            this.blockInvoker = new ExecuteInvoker(this.Execute);
        }

        public void Execute(IntPtr layout, byte arg1, ushort arg2, uint arg3, ulong arg4)
        {
            ((Action<byte, ushort, uint, ulong>) base.Invoker)(arg1, arg2, arg3, arg4);
        }

        public override Delegate BlockInvoker
        {
            get { return this.blockInvoker; }
        }

        public delegate void ExecuteInvoker(IntPtr layout, byte arg1, ushort arg2, uint arg3, ulong arg4);
    }

    /// <summary>
    ///   Block: void (^)(TSWindingRule)
    /// </summary>
    public class Block_Void_TSWindingRule : Block
    {
        public readonly ExecuteInvoker blockInvoker;

        public Block_Void_TSWindingRule(Delegate block)
            : base(block)
        {
            this.blockInvoker = new ExecuteInvoker(this.Execute);
        }

        public void Execute(IntPtr layout, int arg1)
        {
            ((Action<TSWindingRule>) base.Invoker)((TSWindingRule) arg1);
        }

        public override Delegate BlockInvoker
        {
            get { return this.blockInvoker; }
        }

        public delegate void ExecuteInvoker(IntPtr layout, int arg1);
    }

    /// <summary>
    ///   Block: void (^)(IntPtr, IntPtr, IntPtr, const char *)
    /// </summary>
    public class Block_Void_IntPtr_Id_Class_String : Block
    {
        public readonly ExecuteInvoker blockInvoker;


        public Block_Void_IntPtr_Id_Class_String(Delegate block)
            : base(block)
        {
            this.blockInvoker = new ExecuteInvoker(this.Execute);
        }

        public void Execute(IntPtr layout, IntPtr arg1, IntPtr arg2, IntPtr arg3, string arg4)
        {
            ((Action<IntPtr, Id, Class, string>) base.Invoker)(arg1, ObjectiveCRuntime.GetInstance<Id>(arg2), ObjectiveCRuntime.GetInstance<Class>(arg3), arg4);
        }


        public override Delegate BlockInvoker
        {
            get { return this.blockInvoker; }
        }


        public delegate void ExecuteInvoker(IntPtr layout, IntPtr arg1, IntPtr arg2, IntPtr arg3, string arg4);
    }

	/// <summary>
	///   Block: void (^)(Id, BOOL *stop)
	/// </summary>
	public class Block_CustomEnumerator : Block
	{
		public readonly ExecuteInvoker blockInvoker;
		
		public Block_CustomEnumerator(Delegate block)
			: base(block)
		{
			this.blockInvoker = new ExecuteInvoker(this.Execute);
		}
		
		public void Execute(IntPtr layout, Id id, IntPtr stop)
		{
			bool value1 = Marshal.ReadByte(stop) != 0;
			((CustomEnumerator) this.Invoker)(null, ref value1);
			Marshal.WriteByte(stop, (byte)(value1 ? 1 : 0));
		}
		
		public override Delegate BlockInvoker
		{
			get { return this.blockInvoker; }
		}
		
		public delegate void ExecuteInvoker(IntPtr layout, Id id, IntPtr stop);
	}

    /// <summary>
    ///   Block: void (^)(int)
    /// </summary>
    public class Block_Void_Int32 : Block
    {
        public readonly ExecuteInvoker blockInvoker;

        public Block_Void_Int32(Delegate block)
            : base(block)
        {
            this.blockInvoker = new ExecuteInvoker(this.Execute);
        }

        public void Execute(IntPtr layout, int num1)
        {
            ((Action<int>) this.Invoker)(num1);
        }

        public override Delegate BlockInvoker
        {
            get { return this.blockInvoker; }
        }

        public delegate void ExecuteInvoker(IntPtr layout, int num1);
    }

    /// <summary>
    ///   Block: void (^)(int, int)
    /// </summary>
    public class Block_Void_Int32_Int32 : Block
    {
        public readonly ExecuteInvoker blockInvoker;

        public Block_Void_Int32_Int32(Delegate block)
            : base(block)
        {
            this.blockInvoker = new ExecuteInvoker(this.Execute);
        }

        public void Execute(IntPtr layout, int num1, int num2)
        {
            ((Action<int, int>) base.Invoker)(num1, num2);
        }

        public override Delegate BlockInvoker
        {
            get { return this.blockInvoker; }
        }

        public delegate void ExecuteInvoker(IntPtr layout, int num1, int num2);
    }

    /// <summary>
    ///   Block: void (^)(int, int, int)
    /// </summary>
    public class Block_Void_Int32_Int32_Int32 : Block
    {
        public readonly ExecuteInvoker blockInvoker;

        public Block_Void_Int32_Int32_Int32(Delegate block)
            : base(block)
        {
            this.blockInvoker = new ExecuteInvoker(this.Execute);
        }

        public void Execute(IntPtr layout, int num1, int num2, int num3)
        {
            ((Action<int, int, int>) base.Invoker)(num1, num2, num3);
        }

        public override Delegate BlockInvoker
        {
            get { return this.blockInvoker; }
        }

        public delegate void ExecuteInvoker(IntPtr layout, int num1, int num2, int num3);
    }

    /// <summary>
    ///   Block: void (^)(int, int, int, int)
    /// </summary>
    public class Block_Void_Int32_Int32_Int32_Int32 : Block
    {
        public readonly ExecuteInvoker blockInvoker;

        public Block_Void_Int32_Int32_Int32_Int32(Delegate block)
            : base(block)
        {
            this.blockInvoker = new ExecuteInvoker(this.Execute);
        }

        public void Execute(IntPtr layout, int num1, int num2, int num3, int num4)
        {
            ((Action<int, int, int, int>) base.Invoker)(num1, num2, num3, num4);
        }

        public override Delegate BlockInvoker
        {
            get { return this.blockInvoker; }
        }

        public delegate void ExecuteInvoker(IntPtr layout, int num1, int num2, int num3, int num4);
    }

    /// <summary>
    ///   Block: void (^)(TSIntegerEnumeration)
    /// </summary>
    public class Block_Void_TSIntegerEnumeration_TSUnsignedEnumeration32 : Block
    {
        public readonly ExecuteInvoker blockInvoker;

        public Block_Void_TSIntegerEnumeration_TSUnsignedEnumeration32(Delegate block)
            : base(block)
        {
            this.blockInvoker = new ExecuteInvoker(this.Execute);
        }

        public void Execute(IntPtr layout, int num1, uint num2)
        {
            ((Action<TSIntegerEnumeration, TSUIntegerEnumeration>) base.Invoker)((TSIntegerEnumeration) num1, (TSUIntegerEnumeration) num2);
        }

        public override Delegate BlockInvoker
        {
            get { return this.blockInvoker; }
        }

        public delegate void ExecuteInvoker(IntPtr layout, int num1, uint num2);
    }

    /// <summary>
    ///   Block: void (^)(TSIntegerEnumeration)
    /// </summary>
    public class Block_Void_TSIntegerEnumeration_TSUnsignedEnumeration64 : Block
    {
        public readonly ExecuteInvoker blockInvoker;

        public Block_Void_TSIntegerEnumeration_TSUnsignedEnumeration64(Delegate block)
            : base(block)
        {
            this.blockInvoker = new ExecuteInvoker(this.Execute);
        }

        public void Execute(IntPtr layout, long num1, ulong num2)
        {
            ((Action<TSIntegerEnumeration, TSUIntegerEnumeration>) base.Invoker)((TSIntegerEnumeration) num1, (TSUIntegerEnumeration) num2);
        }

        public override Delegate BlockInvoker
        {
            get { return this.blockInvoker; }
        }

        public delegate void ExecuteInvoker(IntPtr layout, long num1, ulong num2);
    }

    /// <summary>
    ///   Block: void (^)(TSInteger, TSUInteger, TSFloat)
    /// </summary>
    public class Block_Void_TSInteger_TSUInteger_TSFloat32 : Block
    {
        public readonly ExecuteInvoker blockInvoker;

        public Block_Void_TSInteger_TSUInteger_TSFloat32(Delegate block)
            : base(block)
        {
            this.blockInvoker = new ExecuteInvoker(this.Execute);
        }

        public void Execute(IntPtr layout, int num1, uint num2, float num3)
        {
            ((Action<TSInteger, TSUInteger, TSFloat>) base.Invoker)((TSInteger) num1, (TSUInteger) num2, (TSFloat) num3);
        }

        public override Delegate BlockInvoker
        {
            get { return this.blockInvoker; }
        }

        public delegate void ExecuteInvoker(IntPtr layout, int l1, uint ul1, float d1);
    }

    /// <summary>
    ///   Block: void (^)(TSInteger, TSUInteger, TSFloat)
    /// </summary>
    public class Block_Void_TSInteger_TSUInteger_TSFloat64 : Block
    {
        public readonly ExecuteInvoker blockInvoker;

        public Block_Void_TSInteger_TSUInteger_TSFloat64(Delegate block)
            : base(block)
        {
            this.blockInvoker = new ExecuteInvoker(this.Execute);
        }

        public void Execute(IntPtr layout, long num1, ulong num2, double num3)
        {
            ((Action<TSInteger, TSUInteger, TSFloat>) base.Invoker)((TSInteger) num1, (TSUInteger) num2, (TSFloat) num3);
        }

        public override Delegate BlockInvoker
        {
            get { return this.blockInvoker; }
        }

        public delegate void ExecuteInvoker(IntPtr layout, long l1, ulong ul1, double d1);
    }

    public class Block_Void_TSRange32 : Block
    {
        public readonly ExecuteInvoker blockInvoker;

        public Block_Void_TSRange32(Delegate block)
            : base(block)
        {
            this.blockInvoker = new ExecuteInvoker(this.Execute);
        }

        public void Execute(IntPtr layout, TSRange arg1)
        {
            ((Action<TSRange>) base.Invoker)(arg1);
        }

        public override Delegate BlockInvoker
        {
            get { return this.blockInvoker; }
        }

        public delegate void ExecuteInvoker(IntPtr layout, TSRange arg1);
    }

    public class Block_Void_TSRange64 : Block
    {
        public readonly ExecuteInvoker blockInvoker;

        public Block_Void_TSRange64(Delegate block)
            : base(block)
        {
            this.blockInvoker = new ExecuteInvoker(this.Execute);
        }

        public void Execute(IntPtr layout, TSRange64 arg1)
        {
            ((Action<TSRange>) base.Invoker)(arg1);
        }

        public override Delegate BlockInvoker
        {
            get { return this.blockInvoker; }
        }

        public delegate void ExecuteInvoker(IntPtr layout, TSRange64 arg1);
    }

    public class Block_Void_TSPoint_TSSize_TSRect32 : Block
    {
        public readonly ExecuteInvoker blockInvoker;

        public Block_Void_TSPoint_TSSize_TSRect32(Delegate block)
            : base(block)
        {
            this.blockInvoker = new ExecuteInvoker(this.Execute);
        }

        public void Execute(IntPtr layout, TSPoint arg1, TSSize arg2, TSRect arg3)
        {
            ((Action<TSPoint, TSSize, TSRect>) base.Invoker)(arg1, arg2, arg3);
        }

        public override Delegate BlockInvoker
        {
            get { return this.blockInvoker; }
        }

        public delegate void ExecuteInvoker(IntPtr layout, TSPoint arg1, TSSize arg2, TSRect arg3);
    }

    public class Block_Void_TSPoint_TSSize_TSRect64 : Block
    {
        public readonly ExecuteInvoker blockInvoker;

        public Block_Void_TSPoint_TSSize_TSRect64(Delegate block)
            : base(block)
        {
            this.blockInvoker = new ExecuteInvoker(this.Execute);
        }

        public void Execute(IntPtr layout, TSPoint64 arg1, TSSize64 arg2, TSRect64 arg3)
        {
            ((Action<TSPoint, TSSize, TSRect>) base.Invoker)(arg1, arg2, arg3);
        }

        public override Delegate BlockInvoker
        {
            get { return this.blockInvoker; }
        }

        public delegate void ExecuteInvoker(IntPtr layout, TSPoint64 arg1, TSSize64 arg2, TSRect64 arg3);
    }


    /// <summary>
    ///   Block: int (^)()
    /// </summary>
    public class Func_Int32 : Block
    {
        public readonly ExecuteInvoker blockInvoker;

        public Func_Int32(Delegate block)
            : base(block)
        {
            this.blockInvoker = new ExecuteInvoker(this.Execute);
        }

        public int Execute(IntPtr layout)
        {
            return ((Func<int>) this.Invoker)();
        }

        public override Delegate BlockInvoker
        {
            get { return this.blockInvoker; }
        }

        public delegate int ExecuteInvoker(IntPtr layout);
    }

    /// <summary>
    ///   Block: int (^)(int)
    /// </summary>
    public class Func_Int32_Int32 : Block
    {
        public readonly ExecuteInvoker blockInvoker;

        public Func_Int32_Int32(Delegate block)
            : base(block)
        {
            this.blockInvoker = new ExecuteInvoker(this.Execute);
        }

        public int Execute(IntPtr layout, int num1)
        {
            return ((Func<int, int>) base.Invoker)(num1);
        }

        public override Delegate BlockInvoker
        {
            get { return this.blockInvoker; }
        }

        public delegate int ExecuteInvoker(IntPtr layout, int num1);
    }

    /// <summary>
    ///   Block: int (^)(int, int)
    /// </summary>
    public class Func_Int32_Int32_Int32 : Block
    {
        public readonly ExecuteInvoker blockInvoker;

        public Func_Int32_Int32_Int32(Delegate block)
            : base(block)
        {
            this.blockInvoker = new ExecuteInvoker(this.Execute);
        }

        public int Execute(IntPtr layout, int num1, int num2)
        {
            return ((Func<int, int, int>) base.Invoker)(num1, num2);
        }

        public override Delegate BlockInvoker
        {
            get { return this.blockInvoker; }
        }

        public delegate int ExecuteInvoker(IntPtr layout, int num1, int num2);
    }

    /// <summary>
    ///   Block: int (^)(int, int, int)
    /// </summary>
    public class Func_Int32_Int32_Int32_Int32 : Block
    {
        public readonly ExecuteInvoker blockInvoker;

        public Func_Int32_Int32_Int32_Int32(Delegate block)
            : base(block)
        {
            this.blockInvoker = new ExecuteInvoker(this.Execute);
        }

        public int Execute(IntPtr layout, int num1, int num2, int num3)
        {
            return ((Func<int, int, int, int>) base.Invoker)(num1, num2, num3);
        }

        public override Delegate BlockInvoker
        {
            get { return this.blockInvoker; }
        }

        public delegate int ExecuteInvoker(IntPtr layout, int num1, int num2, int num3);
    }

    /// <summary>
    ///   Block: int (^)(int, int, int, int)
    /// </summary>
    public class Func_Int32_Int32_Int32_Int32_Int32 : Block
    {
        public readonly ExecuteInvoker blockInvoker;

        public Func_Int32_Int32_Int32_Int32_Int32(Delegate block)
            : base(block)
        {
            this.blockInvoker = new ExecuteInvoker(this.Execute);
        }

        public int Execute(IntPtr layout, int num1, int num2, int num3, int num4)
        {
            return ((Func<int, int, int, int, int>) base.Invoker)(num1, num2, num3, num4);
        }

        public override Delegate BlockInvoker
        {
            get { return this.blockInvoker; }
        }

        public delegate int ExecuteInvoker(IntPtr layout, int num1, int num2, int num3, int num4);
    }

    /// <summary>
    ///   Block: TSIntegerEnumeration (^)()
    /// </summary>
    public class Block_TSIntegerEnumeration32 : Block
    {
        public readonly ExecuteInvoker blockInvoker;

        public Block_TSIntegerEnumeration32(Delegate block)
            : base(block)
        {
            this.blockInvoker = new ExecuteInvoker(this.Execute);
        }

        public int Execute(IntPtr layout)
        {
            return (int) ((Func<TSIntegerEnumeration>) base.Invoker)();
        }

        public override Delegate BlockInvoker
        {
            get { return this.blockInvoker; }
        }

        public delegate int ExecuteInvoker(IntPtr layout);
    }

    /// <summary>
    ///   Block: TSIntegerEnumeration (^)()
    /// </summary>
    public class Block_TSIntegerEnumeration64 : Block
    {
        public readonly ExecuteInvoker blockInvoker;

        public Block_TSIntegerEnumeration64(Delegate block)
            : base(block)
        {
            this.blockInvoker = new ExecuteInvoker(this.Execute);
        }

        public long Execute(IntPtr layout)
        {
            return (long) ((Func<TSIntegerEnumeration>) base.Invoker)();
        }

        public override Delegate BlockInvoker
        {
            get { return this.blockInvoker; }
        }

        public delegate long ExecuteInvoker(IntPtr layout);
    }

    /// <summary>
    ///   Block: TSUIntegerEnumeration (^)()
    /// </summary>
    public class Block_TSUnsignedEnumeration32 : Block
    {
        public readonly ExecuteInvoker blockInvoker;

        public Block_TSUnsignedEnumeration32(Delegate block)
            : base(block)
        {
            this.blockInvoker = new ExecuteInvoker(this.Execute);
        }

        public uint Execute(IntPtr layout)
        {
            return (uint) ((Func<TSUIntegerEnumeration>) base.Invoker)();
        }

        public override Delegate BlockInvoker
        {
            get { return this.blockInvoker; }
        }

        public delegate uint ExecuteInvoker(IntPtr layout);
    }

    /// <summary>
    ///   Block: TSUIntegerEnumeration (^)()
    /// </summary>
    public class Block_TSUnsignedEnumeration64 : Block
    {
        public readonly ExecuteInvoker blockInvoker;

        public Block_TSUnsignedEnumeration64(Delegate block)
            : base(block)
        {
            this.blockInvoker = new ExecuteInvoker(this.Execute);
        }

        public ulong Execute(IntPtr layout)
        {
            return (ulong) ((Func<TSUIntegerEnumeration>) base.Invoker)();
        }

        public override Delegate BlockInvoker
        {
            get { return this.blockInvoker; }
        }

        public delegate ulong ExecuteInvoker(IntPtr layout);
    }

    /// <summary>
    ///   Block: TSInteger (^)()
    /// </summary>
    public class Block_TSInteger32 : Block
    {
        public readonly ExecuteInvoker blockInvoker;


        public Block_TSInteger32(Delegate block)
            : base(block)
        {
            this.blockInvoker = new ExecuteInvoker(this.Execute);
        }

        public int Execute(IntPtr layout)
        {
            return ((Func<TSInteger>) base.Invoker)();
        }


        public override Delegate BlockInvoker
        {
            get { return this.blockInvoker; }
        }


        public delegate int ExecuteInvoker(IntPtr layout);
    }

    /// <summary>
    ///   Block: TSInteger (^)()
    /// </summary>
    public class Block_TSInteger64 : Block
    {
        public readonly ExecuteInvoker blockInvoker;

        public Block_TSInteger64(Delegate block)
            : base(block)
        {
            this.blockInvoker = new ExecuteInvoker(this.Execute);
        }

        public long Execute(IntPtr layout)
        {
            return ((Func<TSInteger>) base.Invoker)();
        }

        public override Delegate BlockInvoker
        {
            get { return this.blockInvoker; }
        }

        public delegate long ExecuteInvoker(IntPtr layout);
    }

    /// <summary>
    ///   Block: TSUInteger (^)()
    /// </summary>
    public class Block_TSUInteger32 : Block
    {
        public readonly ExecuteInvoker blockInvoker;


        public Block_TSUInteger32(Delegate block)
            : base(block)
        {
            this.blockInvoker = new ExecuteInvoker(this.Execute);
        }

        public uint Execute(IntPtr layout)
        {
            return ((Func<TSUInteger>) base.Invoker)();
        }


        public override Delegate BlockInvoker
        {
            get { return this.blockInvoker; }
        }


        public delegate uint ExecuteInvoker(IntPtr layout);
    }

    /// <summary>
    ///   Block: TSUInteger (^)()
    /// </summary>
    public class Block_TSUInteger64 : Block
    {
        public readonly ExecuteInvoker blockInvoker;

        public Block_TSUInteger64(Delegate block)
            : base(block)
        {
            this.blockInvoker = new ExecuteInvoker(this.Execute);
        }

        public ulong Execute(IntPtr layout)
        {
            return ((Func<TSUInteger>) base.Invoker)();
        }

        public override Delegate BlockInvoker
        {
            get { return this.blockInvoker; }
        }

        public delegate ulong ExecuteInvoker(IntPtr layout);
    }

    /// <summary>
    ///   Block: TSFloat (^)()
    /// </summary>
    public class Block_TSFloat32 : Block
    {
        public readonly ExecuteInvoker blockInvoker;

        public Block_TSFloat32(Delegate block)
            : base(block)
        {
            this.blockInvoker = new ExecuteInvoker(this.Execute);
        }

        public float Execute(IntPtr layout)
        {
            return ((Func<TSFloat>) base.Invoker)();
        }

        public override Delegate BlockInvoker
        {
            get { return this.blockInvoker; }
        }

        public delegate float ExecuteInvoker(IntPtr layout);
    }

    /// <summary>
    ///   Block: TSFloat (^)()
    /// </summary>
    public class Block_TSFloat64 : Block
    {
        public readonly ExecuteInvoker blockInvoker;

        public Block_TSFloat64(Delegate block)
            : base(block)
        {
            this.blockInvoker = new ExecuteInvoker(this.Execute);
        }

        public double Execute(IntPtr layout)
        {
            return ((Func<TSFloat>) base.Invoker)();
        }

        public override Delegate BlockInvoker
        {
            get { return this.blockInvoker; }
        }

        public delegate double ExecuteInvoker(IntPtr layout);
    }

    /// <summary>
    ///   Block: TSRange (^)()
    /// </summary>
    public class Block_TSRange32 : Block
    {
        public readonly ExecuteInvoker blockInvoker;

        public Block_TSRange32(Delegate block)
            : base(block)
        {
            this.blockInvoker = new ExecuteInvoker(this.Execute);
        }

        public TSRange Execute(IntPtr layout)
        {
            return ((Func<TSRange>) base.Invoker)();
        }

        public override Delegate BlockInvoker
        {
            get { return this.blockInvoker; }
        }

        public delegate TSRange ExecuteInvoker(IntPtr layout);
    }

    /// <summary>
    ///   Block: TSRange (^)()
    /// </summary>
    public class Block_TSRange64 : Block
    {
        public readonly ExecuteInvoker blockInvoker;

        public Block_TSRange64(Delegate block)
            : base(block)
        {
            this.blockInvoker = new ExecuteInvoker(this.Execute);
        }

        public TSRange64 Execute(IntPtr layout)
        {
            return ((Func<TSRange>) base.Invoker)();
        }

        public override Delegate BlockInvoker
        {
            get { return this.blockInvoker; }
        }

        public delegate TSRange64 ExecuteInvoker(IntPtr layout);
    }

    /// <summary>
    ///   Block: TSPoint (^)()
    /// </summary>
    public class Block_TSPoint32 : Block
    {
        public readonly ExecuteInvoker blockInvoker;


        public Block_TSPoint32(Delegate block)
            : base(block)
        {
            this.blockInvoker = new ExecuteInvoker(this.Execute);
        }

        public TSPoint Execute(IntPtr layout)
        {
            return ((Func<TSPoint>) base.Invoker)();
        }


        public override Delegate BlockInvoker
        {
            get { return this.blockInvoker; }
        }


        public delegate TSPoint ExecuteInvoker(IntPtr layout);
    }

    /// <summary>
    ///   Block: TSPoint (^)()
    /// </summary>
    public class Block_TSPoint64 : Block
    {
        public readonly ExecuteInvoker blockInvoker;


        public Block_TSPoint64(Delegate block)
            : base(block)
        {
            this.blockInvoker = new ExecuteInvoker(this.Execute);
        }

        public TSPoint64 Execute(IntPtr layout)
        {
            return ((Func<TSPoint>) base.Invoker)();
        }


        public override Delegate BlockInvoker
        {
            get { return this.blockInvoker; }
        }

        public delegate TSPoint64 ExecuteInvoker(IntPtr layout);
    }

    /// <summary>
    ///   Block: TSRect (^)()
    /// </summary>
    public class Block_TSRect32 : Block
    {
        public readonly ExecuteInvoker blockInvoker;

        public Block_TSRect32(Delegate block)
            : base(block)
        {
            this.blockInvoker = new ExecuteInvoker(this.Execute);
        }

        public TSRect Execute(IntPtr layout)
        {
            return ((Func<TSRect>) base.Invoker)();
        }

        public override Delegate BlockInvoker
        {
            get { return this.blockInvoker; }
        }

        public delegate TSRect ExecuteInvoker(IntPtr layout);
    }

    /// <summary>
    ///   Block: TSRect (^)()
    /// </summary>
    public class Block_TSRect64 : Block
    {
        public readonly ExecuteInvoker blockInvoker;

        public Block_TSRect64(Delegate block)
            : base(block)
        {
            this.blockInvoker = new ExecuteInvoker(this.Execute);
        }

        public TSRect64 Execute(IntPtr layout)
        {
            return ((Func<TSRect>) base.Invoker)();
        }

        public override Delegate BlockInvoker
        {
            get { return this.blockInvoker; }
        }

        public delegate TSRect64 ExecuteInvoker(IntPtr layout);
    }
#endif
}