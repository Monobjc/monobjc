//
// This file is part of Monobjc, a .NET/Objective-C bridge
// Copyright (C) 2007-2012 - Laurent Etiemble
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
using NUnit.Framework;

namespace Monobjc.Foundation
{
    [TestFixture]
    [Category("Debugger")]
    [Description("Test the debugger proxies")]
    public class DebuggerTests : WrapperTests
    {
        [Test]
        public void TestNSArrayDebuggerProxy() 
        {
            NSArray array = NSArray.Array;
            Monobjc_Foundation_CollectionDebugView view = new Monobjc_Foundation_CollectionDebugView(array);
            Assert.IsNotNull(view.Items, "Items cannot be null");
            Assert.AreEqual(0, view.Items.Length, "Length must be 0");
            
            array = NSArray.ArrayWithObject(NSString.String);
            view = new Monobjc_Foundation_CollectionDebugView(array);
            Assert.IsNotNull(view.Items, "Items cannot be null");
            Assert.AreEqual(1, view.Items.Length, "Length must be 1");
            
            array = NSArray.ArrayWithObjects(NSNumber.NumberWithInt(123), NSNumber.NumberWithInt(456), NSNumber.NumberWithInt(789), null);
            view = new Monobjc_Foundation_CollectionDebugView(array);
            Assert.IsNotNull(view.Items, "Items cannot be null");
            Assert.AreEqual(3, view.Items.Length, "Length must be 3");
        }
        
        [Test]
        public void TestNSSetDebuggerProxy()
        {
            NSSet st = NSSet.Set;
            Monobjc_Foundation_CollectionDebugView view = new Monobjc_Foundation_CollectionDebugView(st);
            Assert.IsNotNull(view.Items, "Items cannot be null");
            Assert.AreEqual(0, view.Items.Length, "Length must be 0");
            
            st = NSSet.SetWithObject(NSString.String);
            view = new Monobjc_Foundation_CollectionDebugView(st);
            Assert.IsNotNull(view.Items, "Items cannot be null");
            Assert.AreEqual(1, view.Items.Length, "Length must be 1");
            
            st = NSSet.SetWithObjects(NSNumber.NumberWithInt(123), NSNumber.NumberWithInt(456), NSNumber.NumberWithInt(789), null);
            view = new Monobjc_Foundation_CollectionDebugView(st);
            Assert.IsNotNull(view.Items, "Items cannot be null");
            Assert.AreEqual(3, view.Items.Length, "Length must be 3");
        }

        [Test]
        public void TestNSDictionaryDebuggerProxy()
        {
            NSDictionary dictionary = NSDictionary.Dictionary;
            Monobjc_Foundation_DictionaryDebugView view = new Monobjc_Foundation_DictionaryDebugView(dictionary);
            Assert.IsNotNull(view.Items, "Items cannot be null");
            Assert.AreEqual(0, view.Items.Length, "Length must be 0");
            
            dictionary = NSDictionary.DictionaryWithObjectForKey(NSString.String, (NSString) "key");
            view = new Monobjc_Foundation_DictionaryDebugView(dictionary);
            Assert.IsNotNull(view.Items, "Items cannot be null");
            Assert.AreEqual(1, view.Items.Length, "Length must be 1");
            
            dictionary = NSDictionary.DictionaryWithObjectsAndKeys(NSNumber.NumberWithInt(123), (NSString) "key1",
                                                                   NSNumber.NumberWithInt(456), (NSString) "key2",
                                                                   NSNumber.NumberWithInt(789), (NSString) "key3",
                                                                   null);
            view = new Monobjc_Foundation_DictionaryDebugView(dictionary);
            Assert.IsNotNull(view.Items, "Items cannot be null");
            Assert.AreEqual(3, view.Items.Length, "Length must be 3");
        }
    }
}
