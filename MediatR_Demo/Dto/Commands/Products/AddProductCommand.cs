using Common.Common;
using MediatR;

namespace Dto.Commands.Products
{
    public class AddProductCommand : IRequest<IActionResult<int>>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
