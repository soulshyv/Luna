using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace Luna.Commons.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        ///     Adds an implementation as its implemented interfaces (like Autofac's AsImplementedInterfaces)
        /// </summary>
        public static IServiceCollection AddScopedAsInterfaces<TType>(this IServiceCollection serviceCollection)
        {
            var implementationType = typeof(TType);
            var interfaces = GetImplementedInterfaces(implementationType);

            foreach (var implementedInterface in interfaces)
            {
                serviceCollection.AddScoped(implementedInterface, implementationType);
            }

            return serviceCollection;
        }

        private static Type[] GetImplementedInterfaces(Type type)
        {
            var interfaces = type.GetInterfaces().Where(i => i != typeof(IDisposable));
            return type.IsInterface ? interfaces.Append(type).ToArray() : interfaces.ToArray();
        }
    }
}