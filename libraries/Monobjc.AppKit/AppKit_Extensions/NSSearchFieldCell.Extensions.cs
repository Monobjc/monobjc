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

using Monobjc;
using Monobjc.Foundation;
using Monobjc.CoreData;
using Monobjc.QuartzCore;
using Monobjc.ApplicationServices;
using System;
using System.CodeDom.Compiler;
using System.Globalization;
using System.Runtime.InteropServices;

namespace Monobjc.AppKit
{
    public partial class NSSearchFieldCell
    {
		/// <summary>
		/// <para>Identifies the menu item that is the title of the menu group for recent search strings.</para>
		/// <para>This item is hidden if there are no recent strings.</para>
		/// <para>You may use this tagged item for separator characters that also do not appear if there are no recent strings to display.</para>
        /// <para>Available in Mac OS X v10.3 and later.</para>
		/// </summary>
		public const int NSSearchFieldRecentsTitleMenuItemTag = 1000;
		
		/// <summary>
		/// <para>Identifies where recent search strings should appear in the “recents” menu group.</para>
        /// <para>Available in Mac OS X v10.3 and later.</para>
		/// </summary>
		public const int NSSearchFieldRecentsMenuItemTag = 1001;

		/// <summary>
		/// <para>Identifies the menu item for clearing the current set of recent string searches in the menu.</para>
		/// <para>This item is hidden if there are no recent strings.</para>
        /// <para>Available in Mac OS X v10.3 and later.</para>
		/// </summary>
		public const int NSSearchFieldClearRecentsMenuItemTag = 1002;

		/// <summary>
		/// <para>Identifies the menu item that describes a lack of recent search strings (for example, “No recent searches”).</para>
		/// <para>This item is hidden if there have been recent searches.</para>
        /// <para>Available in Mac OS X v10.3 and later.</para>
		/// </summary>
		public const int NSSearchFieldNoRecentsMenuItemTag = 1003;
	}
}
