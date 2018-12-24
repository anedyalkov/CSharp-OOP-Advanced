namespace P03_BarraksWars.Core.Command
{
    using _03BarracksFactory.Contracts;

    public abstract class Command : IExecutable
    {
        private string[] data;
       

        protected Command(string[] data)
        {
            Data = data;
        }

        protected string[] Data
        {
            get { return this.data; }
            set { this.data = value; }
        }

        public abstract string Execute();
       
    }
}
