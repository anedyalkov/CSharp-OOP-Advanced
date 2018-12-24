namespace Logger
{
    using Logger.Core;
    using Logger.Core.Contracts;

    public class StartUp
    {
        public static void Main()
        {
            ICommandInterpreter commandInterpreter = new CommandInterpreter();
            IEngine engine = new Engine(commandInterpreter);
            engine.Run();
        }
    }
}
