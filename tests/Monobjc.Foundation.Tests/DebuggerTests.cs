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
