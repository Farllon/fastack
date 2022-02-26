using System.Reflection;

using MediatR;

using FaStack.Bus;
using FaStack.Bus.Abstractions;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class BusExtensions
    {
        public static IServiceCollection AddBus(this IServiceCollection services, Assembly[] assemblies)
        {
            services.AddMediatR(assemblies);

            services.AddScoped<INotificationStore, MemoryStore>();
            services.AddScoped<IBus, Bus>();

            return services;
        }
    }
}
