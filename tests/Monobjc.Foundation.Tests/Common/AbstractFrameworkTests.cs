//
// This file is part of Monobjc, a .NET/Objective-C bridge
// Copyright (C) 2007-2012 - Laurent Etiemble
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
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using NUnit.Framework;

namespace Monobjc.Foundation.Common
{
    [Category("Framework")]
    [Description("Test the framework on various aspects (inheritance, constructors, etc)")]
    public abstract class AbstractFrameworkTests : AbstractObjectiveCTests
    {
        protected abstract string AssemblyName { get; }

        protected abstract void EnsureAssemblyIsReferenced();

        private Assembly Assembly
        {
            get
            {
                this.EnsureAssemblyIsReferenced();
                Assembly assembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(a => a.GetName().Name == this.AssemblyName);
                Assert.NotNull(assembly, "Assembly " + this.AssemblyName + " must be found");
                return assembly;
            }
        }

        [Test]
        public void TestClassHierarchy()
        {
            foreach (Type type in this.Assembly.GetTypes())
            {
                // Type must be an Id subclass
                if (!typeof (Id).IsAssignableFrom(type))
                {
                    continue;
                }

                // Test for the class attribute
                ObjectiveCClassAttribute objectiveCClassAttribute = Attribute.GetCustomAttribute(type, typeof (ObjectiveCClassAttribute), false) as ObjectiveCClassAttribute;
                if (objectiveCClassAttribute == null)
                {
                    continue;
                }

                if (objectiveCClassAttribute.InterceptDealloc)
                {
                    continue;
                }

                Class cls = Class.Get(type);
                Class superClass = Class.Get(type.BaseType);
                Class expectedClass = cls.SuperClass;

                if (expectedClass.Name.StartsWith("%"))
                {
                    expectedClass = expectedClass.SuperClass;
                }

                if (expectedClass == null)
                {
                    continue;
                }

                String superName = superClass.Name;

                Assert.AreEqual(expectedClass.Name, superName, "Superclasses must be equals for " + type.Name);
            }
        }

        [Test]
        public void TestEventDispatcherHierarchy()
        {
            foreach (Type type in this.Assembly.GetTypes())
            {
                // Type must be an Id subclass
                if (!typeof (Id).IsAssignableFrom(type))
                {
                    continue;
                }

                // Test for the class attribute
                ObjectiveCClassAttribute objectiveCClassAttribute = Attribute.GetCustomAttribute(type, typeof (ObjectiveCClassAttribute), false) as ObjectiveCClassAttribute;
                if (objectiveCClassAttribute == null)
                {
                    continue;
                }

                if (!type.IsNested)
                {
                    continue;
                }

                String classname = type.Name;
                if (!classname.EndsWith("EventDispatcher"))
                {
                    continue;
                }

                Type baseType = type.BaseType;
                Type declaringType = type.DeclaringType;
                Type declaringBaseType = type.DeclaringType.BaseType;

                String expectedBaseTypeName = declaringBaseType + "+" + declaringBaseType.Name + "EventDispatcher";
                try
                {
                    this.Assembly.GetType(expectedBaseTypeName, true);
                }
                catch
                {
                    continue;
                }

                Assert.AreEqual(expectedBaseTypeName, baseType.FullName, "Type " + classname + " has wrong super class; it should be " + expectedBaseTypeName);
            }
        }

        [Test]
        public void TestConstructors()
        {
            foreach (Type type in this.Assembly.GetTypes())
            {
                // Type must be an Id subclass
                if (!typeof (Id).IsAssignableFrom(type))
                {
                    continue;
                }

                // Test for the Register attribute
                ObjectiveCClassAttribute objectiveCClassAttribute = Attribute.GetCustomAttribute(type, typeof (ObjectiveCClassAttribute), false) as ObjectiveCClassAttribute;
                if (objectiveCClassAttribute == null)
                {
                    continue;
                }

                Type baseType = type.BaseType;

                ConstructorInfo[] constructorInfos = type.GetConstructors(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
                ConstructorInfo[] baseConstructorInfos = baseType.GetConstructors(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

                // Check number of constructors
                Assert.Greater(constructorInfos.Length, 1, "Type " + type.FullName + " should have at least two constructors");

                // Check empty constructor
                ConstructorInfo constructor = type.GetConstructor(Type.EmptyTypes);
                Assert.IsNotNull(constructor, "Type " + type.FullName + " should have an empty constructor");

                // Check constructor with a single IntPtr parametere
                constructor = type.GetConstructor(new[] {typeof (IntPtr)});
                Assert.IsNotNull(constructor, "Type " + type.FullName + " should have a constructor with a single parameter IntPtr");

                // Check that every constructor from base type is present in type
                foreach (ConstructorInfo constructorInfo in baseConstructorInfos)
                {
                    ParameterInfo[] parameterInfos = constructorInfo.GetParameters();
                    Type[] types = new Type[parameterInfos.Length];
                    int i = 0;
                    foreach (ParameterInfo parameterInfo in parameterInfos)
                    {
                        types[i++] = parameterInfo.ParameterType;
                    }

                    constructor = type.GetConstructor(types);
                    Assert.IsNotNull(constructor, "Type " + type.FullName + " should inherit a constructor with the following signature " + constructorInfo);

                    //if (constructor == null)
                    //{
                    //    Console.WriteLine("Type " + type.FullName + " should inherit a constructor with the following signature " + constructorInfo + " from " + constructorInfo.DeclaringType);
                    //}
                }
            }
        }

        [Test]
        public void TestNativeInteropEntryPoints()
        {
            foreach (Type type in this.Assembly.GetTypes())
            {
                // Search for all the 'public static extern' methods with a DLLImport attribute
                MethodInfo[] methodInfos = type.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Static);
                foreach (MethodInfo methodInfo in methodInfos)
                {
                    DllImportAttribute[] methodAttributes = methodInfo.GetCustomAttributes(typeof (DllImportAttribute), false) as DllImportAttribute[];
                    if (methodAttributes == null || methodAttributes.Length != 1)
                    {
                        continue;
                    }

                    String library = methodAttributes[0].Value;
                    String entryPoint = methodAttributes[0].EntryPoint;

                    if (String.IsNullOrEmpty(entryPoint))
                    {
                        entryPoint = methodInfo.Name;
                    }

                    // Load the native library
                    IntPtr handle = dlopen(library, 0x02);
                    if (handle == IntPtr.Zero)
                    {
                        handle = dlopen(library + ".dylib", 0x02);
                    }
                    Assert.AreNotEqual(IntPtr.Zero, handle, "Cannot load native library " + library + " or " + library + ".dylib");

                    // Lookup for the funtion to see if it is defined
                    IntPtr function = dlsym(handle, entryPoint);
                    Assert.AreNotEqual(IntPtr.Zero, function, "Cannot load symbol " + entryPoint + " in library " + library);

                    //Console.WriteLine("Symbol " + entryPoint + " in library " + library + " found.");
                }
            }
        }

        [Test]
        public void TestNativeInteropAttributes()
        {
            foreach (Type type in this.Assembly.GetTypes())
            {
                // Search for all the 'public static extern' methods with a DLLImport attribute
                MethodInfo[] methodInfos = type.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Static);
                foreach (MethodInfo methodInfo in methodInfos)
                {
                    DllImportAttribute[] methodAttributes = methodInfo.GetCustomAttributes(typeof (DllImportAttribute), false) as DllImportAttribute[];
                    if (methodAttributes == null || methodAttributes.Length != 1)
                    {
                        continue;
                    }

                    Type returnType = methodInfo.ReturnType;
                    ICustomAttributeProvider provider = methodInfo.ReturnTypeCustomAttributes;
                    Object[] returnTypeAttributes = provider.GetCustomAttributes(false);

                    // Check that the return type has correct attributes if it is an Id subclass
                    CheckTypeHasRightAttributes(methodInfo, returnType, returnTypeAttributes, true);

                    // Check that each parameter has correct attributes if it is an Id subclass
                    foreach (ParameterInfo parameterInfo in methodInfo.GetParameters())
                    {
                        Type parameterType = parameterInfo.ParameterType;
                        Object[] parameterTypeAttributes = parameterInfo.GetCustomAttributes(false);
                        CheckTypeHasRightAttributes(methodInfo, parameterType, parameterTypeAttributes, false);
                    }
                }
            }
        }

        private static void CheckTypeHasRightAttributes(MethodInfo methodInfo, Type type, Object[] attributes, bool isReturnType)
        {
            if (typeof (Id).IsAssignableFrom(type))
            {
                if (attributes != null)
                {
                    String location;
                    if (isReturnType)
                    {
                        location = "on return type";
                    }
                    else
                    {
                        location = "on parameters";
                    }

                    bool found = false;
                    foreach (object o in attributes)
                    {
                        MarshalAsAttribute marshalAsAttribute = o as MarshalAsAttribute;
                        if (marshalAsAttribute != null)
                        {
                            Assert.IsNotNull(marshalAsAttribute, "MarshalAsAttribute is missing " + location + " for " + methodInfo.DeclaringType + "." + methodInfo);
                            Assert.AreEqual(UnmanagedType.CustomMarshaler, marshalAsAttribute.Value, "MarshalAsAttribute must have the CustomMarshaler type " + location + " for " + methodInfo.DeclaringType + "." + methodInfo);
                            Assert.IsTrue(marshalAsAttribute.MarshalTypeRef.IsGenericType, "MarshalAsAttribute must have the a generic marshalling type " + location + " for " + methodInfo.DeclaringType + "." + methodInfo);
                            Assert.AreEqual(typeof (IdMarshaler<>), marshalAsAttribute.MarshalTypeRef.GetGenericTypeDefinition(), "MarshalAsAttribute must have the IdMarshaler type " + location + " for " + methodInfo.DeclaringType + "." + methodInfo);
                            Assert.AreEqual(marshalAsAttribute.MarshalTypeRef.GetGenericArguments().GetValue(0), type, "MarshalAsAttribute must have the IdMarshaler<" + type + "> type " + location + " for " + methodInfo.DeclaringType + "." + methodInfo);
                            found = true;
                        }
                    }
                    if (!found)
                    {
                        Assert.Fail("No MarshalAsAttribute found " + location + " for " + methodInfo.DeclaringType + "." + methodInfo);
                    }
                }
            }
        }

        [DllImport("libobjc", CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        private static extern IntPtr dlopen([MarshalAs(UnmanagedType.LPStr)] String path, int type);

        [DllImport("libobjc", CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        private static extern IntPtr dlsym(IntPtr handle, [MarshalAs(UnmanagedType.LPStr)] String path);
    }
}