using _01.Database;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace UnitTests
{
    public class DatabaseTests
    {
        private const int DataSize = 16;
        [Test]
        public void ConstructorSetsData()
        {
            var inputValues = new int[] { 3, 5, 7, 9 };

            var database = new Database(inputValues);
            var type = typeof(Database);
            FieldInfo data = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).FirstOrDefault(f => f.Name == "data");
            var dataAsArray = (int[])data.GetValue(database);
            var dataLength = dataAsArray.Length;

            Assert.That(dataLength, Is.EqualTo(DataSize));
        }

        [Test]
        public void EmptyConstructorSetsCurrentIndexToZero()
        {
            var database = new Database();

            var type = typeof(Database);

            var currentIndex = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).FirstOrDefault(f => f.Name == "currentIndex");
            var currentIndexValue = currentIndex.GetValue(database);

            Assert.That(currentIndexValue, Is.EqualTo(0));
        }

        [Test]
        public void ConstructorSetsCurrentIndexCorrect()
        {
            var inputValues = new int[] { 3, 5, 7, 9 };
            var database = new Database(inputValues);
            var type = typeof(Database);

            FieldInfo currentIndex = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).FirstOrDefault(f => f.Name == "currentIndex");
            var currentIndexValue = currentIndex.GetValue(database);

            Assert.That(currentIndexValue, Is.EqualTo(inputValues.Length));
        }

        [Test]
        public void InvalidConstructorParametersThrowsArgumentException()
        {
            var data = new int[17];

            Assert.That(() => new Database(data), Throws.ArgumentException);
        }

        [Test]
        [TestCase(4)]
        public void AddMethodIsValid(int value)
        {
            Database database = new Database();

            database.Add(value);

            var type = typeof(Database);
            FieldInfo currentIndexField = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).FirstOrDefault(f => f.Name == "currentIndex");
            var currentIndex = (int)currentIndexField.GetValue(database);

            FieldInfo data = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).FirstOrDefault(f => f.Name == "data");
            var firstNumberInData = ((int[])data.GetValue(database)).First();

            Assert.That(firstNumberInData, Is.EqualTo(value));
            Assert.That(currentIndex, Is.EqualTo(1));
        }

   

        [Test]
        public void AddMethodThrowsInvalidOperationException()
        {
            var capacity = 16;
            int[] data = new int[capacity];
            Database database = new Database(data);

            var type = typeof(Database);
            FieldInfo currentIndexField = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).FirstOrDefault(f => f.Name == "currentIndex");
            currentIndexField.SetValue(database, capacity);

            Assert.That(() => database.Add(4), Throws.InvalidOperationException.With.Message.EqualTo("Array is full."));
        }

        [Test]
        [TestCase(5)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] {0})]
        public void RemoveMethodIsValid(params int[] values)
        {
            Database database = new Database(values);           
            database.Remove();

            var type = typeof(Database);
            FieldInfo currentIndexField = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).FirstOrDefault(f => f.Name == "currentIndex");
            var currentIndex = (int)currentIndexField.GetValue(database);

            FieldInfo data = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).FirstOrDefault(f => f.Name == "data");
            var dataAsArray = (int[])data.GetValue(database);

            Assert.That(dataAsArray[currentIndex], Is.EqualTo(default(int)));;
        }

        [Test]
        public void RemoveMethodThrowsInvalidOperationException()
        {
            Database database = new Database();

            var type = typeof(Database);
            FieldInfo currentIndexField = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).FirstOrDefault(f => f.Name == "currentIndex");
            currentIndexField.SetValue(database, 0);

            Assert.That(() => database.Remove(), Throws.InvalidOperationException.With.Message.EqualTo("Array is empty."));
        }

        [Test]
        [TestCase(5)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 0 })]
        public void FetchMethodIsValid(params int[] values)
        {
            Database database = new Database(values);
            var array = database.Fetch();

            var type = typeof(Database);
            FieldInfo currentIndexField = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).FirstOrDefault(f => f.Name == "currentIndex");
            var currentIndex = (int)currentIndexField.GetValue(database);

            FieldInfo data = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).FirstOrDefault(f => f.Name == "data");
            var dataAsArray = (int[])data.GetValue(database);

            var dataToCompare = dataAsArray.Take(currentIndex);

            Assert.That(array, Is.EquivalentTo(dataToCompare)); ;
        }
    }
}
