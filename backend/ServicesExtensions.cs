using System.Text;
using backend.Models;
using backend.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace backend;

public static class ServicesExtensions
{
    
    public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BackendContext>(optionsAction =>
            optionsAction.UseMySql(configuration.GetConnectionString("Default"),
                ServerVersion.AutoDetect(configuration.GetConnectionString("Default")))
        );
    }
    public static void ConfigureIdentity(this IServiceCollection services)
    {
        IdentityBuilder builder = services.AddIdentityCore<User>(o =>
        {
            o.Password.RequireDigit = true;
            o.Password.RequireLowercase = false;
            o.Password.RequireUppercase = false;
            o.Password.RequireNonAlphanumeric = false;
            o.Password.RequiredLength = 10;
            o.User.RequireUniqueEmail = true;
        });
        builder = new IdentityBuilder(builder.UserType, typeof(IdentityRole),
            builder.Services);
        builder.AddEntityFrameworkStores<BackendContext>()
            .AddDefaultTokenProviders();
    }
    
    public static void ConfigureJwt
        (this IServiceCollection services, IConfiguration configuration)
    {
        JwtConfiguration jwtConfiguration = new JwtConfiguration();
        configuration.Bind(jwtConfiguration.Section, jwtConfiguration);
        
        string? secretKey = jwtConfiguration.SecretKey;
        services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtConfiguration.ValidIssuer,
                    ValidAudience = jwtConfiguration.ValidAudience,
                    IssuerSigningKey = new
                        SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                };
            });
    }
    
    public static void AddJwtConfiguration
        (this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtConfiguration>(configuration.GetSection("JwtSettings"));
    }
}