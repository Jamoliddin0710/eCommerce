using DataAccessLayer.Entities;
using DataAccessLayer.RepositoryContracts;

namespace DataAccessLayer.Repositories;

public class ProductRepository(AppDbContext context) : BaseRepo<Product>(context), IProductRepository
{
}