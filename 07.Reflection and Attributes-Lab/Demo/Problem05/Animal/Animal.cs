using System;
using System.Collections.Generic;
using System.Text;
using Problem05.Animal.Contracts;

namespace Problem05.Animal
{
    public abstract class Animal : Mammal, IAnimal 
    {
        private string name;
        private int age;

        private List<string> foods;

        protected Animal(string name, int age)
        {
            this.Name = name;
            this.Age = age;
            this.foods = new List<string>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                this.name = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }
            private set
            {
                this.age = value;
            }
        }

        public void Attack()
        {
            Console.WriteLine("Attack");
        }

        public void AddFood(string foodName)
        {
            this.foods.Add(foodName);
        }
    }
}
