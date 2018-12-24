using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniDependencyInjection.Part2
{
    public class ServiceCollection : IServiceCollection
    {
        private readonly IDictionary<Type, Type> dependencyContainer;

        public ServiceCollection()
        {
            this.dependencyContainer = new Dictionary<Type, Type>();
        }

        public void AddService<TImplementation, TClass>()
        {
            this.dependencyContainer[typeof(TImplementation)] = typeof(TClass);
        }

        public TClass CreateInstance<TClass>()
        {
            return (TClass)this.CreateInstance(typeof(TClass));
        }

        public object CreateInstance(Type type)
        {
            if (this.dependencyContainer.ContainsKey(type))
            {
                type = this.dependencyContainer[type];
            }

            if (type.IsInterface || type.IsAbstract)
            {
                throw new Exception($"Type {type.FullName} cannot be instantiated.");
            }

            var constructor = type.GetConstructors()
                .OrderBy(x => x.GetParameters().Length)
                .FirstOrDefault();

            var constructorParameters = constructor.GetParameters();

            var constructorParameterObjects = new List<object>();

            foreach (var constructorParameter in constructorParameters)
            {
                var parameterObject = this.CreateInstance(constructorParameter.ParameterType);

                constructorParameterObjects.Add(parameterObject);
            }

            var obj = constructor.Invoke(constructorParameterObjects.ToArray());

            return obj;
        }
    }
}
