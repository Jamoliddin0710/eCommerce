using eCommerce.Core.Enums;

namespace eCommerce.Core.DTOs;

public class RegisterDTO
{
    public string Email { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
    public GenderOption GenderOption { get; set; }
}

public record RegisterRequest(string? Email, string? Name, string? Password, GenderOption? Gender);
