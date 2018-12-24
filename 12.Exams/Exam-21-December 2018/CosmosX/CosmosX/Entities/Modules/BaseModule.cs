using CosmosX.Entities.Modules.Contracts;

namespace CosmosX.Entities.Modules
{
    public abstract class BaseModule : IModule
    {
        protected BaseModule(int id)
        {
            this.Id = id;
        }

        public int Id { get;}

        public override string ToString()
        {
            return $"{this.GetType().Name} Module - {this.Id}\n";
        }
    }
}