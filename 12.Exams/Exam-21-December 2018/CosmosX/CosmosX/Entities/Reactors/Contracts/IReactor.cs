using CosmosX.Entities.CommonContracts;
using CosmosX.Entities.Modules.Absorbing.Contracts;
using CosmosX.Entities.Modules.Energy.Contracts;

namespace CosmosX.Entities.Reactors.Contracts
{
    public interface IReactor : IIdentifiable
    {
        long TotalEnergyOutput { get; }

        long TotalHeatAbsorbing { get; }

        int ModuleCount { get; }

        void AddEnergyModule(IEnergyModule energyModule);

        void AddAbsorbingModule(IAbsorbingModule absorbingModule);
    }
}