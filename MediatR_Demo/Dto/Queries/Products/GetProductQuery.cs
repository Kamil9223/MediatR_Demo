using Dto.Dtos;
using MediatR;

namespace Dto.Queries.Products
{
    public class GetProductQuery : IRequest<ProductDto>
    {
        public int Id { get; set; }
    }
}
