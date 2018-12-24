using System.Collections.Generic;
using CosmosX.Entities.Modules.Absorbing.Contracts;
using CosmosX.Entities.Modules.Contracts;
using CosmosX.Entities.Modules.Energy.Contracts;

namespace CosmosX.Entities.Containers.Contracts
{
    public interface IContainer
    {
        long TotalEnergyOutput { get; }

        long TotalHeatAbsorbing { get; }

        IReadOnlyCollection<IModule> ModulesByInput { get; }

        void AddEnergyModule(IEnergyModule energyModule);

        void AddAbsorbingModule(IAbsorbingModule absorbingModule);
    }
}