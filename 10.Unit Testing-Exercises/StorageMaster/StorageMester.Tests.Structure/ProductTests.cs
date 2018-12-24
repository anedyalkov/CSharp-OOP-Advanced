using NUnit.Framework;
using StorageMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace StorageMester.Tests.Structure
{
    [TestFixture]
    public class ProductTests
    {
        private Type product;

        [SetUp]
        public void SetUp()
        {
            this.product = this.GetType("Product");
        }

        [Test]
        public void ValidateAllProducts()
        {
            var types = new[]
            {
                "Gpu",
                "HardDrive",
                "Ram",
                "SolidStateDrive",
                "Product"
            };

            foreach (var type in types)
            {
                var currentType = GetType(type);

                Assert.That(currentType, Is.Not.Null, $"{type} doesn't exists");
            }
        }

        [Test]
        public void ValidateProductConstructor()
        {
            var flags = BindingFlags.NonPublic | BindingFlags.Instance;

            var constructor = this.product.GetConstructors(flags).FirstOrDefault();

            Assert.That(constructor, Is.Not.Null, "Constructor doesn't exists");

            var constructorsParams = constructor.GetParameters();

            Assert.That(constructorsParams[0].ParameterType, Is.EqualTo(typeof(double)));
            Assert.That(constructorsParams[1].ParameterType, Is.EqualTo(typeof(double)));
        }

        [Test]
        public void ValidateProductChildClasses()
        {
            var derivedTypes = new[]
            {
                GetType("Gpu"),
                GetType("HardDrive"),
                GetType("Ram"),
                GetType("SolidStateDrive"),
            };

            foreach (var derivedType in derivedTypes)
            {
                Assert.That(derivedType.BaseType, Is.EqualTo(product), $"{derivedType} doesn't inherit {product.Name}!");
            }
        }


        [Test]
        public void ValidateProductProperties()
        {
            var actualProperties = product.GetProperties();

            var expectedProperties = new Dictionary<string, Type>
            {
                { "Price", typeof(double) },
                { "Weight", typeof(double) },
            };

            foreach (var actualProperty in actualProperties)
            {
                var isValidProperty = expectedProperties.Any(x => x.Key == actualProperty.Name && actualProperty.PropertyType == x.Value);

                Assert.That(isValidProperty, $"{actualProperty.Name} doesn't exists!");
            }
        }

        [Test]
        public void ValidateProductIsAbstract()
        {
            Assert.That(product.IsAbstract, $"Product class must be abstract!");
        }

        [Test]
        public void ValidateProductFields()
        {
            var trunkField = product.GetField("price", BindingFlags.NonPublic | BindingFlags.Instance);

            Assert.That(trunkField, Is.Not.Null, $"Invalid field");
        }

        private Type GetType(string type)
        {
            var targetType = typeof(StartUp)
                .Assembly
                .GetTypes()
                .FirstOrDefault(x => x.Name == type);

            return targetType;
        }
    }
}
