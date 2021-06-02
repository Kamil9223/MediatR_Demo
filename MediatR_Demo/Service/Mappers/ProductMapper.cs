using Data.Entities;
using Dto.Commands.Products;
using Dto.Dtos;

namespace Service.Mappers
{
    internal class ProductMapper
    {
        public Product MapFromAddProductCommand(AddProductCommand command)
        {
            return new Product
            {
                Name = command.Name,
                Price = command.Price
            };
        }

        public Product MapFromUpdateProductCommand(Product product, UpdateProductCommand command)
        {
            product.Name = command.Name;
            product.Price = command.Price;

            return product;
        }

        public ProductDto MapToProductDto(Product product)
        {
            return new ProductDto
            {
                Name = product.Name,
                Price = product.Price
            };
        }
    }
}
