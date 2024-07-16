using MediatR;

namespace E_Commerce_Backend.Application.Features.Auth.Commands.Register;

public class RegisterCommandRequest:IRequest<Unit>  
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
}