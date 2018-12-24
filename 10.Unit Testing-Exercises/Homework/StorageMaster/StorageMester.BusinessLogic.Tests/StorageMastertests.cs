using NUnit.Framework;
using StorageMaster;
using StorageMaster.Entities.Products;
using StorageMaster.Entities.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace StorageMester.BusinessLogic.Tests
{
    [TestFixture]
    public class StorageMastertests
    {
        private Type storageMaster;

        [SetUp]
        public void SetUp()
        {
            this.storageMaster = this.GetType("StorageMaster");
        }

        [Test]
        public void ValidateAddProductMethod()
        {
            var addProductMethod = storageMaster.GetMethod("AddProduct");

            var instance = Activator.CreateInstance(storageMaster);

            string productType = "SolidStateDrive";
            double price = 230.43;

            var actualResult = addProductMethod.Invoke(instance, new object[] { productType, price });
            var expectedResult = $"Added SolidStateDrive to pool";

            Assert.AreEqual(expectedResult, actualResult);

            var productsPoolField = (IDictionary<string, Stack<Product>>)storageMaster.GetField("productsPool", (BindingFlags)62).GetValue(instance);

            Assert.That(productsPoolField[productType].Count, Is.EqualTo(1));
        }

        [Test]
        public void ValidateRegisterStorageMethod()
        {
            var registerStorageMethod = storageMaster.GetMethod("RegisterStorage");
            var instance = Activator.CreateInstance(storageMaster);

            string storageType = "DistributionCenter";
            string name = "Gosho";

            var actualResult = registerStorageMethod.Invoke(instance, new object[] { storageType, name });

            var expectedResult = $"Registered Gosho";

            Assert.AreEqual(expectedResult, actualResult);

            var storageRegistryField = (IDictionary<string, Storage>)storageMaster.GetField("storageRegistry", (BindingFlags)62).GetValue(instance);

            Assert.That(storageRegistryField[name].Name, Is.EqualTo(name));
        }

        [Test]
        public void ValidateSelectVehicleMethod()
        {
            var registerStorageMethod = storageMaster.GetMethod("RegisterStorage");
            var selectVehicleMethod = storageMaster.GetMethod("SelectVehicle");
            var instance = Activator.CreateInstance(storageMaster);

            registerStorageMethod.Invoke(instance, new object[] { "DistributionCenter", "Gosho" });

            string storageName = "Gosho";
            int garageSlot = 0;

            var actualResult = selectVehicleMethod.Invoke(instance, new object[] { storageName, garageSlot });

            var expectedResult = $"Selected Van";

            Assert.AreEqual(expectedResult, actualResult);

            var storageRegistryField = (IDictionary<string, Storage>)storageMaster.GetField("storageRegistry", (BindingFlags)62).GetValue(instance);

            Assert.That(storageRegistryField[storageName].Name, Is.EqualTo(storageName));
        }

        [Test]
        public void ValidateLoadVehicleMethod()
        {
            var registerStorageMethod = storageMaster.GetMethod("RegisterStorage");
            var selectVehicleMethod = storageMaster.GetMethod("SelectVehicle");
            var loadVehicleMethod = storageMaster.GetMethod("LoadVehicle");
            var instance = Activator.CreateInstance(storageMaster);

            var addProductMethod = storageMaster.GetMethod("AddProduct");
            string productType = "HardDrive";
            double price = 230.43;

            addProductMethod.Invoke(instance, new object[] { productType, price });

            registerStorageMethod.Invoke(instance, new object[] { "DistributionCenter", "Gosho" });
            selectVehicleMethod.Invoke(instance, new object[] { "Gosho", 0 });

            string[] products = new string[] { "HardDrive" };

            var actualResult = loadVehicleMethod.Invoke(instance, new object[] { products });

            var expectedResult = $"Loaded 1/1 products into Van";

            Assert.AreEqual(expectedResult, actualResult);

        }
        [Test]
        public void ValidateSendVehicleToMethod()
        {
            var registerStorageMethod = storageMaster.GetMethod("RegisterStorage");
            var instance = Activator.CreateInstance(storageMaster);

            string firstStorageType = "DistributionCenter";
            string firstName = "Gosho";

            string secondStorageType = "AutomatedWarehouse";
            string secondName = "Pesho";

            registerStorageMethod.Invoke(instance, new object[] { firstStorageType, firstName });
            registerStorageMethod.Invoke(instance, new object[] { secondStorageType, secondName });

            var actualResult = storageMaster.GetMethod("SendVehicleTo").Invoke(instance, new object[] { "Gosho", 0, "Pesho" });

            var expectedResult = $"Sent Van to Pesho (slot 1)";

            Assert.AreEqual(expectedResult, actualResult);
        }

        
        [Test]
        public void ValidateUnloadVehicleMethod()
        {
            var registerStorageMethod = storageMaster.GetMethod("RegisterStorage");
            var selectVehicleMethod = storageMaster.GetMethod("SelectVehicle");
            var loadVehicleMethod = storageMaster.GetMethod("LoadVehicle");
            var unloadVehicleMethod = storageMaster.GetMethod("UnloadVehicle");
            var instance = Activator.CreateInstance(storageMaster);

            var addProductMethod = storageMaster.GetMethod("AddProduct");
            string productType = "HardDrive";
            double price = 230.43;

            addProductMethod.Invoke(instance, new object[] { productType, price });

            registerStorageMethod.Invoke(instance, new object[] { "DistributionCenter", "Gosho" });
            selectVehicleMethod.Invoke(instance, new object[] { "Gosho", 0 });

            string[] products = new string[] { "HardDrive" };
            loadVehicleMethod.Invoke(instance, new object[] { products });

            string storageName = "Gosho";
            int garageSlot = 0;
            var actualResult = unloadVehicleMethod.Invoke(instance, new object[] { storageName, garageSlot });

            var expectedResult = $"Unloaded 2/2 products at Gosho";

            Assert.AreEqual(expectedResult, actualResult);
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
