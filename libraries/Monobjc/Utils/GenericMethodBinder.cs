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
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace Monobjc.Utils
{
	/// <summary>
	///   Subclass of <see cref = "Binder" /> used to select or not generic methods when a name collision is possible. Other selection or bind calls are ignored.
	/// </summary>
	internal class GenericMethodBinder : Binder
	{
		private readonly bool returnGeneric;

		/// <summary>
		///   Initializes a new instance of the <see cref = "GenericMethodBinder" /> class.
		/// </summary>
		/// <param name = "generic">if set to <c>true</c> [generic].</param>
		public GenericMethodBinder (bool generic)
		{
			this.returnGeneric = generic;
		}

		/// <summary>
		///   Selects a method to invoke from the given set of methods, based on the supplied arguments.
		/// </summary>
		/// <param name = "bindingAttr">A bitwise combination of <see cref = "T:System.Reflection.BindingFlags" /> values.</param>
		/// <param name = "match">The set of methods that are candidates for matching. For example, when a <see cref = "T:System.Reflection.Binder" /> object is used by <see cref = "Overload:System.Type.InvokeMember" />, this parameter specifies the set of methods that reflection has determined to be possible matches, typically because they have the correct member name. The default implementation provided by <see cref = "P:System.Type.DefaultBinder" /> changes the order of this array.</param>
		/// <param name = "args">The arguments that are passed in. The binder can change the order of the arguments in this array; for example, the default binder changes the order of arguments if the <paramref name = "names" /> parameter is used to specify an order other than positional order. If a binder implementation coerces argument types, the types and values of the arguments can be changed as well.</param>
		/// <param name = "modifiers">An array of parameter modifiers that enable binding to work with parameter signatures in which the types have been modified. The default binder implementation does not use this parameter.</param>
		/// <param name = "culture">An instance of <see cref = "T:System.Globalization.CultureInfo" /> that is used to control the coercion of data types, in binder implementations that coerce types. If <paramref name = "culture" /> is null, the <see cref = "T:System.Globalization.CultureInfo" /> for the current thread is used.
		///   Note:
		///   For example, if a binder implementation allows coercion of string values to numeric types, this parameter is necessary to convert a
		///   String that represents 1000 to a Double value, because 1000 is represented differently by different cultures. The default binder does not do such string coercions.</param>
		/// <param name = "names">The parameter names, if parameter names are to be considered when matching, or null if arguments are to be treated as purely positional. For example, parameter names must be used if arguments are not supplied in positional order.</param>
		/// <param name = "state">After the method returns, <paramref name = "state" /> contains a binder-provided object that keeps track of argument reordering. The binder creates this object, and the binder is the sole consumer of this object. If <paramref name = "state" /> is not null when BindToMethod returns, you must pass <paramref name = "state" /> to the <see cref = "M:System.Reflection.Binder.ReorderArgumentArray(System.Object[]@,System.Object)" /> method if you want to restore <paramref name = "args" /> to its original order, for example, so that you can retrieve the values of ref parameters (ByRef parameters in Visual Basic).</param>
		/// <returns>The matching method.</returns>
		/// <exception cref = "T:System.Reflection.AmbiguousMatchException">
		///   For the default binder, <paramref name = "match" /> contains multiple methods that are equally good matches for <paramref name = "args" />. For example, <paramref name = "args" /> contains a MyClass object that implements the IMyClass interface, and <paramref name = "match" /> contains a method that takes MyClass and a method that takes IMyClass.
		/// </exception>
		/// <exception cref = "T:System.MissingMethodException">
		///   For the default binder, <paramref name = "match" /> contains no methods that can accept the arguments supplied in <paramref name = "args" />.
		/// </exception>
		/// <exception cref = "T:System.ArgumentException">
		///   For the default binder, <paramref name = "match" /> is null or an empty array.
		/// </exception>
		public override MethodBase BindToMethod (BindingFlags bindingAttr, MethodBase[] match, ref object[] args, ParameterModifier[] modifiers, CultureInfo culture, string[] names, out object state)
		{
			throw new NotSupportedException ();
		}

		/// <summary>
		///   Selects a field from the given set of fields, based on the specified criteria.
		/// </summary>
		/// <param name = "bindingAttr">A bitwise combination of <see cref = "T:System.Reflection.BindingFlags" /> values.</param>
		/// <param name = "match">The set of fields that are candidates for matching. For example, when a <see cref = "T:System.Reflection.Binder" /> object is used by <see cref = "Overload:System.Type.InvokeMember" />, this parameter specifies the set of fields that reflection has determined to be possible matches, typically because they have the correct member name. The default implementation provided by <see cref = "P:System.Type.DefaultBinder" /> changes the order of this array.</param>
		/// <param name = "value">The field value used to locate a matching field.</param>
		/// <param name = "culture">An instance of <see cref = "T:System.Globalization.CultureInfo" /> that is used to control the coercion of data types, in binder implementations that coerce types. If <paramref name = "culture" /> is null, the <see cref = "T:System.Globalization.CultureInfo" /> for the current thread is used.
		///   Note:
		///   For example, if a binder implementation allows coercion of string values to numeric types, this parameter is necessary to convert a
		///   String that represents 1000 to a Double value, because 1000 is represented differently by different cultures. The default binder does not do such string coercions.</param>
		/// <returns>The matching field.</returns>
		/// <exception cref = "T:System.Reflection.AmbiguousMatchException">
		///   For the default binder, <paramref name = "bindingAttr" /> includes <see cref = "F:System.Reflection.BindingFlags.SetField" />, and <paramref name = "match" /> contains multiple fields that are equally good matches for <paramref name = "value" />. For example, <paramref name = "value" /> contains a MyClass object that implements the IMyClass interface, and <paramref name = "match" /> contains a field of type MyClass and a field of type IMyClass.
		/// </exception>
		/// <exception cref = "T:System.MissingFieldException">
		///   For the default binder, <paramref name = "bindingAttr" /> includes <see cref = "F:System.Reflection.BindingFlags.SetField" />, and <paramref name = "match" /> contains no fields that can accept <paramref name = "value" />.
		/// </exception>
		/// <exception cref = "T:System.NullReferenceException">
		///   For the default binder, <paramref name = "bindingAttr" /> includes <see cref = "F:System.Reflection.BindingFlags.SetField" />, and <paramref name = "match" /> is null or an empty array.
		///   -or-
		///   <paramref name = "bindingAttr" /> includes <see cref = "F:System.Reflection.BindingFlags.SetField" />, and <paramref name = "value" /> is null.
		/// </exception>
		public override FieldInfo BindToField (BindingFlags bindingAttr, FieldInfo[] match, object value, CultureInfo culture)
		{
			throw new NotSupportedException ();
		}

		/// <summary>
		///   Selects a method from the given set of methods, based on the argument type.
		/// </summary>
		/// <param name = "bindingAttr">A bitwise combination of <see cref = "T:System.Reflection.BindingFlags" /> values.</param>
		/// <param name = "match">The set of methods that are candidates for matching. For example, when a <see cref = "T:System.Reflection.Binder" /> object is used by <see cref = "Overload:System.Type.InvokeMember" />, this parameter specifies the set of methods that reflection has determined to be possible matches, typically because they have the correct member name. The default implementation provided by <see cref = "P:System.Type.DefaultBinder" /> changes the order of this array.</param>
		/// <param name = "types">The parameter types used to locate a matching method.</param>
		/// <param name = "modifiers">An array of parameter modifiers that enable binding to work with parameter signatures in which the types have been modified.</param>
		/// <returns>
		///   The matching method, if found; otherwise, null.
		/// </returns>
		/// <exception cref = "T:System.Reflection.AmbiguousMatchException">
		///   For the default binder, <paramref name = "match" /> contains multiple methods that are equally good matches for the parameter types described by <paramref name = "types" />. For example, the array in <paramref name = "types" /> contains a <see cref = "T:System.Type" /> object for MyClass and the array in <paramref name = "match" /> contains a method that takes a base class of MyClass and a method that takes an interface that MyClass implements.
		/// </exception>
		/// <exception cref = "T:System.ArgumentException">
		///   For the default binder, <paramref name = "match" /> is null or an empty array.
		///   -or-
		///   An element of <paramref name = "types" /> derives from <see cref = "T:System.Type" />, but is not of type RuntimeType.
		/// </exception>
		public override MethodBase SelectMethod (BindingFlags bindingAttr, MethodBase[] match, Type[] types, ParameterModifier[] modifiers)
		{
			foreach (MethodBase methodBase in match) {
				MethodInfo mi = methodBase as MethodInfo;
				if (mi == null) {
					continue;
				}
				if (this.returnGeneric != methodBase.IsGenericMethod) {
					continue;
				}
				Type[] parameterTypes = mi.GetParameters ().Select (p => p.ParameterType).ToArray ();
				if (parameterTypes.Length != types.Length) {
					continue;
				}
				bool ok = true;
				for (int i = 0; i < parameterTypes.Length; i++) {
					if (parameterTypes [i] != types [i]) {
						ok = false;
						break;
					}
				}
				if (ok) {
					return methodBase;
				}
			}
			return null;

			//return match.FirstOrDefault(methodBase => (types.Length == methodBase.GetParameters().Length) && (!this.returnGeneric ^ methodBase.IsGenericMethod));
		}

		/// <summary>
		///   Selects a property from the given set of properties, based on the specified criteria.
		/// </summary>
		/// <param name = "bindingAttr">A bitwise combination of <see cref = "T:System.Reflection.BindingFlags" /> values.</param>
		/// <param name = "match">The set of properties that are candidates for matching. For example, when a <see cref = "T:System.Reflection.Binder" /> object is used by <see cref = "Overload:System.Type.InvokeMember" />, this parameter specifies the set of properties that reflection has determined to be possible matches, typically because they have the correct member name. The default implementation provided by <see cref = "P:System.Type.DefaultBinder" /> changes the order of this array.</param>
		/// <param name = "returnType">The return value the matching property must have.</param>
		/// <param name = "indexes">The index types of the property being searched for. Used for index properties such as the indexer for a class.</param>
		/// <param name = "modifiers">An array of parameter modifiers that enable binding to work with parameter signatures in which the types have been modified.</param>
		/// <returns>The matching property.</returns>
		/// <exception cref = "T:System.Reflection.AmbiguousMatchException">
		///   For the default binder, <paramref name = "match" /> contains multiple properties that are equally good matches for <paramref name = "returnType" /> and <paramref name = "indexes" />.
		/// </exception>
		/// <exception cref = "T:System.ArgumentException">
		///   For the default binder, <paramref name = "match" /> is null or an empty array.
		/// </exception>
		public override PropertyInfo SelectProperty (BindingFlags bindingAttr, PropertyInfo[] match, Type returnType, Type[] indexes, ParameterModifier[] modifiers)
		{
			throw new NotSupportedException ();
		}

		/// <summary>
		///   Changes the type of the given Object to the given Type.
		/// </summary>
		/// <param name = "value">The object to change into a new Type.</param>
		/// <param name = "type">The new Type that <paramref name = "value" /> will become.</param>
		/// <param name = "culture">An instance of <see cref = "T:System.Globalization.CultureInfo" /> that is used to control the coercion of data types. If <paramref name = "culture" /> is null, the <see cref = "T:System.Globalization.CultureInfo" /> for the current thread is used.
		///   Note:
		///   For example, this parameter is necessary to convert a
		///   String that represents 1000 to a Double value, because 1000 is represented differently by different cultures.</param>
		/// <returns>
		///   An object that contains the given value as the new type.
		/// </returns>
		public override object ChangeType (object value, Type type, CultureInfo culture)
		{
			throw new NotSupportedException ();
		}

		/// <summary>
		///   Upon returning from <see cref = "M:System.Reflection.Binder.BindToMethod(System.Reflection.BindingFlags,System.Reflection.MethodBase[],System.Object[]@,System.Reflection.ParameterModifier[],System.Globalization.CultureInfo,System.String[],System.Object@)" />, restores the <paramref name = "args" /> argument to what it was when it came from BindToMethod.
		/// </summary>
		/// <param name = "args">The actual arguments that are passed in. Both the types and values of the arguments can be changed.</param>
		/// <param name = "state">A binder-provided object that keeps track of argument reordering.</param>
		public override void ReorderArgumentArray (ref object[] args, object state)
		{
			throw new NotSupportedException ();
		}
	}
}