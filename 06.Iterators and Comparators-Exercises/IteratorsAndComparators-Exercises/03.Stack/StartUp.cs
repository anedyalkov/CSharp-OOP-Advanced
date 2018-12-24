namespace _03.Stack
{
    using _03.Stack.Contracts;

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
