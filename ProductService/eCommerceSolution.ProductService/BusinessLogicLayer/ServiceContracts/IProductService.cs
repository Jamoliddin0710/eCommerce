using BusinessLogicLayer.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BusinessLogicLayer.ServiceContracts;

public interface IProductService
{
    Task<ProductDTO> Create([FromBody]CreateProductDTO product);
    Task<bool> Edit([FromBody]EditProductDTO product);
    Task<ProductDTO> GetById(Guid id);
    Task<List<ProductDTO>> GetAll(string searchBy = null);
    Task<bool> Delete(Guid id);
}