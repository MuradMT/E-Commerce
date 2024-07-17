using E_Commerce_Backend.Application.Bases;
using E_Commerce_Backend.Application.Features.Auth.Exceptions;
using E_Commerce_Backend.Domain.Entities;

namespace E_Commerce_Backend.Application.Features.Auth.Rules;

public class AuthRules:BaseRules
{
    public Task UserShouldNotBeExist(User? user)
    {
        if (user is not null) throw new UserAlreadyExistsException();
        return Task.CompletedTask;
    }

    public Task EmailOrPasswordShouldNotBeInvalid(User? user, bool checkPassword)
    {
        if (user is null || !checkPassword) throw new EmailOrPasswordShouldNotBeInvalidException();
        return Task.CompletedTask;
    }
}