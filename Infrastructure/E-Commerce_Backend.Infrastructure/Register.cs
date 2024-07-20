using System.Text;
using E_Commerce_Backend.Application.Interfaces.RedisCache;
using E_Commerce_Backend.Application.Interfaces.Tokens;
using E_Commerce_Backend.Infrastructure.RedisCache;
using E_Commerce_Backend.Infrastructure.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;


namespace E_Commerce_Backend.Infrastructure;

public static class Register
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<TokenSettings>(configuration.GetSection("JWT"));

        services.Configure<RedisCacheSettings>(configuration.GetSection("RedisCacheSettings"));

        services.AddTransient<ITokenService, TokenService>();
        services.AddTransient<IRedisCacheService,RedisCacheService>();

        services.AddAuthentication(opt =>
        {
            opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opt =>
        {
            opt.SaveToken = true;
            opt.TokenValidationParameters=new TokenValidationParameters()
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidIssuer = configuration["JWT:Issuer"],
                ValidAudience = configuration["JWT:Audience"],
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"])),
                ValidateLifetime = false,
                ClockSkew = TimeSpan.Zero
            };
        });

        services.AddStackExchangeRedisCache(opt =>
        {
            opt.Configuration = configuration["RedisCacheSettings:ConnectionString"];
            opt.InstanceName = configuration["RedisCacheSettings:InstanceName"];
        });
    }
}