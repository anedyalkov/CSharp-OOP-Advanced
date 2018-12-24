using System;
using CosmosX.IO.Contracts;

namespace CosmosX.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}