using AutoMapper;
using Common.Common;
using Dto.Commands.Products;
using MediatR;
using Repository;
using Service.ValidatorServices;
using System.Threading;
using System.Threading.Tasks;

namespace Service.CommandHandlers.Products
{
    internal class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, IActionResult>
    {
        private readonly IValidatorService _validatorService;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(
            IValidatorService validatorService,
            IProductRepository productRepository,
            IMapper mapper)
        {
            _validatorService = validatorService;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            await _validatorService.ValidateCommand(request);

            var product = await _productRepository.GetProduct(request.Id);

            _mapper.Map(request, product);
            _productRepository.SaveChanges();

            return ActionResult.Success();
        }
    }
}
