using MyCrazyApp.Models;
using MyCrazyApp.Models.Contracts;
using SoftUniDi.Modules;

namespace MyCrazyApp.Modules
{
    public class Module : AbstractModule
    {
        public override void Configure()
        {
            this.CreateMapping<IReader, ConsoleReader>();
            this.CreateMapping<IWriter, ConsoleWriter>();
            this.CreateMapping<IWriter, FileWriter>();
        }
    }
}
