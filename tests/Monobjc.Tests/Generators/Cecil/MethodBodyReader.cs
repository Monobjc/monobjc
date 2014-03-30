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
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace Monobjc.Generators.Cecil
{
    //
    // MethodBodyReader.cs
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
    internal class MethodBodyReader
    {
        private static readonly OpCode[] one_byte_opcodes;
        private static readonly OpCode[] two_bytes_opcodes;

        /// <summary>
        ///   Initializes the <see cref = "MethodBodyReader" /> class.
        /// </summary>
        static MethodBodyReader()
        {
            one_byte_opcodes = new OpCode[0xe1];
            two_bytes_opcodes = new OpCode[0x1f];

            FieldInfo[] fields = typeof (OpCodes).GetFields(
                BindingFlags.Public | BindingFlags.Static);

            foreach (FieldInfo field in fields)
            {
                OpCode opcode = (OpCode) field.GetValue(null);
                if (opcode.OpCodeType == OpCodeType.Nternal)
                {
                    continue;
                }

                if (opcode.Size == 1)
                {
                    one_byte_opcodes[opcode.Value] = opcode;
                }
                else
                {
                    two_bytes_opcodes[opcode.Value & 0xff] = opcode;
                }
            }
        }

        private readonly MethodBase method;
        private readonly MethodBody body;
        private readonly Module module;
        private readonly ByteBuffer il;
        private readonly ParameterInfo[] parameters;
        private readonly IList<LocalVariableInfo> locals;
        private readonly List<Instruction> instructions = new List<Instruction>();

        private MethodBodyReader(MethodBase method)
        {
            this.method = method;

            this.body = method.GetMethodBody();
            if (this.body == null)
            {
                throw new ArgumentException("Method has no body");
            }

            byte[] bytes = this.body.GetILAsByteArray();
            if (bytes == null)
            {
                throw new ArgumentException("Can not get the body of the method");
            }

            if (!(method is ConstructorInfo))
            {
                method.GetGenericArguments();
            }

            if (method.DeclaringType != null)
            {
                method.DeclaringType.GetGenericArguments();
            }

            this.parameters = method.GetParameters();
            this.locals = this.body.LocalVariables;
            this.module = method.Module;
            this.il = new ByteBuffer(bytes);
        }

        private void ReadInstructions()
        {
            Instruction previous = null;

            while (this.il.position < this.il.buffer.Length)
            {
                Instruction instruction = new Instruction(this.il.position, this.ReadOpCode());

                this.ReadOperand(instruction);

                if (previous != null)
                {
                    instruction.Previous = previous;
                    previous.Next = instruction;
                }

                this.instructions.Add(instruction);
                previous = instruction;
            }

            this.ResolveBranches();
        }

        private void ReadOperand(Instruction instruction)
        {
            switch (instruction.OpCode.OperandType)
            {
                case OperandType.InlineNone:
                    break;
                case OperandType.InlineSwitch:
                    int length = this.il.ReadInt32();
                    int base_offset = this.il.position + (4*length);
                    int[] branches = new int[length];
                    for (int i = 0; i < length; i++)
                    {
                        branches[i] = this.il.ReadInt32() + base_offset;
                    }

                    instruction.Operand = branches;
                    break;
                case OperandType.ShortInlineBrTarget:
                    instruction.Operand = (((sbyte) this.il.ReadByte()) + this.il.position);
                    break;
                case OperandType.InlineBrTarget:
                    instruction.Operand = this.il.ReadInt32() + this.il.position;
                    break;
                case OperandType.ShortInlineI:
                    if (instruction.OpCode == OpCodes.Ldc_I4_S)
                    {
                        instruction.Operand = (sbyte) this.il.ReadByte();
                    }
                    else
                    {
                        instruction.Operand = this.il.ReadByte();
                    }
                    break;
                case OperandType.InlineI:
                    instruction.Operand = this.il.ReadInt32();
                    break;
                case OperandType.ShortInlineR:
                    instruction.Operand = this.il.ReadSingle();
                    break;
                case OperandType.InlineR:
                    instruction.Operand = this.il.ReadDouble();
                    break;
                case OperandType.InlineI8:
                    instruction.Operand = this.il.ReadInt64();
                    break;
                case OperandType.InlineSig:
                    instruction.Operand = this.module.ResolveSignature(this.il.ReadInt32());
                    break;
                case OperandType.InlineString:
                    instruction.Operand = this.module.ResolveString(this.il.ReadInt32());
                    break;
                case OperandType.InlineTok:
                case OperandType.InlineType:
                case OperandType.InlineMethod:
                case OperandType.InlineField:
                    this.il.ReadInt32();
                    //instruction.Operand = module.ResolveMember (il.ReadInt32 (), type_arguments, method_arguments);
                    break;
                case OperandType.ShortInlineVar:
                    instruction.Operand = this.GetVariable(instruction, this.il.ReadByte());
                    break;
                case OperandType.InlineVar:
                    instruction.Operand = this.GetVariable(instruction, this.il.ReadInt16());
                    break;
                default:
                    throw new NotSupportedException();
            }
        }

        private void ResolveBranches()
        {
            foreach (Instruction instruction in this.instructions)
            {
                switch (instruction.OpCode.OperandType)
                {
                    case OperandType.ShortInlineBrTarget:
                    case OperandType.InlineBrTarget:
                        instruction.Operand = GetInstruction(this.instructions, (int) instruction.Operand);
                        break;
                    case OperandType.InlineSwitch:
                        int[] offsets = (int[]) instruction.Operand;
                        Instruction[] branches = new Instruction[offsets.Length];
                        for (int j = 0; j < offsets.Length; j++)
                        {
                            branches[j] = GetInstruction(this.instructions, offsets[j]);
                        }

                        instruction.Operand = branches;
                        break;
                }
            }
        }

        private static Instruction GetInstruction(List<Instruction> instructions, int offset)
        {
            int size = instructions.Count;
            if (offset < 0 || offset > instructions[size - 1].Offset)
            {
                return null;
            }

            int min = 0;
            int max = size - 1;
            while (min <= max)
            {
                int mid = min + ((max - min)/2);
                Instruction instruction = instructions[mid];
                int instruction_offset = instruction.Offset;

                if (offset == instruction_offset)
                {
                    return instruction;
                }

                if (offset < instruction_offset)
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }

            return null;
        }

        private object GetVariable(Instruction instruction, int index)
        {
            if (TargetsLocalVariable(instruction.OpCode))
            {
                return this.GetLocalVariable(index);
            }

            return this.GetParameter(index);
        }

        private static bool TargetsLocalVariable(OpCode opcode)
        {
            return opcode.Name.Contains("loc");
        }

        private LocalVariableInfo GetLocalVariable(int index)
        {
            return this.locals[index];
        }

        private ParameterInfo GetParameter(int index)
        {
            if (!this.method.IsStatic)
            {
                index--;
            }

            return this.parameters[index];
        }

        private OpCode ReadOpCode()
        {
            byte op = this.il.ReadByte();
            return op != 0xfe
                       ? one_byte_opcodes[op]
                       : two_bytes_opcodes[this.il.ReadByte()];
        }

        public static IEnumerable<Instruction> GetInstructions(MethodBase method)
        {
            MethodBodyReader reader = new MethodBodyReader(method);
            reader.ReadInstructions();
            return reader.instructions;
        }
    }
}