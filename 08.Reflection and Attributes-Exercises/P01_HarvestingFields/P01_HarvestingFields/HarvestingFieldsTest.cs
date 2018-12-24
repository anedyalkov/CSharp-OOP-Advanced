 namespace P01_HarvestingFields
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            var command = Console.ReadLine();
            var type = typeof(HarvestingFields);
            while (command != "HARVEST")
            {
                if (command == "private")
                {
                    var privateFields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
                    foreach (var field in privateFields.Where(f => f.IsPrivate))
                    {
                        Console.WriteLine($"{field.Attributes.ToString().ToLower()} {field.FieldType.Name} {field.Name}");
                    }
                }
                else if (command == "protected")
                {
                    var protectedFields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
                    foreach (var field in protectedFields.Where(f => f.IsFamily))
                    {
                        Console.WriteLine($"{command} {field.FieldType.Name} {field.Name}");
                    }
                }
                else if (command == "public")
                {
                    var publicFields = type.GetFields(BindingFlags.Instance | BindingFlags.Public);
                    foreach (var field in publicFields)
                    {
                        Console.WriteLine($"{field.Attributes.ToString().ToLower()} {field.FieldType.Name} {field.Name}");
                    }
                }
                else
                {
                    var allFields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                    foreach (var field in allFields)
                    {
                        if (field.Attributes.ToString().ToLower() == "family")
                        {
                            Console.WriteLine($"protected {field.FieldType.Name} {field.Name}");
                        }
                        else
                        {
                            Console.WriteLine($"{field.Attributes.ToString().ToLower()} {field.FieldType.Name} {field.Name}");
                        }
                        
                    }
                }
                command = Console.ReadLine();
            }
        }
    }
}
