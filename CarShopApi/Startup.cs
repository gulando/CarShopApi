using System.Threading;
using CarShopApi.Application.Core.Common.IRepository;
using CarShopApi.Middlewares;
using Infrastructure.IoC.Api;
using Infrastructure.IoC.Application;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace CarShopApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            services.AddDataSeedOptions(Configuration);
            
            services.AddControllers();
            services.AddMapper(Configuration);
            
            services.AddMediatR();
            services.AddSwagger();
            
            services.AddMongoDb(Configuration);
            services.AddRepositories();
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CarShopApi v1"));
            app.UseSerilogRequestLogging();

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
            
            app.ApplicationServices.GetRequiredService<IDataSeed>().SeedAllInitialDataAsync(CancellationToken.None);
        }
    }
}