using Common.Common;
using MediatR;

namespace Dto.Commands.Products
{
    public class UpdateProductCommand : IRequest<IActionResult>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
