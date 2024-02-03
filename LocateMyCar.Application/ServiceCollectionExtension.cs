using LocateMyCar.Domain.Services;
using LocateMyCar.Domain.Services.Interfaces;
using LocateMyCar.Infra.Context;
using LocateMyCar.Infra.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.Extensions.DependencyInjection;

namespace LocateMyCar.Application
{
    public static class ServiceCollectionExtension
    {
        public static void ConfigureServicesExtension(WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")));

            ConfigureServices(builder.Services);
            ConfigureRepository(builder.Services);
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IVehicleService, VehicleService>();
        }

        private static void ConfigureRepository(IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}
