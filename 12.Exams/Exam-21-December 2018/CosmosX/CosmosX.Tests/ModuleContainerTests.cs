namespace CosmosX.Tests
{
    using CosmosX.Entities.Containers;
    using CosmosX.Entities.Modules.Absorbing;
    using CosmosX.Entities.Modules.Energy;
    using CosmosX.Entities.Reactors;
    using NUnit.Framework;

    [TestFixture]
    public class ModuleContainerTests
    {
        [Test]
        public void TestToCreateEnergyModule()
        {
      
            var moduleContainer = new ModuleContainer(10);

            var module = new CryogenRod(1, 100);
            moduleContainer.AddEnergyModule(module);

            System.Console.WriteLine(moduleContainer.TotalEnergyOutput);
            Assert.That(moduleContainer.TotalEnergyOutput, Is.EqualTo(100));

        }

        [Test]
        public void TestToCreateAbsorbingModule()
        {
            
            var moduleContainer = new ModuleContainer(4);

            var module = new HeatProcessor(1, 200);
            moduleContainer.AddAbsorbingModule(module);

            System.Console.WriteLine(moduleContainer.TotalHeatAbsorbing);
            Assert.That(moduleContainer.TotalHeatAbsorbing, Is.EqualTo(200));

        }

        [Test]
        public void TestToRemoveOldestModule()
        {

            var moduleContainer = new ModuleContainer(1);

            var module1 = new HeatProcessor(1, 200);
            var module2 = new HeatProcessor(2, 300);
            moduleContainer.AddAbsorbingModule(module1);
            moduleContainer.AddAbsorbingModule(module2);

            System.Console.WriteLine(moduleContainer.TotalHeatAbsorbing);
            Assert.That(moduleContainer.ModulesByInput.Count, Is.EqualTo(1));

        }
    }
}