using Common.Common;
using Dto.Commands.Products;
using MediatR;
using Repository;
using Service.Mappers;
using Service.ValidatorServices;
using System.Threading;
using System.Threading.Tasks;

namespace Service.CommandHandlers.Products
{
    internal class AddProductCommandHandler : IRequestHandler<AddProductCommand, IActionResult<int>>
    {
        private readonly IValidatorService _validatorService;
        private readonly IProductRepository _productRepository;
        private readonly ProductMapper _productMapper;

        public AddProductCommandHandler(
            IValidatorService validatorService,
            IProductRepository productRepository)
        {
            _validatorService = validatorService;
            _productRepository = productRepository;
            _productMapper = new ProductMapper();
        }

        public async Task<IActionResult<int>> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            await _validatorService.ValidateCommand(request);

            var product = _productMapper.MapFromAddProductCommand(request);

            _productRepository.Add(product);

            return ActionResult<int>.Success(product.Id);
        }
    }
}
