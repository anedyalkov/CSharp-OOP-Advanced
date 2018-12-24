using NUnit.Framework;
using StorageMaster;
using StorageMaster.Entities.Products;
using StorageMaster.Entities.Storage;
using StorageMaster.Entities.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace StorageMester.Tests.Structure
{
    [TestFixture]
    public class StorageTests
    {
        private Type storage;

        [SetUp]
        public void SetUp()
        {
            this.storage = this.GetType("Storage");
        }

        [Test]
        public void ValidateAllStorages()
        {
            var types = new[]
            {
                "AutomatedWarehouse",
                "DistributionCenter",
                "Warehouse",
                "Storage"
            };

            foreach (var type in types)
            {
                var currentType = GetType(type);

                Assert.That(currentType, Is.Not.Null, $"{type} doesn't exists");
            }
        }

        [Test]
        public void ValidateStorageConstructor()
        {
            var flags = BindingFlags.NonPublic | BindingFlags.Instance;

            var constructor = this.storage.GetConstructors(flags).FirstOrDefault();

            Assert.That(constructor, Is.Not.Null, "Constructor doesn't exists");

            var constructorsParams = constructor.GetParameters();

            Assert.That(constructorsParams[0].ParameterType, Is.EqualTo(typeof(string)));
            Assert.That(constructorsParams[1].ParameterType, Is.EqualTo(typeof(int)));
            Assert.That(constructorsParams[2].ParameterType, Is.EqualTo(typeof(int)));
            Assert.That(constructorsParams[3].ParameterType, Is.EqualTo(typeof(IEnumerable<Vehicle>)));
        }

        [Test]
        public void ValidateStorageChildClasses()
        {
            var derivedTypes = new[]
            {
                GetType("AutomatedWarehouse"),
                GetType("DistributionCenter"),
                GetType("Warehouse"),
            };

            foreach (var derivedType in derivedTypes)
            {
                Assert.That(derivedType.BaseType, Is.EqualTo(storage), $"{derivedType} doesn't inherit {storage.Name}!");
            }
        }

        [Test]
        public void ValidateStorageProperties()
        {
            var actualProperties = storage.GetProperties();

            var expectedProperties = new Dictionary<string, Type>
            {
                { "Name", typeof(string) },
                { "Capacity", typeof(int) },
                { "GarageSlots", typeof(int) },
                { "IsFull", typeof(bool) },
                { "Garage", typeof(IReadOnlyCollection<Vehicle>)},
                { "Products", typeof(IReadOnlyCollection<Product>)},

            };

            foreach (var actualProperty in actualProperties)
            {
                var isValidProperty = expectedProperties.Any(x => x.Key == actualProperty.Name && actualProperty.PropertyType == x.Value);

                Assert.That(isValidProperty, $"{actualProperty.Name} doesn't exists!");
            }
        }
        [Test]
        public void ValidateStorageMethods()
        {
            var expectedMethods = new List<Method>
            {
                new Method(typeof(Vehicle), "GetVehicle", typeof(int)),
                new Method(typeof(int), "SendVehicleTo",typeof(int), typeof(Storage)),
                new Method(typeof(int), "UnloadVehicle",typeof(int)),
            };

            foreach (var expectedMethod in expectedMethods)
            {
                var currentMethod = storage.GetMethod(expectedMethod.Name);

                Assert.That(currentMethod, Is.Not.Null, $"{expectedMethod.Name} method doesn't exists");

                var currentMethodReturnType = currentMethod.ReturnType == expectedMethod.ReturnType;

                Assert.That(currentMethodReturnType, $"{expectedMethod.Name} invalid return type");

                var expectedMethodParms = expectedMethod.InputParamateres;
                var actualParms = currentMethod.GetParameters();

                for (int i = 0; i < expectedMethodParms.Length; i++)
                {
                    var actualParam = actualParms[i].ParameterType;
                    var expectedParam = expectedMethodParms[i];

                    Assert.AreEqual(expectedParam, actualParam);
                }
            }
        }

        [Test]
        public void ValidateStorageIsAbstract()
        {
            Assert.That(storage.IsAbstract, $"Vehicle class must be abstract!");
        }

        [Test]
        public void ValidateStorageFields()
        {
            var garageField = storage.GetField("garage", BindingFlags.NonPublic | BindingFlags.Instance);
            var productsField = storage.GetField("products", BindingFlags.NonPublic | BindingFlags.Instance);


            Assert.That(garageField, Is.Not.Null, $"Invalid field");
            Assert.That(productsField, Is.Not.Null, $"Invalid field");

        }
        private class Method
        {
            public Method(Type returnType, string name, params Type[] inputParams)
            {
                this.ReturnType = returnType;
                this.Name = name;
                this.InputParamateres = inputParams;
            }

            public Type ReturnType { get; set; }

            public string Name { get; set; }

            public Type[] InputParamateres { get; set; }
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
