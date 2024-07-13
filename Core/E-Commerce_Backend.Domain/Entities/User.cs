using Microsoft.AspNetCore.Identity;

namespace E_Commerce_Backend.Domain.Entities;

public class User:IdentityUser<Guid>
{
    public string FullName { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpireTime { get; set; }
}