using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using E_Commerce_Backend.Application.Bases;
using E_Commerce_Backend.Application.Features.Auth.Rules;
using E_Commerce_Backend.Application.Interfaces.AutoMapper;
using E_Commerce_Backend.Application.Interfaces.Tokens;
using E_Commerce_Backend.Application.UnitOfWorks;
using E_Commerce_Backend.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace E_Commerce_Backend.Application.Features.Auth.Commands.RefreshToken;

public class RefreshTokenCommandHandler:BaseHandler,IRequestHandler<RefreshTokenCommandRequest,RefreshTokenCommandResponse>
{
    private readonly UserManager<User> _userManager;
    private readonly ITokenService _tokenService;
    private readonly AuthRules _rules;
    public RefreshTokenCommandHandler(AuthRules rules,ITokenService tokenService,UserManager<User> userManager,IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor context) : base(unitOfWork, mapper, context)
    {
        _userManager = userManager;
        _tokenService = tokenService;
        _rules = rules;
    }

    public async Task<RefreshTokenCommandResponse> Handle(RefreshTokenCommandRequest request, CancellationToken cancellationToken)
    {
        ClaimsPrincipal? principal = _tokenService.GetPrincipalFromExpiredToken(request.AccessToken);

        string email = principal.FindFirstValue(ClaimTypes.Email);

        User? user = await _userManager.FindByEmailAsync(email);
        IList<string> roles = await _userManager.GetRolesAsync(user);

        await _rules.RefreshTokenShouldNotBeExpired(user.RefreshTokenExpireTime);

        JwtSecurityToken newAccessToken = await _tokenService.CreateToken(user, roles);
        string newRefreshToken = _tokenService.GenerateRefreshToken();

        user.RefreshToken = newRefreshToken;
        await _userManager.UpdateAsync(user);

        return new()
        {
               AccessToken = new JwtSecurityTokenHandler().WriteToken(newAccessToken),
               RefreshToken = newRefreshToken
        };
    }
}