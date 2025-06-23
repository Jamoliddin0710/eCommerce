using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.ServiceContracts;
using BusinessLogicLayer.Validators;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http.HttpResults;

namespace APILayer.APIEndpoints;

public static class ProductAPIEndpoints
{
    public static IEndpointRouteBuilder MapProductAPIEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("api/products", async (IProductService service) =>
        {
            var response = await service.GetAll();
            return Results.Ok(response);
        });

        app.MapGet("/api/products/search/product-id/{id:guid}", async (IProductService service, Guid id) =>
        {
            var response = await service.GetById(id);
            return Results.Ok(response);
        });

        app.MapGet("/api/products/search/{searchString}", async (IProductService service, string searchString) =>
        {
            var response = await service.GetAll(searchString);
            return Results.Ok(response);
        });

        app.MapPost("/api/products", async (IProductService service,
            IValidator<CreateProductDTO> validator, CreateProductDTO createProductDto) =>
        {
            ValidationResult validationResult = await validator.ValidateAsync(createProductDto);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors
                    .GroupBy(temp => temp.PropertyName)
                    .ToDictionary(grp => grp.Key,
                        grp =>
                            grp.Select(err => err.ErrorMessage).ToArray());

                return Results.ValidationProblem(errors);
            }

            var response = await service.Create(createProductDto);
            if (response != null)
            {
                return Results.Created($"/api/products/search/product-id/{response.Id}", response);
            }

            return Results.Problem("An error occured in adding product", statusCode: 400);
        });

        app.MapPut("api/products", async (IProductService service, IValidator<EditProductDTO> validator
            , EditProductDTO editProduct) =>
        {
            var validationResult = await validator.ValidateAsync(editProduct);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors
                    .GroupBy(a => a.PropertyName)
                    .ToDictionary(t
                        => t.Key, t
                        => t.Select(err => err.ErrorMessage).ToArray());

                return Results.ValidationProblem(errors);
            }

            var response = await service.Edit(editProduct);
            if (response)
            {
                return Results.Ok("Product edited successfully");
            }

            return Results.Problem("An error occured updating product", statusCode: 400);
        });
        
        app.MapDelete("api/products/{id:guid}", async (IProductService service, Guid id) =>
        {
            var response = await service.Delete(id);
            if (response)
            {
                return Results.Ok("Product deleted successfully");
            }

            return Results.Problem("An error occured deleting product");
        });

        return app;
    }
}