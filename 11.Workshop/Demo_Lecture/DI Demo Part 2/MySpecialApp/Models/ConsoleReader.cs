using System;
using System.Collections.Generic;
using System.Text;
using MySpecialApp.Models.Contracts;

namespace MySpecialApp.Models
{
    public class ConsoleReader : IReader
    {
        public string Read()
        {
            return Console.ReadLine();
        }
    }
}
