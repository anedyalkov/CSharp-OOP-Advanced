using CosmosX.Entities.Containers.Contracts;

namespace CosmosX.Entities.Reactors
{
    public class CryoReactor : BaseReactor
    {
        public CryoReactor(int id, IContainer moduleContainer, int cryoProductionIndex)
            : base(id, moduleContainer)
        {
            this.CryoProductionIndex = cryoProductionIndex;
        }

        public int CryoProductionIndex { get; }

        public override long TotalEnergyOutput
        {
            get
            {
                long totalEnergyFromModules = base.TotalEnergyOutput * this.CryoProductionIndex;

                if (totalEnergyFromModules > base.TotalHeatAbsorbing)
                {
                    totalEnergyFromModules = 0;
                }

                return totalEnergyFromModules;
            }
        }
    }
}