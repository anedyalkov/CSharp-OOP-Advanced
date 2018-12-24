namespace P03_BarraksWars.Core.Command
{
    using _03BarracksFactory.Contracts;

    public abstract class Command : IExecutable
    {
        private string[] data;
        private IRepository repository;
        private IUnitFactory unitFactory;

        protected Command(string[] data, IRepository repository, IUnitFactory unitFactory)
        {
            Data = data;
            Repository = repository;
            UnitFactory = unitFactory;
        }

        protected string[] Data
        {
            get { return this.data; }
            set { this.data = value; }
        }

        protected IRepository Repository
        {
            get { return repository; }
            set { repository = value; }
        }

        protected IUnitFactory UnitFactory
        {
            get { return unitFactory ; }
            set { unitFactory = value; }
        }


        public abstract string Execute();
       
    }
}
