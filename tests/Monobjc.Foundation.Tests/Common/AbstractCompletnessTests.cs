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
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using NUnit.Framework;

namespace Monobjc.Foundation.Common
{
    [TestFixture]
    [Category("Wrapper")]
    [Description("Test the completness of the wrappers")]
    public abstract class AbstractCompletnessTests : AbstractObjectiveCTests
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
        public void TestClassCompletness()
        {
            foreach (Type type in this.Assembly.GetTypes())
            {
                // Type must be an Id subclass
                if (!typeof(Id).IsAssignableFrom(type))
                {
                    continue;
                }

                // Test for the class attribute
                ObjectiveCClassAttribute objectiveCClassAttribute = Attribute.GetCustomAttribute(type, typeof(ObjectiveCClassAttribute), false) as ObjectiveCClassAttribute;
                if (objectiveCClassAttribute == null)
                {
                    continue;
                }

                Class cls = Class.Get(type);
				if (cls.Name.EndsWith("Dispatcher")) {
					continue;
				}

				MethodInfo[] methodInfos = type.GetMethods(BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);
				IList<String> methodNames = new List<String>(methodInfos.Select(m => m.Name));
				PropertyInfo[] propertyInfos = type.GetProperties(BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);
				IList<String> propertyNames = new List<String>(propertyInfos.Select(p => p.Name));
				
                int count;
                IntPtr listPtr = class_copyMethodList(cls.NativePointer, out count);
                //Console.WriteLine("Class=" + cls.Name);
				double matches = 0;
                for (int i = 0; i < count; i++)
                {
                    IntPtr ptr = new IntPtr(listPtr.ToInt64() + i * IntPtr.Size);
                    IntPtr method = Marshal.ReadIntPtr(ptr);
                    IntPtr selectorPtr = method_getName(method);
                    String selector = ObjectiveCRuntime.Selector(selectorPtr);
					if (selector.StartsWith("_"))
					{
						matches++;
						continue;
					}
					if (selector.EndsWith("_"))
					{
						matches++;
						continue;
					}
					
					String methodName = GetMethodName(selector);
					
					bool found = false;
					found |= methodNames.Contains(methodName);
					found |= propertyNames.Contains(methodName);
					found |= propertyNames.Contains("Is" + methodName);
					found |= propertyNames.Contains("Has" + methodName);
					if (methodName.StartsWith("Set")) {
						found |= propertyNames.Contains(methodName.Substring(3));
					}
					
					if (found)
					{
						matches++;
					}
					else
					{
						//Console.WriteLine("MISSING: '{0}' => '{1}'", selector, methodName);
					}
                }
                free(listPtr);
				
				double ratio = matches / count;
				//Console.WriteLine("R;{0};{1}", cls.Name, ratio);
				if (ratio < 0.25)
				{
					//Console.WriteLine("{0}: {1}/{2} -> BAD", cls.Name, matches, count);
					//Assert.Fail("Less than 25% of members are wrapped for {0}", cls.Name);
				}
                /*
                else if (ratio < 0.5)
                {
                    Console.WriteLine("{0}: {1}/{2} -> LOW", cls.Name, matches, count);
                    //Assert.Inconclusive("Less than 50% of members are wrapped for {0}", cls.Name);
                }
                else if (ratio < 0.75)
                {
                    Console.WriteLine("{0}: {1}/{2} -> HIGH", cls.Name, matches, count);
                    //Assert.Inconclusive("Less than 75% of members are wrapped for {0}", cls.Name);
                }
                else
                {
                    Console.WriteLine("{0}: {1}/{2} -> GOOD", cls.Name, matches, count);
                    //Assert.Pass("More than 75% of members are wrapped for {0}", cls.Name);
                }
                Console.WriteLine();
                */
            }
        }

        private static String GetMethodName(String selector)
        {
            String[] parts = selector.Split(new[] {':'}, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder builder = new StringBuilder();
            foreach (String part in parts)
            {
                String token = UpperCaseFirstLetter(part);
                builder.Append(token);
            }
            return builder.ToString();
        }
		
        private static String UpperCaseFirstLetter(String str)
        {
            if (str.Length < 2)
            {
                return str;
            }
            str = str.Trim();
            str = str.Substring(0, 1).ToUpperInvariant() + str.Substring(1);
            return str;
        }
		
        [DllImport("libobjc")]
        private static extern IntPtr class_copyMethodList(IntPtr cls, out int outCount);

        [DllImport("libobjc")]
        private static extern IntPtr method_getName(IntPtr method);

        [DllImport("libSystem")]
        private static extern void free(IntPtr mem);
    }
}