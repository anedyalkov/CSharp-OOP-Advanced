using System;
using System.Collections.Generic;
using System.Text;

namespace _02.ExtendedDatabase
{
    public class Person
    {
        private int id;
        private string username;

        public Person(int id, string username)
        {
            this.Id = id;
            this.Username = username;
        }

        public int Id
        {
            get => id;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(id));
                }
                id = value;
            }
        }

        public string Username
        {
            get => username;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(nameof(username));
                }
                username = value;
            }
        }

        public bool Equals(Person other)
        {
            bool result = this.Id == other.Id && this.Username == other.Username;
            return result;
        }
    }
}
