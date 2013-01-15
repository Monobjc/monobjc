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
using Monobjc.Properties;

namespace Monobjc
{
	/// <summary>
	///   Marks a method as an action for Interface Builder.
	/// </summary>
	[AttributeUsage(AttributeTargets.Method)]
	public sealed class IBActionAttribute : Attribute
	{
	}

	/// <summary>
	///   Marks a property as an outlet for Interface Builder.
	/// </summary>
	[AttributeUsage(AttributeTargets.Property)]
	public sealed class IBOutletAttribute : Attribute
	{
	}

	/// <summary>
	///   Marks an assembly as a Mac OS X framework.
	/// </summary>
	[AttributeUsage(AttributeTargets.Assembly)]
	public sealed class ObjectiveCFrameworkAttribute : Attribute
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Monobjc.ObjectiveCFrameworkAttribute"/> class.
		/// </summary>
		/// <param name = "system">The value is <code>true</code> if the framework is a system one; <code>false</code> otherwise.</param>
		public ObjectiveCFrameworkAttribute (bool system)
		{
			this.IsSystem = system;
		}

		/// <summary>
		///   Returns if the framework is a system one.
		/// </summary>
		/// <value><code>True</code> if the framework is a system one; <code>false</code> otherwise</value>
		public bool IsSystem { get; private set; }

		/// <summary>
		///   Returns a <see cref = "String" /> that represents this instance.
		/// </summary>
		/// <returns>
		///   A <see cref = "String" /> that represents this instance.
		/// </returns>
		public override String ToString ()
		{
			return String.Format (CultureInfo.CurrentCulture,
                                 Resources.ObjectiveCFrameworkString,
                                 this.IsSystem);
		}
	}

	/// <summary>
	///   <para>Used to define the underlying native type for a managed type.</para>
	///   <para>This is needed in order to map types that can be dependent on the platform's bitness.</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Enum | AttributeTargets.Interface | AttributeTargets.Struct, AllowMultiple = true)]
	public sealed class ObjectiveCUnderlyingTypeAttribute : Attribute
	{
		/// <summary>
		///   Initializes a new instance of the <see cref = "ObjectiveCUnderlyingTypeAttribute" /> class.
		/// </summary>
		/// <param name = "value">The value.</param>
		public ObjectiveCUnderlyingTypeAttribute (Type value)
		{
			this.Value = value;
		}

		/// <summary>
		///   Gets or sets the underlying type.
		/// </summary>
		/// <value>The underlying type.</value>
		public Type Value { get; private set; }

		/// <summary>
		///   Gets or sets if the type targets 64 bits platfrom or not.
		/// </summary>
		/// <value><code>true</code> if the type targets 64 bits platfrom or not; <code>false</code> otherwise.</value>
		public bool Is64Bits { get; set; }

		/// <summary>
		///   Returns a <see cref = "String" /> that represents this instance.
		/// </summary>
		/// <returns>
		///   A <see cref = "String" /> that represents this instance.
		/// </returns>
		public override String ToString ()
		{
			return String.Format (CultureInfo.CurrentCulture,
                                 Resources.ObjectiveCUnderlyingTypeString,
                                 this.Value,
                                 this.Is64Bits);
		}
	}

	/// <summary>
	///   <para>Allows a .NET class containing extension methods to be registered within the Objective-C runtime.</para>
	///   <para>The extension methods are added as instance methods to the targeted class.</para>
	/// </summary>
	/// <example>
	///   <para>The following example shows how to use the <see cref = "ObjectiveCCategoryAttribute" /> attribute.</para>
	///   <para>The type <c>NSString_Operations</c> will register new methods for NSString class.
	///     <code>
	///       [ObjectiveCCategory("NSString")]
	///       public static class NSString_Operations
	///       {
	///       ...
	///       }
	///     </code>
	///   </para>
	/// </example>
	[AttributeUsage(AttributeTargets.Class)]
	public sealed class ObjectiveCCategoryAttribute : Attribute
	{
		/// <summary>
		///   Initializes a new instance of the <see cref = "ObjectiveCCategoryAttribute" /> class.
		/// </summary>
		/// <param name = "name">The name of the class to use when appending the category in the Objective-C runtime.</param>
		/// <remarks>
		///   The name MUST be an ANSI identifier.
		/// </remarks>
		public ObjectiveCCategoryAttribute (String name)
		{
			this.Name = name;
		}

		/// <summary>
		///   Gets the name of the class to use when appending the category in the Objective-C runtime.
		/// </summary>
		/// <value>The name to use.</value>
		public String Name { get; private set; }

		/// <summary>
		///   Returns a <see cref = "String" /> that represents this instance.
		/// </summary>
		/// <returns>
		///   A <see cref = "String" /> that represents this instance.
		/// </returns>
		public override String ToString ()
		{
			return String.Format (CultureInfo.CurrentCulture,
                                 Resources.ObjectiveCCategoryString,
                                 this.Name);
		}
	}

	/// <summary>
	///   <para>Allows a .NET class to be registered within the Objective-C runtime.</para>
	///   <para>All the ascendant classes in the inheritance hierarchy must have a <see cref = "ObjectiveCClassAttribute" /> attribute,
	///     otherwise the runtime will not be able to use it.</para>
	/// </summary>
	/// <example>
	///   <para>The following example shows how to use the <see cref = "ObjectiveCClassAttribute" /> attribute.</para>
	///   <para>The type <c>MyOwnType1</c> will be registered with the "MyOwnType1" name.
	///     <code>
	///       [ObjectiveCClass]
	///       public class MyOwnType1 : NSObject
	///       {
	///       ...
	///       }
	///     </code>
	///   </para>
	///   <para>The type <c>MyOwnType2</c> will be registered with the "Type2" name.
	///     <code>
	///       [ObjectiveCClass("Type2")]
	///       public class MyOwnType2 : NSObject
	///       {
	///       ...
	///       }
	///     </code>
	///   </para>
	/// </example>
	[AttributeUsage(AttributeTargets.Class)]
	public sealed class ObjectiveCClassAttribute : Attribute
	{
		/// <summary>
		///   <para>Initializes a new instance of the <see cref = "ObjectiveCClassAttribute" /> class.</para>
		///   <para>The name that will be used to register the tagged type will be its short name, i.e. "MyType"
		///     if the type is "Foo.Bar.MyType".</para>
		/// </summary>
		public ObjectiveCClassAttribute ()
		{
			this.Name = String.Empty;
			this.InterceptDealloc = false;
		}

		/// <summary>
		///   Initializes a new instance of the <see cref = "ObjectiveCClassAttribute" /> class.
		/// </summary>
		/// <param name = "name">The name that will be used to register the tagged type.</param>
		/// <remarks>
		///   The name MUST be an ANSI identifier.
		/// </remarks>
		public ObjectiveCClassAttribute (String name)
		{
			this.Name = name;
			this.InterceptDealloc = false;
		}

		/// <summary>
		///   Gets the name to use when registering this class in the Objective-C runtime.
		/// </summary>
		/// <value>The name to use.</value>
		public String Name { get; private set; }

		/// <summary>
		///   Gets or sets a value indicating whether this class needs dealloc interception.
		/// </summary>
		/// <value><c>true</c> if [intercept dealloc]; otherwise, <c>false</c>.</value>
		public bool InterceptDealloc { get; set; }

		/// <summary>
		///   <para>Gets or sets the name of the class whose methods will be intercetped by this class.</para>
		///   <para>The Objective-C runtime allows method replacement. It is useful to introduce
		///     a new behaviour wihtin a class hierarchy or to intercept messages.</para>
		/// </summary>
		/// <value>The name of the replaced class.</value>
		[Obsolete("No needed anymore. Remove this attribute safely.")]
		public String InterceptCallsFor { get; set; }

		/// <summary>
		///   Returns a <see cref = "T:System.String"></see> that represents the current <see cref = "T:System.Object"></see>.
		/// </summary>
		/// <returns>
		///   A <see cref = "T:System.String"></see> that represents the current <see cref = "T:System.Object"></see>.
		/// </returns>
		public override String ToString ()
		{
			return String.Format (CultureInfo.CurrentCulture,
                                 Resources.ObjectiveCClassString,
                                 this.Name,
                                 this.InterceptDealloc);
		}
	}

	/// <summary>
	///   <para>Exposes a field to the Objective-C runtime, so it can be manipulated from the runtime.</para>
	///   <para>When the tagged type (with the <see cref = "ObjectiveCClassAttribute" />) is registered in the Objective-C
	///     runtime, all the tagged fields will be exported, which means they will be accessible from native classes.</para>
	///   <para>Fields declared by <see cref = "ObjectiveCIVarAttribute" /> are synchronized before and after method calls if required (see <see cref = "ObjectiveCMessageAttribute" />).</para>
	/// </summary>
	/// <example>
	///   <para>The following example shows how to use the <see cref = "ObjectiveCIVarAttribute" /> attribute.</para>
	///   <code>
	///     [ObjectiveCClass]
	///     public class MyOwnType1 : NSObject
	///     {
	///     [ObjectiveCIVarAttribute("myBool")]
	///     public bool MyBool
	///     {
	///     get { return GetInstanceVariable&lt;bool&gt;("myBool"); }
	///     set { SetInstanceVariablee&lt;bool&gt;("myBool", value); }
	///     }
	/// 
	///     [ObjectiveCIVarAttribute("aString")]
	///     public NSString aString
	///     {
	///     get { return GetInstanceVariable&lt;NSString&gt;("aString"); }
	///     set { SetInstanceVariablee&lt;NSString&gt;("aString", value); }
	///     }
	/// 
	///     public MyOwnType1()
	///     {
	///     ...
	///     }
	///     ...
	///     }
	///   </code>
	/// </example>
	[AttributeUsage(AttributeTargets.Property)]
	public sealed class ObjectiveCIVarAttribute : Attribute
	{
		/// <summary>
		///   Initializes a new instance of the <see cref = "ObjectiveCIVarAttribute" /> class.
		/// </summary>
		public ObjectiveCIVarAttribute ()
		{
			this.Name = String.Empty;
		}

		/// <summary>
		///   Initializes a new instance of the <see cref = "ObjectiveCIVarAttribute" /> class.
		/// </summary>
		/// <param name = "name">The name.</param>
		/// <remarks>
		///   The name MUST be an ANSI identifier.
		/// </remarks>
		public ObjectiveCIVarAttribute (String name)
		{
			this.Name = name;
		}

		/// <summary>
		///   Gets the name to be used when the enclosing type is registered within the Objective-C runtime.
		/// </summary>
		/// <value>The name to use.</value>
		public String Name { get; private set; }

		/// <summary>
		///   Returns a <see cref = "T:System.String"></see> that represents the current <see cref = "T:System.Object"></see>.
		/// </summary>
		/// <returns>
		///   A <see cref = "T:System.String"></see> that represents the current <see cref = "T:System.Object"></see>.
		/// </returns>
		public override String ToString ()
		{
			return String.Format (CultureInfo.CurrentCulture,
                                 Resources.ObjectiveCIVarString,
                                 this.Name);
		}
	}

	/// <summary>
	///   <para>Allows a method to be exported as part of a native class within the Objective-C runtime.</para>
	///   <para>When the tagged type (with the <see cref = "ObjectiveCClassAttribute" />) is registered in the Objective-C
	///     runtime, all the tagged methods will be exported, which means they will be callable from native classes or instances.</para>
	/// </summary>
	/// <example>
	///   <para>The following example shows how to use the <see cref = "ObjectiveCMessageAttribute" /> attribute.</para>
	///   <code>
	///     [ObjectiveCClass]
	///     public class MyOwnType1 : NSObject
	///     {
	///     [ObjectiveCMessage]
	///     public int DoThis(bool value)
	///     {
	///     ...
	///     }
	/// 
	///     [ObjectiveCMessage("doSomeDummyThing:")]
	///     public void DoDummy(String str)
	///     {
	///     ...
	///     }
	///     ...
	///     }
	///   </code>
	/// </example>
	[AttributeUsage(AttributeTargets.Method)]
	public sealed class ObjectiveCMessageAttribute : Attribute
	{
		/// <summary>
		///   Initializes a new instance of the <see cref = "ObjectiveCMessageAttribute" /> class.
		/// </summary>
		public ObjectiveCMessageAttribute ()
		{
			this.Selector = String.Empty;
		}

		/// <summary>
		///   Initializes a new instance of the <see cref = "ObjectiveCMessageAttribute" /> class.
		/// </summary>
		/// <param name = "selector">The selector to use.</param>
		/// <remarks>
		///   The name MUST be an ANSI identifier.
		/// </remarks>
		public ObjectiveCMessageAttribute (String selector)
		{
			this.Selector = selector;
		}

		/// <summary>
		///   <para>Gets the selector.</para>
		///   <para>Use the given selector when exporting the constructor or the method in the Objective-C runtime. The
		///     selector must conforms to the rules defined in the "The Objective-C Programming Language" and implemented by
		///     <see cref = "ObjectiveCEncoding" />.</para>
		/// </summary>
		/// <value>The selector to use.</value>
		public string Selector { get; private set; }

		/// <summary>
		///   <para>Gets or sets a value indicating whether to synchronize fields.</para>
		/// </summary>
		/// <value><c>true</c> if synchronization of fields has to be performed; otherwise, <c>false</c>.</value>
		[Obsolete("No needed anymore. Remove this attribute safely.")]
		public bool SynchronizeFields { get; set; }

		/// <summary>
		///   Returns a <see cref = "T:System.String"></see> that represents the current <see cref = "T:System.Object"></see>.
		/// </summary>
		/// <returns>
		///   A <see cref = "T:System.String"></see> that represents the current <see cref = "T:System.Object"></see>.
		/// </returns>
		public override String ToString ()
		{
			return String.Format (CultureInfo.CurrentCulture,
                                 Resources.ObjectiveCMessageString,
                                 this.Selector);
		}
	}

	/// <summary>
	///   <para>Allows a .NET interface to be registered within the Objective-C runtime.</para>
	///   <para>When a native instance is returned, the Objective-C runtime provides a wrapper that allows
	///     calls to the native instance through the methods of the interface.</para>
	/// </summary>
	/// <example>
	///   <para>The following example shows how to use the <see cref = "ObjectiveCProtocolAttribute" /> attribute.</para>
	///   <para>The type <c>MyOwnType1</c> will be registered with the "MyOwnType1" name.
	///     <code>
	///       [ObjectiveCProtocolAttribute]
	///       public interface MyOwnInterface1
	///       {
	///       ...
	///       }
	///     </code>
	///   </para>
	///   <para>The type <c>MyOwnType2</c> will be registered with the "Type2" name.
	///     <code>
	///       [ObjectiveCProtocolAttribute("Interface2")]
	///       public interface MyOwnInterface2
	///       {
	///       ...
	///       }
	///     </code>
	///   </para>
	/// </example>
	[AttributeUsage(AttributeTargets.Interface)]
	public sealed class ObjectiveCProtocolAttribute : Attribute
	{
		/// <summary>
		///   Initializes a new instance of the <see cref = "ObjectiveCProtocolAttribute" /> class.
		/// </summary>
		public ObjectiveCProtocolAttribute ()
		{
			this.Name = String.Empty;
		}

		/// <summary>
		///   Initializes a new instance of the <see cref = "ObjectiveCProtocolAttribute" /> class.
		/// </summary>
		/// <param name = "name">The name to use when registering the interface in the Objective-C runtime.</param>
		/// <remarks>
		///   The name MUST be an ANSI identifier.
		/// </remarks>
		public ObjectiveCProtocolAttribute (String name)
		{
			this.Name = name;
		}

		/// <summary>
		///   Gets or sets the name to use when registering the interface in the Objective-C runtime.
		/// </summary>
		/// <value>The name to use.</value>
		public string Name { get; private set; }

		/// <summary>
		///   Returns a <see cref = "T:System.String"></see> that represents the current <see cref = "T:System.Object"></see>.
		/// </summary>
		/// <returns>
		///   A <see cref = "T:System.String"></see> that represents the current <see cref = "T:System.Object"></see>.
		/// </returns>
		public override String ToString ()
		{
			return String.Format (CultureInfo.CurrentCulture,
                                 Resources.ObjectiveCProtocolString,
                                 this.Name);
		}
	}
}