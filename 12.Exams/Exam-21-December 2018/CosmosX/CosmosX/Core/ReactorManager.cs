using System.Collections.Generic;
using System.Linq;
using CosmosX.Core.Contracts;
using CosmosX.Entities.CommonContracts;
using CosmosX.Entities.Containers;
using CosmosX.Entities.Containers.Contracts;
using CosmosX.Entities.Modules.Absorbing;
using CosmosX.Entities.Modules.Absorbing.Contracts;
using CosmosX.Entities.Modules.Contracts;
using CosmosX.Entities.Modules.Energy;
using CosmosX.Entities.Modules.Energy.Contracts;
using CosmosX.Entities.Reactors;
using CosmosX.Entities.Reactors.Contracts;
using CosmosX.Entities.Reactors.ReactorFactory.Contracts;
using CosmosX.Utils;

namespace CosmosX.Core
{
    public class ReactorManager : IManager
    {
        private int currentId;
        private readonly IDictionary<int, IIdentifiable> identifiableObjects;
        private readonly IDictionary<int, IReactor> reactors;
        private readonly IDictionary<int, IModule> modules;
        private IReactorFactory reactorFactory;

        public ReactorManager(IReactorFactory reactorFactory)
        {
            this.currentId = Constants.StartingId;
            this.identifiableObjects = new Dictionary<int, IIdentifiable>();
            this.reactors = new Dictionary<int, IReactor>();
            this.modules = new Dictionary<int, IModule>();
            this.reactorFactory = reactorFactory;
        }

        public string ReactorCommand(IList<string> arguments)
        {
            string reactorType = arguments[0];
            int additionalParameter = int.Parse(arguments[1]);
            int moduleCapacity = int.Parse(arguments[2]);

            IContainer container = new ModuleContainer(moduleCapacity);

            IReactor reactor = null;

            switch (reactorType)
            {
                case "Cryo":
                    //reactor = new CryoReactor(this.currentId, container, additionalParameter);
                    reactor = reactorFactory.CreateReactor(reactorType, this.currentId, container, additionalParameter);
                    break;
                case "Heat":
                    //reactor = new HeatReactor(this.currentId, container, additionalParameter);
                    reactor = reactorFactory.CreateReactor(reactorType, this.currentId, container, additionalParameter);
                    break;
            }

            this.currentId++;

            this.reactors.Add(reactor.Id, reactor);
            this.identifiableObjects.Add(reactor.Id, reactor);

            string result = string.Format(Constants.ReactorCreateMessage, reactorType, reactor.Id);
            return result;
        }

        public string ModuleCommand(IList<string> arguments)
        {
            int reactorId = int.Parse(arguments[0]);
            string moduleType = arguments[1];
            int additionalParameter = int.Parse(arguments[2]);

            switch (moduleType)
            {
                case "CryogenRod":
                    IEnergyModule cryogenRod = new CryogenRod(this.currentId, additionalParameter);
                    this.reactors[reactorId].AddEnergyModule(cryogenRod);
                    this.identifiableObjects.Add(cryogenRod.Id, cryogenRod);
                    this.modules.Add(cryogenRod.Id, cryogenRod);
                    break;
                case "HeatProcessor":
                    IAbsorbingModule heatProcessor = new HeatProcessor(this.currentId, additionalParameter);
                    this.reactors[reactorId].AddAbsorbingModule(heatProcessor);
                    this.identifiableObjects.Add(heatProcessor.Id, heatProcessor);
                    this.modules.Add(heatProcessor.Id, heatProcessor);
                    break;
                case "CooldownSystem":
                    IAbsorbingModule cooldownSystem = new CooldownSystem(this.currentId, additionalParameter);
                    this.reactors[reactorId].AddAbsorbingModule(cooldownSystem);
                    this.identifiableObjects.Add(cooldownSystem.Id, cooldownSystem);
                    this.modules.Add(cooldownSystem.Id, cooldownSystem);
                    break;
            }


            string result = string.Format(Constants.ModuleCreateMessage, moduleType, this.currentId++, reactorId);
            return result;
        }

        public string ReportCommand(IList<string> arguments)
        {
            int id = int.Parse(arguments[0]);
            var reactorOrModule = identifiableObjects.FirstOrDefault(r => r.Key == id);

            return reactorOrModule.Value.ToString();
        }

        public string ExitCommand(IList<string> arguments)
        {
            long cryoReactorCount = this.reactors
                .Values
                .Count(r => r.GetType().Name == nameof(CryoReactor));

            long heatReactorCount = this.reactors
                .Values
                .Count(r => r.GetType().Name == nameof(HeatReactor));

            long energyModulesCount = this.modules
                .Values
                .Count(m => m is IEnergyModule);

            long absorbingModulesCount = this.modules
                .Values
                .Count(m => m is IAbsorbingModule);

            long totalEnergyOutput = this.reactors
                .Values
                .Sum(r => r.TotalEnergyOutput);

            long totalHeatAbsorbing = this.reactors
                .Values
                .Sum(r => r.TotalHeatAbsorbing);

            string result = $"Cryo Reactors: {cryoReactorCount}\n" +                         
                            $"Heat Reactors: {heatReactorCount}\n" +              
                            $"Energy Modules: {energyModulesCount}\n" +                      
                            $"Absorbing Modules: {absorbingModulesCount}\n" +           
                            $"Total Energy Output: {totalEnergyOutput}\n" +
                            $"Total Heat Absorbing: {totalHeatAbsorbing}\n";

            return result;
        }
    }
}