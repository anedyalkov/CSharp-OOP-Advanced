namespace TheTankGame.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        private readonly IManager tankManager;

        public CommandInterpreter(IManager tankManager)
        {
            this.tankManager = tankManager;
        }

        public string ProcessInput(IList<string> inputParameters)
        {
            string command = inputParameters[0];
            var commandArgs = inputParameters.Skip(1).ToList();
            string commandResult = string.Empty;


            //Type commandType = Type.GetType(commandName + Constants.CommandSuffix);
            var commandToInvoke = this.tankManager.GetType()
                .GetMethods()
                .FirstOrDefault(x => x.Name.Contains(command));

            commandResult = (string)commandToInvoke.Invoke(this.tankManager, new object[] { commandArgs });

            //switch (command)
            //{
            //    case "Vehicle":
            //        result = this.tankManager.AddVehicle(inputParameters);
            //        break;
            //    case "Part":
            //        result = this.tankManager.AddVehicle(inputParameters);
            //        break;
            //    case "Inspect":
            //        result = this.tankManager.Inspect(inputParameters);
            //        break;
            //    case "Battle":
            //        result = this.tankManager.Battle(inputParameters);
            //        break;
            //    case "Terminate":
            //        result = this.tankManager.Terminate(inputParameters);
            //        break;
            //}

            return commandResult;
        }
    }
}