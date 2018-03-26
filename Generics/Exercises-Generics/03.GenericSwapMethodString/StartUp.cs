using System;

namespace _03.GenericSwapMethodString
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var count = int.Parse(Console.ReadLine());

            var box = new Box<string>();

            for (int i = 0; i < count; i++)
            {
                var input = Console.ReadLine();
                box.Add(input);
            }

            var swapArgs = Console.ReadLine().Split();

            var firstIndex = int.Parse(swapArgs[0]);
            var secondIndex = int.Parse(swapArgs[1]);

            box.Swap(firstIndex, secondIndex);

            Console.WriteLine(box);
        }
    }
}
