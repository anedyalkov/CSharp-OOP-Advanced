namespace Travel.Entities.Factories
{
	using Contracts;
	using Items;
	using Items.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class ItemFactory : IItemFactory
	{
		public IItem CreateItem(string type)
		{
            var itemType = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(t => t.Name == type);
            var itemInstance = (IItem)Activator.CreateInstance(itemType);
            return itemInstance;
        }
	}
}
