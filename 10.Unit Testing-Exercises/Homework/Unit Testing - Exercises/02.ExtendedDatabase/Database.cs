using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02.ExtendedDatabase
{
    public class Database
    {
        private const int MaxCapacity = 16;

        private Person[] data;
        private int currentIndex;

        public Database()
        {
            this.data = new Person[MaxCapacity];
            this.currentIndex = 0;
        }

        public Database(params Person[] inputElements) : this()
        {
            this.InitializeElements(inputElements);
        }

        private void InitializeElements(Person[] inputElements)
        {

            Array.Copy(inputElements, this.data, inputElements.Length);
            this.currentIndex = inputElements.Length;
        }

        public void Add(Person element)
        {
            if (currentIndex >= MaxCapacity)
            {
                throw new InvalidOperationException("Array is full.");
            }

            if (this.data.Take(this.currentIndex).Any(p => p.Equals(element)))
            {
                throw new InvalidOperationException("There is already person with with same Username and Id.");
            }

            this.data[currentIndex] = element;
            this.currentIndex++;
        }

        public void Remove()
        {
            if (currentIndex == 0)
            {
                throw new InvalidOperationException("Array is empty.");
            }

            currentIndex--;
            this.data[currentIndex] = default(Person);
        }

        public Person FindByUsername(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (this.data.Take(this.currentIndex).All(p => p.Username != name))
            {
                throw new InvalidOperationException($"No person with Username{name}.");
            }

            var searchedPerson = this.data.FirstOrDefault(d => d.Username == name);
            if (searchedPerson == null)
            {
                throw new ArgumentNullException($"No person with this Username.");
            }

            return searchedPerson;
        }

        public Person FindById(int id)
        {
            var searchedPerson = this.data.Take(this.currentIndex).FirstOrDefault(d => d.Id == id);

            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }

            if (searchedPerson == null)
            {
                throw new InvalidOperationException($"No person with this Id.");
            }

            return searchedPerson;
        }

        public Person[] Fetch()
        {
            Person[] newArray = new Person[currentIndex];
            Array.Copy(this.data, newArray, currentIndex);

            return newArray;
        }
    }
}
