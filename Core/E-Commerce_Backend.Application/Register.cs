using System.Globalization;
using System.Reflection;
using E_Commerce_Backend.Application.Bases;
using E_Commerce_Backend.Application.Behaviors;
using E_Commerce_Backend.Application.Exceptions;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace E_Commerce_Backend.Application;

public static class Register
{
    public static void AddApplication(this IServiceCollection services)
    {

        var assembly = Assembly.GetExecutingAssembly();
        services.AddTransient<ExceptionMiddleware>();

        services.AddRulesFromAssemblyContaining(assembly, typeof(BaseRules));

        services.AddMediatR(cfg => { cfg.RegisterServicesFromAssembly(assembly); });

        services.AddValidatorsFromAssembly(assembly);

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationBehaviour<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RedisCacheBehavior<,>));

        //Code below helps us to change the custom language of validation
        //ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("tr");
    }

    private static IServiceCollection AddRulesFromAssemblyContaining(this IServiceCollection services,
        Assembly assembly,Type type)
    {
        var types = assembly.GetTypes().Where(t=>t.IsSubclassOf(type)&&type!=t).ToList();

        foreach (var item in types)
        {
            services.AddTransient(item);
        }

        return services;
    }

}
