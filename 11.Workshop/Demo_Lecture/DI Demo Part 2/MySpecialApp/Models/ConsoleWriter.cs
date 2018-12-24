using System;
using System.Collections.Generic;
using System.Text;
using MySpecialApp.Models.Contracts;

namespace MySpecialApp.Models
{
    public class ConsoleWriter : IWriter
    {
        public void Write(string content)
        {
            Console.WriteLine(content);
        }
    }
}
