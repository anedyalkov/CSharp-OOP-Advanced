namespace _03.Stack
{ 
    using _03.Stack.Contracts;
    using System;
    using System.Linq;

    public class Engine :IEngine
    {
        private bool isRunning;
        ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
            isRunning = true;
        }
        public void Run()
        {
            var input = Console.ReadLine();
            var inputArgs = input.Split(" ").ToArray();

            while (input != "END")
            {

                try
                {
                    commandInterpreter.ParseCommand(inputArgs);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
