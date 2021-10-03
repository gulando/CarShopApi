using System;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;

namespace Infrastructure.IoC.Api
{
    public static class InfrastructureModule
    {
        public static void AddMapper(this IServiceCollection services, IConfiguration configuration)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies()
                .Where(x => x.FullName.Contains("CarShopApi", StringComparison.InvariantCultureIgnoreCase));

            services.AddAutoMapper(
                cfg => { cfg.AllowNullCollections = true; },
                assemblies,
                ServiceLifetime.Scoped);
        }
        
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "CarShopApi", Version = "v1"});
            });
        }
        
        public static void AddMongoDb(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IMongoClient, MongoClient>(sp => new MongoClient(configuration.GetConnectionString("ConnectionStrings:ConnectionString")));
        }
    }
}