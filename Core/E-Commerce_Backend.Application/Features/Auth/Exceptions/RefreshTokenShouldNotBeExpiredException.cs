using E_Commerce_Backend.Application.Bases;
using E_Commerce_Backend.Application.Constants;

namespace E_Commerce_Backend.Application.Features.Auth.Exceptions;

public class RefreshTokenShouldNotBeExpiredException:BaseExceptions
{
    public RefreshTokenShouldNotBeExpiredException():base(AuthMessages.Should_Not_Be_Expired)
    {
        
    }
}