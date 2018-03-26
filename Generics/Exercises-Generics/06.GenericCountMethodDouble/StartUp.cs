using System;

namespace _06.GenericCountMethodDouble
{
    public class StartUp
    {
        public static void Main()
        {
            var count = int.Parse(Console.ReadLine());

            var box = new Box<double>();

            for (int i = 0; i < count; i++)
            {
                var input = double.Parse(Console.ReadLine());
                box.Add(input);
            }

            var valueToCompare = double.Parse(Console.ReadLine());

            box.CountGreaterValues(valueToCompare);

            Console.WriteLine(box.Count);
        }
    }
}
