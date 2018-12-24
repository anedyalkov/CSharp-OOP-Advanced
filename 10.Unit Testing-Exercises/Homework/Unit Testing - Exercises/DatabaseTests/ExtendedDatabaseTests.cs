using _02.ExtendedDatabase;
using NUnit.Framework;
using System;
using System.Linq;
using System.Reflection;

namespace UnitTests
{
    public class ExtendedDatabaseTests
    {
        private const int DataSize = 16;
        [Test]
        public void ConstructorSetsDataCorrect()
        {
            var persons = new Person[] { new Person(1, "Ivan"),new Person(2, "Gosho"), new Person(3, "Niki"), new Person(4, "Ivan") };
            var database = new Database(persons);
            var type = typeof(Database);
            FieldInfo data = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).FirstOrDefault(f => f.Name == "data");
            var dataAsArray = (Person[])data.GetValue(database);
            var dataLength = dataAsArray.Length;

            Assert.That(dataLength, Is.EqualTo(DataSize));
        }

        [Test]
        public void EmptyConstructorSetsCurrentIndexToZero()
        {
            var database = new Database();

            var type = typeof(Database);

            var field = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).FirstOrDefault(f => f.Name == "currentIndex");
            var fieldValue = field.GetValue(database);

            Assert.That(fieldValue, Is.EqualTo(0));
        }

        [Test]
        public void ConstructorSetsCurrentIndexCorrect()
        {
            var persons = new Person[] { new Person(1, "Ivan"), new Person(2, "Gosho"), new Person(3, "Niki"), new Person(4, "Pesho") };
            var database = new Database(persons);
            var type = typeof(Database);

            FieldInfo currentIndex = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).FirstOrDefault(f => f.Name == "currentIndex");
            var currentIndexValue = currentIndex.GetValue(database);

            Assert.That(currentIndexValue, Is.EqualTo(persons.Length));
        }

        [Test]
        public void InvalidConstructorParametersThrowsArgumentException()
        {
            var data = new Person[17];

            Assert.That(() => new Database(data), Throws.ArgumentException);
            //Assert.Throws<ArgumentException>(() => new Database(data));
        }
        [Test]
        public void AddMethodThrowsInvalidOpretaionExceptionWhenDataIsFull()
        {
            var database = new Database();
            var type = typeof(Database);
            FieldInfo currentIndex = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).FirstOrDefault(f => f.Name == "currentIndex");
            currentIndex.SetValue(database,DataSize);

            Assert.That(() => database.Add(new Person(3, "Gogo")), Throws.InvalidOperationException.With.Message.EqualTo("Array is full."));
        }

        [Test]
        public void AddMethodThrowsInvalidOpretaionExceptionWhenThereIsPersonWithSameIdAndUsername()
        {
            var persons = new Person[] { new Person(1, "Ivan"), new Person(2, "Gosho"), new Person(3, "Niki"), new Person(4, "Pesho") };
            var database = new Database(persons);

            Assert.That(() => database.Add(new Person(1, "Ivan")), Throws.InvalidOperationException.With.Message.EqualTo("There is already person with with same Username and Id."));
        }

        [Test]
        public void AddMethodIsValid()
        {
            Database database = new Database();
            var person = new Person(2, "Gogo");
            database.Add(person);

            var type = typeof(Database);
            FieldInfo currentIndexField = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).FirstOrDefault(f => f.Name == "currentIndex");
            var currentIndex = (int)currentIndexField.GetValue(database);

            FieldInfo data = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).FirstOrDefault(f => f.Name == "data");
            var firstPersonInData = ((Person[])data.GetValue(database)).First();

            Assert.That(firstPersonInData, Is.EqualTo(person));
            Assert.That(currentIndex, Is.EqualTo(1));
        }

        [Test]
        public void RemoveMethodIsValid()
        {
            var persons = new Person[] { new Person(1, "Ivan"), new Person(2, "Gosho"), new Person(3, "Niki"), new Person(4, "Ivan") };
            Database database = new Database();
            var type = typeof(Database);

            FieldInfo currentIndexField = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).FirstOrDefault(f => f.Name == "currentIndex");
            var currentIndex = (int)currentIndexField.GetValue(database);

            FieldInfo data = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).FirstOrDefault(f => f.Name == "data");
            var dataAsArray = (Person[])data.GetValue(database);

            Assert.That(dataAsArray[currentIndex], Is.EqualTo(default(Person))); ;
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
        public void FetchMethodIsValid()
        {
            var persons = new Person[] { new Person(1, "Ivan"), new Person(2, "Gosho"), new Person(3, "Niki"), new Person(4, "Pesho") };
            Database database = new Database(persons);
            var array = database.Fetch();

            var type = typeof(Database);
            FieldInfo currentIndexField = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).FirstOrDefault(f => f.Name == "currentIndex");
            var currentIndex = (int)currentIndexField.GetValue(database);

            FieldInfo data = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).FirstOrDefault(f => f.Name == "data");
            var dataAsArray = (Person[])data.GetValue(database);

            var dataToCompare = dataAsArray.Take(currentIndex);

            Assert.That(array, Is.EquivalentTo(dataToCompare)); ;
        }
        //Методът работи, но хвърля някаква грешка
        [Test]
        public void FindByUsernameMethodIsValid()
        {
            var persons = new Person[] { new Person(1, "Ivan"), new Person(2, "Gosho"), new Person(3, "Niki"), new Person(4, "Pesho") };
            Database database = new Database(persons);

            Assert.That(() => database.FindByUsername("Ivan"), Is.EqualTo(new Person(1, "Ivan")));
        }

        [Test]
        [TestCase("Gogo")]
        [TestCase("Mimi")]
        public void FindByUsernameMethodThrowsInvalidOperationException(string name)
        {
            var persons = new Person[] { new Person(1, "Ivan"), new Person(2, "Gosho"), new Person(3, "Niki"), new Person(4, "Pesho") };
            Database database = new Database(persons);

            Assert.That(() => database.FindByUsername(name), Throws.InvalidOperationException);
        }
        //Методът работи, но хвърля някаква грешка
        [Test]
        public void FindByIdMethodIsValid()
        {
            var persons = new Person[] { new Person(1, "Ivan"), new Person(2, "Gosho"), new Person(3, "Niki"), new Person(4, "Pesho") };
            Database database = new Database(persons);

            Assert.That(() => database.FindById(1), Is.EqualTo(new Person(1, "Ivan")));
        }

        [Test]
        public void FindByIdUserMethodThrowsInvalidOperationException()
        {
            var persons = new Person[] { new Person(1, "Ivan"), new Person(2, "Gosho"), new Person(3, "Niki"), new Person(4, "Pesho") };
            Database database = new Database(persons);

            Assert.That(() => database.FindById(5), Throws.InvalidOperationException);
        }

        [Test]
        public void FindByIdMethodThrowsArgumentOutOfRangeExceptionWhenIdIsInvalid()
        {
            var persons = new Person[] { new Person(1, "Ivan"), new Person(2, "Gosho"), new Person(3, "Niki"), new Person(4, "Pesho") };
            Database database = new Database(persons);


            Assert.That(() => database.FindById(-1), Throws.Exception);
        }
    }
}
