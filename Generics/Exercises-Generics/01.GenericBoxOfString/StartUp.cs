using System;

namespace _01.GenericBoxOfString
{
    public class StartUp
    {
        public static void Main()
        {
            var count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                var input = Console.ReadLine();

                var box = new Box<string>(input);

                Console.WriteLine(box);
            }
        }
    }
}
