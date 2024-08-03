using InventoryManagementSystemApi.DbService.Db;
using InventoryManagementSystemApi.Features.Category;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystemApi;

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
        services.AddScoped<Bl_Category>();
        return services;
    }

    private static IServiceCollection AddDataAccessServices(this IServiceCollection services)
    {
        services.AddScoped<DA_Category>();
        return services;
    }
}