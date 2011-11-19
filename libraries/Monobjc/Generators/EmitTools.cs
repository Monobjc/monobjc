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
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using Monobjc.Utils;

namespace Monobjc.Generators
{
    internal static class EmitConstants
    {
        public const TypeAttributes PUBLIC_TYPE = TypeAttributes.Class |
                                                  TypeAttributes.Public |
                                                  TypeAttributes.BeforeFieldInit;

        public const TypeAttributes PUBLIC_STATIC_TYPE = TypeAttributes.Class |
                                                         TypeAttributes.Public |
                                                         TypeAttributes.Abstract |
                                                         TypeAttributes.Sealed |
                                                         TypeAttributes.BeforeFieldInit;

        public const TypeAttributes PUBLIC_NESTED_TYPE = TypeAttributes.Class |
                                                         TypeAttributes.NestedPublic |
                                                         TypeAttributes.Sealed;

        public const FieldAttributes PUBLIC_FIELD_READONLY = FieldAttributes.Public |
                                                             FieldAttributes.InitOnly;

        public const FieldAttributes PUBLIC_STATIC_FIELD_READONLY = FieldAttributes.Public |
                                                                    FieldAttributes.Static |
                                                                    FieldAttributes.InitOnly;

        public const MethodAttributes PUBLIC_CONSTRUCTOR = MethodAttributes.Public |
                                                           MethodAttributes.HideBySig |
                                                           MethodAttributes.SpecialName |
                                                           MethodAttributes.RTSpecialName;

        public const MethodAttributes PRIVATE_STATIC_CONSTRUCTOR = MethodAttributes.Private |
                                                                   MethodAttributes.Static |
                                                                   MethodAttributes.SpecialName |
                                                                   MethodAttributes.RTSpecialName;

        public const MethodAttributes PUBLIC_METHOD = MethodAttributes.Public |
                                                      MethodAttributes.HideBySig;

        public const MethodAttributes PUBLIC_METHOD_OVERRIDE = MethodAttributes.Public |
                                                               MethodAttributes.HideBySig |
                                                               MethodAttributes.NewSlot |
                                                               MethodAttributes.Virtual;

        public const MethodAttributes PUBLIC_METHOD_OVERRIDE_FINAL = MethodAttributes.Public |
                                                                     MethodAttributes.Final |
                                                                     MethodAttributes.Virtual |
                                                                     MethodAttributes.HideBySig |
                                                                     MethodAttributes.NewSlot;

        public const MethodAttributes PUBLIC_METHOD_GET_SET = MethodAttributes.Public |
                                                              MethodAttributes.HideBySig |
                                                              MethodAttributes.SpecialName |
                                                              MethodAttributes.Virtual;

        public const MethodAttributes PUBLIC_METHOD_GET_SET_VIRTUAL = MethodAttributes.Public |
                                                                      MethodAttributes.SpecialName |
                                                                      MethodAttributes.NewSlot |
                                                                      MethodAttributes.Virtual |
                                                                      MethodAttributes.HideBySig;

        public const MethodAttributes PUBLIC_METHOD_GET_SET_FINAL = MethodAttributes.Public |
                                                                    MethodAttributes.Final |
                                                                    MethodAttributes.SpecialName |
                                                                    MethodAttributes.NewSlot |
                                                                    MethodAttributes.Virtual |
                                                                    MethodAttributes.HideBySig;

        public const MethodAttributes PUBLIC_METHOD_VIRTUAL = MethodAttributes.Public |
                                                              MethodAttributes.Virtual |
                                                              MethodAttributes.HideBySig;

        public const MethodAttributes PUBLIC_METHOD_STATIC = MethodAttributes.Public |
                                                             MethodAttributes.Static |
                                                             MethodAttributes.HideBySig;

        public const MethodAttributes PUBLIC_METHOD_PINVOKE = MethodAttributes.Public |
                                                              MethodAttributes.Static |
                                                              MethodAttributes.PinvokeImpl |
                                                              MethodAttributes.HideBySig;
    }

    internal static class EmitInfos
    {
#if MACOSX_10_6
        public static readonly ConstructorInfo BLOCK_CONSTRUCTOR_DELEGATE = typeof (Block).GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, new[] {typeof (Delegate)}, null);
        public static readonly MethodInfo BLOCK_GET_INVOKER = typeof (Block).GetProperty("Invoker").GetGetMethod();
#endif
        public static readonly ConstructorInfo ID_CONSTRUCTOR_INTPTR = typeof (Id).GetConstructor(new[] {typeof (IntPtr)});
        public static readonly MethodInfo ID_GETNATIVEPOINTER = typeof (Id).GetProperty("NativePointer").GetGetMethod();
        public static readonly MethodInfo ID_OP_EQUALITY = typeof (Id).GetMethod("op_Equality", new[] {typeof (Id), typeof (Id)});
        public static readonly MethodInfo IMANAGEDWRAPPER_GETNATIVEPOINTER = typeof (IManagedWrapper).GetProperty("NativePointer").GetGetMethod();
        public static readonly FieldInfo INTPTR_ZERO = typeof (IntPtr).GetField("Zero");
        public static readonly MethodInfo MARSHAL_READBYTE = typeof (Marshal).GetMethod("ReadByte", new[] {typeof (IntPtr)});
        public static readonly MethodInfo MARSHAL_READINT16 = typeof (Marshal).GetMethod("ReadInt16", new[] {typeof (IntPtr)});
        public static readonly MethodInfo MARSHAL_READINT32 = typeof (Marshal).GetMethod("ReadInt32", new[] {typeof (IntPtr)});
        public static readonly MethodInfo MARSHAL_READINT64 = typeof (Marshal).GetMethod("ReadInt64", new[] {typeof (IntPtr)});
        public static readonly MethodInfo MARSHAL_READINTPTR = typeof (Marshal).GetMethod("ReadIntPtr", new[] {typeof (IntPtr)});
        public static readonly MethodInfo MARSHAL_PTRTOSTRUCTURE = typeof (Marshal).GetMethod("PtrToStructure", new[] {typeof (IntPtr), typeof (Type)});
        public static readonly MethodInfo MARSHAL_STRUCTURETOPTR = typeof (Marshal).GetMethod("StructureToPtr", new[] {typeof (Object), typeof (IntPtr), typeof (bool)});
        public static readonly MethodInfo MARSHAL_WRITEBYTE = typeof (Marshal).GetMethod("WriteByte", new[] {typeof (IntPtr), typeof (byte)});
        public static readonly MethodInfo MARSHAL_WRITECHAR = typeof (Marshal).GetMethod("WriteInt16", new[] {typeof (IntPtr), typeof (char)});
        public static readonly MethodInfo MARSHAL_WRITEINT16 = typeof (Marshal).GetMethod("WriteInt16", new[] {typeof (IntPtr), typeof (Int16)});
        public static readonly MethodInfo MARSHAL_WRITEINT32 = typeof (Marshal).GetMethod("WriteInt32", new[] {typeof (IntPtr), typeof (Int32)});
        public static readonly MethodInfo MARSHAL_WRITEINT64 = typeof (Marshal).GetMethod("WriteInt64", new[] {typeof (IntPtr), typeof (Int64)});
        public static readonly MethodInfo MARSHAL_WRITEINTPTR = typeof (Marshal).GetMethod("WriteIntPtr", new[] {typeof (IntPtr), typeof (IntPtr)});
        public static readonly MethodInfo OBJECTIVECRUNTIME_GETINSTANCE = typeof (ObjectiveCRuntime).GetMethod("GetInstance", new[] {typeof (IntPtr)});

        public static readonly MethodInfo OBJECTIVECRUNTIME_SENDMESSAGE_VOID_ARGS = typeof (ObjectiveCRuntime).GetMethod("SendMessage", BindingFlags.Public | BindingFlags.Static, new GenericMethodBinder(false),
                                                                                                                         new[] {typeof (IManagedWrapper), typeof (String), typeof (Object[])}, null);

        public static readonly MethodInfo OBJECTIVECRUNTIME_SENDMESSAGE_ARGS_GENERIC = typeof (ObjectiveCRuntime).GetMethod("SendMessage", BindingFlags.Public | BindingFlags.Static, new GenericMethodBinder(true),
                                                                                                                            new[] {typeof (IManagedWrapper), typeof (String), typeof (Object[])}, null);

        public static readonly MethodInfo TYPE_GETTYPEFROMHANDLE = typeof (Type).GetMethod("GetTypeFromHandle", new[] {typeof (RuntimeTypeHandle)});
    }

    internal static class EmitHelper
    {
        public static TypeBuilder DefineType(ModuleBuilder moduleBuilder, String name)
        {
            return DefineType(moduleBuilder, name, typeof (Object), false);
        }

        public static TypeBuilder DefineType(ModuleBuilder moduleBuilder, String name, bool isStatic)
        {
            return DefineType(moduleBuilder, name, typeof (Object), isStatic);
        }

        public static TypeBuilder DefineType(ModuleBuilder moduleBuilder, String name, Type parentType)
        {
            return DefineType(moduleBuilder, name, parentType, false);
        }

        public static TypeBuilder DefineType(ModuleBuilder moduleBuilder, String name, Type parentType, bool isStatic)
        {
            return moduleBuilder.DefineType(name, isStatic ? EmitConstants.PUBLIC_STATIC_TYPE : EmitConstants.PUBLIC_TYPE, parentType);
        }

        public static TypeBuilder DefineDelegate(ModuleBuilder typeBuilder, String delegateName, Type returnType, Type[] parameterTypes, String[] parameterNames)
        {
            // Parameter types for BeginInvoker are: parameterTypes + AsyncCallback + Object
            Type[] beginInvokeParameterTypes = ArrayHelper.Append(parameterTypes, typeof (AsyncCallback), typeof (Object));

            // Put names on parameters to ease debugging
            String[] beginInvokeParameterNames = new String[beginInvokeParameterTypes.Length];
            Array.Copy(parameterNames, beginInvokeParameterNames, parameterNames.Length);
            beginInvokeParameterNames[parameterTypes.Length] = "callback";
            beginInvokeParameterNames[parameterTypes.Length + 1] = "object";

            TypeBuilder delegateBuilder = DefineType(typeBuilder, delegateName, typeof (MulticastDelegate));

            DefineConstructor(delegateBuilder, MethodImplAttributes.Runtime, new[] {typeof (Object), typeof (IntPtr)}, new[] {"object", "method"});
            DefineOverrideMethod(delegateBuilder, MethodImplAttributes.Runtime, "Invoke", returnType, parameterTypes, parameterNames);
            DefineOverrideMethod(delegateBuilder, MethodImplAttributes.Runtime, "BeginInvoke", typeof (IAsyncResult), beginInvokeParameterTypes, beginInvokeParameterNames);
            DefineOverrideMethod(delegateBuilder, MethodImplAttributes.Runtime, "EndInvoke", returnType, new[] {typeof (IAsyncResult)}, new[] {"result"});

            return delegateBuilder;
        }

        public static FieldBuilder DefineField(TypeBuilder typeBuilder, String fieldName, Type fieldType, bool isStatic)
        {
            return typeBuilder.DefineField(fieldName, fieldType, isStatic ? EmitConstants.PUBLIC_STATIC_FIELD_READONLY : EmitConstants.PUBLIC_FIELD_READONLY);
        }

        public static ConstructorBuilder DefineDefaultConstructor(TypeBuilder typeBuilder)
        {
            ConstructorBuilder constructorBuilder = typeBuilder.DefineDefaultConstructor(EmitConstants.PUBLIC_CONSTRUCTOR);
            return constructorBuilder;
        }

        public static ConstructorBuilder DefineStaticConstructor(TypeBuilder typeBuilder)
        {
            return typeBuilder.DefineConstructor(EmitConstants.PRIVATE_STATIC_CONSTRUCTOR, CallingConventions.Standard, Type.EmptyTypes);
        }

        public static ConstructorBuilder DefineConstructor(TypeBuilder typeBuilder, Type[] parameterTypes)
        {
            return DefineConstructor(typeBuilder, MethodImplAttributes.IL, parameterTypes);
        }

        public static ConstructorBuilder DefineConstructor(TypeBuilder typeBuilder, MethodImplAttributes attributes, Type[] parameterTypes)
        {
            return DefineConstructor(typeBuilder, attributes, parameterTypes, new String[parameterTypes.Length]);
        }

        public static ConstructorBuilder DefineConstructor(TypeBuilder typeBuilder, MethodImplAttributes attributes, Type[] parameterTypes, String[] parameterNames)
        {
            ConstructorBuilder constructorBuilder = typeBuilder.DefineConstructor(EmitConstants.PUBLIC_CONSTRUCTOR, CallingConventions.Standard, parameterTypes);
            constructorBuilder.SetImplementationFlags(attributes);
            for (int i = 0; i < parameterNames.Length; i++)
            {
                if (parameterNames[i] != null)
                {
                    constructorBuilder.DefineParameter(i + 1, ParameterAttributes.None, parameterNames[i]);
                }
            }
            return constructorBuilder;
        }

        public static MethodBuilder DefineOverrideMethod(TypeBuilder typeBuilder, String name, Type returnType, Type[] parameterTypes)
        {
            return DefineOverrideMethod(typeBuilder, MethodImplAttributes.IL, name, returnType, parameterTypes);
        }

        public static MethodBuilder DefineOverrideMethod(TypeBuilder typeBuilder, MethodImplAttributes attributes, String name, Type returnType, Type[] parameterTypes)
        {
            return DefineOverrideMethod(typeBuilder, attributes, name, returnType, parameterTypes, new String[parameterTypes.Length]);
        }

        public static MethodBuilder DefineOverrideMethod(TypeBuilder typeBuilder, MethodImplAttributes attributes, String name, Type returnType, Type[] parameterTypes, String[] parameterNames)
        {
            MethodBuilder methodBuilder = typeBuilder.DefineMethod(name, EmitConstants.PUBLIC_METHOD_OVERRIDE, returnType, parameterTypes);
            methodBuilder.SetImplementationFlags(attributes);
            for (int i = 0; i < parameterNames.Length; i++)
            {
                if (parameterNames[i] != null)
                {
                    methodBuilder.DefineParameter(i + 1, ParameterAttributes.None, parameterNames[i]);
                }
            }
            return methodBuilder;
        }

        public static TypeBuilder DefineNestedDelegate(TypeBuilder typeBuilder, String delegateName, Type returnType, Type[] parameterTypes, String[] parameterNames)
        {
            ConstructorBuilder constructorBuilder;
            return DefineNestedDelegate(typeBuilder, delegateName, returnType, parameterTypes, parameterNames, out constructorBuilder);
        }

        public static TypeBuilder DefineNestedDelegate(TypeBuilder typeBuilder, String delegateName, Type returnType, Type[] parameterTypes, String[] parameterNames, out ConstructorBuilder constructorBuilder)
        {
            // Parameter types for BeginInvoker are: parameterTypes + AsyncCallback + Object
            Type[] beginInvokeParameterTypes = ArrayHelper.Append(parameterTypes, typeof (AsyncCallback), typeof (Object));

            // Put names on parameters to ease debugging
            String[] beginInvokeParameterNames = new String[beginInvokeParameterTypes.Length];
            Array.Copy(parameterNames, beginInvokeParameterNames, parameterNames.Length);
            beginInvokeParameterNames[parameterTypes.Length] = "callback";
            beginInvokeParameterNames[parameterTypes.Length + 1] = "object";

            // Create the nested type
            TypeBuilder delegateBuilder = typeBuilder.DefineNestedType(delegateName, EmitConstants.PUBLIC_NESTED_TYPE, typeof (MulticastDelegate));

            constructorBuilder = DefineConstructor(delegateBuilder, MethodImplAttributes.Runtime, new[] {typeof (Object), typeof (IntPtr)}, new[] {"object", "method"});
            DefineOverrideMethod(delegateBuilder, MethodImplAttributes.Runtime, "Invoke", returnType, parameterTypes, parameterNames);
            DefineOverrideMethod(delegateBuilder, MethodImplAttributes.Runtime, "BeginInvoke", typeof (IAsyncResult), beginInvokeParameterTypes, beginInvokeParameterNames);
            DefineOverrideMethod(delegateBuilder, MethodImplAttributes.Runtime, "EndInvoke", returnType, new[] {typeof (IAsyncResult)}, new[] {"result"});

            return delegateBuilder;
        }

        public static void CastValueType(ILGenerator generator, Type sourceType, Type targetType)
        {
            if (sourceType.Equals(targetType))
            {
                return;
            }

            if (sourceType.IsEnum)
            {
                Type baseType = Enum.GetUnderlyingType(sourceType);
                if (!baseType.Equals(targetType))
                {
                    if (targetType == typeof (long) && baseType == typeof (int))
                    {
                        generator.Emit(OpCodes.Conv_I8);
                    }
                    else if (targetType == typeof (ulong) && baseType == typeof (uint))
                    {
                        generator.Emit(OpCodes.Conv_U8);
                    }
                    else
                    {
                        throw new NotSupportedException("1. Cannot cast from " + sourceType + " to " + targetType);
                    }
                }
            }
            else if (targetType.IsEnum)
            {
                Type baseType = Enum.GetUnderlyingType(targetType);
                if (!baseType.Equals(sourceType))
                {
                    if (sourceType == typeof (long) && baseType == typeof (int))
                    {
                        generator.Emit(OpCodes.Conv_I4);
                    }
                    else if (sourceType == typeof (ulong) && baseType == typeof (uint))
                    {
                        generator.Emit(OpCodes.Conv_U4);
                    }
                    else
                    {
                        throw new NotSupportedException("2. Cannot cast from " + sourceType + " to " + targetType);
                    }
                }
            }
            else
            {
                Binder binder = new ImplicitMethodBinder(sourceType, targetType);
                MethodInfo converter = sourceType.GetMethod("op_Implicit", BindingFlags.Public | BindingFlags.Static, binder, new[] {sourceType}, null) ??
                                       targetType.GetMethod("op_Implicit", BindingFlags.Public | BindingFlags.Static, binder, new[] {sourceType}, null);
                if (converter != null)
                {
                    generator.Emit(OpCodes.Call, converter);
                }
                else
                {
                    throw new NotSupportedException("3. Cannot cast from " + sourceType + " to " + targetType);
                }
            }
        }
    }
}