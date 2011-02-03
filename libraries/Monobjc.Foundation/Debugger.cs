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
	partial class NSMutableArray
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

	[DebuggerDisplay("Count = {Count}"), DebuggerTypeProxy(typeof(Monobjc_Foundation_DictionaryDebugView))]
	partial class NSMutableDictionary
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
