using System;

namespace _05.GenericCountMethodString
{
    public class StartUp
    {
        public static void Main()
        {
            var count = int.Parse(Console.ReadLine());

            var box = new Box<string>();

            for (int i = 0; i < count; i++)
            {
                var input = Console.ReadLine();
                box.Add(input);
            }

            var valueToCompare = Console.ReadLine();

            box.CountGreaterValues(valueToCompare);

            Console.WriteLine(box.Count);
        }
    }
}
