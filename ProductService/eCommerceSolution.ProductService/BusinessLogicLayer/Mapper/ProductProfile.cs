using AutoMapper;
using BusinessLogicLayer.DTOs;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Mapper;

public class ProductProfile : Profile  
{
    public ProductProfile()
    {
        CreateMap<Product, ProductDTO>().ReverseMap();
        CreateMap<CreateProductDTO, Product>().ReverseMap();
    }
}