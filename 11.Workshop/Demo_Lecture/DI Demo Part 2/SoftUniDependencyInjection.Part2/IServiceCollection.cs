using System;

namespace SoftUniDependencyInjection.Part2
{
    public interface IServiceCollection
    {
        void AddService<TImplementation, TClass>();

        object CreateInstance(Type type);

        TClass CreateInstance<TClass>();
    }
}
