using FluentValidation;

namespace E_Commerce_Backend.Application.Features.Auth.Commands.Revoke;

public class RevokeCommandValidator:AbstractValidator<RevokeCommandRequest>
{
    public RevokeCommandValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();
    }
}