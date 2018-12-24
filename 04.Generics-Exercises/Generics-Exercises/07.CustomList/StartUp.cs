namespace _07.CustomList
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            string input;
            string element;
            var customList = new CustomList<string>();
            while ((input = Console.ReadLine()) != "END")
            {
                var commandArgs = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var command = commandArgs[0];
                switch (command)
                {
                    case "Add":
                        customList.Add(commandArgs[1]);
                        break;
                    case "Remove":
                        customList.Remove(int.Parse(commandArgs[1]));
                        break;
                    case "Contains":
                        element = commandArgs[1];
                        Console.WriteLine(customList.Contains(element));
                        break;
                    case "Swap":
                        var firstIndex = int.Parse(commandArgs[1]);
                        var secondIndex = int.Parse(commandArgs[2]);
                        customList.Swap(firstIndex, secondIndex);
                        break;
                    case "Greater":
                        element = commandArgs[1];
                        Console.WriteLine(customList.CountGreaterThan(element));
                        break;
                    case "Max":
                        Console.WriteLine(customList.Max());
                        break;
                    case "Min":
                        Console.WriteLine(customList.Min());
                        break;
                    case "Print":
                        Console.WriteLine(customList.Print()); 
                        break;
                }
            }
        }
    }
}
