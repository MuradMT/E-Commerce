using E_Commerce_Backend.Application.Bases;
using E_Commerce_Backend.Application.Constants;

namespace E_Commerce_Backend.Application.Features.Auth.Exceptions;

public class EmailOrPasswordShouldNotBeInvalidException:BaseExceptions
{
    public EmailOrPasswordShouldNotBeInvalidException():base(AuthMessages.Should_Not_Be_Invalid)
    {
        
    }
}