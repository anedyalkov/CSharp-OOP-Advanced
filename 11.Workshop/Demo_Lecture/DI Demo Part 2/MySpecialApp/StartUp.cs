using System;
using Microsoft.Extensions.DependencyInjection;
//using SoftUniDependencyInjection.Part2;
using MySpecialApp.Core;
using MySpecialApp.Core.Contracts;
using MySpecialApp.Models;
using MySpecialApp.Models.Contracts;

namespace MySpecialApp
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var serviceProvider = ConfigureServices();

            //Custom DI
            //var engine = serviceProvider.CreateInstance<Engine>();

            var engine = serviceProvider.GetService<Engine>();
            engine.Run();
        }


        //Custom DI
        //private static IServiceCollection ConfigureServices()
        //{
        //    IServiceCollection serviceCollection = new ServiceCollection();

        //    serviceCollection.AddService<IEngine, Engine>();
        //    serviceCollection.AddService<IWriter, ConsoleWriter>();
        //    serviceCollection.AddService<IWriter, FileWriter>();
        //    serviceCollection.AddService<IReader, ConsoleReader>();

        //    return serviceCollection;
        //}

        private static IServiceProvider ConfigureServices()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddTransient<IEngine, Engine>();
            serviceCollection.AddTransient<IWriter, ConsoleWriter>();
            serviceCollection.AddTransient<IWriter, FileWriter>();
            serviceCollection.AddTransient<IReader, ConsoleReader>();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            return serviceProvider;
        }
    }
}
