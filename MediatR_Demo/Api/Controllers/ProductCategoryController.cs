using Dto.Dtos;
using Dto.Queries.ProductCategory;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/productCategory")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductCategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}:int")]
        public async Task<ActionResult<ProductCategoryDto>> GetCategory(int id)
        {
            var result = await _mediator.Send(new GetProductCategoryQuery { Id = id });

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddProductCategory(ProductCategoryAddRequestDto dto)
        {
            var result = await _mediator.Send(dto);

            return Ok(result.Data);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateProductCategory(int id, ProductCategoryUpdateRequestDto dto)
        {
            dto.Id = id;
            var result = await _mediator.Send(dto);

            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result.ErrorMessage);
        }
    }
}
