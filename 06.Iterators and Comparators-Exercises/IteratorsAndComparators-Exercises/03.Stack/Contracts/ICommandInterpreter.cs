namespace _03.Stack.Contracts
{
    public interface ICommandInterpreter
    {
        void ParseCommand(params string[] input);
    }
}
