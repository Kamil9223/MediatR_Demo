using AutoMapper;
using Data.Entities;
using Dto.Dtos;

namespace Service.Mappers.EntityMappers
{
    internal class ProductCategoryMapperProfile : Profile
    {
        public ProductCategoryMapperProfile()
        {
            CreateMap<ProductCategory, ProductCategoryDto>();

            CreateMap<ProductCategoryAddRequestDto, ProductCategory>()
                .ForMember(e => e.Id, src => src.Ignore())
                .ForMember(e => e.Products, src => src.Ignore());

            CreateMap<ProductCategoryUpdateRequestDto, ProductCategory>()
                .ForMember(e => e.Id, src => src.Ignore())
                .ForMember(e => e.Products, src => src.Ignore());
        }
    }
}
