using CosmosX.Entities.Containers.Contracts;
using CosmosX.Entities.Modules.Absorbing.Contracts;
using CosmosX.Entities.Modules.Energy.Contracts;
using CosmosX.Entities.Reactors.Contracts;
using System;

namespace CosmosX.Entities.Reactors
{
    public abstract class BaseReactor : IReactor
    {
        private readonly IContainer moduleContainer;
        private int id;

        protected BaseReactor(int id, IContainer moduleContainer)
        {
            this.Id = id;
            this.moduleContainer = moduleContainer;
        }

        public int Id
        {
            get
            {
                return this.id;
            }
            private set
            {
                this.id = value;
            }
        }

        public virtual long TotalEnergyOutput 
            => this.moduleContainer.TotalEnergyOutput;

        public virtual long TotalHeatAbsorbing 
            => this.moduleContainer.TotalHeatAbsorbing;

        public int ModuleCount 
            => this.moduleContainer.ModulesByInput.Count;

        public void AddEnergyModule(IEnergyModule energyModule)
        {
            this.moduleContainer.AddEnergyModule(energyModule);
        }

        public void AddAbsorbingModule(IAbsorbingModule absorbingModule)
        {
            this.moduleContainer.AddAbsorbingModule(absorbingModule);
        }

        public override string ToString()
        {
            string result = $"{this.GetType().Name} - {this.Id}" +  Environment.NewLine + 
                            $"Energy Output: {this.TotalEnergyOutput}" + Environment.NewLine +
                            $"Heat Absorbing: {this.TotalHeatAbsorbing}" + Environment.NewLine +
                            $"Modules: {this.ModuleCount}";

            return result;
        }
    }
}