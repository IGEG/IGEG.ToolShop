using AutoMapper;
using IGEG.ToolShop.Application.Contracts.Percistance;
using IGEG.ToolShop.Application.Dtos;
using IGEG.ToolShop.Application.Logging;
using MediatR;

namespace IGEG.ToolShop.Application.Features.Product.Queries.GetProductsByUrl
{
    public class GetProductsByUrlQueryHandler : IRequestHandler<GetProductsByUrlQuery, List<ProductDto>>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _repository;
        private readonly IAppLogger<GetProductsByUrlQueryHandler> _logger;

        public GetProductsByUrlQueryHandler(IMapper mapper, IProductRepository repository, IAppLogger<GetProductsByUrlQueryHandler> logger)
        {
            _mapper = mapper;
            _repository = repository;
            _logger = logger;
        }
        public async Task<List<ProductDto>> Handle(GetProductsByUrlQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInfo("The query {0}  is called.", nameof(GetProductsByUrlQuery));

            var products = await _repository.GetProductsByUrlASync(request.productUrl);
            var productsDto = _mapper.Map<List<ProductDto>>(products);

            _logger.LogInfo("The query {0} was executed successfully.", nameof(GetProductsByUrlQuery));

            return productsDto;
        }
    }
}
