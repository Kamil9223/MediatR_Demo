using Common.Common;
using MediatR;
using System.Text.Json.Serialization;

namespace Dto.Dtos
{
    /// <summary>
    /// Dto for updating product category
    /// </summary>
    public class ProductCategoryUpdateRequestDto : IRequest<IActionResult>, ICommand
    {
        /// <summary>
        /// Category name
        /// </summary>
        public string CategoryName { get; set; }

        [JsonIgnore]
        public int Id { get; set; }
    }
}
