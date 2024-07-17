namespace E_Commerce_Backend.Application.Features.Auth.Commands.Login;

public class LoginCommandResponse
{
    public string Token { get; set; }
    public string RefreshToken { get; set; }
    public DateTime Expiration { get; set; }
}