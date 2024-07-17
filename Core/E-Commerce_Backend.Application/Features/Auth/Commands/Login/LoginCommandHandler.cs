using System.IdentityModel.Tokens.Jwt;
using E_Commerce_Backend.Application.Bases;
using E_Commerce_Backend.Application.Features.Auth.Rules;
using E_Commerce_Backend.Application.Interfaces.AutoMapper;
using E_Commerce_Backend.Application.Interfaces.Tokens;
using E_Commerce_Backend.Application.UnitOfWorks;
using E_Commerce_Backend.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace E_Commerce_Backend.Application.Features.Auth.Commands.Login;

public class LoginCommandHandler:BaseHandler,IRequestHandler<LoginCommandRequest,LoginCommandResponse>
{
    private readonly UserManager<User> _userManager;
    private readonly AuthRules _rules;
    private readonly RoleManager<Role> _roleManager;
    private readonly ITokenService _tokenService;
    private readonly IConfiguration _configuration;
    public LoginCommandHandler(IConfiguration configuration,ITokenService tokenService,RoleManager<Role> roleManager,AuthRules rules,UserManager<User> userManager,
        IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor context) : base(unitOfWork, mapper, context)
    {
        _configuration = configuration;
        _tokenService = tokenService;
        _roleManager = roleManager;
        _rules = rules;
        _userManager = userManager;
    }

    public async Task<LoginCommandResponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
    {
        User user = await _userManager.FindByEmailAsync(request.Email);
        bool checkPassword = await _userManager.CheckPasswordAsync(user, request.Email);

        await _rules.EmailOrPasswordShouldNotBeInvalid(user, checkPassword);

        var roles = await _userManager.GetRolesAsync(user);

        JwtSecurityToken securityToken = await _tokenService.CreateToken(user, roles);
        string refreshToken =  _tokenService.GenerateRefreshToken();

        _ = int.TryParse(_configuration["JWT:RefreshTokenValidityInDays"], out int refreshTokenValidityInDays);

        user.RefreshToken = refreshToken;
        user.RefreshTokenExpireTime = DateTime.Now.AddDays(refreshTokenValidityInDays);

        await _userManager.UpdateAsync(user);
        await _userManager.UpdateSecurityStampAsync(user);

        var token =  new JwtSecurityTokenHandler().WriteToken(securityToken);

        await _userManager.SetAuthenticationTokenAsync(user, "Default", "AccessToken", token);

        return new()
        {
           Token = token,
           RefreshToken = refreshToken,
           Expiration = securityToken.ValidTo
        };

    }
}