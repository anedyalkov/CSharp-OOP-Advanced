namespace TheTankGame.Tests
{
    using NUnit.Framework;
    using TheTankGame.Entities.Miscellaneous;
    using TheTankGame.Entities.Miscellaneous.Contracts;
    using TheTankGame.Entities.Parts;
    using TheTankGame.Entities.Vehicles;
    using TheTankGame.Entities.Vehicles.Contracts;

    [TestFixture]
    public class BaseVehicleTests
    {
        [Test]
        public void TestBaseVehicleClassReturnsCorrectOutput()
        {
            //Vehicle Vanguard SA-203 100 300 1000 450 2000
            var assembler = new VehicleAssembler();
            var vehicle = new Vanguard("SA-203", 100, 300, 1000, 450, 2000, assembler);
            var part = new ShellPart("SA-203", 300, 100, 2);
            vehicle.AddShellPart(part);

            var actualResult = vehicle.ToString();
  
            var expectedResult = "Vanguard - SA-203\r\nTotal Weight: 400.000\r\nTotal Price: 400.000\r\nAttack: 1000\r\nDefense: 452\r\nHitPoints: 2000\r\nParts: SA-203";
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }
        
       
    }
}