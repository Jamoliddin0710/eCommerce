using DataAccessLayer;
using Microsoft.EntityFrameworkCore;

namespace APILayer.Extensions
{
    public static class WebApplicationBuilderExtension
    {
        public static IServiceCollection AddConfigurationService(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            return services;
        }
    }
}
