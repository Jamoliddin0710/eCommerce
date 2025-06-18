using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace eCommerce.API.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
              await next(httpContext);
            }
            catch (Exception ex)
            { 
                logger.LogError($"{ex.GetType()} : Message {ex.Message}");
                if (ex.InnerException.Message != null)
                {
                    logger.LogError($"{ex.InnerException.GetType()} : Message {ex.InnerException.Message}");
                }
                httpContext.Response.StatusCode = 500;
                httpContext.Response.ContentType = "application/json";
                await httpContext.Response.WriteAsJsonAsync(new { Message = ex.Message, Type = ex.GetType().Name.ToString()});
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}
