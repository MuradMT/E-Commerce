using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using E_Commerce_Backend.Domain.Entities;

namespace E_Commerce_Backend.Application.Interfaces.Tokens;

public interface ITokenService
{
    Task<JwtSecurityToken> CreateToken(User user,IList<string> roles);
    string GenerateRefreshToken();
    ClaimsPrincipal? GetPrincipalFromExpiredToken();
}