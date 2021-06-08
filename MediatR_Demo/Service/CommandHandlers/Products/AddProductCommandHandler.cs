using AutoMapper;
using Common.Common;
using Data.Entities;
using Dto.Commands.Products;
using MediatR;
using Repository;
using Service.ValidatorServices;
using System.Threading;
using System.Threading.Tasks;

namespace Service.CommandHandlers.Products
{
    internal class AddProductCommandHandler : IRequestHandler<AddProductCommand, IActionResult<int>>
    {
        private readonly IValidatorService _validatorService;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public AddProductCommandHandler(
            IValidatorService validatorService,
            IProductRepository productRepository,
            IMapper mapper)
        {
            _validatorService = validatorService;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult<int>> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            await _validatorService.ValidateCommand(request);

            var product = _mapper.Map<Product>(request);

            _productRepository.Add(product);

            return ActionResult<int>.Success(product.Id);
        }
    }
}
