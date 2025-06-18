using eCommerce.Core.DTOs;
using eCommerce.Core.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers;

public class AuthController(IUserService service) : BaseApiController
{
    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var response = await service.Login(request);
        if (response is null || !response.Success)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        var response = await service.Register(request);
        if (response is null || !response.Success)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }
}