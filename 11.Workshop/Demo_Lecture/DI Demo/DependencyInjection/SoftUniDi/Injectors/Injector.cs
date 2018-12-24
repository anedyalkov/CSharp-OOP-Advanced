using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using SoftUniDi.Attributes;
using SoftUniDi.Modules.Contracts;

namespace SoftUniDi.Injectors
{
    public class Injector
    {
        private readonly IModule module;

        public Injector(IModule module)
        {
            this.module = module;
        }

        public TClass Inject<TClass>()
        {
            var hasConstructorAttribute = this.CheckFoConstructorInjection<TClass>();
            var hasFieldAttribute = this.CheckForFieldInjection<TClass>();

            if (hasConstructorAttribute && hasFieldAttribute)
            {
                throw new ArgumentException("There must be only field or constructor annotated with Inject attribute");
            }

            if (hasConstructorAttribute)
            {
                return this.CreateConstructorInjection<TClass>();
            }

            if (hasFieldAttribute)
            {
                return this.CreateFieldInjection<TClass>();
            }

            return default(TClass);
        }

        private TClass CreateConstructorInjection<TClass>()
        {
            var desireClass = typeof(TClass);

            if (desireClass == null)
            {
                return default(TClass);
            }

            var constructors = desireClass.GetConstructors();

            int i = 0;

            foreach (var constructorInfo in constructors)
            {
                if (!CheckFoConstructorInjection<TClass>())
                {
                    continue;
                }

                var inject = constructorInfo.GetCustomAttributes<InjectAttribute>(true)
                    .FirstOrDefault();

                var parameterTypes = constructorInfo.GetParameters();
                var constructorParams = new object[parameterTypes.Length];

                foreach (var parameterInfo in parameterTypes)
                {
                    var named = parameterInfo.GetCustomAttribute<NamedAttribute>();
                    Type dependency = null;

                    if (named == null)
                    {
                        dependency = this.module.GetMapping(parameterInfo.ParameterType, inject);
                    }
                    else
                    {
                        dependency = this.module.GetMapping(parameterInfo.ParameterType, named);
                    }

                    if (parameterInfo.ParameterType.IsAssignableFrom(dependency))
                    {
                        var instance = this.module.GetInstance(dependency);

                        if (instance == null)
                        {
                            instance = Activator.CreateInstance(dependency);
                            constructorParams[i++] = instance;
                            this.module.SetInstance(parameterInfo.ParameterType, instance);
                        }
                        else
                        {
                            constructorParams[i++] = instance;
                        }
                    }
                }

                return (TClass)Activator.CreateInstance(desireClass, constructorParams);
            }

            return default(TClass);
        }

        private TClass CreateFieldInjection<TClass>()
        {
            var desireClass = typeof(TClass);
            var desireClassInstance = this.module.GetInstance(desireClass);

            if (desireClassInstance == null)
            {
                desireClassInstance = Activator.CreateInstance(desireClass);
                this.module.SetInstance(desireClass, desireClassInstance);
            }

            var fields = desireClass.GetFields((BindingFlags)62);

            foreach (var fieldInfo in fields)
            {
                if (fieldInfo.GetCustomAttributes<InjectAttribute>(true).Any())
                {
                    var injection = fieldInfo
                        .GetCustomAttributes<InjectAttribute>(true).FirstOrDefault();
                    Type dependency = null;

                    var named = fieldInfo.GetCustomAttribute<NamedAttribute>(true);
                    var type = fieldInfo.FieldType;

                    if (named == null)
                    {
                        dependency = this.module.GetMapping(type, injection);
                    }
                    else
                    {
                        dependency = this.module.GetMapping(type, named);
                    }

                    if (type.IsAssignableFrom(dependency))
                    {
                        var instance = this.module.GetInstance(dependency);

                        if (instance == null)
                        {
                            instance = Activator.CreateInstance(dependency);
                            this.module.SetInstance(dependency, instance);
                        }

                        fieldInfo.SetValue(desireClassInstance, instance);
                    }
                }           
            }
            return (TClass)desireClassInstance;
        }

        private bool CheckForFieldInjection<TClass>()
        {
            return typeof(TClass).GetFields((BindingFlags) 62)
                .Any(c => c.GetCustomAttributes<InjectAttribute>(true).Any());
        }

        private bool CheckFoConstructorInjection<TClass>()
        {
            return typeof(TClass).GetConstructors((BindingFlags)62)
                .Any(c => c.GetCustomAttributes<InjectAttribute>(true).Any());
        }
    }
}
