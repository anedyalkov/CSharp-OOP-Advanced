using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string StealFieldInfo(string className, params string[] args)
    {
        var sb = new StringBuilder();
        var type = Type.GetType(className);
        var hacker = Activator.CreateInstance(type, new object[] { });
        var fields = type.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)
            .Where(f => f.Name == args[0] || f.Name == args[1]);
        sb.AppendLine($"Class under investigation: {className}");

        foreach (var field in fields)
        {
            sb.AppendLine($"{field.Name} = {field.GetValue(hacker)}");
        }
        return sb.ToString().Trim();
    }

    public string AnalyzeAcessModifiers(string className)
    {
        var sb = new StringBuilder();
        var type = Type.GetType(className);

        var fields = type.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);

        foreach (var field in fields)
        {
            sb.AppendLine($"{field.Name} must be private!");
        }

        var properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

        foreach (var property in properties)
        {
            if (property.GetMethod?.IsPrivate == true)
            {
                sb.AppendLine($"{property.GetMethod.Name} have to be public!");
            }
        }

        foreach (var property in properties)
        {
            if (property.SetMethod?.IsPublic == true)
            {
                sb.AppendLine($"{property.SetMethod.Name} have to be private!");
            }
        }

        return sb.ToString().Trim();
    }
}

