using E_Commerce_Backend.Application.Bases;
using E_Commerce_Backend.Application.Constants;
using E_Commerce_Backend.Application.Features.Auth.Rules;
using E_Commerce_Backend.Application.Interfaces.AutoMapper;
using E_Commerce_Backend.Application.UnitOfWorks;
using E_Commerce_Backend.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace E_Commerce_Backend.Application.Features.Auth.Commands.Register;

public class RegisterCommandHandler:BaseHandler,IRequestHandler<RegisterCommandRequest,Unit>
{
    private readonly AuthRules _rules;
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<Role> _roleManager;
    
    public RegisterCommandHandler(AuthRules rules,UserManager<User> userManager,RoleManager<Role> roleManager,
        IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor context) : base(unitOfWork, mapper, context)
    {
    }

    public async Task<Unit> Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
    {
        await _rules.UserShouldNotBeExist(await _userManager.FindByEmailAsync(request.Email));
        User user = _mapper.Map<User, RegisterCommandRequest>(request);
        user.UserName = request.Email;
        user.SecurityStamp = Guid.NewGuid().ToString();

        IdentityResult result = await _userManager.CreateAsync(user, request.Password);
        if (result.Succeeded)
        {
            if (!await _roleManager.RoleExistsAsync(AuthMessages.User_Role))
            {
                await _roleManager.CreateAsync(new Role()
                {
                     Id = Guid.NewGuid(),
                     Name = AuthMessages.User_Role,
                     NormalizedName = AuthMessages.User_Role.ToUpper(),
                     ConcurrencyStamp = Guid.NewGuid().ToString()
                });
            }

            await _userManager.AddToRoleAsync(user, AuthMessages.User_Role);
        }

        return Unit.Value;
    }
}