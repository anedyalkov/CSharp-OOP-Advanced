using Problem02.Core.Contracts;

namespace Problem02.Core.Commands
{
    public class ScreamCommand : ICommand
    {
        public string Execute()
        {
            return "Whooooooooooooooooo";
        }
    }
}
