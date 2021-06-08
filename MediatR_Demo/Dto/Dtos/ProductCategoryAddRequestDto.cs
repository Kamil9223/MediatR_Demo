using Common.Common;
using MediatR;

namespace Dto.Dtos
{
    /// <summary>
    /// dto to add product category
    /// </summary>
    public class ProductCategoryAddRequestDto : IRequest<IActionResult<int>>, ICommand
    {
        /// <summary>
        /// Category name
        /// </summary>
        public string CategoryName { get; set; }
    }
}
