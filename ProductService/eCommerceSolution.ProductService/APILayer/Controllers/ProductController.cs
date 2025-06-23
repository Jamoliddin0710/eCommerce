using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace APILayer.Controllers;

public class ProductController(IProductService service) : BaseApiController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductDTO product)
    {
        var result = await service.Create(product);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await service.GetById(id);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Edit([FromBody] EditProductDTO product)
    {
        return Ok(await service.Edit(product));
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id)
    {
        return Ok(await service.Delete(id));
    }

    [HttpGet]
    public async Task<IActionResult> GetProducts(string? search)
    {
        return Ok(await service.GetAll(search));
    }
}