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
using System.Globalization;
using System.Runtime.CompilerServices;
using Monobjc.Generators;
using Monobjc.Properties;

namespace Monobjc.Runtime
{
	internal static partial class Bridge
	{
		/// <summary>
		///   Defines the given class by installing a proxy, that will forward native calls to the corresponding instance.
		/// </summary>
		/// <param name = "classGenerator">The class generator.</param>
		/// <param name = "type">The type.</param>
		public static void DefineClass (ClassGenerator classGenerator, Type type)
		{
			if (type == null) {
				throw new ArgumentNullException ("type", Resources.CannotDefineObjectiveCClassFromNullType);
			}

			// Check if the class is already mapped
			if (Class.IsMapped (type)) {
				return;
			}

			// Extract class name from attributes
			String className = ExtractClassName (type);

			// Check for class existence
			Class cls = Class.Get (className);
			if (cls != null) {
				// Associate the type to the class
				cls.WrapperType = type.TypeHandle.Value;

				// Check to see if the class must be intercepted
				if (NeedInterception (type)) {
					if (Logger.InfoEnabled) {
						Logger.Info ("Bridge", "Intercepting 'dealloc' messages for class " + className);
					}
					InterceptDeallocFor (cls);
				}
				return;
			}
            else if(IsNative(type)) {
                if (Logger.DebugEnabled) {
                    Logger.Debug("Bridge", "Skipping definition for nonexistent native class " + className);
                }
                return;
            }

            // Objects with an Id base type do not have a superclass
            String superClassName = null;
            if (typeof(Id) != type.BaseType) {
    			// Extract class name from attributes
    			superClassName = ExtractSuperClassName (type);

    			// Get the superclass
    			Class superCls = Class.Get (superClassName);
    			if (superCls == null) {
    				throw new ObjectiveCException (String.Format (CultureInfo.CurrentCulture, Resources.CannotDefineClassBecauseSuperclassDoesNotExists, type, superClassName));
    			}
            }

			if (Logger.DebugEnabled) {
				Logger.Debug ("Bridge", "Defining class " + type + " <-> " + className + " : " + superClassName ?? "Id");
			}

			// Collects the informations needed for class generation
			VariableTuple[] variableTuples = CollectInstanceVariables (type);
			MethodTuple[] instanceMethods = CollectInstanceMethods (type);
			MethodTuple[] classMethods = CollectStaticMethods (type);

			// Generates the class proxy with the associated structures
			Type proxyType = classGenerator.DefineClassProxy (type, instanceMethods, classMethods);

			// Create the peer native class
			String[] ivarNames = Array.ConvertAll (variableTuples, tuple => tuple.Name);
			IntPtr[] ivarTypes = Array.ConvertAll (variableTuples, tuple => tuple.Type.TypeHandle.Value);
			cls = CreateClass (className, superClassName, ivarNames, ivarTypes);

			// Add instance methods
#if USE_CLOSURES
            foreach (MethodTuple tuple in instanceMethods)
            {
                MethodInfo methodInfo = proxyType.GetMethod(tuple.ProxyMethodInfo.Name);
                IntPtr handle = methodInfo.MethodHandle.Value;
                AddMethod(cls.pointer, false, handle, tuple.Selector, ObjectiveCEncoding.GetSignature(methodInfo));
            }
#else
			String[] methodNames = Array.ConvertAll (instanceMethods, tuple => tuple.Selector);
			IntPtr[] methodImplementations = Array.ConvertAll (instanceMethods, tuple => tuple.GetFunction (proxyType));
			String[] methodEncoding = Array.ConvertAll (instanceMethods, tuple => ObjectiveCEncoding.GetSignature (tuple.MethodInfo));
			AddMethods (cls.pointer, false, methodNames, methodImplementations, methodEncoding);
#endif

			// Add class methods
#if USE_CLOSURES
            foreach (MethodTuple tuple in classMethods)
            {
                MethodInfo methodInfo = proxyType.GetMethod(tuple.ProxyMethodInfo.Name);
                IntPtr handle = methodInfo.MethodHandle.Value;
                AddMethod(cls.pointer, true, handle, tuple.Selector, ObjectiveCEncoding.GetSignature(methodInfo, 0));
            }
#else
			methodNames = Array.ConvertAll (classMethods, tuple => tuple.Selector);
			methodImplementations = Array.ConvertAll (classMethods, tuple => tuple.GetFunction (proxyType));
			methodEncoding = Array.ConvertAll (classMethods, tuple => ObjectiveCEncoding.GetSignature (tuple.MethodInfo, 0));
			AddMethods (cls.pointer, true, methodNames, methodImplementations, methodEncoding);
#endif
		}

		/// <summary>
		///   Defines a category, by using various attributes.
		/// </summary>
		/// <param name = "categoryGenerator">The category generator to use.</param>
		/// <param name = "type">The type that contains the definition attibutes.</param>
		public static void DefineCategory (CategoryGenerator categoryGenerator, Type type)
		{
			if (type == null) {
				throw new ArgumentNullException ("type", Resources.CannotDefineObjectiveCCategroyFromNullType);
			}

			// Extract the category's class
			String className = ExtractCategoryClassName (type);

			// Check that the category's class exists
			Class cls = Class.Get (className);
			if (cls == null) {
				throw new ObjectiveCCategoryMappingException (String.Format (CultureInfo.CurrentCulture, Resources.ClassNotFoundForCategory, className, type));
			}

			if (Logger.DebugEnabled) {
				Logger.Debug ("Bridge", "Defining category " + type + " <-> " + className + "(" + type.Name + ")");
			}

			// Collects the informations needed for class generation
			MethodTuple[] extensionMethods = CollectStaticMethods (type);

			// Generates the class proxy with the associated structures
			Type proxyType = categoryGenerator.DefineCategoryProxy (type, extensionMethods);

			// Add class methods
#if USE_CLOSURES
            foreach (MethodTuple tuple in extensionMethods)
            {
                MethodInfo methodInfo = proxyType.GetMethod(tuple.ProxyMethodInfo.Name);
                IntPtr handle = methodInfo.MethodHandle.Value;
                AddMethod(cls.pointer, false, handle, tuple.Selector, ObjectiveCEncoding.GetSignature(methodInfo, 1));
            }
#else
			String[] methodNames = Array.ConvertAll (extensionMethods, tuple => tuple.Selector);
			IntPtr[] methodImplementations = Array.ConvertAll (extensionMethods, tuple => tuple.GetFunction (proxyType));
			String[] methodEncoding = Array.ConvertAll (extensionMethods, tuple => ObjectiveCEncoding.GetSignature (tuple.MethodInfo, 1));
			AddMethods (cls.pointer, false, methodNames, methodImplementations, methodEncoding);
#endif
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void InterceptDeallocFor (Class cls);

		[MethodImplAttribute(MethodImplOptions.InternalCall)]
		private static extern Class CreateClass (String className, String superClassName, String[] ivarNames, IntPtr[] ivarTypes);

		[MethodImplAttribute(MethodImplOptions.InternalCall)]
		private static extern void AddMethods (IntPtr cls, bool meta, String[] methodNames, IntPtr[] methodImplementations, String[] methodEncodings);

		[MethodImplAttribute(MethodImplOptions.InternalCall)]
		private static extern void AddMethod (IntPtr cls, bool meta, IntPtr handle, String methodName, String methodEncoding);
	}
}