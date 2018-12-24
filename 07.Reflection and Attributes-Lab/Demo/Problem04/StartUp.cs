using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Problem04
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Type type = typeof(Rich);
            //var type = Type.GetType("Problem04.Rich");
            //var type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(x => x.Name ==
            //"Rich");

            //var instance = Activator.CreateInstance(type);
            var instance = Activator.CreateInstance(type, new object[] { "new address"});

            var firstMethod = type.GetMethod("Hello", new Type[] { typeof(string)});
            var constructor = type.GetConstructor(new Type[] { typeof(string)});
            //not needed BindingFlags
            var property = type.GetProperty("Age", BindingFlags.Public | BindingFlags.Instance);

            var myField = type.GetField("publicName");
            myField.SetValue(instance, "Ime");
            var getFieldValue = myField.GetValue(instance);

            var result = firstMethod.Invoke(instance, new object[] { "Stoyan" });

            Console.WriteLine(result);
        }
    }
}
