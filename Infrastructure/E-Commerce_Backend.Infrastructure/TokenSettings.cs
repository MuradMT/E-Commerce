namespace E_Commerce_Backend.Infrastructure;

public class TokenSettings
{
    public string Audience { get; set; }
    public string Issuer { get; set; }
    public string Secret { get; set; }
    public int TokenValidityInMinutes { get; set; }
}