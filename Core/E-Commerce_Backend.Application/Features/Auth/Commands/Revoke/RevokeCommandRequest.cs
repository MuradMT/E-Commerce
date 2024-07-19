using MediatR;

namespace E_Commerce_Backend.Application.Features.Auth.Commands.Revoke;

public class RevokeCommandRequest:IRequest<Unit>
{
    public string Email { get; set; }
}