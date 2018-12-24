namespace Problem02.Core.Commands
{
    using System;
    using Contracts;

    public class ByeCommand : ICommand
    {
        public string Execute()
        {
            Console.WriteLine("Bye");
            Environment.Exit(0);
            return null;
        }
    }
}
