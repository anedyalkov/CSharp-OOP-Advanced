using System;
using System.Linq;
using System.Reflection;

namespace Problem01
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var assembly = Assembly.LoadFile(@"C:\Users\Stoyan\Desktop\Demo\MyCrazyApp.dll");

            //Find all classes
            var allTypes = assembly.GetTypes();

            foreach (var currentType in allTypes)
            {
                Console.WriteLine(currentType.Name);

                foreach (var propertyInfo in currentType.GetProperties())
                {
                    Console.WriteLine(propertyInfo.Name);
                }

                foreach (var methodInfo in currentType.GetMethods())
                {
                    Console.WriteLine(methodInfo.Name);
                }
            }
  
            //Create instance

            //Invoke method
        }
    }
}
