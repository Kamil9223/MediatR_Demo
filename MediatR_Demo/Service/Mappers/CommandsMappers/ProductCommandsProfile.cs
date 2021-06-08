using AutoMapper;
using Dto.Commands.Products;
using Dto.Dtos;
using Service.Mappers.Resolvers;

namespace Service.Mappers.CommandsMappers
{
    internal class ProductCommandsProfile : Profile
    {
        public ProductCommandsProfile()
        {
            CreateMap<ProductRequestDto, AddProductCommand>();

            CreateMap<ProductRequestDto, UpdateProductCommand>()
                .ForMember(e => e.Id, src => src.MapFrom(new KeyResolver<int>(nameof(UpdateProductCommand.Id))));
        }
    }
}
