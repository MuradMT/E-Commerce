using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace E_Commerce_Backend.Infrastructure;

public static class Register
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<TokenSettings>(configuration.GetSection("JWT"));
    }
}