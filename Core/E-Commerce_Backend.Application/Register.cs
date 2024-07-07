using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace E_Commerce_Backend.Application;

public static class Register
{
    public static void AddApplication(this IServiceCollection services){

        var assembly=Assembly.GetExecutingAssembly();

        services.AddMediatR(cfg=>{
             cfg.RegisterServicesFromAssembly(assembly);
        });

    }
}
