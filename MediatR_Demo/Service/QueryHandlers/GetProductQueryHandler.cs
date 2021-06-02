using Dto.Dtos;
using Dto.Queries.Products;
using MediatR;
using Repository;
using Service.Mappers;
using Service.ValidatorServices;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Service.QueryHandlers
{
    internal class GetProductQueryHandler : IRequestHandler<GetProductQuery, ProductDto>
    {
        private readonly IValidatorService _validatorService;
        private readonly IProductRepository _productRepository;
        private readonly ProductMapper _productMapper;

        public GetProductQueryHandler(
            IValidatorService validatorService,
            IProductRepository productRepository)
        {
            _validatorService = validatorService;
            _productRepository = productRepository;
            _productMapper = new ProductMapper();
        }

        public async Task<ProductDto> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProduct(request.Id);

            if (product == null)
            {
                throw new Exception("Not Found!");
            }

            return _productMapper.MapToProductDto(product);
        }
    }
}
