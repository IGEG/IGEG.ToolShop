using AutoMapper;
using IGEG.ToolShop.Application.Contracts.Percistance;
using IGEG.ToolShop.Application.Dtos;
using MediatR;

namespace IGEG.ToolShop.Application.Features.Product.Queries.GetProductsByUrl
{
    public class GetProductsByUrlQueryHandler : IRequestHandler<GetProductsByUrlQuery, List<ProductDto>>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _repository;

        public GetProductsByUrlQueryHandler(IMapper mapper, IProductRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<List<ProductDto>> Handle(GetProductsByUrlQuery request, CancellationToken cancellationToken)
        {
            var products = await _repository.GetProductsByUrlASync(request.productUrl);
            var productsDto = _mapper.Map<List<ProductDto>>(products);
            return productsDto;
        }
    }
}
