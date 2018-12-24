using System;
using System.Linq;
using System.Reflection;
using Problem03.Extension;

namespace Problem03
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("1. Problem03.StartUp Calling Assembly: " + Assembly.GetCallingAssembly().FullName);
            Console.WriteLine("2. Problem03.StartUp Executing Assembly: " + Assembly.GetExecutingAssembly().FullName);

            Console.WriteLine(new Stoyan().GetCrazy());
        }
    }
}
