//
// This file is part of Monobjc, a .NET/Objective-C bridge
// Copyright (C) 2007-2013 - Laurent Etiemble
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
	internal partial class BlockGenerator
	{
        private void EmitInvokerBody (ILGenerator generator, MethodInfo methodInfo, Type returnType, Type nativeReturnType, Type[] parameterTypes, Type[] nativeParameterTypes)
		{
			bool isNotVoid = (returnType != typeof(void));

			// Creates local variables for by-ref parameters
            ByRefParameter[] byRefLocalVariables = CreateLocalVariableForByRefParameters (generator, methodInfo.GetParameters ());
            bool hasByRef = byRefLocalVariables.Any (p => p.LocalBuilder != null && !p.IsOut);

            // To store result before return
            LocalBuilder result = (isNotVoid && hasByRef) ? CreateLocalBuilderForInvocationResult(generator, returnType, nativeReturnType) : null;

			// For by-ref parameters passed as reference (without [out] attribute), we first set the value of local variables
			this.EmitNativeToManagedMarshallingForByRefParameters (generator, nativeParameterTypes, byRefLocalVariables);

			// Loads the parameters on the stack.
			// - For regular parameter, values are directly loaded on the stack
			// - For by-ref parameters, local variables are loaded instead.
			EmitParametersLoadingOnStack (generator, parameterTypes, nativeParameterTypes, byRefLocalVariables, 2);

			// Make the call with the delegate
            generator.Emit (OpCodes.Call, methodInfo);

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