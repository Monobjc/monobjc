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
		private readonly ICollection<Id> instance;

		public Monobjc_Foundation_CollectionDebugView (ICollection<Id> instance)
		{
			if (instance == null) 
			{
				throw new ArgumentNullException ("instance");
			}
			this.instance = instance;
		}

		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
		public Id[] Items 
		{
			get 
			{
				Id[] array = new Id[this.instance.Count];
				this.instance.CopyTo (array, 0);
				return array;
			}
		}
	}

	internal sealed class Monobjc_Foundation_DictionaryDebugView
	{
		private readonly IDictionary<Id, Id> instance;

		public Monobjc_Foundation_DictionaryDebugView (IDictionary<Id, Id> instance)
		{
			if (instance == null) 
			{
				throw new ArgumentNullException ("instance");
			}
			this.instance = instance;
		}
		
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
		public KeyValuePair<Id, Id>[] Items 
		{
			get 
			{
				KeyValuePair<Id, Id>[] array = new KeyValuePair<Id, Id>[this.instance.Count];
				this.instance.CopyTo (array, 0);
				return array;
			}
		}
	}
}
