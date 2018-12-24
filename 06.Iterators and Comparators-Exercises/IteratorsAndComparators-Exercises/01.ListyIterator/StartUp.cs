namespace _01.ListyIterator
{
    using _01.ListyIterator.Contracts;
    using System;

    public class StartUp
    {
        public static void Main()
        {
            ICommandInterpreter commandInterpreter = new CommandInterpreter();
            var engine = new Engine(commandInterpreter);
            engine.Run();
        }
    }
}
