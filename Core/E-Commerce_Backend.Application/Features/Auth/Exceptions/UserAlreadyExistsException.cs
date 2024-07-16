using E_Commerce_Backend.Application.Bases;
using E_Commerce_Backend.Application.Constants;

namespace E_Commerce_Backend.Application.Features.Auth.Exceptions;

public class UserAlreadyExistsException:BaseExceptions
{
    public UserAlreadyExistsException():base(AuthMessages.Already_Exists)
    {
        
    }
}