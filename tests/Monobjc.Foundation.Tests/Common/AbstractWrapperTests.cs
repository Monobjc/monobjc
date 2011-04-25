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
using NUnit.Framework;

namespace Monobjc.Foundation.Common
{
    [TestFixture]
    [Category("Wrapper")]
    [Description("Test the wrappers")]
    public abstract class AbstractWrapperTests : AbstractObjectiveCTests
    {
        private NSAutoreleasePool pool;

        [SetUp]
        public void SetUp()
        {
            this.pool = new NSAutoreleasePool();
        }

        [TearDown]
        public void TearDown()
        {
            this.pool.Release();
        }
    }
}