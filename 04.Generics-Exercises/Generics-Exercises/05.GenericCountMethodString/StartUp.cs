namespace _05.GenericCountMethodString
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var counter = int.Parse(Console.ReadLine());

            var box = new Box<string>();

            for (int i = 0; i < counter; i++)
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
