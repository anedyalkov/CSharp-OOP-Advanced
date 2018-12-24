namespace MyCrazyApp.Models
{
    using System;
    using Contracts;

    public class ConsoleWriter : IWriter
    {
        public void Write(string text)
        {
            Console.WriteLine(text);
        }
    }
}
