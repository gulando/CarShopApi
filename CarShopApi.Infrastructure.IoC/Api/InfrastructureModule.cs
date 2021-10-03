using System;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Infrastructure.IoC.Api
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddMapper(this IServiceCollection services, IConfiguration configuration)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies()
                .Where(x => x.FullName.Contains("CarShopApi", StringComparison.InvariantCultureIgnoreCase));

            return services.AddAutoMapper(
                cfg => { cfg.AllowNullCollections = true; },
                assemblies,
                ServiceLifetime.Scoped);
        }
        
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            return services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "CarShopApi", Version = "v1"});
            });
        }
    }
}