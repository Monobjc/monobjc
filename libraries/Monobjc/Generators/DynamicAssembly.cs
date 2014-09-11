//
// This file is part of Monobjc, a .NET/Objective-C bridge
// Copyright (C) 2007-2014 - Laurent Etiemble
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
using System.Reflection.Emit;

namespace Monobjc.Generators
{
	/// <summary>
	///   TODO: Doc
	/// </summary>
	internal class DynamicAssembly
	{
		private readonly String assemblyName;
		private readonly AssemblyBuilder assembly;
		private readonly String moduleName;
		private readonly ModuleBuilder module;

        public DynamicAssembly (String assemblyName, String moduleName, AssemblyBuilderAccess access = AssemblyBuilderAccess.RunAndSave)
        {
            this.assemblyName = assemblyName;
            this.moduleName = moduleName;

            // Define dynamic assembly
            AssemblyName name = new AssemblyName { Name = this.assemblyName, Version = Assembly.GetExecutingAssembly().GetName().Version };
            this.assembly = AppDomain.CurrentDomain.DefineDynamicAssembly (name, access);

            // Define dynamic module
            if (access == AssemblyBuilderAccess.RunAndSave || access == AssemblyBuilderAccess.Save) {
                // Persistent
                this.module = this.assembly.DefineDynamicModule (this.moduleName, this.assemblyName + ".dll");
            } else {
                // Transient
                this.module = this.assembly.DefineDynamicModule (this.moduleName);
            }
        }

		public String Save ()
		{
			String file = this.assemblyName + ".dll";
			this.assembly.Save (file);
			return file;
		}

		public TypeBuilder AddType (String typeName)
		{
			return this.AddType (typeName, typeof(Object), false);
		}

		public TypeBuilder AddType (String typeName, Type parentType)
		{
			return this.AddType (typeName, parentType, false);
		}

		public TypeBuilder AddType (String typeName, bool isStatic)
		{
			return this.AddType (typeName, typeof(Object), isStatic);
		}

		public TypeBuilder AddType (String typeName, Type parentType, bool isStatic)
		{
			return EmitHelper.DefineType (this.module, typeName, parentType, isStatic);
		}

		public Type GetType (String typeName)
		{
			return this.assembly.GetType (typeName);
		}
	}
}