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
}

