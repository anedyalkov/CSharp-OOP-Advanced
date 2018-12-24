using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CosmosX.Core.Contracts;

namespace CosmosX.Core
{
    public class CommandParser : ICommandParser
    {
        private const string CommandNameSuffix = "Command";

        private readonly IManager reactorManager;

        public CommandParser(IManager reactorManager)
        {
            this.reactorManager = reactorManager;
        }

        public string Parse(IList<string> arguments)
        {
            string command = arguments[0] + CommandNameSuffix;

            string[] commandArguments = arguments.Skip(1).ToArray();

            string result = string.Empty;

            var commandToInvoke = reactorManager.GetType().GetMethods().FirstOrDefault(x => x.Name == command);
            result = (string)commandToInvoke.Invoke(this.reactorManager, new object[] { commandArguments});

            //switch (command)
            //{
            //    case "Reactor":
            //        result = this.reactorManager.ReactorCommand(commandArguments);
            //        break;
            //    case "Module":
            //        result = this.reactorManager.ReactorCommand(commandArguments);
            //        break;
            //    case "Report":
            //        result = this.reactorManager.ReactorCommand(commandArguments);
            //        break;
            //    case "Exit":
            //        result = this.reactorManager.ExitCommand(commandArguments);
            //        break;
            //}

            return result;
        }
    }
}