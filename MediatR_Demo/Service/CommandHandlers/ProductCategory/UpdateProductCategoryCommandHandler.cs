using AutoMapper;
using Common.Common;
using Dto.Dtos;
using MediatR;
using Repository;
using Service.ValidatorServices;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Service.CommandHandlers.ProductCategory
{
    internal class UpdateProductCategoryCommandHandler : IRequestHandler<ProductCategoryUpdateRequestDto, IActionResult>
    {
        private readonly IValidatorService _validatorService;
        private readonly IProductCategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public UpdateProductCategoryCommandHandler(
            IValidatorService validatorService,
            IProductCategoryRepository categoryRepository,
            IMapper mapper)
        {
            _validatorService = validatorService;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Handle(ProductCategoryUpdateRequestDto request, CancellationToken cancellationToken)
        {
            await _validatorService.ValidateCommand(request);

            var category = await _categoryRepository.GetProductCategory(request.Id);

            _mapper.Map(request, category);
            _categoryRepository.SaveChanges();

            return ActionResult.Success();
        }
    }
}
