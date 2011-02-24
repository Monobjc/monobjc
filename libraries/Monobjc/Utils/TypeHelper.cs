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
        /// <summary>
        ///   Gets the underlying native type of the managed type.
        /// </summary>
        /// <param name = "type">The type.</param>
        /// <param name = "is64bits">if set to <c>true</c>, take the 64 bits type.</param>
        /// <returns>The underlying type.</returns>
        internal static Type GetUnderlyingType(Type type, bool is64bits)
        {
            //Logger.Info("TypeHelper", "GetUnderlyingType for " + type);
            object[] attributes = type.GetCustomAttributes(typeof (ObjectiveCUnderlyingTypeAttribute), false);
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

        /// <summary>
        ///   Gets the underlying native type of the managed type.
        /// </summary>
        /// <param name = "type">The type.</param>
        /// <param name = "is64bits">if set to <c>true</c>, take the 64 bits type.</param>
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
        ///   Get the native conterpart of the given type.
        /// </summary>
        public static Type GetNativeType(Type type, bool is64bits)
        {
            if (type.IsByRef)
            {
                return typeof (IntPtr);
            }
            Type underlyingType = GetUnderlyingType(type, is64bits);
            return NeedWrapping(underlyingType) ? typeof (IntPtr) : underlyingType;
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

        /// <summary>
        ///   Get the native conterpart of the method parameter types.
        /// </summary>
        public static Type[] GetNativeParameterTypes(MethodBase methodBase, bool is64bits)
        {
            return Array.ConvertAll(methodBase.GetParameters(), p => GetNativeType(p.ParameterType, is64bits));
        }

        /// <summary>
        ///   Get the native conterpart of the given types.
        /// </summary>
        public static Type[] GetNativeParameterTypes(Type[] parameterTypes, bool is64bits)
        {
            return Array.ConvertAll(parameterTypes, t => GetNativeType(t, is64bits));
        }

        /// <summary>
        ///   Gets the converter between the source and destination type.
        /// </summary>
        internal static MethodInfo GetConverter(Type sourceType, Type targetType)
        {
            // Dereference enumerations
            if (sourceType.IsEnum)
            {
                sourceType = Enum.GetUnderlyingType(sourceType);
            }
            if (targetType.IsEnum)
            {
                targetType = Enum.GetUnderlyingType(targetType);
            }

            // If the types are equivalent, return
            if (sourceType == targetType)
            {
                return null;
            }

            // Process well-known conversion first);
            if (sourceType == typeof(int) && targetType == typeof(long))
            {
                return INT_2_LONG;
            }
            if (sourceType == typeof(uint) && targetType == typeof(ulong))
            {
                return UINT_2_ULONG;
            }
            if (sourceType == typeof(float) && targetType == typeof(double))
            {
                return FLOAT_2_DOUBLE;
            }
            if (sourceType == typeof(long) && targetType == typeof(int))
            {
                return LONG_2_INT;
            }
            if (sourceType == typeof(ulong) && targetType == typeof(uint))
            {
                return ULONG_2_UINT;
            }
            if (sourceType == typeof(double) && targetType == typeof(float))
            {
                return DOUBLE_2_FLOAT;
            }

            // Process value-type conversion
            if (sourceType.IsValueType && targetType.IsValueType)
            {
                Binder binder = new ImplicitMethodBinder(sourceType, targetType);
                MethodInfo converter = sourceType.GetMethod("op_Implicit", BindingFlags.Public | BindingFlags.Static, binder, new[] {sourceType}, null) ??
                                       targetType.GetMethod("op_Implicit", BindingFlags.Public | BindingFlags.Static, binder, new[] {sourceType}, null);
                if (converter != null)
                {
                    return converter;
                }
            }


            throw new NotSupportedException("Cannot find a converter between " + sourceType + " and " + targetType);
        }

        /// <summary>
        ///   Gets the converter between the source and destination type.
        /// </summary>
        internal static IntPtr GetConverterHandle(Type sourceType, Type targetType)
        {
            MethodInfo methodInfo = GetConverter(sourceType, targetType);
            return (methodInfo != null) ? methodInfo.MethodHandle.Value : IntPtr.Zero;
        }

        private static readonly MethodInfo INT_2_LONG = typeof (Convert).GetMethod("ToInt64", BindingFlags.Public | BindingFlags.Static, null, new[] {typeof (int)}, null);
        private static readonly MethodInfo UINT_2_ULONG = typeof (Convert).GetMethod("ToUInt64", BindingFlags.Public | BindingFlags.Static, null, new[] {typeof (uint)}, null);
        private static readonly MethodInfo FLOAT_2_DOUBLE = typeof (Convert).GetMethod("ToDouble", BindingFlags.Public | BindingFlags.Static, null, new[] {typeof (float)}, null);
        private static readonly MethodInfo LONG_2_INT = typeof (Convert).GetMethod("ToInt32", BindingFlags.Public | BindingFlags.Static, null, new[] {typeof (long)}, null);
        private static readonly MethodInfo ULONG_2_UINT = typeof (Convert).GetMethod("ToUInt32", BindingFlags.Public | BindingFlags.Static, null, new[] {typeof (ulong)}, null);
        private static readonly MethodInfo DOUBLE_2_FLOAT = typeof (Convert).GetMethod("ToSingle", BindingFlags.Public | BindingFlags.Static, null, new[] {typeof (double)}, null);
    }
}