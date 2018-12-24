namespace _03BarracksFactory.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            //TODO: implement for Problem 3
            var assembly = Assembly.GetExecutingAssembly();

            var typeOfUnit = assembly.GetTypes().FirstOrDefault(t => t.Name == unitType);

            if (typeOfUnit == null)
            {
                throw new ArgumentException("Unit does not exist");
            }

            if (!typeof(IUnit).IsAssignableFrom(typeOfUnit))
            {
                throw new ArgumentException($"{unitType} is not IUnit type!");
            }
            //var unit = (IUnit)Activator.CreateInstance(typeOfUnit);
            var constructor = typeOfUnit.GetConstructor(new Type[0]);
            var unit = (IUnit)constructor.Invoke(new object[0]);
            return unit;
        }
    }
}
