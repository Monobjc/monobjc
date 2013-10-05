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
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using Monobjc.Generators;
using Monobjc.Properties;

namespace Monobjc.Runtime
{
	internal partial class Bridge
	{
		/// <summary>
		///   Collect every public instance method with an attribute defined in the type.
		/// </summary>
		internal static MethodTuple[] CollectInstanceMethods (Type type)
		{
			List<MethodTuple> tuples = new List<MethodTuple> ();
			MethodInfo[] methodInfos = type.GetMethods (BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
			Array.ForEach (methodInfos, methodInfo =>
			{
				ObjectiveCMessageAttribute attribute = (ObjectiveCMessageAttribute)Attribute.GetCustomAttribute (methodInfo, typeof(ObjectiveCMessageAttribute));
				if (attribute == null) {
					return;
				}

				MethodTuple methodTuple = new MethodTuple ();
				methodTuple.MethodInfo = methodInfo;
				methodTuple.Selector = String.IsNullOrEmpty (attribute.Selector) ? ObjectiveCEncoding.GetSelector (methodInfo) : attribute.Selector;

				tuples.Add (methodTuple);
			});
			return tuples.ToArray ();
		}

		/// <summary>
		///   Collect every public static method with an attribute.
		/// </summary>
		internal static MethodTuple[] CollectStaticMethods (Type type)
		{
			List<MethodTuple> tuples = new List<MethodTuple> ();
			MethodInfo[] methodInfos = type.GetMethods (BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);
			Array.ForEach (methodInfos, methodInfo =>
			{
				ObjectiveCMessageAttribute attribute = (ObjectiveCMessageAttribute)Attribute.GetCustomAttribute (methodInfo, typeof(ObjectiveCMessageAttribute));
				if (attribute == null) {
					return;
				}

				MethodTuple methodTuple = new MethodTuple ();
				methodTuple.MethodInfo = methodInfo;
				methodTuple.Selector = String.IsNullOrEmpty (attribute.Selector) ? ObjectiveCEncoding.GetSelector (methodInfo) : attribute.Selector;

				tuples.Add (methodTuple);
			});
			return tuples.ToArray ();
		}

		/// <summary>
		///   Extract the class name to use when defining a new class :
		///   <list type = "number">
		///     <item>Check for the presence of a <see cref = "ObjectiveCClassAttribute" /> on the type. If the attribute is missing, an exception is thrown.</item>
		///     <item>Check for the name value of the <see cref = "ObjectiveCClassAttribute" />. If the attribute doesn't supply a name, the short name of the Type is used.</item>
		///   </list>
		/// </summary>
		/// <exception cref = "ObjectiveCException">If no <see cref = "ObjectiveCClassAttribute" /> attribute is found on the type.</exception>
		private static String ExtractClassName (Type type)
		{
			// Check that the type has a class attribute as we don't define type without class attribute
			ObjectiveCClassAttribute attribute = Attribute.GetCustomAttribute (type, typeof(ObjectiveCClassAttribute), false) as ObjectiveCClassAttribute;
			if (attribute == null) {
				throw new ObjectiveCException (String.Format (CultureInfo.CurrentCulture, Resources.NoClassAttributeFoundForType, type.FullName));
			}
            String name = String.IsNullOrEmpty (attribute.Name) ? type.Name : attribute.Name;

            // Native types are never mangled
            if (attribute.IsNative) {
                return name;
            }

            // Managed types other than the primary require the domain token
            return ObjectiveCRuntime.GetDomainManagledName(name);
		}

		/// <summary>
		///   Extract the category's class name to use when defining a new category.
		/// </summary>
		/// <exception cref = "ObjectiveCException">If no <see cref = "ObjectiveCCategoryAttribute" /> attribute is found on the type, or if the category's name is null or empty.</exception>
		private static String ExtractCategoryClassName (Type type)
		{
			// Check that the type has a class attribute as we don't define type without class attribute
			ObjectiveCCategoryAttribute attribute = Attribute.GetCustomAttribute (type, typeof(ObjectiveCCategoryAttribute), false) as ObjectiveCCategoryAttribute;
			if (attribute == null) {
				throw new ObjectiveCException (String.Format (CultureInfo.CurrentCulture, Resources.NoCategoryAttributeFoundForType, type.FullName));
			}
			if (String.IsNullOrEmpty (attribute.Name)) {
				throw new ObjectiveCException (String.Format (CultureInfo.CurrentCulture, Resources.NoNameInCategoryAttributeForType, type.FullName));
			}

            // Native types are never mangled
            if (attribute.IsNative) {
                return attribute.Name;
            }

            // Managed types other than the primary require the domain token
            return ObjectiveCRuntime.GetDomainManagledName(attribute.Name);
		}

		/// <summary>
		///   Extract the super class name to use when defining a new class :
		///   <list type = "number">
		///     <item>Check for the presence of a <see cref = "ObjectiveCClassAttribute" /> on the base type. If the attribute is missing, an exception is thrown unless this is a for a Root Class.</item>
		///     <item>Check for the name value of the <see cref = "ObjectiveCClassAttribute" />. If the attribute doesn't supply a name, the short name of the Type is used.</item>
		///     <item>Check for the name found previously and correct it if the super class name is the imposter one.</item>
		///   </list>
		/// </summary>
		/// <exception cref = "ObjectiveCException">If no <see cref = "ObjectiveCClassAttribute" /> attribute is found on the type or on the base type.</exception>
		private static String ExtractSuperClassName (Type type)
		{
			// Check that the type has a register attribute as we don't define type without register attribute
			ObjectiveCClassAttribute objectiveCClassAttribute = Attribute.GetCustomAttribute (type, typeof(ObjectiveCClassAttribute), false) as ObjectiveCClassAttribute;
			if (objectiveCClassAttribute == null) {
				throw new ObjectiveCException (String.Format (CultureInfo.CurrentCulture, Resources.NoClassAttributeFoundForType, type.FullName));
			}

			// Check that the type has a register attribute as we don't define type with a broken hierarchy.
			ObjectiveCClassAttribute superObjectiveCClassAttribute = Attribute.GetCustomAttribute (type.BaseType, typeof(ObjectiveCClassAttribute), false) as ObjectiveCClassAttribute;
			if (superObjectiveCClassAttribute == null) {
				throw new ObjectiveCException (String.Format (CultureInfo.CurrentCulture, Resources.NoClassAttributeFoundForBaseType, type.FullName));
			}

			String name = String.IsNullOrEmpty (superObjectiveCClassAttribute.Name) ? type.BaseType.Name : superObjectiveCClassAttribute.Name;

            if (superObjectiveCClassAttribute.IsNative) {
                return name;
            }
            return ObjectiveCRuntime.GetDomainManagledName(name);
		}

		/// <summary>
		///   Determines whether the specified type requires a dealloc interception for lifecycle purpose.
		/// </summary>
		/// <param name = "type">The type.</param>
		/// <returns>
		///   <c>true</c> if the specified type requires a dealloc interception; otherwise, <c>false</c>.
		/// </returns>
		/// <exception cref = "ObjectiveCException">If no <see cref = "ObjectiveCClassAttribute" /> attribute is found on the type.</exception>
		private static bool NeedInterception (Type type)
		{
			// Check that the type has a register attribute as we don't define type without register attribute
			ObjectiveCClassAttribute objectiveCClassAttribute = Attribute.GetCustomAttribute (type, typeof(ObjectiveCClassAttribute), false) as ObjectiveCClassAttribute;
			if (objectiveCClassAttribute == null) {
				throw new ObjectiveCException (String.Format (CultureInfo.CurrentCulture, Resources.NoClassAttributeFoundForType, type.FullName));
			}

			return objectiveCClassAttribute.InterceptDealloc;
		}

        /// <summary>
        /// Determines if the specified type is native backed.
        /// </summary>
        /// <returns><c>true</c> if the specified type is native backed; otherwise, <c>false</c>.</returns>
        /// <param name="type">Type.</param>
        private static bool IsNative (Type type)
        {
            // Check whether the type is native backed
            ObjectiveCClassAttribute objectiveCClassAttribute = Attribute.GetCustomAttribute (type, typeof(ObjectiveCClassAttribute), false) as ObjectiveCClassAttribute;
            if (objectiveCClassAttribute == null) {
                throw new ObjectiveCException (String.Format (CultureInfo.CurrentCulture, Resources.NoClassAttributeFoundForType, type.FullName));
            }
            return objectiveCClassAttribute.IsNative;
        }

		/// <summary>
		///   Collect every public properties with an attribute.
		/// </summary>
		private static VariableTuple[] CollectInstanceVariables (Type type)
		{
			List<VariableTuple> tuples = new List<VariableTuple> ();
			PropertyInfo[] propertyInfos = type.GetProperties (BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
			Array.ForEach (propertyInfos, propertyInfo =>
			{
				ObjectiveCIVarAttribute objectiveCiVarAttribute = (ObjectiveCIVarAttribute)Attribute.GetCustomAttribute (propertyInfo, typeof(ObjectiveCIVarAttribute));
				if (objectiveCiVarAttribute == null) {
					return;
				}

				VariableTuple tuple = new VariableTuple ();
				tuple.Name = String.IsNullOrEmpty (objectiveCiVarAttribute.Name) ? propertyInfo.Name : objectiveCiVarAttribute.Name;
				tuple.Type = propertyInfo.PropertyType;

				tuples.Add (tuple);
			});
			return tuples.ToArray ();
		}
	}
}