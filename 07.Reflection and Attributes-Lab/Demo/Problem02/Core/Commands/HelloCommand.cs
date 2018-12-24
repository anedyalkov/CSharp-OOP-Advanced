namespace Problem02.Core.Commands
{
    using Contracts;

    public class HelloCommand : ICommand
    {
        public string Execute()
        {
            return "Hello, my best friend";
        }
    }
}
