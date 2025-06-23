using APILayer.Filters;
using BusinessLogicLayer.Validators;
using DataAccessLayer;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace APILayer.Extensions
{
    public static class WebApplicationBuilderExtension
    {
        public static IServiceCollection AddConfigurationService(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            return services;
        }

        public static IServiceCollection AddValidatorSettings(this IServiceCollection services)
        {
            services.AddScoped(typeof(ValidationFilter<>));
            services.AddValidatorsFromAssemblyContaining<CreateProductDtoValidator>();
            return services;
        }
    }
}