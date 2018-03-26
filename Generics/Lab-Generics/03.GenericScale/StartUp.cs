using System;

namespace _03.GenericScale
{
    public class StartUp
    {
        public static void Main()
        {
           var scale = new Scale<string>("Pesho", "Gosho");

           Console.WriteLine(scale.GetHeavier()); 
        }
    }
}
