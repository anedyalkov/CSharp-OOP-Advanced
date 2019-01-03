namespace TheTankGame.Core
{
    using System;
    using System.Linq;
    using Contracts;
    using IO.Contracts;

    public class Engine : IEngine
    {
        private bool isRunning;
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(
            IReader reader, 
            IWriter writer, 
            ICommandInterpreter commandInterpreter)
        {
            this.reader = reader;
            this.writer = writer;
            this.commandInterpreter = commandInterpreter;

            this.isRunning = false;
        }

        public void Run()
        {
            this.isRunning = true;
            while (isRunning)
            {
                try
                {
                    var inputLine = this.reader.ReadLine().Trim();
                    var commandArgs = inputLine
                        .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .ToList();

                    var result = this.commandInterpreter.ProcessInput(commandArgs).Trim();

                    this.writer.WriteLine(result);

                    if (inputLine == "Terminate")
                    {
                        this.isRunning = false;
                    }
                }
                catch (Exception e)
                {
                    this.writer.WriteLine(e.Message);
                }
            }
        }
    }
}