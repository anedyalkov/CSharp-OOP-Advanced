namespace Travel
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
	using Entities.Airplanes;
	using Entities.Contracts;
    using Travel.Entities.Factories;
    using Travel.Entities.Factories.Contracts;

    public static class StartUp
	{
		public static void Main(string[] args)
		{
            IReader reader = new ConsoleReader();
			IWriter writer = new ConsoleWriter();
            IAirplaneFactory airplaneFactory = new AirplaneFactory();
            IItemFactory itemFactory = new ItemFactory();
            IAirport airport = new Airport();
            var airportController = new AirportController(airport, airplaneFactory, itemFactory);
			var flightController = new FlightController(airport);

			var engine = new Engine(reader, writer, airportController, flightController);

			engine.Run();
		}
	}
}