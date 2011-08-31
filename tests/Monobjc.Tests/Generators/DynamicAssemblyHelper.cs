//
// This file is part of Monobjc, a .NET/Objective-C bridge
// Copyright (C) 2007-2011 - Laurent Etiemble
//
// Monobjc is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// any later version.
//
// Monobjc is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with Monobjc.  If not, see <http://www.gnu.org/licenses/>.
//
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Monobjc.Generators.Cecil;
using NUnit.Framework;

namespace Monobjc.Generators
{
    internal static class DynamicAssemblyHelper
    {
        public static String GetAssemblyName(Object obj, int number)
        {
            return String.Format("{0}_{1}", obj.GetType(), number);
        }

        private const BindingFlags ALL = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly;

        public static void Compare(Type referenceType, Type testedType)
        {
            Assert.IsNotNull(testedType, "Type is null");
            Assert.IsNotNull(referenceType, "Reference Type is null");

            String prefix = referenceType.Name + "_";

            Assert.AreEqual(referenceType.BaseType, testedType.BaseType, prefix + "Superclasses are different");
            Assert.AreEqual(referenceType.Attributes, testedType.Attributes, prefix + "Attributes are different");

            // Constructors comparison
            ConstructorInfo[] constructorInfos = referenceType.GetConstructors(ALL);
            Assert.AreEqual(constructorInfos.Length, testedType.GetConstructors(ALL).Length, prefix + "Number of Constructors are different");
            foreach (ConstructorInfo constructorInfo in constructorInfos)
            {
                String constructorPrefix = prefix + "Constructor_" + constructorInfo.Name;

                Type[] types = Array.ConvertAll(constructorInfo.GetParameters(), param => param.ParameterType);
                ConstructorInfo testedconstructorInfo = testedType.GetConstructor(ALL, null, types, null);
                Assert.IsNotNull(testedconstructorInfo, constructorPrefix + " is missing");

                Assert.AreEqual(constructorInfo.Attributes, testedconstructorInfo.Attributes, constructorPrefix + " has wrong attributes");
                Assert.AreEqual(constructorInfo.CallingConvention, testedconstructorInfo.CallingConvention, constructorPrefix + " has wrong calling convention");
                Assert.AreEqual(constructorInfo.IsGenericMethod, testedconstructorInfo.IsGenericMethod, constructorPrefix + " has wrong generic definition");

                Assert.AreEqual(constructorInfo.GetMethodImplementationFlags(), testedconstructorInfo.GetMethodImplementationFlags(), constructorPrefix + " has wrong implementation flags");

                ParameterInfo[] parameterInfos = constructorInfo.GetParameters();
                ParameterInfo[] testedParameterInfos = constructorInfo.GetParameters();
                CompareParameters(constructorPrefix, parameterInfos, testedParameterInfos);

                object[] customAttributes = constructorInfo.GetCustomAttributes(false);
                object[] testedCustomAttributes = testedconstructorInfo.GetCustomAttributes(false);
                if ((customAttributes == null && testedCustomAttributes != null) ||
                    (customAttributes != null && testedCustomAttributes == null))
                {
                    Assert.Fail(constructorPrefix + "Custom Attributes mismatch");
                }
                if (customAttributes != null && testedCustomAttributes != null)
                {
                    Assert.AreEqual(customAttributes.Length, testedCustomAttributes.Length);
                    for (int i = 0; i < customAttributes.Length; i++)
                    {
                        //Console.WriteLine(">"+customAttributes[i]);
                        //Console.WriteLine("<"+testedCustomAttributes[i]);
                        CompareAttributes(constructorPrefix, (Attribute) customAttributes[i], (Attribute) testedCustomAttributes[i]);
                    }
                }
            }

            // Events comparison
            Assert.AreEqual(referenceType.GetEvents().Length, testedType.GetEvents(ALL).Length, prefix + "Number of Events are different");
            // TODO: Missing comparison

            // Fields comparison
            FieldInfo[] fieldInfos = referenceType.GetFields(ALL);
            Assert.AreEqual(fieldInfos.Length, testedType.GetFields(ALL).Length, prefix + "Number of Fields are different");
            foreach (FieldInfo fieldInfo in fieldInfos)
            {
                String fieldPrefix = "Field_" + fieldInfo.Name;
                FieldInfo testedFieldInfo = testedType.GetField(fieldInfo.Name, ALL);
                Assert.IsNotNull(testedFieldInfo, fieldPrefix + " is missing");

                Assert.AreEqual(fieldInfo.Attributes, testedFieldInfo.Attributes, fieldPrefix + " has wrong attributes");
            }

            // Interfaces comparison
            Assert.AreEqual(referenceType.GetInterfaces().Length, testedType.GetInterfaces().Length, prefix + "Number of Interfaces are different");
            // TODO: Missing comparison

            // Methods comparison
            MethodInfo[] methodInfos = referenceType.GetMethods(ALL);
            Assert.AreEqual(methodInfos.Length, testedType.GetMethods(ALL).Length, prefix + "Number of Methods are different");
            foreach (MethodInfo methodInfo in methodInfos)
            {
                String methodPrefix = prefix + "Method_" + methodInfo.Name;

                // Skip methods like Finalize
                if (String.Equals("Finalize", methodInfo.Name))
                {
                    continue;
                }

                MethodInfo testedMethodInfo = testedType.GetMethod(methodInfo.Name, ALL);
                Assert.IsNotNull(testedMethodInfo, methodPrefix + " is missing");

                Assert.AreEqual(methodInfo.Attributes, testedMethodInfo.Attributes, methodPrefix + " has wrong attributes");
                Assert.AreEqual(methodInfo.CallingConvention, testedMethodInfo.CallingConvention, methodPrefix + " has wrong calling convention");
                Assert.AreEqual(methodInfo.IsGenericMethod, testedMethodInfo.IsGenericMethod, methodPrefix + " has wrong generic definition");
                Assert.AreEqual(methodInfo.ReturnType, testedMethodInfo.ReturnType, methodPrefix + " has wrong return type");

                Assert.AreEqual(methodInfo.GetMethodImplementationFlags(), testedMethodInfo.GetMethodImplementationFlags(), methodPrefix + " has wrong implementation flags");

                ParameterInfo[] parameterInfos = methodInfo.GetParameters();
                ParameterInfo[] testedParameterInfos = testedMethodInfo.GetParameters();
                CompareParameters(methodPrefix, parameterInfos, testedParameterInfos);

                object[] customAttributes = methodInfo.GetCustomAttributes(false);
                object[] testedCustomAttributes = testedMethodInfo.GetCustomAttributes(false);
                if ((customAttributes == null && testedCustomAttributes != null) ||
                    (customAttributes != null && testedCustomAttributes == null))
                {
                    Assert.Fail(methodPrefix + "Custom Attributes mismatch");
                }

                if (customAttributes != null && testedCustomAttributes != null)
                {
                    Assert.AreEqual(customAttributes.Length, testedCustomAttributes.Length);
                    for (int i = 0; i < customAttributes.Length; i++)
                    {
                        //Console.WriteLine(">"+customAttributes[i]);
                        //Console.WriteLine("<"+testedCustomAttributes[i]);
                        CompareAttributes(methodPrefix, (Attribute) customAttributes[i], (Attribute) testedCustomAttributes[i]);
                    }
                }

                // Check method bodies
                byte[] methodBody = methodInfo.GetMethodBody() != null ? methodInfo.GetMethodBody().GetILAsByteArray() : null;
                byte[] testedMethodBody = testedMethodInfo.GetMethodBody() != null ? testedMethodInfo.GetMethodBody().GetILAsByteArray() : null;
                if (methodBody == null && testedMethodBody != null ||
                    methodBody != null && testedMethodBody == null)
                {
                    Assert.Fail(methodPrefix + "Method bodies mismatch");
                }

                if (methodBody != null && testedMethodBody != null)
                {
                    if (methodBody.Length != testedMethodBody.Length)
                    {
                        //Assert.Inconclusive(methodPrefix + ": Bodies are different length");
                    }

                    IEnumerable<Instruction> instructions = MethodBodyReader.GetInstructions(methodInfo);
                    IEnumerable<Instruction> testedInstructions = MethodBodyReader.GetInstructions(testedMethodInfo);

                    Directory.CreateDirectory("Methods");

                    //String[] lines1 = instructions.Select(i => i.OpCode + " " + i.Operand).ToArray();
                    String[] lines1 = instructions.Where(i => i.OpCode != OpCodes.Nop).Select(i => i.OpCode + " " + i.Operand).ToArray();
                    String file1 = "Methods/" + methodPrefix + "_expected.txt";
                    File.WriteAllLines(file1, lines1);
                    //String[] lines2 = testedInstructions.Select(i => i.OpCode + " " + i.Operand).ToArray();
                    String[] lines2 = testedInstructions.Where(i => i.OpCode != OpCodes.Nop).Select(i => i.OpCode + " " + i.Operand).ToArray();
                    String file2 = "Methods/" + methodPrefix + "_generated.txt";
                    File.WriteAllLines(file2, lines2);

                    /*
                    for(int i = 0; i < instructions.Count; i++)
                    {
                        var instruction = instructions[i];
                        Console.WriteLine(instruction.Offset.ToString("X") + ": " + instruction.OpCode + " " + instruction.Operand);
                    }
                    for(int i = 0; i < testedInstructions.Count; i++)
                    {
                        var instruction = testedInstructions[i];
                        Console.WriteLine(instruction.Offset.ToString("X") + ": " + instruction.OpCode + " " + instruction.Operand);
                    }
                    */
                }
            }

            // Nested Types comparison
            Type[] nestedTypes = referenceType.GetNestedTypes(ALL);
            Assert.AreEqual(nestedTypes.Length, testedType.GetNestedTypes(ALL).Length, prefix + "Number of NestedTypes are different");
            foreach (Type nestedType in nestedTypes)
            {
                String nestedTypePrefix = prefix + "NestedType_" + nestedType.Name;
                Type testedNestedType = testedType.GetNestedType(nestedType.Name, ALL);
                Assert.IsNotNull(testedNestedType, nestedTypePrefix + " is missing");

                Compare(nestedType, testedNestedType);
            }

            // Properties comparison
            PropertyInfo[] properties = referenceType.GetProperties(ALL);
            Assert.AreEqual(properties.Length, testedType.GetProperties(ALL).Length, prefix + "Number of Properties are different");
            foreach (PropertyInfo propertyInfo in properties)
            {
                String propertyPrefix = prefix + "Property_" + propertyInfo.Name;
                PropertyInfo testedPropertyInfo = testedType.GetProperty(propertyInfo.Name, ALL);
                Assert.IsNotNull(testedPropertyInfo, propertyPrefix + " is missing");

                Assert.AreEqual(propertyInfo.PropertyType, testedPropertyInfo.PropertyType, propertyPrefix + " has wrong type");
                Assert.AreEqual(propertyInfo.CanRead, testedPropertyInfo.CanRead, propertyPrefix + " has wrong read access");
                Assert.AreEqual(propertyInfo.CanWrite, testedPropertyInfo.CanWrite, propertyPrefix + " has wrong write access");
            }
        }

        private static void CompareParameters(String methodPrefix, ParameterInfo[] referenceParameterInfos, ParameterInfo[] testedParameterInfos)
        {
            Assert.AreEqual(referenceParameterInfos.Length, testedParameterInfos.Length, methodPrefix + " has wrong number of parameter");
            for (int i = 0; i < referenceParameterInfos.Length; i++)
            {
                ParameterInfo referenceParameterInfo = referenceParameterInfos[i];
                ParameterInfo testedParameterInfo = testedParameterInfos[i];

                Assert.AreEqual(referenceParameterInfo.Attributes, testedParameterInfo.Attributes, methodPrefix + " has wrong parameter attribute for " + referenceParameterInfo.Name);
                Assert.AreEqual(referenceParameterInfo.ParameterType, testedParameterInfo.ParameterType, methodPrefix + " has wrong parameter type for " + referenceParameterInfo.Name);
            }
        }

        private static void CompareAttributes(String methodPrefix, Attribute referenceAttribute, Attribute testedAttribute)
        {
            Type type = referenceAttribute.GetType();
            if (type.Equals(typeof (DllImportAttribute)))
            {
                DllImportAttribute a1 = (DllImportAttribute) referenceAttribute;
                DllImportAttribute a2 = (DllImportAttribute) testedAttribute;
                Assert.AreEqual(a1.BestFitMapping, a2.BestFitMapping, methodPrefix + " has wrong DllImportAttribute");
                Assert.AreEqual(a1.CallingConvention, a2.CallingConvention, methodPrefix + " has wrong DllImportAttribute");
                Assert.AreEqual(a1.CharSet, a2.CharSet, methodPrefix + " has wrong DllImportAttribute");
                Assert.AreEqual(a1.EntryPoint, a2.EntryPoint, methodPrefix + " has wrong DllImportAttribute");
                Assert.AreEqual(a1.ExactSpelling, a2.ExactSpelling, methodPrefix + " has wrong DllImportAttribute");
                Assert.AreEqual(a1.PreserveSig, a2.PreserveSig, methodPrefix + " has wrong DllImportAttribute");
                Assert.AreEqual(a1.SetLastError, a2.SetLastError, methodPrefix + " has wrong DllImportAttribute");
                Assert.AreEqual(a1.ThrowOnUnmappableChar, a2.ThrowOnUnmappableChar, methodPrefix + " has wrong DllImportAttribute");
                Assert.AreEqual(a1.Value, a2.Value, methodPrefix + " has wrong DllImportAttribute");
            }
            else if (type.Equals(typeof (MethodImplAttribute)))
            {
                MethodImplAttribute a1 = (MethodImplAttribute) referenceAttribute;
                MethodImplAttribute a2 = (MethodImplAttribute) testedAttribute;
                Assert.AreEqual(a1.Value, a2.Value, methodPrefix + " has wrong MethodImplAttribute");
            }
        }
    }
}