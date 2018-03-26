using System;

namespace _08.CustomListSorter
{
    public class StartUp
    {
        public static void Main()
        {
            string input;
            string element;
            var box = new Box<string>();
            while ((input = Console.ReadLine()) != "END")
            {
                var commandArgs = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var command = commandArgs[0];
                switch (command)
                {
                    case "Add":
                        box.Add(commandArgs[1]);
                        break;
                    case "Remove":
                        box.Remove(int.Parse(commandArgs[1]));
                        break;
                    case "Contains":
                        element = commandArgs[1];
                        Console.WriteLine(box.Contains(element));
                        break;
                    case "Swap":
                        var firstIndex = int.Parse(commandArgs[1]);
                        var secondIndex = int.Parse(commandArgs[2]);
                        box.Swap(firstIndex, secondIndex);
                        break;
                    case "Greater":
                        element = commandArgs[1];
                        Console.WriteLine(box.CountGreaterThan(element));
                        break;
                    case "Max":
                        Console.WriteLine(box.Max());
                        break;
                    case "Min":
                        Console.WriteLine(box.Min());
                        break;
                    case "Sort":
                        box.Sort();
                        break;
                    case "Print":
                        box.Print();
                        break;
                }
            }
        }
    }
}
