using CarShopApi.Application.Core;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.IoC.Application
{
    public static class ApplicationCoreModule
    {
        public static IServiceCollection AddMediatR(this IServiceCollection services)
        {
            return services.AddMediatR(typeof(MediatREntryPoint).Assembly);
        }
    }
}