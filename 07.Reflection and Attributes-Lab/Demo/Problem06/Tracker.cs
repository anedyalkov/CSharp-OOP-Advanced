using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

public class Tracker
{
    public void PrintMethodsByAuthor()
    {
        var type = typeof(StartUp);

        var methods = type.GetMethods(BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);

        foreach (var methodInfo in methods)
        {
            var customeAttribute = methodInfo.GetCustomAttribute<SoftUniAttribute>();
            
            if (customeAttribute != null)
            {
                Console.WriteLine($"{methodInfo.Name} is written by {customeAttribute.Name}");
            }
        }
    }
}

