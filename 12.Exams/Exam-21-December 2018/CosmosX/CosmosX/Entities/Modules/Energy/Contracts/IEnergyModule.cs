using CosmosX.Entities.Modules.Contracts;

namespace CosmosX.Entities.Modules.Energy.Contracts
{
    public interface IEnergyModule : IModule
    {
        int EnergyOutput { get; }
    }
}