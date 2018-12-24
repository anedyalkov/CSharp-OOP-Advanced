using System;
using Problem02.Core.Commands;

namespace Problem02.Core
{
    using System.Linq;
    using System.Reflection;
    using Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string[] inputArgs)
        {
            string commandName = inputArgs[0];

            var type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(x => x.Name == commandName);

            var instance = Activator.CreateInstance(type);
            var result = ((ICommand)instance).Execute();

            return result;
        }
    }
}
