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

namespace Monobjc.Generators
{
	internal partial class WrapperGenerator
	{
		private static void EmitMethodBody (MethodBuilder methodBuilder, MethodInfo methodInfo, String message)
		{
			Type returnType = methodInfo.ReturnType;
			ILGenerator generator = methodBuilder.GetILGenerator ();
			ParameterInfo[] parameterInfos = methodInfo.GetParameters ();

			if (returnType == typeof(void)) {
				MethodInfo sendMessageInvoker = EmitInfos.OBJECTIVECRUNTIME_SENDMESSAGE_VOID_ARGS;

				// Makes the actual call
				generator.Emit (OpCodes.Ldarg_0);
				generator.Emit (OpCodes.Ldstr, message);
				EmitParametersAsArrayOnStack (generator, parameterInfos);
				generator.Emit (OpCodes.Call, sendMessageInvoker);

				generator.Emit (OpCodes.Ret);
			} else {
				MethodInfo sendMessageInvoker = EmitInfos.OBJECTIVECRUNTIME_SENDMESSAGE_ARGS_GENERIC.MakeGenericMethod (returnType);

				// Makes the actual call
				generator.Emit (OpCodes.Ldarg_0);
				generator.Emit (OpCodes.Ldstr, message);
				EmitParametersAsArrayOnStack (generator, parameterInfos);
				generator.Emit (OpCodes.Call, sendMessageInvoker);

				generator.Emit (OpCodes.Ret);
			}
		}

		/// <summary>
		///   Create an object array and put the method arguments in it, then load the array on the stack
		/// </summary>
		private static void EmitParametersAsArrayOnStack (ILGenerator generator, IList<ParameterInfo> infos)
		{
			int size = infos.Count;

			// Create a local variable to hold the array
			LocalBuilder array = generator.DeclareLocal (typeof(Object[]));

			// Load array size on the stack
			switch (size) {
			case 0:
				generator.Emit (OpCodes.Ldc_I4_0);
				break;
			case 1:
				generator.Emit (OpCodes.Ldc_I4_1);
				break;
			case 2:
				generator.Emit (OpCodes.Ldc_I4_2);
				break;
			case 3:
				generator.Emit (OpCodes.Ldc_I4_3);
				break;
			case 4:
				generator.Emit (OpCodes.Ldc_I4_4);
				break;
			case 5:
				generator.Emit (OpCodes.Ldc_I4_5);
				break;
			case 6:
				generator.Emit (OpCodes.Ldc_I4_6);
				break;
			case 7:
				generator.Emit (OpCodes.Ldc_I4_7);
				break;
			case 8:
				generator.Emit (OpCodes.Ldc_I4_8);
				break;
			default:
				generator.Emit (OpCodes.Ldc_I4, size);
				break;
			}

			// Create the array
			generator.Emit (OpCodes.Newarr, typeof(Object));

			// Don't bother putting the array on the stack if there is no argument
			if (size == 0) {
				return;
			}

			generator.Emit (OpCodes.Stloc, array);

			for (int i = 0; i < size; i++) {
				ParameterInfo info = infos [i];

				// Load array to fill
				generator.Emit (OpCodes.Ldloc, array);

				// Load array index to fill
				switch (i) {
				case 0:
					generator.Emit (OpCodes.Ldc_I4_0);
					break;
				case 1:
					generator.Emit (OpCodes.Ldc_I4_1);
					break;
				case 2:
					generator.Emit (OpCodes.Ldc_I4_2);
					break;
				case 3:
					generator.Emit (OpCodes.Ldc_I4_3);
					break;
				case 4:
					generator.Emit (OpCodes.Ldc_I4_4);
					break;
				case 5:
					generator.Emit (OpCodes.Ldc_I4_5);
					break;
				case 6:
					generator.Emit (OpCodes.Ldc_I4_6);
					break;
				case 7:
					generator.Emit (OpCodes.Ldc_I4_7);
					break;
				case 8:
					generator.Emit (OpCodes.Ldc_I4_8);
					break;
				default:
					generator.Emit (OpCodes.Ldc_I4, size);
					break;
				}

				// Load value to put
				// As 'this' is the first argument (arg0), we need to shift the argument following
				// Parameter 0 from method is arg1 in IL
				// Parameter 1 from method is arg2 in IL
				switch (i) {
				case 0:
					generator.Emit (OpCodes.Ldarg_1);
					break;
				case 1:
					generator.Emit (OpCodes.Ldarg_2);
					break;
				case 2:
					generator.Emit (OpCodes.Ldarg_3);
					break;
				default:
					generator.Emit (OpCodes.Ldarg_S, i + 1);
					break;
				}

				// Box value types
				if (info.ParameterType.IsValueType) {
					generator.Emit (OpCodes.Box, info.ParameterType);
				}

				// Store reference in array
				generator.Emit (OpCodes.Stelem_Ref);
			}

			// Load array on stack
			generator.Emit (OpCodes.Ldloc, array);
		}
	}
}