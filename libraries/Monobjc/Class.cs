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
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.CompilerServices;
using Monobjc.Properties;

namespace Monobjc
{
    /// <summary>
    ///   Represents a managed wrapper around an Objective-C Class definition.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords", MessageId = "Class")]
    public sealed class Class : Id
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref = "Class" /> class.
        /// </summary>
        /// <param name = "value">The pointer.</param>
        public Class(IntPtr value) : base(value) {}

        /// <summary>
        ///   Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public String Name
        {
            get { return GetName(this.pointer); }
        }

        /// <summary>
        ///   Gets the super class.
        /// </summary>
        /// <value>The super class.</value>
        public Class SuperClass
        {
            get { return GetSuperClass(this.pointer); }
        }

        /// <summary>
        ///   Gets the a <see cref = "Class" /> for the specified id.
        /// </summary>
        /// <param name = "id">The id.</param>
        /// <returns>A <see cref = "Class" /> object.</returns>
        public static Class Get(Id id)
        {
            return Get(id.GetType());
        }

        /// <summary>
        ///   Gets the a <see cref = "Class" /> for the specified type.
        /// </summary>
        /// <param name = "type">The type.</param>
        /// <returns>A <see cref = "Class" /> object.</returns>
        public static Class Get(Type type)
        {
            String className = GetAttributeName(type);
            return Get(className);
        }

        /// <summary>
        ///   Gets the a <see cref = "Class" /> for the specified type.
        /// </summary>
        /// <param name = "type">The type.</param>
        /// <returns>A <see cref = "Class" /> object.</returns>
        [Obsolete("Use Class.Get(Type) instead.")]
        public static Class GetClassFromType(Type type)
        {
            return Get(type);
        }

        /// <summary>
        ///   Determines whether the <see cref = "Class" /> for the specified type is mapped.
        /// </summary>
        /// <param name = "type">The type.</param>
        /// <returns>
        ///   <c>true</c> if the specified type is mapped; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsMapped(Type type)
        {
            String className = GetAttributeName(type);
            return IsMapped(className);
        }

        /// <summary>
        ///   Gets the name of the <see cref = "ObjectiveCClassAttribute" /> instance for the given type.
        /// </summary>
        /// <param name = "type">The type that has a <see cref = "ObjectiveCClassAttribute" />.</param>
        /// <returns>The class name.</returns>
        internal static String GetAttributeName(Type type)
        {
            ObjectiveCClassAttribute attribute = Attribute.GetCustomAttribute(type, typeof (ObjectiveCClassAttribute)) as ObjectiveCClassAttribute;
            if (attribute == null)
            {
                throw new ObjectiveCException(String.Format(CultureInfo.CurrentCulture, Resources.NoClassAttributeFoundForType, type));
            }
            return String.IsNullOrEmpty(attribute.Name) ? type.Name : attribute.Name;
        }

        /// <summary>
        ///   Gets the a <see cref = "Class" /> for the specified name.
        /// </summary>
        /// <param name = "className">Name of the class.</param>
        /// <returns>A <see cref = "Class" /> object or null if it does not exists.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern Class Get(String className);

        /// <summary>
        ///   Gets the a <see cref = "Class" /> for the specified pointer.
        /// </summary>
        /// <param name = "value">The pointer of the native class.</param>
        /// <returns>A <see cref = "Class" /> object.</returns>
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        public static extern Class Get(IntPtr value);

        /// <summary>
        ///   Internal call to get the name of the class.
        /// </summary>
        /// <param name = "value">The pointer of the native class.</param>
        /// <returns>The name of the class.</returns>
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        private static extern String GetName(IntPtr value);

        /// <summary>
        ///   Internal call to get the super class of the class.
        /// </summary>
        /// <param name = "value">The pointer of the native class.</param>
        /// <returns>The super class of the class.</returns>
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        private static extern Class GetSuperClass(IntPtr value);

        /// <summary>
        ///   Determines whether the specified class name is mapped.
        /// </summary>
        /// <param name = "className">Name of the class.</param>
        /// <returns>
        ///   <c>true</c> if the specified class name is mapped; otherwise, <c>false</c>.
        /// </returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern bool IsMapped(String className);
    }
}