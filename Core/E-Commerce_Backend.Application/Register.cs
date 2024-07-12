using System.Globalization;
using System.Reflection;
using E_Commerce_Backend.Application.Behaviors;
using E_Commerce_Backend.Application.Exceptions;
using FluentValidation;
using MediatR;
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

        services.AddValidatorsFromAssembly(assembly);

        services.AddTransient(typeof(IPipelineBehavior<,>),typeof(FluentValidationBehaviour<,>));

        //Code below helps us to change the custom language of validation
        //ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("tr");
    }
}
