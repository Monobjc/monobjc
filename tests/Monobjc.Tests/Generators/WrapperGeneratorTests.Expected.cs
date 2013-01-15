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
using System;

namespace Monobjc.Generators
{
    public interface IManagedWrapper12 : IServiceProvider {}

    public interface IManagedWrapper13 : IManagedWrapper {}

    [ObjectiveCProtocol]
    public interface IManagedWrapper14 : IManagedWrapper
    {
        void DoSomething();
    }

    [ObjectiveCProtocol]
    public interface IManagedWrapper15 : IManagedWrapper
    {
        [ObjectiveCMessage]
        void DoSomething();
    }
}

namespace Monobjc.Dynamic.Wrappers
{
    [ObjectiveCProtocol("ManagedWrapper21")]
    public interface IManagedWrapper21 : IManagedWrapper {}

    public class ManagedWrapper21Impl : Id, IManagedWrapper21
    {
        public ManagedWrapper21Impl() {}

        public ManagedWrapper21Impl(IntPtr value) : base(value) {}
    }

    [ObjectiveCProtocol("ManagedWrapper22")]
    public interface IManagedWrapper22 : IManagedWrapper
    {
        [ObjectiveCMessage("doSomething")]
        void DoSomething();
    }

    public class ManagedWrapper22Impl : Id, IManagedWrapper22
    {
        public ManagedWrapper22Impl() {}

        public ManagedWrapper22Impl(IntPtr value) : base(value) {}

        public void DoSomething()
        {
            ObjectiveCRuntime.SendMessage(this, "doSomething");
        }
    }

    [ObjectiveCProtocol("ManagedWrapper23")]
    public interface IManagedWrapper23 : IManagedWrapper
    {
        String MyProperty { [ObjectiveCMessage("myProperty")]
        get; [ObjectiveCMessage("setMyProperty")]
        set; }
    }

    public class ManagedWrapper23Impl : Id, IManagedWrapper23
    {
        public ManagedWrapper23Impl() {}

        public ManagedWrapper23Impl(IntPtr value) : base(value) {}

        public String MyProperty
        {
            get { return ObjectiveCRuntime.SendMessage<String>(this, "myProperty"); }
            set { ObjectiveCRuntime.SendMessage(this, "setMyProperty", value); }
        }
    }

    [ObjectiveCProtocol("ManagedWrapper24")]
    public interface IManagedWrapper24 : IManagedWrapper
    {
        [ObjectiveCMessage("doSomething")]
        void DoSomething();

        String MyProperty { [ObjectiveCMessage("myProperty")]
        get; [ObjectiveCMessage("setMyProperty")]
        set; }
    }

    public class ManagedWrapper24Impl : Id, IManagedWrapper24
    {
        public ManagedWrapper24Impl() {}

        public ManagedWrapper24Impl(IntPtr value) : base(value) {}

        public void DoSomething()
        {
            ObjectiveCRuntime.SendMessage(this, "doSomething");
        }

        public string MyProperty
        {
            get { return ObjectiveCRuntime.SendMessage<String>(this, "myProperty"); }
            set { ObjectiveCRuntime.SendMessage(this, "setMyProperty", value); }
        }
    }

    [ObjectiveCProtocol("ManagedWrapper25")]
    public interface IManagedWrapper25 : IManagedWrapper {}

    public class ManagedWrapper25Impl : Id, IManagedWrapper25
    {
        public ManagedWrapper25Impl() {}

        public ManagedWrapper25Impl(IntPtr value) : base(value) {}
    }

    [ObjectiveCProtocol("ManagedWrapper26")]
    public interface IManagedWrapper26 : IManagedWrapper {}

    public class ManagedWrapper26Impl : Id, IManagedWrapper26
    {
        public ManagedWrapper26Impl() {}

        public ManagedWrapper26Impl(IntPtr value) : base(value) {}
    }
}