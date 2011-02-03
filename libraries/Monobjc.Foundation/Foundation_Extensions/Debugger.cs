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
using System.Collections.Generic;
using System.Diagnostics;

namespace Monobjc.Foundation
{
	[DebuggerDisplay("Count = {Count}"), DebuggerTypeProxy(typeof(Monobjc_Foundation_CollectionDebugView))]
	partial class NSArray
	{
	}

	[DebuggerDisplay("Count = {Count}"), DebuggerTypeProxy(typeof(Monobjc_Foundation_DictionaryDebugView))]
	partial class NSDictionary
	{
	}

    [DebuggerDisplay("Count = {Count}"), DebuggerTypeProxy(typeof(Monobjc_Foundation_DictionaryDebugView))]
    partial class NSCountedSet
    {
    }

    [DebuggerDisplay("Count = {Count}"), DebuggerTypeProxy(typeof(Monobjc_Foundation_CollectionDebugView))]
    partial class NSIndexSet
    {
    }

	[DebuggerDisplay("Count = {Count}"), DebuggerTypeProxy(typeof(Monobjc_Foundation_CollectionDebugView))]
	partial class NSMutableArray
	{
	}

    [DebuggerDisplay("Count = {Count}"), DebuggerTypeProxy(typeof(Monobjc_Foundation_DictionaryDebugView))]
    partial class NSMutableDictionary
    {
    }

    [DebuggerDisplay("Count = {Count}"), DebuggerTypeProxy(typeof(Monobjc_Foundation_CollectionDebugView))]
    partial class NSMutableIndexSet
    {
    }

    [DebuggerDisplay("Count = {Count}"), DebuggerTypeProxy(typeof(Monobjc_Foundation_CollectionDebugView))]
	partial class NSMutableSet
	{
	}

	[DebuggerDisplay("Count = {Count}"), DebuggerTypeProxy(typeof(Monobjc_Foundation_CollectionDebugView))]
	partial class NSSet
	{
	}

	internal sealed class Monobjc_Foundation_CollectionDebugView
	{
		private readonly ICollection<Id> collection;

		public Monobjc_Foundation_CollectionDebugView (ICollection<Id> collection)
		{
			if (collection == null) 
			{
				throw new ArgumentNullException ("collection");
			}
			this.collection = collection;
		}

		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
		public Id[] Items 
		{
			get 
			{
				Id[] array = new Id[this.collection.Count];
				this.collection.CopyTo (array, 0);
				return array;
			}
		}
	}

	internal sealed class Monobjc_Foundation_DictionaryDebugView
	{
		private readonly IDictionary<Id, Id> dictionary;

		public Monobjc_Foundation_DictionaryDebugView (IDictionary<Id, Id> dictionary)
		{
			if (dictionary == null) 
			{
				throw new ArgumentNullException ("dictionary");
			}
			this.dictionary = dictionary;
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
		public KeyValuePair<Id, Id>[] Items 
		{
			get 
			{
				KeyValuePair<Id, Id>[] array = new KeyValuePair<Id, Id>[this.dictionary.Count];
				this.dictionary.CopyTo (array, 0);
				return array;
			}
		}
	}
}
