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
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using Monobjc.Utils;

namespace Monobjc.Generators
{
	internal partial class ClassGenerator
	{
		/// <summary>
		///   Defines an inner Delegate type for the method to be invoked from Objective-C runtime.
		/// </summary>
		// TODO: Refactor
		private Type DefineDelegate (TypeBuilder typeBuilder, MethodBase methodInfo, out ConstructorBuilder constructorBuilder)
		{
			// Get info about the target method
			Type returnType = GetReturnType (methodInfo);
			Type nativeReturnType = TypeHelper.GetNativeType (returnType, this.Is64Bits);
			Type[] nativeParameterTypes = TypeHelper.GetNativeParameterTypes (methodInfo, this.Is64Bits);


			// Create the array of parameters for the delegate's invoke method
			nativeParameterTypes = ArrayHelper.Prepend (nativeParameterTypes, typeof(IntPtr), typeof(IntPtr));

			// Assign some names to parameters (for easy debugging)
			String[] parameterNames = TypeHelper.GetParameterNames (methodInfo);


			String[] nativeParameterNames = new String[nativeParameterTypes.Length];
			Array.Copy (parameterNames, 0, nativeParameterNames, 2, parameterNames.Length);
			nativeParameterNames [0] = "receiver";
			nativeParameterNames [1] = "selector";

			// Create a unique delegate name
			String name = GetUniqueName (methodInfo) + "_Invoker";

			// Create a delegate
			TypeBuilder delegateBuilder = EmitHelper.DefineNestedDelegate (typeBuilder, name, nativeReturnType, nativeParameterTypes, nativeParameterNames, out constructorBuilder);

			// Generate the type
			return delegateBuilder.CreateType ();
		}

		/// <summary>
		///   Defines a proxy method that is called from Objective-C runtime. This method retrieves the targeted managed instance and passes the parameters.
		/// </summary>
		private MethodBuilder DefineProxyMethod (TypeBuilder typeBuilder, MethodTuple methodTuple)
		{
			// Get info about the target method
			Type returnType = GetReturnType (methodTuple.MethodInfo);
			Type[] parameterTypes = TypeHelper.GetParameterTypes (methodTuple.MethodInfo);


			Type nativeReturnType = TypeHelper.GetNativeType (returnType, this.Is64Bits);
			Type[] nativeParameterTypes = TypeHelper.GetNativeParameterTypes (parameterTypes, this.Is64Bits);

			// Create the array of parameters for the proxy method
			Type[] signatureNativeParameterTypes = ArrayHelper.Prepend (nativeParameterTypes, typeof(IntPtr), typeof(IntPtr));

			// Create a unique proxy method name
			String name = GetUniqueName (methodTuple.MethodInfo);

			// Create a proxy method
			MethodBuilder methodBuilder = typeBuilder.DefineMethod (name,
                                                                   EmitConstants.PUBLIC_METHOD_STATIC,
                                                                   nativeReturnType,
                                                                   signatureNativeParameterTypes);

			// Give name to parameters
			methodBuilder.DefineParameter (1, ParameterAttributes.None, "receiver");
			methodBuilder.DefineParameter (2, ParameterAttributes.None, "selector");
			String[] parameterNames = TypeHelper.GetParameterNames (methodTuple.MethodInfo);
			for (int i = 0; i < parameterNames.Length; i++) {
				if (!String.IsNullOrEmpty (parameterNames [i])) {
					methodBuilder.DefineParameter (i + 3, ParameterAttributes.None, parameterNames [i]);
				}
			}

			// Generates body
			ILGenerator generator = methodBuilder.GetILGenerator ();

			// We handle different behaviours:
			// - Static Method
			// - Instance Method
			if (methodTuple.MethodInfo.IsStatic) {
				this.EmitProxyMethodBodyForStaticMethod (generator, methodTuple, returnType, nativeReturnType, parameterTypes, nativeParameterTypes);
			} else {
				this.EmitProxyMethodBodyForInstanceMethod (generator, methodTuple, returnType, nativeReturnType, parameterTypes, nativeParameterTypes);
			}

			// Return
			generator.Emit (OpCodes.Ret);

			return methodBuilder;
		}

		private void EmitProxyMethodBodyForStaticMethod (ILGenerator generator, MethodTuple methodTuple, Type returnType, Type nativeReturnType, Type[] parameterTypes, Type[] nativeParameterTypes)
		{
			bool isNotVoid = (returnType != typeof(void));

			// Creates local variables for by-ref parameters
			ByRefParameter[] byRefLocalVariables = CreateLocalVariableForByRefParameters (generator, methodTuple.MethodInfo.GetParameters ());
			bool hasByRef = byRefLocalVariables.Any (p => p.LocalBuilder != null && !p.IsOut);

			// To store result before return
            LocalBuilder result = (isNotVoid && hasByRef) ? CreateLocalBuilderForInvocationResult(generator, returnType, nativeReturnType) : null;

			// For by-ref parameters passed as reference (without [out] attribute), we first set the value of local variables
			this.EmitNativeToManagedMarshallingForByRefParameters (generator, nativeParameterTypes, byRefLocalVariables);

			// Loads the parameters on the stack.
			// - For regular parameter, values are directly loaded on the stack
			// - For by-ref parameters, local variables are loaded instead.
			EmitParametersLoadingOnStack (generator, parameterTypes, nativeParameterTypes, byRefLocalVariables, 2);

			// Make the call on the receiver (direct call as the method is static)
			generator.Emit (OpCodes.Call, methodTuple.MethodInfo);

			// Unwrap result if needed
            if (isNotVoid) {
                UnwrapResultOfInvocation(generator, result, returnType, nativeReturnType, hasByRef);
            }

			// Marshal by-ref local variables to their corresponding parameters
			this.EmitManagedToNativeMarshallingForByRefParameters (generator, nativeParameterTypes, byRefLocalVariables);

			if (isNotVoid && hasByRef) {
				// Load the result on the stack
				generator.Emit (OpCodes.Ldloc, result);
			}
		}

		private void EmitProxyMethodBodyForInstanceMethod (ILGenerator generator, MethodTuple methodTuple, Type returnType, Type nativeReturnType, Type[] parameterTypes, Type[] nativeParameterTypes)
		{
			bool isNotVoid = (returnType != typeof(void));

			// Creates local variables for by-ref parameters
			ByRefParameter[] byRefLocalVariables = CreateLocalVariableForByRefParameters (generator, methodTuple.MethodInfo.GetParameters ());
			bool hasByRef = byRefLocalVariables.Any (p => p.LocalBuilder != null && !p.IsOut);

			// To store result before return
            LocalBuilder result = (isNotVoid && hasByRef) ? CreateLocalBuilderForInvocationResult(generator, returnType, nativeReturnType) : null;

			// For by-ref parameters passed as reference (without [out] attribute), we first set the value of local variables
			this.EmitNativeToManagedMarshallingForByRefParameters (generator, nativeParameterTypes, byRefLocalVariables);

            // Load the receiver on the stack
            generator.Emit (OpCodes.Ldarg_0);
            MethodInfo wrapInstance = EmitInfos.OBJECTIVECRUNTIME_GETINSTANCE.MakeGenericMethod (new[] {methodTuple.MethodInfo.DeclaringType});
            generator.Emit (OpCodes.Call, wrapInstance);

			// Loads the parameters on the stack.
			// - For regular parameter, values are directly loaded on the stack
			// - For by-ref parameters, local variables are loaded instead.
			EmitParametersLoadingOnStack (generator, parameterTypes, nativeParameterTypes, byRefLocalVariables, 2);

			// Make the call on the receiver
			generator.Emit (OpCodes.Call, methodTuple.MethodInfo);

			// Unwrap result if needed
			if (isNotVoid) {
                UnwrapResultOfInvocation(generator, result, returnType, nativeReturnType, hasByRef);
			}

			// Marshal by-ref local variables to their corresponding parameters
			this.EmitManagedToNativeMarshallingForByRefParameters (generator, nativeParameterTypes, byRefLocalVariables);

			if (isNotVoid && hasByRef) {
				// Load the result on the stack
				generator.Emit (OpCodes.Ldloc, result);
			}
		}
	}
}