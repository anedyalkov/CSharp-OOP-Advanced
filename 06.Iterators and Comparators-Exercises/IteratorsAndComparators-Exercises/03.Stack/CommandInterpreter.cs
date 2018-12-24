namespace _03.Stack
{
    using _03.Stack.Contracts;
    using System;
    using System.Linq;

    public class CommandInterpreter : ICommandInterpreter
    {
        private Stack<string> stack;
        private string[] stackArgs;

        public CommandInterpreter()
        {

        }
        public void ParseCommand(params string[] inputArgs)
        {
         
            if (inputArgs.Length > 1)
            {
               stackArgs = inputArgs
                    .Select(e => e.TrimEnd(','))
                    .Skip(1)
                    .ToArray();
                stack = new Stack<string>(stackArgs);
            }
            var command = inputArgs[0];
           
            switch (command)
            {
                case "Pop":
                    stack.Pop();
                    break;
                case "Push":
                    var element = stackArgs.LastOrDefault();
                    stack.Push(element);
                    break;
                case "END":
                    //this.isRunning = false;
                    for (int i = 0; i < 2; i++)
                    {
                        foreach (var item in stack)
                        {
                            Console.WriteLine(item);
                        }
                    }
                    break;
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}
