using AutoMapper;
using Common.Common;
using Data.Entities;
using Dto.Dtos;
using MediatR;
using Repository;
using Service.ValidatorServices;
using System.Threading;
using System.Threading.Tasks;

namespace Service.CommandHandlers.ProductCategory
{
    internal class AddProductCategoryCommandHandler : IRequestHandler<ProductCategoryAddRequestDto, IActionResult<int>>
    {
        private readonly IValidatorService _validatorService;
        private readonly IProductCategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public AddProductCategoryCommandHandler(
            IValidatorService validatorService,
            IProductCategoryRepository categoryRepository,
            IMapper mapper)
        {
            _validatorService = validatorService;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult<int>> Handle(ProductCategoryAddRequestDto request, CancellationToken cancellationToken)
        {
            await _validatorService.ValidateCommand(request);

            var category = _mapper.Map<Data.Entities.ProductCategory>(request);

            _categoryRepository.Add(category);

            return ActionResult<int>.Success(category.Id);
        }
    }
}
