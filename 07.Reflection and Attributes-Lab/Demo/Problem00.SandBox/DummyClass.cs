using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Text;

namespace Problem00.SandBox
{
    public class DummyClass
    {
        private int age;

        public DummyClass(string name)
        {
            this.Name = name;
        }
        
        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string WhoAmI()
        {
            return this.Name;
        }

        public void DeprecatedMethod()
        {
            Console.WriteLine("Deprecated!");
        }

    }
}
