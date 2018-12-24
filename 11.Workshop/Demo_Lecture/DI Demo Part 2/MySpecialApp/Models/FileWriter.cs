using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using MySpecialApp.Models.Contracts;

namespace MySpecialApp.Models
{
    public class FileWriter : IWriter
    {
        private const string FilePath = "log.txt";

        public void Write(string content)
        {
            File.AppendAllText(FilePath, content);
        }
    }
}
