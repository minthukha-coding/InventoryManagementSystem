using InventoryManagementSystemApi.DbService.Model;
using InventoryManagementSystemApi.Features.InventoryCategory;
using InventoryManagementSystemApi.Features.InventoryItem;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystemAPI
{
    public static class ModularService
    {
        public static IServiceCollection AddServices(this IServiceCollection services, WebApplicationBuilder builder)
        {
            services.AddAppDbContextService(builder);
            services.AddDataAccessServices();
            services.AddBusinessLogicServices();
            return services;
        }

        private static IServiceCollection AddAppDbContextService(this IServiceCollection services,
            WebApplicationBuilder builder)
        {
            //services.AddDbContext<AppDbContext>(
            //    opt => { opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")); },
            //    ServiceLifetime.Scoped); 

            services.AddDbContext<AppDbContext>(
                opt => { opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection") ?? throw new InvalidOperationException("connectionString is null")); },
                ServiceLifetime.Scoped);

            return services;
        }

        private static IServiceCollection AddBusinessLogicServices(this IServiceCollection services)
        {
            services.AddScoped<BL_InventoryItem>();
            services.AddScoped<BL_InventoryCategory>();
            return services;
        }

        private static IServiceCollection AddDataAccessServices(this IServiceCollection services)
        {
            services.AddScoped<DL_InventoryItem>();
            services.AddScoped<DL_InventoryCategory>();
            return services;
        }
    }
}