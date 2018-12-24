using NUnit.Framework;
using System;

namespace MyTests
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void TestProviderIsBroken()
        {
            var provider = new SolarProvider(1, 200);
            provider.Broke();

            Assert.That(provider.Durability, Is.EqualTo(1400));
        }
    }
}
