namespace P03_BarraksWars.Core.Command
{
    using _03BarracksFactory.Contracts;

    public class AddCommand : Command
    {
        [Inject]
        private IRepository repository;
        [Inject]
        private IUnitFactory unitFactory;

        public AddCommand(string[] data, IRepository repository, IUnitFactory unitFactory) : base(data)
        {
            Repository = repository;
            UnitFactory = unitFactory;
        }

        public  IRepository Repository
        {
            get { return repository; }
            set { repository = value; }
        }

        public IUnitFactory UnitFactory
        {
            get { return unitFactory; }
            set { unitFactory = value; }
        }

        public override string Execute()
        {
            string unitType = Data[1];
            IUnit unitToAdd = this.UnitFactory.CreateUnit(unitType);
            this.Repository.AddUnit(unitToAdd);
            string output = unitType + " added!";
            return output;
        }
    }
}
