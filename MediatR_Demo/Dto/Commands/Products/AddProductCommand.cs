using Common.Common;
using MediatR;

namespace Dto.Commands.Products
{
    public class AddProductCommand : IRequest<IActionResult<int>>, ICommand
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int ProductCategoryId { get; set; }
    }
}
