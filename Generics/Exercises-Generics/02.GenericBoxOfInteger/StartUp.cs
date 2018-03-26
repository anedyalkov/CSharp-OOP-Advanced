using System;

namespace _02.GenericBoxOfInteger
{
    public class StartUp
    {
        public static void Main()
        {
            var count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                var input = int.Parse(Console.ReadLine());

                var box = new Box<int>(input);

                Console.WriteLine(box);
            }
        }
    }
}
