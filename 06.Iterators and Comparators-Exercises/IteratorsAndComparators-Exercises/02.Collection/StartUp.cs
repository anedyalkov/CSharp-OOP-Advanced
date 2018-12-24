namespace _02.Collection
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var tokens = Console.ReadLine().Split();
            ListIterator<string> list = new ListIterator<string>(tokens.Skip(1).ToArray());

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                switch (input)
                {
                    case "Move":
                        Console.WriteLine(list.Move()); 
                        break;
                    case "HasNext":
                        Console.WriteLine(list.HasNext());
                        break;
                    case "Print":
                        try
                        {
                            list.Print();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case "PrintAll":
                        {
                            foreach (var element in list)
                            {
                                Console.Write(element + " ");
                            }
                            Console.WriteLine();
                        }
                        break;
                }
            }
        }
    }
}
