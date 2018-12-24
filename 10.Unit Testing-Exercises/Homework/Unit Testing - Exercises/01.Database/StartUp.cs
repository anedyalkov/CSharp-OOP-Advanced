using System;

namespace _01.Database
{
    public class StartUp
    {
        public static void Main()
        {
            int[] inputValues = new int[] { 3 };
            var database = new Database(inputValues);


            //database.Add(6);
            //database.Add(8);
            //database.Add(10);
            database.Remove();
            database.Add(6);
            var array = database.Fetch();

        }
    }
}
