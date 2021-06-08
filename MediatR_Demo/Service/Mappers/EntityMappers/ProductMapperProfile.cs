using AutoMapper;
using Data.Entities;
using Dto.Commands.Products;
using Dto.Dtos;

namespace Service.Mappers.EntityMappers
{
    internal class ProductMapperProfile : Profile
    {
        public ProductMapperProfile()
        {
            CreateMap<Product, ProductDto>();

            CreateMap<AddProductCommand, Product>()
                .ForMember(e => e.Id, src => src.Ignore())
                .ForMember(e => e.ProductCategory, src => src.Ignore());

            CreateMap<UpdateProductCommand, Product>()
                .ForMember(e => e.Id, src => src.Ignore())
                .ForMember(e => e.ProductCategory, src => src.Ignore());
        }
    }
}
