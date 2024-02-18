using AutoMapper;
using IGEG.ToolShop.Application.Contracts.Percistance;
using IGEG.ToolShop.Application.Dtos;
using IGEG.ToolShop.Application.Logging;
using MediatR;

namespace IGEG.ToolShop.Application.Features.Product.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<ProductDto>>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _repository;
        private readonly IAppLogger<GetAllProductsQueryHandler> _logger;

        public GetAllProductsQueryHandler(IMapper mapper, IProductRepository repository, IAppLogger<GetAllProductsQueryHandler> logger)
        {
            _mapper = mapper;
            _repository = repository;
            _logger = logger;
        }
        public async Task<List<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInfo("The query {0}  is called.", nameof(GetAllProductsQuery));

            var products = await _repository.GetAllAsync();
            var ProductsDto = _mapper.Map<List<ProductDto>>(products);

            _logger.LogInfo("The query {0} was executed successfully.", nameof(GetAllProductsQuery));

            return ProductsDto;
        }
    }
}
