using AutoMapper;
using IGEG.ToolShop.Application.Contracts.Percistance;
using IGEG.ToolShop.Application.Dtos;
using IGEG.ToolShop.Application.Features.Category.Commands.CreateCategory;
using IGEG.ToolShop.Application.Logging;
using MediatR;

namespace IGEG.ToolShop.Application.Features.Category.Queries.GetAllCategories
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, List<CategoryDto>>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _repository;
        private readonly IAppLogger<GetAllCategoriesQueryHandler> _logger;

        public GetAllCategoriesQueryHandler(IMapper mapper, ICategoryRepository repository, IAppLogger<GetAllCategoriesQueryHandler> logger)
        {
            _mapper = mapper;
            _repository = repository;
            _logger = logger;
        }
        public async Task<List<CategoryDto>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInfo("The query {0}  is called.", nameof(GetAllCategoriesQuery));

            var categories = await _repository.GetAllAsync();
            var categoriesDto = _mapper.Map<List<CategoryDto>>(categories);

            _logger.LogInfo("The query {0} was executed successfully.", nameof(GetAllCategoriesQuery));

            return categoriesDto;
        }
    }
}
