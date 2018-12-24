namespace P03_BarraksWars.Core.Command
{
    using _03BarracksFactory.Contracts;

    public class RetireCommand : Command
    {
        [Inject]
        private IRepository repository;

        public RetireCommand(string[] data, IRepository repository) : base(data)
        {
            Repository = repository;
        }

        public IRepository Repository
        {
            get { return repository; }
            set { repository = value; }
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
