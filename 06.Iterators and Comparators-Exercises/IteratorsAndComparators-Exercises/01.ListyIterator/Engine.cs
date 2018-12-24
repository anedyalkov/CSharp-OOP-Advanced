namespace _01.ListyIterator
{
    using _01.ListyIterator.Contracts;
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
            while (isRunning)
            {
                var input = Console.ReadLine();
                if (input == "END")
                {
                    isRunning = false;
                    break;
                }

                try
                {
                    commandInterpreter.ParseCommand(input);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
