namespace P03_BarraksWars.Core.Command
{
    using _03BarracksFactory.Contracts;

    public class RetireCommand : Command
    {
        public RetireCommand(string[] data, IRepository repository, IUnitFactory unitFactory) : base(data, repository, unitFactory)
        {
        }

        public override string Execute()
        {
            var unitToRemove = Data[1];
            Repository.RemoveUnit(unitToRemove);
            string output = unitToRemove + " retired!";
            return output;
        }
    }
}
