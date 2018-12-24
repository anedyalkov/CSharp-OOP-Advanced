using System.Collections.Generic;

namespace CosmosX.Core.Contracts
{
    public interface ICommandParser
    {
        string Parse(IList<string> arguments);
    }
}