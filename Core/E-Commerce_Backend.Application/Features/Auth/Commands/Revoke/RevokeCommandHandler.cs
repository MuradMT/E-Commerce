using E_Commerce_Backend.Application.Bases;
using E_Commerce_Backend.Application.Features.Auth.Rules;
using E_Commerce_Backend.Application.Interfaces.AutoMapper;
using E_Commerce_Backend.Application.UnitOfWorks;
using E_Commerce_Backend.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace E_Commerce_Backend.Application.Features.Auth.Commands.Revoke;

public class RevokeCommandHandler:BaseHandler,IRequestHandler<RevokeCommandRequest,Unit>
{
    private readonly UserManager<User> _userManager;
    private readonly AuthRules _rules;
    public RevokeCommandHandler(AuthRules rules,UserManager<User> userManager,IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor context) : base(unitOfWork, mapper, context)
    {
        _rules = rules;
        _userManager = userManager;
    }
    public async Task<Unit> Handle(RevokeCommandRequest request, CancellationToken cancellationToken)
    {
        User user = await _userManager.FindByEmailAsync(request.Email);
        await _rules.EmailAddressShouldBeValid(user);

        user.RefreshToken = null;
        _userManager.UpdateAsync(user);
        return Unit.Value;
    }
}