using InventoryManagementSystemApi.DbService.Db;
using InventoryManagementSystemApi.Features.Authenation;
using InventoryManagementSystemApi.Features.Category;
using InventoryManagementSystemApi.Shared;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace InventoryManagementSystemApi;

public static class ModularService
{
    public static IServiceCollection AddServices(this IServiceCollection services, WebApplicationBuilder builder)
    {
        services.AddAppDbContextService(builder);
        services.AddDataAccessServices(builder.Configuration);
        services.AddBusinessLogicServices();
        services.AddJwtAuthorization();
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

    private static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<DA_Category>();
        services.AddSingleton<IConfiguration>(configuration);
        services.AddSingleton<JwtSecurityTokenHandler>();
        services.AddScoped<JwtTokenService>();
        services.AddScoped<DA_Authenation>();
        return services;
    }

    private static IServiceCollection AddBusinessLogicServices(this IServiceCollection services)
    {
        services.AddScoped<Bl_Category>();
        services.AddScoped<BL_Authenation>();
        return services;
    }

    private static IServiceCollection AddJwtAuthorization(this IServiceCollection services)
    {
        var key = Encoding.ASCII.GetBytes("HQfsdfQ@C1"); // Use a secret key for encoding the token

        services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(x =>
        {
            x.RequireHttpsMetadata = false;
            x.SaveToken = true;
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        });
        services.AddAuthorization();
        return services;
    }
}