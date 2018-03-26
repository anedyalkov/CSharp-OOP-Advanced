using System;

namespace _00.GenericBox
{
    public class StartUp
    {
        public static void Main()
        {
            var number = Console.ReadLine();

            Box<string> box = new Box<string>(number);

            Console.WriteLine(box);
        }
    }
}
