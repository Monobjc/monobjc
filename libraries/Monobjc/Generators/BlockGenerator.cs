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
using System.Reflection;
using System.Reflection.Emit;
using Monobjc.Properties;
using Monobjc.Utils;

namespace Monobjc.Generators
{
    /// <summary>
	///   Code generator that produces block proxies.
	/// </summary>
	internal partial class BlockGenerator : CodeGenerator
	{
		// Common prefix for dynamically generated proxies
		private const String NAME_PREFIX = "Monobjc.Dynamic.Blocks.Block";

		// Layout field name
		private const String LAYOUT_FIELD = "layout";

		// Argument prefix
		private const String ARG_PREFIX = "arg";

		/// <summary>
		///   Initializes a new instance of the <see cref = "BlockGenerator" /> class.
		/// </summary>
		/// <param name = "assembly">The assembly.</param>
		/// <param name = "is64Bits"></param>
		public BlockGenerator (DynamicAssembly assembly, bool is64Bits) : base(assembly, is64Bits)
		{
		}

		/// <summary>
		///   Defines a block proxy to bridge the given type of delegate.
		/// </summary>
		/// <param name = "delegateType">Type of the delegate.</param>
		/// <returns>A dynamically created type that can bridge the given type of delegate.</returns>
		public Type DefineBlockProxy (Type delegateType)
		{
			if (delegateType == null) {
				throw new ArgumentNullException ("delegateType");
			}
			if (!typeof(Delegate).IsAssignableFrom (delegateType)) {
				throw new ObjectiveCCodeGenerationException (Resources.BlockIsNotDelegateSubclass);
			}

			// Retrieve more information on the delegate type
			MethodInfo delegateMethodInfo = delegateType.GetMethod ("Invoke"); // <-- Invoke method of delegate
			Type returnType = delegateMethodInfo.ReturnType;
			Type nativeReturnType = TypeHelper.GetNativeType (returnType, this.Is64Bits);
			Type[] parameterTypes = TypeHelper.GetParameterTypes (delegateMethodInfo);
			Type[] nativeParameterTypes = TypeHelper.GetNativeParameterTypes (delegateMethodInfo, this.Is64Bits);

			// Create the array of parameters for the delegate's invoke method
			Type[] invokerParameterTypes = ArrayHelper.Prepend (nativeParameterTypes, typeof(IntPtr));
			String[] invokerParameterNames = new String[invokerParameterTypes.Length];
			invokerParameterNames [0] = LAYOUT_FIELD;
			for (int i = 1; i < invokerParameterNames.Length; i++) {
				invokerParameterNames [i] = ARG_PREFIX + i;
			}

			// Compute the name of the proxy
			String typeName = GetUniqueName (returnType, parameterTypes);

			if (Logger.DebugEnabled) {
				Logger.Debug ("BlockGenerator", "Generating Block Proxy: " + typeName);
			}

			// Create a type builder
			TypeBuilder typeBuilder = this.Assembly.AddType (typeName, typeof(Block));

			// Create a nested delegate
			ConstructorBuilder nestedDelegateConstructorBuilder;
			TypeBuilder delegateBuilder = EmitHelper.DefineNestedDelegate (typeBuilder, "ExecuteInvoker", nativeReturnType, invokerParameterTypes, invokerParameterNames, out nestedDelegateConstructorBuilder);
			delegateBuilder.CreateType ();

			// Field storage for the block invoker
			FieldBuilder fieldBuilder = EmitHelper.DefineField (typeBuilder, "blockInvoker", delegateBuilder, false);

			// Execute method
			MethodBuilder methodBuilder = typeBuilder.DefineMethod ("Execute", EmitConstants.PUBLIC_METHOD, nativeReturnType, invokerParameterTypes);
			methodBuilder.DefineParameter (1, ParameterAttributes.None, LAYOUT_FIELD);
			for (int i = 1; i < invokerParameterNames.Length; i++) {
				methodBuilder.DefineParameter (i + 1, ParameterAttributes.None, ARG_PREFIX + i);
			}
			ILGenerator generator = methodBuilder.GetILGenerator ();

			// Retrieve the invoker field
            // Cast it to the delegate
			generator.Emit (OpCodes.Ldarg_0);
			generator.Emit (OpCodes.Call, EmitInfos.BLOCK_GET_INVOKER);
			generator.Emit (OpCodes.Castclass, delegateType);

            EmitInvokerBody(generator, delegateMethodInfo, returnType, nativeReturnType, parameterTypes, nativeParameterTypes);
            generator.Emit (OpCodes.Ret);

			// Constructor
			ConstructorBuilder constructorBuilder = EmitHelper.DefineConstructor (typeBuilder, new[] {typeof(Delegate)});
			constructorBuilder.DefineParameter (1, ParameterAttributes.None, "block");
			generator = constructorBuilder.GetILGenerator ();
			generator.Emit (OpCodes.Ldarg_0);
			generator.Emit (OpCodes.Ldarg_1);
			generator.Emit (OpCodes.Call, EmitInfos.BLOCK_CONSTRUCTOR_DELEGATE);
			generator.Emit (OpCodes.Ldarg_0);
			generator.Emit (OpCodes.Ldarg_0);
			generator.Emit (OpCodes.Ldftn, methodBuilder);
			generator.Emit (OpCodes.Newobj, nestedDelegateConstructorBuilder);
			generator.Emit (OpCodes.Stfld, fieldBuilder);
			generator.Emit (OpCodes.Ret);

			// Get Accessor
			methodBuilder = typeBuilder.DefineMethod ("get_BlockInvoker", EmitConstants.PUBLIC_METHOD_GET_SET, typeof(Delegate), null);
			generator = methodBuilder.GetILGenerator ();
			generator.Emit (OpCodes.Ldarg_0);
			generator.Emit (OpCodes.Ldfld, fieldBuilder);
			generator.Emit (OpCodes.Ret);

			// Property
			PropertyBuilder propertyBuilder = typeBuilder.DefineProperty ("BlockInvoker", PropertyAttributes.None, typeof(Delegate), null);
			propertyBuilder.SetGetMethod (methodBuilder);

			return typeBuilder.CreateType ();
		}
	}
}