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
        services.AddDbContext<AppDbContext>(
            opt => { opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection") ?? throw new InvalidOperationException("connectionString is null")); },
            ServiceLifetime.Transient,
            ServiceLifetime.Transient);

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
        services.AddScoped<BL_Authenation>();
        services.AddScoped<Bl_Category>();
        return services;
    }

    private static IServiceCollection AddJwtAuthorization(this IServiceCollection services)
    {
        services.AddSwaggerGen(option =>
        {
            option.SwaggerDoc("v1", new OpenApiInfo { Title = "InventoryManagementSystem", Version = "v1" });
            option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please enter a valid token",
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Scheme = "Bearer"
            });
            option.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                       new List<string> ()
                    }
                });
        });

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