namespace _06.GenericCountMethodDouble
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var counter = int.Parse(Console.ReadLine());

            var box = new Box<double>();

            for (int i = 0; i < counter; i++)
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
