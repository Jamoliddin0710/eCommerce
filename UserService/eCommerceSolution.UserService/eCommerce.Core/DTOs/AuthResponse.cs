using eCommerce.Core.Enums;

namespace eCommerce.Core.DTOs;

public record AuthResponse(
    Guid Id,
    string? Email,
    string? Name,
    GenderOption? Gender,
    string? Token,
    bool Success)
{
    //Parameterless constructor
    public AuthResponse() : this(default, default, default, default, default, default)
    {
    }  
}
    
