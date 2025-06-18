using Dapper;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;

namespace eCommerce.Infrastructure.Repositories;

public class UserRepository(DapperDbContext context) : IUsersRepository
{
    public async Task<ApplicationUser?> AddUser(ApplicationUser user)
    {
        user.Id = Guid.NewGuid();
        var query =
            "INSERT INTO public.\"Users\"(\"Id\", \"Email\", \"Name\", \"Gender\", \"Password\") VALUES(@Id, @Email, @Name, @Gender, @Password)";
        var result = await context.DbConnection.ExecuteAsync(query, user);
        if (result > 0)
        {
            return user;
        }

        return null;
    }


    public async Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password)
    {
        var query = "SELECT * FROM public.\"Users\" WHERE  \"Email\" = @Email and \"Password\" = @Password";
        var parameters = new { Email = email, Password = password };
        var result = await context.DbConnection.QueryFirstOrDefaultAsync<ApplicationUser>(query, parameters);
        return result;
    }
}