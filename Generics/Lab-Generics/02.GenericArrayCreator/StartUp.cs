using System;

namespace _02.GenericArrayCreator
{
    public class StartUp
    {
        public static void Main()
        {
            string[] strings = ArrayCreator.Create(5, "Pesho");
            int[] integers = ArrayCreator.Create(10, 33);
        }
    }
}
