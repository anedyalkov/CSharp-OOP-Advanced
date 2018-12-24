using CosmosX.Core.Contracts;
using CosmosX.IO.Contracts;
using System;
using System.Linq;

namespace CosmosX.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private ICommandParser commandParser;
        private bool isRunning;

        public Engine(IReader reader, IWriter writer, ICommandParser commandParser)
        {
            this.reader = reader;
            this.writer = writer;
            this.commandParser = commandParser;
            this.isRunning = false;
        }

        public void Run()
        {
            //It's not really necessary to implement this method


            this.isRunning = true;
            while (isRunning)
            {
                try
                {
                    var inputLine = this.reader.ReadLine().Trim();
                    var commandArgs = inputLine
                        .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .ToList();

                    var result = this.commandParser.Parse(commandArgs).Trim();

                    this.writer.WriteLine(result);

                    if (inputLine == "Exit")
                    {
                        this.isRunning = false;
                        //break;
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