using CosmosX.Entities.Modules.Contracts;

namespace CosmosX.Entities.Modules.Absorbing.Contracts
{
    public interface IAbsorbingModule : IModule
    {
        int HeatAbsorbing { get; }
    }
}