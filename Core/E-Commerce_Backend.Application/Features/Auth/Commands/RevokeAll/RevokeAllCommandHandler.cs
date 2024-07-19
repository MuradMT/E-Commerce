using E_Commerce_Backend.Application.Bases;
using E_Commerce_Backend.Application.Interfaces.AutoMapper;
using E_Commerce_Backend.Application.UnitOfWorks;
using E_Commerce_Backend.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_Backend.Application.Features.Auth.Commands.RevokeAll;

public class RevokeAllCommandHandler:BaseHandler,IRequestHandler<RevokeAllCommandRequest,Unit>
{
    private readonly UserManager<User> _userManager;
    public RevokeAllCommandHandler(UserManager<User> userManager,IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor context) : base(unitOfWork, mapper, context)
    {
        _userManager = userManager;
    }

    public async Task<Unit> Handle(RevokeAllCommandRequest request, CancellationToken cancellationToken)
    {
        var users = await _userManager.Users.ToListAsync(cancellationToken);
        foreach (var user in users)
        {
            user.RefreshToken = null;
            await _userManager.UpdateAsync(user);
        }

        return Unit.Value;
    }
}