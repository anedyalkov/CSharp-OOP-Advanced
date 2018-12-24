using System;
using System.Collections.Generic;
using System.Text;
using SoftUniDi.Injectors;
using SoftUniDi.Modules.Contracts;

namespace SoftUniDi
{
    public class DependencyInjector
    {
        public static Injector CreateInjector(IModule module)
        {
            module.Configure();
            return new Injector(module);
        }
    }
}
