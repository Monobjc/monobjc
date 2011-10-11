using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Monobjc.ScriptingBridge
{
	[DebuggerDisplay("Count = {Count}"), DebuggerTypeProxy(typeof(Monobjc_ScriptingBridge_CollectionDebugView))]
	partial class SBElementArray
	{
	}

	internal sealed class Monobjc_ScriptingBridge_CollectionDebugView
	{
		private readonly ICollection<Id> instance;

		public Monobjc_ScriptingBridge_CollectionDebugView (ICollection<Id> instance)
		{
			if (instance == null) 
			{
				throw new ArgumentNullException ("instance");
			}
			this.instance = instance;
		}

		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
		public SBObject[] Items 
		{
			get 
			{
				SBObject[] array = new SBObject[this.instance.Count];
				this.instance.CopyTo (array, 0);
				return array;
			}
		}
	}
}
