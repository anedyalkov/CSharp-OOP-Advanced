namespace _01.ListyIterator
{
    using _01.ListyIterator.Contracts;
    using System;
    using System.Linq;

    public class CommandInterpreter : ICommandInterpreter
    {
        private ListIterator<string> listIterator;

        public void ParseCommand(string input)
        {
            var inputArgs = input.Split(" ").ToArray();
            var command = inputArgs[0];
            var commandArgs = inputArgs.Skip(1).ToArray();
            switch (command)
            {
                case "Create":
                    this.listIterator = new ListIterator<string>(commandArgs);
                    break;
                case "Move":
                    Console.WriteLine(this.listIterator.Move());
                    break;
                case "HasNext":
                    Console.WriteLine(this.listIterator.HasNext());
                    break;
                case "Print":
                    Console.WriteLine(this.listIterator.Print());
                    break;
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}
