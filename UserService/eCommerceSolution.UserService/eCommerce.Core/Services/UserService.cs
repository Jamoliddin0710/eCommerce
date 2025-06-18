using eCommerce.Core.DTOs;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Core.ServiceContracts;

namespace eCommerce.Core.Services;

public class UserService(IUsersRepository repository) : IUserService
{
    public async Task<AuthResponse?> Login(LoginRequest loginRequest)
    {
        if (loginRequest is null)
            return null;
        var user = await repository.GetUserByEmailAndPassword(loginRequest.Email, loginRequest.Password);
        return new AuthResponse()
        {
        };
    }

    public async Task<AuthResponse?> Register(RegisterRequest registerRequest)
    {
        if (registerRequest is null) return null;

        var entity = new ApplicationUser()
        {
            Email = registerRequest.Email,
            Password = registerRequest.Password,
            Gender = registerRequest.Gender,
            Name = registerRequest.Name,
        };

        await repository.AddUser(entity);
        return new AuthResponse();
    }
}