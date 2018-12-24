namespace Travel.Entities.Factories
{
	using Contracts;
	using Airplanes.Contracts;
    using System.Reflection;
    using System.Linq;
    using System;

    public class AirplaneFactory : IAirplaneFactory
	{
		public IAirplane CreateAirplane(string type)
		{
            var airplaneType = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(t => t.Name == type);
            var airplaneInstance = (IAirplane)Activator.CreateInstance(airplaneType);
            return airplaneInstance;
		}
	}
}