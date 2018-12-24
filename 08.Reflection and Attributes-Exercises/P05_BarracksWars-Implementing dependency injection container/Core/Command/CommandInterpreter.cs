namespace P03_BarraksWars.Core.Command
{
    using _03BarracksFactory.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class CommandInterpreter : ICommandInterpreter
    {
        private IServiceProvider serviceProvider;

        public CommandInterpreter(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }
        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            Type commandType = assembly.GetTypes().FirstOrDefault(t => t.Name.ToLower() == commandName + "command");

            var fieldsToInject = commandType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(f => f.CustomAttributes.Any(ca => ca.AttributeType == typeof(InjectAttribute))).ToArray();

            var injectArgs = fieldsToInject.Select(f => serviceProvider.GetService(f.FieldType)).ToArray();

            var constrArgs = new object[] { data }.Concat(injectArgs).ToArray();

            var commandInstance = (IExecutable)Activator.CreateInstance(commandType, constrArgs);

            return commandInstance;
        }
    }
}
