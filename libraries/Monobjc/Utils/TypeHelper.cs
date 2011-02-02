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
using System.Reflection;

namespace Monobjc.Utils
{
    /// <summary>
    ///   Utility class to manipulate <see cref = "Type" /> instance and arrays.
    /// </summary>
    internal static class TypeHelper
    {
        [Obsolete]
        internal static Type GetUnderlyingType(Type type)
        {
            return GetUnderlyingType(type, ObjectiveCRuntime.Is64Bits);
        }

        /// <summary>
        /// Gets the underlying native type of the managed type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="is64bits">if set to <c>true</c>, take the 64 bits type.</param>
        /// <returns>The underlying type.</returns>
        internal static Type GetUnderlyingType(Type type, bool is64bits)
        {
            //Logger.Info("TypeHelper", "GetUnderlyingType for " + type);
            object[] attributes = type.GetCustomAttributes(typeof(ObjectiveCUnderlyingTypeAttribute), false);
            if (attributes.Length > 0)
            {
                foreach (object o in attributes)
                {
                    ObjectiveCUnderlyingTypeAttribute attribute = o as ObjectiveCUnderlyingTypeAttribute;
                    if (attribute != null && (attribute.Is64Bits == is64bits))
                    {
                        return attribute.Value;
                    }
                }
            }

            if (type.IsEnum)
            {
                return Enum.GetUnderlyingType(type);
            }

            return type;
        }

        [Obsolete]
        internal static IntPtr GetUnderlyingTypeHandle(Type type)
        {
            return GetUnderlyingType(type, ObjectiveCRuntime.Is64Bits).TypeHandle.Value;
        }

        /// <summary>
        /// Gets the underlying native type of the managed type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="is64bits">if set to <c>true</c>, take the 64 bits type.</param>
        /// <returns>The type handle value</returns>
        internal static IntPtr GetUnderlyingTypeHandle(Type type, bool is64bits)
        {
            return GetUnderlyingType(type, is64bits).TypeHandle.Value;
        }

        /// <summary>
        ///   Tells if the given type need to be wrapped as a native pointer.
        /// </summary>
        public static bool NeedWrapping(Type type)
        {
            // Wrapping is required if :
            // - the parameter is a subclass of Id
            // - the parameter is an interface
            return typeof (IManagedWrapper).IsAssignableFrom(type);
        }

        /// <summary>
        ///   Wraps the given type as a native pointer if needed.
        /// </summary>
        [Obsolete]
        public static Type WrapType(Type type)
        {
            return NeedWrapping(type) ? typeof(IntPtr) : type;
        }

        /// <summary>
        ///   Get the native conterpart of the given type.
        /// </summary>
        public static Type GetNativeType(Type type, bool is64bits)
        {
            if (type.IsByRef)
            {
                return typeof(IntPtr);
            }
            Type underlyingType = GetUnderlyingType(type, is64bits);
            return NeedWrapping(underlyingType) ? typeof(IntPtr) : underlyingType;
        }

        /// <summary>
        ///   Extract the parameter types for the method.
        /// </summary>
        public static Type[] GetParameterTypes(MethodBase methodBase)
        {
            return Array.ConvertAll(methodBase.GetParameters(), p => p.ParameterType);
        }

        /// <summary>
        ///   Extract the parameter names for the method.
        /// </summary>
        public static string[] GetParameterNames(MethodBase methodBase)
        {
            return Array.ConvertAll(methodBase.GetParameters(), p => p.Name);
        }

        [Obsolete]
        public static Type[] WrapParameterTypes(MethodBase methodBase)
        {
            return Array.ConvertAll(methodBase.GetParameters(), p =>
            {
                Type parameterType = p.ParameterType;
                if (parameterType.IsByRef)
                {
                    return typeof(IntPtr);
                }
                Type underlyingType = GetUnderlyingType(p.ParameterType);
                return NeedWrapping(underlyingType) ? typeof(IntPtr) : underlyingType;
            });
        }

        /// <summary>
        ///   Get the native conterpart of the method parameter types.
        /// </summary>
        public static Type[] GetNativeParameterTypes(MethodBase methodBase, bool is64bits)
        {
            return Array.ConvertAll(methodBase.GetParameters(), p => GetNativeType(p.ParameterType, is64bits));
        }

        [Obsolete]
        public static Type[] WrapParameterTypes(Type[] parameterTypes)
        {
            return Array.ConvertAll(parameterTypes, t =>
            {
                if (t.IsByRef)
                {
                    return typeof(IntPtr);
                }
                Type underlyingType = GetUnderlyingType(t);
                return NeedWrapping(underlyingType) ? typeof(IntPtr) : underlyingType;
            });
        }

        /// <summary>
        ///   Get the native conterpart of the given types.
        /// </summary>
        public static Type[] GetNativeParameterTypes(Type[] parameterTypes, bool is64bits)
        {
            return Array.ConvertAll(parameterTypes, t => GetNativeType(t, is64bits));
        }
    }
}