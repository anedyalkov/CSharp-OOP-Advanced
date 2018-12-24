using System;
using System.Collections.Generic;
using System.Text;

namespace Problem05.Animal.Contracts
{
    public interface IAnimal
    {
        string Name { get; }

        int Age { get; }

        void Attack();

        void AddFood(string foodName);
    }
}
