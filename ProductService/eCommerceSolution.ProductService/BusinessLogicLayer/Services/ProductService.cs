using AutoMapper;
using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Helper;
using BusinessLogicLayer.ServiceContracts;
using DataAccessLayer.Entities;
using DataAccessLayer.RepositoryContracts;

namespace BusinessLogicLayer.Services;

public class ProductService(IProductRepository repository, IMapper mapper) : IProductService
{
    public async Task<ProductDTO> Create(CreateProductDTO product)
    {
        var entity = mapper.Map<Product>(product);
        await repository.AddAsync(entity);
        return mapper.Map<ProductDTO>(entity);
    }

    public async Task<bool> Edit(EditProductDTO product)
    {
        var currentProduct = await repository.GetByIdAsync(product.Id);
        currentProduct.Name = product.Name;
        currentProduct.Price = product.Price;
        currentProduct.Category = product.Category;
        currentProduct.QuantityInStock = product.QuantityInStock;
        return true;
    }

    public async Task<ProductDTO> GetById(Guid id)
    {
        var result = await repository.GetByIdAsync(id);
        return mapper.Map<ProductDTO>(result);
    }

    public async Task<List<ProductDTO>> GetAll(string searchBy = null)
    {
        var filter = new Filter()
        {
            Value = searchBy,
        };

        var query= repository.GetAllQuerable().ApplyFilter(filter);
        var result = mapper.Map<List<ProductDTO>>(query);
        return result;
    }

    public async Task<bool> Delete(Guid id)
    {
        var product = await repository.GetByIdAsync(id);
        if (product is not null)
        {
            repository.Remove(product);
        }

        return true;
    }
}