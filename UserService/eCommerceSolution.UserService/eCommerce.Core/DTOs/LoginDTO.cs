namespace eCommerce.Core.DTOs;

public class LoginDTO
{
    public string Email { get; set; }
    public string Password { get; set; }
}

public record LoginRequest(string? Email, string? Password);