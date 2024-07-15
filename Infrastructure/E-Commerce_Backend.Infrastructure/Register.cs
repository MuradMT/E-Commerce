using System.Text;
using E_Commerce_Backend.Application.Interfaces.Tokens;
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

        services.AddTransient<ITokenService, ITokenService>();

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
    }
}