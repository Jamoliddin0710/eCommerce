using eCommerce.Core.Enums;

namespace eCommerce.Core.Entities;

public class ApplicationUser : BaseGuidEntity
{
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? Name { get; set; }
    public GenderOption? Gender { get; set; }
}