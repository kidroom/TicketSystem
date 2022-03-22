using Microsoft.Extensions.DependencyInjection;
using Repository.Repositories;
using TicketSystem.Service;

namespace TicketSystem.Extensions
{
    public static class FeatureServicesExtensions
    {
        // Use this method to add Features to service container.
        public static IServiceCollection AddFeatureServices(this IServiceCollection services)
        {
            // Repository
            services.AddScoped<ITicketRepository, TicketRepository>();

            // Service
            services.AddScoped<ITicketService, TicketService>();

            return services;
        }
    }
}
