using Dto.Dtos;
using MediatR;

namespace Dto.Queries.Products
{
    public class GetProductQuery : IRequest<ProductDto>, IQuery
    {
        public int Id { get; set; }
    }
}
