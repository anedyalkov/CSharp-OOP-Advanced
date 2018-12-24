namespace P02_BlackBoxInteger
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var type = typeof(BlackBoxInteger);
            Type[] paramTypes = new Type[] { typeof(int) };
            var field = type.GetField("innerValue",BindingFlags.Instance | BindingFlags.NonPublic);

            //ConstructorInfo constructor = type.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null, new Type[0], null);
            //var blackBoxInstance = constructor.Invoke(new object[0]);
            var blackBoxInstance = Activator.CreateInstance(type,true);
            while (input != "END")
            {
                var inputArgs = input.Split("_").ToArray();
                var methodName = inputArgs[0];
                var number = int.Parse(inputArgs[1]);

                //var currentMethod = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic).First(m => m.Name == methodName);
                //var currentMethod = type.GetMethod(methodName, BindingFlags.Instance | BindingFlags.NonPublic, null, paramTypes, null);
                var currentMethod = type.GetMethod(methodName, BindingFlags.Instance | BindingFlags.NonPublic);
                currentMethod.Invoke(blackBoxInstance, new object[] { number });
                Console.WriteLine(field.GetValue(blackBoxInstance));

                input = Console.ReadLine();
            }
        }
    }
}
