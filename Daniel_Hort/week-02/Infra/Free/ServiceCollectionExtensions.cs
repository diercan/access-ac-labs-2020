using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using Infra.Free;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Infrastructure.Free
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddOperations(this IServiceCollection serviceCollection, Assembly assembly)
        {
            serviceCollection.TryAddTransient(typeof(LiveInterpreterAsync));

            var types = assembly.GetTypes()
                .Where(p => typeof(IInterpreter).IsAssignableFrom(p))
                .Where(p => !p.IsGenericType)
                ;

            types.ToList().ForEach(p =>
            {
                var markerInterface = p.GetInterfaces().SingleOrDefault(r => typeof(IOp).IsAssignableFrom(r) && r.IsGenericType);
                if (markerInterface != null)
                    serviceCollection.TryAddTransient(markerInterface, p);
            });
            return serviceCollection;
        }
    }
}
