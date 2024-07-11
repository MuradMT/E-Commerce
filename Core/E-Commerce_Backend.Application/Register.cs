using System.Reflection;
using E_Commerce_Backend.Application.Exceptions;
using Microsoft.Extensions.DependencyInjection;

namespace E_Commerce_Backend.Application;

public static class Register
{
    public static void AddApplication(this IServiceCollection services){

        var assembly=Assembly.GetExecutingAssembly();
        services.AddTransient<ExceptionMiddleware>();

        services.AddMediatR(cfg=>{
             cfg.RegisterServicesFromAssembly(assembly);
        });

    }
}
