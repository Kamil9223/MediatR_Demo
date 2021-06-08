using AutoMapper;
using Dto.Commands.Products;
using Dto.Dtos;
using Dto.Notifications;
using Dto.Queries.Products;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProductController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("{id}:int")]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            var result = await _mediator.Send(new GetProductQuery { Id = id });

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddProduct(ProductRequestDto dto)
        {
            var command = _mapper.Map<AddProductCommand>(dto);

            var result = await _mediator.Send(command);

            return Ok(result.Data);
        }

        [HttpPut("{id}:int")]
        public async Task<ActionResult> UpdateProduct(int id, ProductRequestDto dto)
        {
            var command = _mapper.Map<UpdateProductCommand>(dto,
                opt =>
            {
                opt.Items[nameof(UpdateProductCommand.Id)] = id;
            });

            var result = await _mediator.Send(command);

            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result.ErrorMessage);
        }

        [HttpGet("notify")]
        public async Task<IActionResult> Notify()
        {
            await _mediator.Publish(new NotifyRequest());
            return Ok();
        }
    }
}
