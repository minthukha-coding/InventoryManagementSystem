using InventoryManagementSystemApi.Shared.Service;

namespace InventoryManagementSystemApi;

public static class ModularService
{
    public static IServiceCollection AddServices(this IServiceCollection services, WebApplicationBuilder builder)
    {
        services.AddAppDbContextService(builder);
        services.AddDataAccessServices(builder.Configuration);
        services.AddBusinessLogicServices();
        services.AddJwtAuthorization(builder.Configuration);
        return services;
    }

    private static IServiceCollection AddAppDbContextService(this IServiceCollection services,
        WebApplicationBuilder builder)
    {
        services.AddDbContext<AppDbContext>(
            opt =>
            {
                opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection") ??
                                 throw new InvalidOperationException("connectionString is null"));
            },
            ServiceLifetime.Transient,
            ServiceLifetime.Transient);

        return services;
    }

    private static IServiceCollection AddDataAccessServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped<DA_Category>();
        services.AddSingleton(configuration);
        services.AddSingleton<JwtSecurityTokenHandler>();
        services.AddScoped<JwtTokenService>();
        services.AddScoped<DA_Authenation>();
        return services;
    }

    private static IServiceCollection AddBusinessLogicServices(this IServiceCollection services)
    {
        services.AddScoped<BL_Authenation>();
        services.AddScoped<Bl_Category>();
        return services;
    }

    private static IServiceCollection AddJwtAuthorization(this IServiceCollection services , IConfiguration _configuration)
    {
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
                    IssuerSigningKey =  new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        services.AddAuthorization();
        return services;
    }
}