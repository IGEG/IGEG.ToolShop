using AutoMapper;
using IGEG.ToolShop.Application.Contracts.Percistance;
using IGEG.ToolShop.Application.Dtos;
using IGEG.ToolShop.Application.Logging;
using MediatR;

namespace IGEG.ToolShop.Application.Features.Product.Queries.GetProductById
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDto> 
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _repository;
        private readonly IAppLogger<GetProductByIdQueryHandler> _logger;

        public GetProductByIdQueryHandler(IMapper mapper, IProductRepository repository, IAppLogger<GetProductByIdQueryHandler> logger)
        {
            _mapper = mapper;
            _repository = repository;
            _logger = logger;
        }
        public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInfo("The query {0}  is called.", nameof(GetProductByIdQuery));

            var product = await _repository.GetByIdAsync(request.Id);
            var productDto = _mapper.Map<ProductDto>(product);

            _logger.LogInfo("The query {0} was executed successfully.", nameof(GetProductByIdQuery));

            return productDto;
        }
    }
}
