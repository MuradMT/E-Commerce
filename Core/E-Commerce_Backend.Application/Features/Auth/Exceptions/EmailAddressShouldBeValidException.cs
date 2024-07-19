using E_Commerce_Backend.Application.Bases;
using E_Commerce_Backend.Application.Constants;

namespace E_Commerce_Backend.Application.Features.Auth.Exceptions;

public class EmailAddressShouldBeValidException:BaseExceptions
{
    public EmailAddressShouldBeValidException():base(AuthMessages.Should_Be_Valid)
    {
        
    }
}