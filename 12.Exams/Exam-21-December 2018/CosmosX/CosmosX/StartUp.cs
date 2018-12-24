using CosmosX.Core;
using CosmosX.Core.Contracts;
using CosmosX.Entities.Reactors.ReactorFactory;
using CosmosX.Entities.Reactors.ReactorFactory.Contracts;
using CosmosX.IO;
using CosmosX.IO.Contracts;

namespace CosmosX
{
    public class StartUp
    {
        public static void Main()
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IReactorFactory reactorFactory = new ReactorFactory();
            IManager reactorManager = new ReactorManager(reactorFactory);

            ICommandParser commandParser = new CommandParser(reactorManager);
            IEngine engine = new Engine(reader,writer,commandParser);
            engine.Run();
        }
    }
}
