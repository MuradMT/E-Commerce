using System.ComponentModel;
using MediatR;

namespace E_Commerce_Backend.Application.Features.Auth.Commands.Login;

public class LoginCommandRequest:IRequest<LoginCommandResponse>
{
    [DefaultValue("mammadzade03@gmail.com")]
    public string Email { get; set; }
    [DefaultValue("123456")]
    public string Password { get; set; }
}