using System;
using System.Reflection;

namespace Problem03.Extension
{
    public class Stoyan
    {
        public string GetCrazy()
        {
            return "3. Problem03.Extensions.Stoyan Executing Assembly: " + Assembly.GetExecutingAssembly().FullName + "\n" +
                   "4. Problem03.Extensions.Stoyan Calling Assembly: " + Assembly.GetCallingAssembly().FullName;
        }
    }
}
