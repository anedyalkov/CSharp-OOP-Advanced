namespace FestivalManager
{
	using System.IO;
	using System.Linq;
	using Core;
	using Core.Contracts;
	using Core.Controllers;
	using Core.Controllers.Contracts;
	using Core.IO;
	using Core.IO.Contracts;
	using Entities;
	using Entities.Contracts;
    using FestivalManager.Entities.Factories;
    using FestivalManager.Entities.Factories.Contracts;

    public static class StartUp
	{
		public static void Main(string[] args)
		{
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
			IStage stage = new Stage();
            ISetFactory setFactory = new SetFactory();
            IPerformerFactory performerFactory = new PerformerFactory();
            IInstrumentFactory instrumentFactory = new InstrumentFactory();
            ISongFactory songFactory = new SongFactory();
			IFestivalController festivalController = new FestivalController(stage, setFactory, performerFactory, instrumentFactory, songFactory);
			ISetController setController = new SetController(stage);

			var engine = new Engine(festivalController, setController, reader, writer);

			engine.Run();
		}
	}
}