using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using Ninject.Modules;
using Ninject;

namespace MainTests
{
    [SetUpFixture]
    class MyTestModule
    {
        private static IKernel kernel = new StandardKernel(new MyInjectModule());

        public static IEnumerable<T> GetAllImpl<T>()
        {
            IList<T> implementations = new List<T>();

            // this foreach needed to let ninject retrieve the bindings
            foreach (var impl in kernel.GetAll<T>())
            {
                implementations.Add(impl);
            }
            return implementations;
        }

        public static T GetImpl<T>()
        {
            return kernel.Get<T>();
        }

        [SetUp]
        public void SetUpTestEnvironment()
        {
        }
        [TearDown]
        public void CleanTestEnvironment()
        {
        }
    }
}
