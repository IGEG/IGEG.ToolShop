using AutoMapper;
using IGEG.ToolShop.Application.Contracts.Percistance;
using IGEG.ToolShop.Application.Dtos;
using IGEG.ToolShop.Application.Logging;
using MediatR;

namespace IGEG.ToolShop.Application.Features.Category.Queries.GetCategoryByUrl
{
    public class GetCategoryByUrlQueryHandler : IRequestHandler<GetCategoryByUrlQuery, CategoryDto>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _repository;
        private readonly IAppLogger<GetCategoryByUrlQueryHandler> _logger;

        public GetCategoryByUrlQueryHandler(IMapper mapper, ICategoryRepository repository, IAppLogger<GetCategoryByUrlQueryHandler> logger)
        {
            _mapper = mapper;
            _repository = repository;
            _logger = logger;
        }
        public async Task<CategoryDto> Handle(GetCategoryByUrlQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInfo("The query {0}  is called.", nameof(GetCategoryByUrlQuery));

            var category = await _repository.GetCategoryByUrlAsync(request.url);
            var categoryDto = _mapper.Map<CategoryDto>(category);

            _logger.LogInfo("The query {0} was executed successfully.", nameof(GetCategoryByUrlQuery));

            return categoryDto;
        }
    }
}
