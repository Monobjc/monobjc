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
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using Monobjc.Utils;

namespace Monobjc.Generators
{
    internal partial class CategoryGenerator
    {
        /// <summary>
        ///   Defines an inner Delegate type for the method to be invoked from Objective-C runtime.
        /// </summary>
        // TODO: Refactor
        private Type DefineDelegate(TypeBuilder typeBuilder, MethodInfo methodInfo, out ConstructorBuilder constructorBuilder)
        {
            // Get info about the target method
            Type returnType = GetReturnType(methodInfo);
            Type nativeReturnType = TypeHelper.GetNativeType(returnType, this.Is64Bits);
            Type[] nativeParameterTypes = TypeHelper.GetNativeParameterTypes(methodInfo, this.Is64Bits);

            // TODO: Refactor
            // Remove first parameter of the extension method
            nativeParameterTypes = ArrayHelper.TrimLeft(nativeParameterTypes, 1);

            // Create the array of parameters for the delegate's invoke method
            nativeParameterTypes = ArrayHelper.Prepend(nativeParameterTypes, typeof (IntPtr), typeof (IntPtr));

            // Assign some names to parameters (for easy debugging)
            String[] parameterNames = TypeHelper.GetParameterNames(methodInfo);

            // TODO: Refactor
            // Remove first parameter of the extension method
            parameterNames = ArrayHelper.TrimLeft(parameterNames, 1);

            String[] nativeParameterNames = new String[nativeParameterTypes.Length];
            Array.Copy(parameterNames, 0, nativeParameterNames, 2, parameterNames.Length);
            nativeParameterNames[0] = "receiver";
            nativeParameterNames[1] = "selector";

            // Create a unique delegate name
            String name = GetUniqueName(methodInfo) + "_Invoker";

            // Create a delegate
            TypeBuilder delegateBuilder = EmitHelper.DefineNestedDelegate(typeBuilder, name, nativeReturnType, nativeParameterTypes, nativeParameterNames, out constructorBuilder);

            // Generate the type
            return delegateBuilder.CreateType();
        }

        /// <summary>
        ///   Defines a proxy method that is called from Objective-C runtime. This method retrieves the targeted managed instance and passes the parameters.
        /// </summary>
        private MethodBuilder DefineProxyMethod(TypeBuilder typeBuilder, MethodTuple methodTuple)
        {
            // Get info about the target method
            Type returnType = GetReturnType(methodTuple.MethodInfo);
            Type[] parameterTypes = TypeHelper.GetParameterTypes(methodTuple.MethodInfo);
            // The first argument of the extension method is the target type
            // TODO: Refactor
            Type targetType = parameterTypes[0];
            // Remove first parameter of the extension method
            // TODO: Refactor
            parameterTypes = ArrayHelper.TrimLeft(parameterTypes, 1);
            Type nativeReturnType = TypeHelper.GetNativeType(returnType, this.Is64Bits);
            Type[] nativeParameterTypes = TypeHelper.GetNativeParameterTypes(parameterTypes, this.Is64Bits);

            // Create the array of parameters for the proxy method
            Type[] signatureNativeParameterTypes = ArrayHelper.Prepend(nativeParameterTypes, typeof (IntPtr), typeof (IntPtr));

            // Create a unique proxy method name
            String name = GetUniqueName(methodTuple.MethodInfo);

            // Create a proxy method
            MethodBuilder methodBuilder = typeBuilder.DefineMethod(name,
                                                                   EmitConstants.PUBLIC_METHOD_STATIC,
                                                                   nativeReturnType,
                                                                   signatureNativeParameterTypes);

            // Give name to parameters
            methodBuilder.DefineParameter(1, ParameterAttributes.None, "receiver");
            methodBuilder.DefineParameter(2, ParameterAttributes.None, "selector");
            String[] parameterNames = TypeHelper.GetParameterNames(methodTuple.MethodInfo);
            // Remove first parameter of the extension method
            // TODO: Refactor
            parameterNames = ArrayHelper.TrimLeft(parameterNames, 1);
            for (int i = 0; i < parameterNames.Length; i++)
            {
                if (!String.IsNullOrEmpty(parameterNames[i]))
                {
                    methodBuilder.DefineParameter(i + 3, ParameterAttributes.None, parameterNames[i]);
                }
            }

            // Generates body
            ILGenerator generator = methodBuilder.GetILGenerator();

            // Emit the body
            this.EmitProxyMethodBodyForExtensionMethod(generator, methodTuple, targetType, returnType, nativeReturnType, parameterTypes, nativeParameterTypes);

            // Return
            generator.Emit(OpCodes.Ret);

            return methodBuilder;
        }

        private void EmitProxyMethodBodyForExtensionMethod(ILGenerator generator, MethodTuple methodTuple, Type targetType, Type returnType, Type nativeReturnType, Type[] parameterTypes, Type[] nativeParameterTypes)
        {
            bool isNotVoid = (returnType != typeof (void));

            // Creates local variables for by-ref parameters
            ByRefParameter[] byRefLocalVariables = CreateLocalVariableForByRefParameters(generator, methodTuple.MethodInfo.GetParameters());
            bool hasByRef = byRefLocalVariables.Where(p => p.LocalBuilder != null && !p.IsOut).Count() > 0;

            // To store result before return
            LocalBuilder result = null;
            if (isNotVoid && hasByRef)
            {
                if (TypeHelper.NeedWrapping(returnType))
                {
                    result = generator.DeclareLocal(typeof (IntPtr));
                }
                else if (!nativeReturnType.Equals(returnType))
                {
                    result = generator.DeclareLocal(nativeReturnType);
                }
                else
                {
                    result = generator.DeclareLocal(returnType);
                }
            }

            // For by-ref parameters passed as reference (without [out] attribute), we first set the value of local variables
            this.EmitNativeToManagedMarshallingForByRefParameters(generator, nativeParameterTypes, byRefLocalVariables);

            // The target type is the type for which the extension method is declared
            generator.Emit(OpCodes.Ldarg_0);
            MethodInfo wrapInstance = EmitInfos.OBJECTIVECRUNTIME_GETINSTANCE.MakeGenericMethod(new[] {targetType});
            generator.Emit(OpCodes.Call, wrapInstance);

            // Loads the parameters on the stack.
            // - For regular parameter, values are directly loaded on the stack
            // - For by-ref parameters, local variables are loaded instead.
            EmitParametersLoadingOnStack(generator, parameterTypes, nativeParameterTypes, byRefLocalVariables);

            // Make the call on the receiver (direct call as the method is static)
            generator.Emit(OpCodes.Call, methodTuple.MethodInfo);

            // Unwrap result if needed
            if (isNotVoid)
            {
                // Unwraps the result if not null
                if (TypeHelper.NeedWrapping(returnType))
                {
                    Label notNullValueLabel = generator.DefineLabel();
                    Label continueLabel = generator.DefineLabel();

                    // Store result
                    LocalBuilder managedInstance = generator.DeclareLocal(returnType);
                    generator.Emit(OpCodes.Stloc, managedInstance);

                    // Test to see if instance is null
                    generator.Emit(OpCodes.Ldloc, managedInstance);

                    if (returnType.IsInterface)
                    {
                        generator.Emit(OpCodes.Brtrue, notNullValueLabel);
                    }
                    else
                    {
                        generator.Emit(OpCodes.Ldnull);
                        generator.Emit(OpCodes.Call, EmitInfos.ID_OP_EQUALITY);
                        generator.Emit(OpCodes.Brfalse, notNullValueLabel);
                    }

                    // If null, load a zero pointer
                    generator.Emit(OpCodes.Ldsfld, EmitInfos.INTPTR_ZERO);
                    generator.Emit(OpCodes.Br, continueLabel);

                    // If not null, extract the pointer 
                    generator.MarkLabel(notNullValueLabel);
                    generator.Emit(OpCodes.Ldloc, managedInstance);
                    generator.Emit(OpCodes.Callvirt, EmitInfos.IMANAGEDWRAPPER_GETNATIVEPOINTER);

                    generator.MarkLabel(continueLabel);
                }
                else if (!nativeReturnType.Equals(returnType))
                {
                    EmitHelper.CastValueType(generator, returnType, nativeReturnType);
                }

                if (hasByRef)
                {
                    // Store the final result into the local
                    generator.Emit(OpCodes.Stloc, result);
                }
            }

            // Marshal by-ref local variables to their corresponding parameters
            this.EmitManagedToNativeMarshallingForByRefParameters(generator, nativeParameterTypes, byRefLocalVariables);

            if (isNotVoid && hasByRef)
            {
                // Load the result on the stack
                generator.Emit(OpCodes.Ldloc, result);
            }
        }
    }
}