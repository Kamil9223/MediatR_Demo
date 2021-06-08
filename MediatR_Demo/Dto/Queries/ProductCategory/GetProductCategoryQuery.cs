using Dto.Dtos;
using MediatR;

namespace Dto.Queries.ProductCategory
{
    public class GetProductCategoryQuery : IRequest<ProductCategoryDto>, IQuery
    {
        public int Id { get; set; }
    }
}
