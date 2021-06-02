﻿using Common.Common;
using Dto.Commands.Products;
using MediatR;
using Repository;
using Service.Mappers;
using Service.ValidatorServices;
using System.Threading;
using System.Threading.Tasks;

namespace Service.CommandHandlers.Products
{
    internal class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, IActionResult>
    {
        private readonly IValidatorService _validatorService;
        private readonly IProductRepository _productRepository;
        private readonly ProductMapper _productMapper;

        public UpdateProductCommandHandler(
            IValidatorService validatorService,
            IProductRepository productRepository)
        {
            _validatorService = validatorService;
            _productRepository = productRepository;
            _productMapper = new ProductMapper();
        }

        public async Task<IActionResult> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            await _validatorService.ValidateCommand(request);

            var product = await _productRepository.GetProduct(1);

            _productMapper.MapFromUpdateProductCommand(product, request);

            return ActionResult.Success();
        }
    }
}
