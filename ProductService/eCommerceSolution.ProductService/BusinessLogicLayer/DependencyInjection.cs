using BusinessLogicLayer.ServiceContracts;
using BusinessLogicLayer.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogicLayer;

public static class DependencyInjection
{
    public static IServiceCollection AddBusinessLogicLayer(this IServiceCollection services)
    {
        services.AddTransient<IProductService, ProductService>();
        return services;
    }
}