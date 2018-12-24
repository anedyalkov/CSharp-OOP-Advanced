using System.Collections.Generic;

namespace CosmosX.Core.Contracts
{
    public interface IManager
    {
        string ReactorCommand(IList<string> arguments);

        string ModuleCommand(IList<string> arguments);

        string ReportCommand(IList<string> arguments);

        string ExitCommand(IList<string> arguments);
    }
}