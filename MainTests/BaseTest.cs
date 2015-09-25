using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace MainTests
{
    class BaseTest<I>
    {
        private I impl = MyTestModule.GetImpl<I>();

        protected void AssertNotNull<T>(T impl)
        {
            Assert.NotNull(impl, typeof(T).FullName + " implementation does not exist. Test skipped.");
        }

        protected I GetImpl()
        {
            AssertNotNull(impl);
            return impl;
        }
    }
}
