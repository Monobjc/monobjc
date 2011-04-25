//
// This file is part of Monobjc, a .NET/Objective-C bridge
// Copyright (C) 2007-2011 - Laurent Etiemble
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
        public ManagedWrapper21Impl(){}

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
        public ManagedWrapper22Impl() { }

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
        public ManagedWrapper23Impl() { }

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
        public ManagedWrapper24Impl() { }

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
    public interface IManagedWrapper25 : IManagedWrapper
    {
    }

    public class ManagedWrapper25Impl : Id, IManagedWrapper25
    {
        public ManagedWrapper25Impl() { }

        public ManagedWrapper25Impl(IntPtr value) : base(value) {}
    }

    [ObjectiveCProtocol("ManagedWrapper26")]
    public interface IManagedWrapper26 : IManagedWrapper
    {
    }

    public class ManagedWrapper26Impl : Id, IManagedWrapper26
    {
        public ManagedWrapper26Impl() { }

        public ManagedWrapper26Impl(IntPtr value) : base(value) {}
    }
}