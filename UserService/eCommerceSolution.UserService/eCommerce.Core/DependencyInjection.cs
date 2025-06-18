using eCommerce.Core.ServiceContracts;
using eCommerce.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            // Register your core services here
            // Example: services.AddSingleton<IMyCoreService, MyCoreService>();
            services.AddScoped<IUserService, UserService>();
            return services;
        }
    }
}