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
using System.CodeDom.Compiler;
using System.Globalization;
using System.Runtime.InteropServices;

using Monobjc;
using Monobjc.Foundation;

namespace Monobjc.Accounts
{
	public struct __StructureToMakeNamespaceVisible
	{
	}

#if MACOSX_10_8
	/// <summary>
	/// <para>Specifies a handler to call when an Accounts database operation is complete.</para>
	/// </summary>
	/// <param name="success">A Boolean value indicating whether the operation is successful. YES if the operation is successful; otherwise NO.</param>
	/// <param name="error">An error, if one occurred.</param>
	public delegate void ACAccountStoreSaveCompletionHandler(bool success, NSError error);

	/// <summary>
	/// <para>Specifies a handler to call when an Accounts database operation is complete.</para>
	/// </summary>
	/// <param name="success">A Boolean value indicating whether the operation is successful. YES if the operation is successful; otherwise NO.</param>
	/// <param name="error">An error, if one occurred.</param>
	public delegate void ACAccountStoreRemoveCompletionHandler(bool success, NSError error);

	/// <summary>
	/// <para>Specifies a handler to call when access is granted or denied.</para>
	/// </summary>
	/// <param name="success">A Boolean value indicating whether the operation is successful. YES if the operation is successful; otherwise NO.</param>
	/// <param name="error">An error, if one occurred.</param>
	public delegate void ACAccountStoreRequestAccessCompletionHandler(bool success, NSError error);

	/// <summary>
	/// <para>Specifies a handler to call when credentials are renewed.</para>
	/// </summary>
	/// <param name="renewResult">The result of the renewal request.</param>
	/// <param name="error">An error, if one occurred.</param>
	public delegate void ACAccountStoreCredentialRenewalHandler(ACAccountCredentialRenewResult renewResult, NSError error);
#endif
}
