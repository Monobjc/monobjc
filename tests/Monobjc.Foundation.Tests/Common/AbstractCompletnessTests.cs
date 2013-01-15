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
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using NUnit.Framework;

namespace Monobjc.Foundation.Common
{
	[Category("Wrapper")]
	[Description("Test the completness of the wrappers")]
	public abstract class AbstractCompletnessTests : AbstractObjectiveCTests
	{
		protected AbstractCompletnessTests (TestEnvironment env) : base(env)
		{
		}
		
		private Assembly Assembly {
			get {
				this.Env.EnsureAssemblyIsReferenced ();
				Assembly assembly = AppDomain.CurrentDomain.GetAssemblies ().FirstOrDefault (a => a.GetName ().Name == this.Env.AssemblyName);
				Assert.NotNull (assembly, "Assembly " + this.Env.AssemblyName + " must be found");
				return assembly;
			}
		}

		[Test]
		public void TestClassCompletness ()
		{
			if (!this.Env.IsAvailable) {
				Assert.Ignore("Framework not available");
				return;
			}
			
			foreach (Type type in this.Assembly.GetTypes()) {
				// Type must be an Id subclass
				if (!typeof(Id).IsAssignableFrom (type)) {
					continue;
				}

				// Test for the class attribute
				ObjectiveCClassAttribute objectiveCClassAttribute = Attribute.GetCustomAttribute (type, typeof(ObjectiveCClassAttribute), false) as ObjectiveCClassAttribute;
				if (objectiveCClassAttribute == null) {
					continue;
				}

				Class cls = Class.Get (type);
				if (cls.Name.EndsWith ("Dispatcher")) {
					continue;
				}

				MethodInfo[] methodInfos = type.GetMethods (BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);
				IList<String> methodNames = new List<String> (methodInfos.Select (m => m.Name));
				PropertyInfo[] propertyInfos = type.GetProperties (BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);
				IList<String> propertyNames = new List<String> (propertyInfos.Select (p => p.Name));
				
				int count;
				IntPtr listPtr = class_copyMethodList (cls.NativePointer, out count);
				//Console.WriteLine("Class=" + cls.Name);
				double matches = 0;
				for (int i = 0; i < count; i++) {
					IntPtr ptr = new IntPtr (listPtr.ToInt64 () + i * IntPtr.Size);
					IntPtr method = Marshal.ReadIntPtr (ptr);
					IntPtr selectorPtr = method_getName (method);
					String selector = ObjectiveCRuntime.Selector (selectorPtr);
					if (selector.StartsWith ("_")) {
						matches++;
						continue;
					}
					if (selector.EndsWith ("_")) {
						matches++;
						continue;
					}
					
					String methodName = GetMethodName (selector);
					
					bool found = false;
					found |= methodNames.Contains (methodName);
					found |= propertyNames.Contains (methodName);
					found |= propertyNames.Contains ("Is" + methodName);
					found |= propertyNames.Contains ("Has" + methodName);
					if (methodName.StartsWith ("Set")) {
						found |= propertyNames.Contains (methodName.Substring (3));
					}
					
					if (found) {
						matches++;
					} else {
						//Console.WriteLine("MISSING: '{0}' => '{1}'", selector, methodName);
					}
				}
				free (listPtr);
				
				double ratio = matches / count;
				//Console.WriteLine("R;{0};{1}", cls.Name, ratio);
				if (ratio < 0.25) {
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

		private static String GetMethodName (String selector)
		{
			String[] parts = selector.Split (new[] {':'}, StringSplitOptions.RemoveEmptyEntries);
			StringBuilder builder = new StringBuilder ();
			foreach (String part in parts) {
				String token = UpperCaseFirstLetter (part);
				builder.Append (token);
			}
			return builder.ToString ();
		}
		
		private static String UpperCaseFirstLetter (String str)
		{
			if (str.Length < 2) {
				return str;
			}
			str = str.Trim ();
			str = str.Substring (0, 1).ToUpperInvariant () + str.Substring (1);
			return str;
		}
		
		[DllImport("libobjc")]
		private static extern IntPtr class_copyMethodList (IntPtr cls, out int outCount);

		[DllImport("libobjc")]
		private static extern IntPtr method_getName (IntPtr method);

		[DllImport("libSystem")]
		private static extern void free (IntPtr mem);
	}
}