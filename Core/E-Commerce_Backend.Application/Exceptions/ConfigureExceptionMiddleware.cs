using Microsoft.AspNetCore.Builder;

namespace E_Commerce_Backend.Application.Exceptions;

public static class ConfigureExceptionMiddleware
{
    public static void ConfiureExceptionHandlingMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionMiddleware>();
    }
}