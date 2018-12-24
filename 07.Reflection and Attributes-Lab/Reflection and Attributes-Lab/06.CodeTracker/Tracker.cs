using System;
using System.Linq;
using System.Reflection;

public class Tracker
{
    public void PrintMethodsByAuthor()
    {
        var type = typeof(StartUp);
        var methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);

        foreach (var method in methods)
        {
            if (method.CustomAttributes.Any(n => n.AttributeType == typeof(SoftUniAttribute)))
            {
                var attrs = method.GetCustomAttributes<SoftUniAttribute>();
                foreach (var attr in attrs)
                {
                   Console.WriteLine($"{method.Name} is written by {attr.Name}");
                }
            }
        }
    }
}

