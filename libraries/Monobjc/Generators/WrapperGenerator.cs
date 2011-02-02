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
using Monobjc.Properties;
using Monobjc.Utils;

namespace Monobjc.Generators
{
    /// <summary>
    ///   Code generator that produces protocol wrapper proxies.
    /// </summary>
    internal partial class WrapperGenerator : CodeGenerator
    {
        // Common pattern for dynamically generated proxies
        private const String NAME_PATTERN = "Monobjc.Dynamic.Wrappers.{0}Impl";

        /// <summary>
        ///   Initializes a new instance of the <see cref = "WrapperGenerator" /> class.
        /// </summary>
        /// <param name = "assembly">The assembly.</param>
        /// <param name="is64Bits"></param>
        public WrapperGenerator(DynamicAssembly assembly, bool is64Bits) : base(assembly, is64Bits) { }

        /// <summary>
        ///   TODO: Doc
        /// </summary>
        public Type DefineWrapperProxy(Type type)
        {
            if (!type.IsInterface)
            {
                throw new ArgumentException(String.Format(CultureInfo.CurrentCulture, Resources.TypeIsNotAnInterface, type.FullName));
            }
            if (!typeof (IManagedWrapper).IsAssignableFrom(type))
            {
                throw new ArgumentException(String.Format(CultureInfo.CurrentCulture, Resources.TypeDoesNotInheritsFromIManagedWrapper, type.FullName));
            }

            // Check that the type has the required attribute
            ObjectiveCProtocolAttribute protocolAttribute = Attribute.GetCustomAttribute(type, typeof (ObjectiveCProtocolAttribute)) as ObjectiveCProtocolAttribute;
            if (protocolAttribute == null)
            {
                throw new ObjectiveCCodeGenerationException(String.Format(CultureInfo.CurrentCulture, Resources.TypeHasNoObjectiveCProtocolAttribute, type.FullName));
            }

            // Compute the name of the proxy
            String name = String.IsNullOrEmpty(protocolAttribute.Name) ? type.FullName : protocolAttribute.Name;
            String typeName = String.Format(CultureInfo.CurrentCulture, NAME_PATTERN, name);

            if (Logger.DebugEnabled)
            {
                Logger.Debug("WrapperGenerator", "Generating Protocol Proxy: " + typeName);
            }

            // Declare the wrapper type
            TypeBuilder typeBuilder = this.Assembly.AddType(typeName, typeof (Id));
            typeBuilder.AddInterfaceImplementation(typeof (IManagedWrapper));
            typeBuilder.AddInterfaceImplementation(type);

            // Define default constructor
            typeBuilder.DefineDefaultConstructor(EmitConstants.PUBLIC_CONSTRUCTOR);

            // Define a constructor with an IntPtr argument
            ConstructorBuilder constructorBuilder = typeBuilder.DefineConstructor(EmitConstants.PUBLIC_CONSTRUCTOR, CallingConventions.Standard, new[] {typeof (IntPtr)});
            constructorBuilder.DefineParameter(1, ParameterAttributes.None, "nativePointer");
            ILGenerator generator = constructorBuilder.GetILGenerator();
            generator.Emit(OpCodes.Ldarg_0);
            generator.Emit(OpCodes.Ldarg_1);
            generator.Emit(OpCodes.Call, EmitInfos.ID_CONSTRUCTOR_INTPTR);
            generator.Emit(OpCodes.Ret);

            // Gets a list of methods
            List<MethodInfo> methods = new List<MethodInfo>(type.GetMethods(BindingFlags.Public |
                                                                            BindingFlags.Instance |
                                                                            BindingFlags.FlattenHierarchy));

            // Gets a list of properties
            PropertyInfo[] properties = type.GetProperties(BindingFlags.Public |
                                                           BindingFlags.Instance |
                                                           BindingFlags.FlattenHierarchy);
            // Implements each interface method
            // Method must be tagged properly
            foreach (PropertyInfo propertyInfo in properties)
            {
                // Define the implementation property
                PropertyBuilder propertyBuilder = typeBuilder.DefineProperty(propertyInfo.Name, PropertyAttributes.None, propertyInfo.PropertyType, null);

                MethodInfo getterInfo = propertyInfo.GetGetMethod();
                if (getterInfo != null)
                {
                    String message = GetSelector(getterInfo);

                    // Define the implementation getter
                    MethodBuilder getterMethodBuilder = typeBuilder.DefineMethod(getterInfo.Name,
                                                                                 EmitConstants.PUBLIC_METHOD_GET_SET_FINAL,
                                                                                 propertyInfo.PropertyType,
                                                                                 Type.EmptyTypes);
                    EmitMethodBody(getterMethodBuilder, getterInfo, message);

                    // Assign the getter to the property
                    propertyBuilder.SetGetMethod(getterMethodBuilder);

                    // Remove the getter from the method list
                    methods.Remove(getterInfo);
                }

                MethodInfo setterInfo = propertyInfo.GetSetMethod();
                if (setterInfo != null)
                {
                    String message = GetSelector(setterInfo);

                    // Define the implementation setter
                    MethodBuilder setterMethodBuilder = typeBuilder.DefineMethod(setterInfo.Name,
                                                                                 EmitConstants.PUBLIC_METHOD_GET_SET_FINAL,
                                                                                 null,
                                                                                 new[] {propertyInfo.PropertyType});
                    EmitMethodBody(setterMethodBuilder, setterInfo, message);

                    // Assign the setter to the property
                    propertyBuilder.SetSetMethod(setterMethodBuilder);

                    // Remove the setter from the method list
                    methods.Remove(setterInfo);
                }
            }

            // Implements each interface method left
            foreach (MethodInfo methodInfo in methods)
            {
                String message = GetSelector(methodInfo);
                ParameterInfo[] parameterInfos = methodInfo.GetParameters();
                Type[] parameterTypes = TypeHelper.GetParameterTypes(methodInfo);

                // Define the implementation method
                MethodBuilder methodBuilder = typeBuilder.DefineMethod(methodInfo.Name,
                                                                       EmitConstants.PUBLIC_METHOD_OVERRIDE_FINAL,
                                                                       methodInfo.ReturnType,
                                                                       parameterTypes);
                // Copy parameter names
                for (int i = 0; i < parameterInfos.Length; i++)
                {
                    methodBuilder.DefineParameter(i + 1, ParameterAttributes.None, parameterInfos[i].Name);
                }

                EmitMethodBody(methodBuilder, methodInfo, message);
            }

            return typeBuilder.CreateType();
        }
    }
}