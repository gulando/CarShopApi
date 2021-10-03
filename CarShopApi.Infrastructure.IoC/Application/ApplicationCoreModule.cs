using CarShopApi.Application.Core;
using CarShopApi.Application.Core.IRepository;
using CarShopApi.Infrastructure.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.IoC.Application
{
    public static class ApplicationCoreModule
    {
        public static void AddMediatR(this IServiceCollection services)
        {
            services.AddMediatR(typeof(MediatREntryPoint).Assembly);
        }
        
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IWarehouseRepository, WarehouseRepository>();
        }
    }
}