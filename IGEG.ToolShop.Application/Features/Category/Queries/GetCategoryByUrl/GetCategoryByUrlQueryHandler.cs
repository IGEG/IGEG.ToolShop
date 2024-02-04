using AutoMapper;
using IGEG.ToolShop.Application.Contracts.Percistance;
using IGEG.ToolShop.Application.Dtos;
using MediatR;

namespace IGEG.ToolShop.Application.Features.Category.Queries.GetCategoryByUrl
{
    public class GetCategoryByUrlQueryHandler : IRequestHandler<GetCategoryByUrlQuery, CategoryDto>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _repository;

        public GetCategoryByUrlQueryHandler(IMapper mapper, ICategoryRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<CategoryDto> Handle(GetCategoryByUrlQuery request, CancellationToken cancellationToken)
        {
            var category = await _repository.GetCategoryByUrlAsync(request.url);
            var categoryDto = _mapper.Map<CategoryDto>(category);
            return categoryDto;
        }
    }
}
