namespace FestivalManager.Entities.Factories
{
	using Contracts;
	using Entities.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class PerformerFactory : IPerformerFactory
	{
		public IPerformer CreatePerformer(string name, int age)
		{
            var performerType = Assembly.GetCallingAssembly().GetType("FestivalManager.Entities.Performer");
            var instance = (IPerformer)Activator.CreateInstance(performerType, new object[] { name, age});
            return instance;
        }
	}
}