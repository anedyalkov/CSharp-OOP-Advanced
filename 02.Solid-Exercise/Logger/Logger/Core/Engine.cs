namespace Logger.Core
{
    using Logger.Appenders.Contracts;
    using Logger.Core.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine : IEngine
    {
        private ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }
        public void Run()
        {
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var inputArgs = Console.ReadLine().Split().ToArray();

                commandInterpreter.AddAppender(inputArgs);
            }

            var input = Console.ReadLine();

            while (input != "END")
            {
                var inputArgs = input.Split('|').ToArray();
                commandInterpreter.AddMessage(inputArgs);

                input = Console.ReadLine();
            }

            commandInterpreter.PrintInfo();
        }
    }
}
