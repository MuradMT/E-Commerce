using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using SendGrid.Helpers.Errors.Model;

namespace E_Commerce_Backend.Application.Exceptions;

public class ExceptionMiddleware : IMiddleware
{
    //reformatting code in Rider-alt+shift+f
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        int statusCode = GetStatusCode(exception);
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = statusCode;

        if (exception.GetType() == typeof(FluentValidation.ValidationException))
        {
            await context.Response.WriteAsync(new ExceptionModel()
            {
                Errors = ((FluentValidation.ValidationException)exception).Errors.Select(x=>x.ErrorMessage),
                StatusCode = StatusCodes.Status400BadRequest
            }.ToString());
        }

        List<string> errors = new()
        {
            $"Error Message: {exception.Message}",
            $"Meesage Description: {exception.InnerException.ToString()}"
        };
        await context.Response.WriteAsync(new ExceptionModel()
        {
            Errors = errors,
            StatusCode = statusCode
        }.ToString());
    }

    private static int GetStatusCode(Exception exception) =>
        exception switch
        {
            BadRequestException => StatusCodes.Status400BadRequest,
            NotFoundException => StatusCodes.Status404NotFound,
            ValidationException => StatusCodes.Status422UnprocessableEntity,
            _ => StatusCodes.Status500InternalServerError
        };
}