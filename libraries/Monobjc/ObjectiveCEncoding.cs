//
// This file is part of Monobjc, a .NET/Objective-C bridge
// Copyright (C) 2007-2012 - Laurent Etiemble
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
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace Monobjc
{
    /// <summary>
    ///   <para>Utility class to handle encoding of types and methods. </para>
    /// </summary>
    public static class ObjectiveCEncoding
    {
        private const String COLON = ":";
        private const String ENCODING_OFFSET = "{0}{1}";
        private const String WITH = "With";

        private static readonly String SIGNATURE_PREFIX = String.Format(CultureInfo.CurrentCulture, "@0:{0}", IntPtr.Size);

        /// <summary>
        ///   <para>Gets the selector for the given method.</para>
        ///   <para>The selector for a method is build with the following rules:
        ///     <list type = "bullet">
        ///       <item>Selector begins with the method name</item>
        ///       <item>The first parameter if present is appended by its name with the "With" prefix</item>
        ///       <item>The other parameters if present are appended by their names</item>
        ///     </list>
        ///   </para>
        ///   <para>Here are some examples of result:
        ///     <list type = "table">
        ///       <listheader>
        ///         <term>Method</term>
        ///         <description>Corresponding selector</description>
        ///       </listheader>
        ///       <item>
        ///         <term>public void DoThis()</term>
        ///         <description>DoThis</description>
        ///       </item>
        ///       <item>
        ///         <term>public void DoThis(int value)</term>
        ///         <description>DoThisWithValue:</description>
        ///       </item>
        ///       <item>
        ///         <term>public void DoThis(NSString str, int val)</term>
        ///         <description>DoThisWithStr:val:</description>
        ///       </item>
        ///     </list>
        ///   </para>
        /// </summary>
        /// <param name = "methodBase">The method.</param>
        /// <returns>
        ///   A selector compliant with Objective-C messaging.
        /// </returns>
        public static String GetSelector(MethodBase methodBase)
        {
            if (methodBase == null)
            {
                throw new ArgumentNullException("methodBase");
            }

            StringBuilder builder = new StringBuilder();
            ParameterInfo[] parameters = methodBase.GetParameters();

            // Add name
            builder.Append(methodBase.Name);

            for (int i = 0; i < parameters.Length; i++)
            {
                String name = parameters[i].Name;

                // If first parameter, use "With" prefix
                if (i == 0)
                {
                    builder.Append(WITH);
                    builder.Append(name.Substring(0, 1).ToUpperInvariant());
                    if (name.Length > 1)
                    {
                        builder.Append(name.Substring(1));
                    }
                }
                else
                {
                    builder.Append(name);
                }

                builder.Append(COLON);
            }

            return builder.ToString();
        }

        /// <summary>
        ///   <para>Gets the signature for the given method.</para>
        ///   <para>Here are some examples of result for methods:
        ///     <list type = "table">
        ///       <listheader>
        ///         <term>Method</term>
        ///         <description>Corresponding signature (on IA32 architecture)</description>
        ///       </listheader>
        ///       <item>
        ///         <term>public void DoThis()</term>
        ///         <description>v8@0:4</description>
        ///       </item>
        ///       <item>
        ///         <term>public void DoThis(int value)</term>
        ///         <description>v12@0:4i8</description>
        ///       </item>
        ///       <item>
        ///         <term>public void DoThis(NSString str, int val)</term>
        ///         <description>v16@0:4@8i12</description>
        ///       </item>
        ///     </list>
        ///   </para>
        /// </summary>
        /// <param name = "methodInfo">The method.</param>
        /// <returns>
        ///   A signature compliant with Objective-C messaging.
        /// </returns>
        /// <exception cref = "ArgumentNullException">If the method is null.</exception>
        public static String GetSignature(MethodInfo methodInfo)
        {
            return GetSignature(methodInfo, 0);
        }

        /// <summary>
        ///   <para>Gets the signature for the given method.</para>
        /// </summary>
        /// <param name = "methodInfo">The method.</param>
        /// <param name = "parametersToSkip">The numbers of parameters to skip.</param>
        /// <returns>
        ///   A signature compliant with Objective-C messaging.
        /// </returns>
        /// <exception cref = "ArgumentNullException">If the method is null.</exception>
        internal static String GetSignature(MethodInfo methodInfo, int parametersToSkip)
        {
            if (methodInfo == null)
            {
                throw new ArgumentNullException("methodInfo");
            }

            StringBuilder builder = new StringBuilder();
            ParameterInfo[] parameters = methodInfo.GetParameters();
            Type returnType = methodInfo.ReturnType;

            // Add common prefix
            builder.Append(SIGNATURE_PREFIX);
            // Add self and SEL offsets
            int offset = IntPtr.Size*2;

            int alignmentMask;
            foreach (ParameterInfo t in parameters)
            {
                if (parametersToSkip-- > 0)
                {
                    continue;
                }

                // Compute the type encoding and offset
                Type type = t.ParameterType;
                alignmentMask = (1 << GetTypeAlignment(type)) - 1;
                offset = (offset + alignmentMask) & ~alignmentMask;

                builder.AppendFormat(CultureInfo.CurrentCulture, ENCODING_OFFSET, GetTypeEncoding(type), offset);

                offset += GetTypeSize(type);
            }

            // Compute the return type encoding and offset
            alignmentMask = (1 << GetTypeAlignment(returnType)) - 1;
            offset = (offset + alignmentMask) & ~alignmentMask;

            String returnEncoding = String.Format(CultureInfo.CurrentCulture, ENCODING_OFFSET, GetTypeEncoding(returnType), offset);
            builder.Insert(0, returnEncoding);

            return builder.ToString();
        }

        /// <summary>
        ///   <para>Return the Objective-C encoding used to build selector signature.</para>
        ///   <para>Here are some examples of encoding:
        ///     <list type = "table">
        ///       <listheader>
        ///         <term>Type</term>
        ///         <description>Corresponding encoding</description>
        ///       </listheader>
        ///       <item>
        ///         <term>void</term>
        ///         <description>v</description>
        ///       </item>
        ///       <item>
        ///         <term>int or Int32</term>
        ///         <description>i</description>
        ///       </item>
        ///       <item>
        ///         <term>NSString</term>
        ///         <description>@</description>
        ///       </item>
        ///       <item>
        ///         <term>int[]</term>
        ///         <description>^i</description>
        ///       </item>
        ///       <item>
        ///         <term>NSRect</term>
        ///         <description>{NSRect={NSPoint=ff}{NSSize=ff}}</description>
        ///       </item>
        ///     </list>
        ///   </para>
        ///   <para>For a full list of the encoding, refer to http://developer.apple.com/documentation/Cocoa/Conceptual/ObjectiveC/Articles/chapter_5_section_7.html</para>
        /// </summary>
        /// <param name = "type">The type to encode.</param>
        /// <returns>The encoding representation</returns>
        public static String GetTypeEncoding(Type type)
        {
            return GetTypeEncodingInternal(type.TypeHandle.Value);
        }

        /// <summary>
        ///   <para>Return the native type size. The value represents the natural size of the type.</para>
        ///   <para>Here are some examples of sizes:
        ///     <list type = "table">
        ///       <listheader>
        ///         <term>Type</term>
        ///         <description>Corresponding size (on IA32 architecture)</description>
        ///       </listheader>
        ///       <item>
        ///         <term>bool or Boolean</term>
        ///         <description>1</description>
        ///       </item>
        ///       <item>
        ///         <term>int or Int32</term>
        ///         <description>4</description>
        ///       </item>
        ///       <item>
        ///         <term>NSString</term>
        ///         <description>4</description>
        ///       </item>
        ///       <item>
        ///         <term>NSRect</term>
        ///         <description>16</description>
        ///       </item>
        ///     </list>
        ///   </para>
        /// </summary>
        /// <para>Of course, the size value is platform dependant.</para>
        /// <param name = "type">The type to measure.</param>
        /// <returns>The size value</returns>
        public static int GetTypeSize(Type type)
        {
            return GetTypeSizeInternal(type.TypeHandle.Value);
        }

        /// <summary>
        ///   <para>Return the native type alignment size used to build selector signature. The value represents the size of the parameter on the stack.</para>
        ///   <para>Here are some examples of sizes:
        ///     <list type = "table">
        ///       <listheader>
        ///         <term>Type</term>
        ///         <description>Corresponding size (on IA32 architecture)</description>
        ///       </listheader>
        ///       <item>
        ///         <term>bool or Boolean</term>
        ///         <description>1</description>
        ///       </item>
        ///       <item>
        ///         <term>int or Int32</term>
        ///         <description>4</description>
        ///       </item>
        ///       <item>
        ///         <term>NSString</term>
        ///         <description>4</description>
        ///       </item>
        ///       <item>
        ///         <term>NSRect</term>
        ///         <description>16</description>
        ///       </item>
        ///     </list>
        ///   </para>
        /// </summary>
        /// <para>Of course, the size value is platform dependant.</para>
        /// <param name = "type">The type to measure.</param>
        /// <returns>The size value</returns>
        public static int GetTypeAlignment(Type type)
        {
            return GetTypeAlignmentInternal(type.TypeHandle.Value);
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern String GetTypeEncodingInternal(IntPtr type);

        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        private static extern int GetTypeSizeInternal(IntPtr type);

        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        private static extern int GetTypeAlignmentInternal(IntPtr type);
    }
}