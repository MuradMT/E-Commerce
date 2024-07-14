using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using E_Commerce_Backend.Application.Interfaces.Tokens;
using E_Commerce_Backend.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace E_Commerce_Backend.Infrastructure.Tokens;

public class TokenService:ITokenService
{
    private readonly UserManager<User> _userManager;
    private readonly TokenSettings _settings;
    public TokenService(IOptions<TokenSettings> options,UserManager<User> userManager)
    {
        _settings = options.Value;
        _userManager = userManager;
    }
    public async Task<JwtSecurityToken> CreateToken(User user, IList<string> roles)
    {
        var claims = new List<Claim>()
        {
            new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email,user.Email)
        };
        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role,role));
        }

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.Secret));
        var token = new JwtSecurityToken(
            issuer:_settings.Issuer,
            audience:_settings.Audience,
            expires: DateTime.Now.AddMinutes(_settings.TokenValidityInMinutes),
            claims:claims,
            signingCredentials:new SigningCredentials(key,SecurityAlgorithms.HmacSha256));

        await _userManager.AddClaimsAsync(user, claims);

        return token;
    }

    public string GenerateRefreshToken()
    {
        throw new NotImplementedException();
    }

    public ClaimsPrincipal? GetPrincipalFromExpiredToken()
    {
        throw new NotImplementedException();
    }
}