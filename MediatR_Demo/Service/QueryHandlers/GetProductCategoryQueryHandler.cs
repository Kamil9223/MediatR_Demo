using AutoMapper;
using Dto.Dtos;
using Dto.Queries.ProductCategory;
using MediatR;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Service.QueryHandlers
{
    internal class GetProductCategoryQueryHandler : IRequestHandler<GetProductCategoryQuery, ProductCategoryDto>
    {
        private readonly IProductCategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetProductCategoryQueryHandler(
            IProductCategoryRepository categoryRepository,
            IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<ProductCategoryDto> Handle(GetProductCategoryQuery request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetProductCategory(request.Id);

            if (category == null)
            {
                throw new Exception("Not Found!");
            }

            return _mapper.Map<ProductCategoryDto>(category);
        }
    }
}
