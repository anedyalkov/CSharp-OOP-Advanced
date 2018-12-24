namespace MyCrazyApp.Models
{
    using System.IO;
    using Contracts;

    public class FileWriter : IWriter
    {
        private const string FilePath = "log.txt";

        public void Write(string text)
        {
            File.AppendAllText(FilePath, text);
        }
    }
}
