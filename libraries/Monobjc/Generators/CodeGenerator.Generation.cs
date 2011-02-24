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
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using Monobjc.Properties;
using Monobjc.Utils;

namespace Monobjc.Generators
{
    internal partial class CodeGenerator
    {
        /// <summary>
        ///   Defines the proxy delegate field info.
        /// </summary>
        /// <param name = "typeBuilder">The type builder.</param>
        /// <param name = "methodTuple">The method tuple.</param>
        internal static FieldInfo DefineProxyDelegateFieldInfo(TypeBuilder typeBuilder, MethodTuple methodTuple)
        {
            // Create a unique delegate name
            String name = GetUniqueName(methodTuple.MethodInfo) + "_Delegate"; // TODO: Const
            return EmitHelper.DefineField(typeBuilder, name, methodTuple.ProxyDelegate, true);
        }

        /// <summary>
        ///   Defines a static constructor.
        /// </summary>
        /// <param name = "typeBuilder">The type builder.</param>
        /// <param name = "methodTuples">The method tuples.</param>
        internal static void DefineStaticConstructor(TypeBuilder typeBuilder, IEnumerable<MethodTuple> methodTuples)
        {
            ConstructorBuilder constructorBuilder = null;
            ILGenerator generator = null;

            foreach (MethodTuple methodTuple in methodTuples)
            {
                if (constructorBuilder == null)
                {
                    // Generates body only if needed
                    constructorBuilder = EmitHelper.DefineStaticConstructor(typeBuilder);
                    generator = constructorBuilder.GetILGenerator();
                }

                generator.Emit(OpCodes.Ldnull);
                generator.Emit(OpCodes.Ldftn, methodTuple.ProxyMethodInfo);
                generator.Emit(OpCodes.Newobj, methodTuple.ProxyDelegateConstructor);
                generator.Emit(OpCodes.Stsfld, methodTuple.ProxyDelegateFieldInfo);
            }

            if (generator != null)
            {
                // Return
                generator.Emit(OpCodes.Ret);
            }
        }

        /// <summary>
        ///   Emit local variable for each by-ref parameters. These variables will hold the result until the marshalling occurs.
        /// </summary>
        protected static ByRefParameter[] CreateLocalVariableForByRefParameters(ILGenerator generator, ParameterInfo[] parameterInfos)
        {
            ByRefParameter[] byrefLocals = new ByRefParameter[parameterInfos.Length];
            for (int i = 0; i < parameterInfos.Length; i++)
            {
                Type parameterType = parameterInfos[i].ParameterType;

                // For by-ref type, create a local variable and store it
                if (!parameterType.IsByRef)
                {
                    continue;
                }

                // Create the local variable of the de-referenced type
                byrefLocals[i].LocalBuilder = generator.DeclareLocal(parameterType.GetElementType());
                byrefLocals[i].IsOut = parameterInfos[i].IsOut;
            }
            return byrefLocals;
        }

        /// <summary>
        ///   For by-ref parameters passed as reference (without [out] attribute), we first set the value of local variables
        /// </summary>
        protected void EmitNativeToManagedMarshallingForByRefParameters(ILGenerator generator, Type[] nativeParameterTypes, ByRefParameter[] byRefLocalVariables)
        {
            for (int i = 0; i < byRefLocalVariables.Length; i++)
            {
                ByRefParameter parameter = byRefLocalVariables[i];
                if (parameter.LocalBuilder == null || parameter.IsOut)
                {
                    continue;
                }

                Type localType = parameter.LocalBuilder.LocalType;

                EmitLoadArgument(generator, i + 2);
                this.EmitNativeToManagedMarshallingCast(generator, localType);
                generator.Emit(OpCodes.Stloc, parameter.LocalBuilder);
            }
        }

        /// <summary>
        ///   Emits the native to managed marshalling cast.
        /// </summary>
        /// <param name = "generator">The generator.</param>
        /// <param name = "localType">Type of the local.</param>
        private void EmitNativeToManagedMarshallingCast(ILGenerator generator, Type localType)
        {
            if (TypeHelper.NeedWrapping(localType))
            {
                MethodInfo retrieveInstance = EmitInfos.OBJECTIVECRUNTIME_GETINSTANCE.MakeGenericMethod(new[] {localType});
                generator.Emit(OpCodes.Call, retrieveInstance);
            }
            else if (localType == typeof (bool))
            {
                generator.Emit(OpCodes.Call, EmitInfos.MARSHAL_READINT32);
                generator.Emit(OpCodes.Ldc_I4_0);
                generator.Emit(OpCodes.Ceq);
                generator.Emit(OpCodes.Ldc_I4_0);
                generator.Emit(OpCodes.Ceq);
            }
            else if (localType == typeof (byte))
            {
                generator.Emit(OpCodes.Call, EmitInfos.MARSHAL_READBYTE);
            }
            else if (localType == typeof (char))
            {
                generator.Emit(OpCodes.Call, EmitInfos.MARSHAL_READINT16);
                generator.Emit(OpCodes.Conv_U2);
            }
            else if (localType == typeof (short))
            {
                generator.Emit(OpCodes.Call, EmitInfos.MARSHAL_READINT16);
            }
            else if (localType == typeof (ushort))
            {
                generator.Emit(OpCodes.Call, EmitInfos.MARSHAL_READINT16);
                generator.Emit(OpCodes.Conv_U2);
            }
            else if (localType == typeof (int) || localType == typeof (uint))
            {
                generator.Emit(OpCodes.Call, EmitInfos.MARSHAL_READINT32);
            }
            else if (localType == typeof (long) || localType == typeof (ulong))
            {
                generator.Emit(OpCodes.Call, EmitInfos.MARSHAL_READINT64);
            }
            else if (localType == typeof (IntPtr) || localType == typeof (UIntPtr))
            {
                generator.Emit(OpCodes.Call, EmitInfos.MARSHAL_READINTPTR);
            }
            else if (localType.IsEnum)
            {
                Type baseType = Enum.GetUnderlyingType(localType);
                Type underlyingType = TypeHelper.GetUnderlyingType(localType, this.Is64Bits);
                this.EmitNativeToManagedMarshallingCast(generator, underlyingType);

                if (baseType != underlyingType)
                {
                    if (baseType == typeof (int) && underlyingType == typeof (long))
                    {
                        generator.Emit(OpCodes.Conv_I4);
                    }
                    else if (baseType == typeof (uint) && underlyingType == typeof (ulong))
                    {
                        generator.Emit(OpCodes.Conv_U4);
                    }
                    else
                    {
                        throw new ObjectiveCCodeGenerationException(String.Format(CultureInfo.CurrentCulture, Resources.CannotGenerateCodeByRefParameterNotSupported, localType.FullName));
                    }
                }
            }
            else if (localType.IsValueType)
            {
                Type underlyingType = TypeHelper.GetUnderlyingType(localType, this.Is64Bits);
                if (localType != underlyingType)
                {
                    // Marshal the native value into the local variable
                    generator.Emit(OpCodes.Ldtoken, underlyingType);
                    generator.Emit(OpCodes.Call, EmitInfos.TYPE_GETTYPEFROMHANDLE);
                    generator.Emit(OpCodes.Call, EmitInfos.MARSHAL_PTRTOSTRUCTURE);
                    generator.Emit(OpCodes.Unbox_Any, underlyingType);
                    EmitHelper.CastValueType(generator, underlyingType, localType);
                }
                else
                {
                    // Marshal the native value into the local variable
                    generator.Emit(OpCodes.Ldtoken, localType);
                    generator.Emit(OpCodes.Call, EmitInfos.TYPE_GETTYPEFROMHANDLE);
                    generator.Emit(OpCodes.Call, EmitInfos.MARSHAL_PTRTOSTRUCTURE);
                    generator.Emit(OpCodes.Unbox_Any, localType);
                }
            }
            else
            {
                throw new ObjectiveCCodeGenerationException(String.Format(CultureInfo.CurrentCulture, Resources.CannotGenerateCodeByRefParameterNotSupported, localType.FullName));
            }
        }

        /// <summary>
        ///   Genenerate optimized IL for stacking parameters :
        ///   - For the third or fourth parameter, use the short OpCode
        ///   - For all the parameters left, use the long OpCode
        /// </summary>
        protected static void EmitParametersLoadingOnStack(ILGenerator generator, Type[] parameterTypes, Type[] nativeParameterTypes, ByRefParameter[] byRefLocalVariables)
        {
            for (int i = 0; i < parameterTypes.Length; i++)
            {
                // For by-ref type, loads the local variable
                // Otherwise, loads the argument (wrapped or not)
                Type parameterType = parameterTypes[i];
                if (parameterType.IsByRef)
                {
                    generator.Emit(OpCodes.Ldloca, byRefLocalVariables[i].LocalBuilder);
                }
                else
                {
                    EmitLoadArgument(generator, i + 2);

                    // For wrapped type (interface or Id subclass)
                    if (TypeHelper.NeedWrapping(parameterType))
                    {
                        MethodInfo wrapInstance = EmitInfos.OBJECTIVECRUNTIME_GETINSTANCE.MakeGenericMethod(new[] {parameterType});
                        generator.Emit(OpCodes.Call, wrapInstance);
                    }
                    else
                    {
                        EmitHelper.CastValueType(generator, nativeParameterTypes[i], parameterTypes[i]);
                    }
                }
            }
        }

        /// <summary>
        ///   Emit the code needed to marshal back the local variables to by-ref parameters.
        /// </summary>
        protected void EmitManagedToNativeMarshallingForByRefParameters(ILGenerator generator, Type[] nativeParameterTypes, ByRefParameter[] byRefLocalVariables)
        {
            for (int i = 0; i < byRefLocalVariables.Length; i++)
            {
                LocalBuilder local = byRefLocalVariables[i].LocalBuilder;
                if (local == null)
                {
                    continue;
                }

                this.EmitManagedToNativeMarshallingCast(generator, local, local.LocalType, i);
            }
        }

        private void EmitManagedToNativeMarshallingCast(ILGenerator generator, LocalBuilder local, Type localType, int i)
        {
            if (TypeHelper.NeedWrapping(localType))
            {
                Label nullValueLabel = generator.DefineLabel();
                Label continueLabel = generator.DefineLabel();

                // Load the target argument on the stack
                // Test for null on the by-ref local
                EmitLoadArgument(generator, i + 2);
                generator.Emit(OpCodes.Ldloc, local);
                generator.Emit(OpCodes.Ldnull);
                generator.Emit(OpCodes.Beq_S, nullValueLabel);

                // If not null, extract the pointer
                generator.Emit(OpCodes.Ldloc, local);
                generator.Emit(OpCodes.Call, EmitInfos.ID_GETNATIVEPOINTER);
                generator.Emit(OpCodes.Br_S, continueLabel);

                // If null, load a zero pointer
                generator.MarkLabel(nullValueLabel);
                generator.Emit(OpCodes.Ldsfld, EmitInfos.INTPTR_ZERO);

                // Store the final result into the target argument
                generator.MarkLabel(continueLabel);
                generator.Emit(OpCodes.Call, EmitInfos.MARSHAL_WRITEINTPTR);
            }
            else if (localType == typeof (bool))
            {
                Label falseValueLabel = generator.DefineLabel();
                Label continueLabel = generator.DefineLabel();

                // Load the target argument on the stack
                // Test for bool equality on the by-ref local
                EmitLoadArgument(generator, i + 2);
                generator.Emit(OpCodes.Ldloc, local);
                generator.Emit(OpCodes.Brfalse, falseValueLabel);

                // Load value 1
                generator.Emit(OpCodes.Ldc_I4_1);
                generator.Emit(OpCodes.Br, continueLabel);

                // Load value 0
                generator.MarkLabel(falseValueLabel);
                generator.Emit(OpCodes.Ldc_I4_0);

                generator.MarkLabel(continueLabel);
                generator.Emit(OpCodes.Call, EmitInfos.MARSHAL_WRITEINT32);
            }
            else if (localType == typeof (byte))
            {
                EmitLoadArgument(generator, i + 2);
                generator.Emit(OpCodes.Ldloc, local);
                generator.Emit(OpCodes.Call, EmitInfos.MARSHAL_WRITEBYTE);
            }
            else if (localType == typeof (char))
            {
                EmitLoadArgument(generator, i + 2);
                generator.Emit(OpCodes.Ldloc, local);
                generator.Emit(OpCodes.Call, EmitInfos.MARSHAL_WRITECHAR);
            }
            else if (localType == typeof (short))
            {
                EmitLoadArgument(generator, i + 2);
                generator.Emit(OpCodes.Ldloc, local);
                generator.Emit(OpCodes.Call, EmitInfos.MARSHAL_WRITEINT16);
            }
            else if (localType == typeof (ushort))
            {
                EmitLoadArgument(generator, i + 2);
                generator.Emit(OpCodes.Ldloc, local);
                generator.Emit(OpCodes.Conv_I2, local);
                generator.Emit(OpCodes.Call, EmitInfos.MARSHAL_WRITEINT16);
            }
            else if (localType == typeof (int) || localType == typeof (uint))
            {
                EmitLoadArgument(generator, i + 2);
                generator.Emit(OpCodes.Ldloc, local);
                generator.Emit(OpCodes.Call, EmitInfos.MARSHAL_WRITEINT32);
            }
            else if (localType == typeof (long) || localType == typeof (ulong))
            {
                EmitLoadArgument(generator, i + 2);
                generator.Emit(OpCodes.Ldloc, local);
                generator.Emit(OpCodes.Call, EmitInfos.MARSHAL_WRITEINT64);
            }
            else if (localType == typeof (IntPtr) || localType == typeof (UIntPtr))
            {
                EmitLoadArgument(generator, i + 2);
                generator.Emit(OpCodes.Ldloc, local);
                generator.Emit(OpCodes.Call, EmitInfos.MARSHAL_WRITEINTPTR);
            }
            else if (localType.IsEnum)
            {
                Type baseType = Enum.GetUnderlyingType(localType);
                Type underlyingType = TypeHelper.GetUnderlyingType(localType, this.Is64Bits);

                if (baseType != underlyingType)
                {
                    if (baseType == typeof (int) && underlyingType == typeof (long))
                    {
                        EmitLoadArgument(generator, i + 2);
                        generator.Emit(OpCodes.Ldloc, local);
                        generator.Emit(OpCodes.Conv_I8);
                        generator.Emit(OpCodes.Call, EmitInfos.MARSHAL_WRITEINT64);
                    }
                    else if (baseType == typeof (uint) && underlyingType == typeof (ulong))
                    {
                        EmitLoadArgument(generator, i + 2);
                        generator.Emit(OpCodes.Ldloc, local);
                        generator.Emit(OpCodes.Conv_U8);
                        generator.Emit(OpCodes.Call, EmitInfos.MARSHAL_WRITEINT64);
                    }
                    else
                    {
                        throw new ObjectiveCCodeGenerationException(String.Format(CultureInfo.CurrentCulture, Resources.CannotGenerateCodeByRefParameterNotSupported, localType.FullName));
                    }
                }
                else
                {
                    this.EmitManagedToNativeMarshallingCast(generator, local, baseType, i);
                }
            }
            else if (localType.IsValueType)
            {
                Type underlyingType = TypeHelper.GetUnderlyingType(localType, this.Is64Bits);
                if (localType != underlyingType)
                {
                    // Store the final result into the target argument
                    generator.Emit(OpCodes.Ldloc, local);
                    EmitHelper.CastValueType(generator, localType, underlyingType);
                    generator.Emit(OpCodes.Box, underlyingType);
                    EmitLoadArgument(generator, i + 2);
                    generator.Emit(OpCodes.Ldc_I4_0);
                    generator.Emit(OpCodes.Call, EmitInfos.MARSHAL_STRUCTURETOPTR);
                }
                else
                {
                    // Store the final result into the target argument
                    generator.Emit(OpCodes.Ldloc, local);
                    generator.Emit(OpCodes.Box, localType);
                    EmitLoadArgument(generator, i + 2);
                    generator.Emit(OpCodes.Ldc_I4_0);
                    generator.Emit(OpCodes.Call, EmitInfos.MARSHAL_STRUCTURETOPTR);
                }
            }
            else
            {
                throw new ObjectiveCCodeGenerationException(String.Format(CultureInfo.CurrentCulture, Resources.CannotGenerateCodeByRefParameterNotSupported, localType.FullName));
            }
        }

        protected static void EmitLoadArgument(ILGenerator generator, int index)
        {
            switch (index)
            {
                case 0:
                    generator.Emit(OpCodes.Ldarg_0);
                    break;
                case 1:
                    generator.Emit(OpCodes.Ldarg_1);
                    break;
                case 2:
                    generator.Emit(OpCodes.Ldarg_2);
                    break;
                case 3:
                    generator.Emit(OpCodes.Ldarg_3);
                    break;
                default:
                    generator.Emit(OpCodes.Ldarg_S, index);
                    break;
            }
        }

        /// <summary>
        ///   Gets the return type of the method base.
        /// </summary>
        protected static Type GetReturnType(MethodBase methodBase)
        {
            return methodBase.IsConstructor ? methodBase.DeclaringType : ((MethodInfo) methodBase).ReturnType;
        }

        /// <summary>
        ///   Gets a unique name of the method base.
        /// </summary>
        protected static String GetUniqueName(MethodBase methodBase)
        {
            StringBuilder builder = new StringBuilder(methodBase.IsConstructor ? "InitWith" : methodBase.Name);
            ParameterInfo[] parameterInfos = methodBase.GetParameters();
            Array.ForEach(parameterInfos, p => builder.AppendFormat(CultureInfo.CurrentCulture, "_{0}", p.ParameterType.FullName.Replace("&", String.Empty).Replace(".", "_")));
            return builder.ToString();
        }
    }
}