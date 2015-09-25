using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Ninject;
using Ninject.Modules;

namespace MainTests
{
    class MyInjectModule : NinjectModule
    {
        private enum TestsTarget { Examples, Solutions };
        private TestsTarget target = TestsTarget.Examples;

        public override void Load()
        {
            switch(target)
            {
                case TestsTarget.Examples:
                    Bind<Interfaces.Bits.ISensorAverage>().To<Examples.Bits.SensorAverage>().InSingletonScope();
                break;
                case TestsTarget.Solutions:
                    Bind<Interfaces.Bits.ISensorAverage>().To<Solutions.Bits.SensorAverage>().InSingletonScope();
                break;
            }
        }
    }
}
