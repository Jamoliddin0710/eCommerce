using AutoMapper;
using eCommerce.Core.DTOs;
using eCommerce.Core.Entities;
namespace eCommerce.Core.Mappers;

public class ApplicationMappingProfile : Profile
{
    public ApplicationMappingProfile()
    {
        CreateMap<ApplicationUser, AuthResponse>()
            .ForMember(dest => dest.Email,
                opt => opt.MapFrom(src => src.Email))            .ForMember(dest => dest.Email,
                opt => opt.Ignore()).ReverseMap();
    }
}