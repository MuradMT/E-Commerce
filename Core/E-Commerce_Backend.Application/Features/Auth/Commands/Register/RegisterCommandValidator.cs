using FluentValidation;

namespace E_Commerce_Backend.Application.Features.Auth.Commands.Register;

public class RegisterCommandValidator:AbstractValidator<RegisterCommandRequest>
{
    public RegisterCommandValidator()
    {
        RuleFor(x => x.FullName)
            .NotEmpty()
            .MaximumLength(50)
            .MinimumLength(2)
            .WithName("Name Surname");

        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress()
            .MaximumLength(60)
            .MinimumLength(8)
            .WithName("Email Address");

        RuleFor(x => x.Password)
            .NotEmpty()
            .MinimumLength(6)
            .WithName("Password");
        
        RuleFor(x => x.ConfirmPassword)
            .NotEmpty()
            .MinimumLength(6)
            .Equal(x=>x.Password)
            .WithName("Confirm Password");
    }
}