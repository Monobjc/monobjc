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
using NUnit.Framework;

namespace Monobjc.Foundation.Common
{
	[Category("Wrapper")]
	[Description("Test the wrappers")]
	public abstract class AbstractObjectiveCTests
	{
		protected AbstractObjectiveCTests (TestEnvironment env)
		{
			this.Env = env;
		}

		protected TestEnvironment Env { get; private set; }
		
		[TestFixtureSetUp]
		public void TestFixtureSetUp ()
		{
			if (!this.Env.IsAvailable) {
				return;
			}
			
			try {
				foreach (String framework in this.Env.Frameworks) {
					ObjectiveCRuntime.LoadFramework (framework);
				}
			} catch (Exception ex) {
				Assert.Ignore ("Cannot initialize runtime:\n{0}", ex);
			}

            try {
                // Enable auto domain tokens to support running tests in multiple domains.
                //
                // Note: This will append domain tokens to types in secondary domains. If
                // any tests are added which rely on specific class names being present 
                // (e.g. NSCoder serializtion) then those tests will need to execute in a single
                // domain on the command-line using the domain=single option or have their
                // fixtures setup using a well-known token which can be integrated into the 
                // test or resource names and also passed to Initialize().
                ObjectiveCRuntime.EnableAutoDomainTokens();
                ObjectiveCRuntime.Initialize ();
            } catch (Exception ex) {
                Assert.Fail ("Cannot initialize runtime:\n{0}", ex);
            }
		}
	}
}