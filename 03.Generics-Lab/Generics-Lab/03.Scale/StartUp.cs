namespace GenericScale
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var scale = new Scale<string>("Ani", "Vasko");
            Console.WriteLine(scale.GetHeavier());
        }
    }
}
